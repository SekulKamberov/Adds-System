namespace AddsSystem.DAL.Repositories
{
    using AddsSystem.DAL.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(IAddsSystemDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return this.DbSet; }
        }


        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public IAddsSystemDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public void Add(T entity)
        {
            //var entry = AttachIfDetached(entity);
            //entry.State = EntityState.Added;
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            //var entry = AttachIfDetached(entity);
            //entry.State = EntityState.Modified;
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            //var entry = AttachIfDetached(entity);
            //entry.State = EntityState.Deleted;
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }

        //public virtual T Attach(T entity)
        //{
        //    return this.Context.Set<T>().Attach(entity);
        //}

        //public virtual void Detach(T entity)
        //{
        //    var entry = this.Context.Entry(entity);
        //    entry.State = EntityState.Detached;
        //}


        //public static IQueryable<T> Include<T1>(this DbSet<T> DbSet, params Expression<Func<T, object>>[] includes)
        //    where T1 : class
        //{
        //    IQueryable<T> query = null;
        //    foreach (var include in includes)
        //    {
        //        query = DbSet.Include(include);
        //    }

        //    return query == null ? DbSet : query;
        //}


        //public static IQueryable<T> IncludeMultiple<T1>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T1 : class
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));
        //    }

        //    return query;
        //}

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = this.All;

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }

            return set;
        }

        //public IQueryable<T> CurrentUser(T Db)
        //{
        //    return this.DbSet.Include(x => x.DbSet.);
        //}
    }
}
