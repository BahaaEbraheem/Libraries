using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_CRUD.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Age { get; set; }
        public string Password { get; set; }



    }
}
