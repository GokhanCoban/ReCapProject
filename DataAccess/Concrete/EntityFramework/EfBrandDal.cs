using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var addedEntity = reCapProjectDBContext.Entry(entity);
                addedEntity.State =EntityState.Added;
                reCapProjectDBContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var deletedEntity = reCapProjectDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectDBContext.SaveChanges();
            }
            
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                return reCapProjectDBContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                return filter == null ? reCapProjectDBContext.Set<Brand>().ToList() : reCapProjectDBContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var updatedEntity = reCapProjectDBContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectDBContext.SaveChanges();
            }
        }
    }
}
