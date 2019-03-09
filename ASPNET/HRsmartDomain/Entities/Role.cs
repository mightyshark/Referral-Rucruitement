using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain
{
   public   class Role: IdentityRole
    {   [JsonIgnore]
        public override ICollection<IdentityUserRole> Users
        {
            get
            {
                return base.Users;
            }
        }
    }
}
