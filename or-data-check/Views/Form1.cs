using or_data_check.Interface;
using or_data_check.Services;
using System.Data;

namespace or_data_check
{
    public partial class Form1 : Form
    {
        private readonly IExcelService _excelService;
        private readonly IDatabaseService _databaseService;
        private readonly ComparisonService _comparisonService;
        private readonly string _filePath;

        public Form1(IExcelService excelService, IDatabaseService databaseService, ComparisonService comparisonService, string filePath)
        {
            InitializeComponent();
            _excelService = excelService;
            _databaseService = databaseService;
            _comparisonService = comparisonService;
            _filePath = filePath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadExcelPreview();
            LoadDbPreview();
        }

        private void LoadExcelPreview()
        {
            try
            {
                DataTable firstTenRowsFromExcel = _excelService.LoadData(_filePath, maxRows: 10, maxCols: 50);
                dgvExcel.DataSource = firstTenRowsFromExcel;

                excelIdColumnList.Items.Clear();
                excelValueColumnList.Items.Clear();

                foreach (DataColumn column in firstTenRowsFromExcel.Columns)
                {
                    excelIdColumnList.Items.Add(column.ColumnName);
                    excelValueColumnList.Items.Add(column.ColumnName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel Error: " + ex.Message);
            }
        }

        private void LoadDbPreview()
        {
            try
            {
                DataTable firstTenRowsFromDb = _databaseService.GetTransactions(limit: 10);
                dgvDatabase.DataSource = firstTenRowsFromDb;

                dbIdColumnList.Items.Clear();
                foreach (DataColumn column in firstTenRowsFromDb.Columns)
                {
                    dbIdColumnList.Items.Add(column.ColumnName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error: " + ex.Message);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var selectedExcelKeys = excelIdColumnList.CheckedItems.Cast<string>().ToList();
            var selectedDbKeys = dbIdColumnList.CheckedItems.Cast<string>().ToList();
            var selectedValueColumns = excelValueColumnList.CheckedItems.Cast<string>().ToList();

            if (selectedExcelKeys.Count != selectedDbKeys.Count || selectedExcelKeys.Count == 0) //nieprawidłowe założenia  dbKeys powinien być 1
            {
                MessageBox.Show("Please select the same number of ID columns in both lists!");
                return;
            }

            try
            {
                DataTable fullExcelData = _excelService.LoadData(_filePath, maxRows: 1000000);
                DataTable fullDatabaseData = _databaseService.GetTransactions(limit: 1000000);

                var missingRecords = _comparisonService.FindMissingRecords(
                    fullExcelData,
                    fullDatabaseData,
                    selectedExcelKeys,
                    selectedDbKeys,
                    selectedValueColumns
                );

                string resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "missing_records.txt");
                File.WriteAllLines(resultFilePath, missingRecords);

                MessageBox.Show($"Found {missingRecords.Count} missing records.\nSaved to: {resultFilePath}", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Processing error: " + ex.Message);
            }
        }
    }
}