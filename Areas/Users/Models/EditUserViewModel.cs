using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspStudio_Boilerplate.Models;
using AutoMapper;

namespace AspStudio_Boilerplate.Areas.Users.Models
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public int Id { get; set; }
        public List<EditUserRolesViewModel> Roles { get; set; } = new List<EditUserRolesViewModel>();

    }

    public class EditUserViewModelProfile : Profile
    {
        public EditUserViewModelProfile()
        {
            CreateMap<EditUserViewModel, ApplicationUser>().ReverseMap(); // Output is ApplicationUser
        }
    }

    public class EditUserRolesViewModel
    {
        public string Name { get; set; }
        public bool Has { get; set; }
    }
}
