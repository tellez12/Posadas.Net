using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;

namespace Posadas.Domain.UOW
{

    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        internal MyContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(MyContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity GetById(object id, string includeProperty)
        {
            return Get(filter: e => (object)e.Id == id, includeProperties: includeProperty).FirstOrDefault();
        }

        public virtual void Insert(TEntity entity)
        {
            //SetDates(entity);

            DbSet.Add(entity);
        }

        public virtual void Insert(List<TEntity> list)
        {
            //SetDates(entity);
            foreach (var entity in list)
            {
                DbSet.Add(entity);
            }

        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }



        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);



        }

        public virtual void Delete(List<TEntity> list)
        {
            //SetDates(entity);
            foreach (var entity in list)
            {
                Delete(entity);
            }

        }

        public virtual void Update(TEntity entityToUpdate)
        {

            entityToUpdate.FechaModificacion = DateTime.Now;
            DbSet.Attach(entityToUpdate);
            var entry = Context.Entry(entityToUpdate);
            entry.State = EntityState.Modified;

        }
        public virtual void Update(List<TEntity> list)
        {
            //SetDates(entity);
            foreach (var entity in list)
            {
                Update(entity);
            }

        }
    }
}

