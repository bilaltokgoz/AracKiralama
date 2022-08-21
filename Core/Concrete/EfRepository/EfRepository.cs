using Core.Abstact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Concrete
{
    public class EfRepository<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where TContext : DbContext, new()
    {
        public T Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return context.Set<T>().FirstOrDefault(filter);
            }
          
        }

        public List<T> GetAll(Expression<Func<T,bool>>filter=null)
        {
            using (TContext context=new TContext())
            {
                return filter==null?context.Set<T>().ToList():context.Set<T>().Where(filter).ToList();
            }
        }
        public void Add(T entity)
        {
          using(TContext context=new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

     

        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }


    }
}
