using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Core
{
    public interface IPrimeTablesModel
    {
        bool[] MakeSieve(int max, int count);
    }
}
