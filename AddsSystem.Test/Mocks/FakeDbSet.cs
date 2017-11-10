namespace AddsSystem.Test.Mocks
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class FakeDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : class
    {
        protected HashSet<T> Set;
        protected IQueryable Query;

        public FakeDbSet()
        {
            this.Set = new HashSet<T>();
            this.Query = this.Set.AsQueryable();
        }

        public override T Add(T entity)
        {
            this.Set.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            this.Set.Remove(entity);
            return entity;
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return this.Query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.Query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Set.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Set.GetEnumerator();
        }

    }
}
