using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRsmartWeb.Models
{
    public class UserMVC : IdentityUser
    {
        [DataType(DataType.Password)]
        [Required]
        [Compare("PasswordHash")] //equal avec le champs password
        [NotMapped] //not mapped in the database
        public String ConfirmPassword { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe
        {
            get; set;
        }
        public UserMVC() : base()
        {

        }

        public UserMVC(string Id,string UserName) 
        {
            this.Id = Id;
            this.UserName = UserName;
            
        }
    }
}