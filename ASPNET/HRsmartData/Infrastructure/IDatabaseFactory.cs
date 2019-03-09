using HRsmartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public interface IDatabaseFactory : IDisposable
    {
        // retourner une instance du context
        HRsmartContext MyContext { get; }

    }
}
