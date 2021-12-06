using AspStudio_Boilerplate.Models;
using AutoMapper;

namespace AspStudio_Boilerplate.Areas.Users.Models
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

    }

    public class EditUserViewModelProfile : Profile
    {
        public EditUserViewModelProfile()
        {
            CreateMap<EditUserViewModel, ApplicationUser>().ReverseMap(); // Output is ApplicationUser
        }
    }
}
