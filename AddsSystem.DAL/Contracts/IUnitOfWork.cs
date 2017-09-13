namespace AddsSystem.DAL.Contracts
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
