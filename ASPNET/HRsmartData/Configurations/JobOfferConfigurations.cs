using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData.Configurations
{
    public class JobOfferConfigurations : EntityTypeConfiguration<JobOffer>
    {
        public JobOfferConfigurations()
        {

            //Many to One
            HasOptional(e => e.Employee).WithMany(jo => jo.JobOffers).HasForeignKey(e => e.EmployeeId).WillCascadeOnDelete(false);


            //One To Many
          //  HasMany(c => c.Candidates).WithRequired(jo => jo.JobOffer).HasForeignKey(jo => jo.JobOffreId).WillCascadeOnDelete(false);

            //Many To One
            HasRequired(r => r.RecruitementManager).WithMany(jo => jo.JobOffers).HasForeignKey(r => r.RmId).WillCascadeOnDelete(false);
        }
    }
}
