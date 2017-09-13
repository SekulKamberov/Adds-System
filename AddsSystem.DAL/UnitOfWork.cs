namespace AddsSystem.DAL
{
    using System;
    using Contracts;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IAddsSystemDbContext context;

        public UnitOfWork(IAddsSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}