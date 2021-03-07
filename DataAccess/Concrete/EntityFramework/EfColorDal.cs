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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var addedEntity = reCapProjectDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectDBContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var deletedEntity = reCapProjectDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectDBContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                return reCapProjectDBContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                return filter == null ? reCapProjectDBContext.Set<Color>().ToList() : reCapProjectDBContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
