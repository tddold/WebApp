using System;

namespace App.Data.Common.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
