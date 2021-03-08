using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext reCapProjectDBContext = new TContext())
            {
                var addedEntity = reCapProjectDBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectDBContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapProjectDBContext = new TContext())
            {
                var deletedEntity = reCapProjectDBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectDBContext.SaveChanges();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapProjectDBContext = new TContext())
            {
                return reCapProjectDBContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext reCapProjectDBContext = new TContext())
            {
                return filter == null ? reCapProjectDBContext.Set<TEntity>().ToList() 
                                      : reCapProjectDBContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext reCapProjectDBContext = new TContext())
            {
                var updatedEntity = reCapProjectDBContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectDBContext.SaveChanges();
            }
        }
    }
}
