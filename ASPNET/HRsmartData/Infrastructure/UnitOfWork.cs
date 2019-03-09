using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public class UnitOfWork : IUnitOfWork
    {
        private HRsmartContext myContext = null;
        private DatabaseFactory dbFactory = null;
         public UnitOfWork(DatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public HRsmartContext MyContext
        {
            get { return dbFactory.MyContext; }
        }
        public void Commit()
        {
            MyContext.SaveChanges();

        }

        public RepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(dbFactory);
        }

        public void Dispose()
        {
            MyContext.Dispose();
        }
    }
}
