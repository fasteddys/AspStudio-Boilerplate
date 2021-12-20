using AspStudio_Boilerplate.Infrastructure.Entities.Identity;
using AutoMapper;

namespace AspStudio_Boilerplate.Infrastructure.Entities.Users.ViewModels;

public class EditUserViewModelProfile : Profile
{
    public EditUserViewModelProfile()
    {
        CreateMap<EditUserViewModel, ApplicationUser>().ReverseMap(); // Output is ApplicationUser
    }
}