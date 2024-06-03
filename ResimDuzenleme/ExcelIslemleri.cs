using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ImageMagick;
using Excel = Microsoft.Office.Interop.Excel;
using CsvHelper;
using System.Globalization;
using ClosedXML.Excel;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;


namespace ResimDuzenleme
{
    public partial class ExcelIslemleri : Form
    {
        public ExcelIslemleri()
        {
            InitializeComponent();
        }

        private void ExportToExcel(DataTable dt)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet excelWorkSheet = excelWorkBook.Sheets[1];
            excelWorkSheet.Columns[1].ColumnWidth = 30;

            Dictionary<string, int> addedProductCodes = new Dictionary<string, int>();
            int rowCount = 2; // Start from the second row

            // Set column names
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                excelWorkSheet.Cells[1, i + 2] = dt.Columns[i].ColumnName;
            }

            foreach (DataRow row in dt.Rows)
            {
                string productCode = row["UrunKodu"].ToString();
                string colorCode = row["ColorCode"].ToString();
                string uniqueCode = productCode + "-" + colorCode;

                if (!addedProductCodes.ContainsKey(uniqueCode))
                {
                    string picturePath = row["Photo"].ToString();
                    if (!File.Exists(picturePath))
                    {
                        picturePath = "C:\\Resim\\resimyok.jpg"; // Default image path
                    }

                    // Merge cells for the picture in column A only
                    Excel.Range picCell = excelWorkSheet.Range[excelWorkSheet.Cells[rowCount, 1], excelWorkSheet.Cells[rowCount + 11, 1]];
                    picCell.Merge();


                    // Calculate the size and position of the picture
                    float left = (float)((double)picCell.Left);
                    float top = (float)((double)picCell.Top);
                    float cellWidth = (float)Convert.ToDouble(picCell.Width);
                    float cellHeight = (float)Convert.ToDouble(picCell.Height);
                    float pictureWidth = cellWidth / 2; // Half of the cell width
                    float pictureHeight = 119; // Same as the cell height
                    float centerLeft = left + (cellWidth - pictureWidth) / 2;
                    float centerTop = top + (cellHeight - pictureHeight) / 2; // Center the picture vertically

                    // Add the picture
                    Excel.Shape picture = excelWorkSheet.Shapes.AddPicture(
               picturePath,
               Microsoft.Office.Core.MsoTriState.msoFalse,
               Microsoft.Office.Core.MsoTriState.msoCTrue,
               centerLeft, centerTop, pictureWidth, pictureHeight);


                    addedProductCodes[uniqueCode] = rowCount;
                    rowCount += 12; // 12 satırlık ürün için yer ayır

                    // Resim ve ürün bilgileri eklendikten sonra boş bir satır bırak
                    excelWorkSheet.Rows[rowCount].Insert(); // Boş bir satır ekle
                    rowCount += 1; // Boş satır için rowCount'u artır
                }
                Excel.Range headerRange = excelWorkSheet.Range[excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[1, 18]];
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                // Write other details in non-merged cells
                int startRow = addedProductCodes[uniqueCode];
                startRow += 2;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    // Yazı tiplerini ayarla (Arial) - Her sütun için sadece bir kere ayarla
                    if (j == 1) // Resim sütunu hariç diğer sütunlar için
                    {


                        //excelWorkSheet.Cells[startRow, j + 2].Font.Name = "Arial";
                        //// Her seferinde 3 satır aşağıdan başlat
                        excelWorkSheet.Cells[startRow, j + 2].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                        excelWorkSheet.Cells[startRow, j + 2].AddIndent = false;
                        excelWorkSheet.Cells[startRow, j + 2].IndentLevel = 0;
                        //excelWorkSheet.Cells[startRow, j + 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //excelWorkSheet.Cells[startRow, j + 2].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //excelWorkSheet.Cells[startRow, j + 2].WrapText = true;

                        // Sütun genişliklerini ayarla (İsteğe bağlı)
                        //excelWorkSheet.Columns[j + 1].AutoFit();
                        // Diğer sütun genişliklerini buraya ekleyin...

                        // Sütun hizalamalarını ayarla (İsteğe bağlı)
                        //excelWorkSheet.Columns[j + 1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        // Diğer sütun hizalamalarını buraya ekleyin...
                        //excelWorkSheet.Columns[3].ColumnWidth = 9;
                        //excelWorkSheet.Columns[4].ColumnWidth = 12;
                        //excelWorkSheet.Columns[5].ColumnWidth = 12;
                        //excelWorkSheet.Columns[6].ColumnWidth = 18;
                        //excelWorkSheet.Columns[7].ColumnWidth = 9;
                        //excelWorkSheet.Columns[8].ColumnWidth = 4;
                        //excelWorkSheet.Columns[9].ColumnWidth = 8;
                        //excelWorkSheet.Columns[10].ColumnWidth = 10;
                        //excelWorkSheet.Columns[11].ColumnWidth = 15;
                        //excelWorkSheet.Columns[12].ColumnWidth = 15;
                        //excelWorkSheet.Columns[13].ColumnWidth = 10;
                        //excelWorkSheet.Columns[14].ColumnWidth = 7;
                        //excelWorkSheet.Columns[15].ColumnWidth = 16;
                        //excelWorkSheet.Columns[16].ColumnWidth = 12;
                        //excelWorkSheet.Columns[17].ColumnWidth = 8;
                        //excelWorkSheet.Columns[18].ColumnWidth = 15;

                        //excelWorkSheet.Columns[3].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[4].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[5].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[6].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[7].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[8].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[9].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[10].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[11].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[12].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[13].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[14].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[15].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[16].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[17].EntireColumn.AutoFit();
                        //excelWorkSheet.Columns[18].EntireColumn.AutoFit();

                        //excelWorkSheet.Columns[3].Font.Name = "Arial";
                        //excelWorkSheet.Columns[4].Font.Name = "Arial";
                        //excelWorkSheet.Columns[5].Font.Name = "Arial";
                        //excelWorkSheet.Columns[6].Font.Name = "Arial";
                        //excelWorkSheet.Columns[7].Font.Name = "Arial";
                        //excelWorkSheet.Columns[8].Font.Name = "Arial";
                        //excelWorkSheet.Columns[9].Font.Name = "Arial";
                        //excelWorkSheet.Columns[10].Font.Name = "Arial";
                        //excelWorkSheet.Columns[11].Font.Name = "Arial";
                        //excelWorkSheet.Columns[12].Font.Name = "Arial";
                        //excelWorkSheet.Columns[13].Font.Name = "Arial";
                        //excelWorkSheet.Columns[14].Font.Name = "Arial";
                        //excelWorkSheet.Columns[15].Font.Name = "Arial";
                        //excelWorkSheet.Columns[16].Font.Name = "Arial";
                        //excelWorkSheet.Columns[17].Font.Name = "Arial";
                        //excelWorkSheet.Columns[18].Font.Name = "Arial";


                    }

                    // Yazıları yazdır
                    excelWorkSheet.Cells[startRow, j + 2] = row[j].ToString();
              
                    //excelWorkSheet.Columns[3].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[4].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[5].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[6].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[7].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[8].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[9].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[10].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[11].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[12].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[13].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[14].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[15].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[16].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[17].EntireColumn.AutoFit();
                    //excelWorkSheet.Columns[18].EntireColumn.AutoFit();
                }
                //excelWorkSheet.Columns[3].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[4].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[5].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[6].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[7].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[8].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[9].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[10].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[11].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[12].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[13].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[14].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[15].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[16].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[17].EntireColumn.AutoFit();
                //excelWorkSheet.Columns[18].EntireColumn.AutoFit();
                addedProductCodes[uniqueCode]++; // Increment the row counter within the merged region

            }
 


            // Save and close
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel | *.xls;*.xlsx;*.xlsm";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelWorkBook.SaveAs(saveFileDialog.FileName);
                excelWorkBook.Close();
                excelApp.Quit();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {


            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string spName = "MSG_GetUrunListesi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ExportToExcel(dt);
            }
        }

        private void ExcelIslemleri_Load(object sender, EventArgs e)
        {
            txtSpgetir.Text = Properties.Settings.Default.Spname;
        }
        private void ExportToCsv(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyaları | *.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("iso-8859-9"))) // ISO-8859-9 kodlamasını kullan
                {
                    var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";"
                    };

                    using (var csv = new CsvWriter(writer, config)) // CultureInfo.InvariantCulture ve yeni ayırıcı karakteri kullan
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            csv.WriteField(column.ColumnName);
                        }
                        csv.NextRecord();

                        foreach (DataRow row in dt.Rows)
                        {
                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                csv.WriteField(row[i]);
                            }
                            csv.NextRecord();
                        }
                    }
                }
            }
        }

        private void btnCsvaktar_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string spName = txtSpgetir.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@startdate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@enddate", dateTimePicker2.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ExportToCsv(dt);
                MessageBox.Show("Dosya Aktarıldı");
            }
        }

        private void ExcelIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Spname = txtSpgetir.Text;
            Properties.Settings.Default.Save();
        }
    }
}
