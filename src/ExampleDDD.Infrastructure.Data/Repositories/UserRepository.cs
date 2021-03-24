using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Domain.Interfaces;
using ExampleDDD.Infrastructure.Data.Context;

namespace ExampleDDD.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(User user)
        {
            await _context.Users
                .AddAsync(user)
                .ConfigureAwait(false);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Addresses)
                .Include(u => u.Emails)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Addresses)
                .Include(u => u.Emails)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
