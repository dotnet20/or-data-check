using System;
using System.Configuration;
using System.Windows.Forms;

namespace or_data_check
{
    public partial class Form1 : Form
    {
        private readonly ExcelService _excelService;
        private readonly DatabaseService _databaseService;

        private readonly string _filePath;

        public Form1()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? throw new Exception("No connection string found in configuration file.");

            _filePath = ConfigurationManager.AppSettings["ExcelFilePath"]
                ?? throw new Exception("No path to excel file in configuration.");

            _excelService = new ExcelService();
            _databaseService = new DatabaseService(connectionString);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadExcelData();
            LoadSqlData();
        }

        private void LoadExcelData()
        {
            try
            {
                dgvExcel.DataSource = _excelService.LoadData(_filePath, maxRows: 10, maxCols: 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Excel data: " + ex.Message, "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSqlData()
        {
            try
            {
                dgvDatabase.DataSource = _databaseService.GetTransactions(limit: 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}