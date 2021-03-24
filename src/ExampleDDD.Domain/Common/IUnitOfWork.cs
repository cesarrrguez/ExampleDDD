using System;
using System.Threading.Tasks;

namespace ExampleDDD.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
