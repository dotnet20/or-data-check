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

            var dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                if (worksheet.Dimension == null) return dt;

                int rows = worksheet.Dimension.Rows;
                int cols = Math.Min(maxCols, worksheet.Dimension.Columns);

                GenerateColumns(worksheet, dt, cols);

                for (int r = 2; r <= Math.Min(maxRows + 1, rows); r++)
                {
                    DataRow dr = CreateRow(worksheet, dt, r, cols);
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void GenerateColumns(ExcelWorksheet worksheet, DataTable dt, int cols)
        {
            for (int c = 1; c <= cols; c++)
            {
                string colName = worksheet.Cells[1, c].Text;
                dt.Columns.Add(string.IsNullOrWhiteSpace(colName) ? $"Column {c}" : colName);
            }
        }

        private DataRow CreateRow(ExcelWorksheet worksheet, DataTable dt, int rowIndex, int cols)
        {
            DataRow dr = dt.NewRow();
            for (int c = 1; c <= cols; c++)
            {
                dr[c - 1] = worksheet.Cells[rowIndex, c].Text;
            }
            return dr;
        }
    }
}