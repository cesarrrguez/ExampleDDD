using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
