﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspStudio_Boilerplate.Entities.Models;
using AspStudio_Boilerplate.Models;
using AutoMapper;

namespace AspStudio_Boilerplate.Areas.Administration.Models
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
        public List<string> Roles { get; set; }

    }

    public class EditUserViewModelProfile : Profile
    {
        public EditUserViewModelProfile()
        {
            CreateMap<EditUserViewModel, ApplicationUser>().ReverseMap(); // Output is ApplicationUser
        }
    }
}