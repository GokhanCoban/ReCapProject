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
    public class EfCarDal : ICarDal
    {
      
        public void Add(Car entity)
        {
            using (ReCapProjectDBContext reCapProjectContext=new ReCapProjectDBContext())
            {
                var addedEntity = reCapProjectContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectDBContext reCapProjectContext=new ReCapProjectDBContext())
            {
                var deletedEntity = reCapProjectContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectDBContext reCapProjectContext=new ReCapProjectDBContext())
            {
                return reCapProjectContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDBContext reCapProjectContext=new ReCapProjectDBContext())
            {
                return filter == null ? reCapProjectContext.Set<Car>().ToList() : reCapProjectContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectDBContext reCapProjectContext=new ReCapProjectDBContext())
            {
                var updatedEntity = reCapProjectContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectContext.SaveChanges();
            }
           
        }
    }
}
