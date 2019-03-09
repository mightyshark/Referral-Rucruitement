
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class RoleViewModel
    {
        public virtual List<RoleMVC> RoleMVC { get; set; }
        public virtual List<UserMVC> UserMVC { get; set; }
        public virtual List<UserRoleMVC> UserRoleMVC { get; set; }
       public RoleViewModel()
        {

        }
    }
}