using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace or_data_check.Interface
{
    public interface IExcelService
    {
        DataTable LoadData(string filePath, int maxRows = 10, int maxCols = 5);
    }
}
