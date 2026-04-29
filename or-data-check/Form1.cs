using System;
using System.Configuration;
using System.Windows.Forms;

namespace or_data_check
{
    public partial class Form1 : Form
    {
        private readonly ExcelService _excelService; //IExcelService
        private readonly DatabaseService _databaseService; //IDatabaseService

        private readonly string _filePath;

        public Form1(/*IExcelService excelService, IDatabaseService databaseService*/)
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? throw new Exception("No connection string found in configuration file.");

            _filePath = ConfigurationManager.AppSettings["ExcelFilePath"]
                ?? throw new Exception("No path to excel file in configuration.");

            //nie koduj do konkretnej implementacji;
            //użyj abstrakcji i wstrzyknij zależność przez kontener DependencyInjection (jak przejdziesz na aktualnego .neta to będziesz miał wbudowanego, w .net Frameworku trzeba by dodać zewnętrzną bibliotekę - np NInject)
            //- dziś użyjeż EPPlus, a jutro może sie okazać że jednak trzeba przejść na inną kontrolke
            //wtedy będzie trzeba zmieniać wszystkie miejsca, gdzie EPPlus był użyty
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