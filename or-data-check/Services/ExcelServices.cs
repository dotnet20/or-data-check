using OfficeOpenXml;
using or_data_check.Interface;
using System.Data;

namespace or_data_check.Services
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

            DataTable dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets[0];
                if (ws.Dimension == null) return dt;

                int rows = ws.Dimension.Rows;
                int cols = Math.Min(maxCols, ws.Dimension.Columns);

                for (int c = 1; c <= cols; c++)
                {
                    string colName = ws.Cells[1, c].Text;
                    dt.Columns.Add(string.IsNullOrWhiteSpace(colName) ? $"Kolumna {c}" : colName);
                }

                for (int r = 2; r <= Math.Min(maxRows + 1, rows); r++)
                {
                    DataRow dr = dt.NewRow();
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