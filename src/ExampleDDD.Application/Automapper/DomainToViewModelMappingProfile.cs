using AutoMapper;
using ExampleDDD.Application.ViewModels;
using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Application.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(u => u.PhoneNumber, opt => opt.MapFrom(u => u.PhoneNumber.Number));

            CreateMap<UserAddress, UserAddressViewModel>()
                .ForMember(ua => ua.Street, opt => opt.MapFrom(ua => ua.Address.Street))
                .ForMember(ua => ua.City, opt => opt.MapFrom(ua => ua.Address.City))
                .ForMember(ua => ua.State, opt => opt.MapFrom(ua => ua.Address.State))
                .ForMember(ua => ua.Country, opt => opt.MapFrom(ua => ua.Address.Country))
                .ForMember(ua => ua.ZipCode, opt => opt.MapFrom(ua => ua.Address.ZipCode));

            CreateMap<UserEmail, UserEmailViewModel>()
                .ForMember(ue => ue.EmailAddress, opt => opt.MapFrom(ue => ue.Email.EmailAddress));
        }
    }
}
