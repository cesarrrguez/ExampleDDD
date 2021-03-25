using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleDDD.Application.ViewModels;

namespace ExampleDDD.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task RegisterAsync(UserViewModel userViewModel);
        Task UpdateAsync(UserViewModel userViewModel);
        Task RemoveAsync(int id);
        Task<UserViewModel> GetByIdAsync(int id);
        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}
