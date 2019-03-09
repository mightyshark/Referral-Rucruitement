using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRsmartWeb.Models
{
 public    class RoleMVC: IdentityRole

    {   
       // public string Name;
        public RoleMVC()
        {

        }
        public RoleMVC(string Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
            
        }

    }
}