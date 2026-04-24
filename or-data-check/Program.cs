using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Microsoft.Data.SqlClient;

namespace OrDataCheck
{
    class Program
    {
        static string connectionString = "Server=localhost;Database=testowa_baza;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Name");

            string filePath = "transactionDump_2026-02-10_2026_03_03_FULL.xlsx";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found: " + filePath);
                return;
            }

            Console.WriteLine("Excel File Content (First 10 rows, 5 columns):");
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets[0];
                    int rows = ws.Dimension.Rows;
                    int cols = ws.Dimension.Columns;

                    for (int r = 1; r <= Math.Min(10, rows); r++)
                    {
                        Console.Write("Row " + r + ": ");
                        for (int c = 1; c <= Math.Min(5, cols); c++)
                        {
                            string val = ws.Cells[r, c].Text;
                            string displayVal = val.Length > 15 ? val.Substring(0, 15) : val.PadRight(15);
                            Console.Write("[" + displayVal + "] ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excel Error: " + ex.Message);
            }

            Console.WriteLine("\n Database Content (First 10 records):");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 10 EXPENDITURE_ITEM_ID, EXPENDITURE_TYPE_NAME, PROJECT_NUM, PROJFUNC_BURDENED_COST FROM [dbo].[ExpenditureTransactions]";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("ID: " + reader[0] + " | Type: " + reader[1] + " | Project: " + reader[2] + " | Cost: " + reader[3]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }

            Console.WriteLine("\n Press any key to exit...");
            Console.ReadKey();
        }
    }
}