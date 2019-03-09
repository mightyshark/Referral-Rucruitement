using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData.Configurations
{
    public class RmConfigurations : EntityTypeConfiguration<RecruitementManager>
    {
        public RmConfigurations()
        {


            HasRequired(ch => ch.ChiefHumanRessources).WithMany(r => r.RecruitementManagers).HasForeignKey(ch => ch.CHROId).WillCascadeOnDelete(false);


        }
    }
}
