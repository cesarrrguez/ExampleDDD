using AutoMapper;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Application.ViewModels;

namespace ExampleDDD.Application.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserAddress, UserAddressViewModel>();
            CreateMap<UserEmail, UserEmailViewModel>();
        }
    }
}
