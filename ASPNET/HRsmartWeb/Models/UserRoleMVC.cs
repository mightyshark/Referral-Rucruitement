using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
    public class UserRoleMVC : IdentityUserRole
    {
        public UserRoleMVC()
        {
                
        }
        public UserRoleMVC(string RoleId,string UserId)
        {
            this.RoleId = RoleId;
            this.UserId = UserId;
        }
    }
}