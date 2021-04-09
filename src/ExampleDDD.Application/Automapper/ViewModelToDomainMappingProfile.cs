using AutoMapper;
using ExampleDDD.Application.ViewModels;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Domain.ValueObjects;

namespace ExampleDDD.Application.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(u => u.Addresses, opt => opt.Ignore())
                .ForMember(u => u.Emails, opt => opt.Ignore())
                .ForMember(u => u.PhoneNumber, opt => opt.Ignore())
                .ConstructUsing(u => new User(u.FirstName, u.LastName, u.Age, new PhoneNumber(u.PhoneNumber)))
                .AfterMap((uvm, u) =>
                {
                    if (uvm.Addresses != null)
                    {
                        foreach (var ua in uvm.Addresses)
                            u.AddAddress(ua.Id, ua.Street, ua.City, ua.State, ua.Country, ua.ZipCode);
                    }

                    if (uvm.Emails != null)
                    {
                        foreach (var ue in uvm.Emails)
                            u.AddEmail(ue.Id, ue.EmailAddress);
                    }
                });
        }
    }
}
