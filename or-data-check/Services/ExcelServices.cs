using OfficeOpenXml;
using or_data_check.Interface;
using System.Data;

namespace or_data_check
{
    public class ExcelService : IExcelService
    {
        public ExcelService()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Name");
        }

        public DataTable LoadData(string filePath, int maxRows = 10, int maxCols = 5)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Excel file not found: {filePath}");
            }

            DataTable dt = new DataTable(); //tu jest przykład miejsca, gdzie można użyć przy deklaracji słowa kluczowego var - bo widać jaki jest typ

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets[0]; //nic nie mówiące nazwy zmiennych; i tu jest takie miejsce gdzie var  zaciemnia, bo nie wiadomo wprost jakiego typu jest Worksheets[0]
                if (ws.Dimension == null) return dt;

                int rows = ws.Dimension.Rows;
                int cols = Math.Min(maxCols, ws.Dimension.Columns);

                for (int c = 1; c <= cols; c++) //to też dla czytelności mogło by być w osobnej funkcji List<DataColumns> GenerateColumns() i potem dt.Columns.AddRange(columns)
                {
                    string colName = ws.Cells[1, c].Text;
                    dt.Columns.Add(string.IsNullOrWhiteSpace(colName) ? $"Column {c}" : colName);
                }


                for (int r = 2; r <= Math.Min(maxRows + 1, rows); r++)
                {
                    DataRow dr = dt.NewRow(); //metoda DataRow CreateRow()
                    for (int c = 1; c <= cols; c++)
                    {
                        dr[c - 1] = ws.Cells[r, c].Text;
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}