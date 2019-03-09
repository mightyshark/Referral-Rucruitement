using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class UserViewModel
    {

        [Key]
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The First Name is Required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name is Required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "The Role is Required")]

        public Roles Role { get; set; }

    }
}