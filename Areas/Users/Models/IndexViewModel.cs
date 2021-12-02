using System.Collections.Generic;
using AspStudio_Boilerplate.Models;

namespace AspStudio_Boilerplate.Areas.Users.Models;

public class IndexViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CreatedAt { get; set; }
}