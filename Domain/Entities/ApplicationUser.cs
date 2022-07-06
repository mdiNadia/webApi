using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public Guid? Photo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
