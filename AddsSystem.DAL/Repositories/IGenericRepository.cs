namespace AddsSystem.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);

        IQueryable<T> All { get; }

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

           //IQueryable<T> Include<T1>(IQueryable<T1> DbSet, params Expression<Func<T, object>>[] includes) where T1 : class;

        //IQueryable<T> IncludeMultiple<T1>(this IQueryable<T1> query, params Expression<Func<T, object>>[] includes) where T1 : class;

        IQueryable<T> Include(params Expression<Func<T, object>>[] includeExpressions);

        //IEnumerable<T> CurrentUser();
    }
}