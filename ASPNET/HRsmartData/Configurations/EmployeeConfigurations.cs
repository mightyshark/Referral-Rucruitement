using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData.Configurations
{
    public class EmployeeConfigurations : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfigurations()
        {
            //One To Many

            HasMany(c => c.Candidates).WithRequired(e => e.Employee).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(false);

            //Many to One

            HasRequired(ch => ch.ChiefHumanRessources).WithMany(e => e.Employees).HasForeignKey(ch => ch.CHROId).WillCascadeOnDelete(false);
        }

    }
}
