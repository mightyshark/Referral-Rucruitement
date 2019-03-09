using HRsmartDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData.Configurations
{
    public class AddressConfigurations : ComplexTypeConfiguration<Address>
    {
        public AddressConfigurations()
        {
            Property(p => p.city).IsOptional();
            Property(p => p.country).IsRequired();
        }

    }
}
