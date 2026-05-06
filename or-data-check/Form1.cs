using System.Data;

namespace or_data_check
{
    public partial class Form1 : Form
    {
        private readonly IExcelService _excelService;
        private readonly IDatabaseService _databaseService;
        private readonly ComparisonService _comparisonService;
        private readonly string _filePath;

        public Form1(IExcelService excelService, IDatabaseService databaseService, string filePath)
        {
            InitializeComponent();
            _excelService = excelService;
            _databaseService = databaseService;
            _comparisonService = new ComparisonService(); // ten serwis też powinien być wstrzyknięty
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
                DataTable dt = _excelService.LoadData(_filePath, maxRows: 10, maxCols: 50); //nie używa się nazw zmiennych, które nic nie mówią jak dt, więcej powie firstTenRowsFromExcel
                dgvExcel.DataSource = dt;

                clbKeyColumns.Items.Clear(); //tu tak samo nazwa jest taka, że jak ktos poza tobą to przegląda to nie wie o co chodzi. clbKeyColumns - to powinno być cos znaczącego np idColumnList
                clbValueColumns.Items.Clear();
                foreach (DataColumn col in dt.Columns)
                {
                    clbKeyColumns.Items.Add(col.ColumnName);
                    clbValueColumns.Items.Add(col.ColumnName);
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
                DataTable dt = _databaseService.GetTransactions(limit: 10);
                dgvDatabase.DataSource = dt;

                clbDbColumns.Items.Clear();
                foreach (DataColumn col in dt.Columns) clbDbColumns.Items.Add(col.ColumnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error: " + ex.Message);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var excelKeys = clbKeyColumns.CheckedItems.Cast<string>().ToList();
            var dbKeys = clbDbColumns.CheckedItems.Cast<string>().ToList();
            var valCols = clbValueColumns.CheckedItems.Cast<string>().ToList();

            if (excelKeys.Count != dbKeys.Count || excelKeys.Count == 0)
            {
                MessageBox.Show("Please select the same number of ID columns in both lists!");
                return;
            }

            try
            {
                DataTable excelData = _excelService.LoadData(_filePath, maxRows: 1000000);
                DataTable dbData = _databaseService.GetTransactions(limit: 1000000);

                var missing = _comparisonService.FindMissingRecords(excelData, dbData, excelKeys, dbKeys, valCols);

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "missing_records.txt");
                File.WriteAllLines(path, missing);

                MessageBox.Show($"Found {missing.Count} missing records.\n Saved to: {path}", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Processing error: " + ex.Message);
            }
        }
    }
}