using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        RepositoryBase<T> GetRepository<T>() where T :class;
    }
}
