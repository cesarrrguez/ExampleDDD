using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Infrastructure.Data.Mappings;

namespace ExampleDDD.Infrastructure.Data.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public const string DefaultSchema = "data";

        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserAddressMap());
            modelBuilder.ApplyConfiguration(new UserEmailMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
