using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace or_data_check
{
    //skąd wybór .NET Framework i to jeszcze nie najnowszy? dlaczego nie .net Core? 

    public partial class Form1 : Form
    {
        //TO POWINNO BYĆ W KONFIGURACJI
        private string connectionString = "Server=localhost;Database=testowa_baza;Trusted_Connection=True;TrustServerCertificate=True;";
        private string filePath = "transactionDump_2026-02-10_2026_03_03_FULL.xlsx";

        public Form1()
        {
            InitializeComponent();
            ExcelPackage.License.SetNonCommercialPersonal("Name");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadExcelData();
            LoadSqlData();
        }

        private void LoadExcelData()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error: Excel file not found: " + filePath, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //OD RAZU WYNIEŚ OBSŁUGĘ PLIKU EXCEL DO ODDZIELNEJ KLASY, KTÓRA BĘDZIE ODPOWIEDZIALNA ZA WSZELKIE OPERACJE NA PLIKU EXCEL
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets[0];
                    DataTable dt = new DataTable();

                    int rows = ws.Dimension.Rows;
                    int cols = Math.Min(5, ws.Dimension.Columns);

                    for (int c = 1; c <= cols; c++)
                    {
                        string colName = ws.Cells[1, c].Text;
                        dt.Columns.Add(string.IsNullOrWhiteSpace(colName) ? $"Kolumna {c}" : colName);
                    }

                    for (int r = 2; r <= Math.Min(11, rows); r++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int c = 1; c <= cols; c++)
                        {
                            dr[c - 1] = ws.Cells[r, c].Text;
                        }
                        dt.Rows.Add(dr);
                    }

                    dgvExcel.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Excel data: " + ex.Message);
            }
        }

        private void LoadSqlData()
        {
            try
            {
                //OD RAZU WYNIEŚ OBSŁUGĘ BAZY DANYCH DO ODDZIELNEJ KLASY, KTÓRA BĘDZIE ODPOWIEDZIALNA ZA WSZELKIE OPERACJE NA BAZIE DANYCH
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //w rzeczywistości będzie baza danych z takimi kolumnami (przynajmniej z tymi istotnymi):
                    //UniqueLineId varchar(50) - to będzie CONCAT(EXPENDITURE_ITEM_ID, 'SEGMENT3')
                    //TransactionId - to będzie równ EEPENDITURE_ITEM_ID
                    //TransactionAmount decimal(18,2) 
                    //AccountingAmount decimal(18,2) 
                    //ReportingAmount decimal(18,2) 

                    //wierszy w bazie danych jest obecnie około 5mln i liczba szybko rośnie, więc jakby co to nie próbuj pobierać wszystkich :)
                    


                    string query = "SELECT TOP 10 EXPENDITURE_ITEM_ID, EXPENDITURE_TYPE_NAME, PROJECT_NUM, PROJFUNC_BURDENED_COST FROM [dbo].[ExpenditureTransactions]";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    dgvDatabase.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
    }
}