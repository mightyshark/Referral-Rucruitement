using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData.Configurations
{
    public class DateTimeConvention : Convention
    {
        public DateTimeConvention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
