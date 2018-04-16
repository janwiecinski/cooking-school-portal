using CookingSchool.DAL.Models;
using System;
using System.Linq;

namespace CookingSchool.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        CookingContext Context = new CookingContext();

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            entity.CreatedOnUtc = entity.ModifiedOnUtc = DateTime.UtcNow;
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);

            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            entity.ModifiedOnUtc = DateTime.UtcNow;

            Context.Set<T>().Attach(entity);

            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            Context.SaveChanges();
        }
    }
}