using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace or_data_check.Interface
{
    public interface IDatabaseService
    {
        DataTable GetTransactions(int limit = 10);
    }
}
