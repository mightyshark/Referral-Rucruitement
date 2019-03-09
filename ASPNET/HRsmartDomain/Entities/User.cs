using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace HRsmartDomain
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        public override ICollection<IdentityUserClaim> Claims
        {
            get
            {
                return base.Claims;
            }
        }
        [JsonIgnore]
        public override ICollection<IdentityUserRole> Roles
        {
            get
            {
                return base.Roles;
            }
        }
        [JsonIgnore]
        public override ICollection<IdentityUserLogin> Logins
        {
            get
            {
                return base.Logins;
            }
        }

        public object Role { get; set; }

        //[Key]
        //public int UserId { get; set; }

        //[MinLength(8, ErrorMessage = "At least 8 characters are required")]
        //[MaxLength(8, ErrorMessage = "At least 8 characters are required")]
        //public string Cin { get; set; }



        //public string Matricule { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public int Age { get; set; }

        //public Gender Gender { get; set; }

        //public string Adresse { get; set; }


        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
        //public string UserName { get; set; }
        //[DataType(DataType.Password)]

        //[MinLength(8, ErrorMessage = "At least 8 characters are required")]
        //public string Password { get; set; }
        //[DataType(DataType.Password)]

        //[Compare("Password")]
        //public string VerifPassword { get; set; }
        //public Role Role { get; set; }
        //public User()
        //{

        // }

        public override string ToString()
        {
            return "UserName : " + UserName + "Email : " + Email + "Role : " + Role;
        }

    }
}
