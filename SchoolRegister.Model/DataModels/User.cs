using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels
{
    public class User : IdentityUser<int>
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        required public string Title { get; set; }

        public User()
        {
            RegistrationDate = DateTime.UtcNow;
        }
    }
}
