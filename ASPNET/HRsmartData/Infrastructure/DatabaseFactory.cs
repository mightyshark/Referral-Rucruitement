using HRsmartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private HRsmartContext ctx;
        public DatabaseFactory()
        {
            ctx = new HRsmartContext();
        }
        public HRsmartContext MyContext
        {
            get
            {
                return ctx;
            }


        }

        protected override void DisposeCore()
        {
            if (MyContext != null)
            {
                MyContext.Dispose();

            }
        }
    }
}
