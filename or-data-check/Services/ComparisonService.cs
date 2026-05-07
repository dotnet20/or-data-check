using System.Data;

namespace or_data_check.Services
{
    public class ComparisonService //interface
    {
        public List<string> FindMissingRecords(DataTable excelData, DataTable dbData,
            List<string> excelKeys, List<string> dbKeys, List<string> valueCols)
        {
            var dbKeySet = new HashSet<string>(
                dbData.AsEnumerable().Select(r =>
                    string.Join("|", dbKeys.Select(c => r[c]?.ToString()?.Trim() ?? ""))) //tu nie trzeba wielu kolumn, jedna wystarczy z bazy
            );

            List<string> missing = new List<string>();

            foreach (DataRow row in excelData.Rows)
            {
                bool hasRealValue = valueCols.Any(c => {   //tu się aż prosi, żeby utworzyć metode bool HasRealValue()
                    string v = row[c]?.ToString()?.Trim();
                    return !string.IsNullOrEmpty(v) && v != "0" && v != "0.00";
                });

                if (!hasRealValue) continue;

                string excelKey = string.Join("|", excelKeys.Select(c => row[c]?.ToString()?.Trim() ?? "")); //tu trzeba joinować bez separatora i też można wyodrębnić metode string BuildKeyForExcelRow()

                if (!dbKeySet.Contains(excelKey))
                {
                    missing.Add(excelKey);
                }
            }

            return missing;
        }
    }
}
