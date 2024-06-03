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

using System.Linq;


using System.Text.RegularExpressions;




namespace ResimDuzenleme
{
    public partial class PhotoDuzenleme : Form
    {
        public PhotoDuzenleme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ResimDuzenleme_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxImageFolder.Text))
            {
                MessageBox.Show("Lütfen önce bir klasör seçin.");
                return;
            }

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string imageFolder = textBoxImageFolder.Text;
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.jpg");

            var orderedFiles = imageFiles.OrderBy(file =>
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (string.IsNullOrEmpty(fileName)) return int.MaxValue; //Null veya boş isimli dosyaları listenin sonuna atar.
                return fileName.Contains(" ") || fileName.Contains("-") || fileName.Contains("(") ? int.MaxValue : 0;
            }).ThenBy(file => file).ToArray(); //Eğer dosya ismi " " veya "-" içermiyorsa, o dosyaları önce döndürür, sonrasında kalan dosyaları isim sıralamasına göre döndürür.

            progressBar1.Maximum = orderedFiles.Length;
            progressBar1.Value = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string imagePath in orderedFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imagePath);

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@barkod", fileName + ".jpg");

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string newItemCode = reader["Itemcode"].ToString();
                            string newFileName = newItemCode + ".jpg";
                            string newImagePath = Path.Combine(imageFolder, newFileName);

                            int counter = 1;
                            while (File.Exists(newImagePath))
                            {
                                newFileName = $"{newItemCode}_{counter}.jpg";
                                newImagePath = Path.Combine(imageFolder, newFileName);
                                counter++;
                            }

                            File.Move(imagePath, newImagePath);
                        }

                        progressBar1.Value += 1;
                        //if (reader.Read())
                        //{
                        //    string newFileName = reader["Itemcode"].ToString();
                        //    string newImagePath = Path.Combine(imageFolder, newFileName);

                        //    File.Move(imagePath, newImagePath);
                        //}
                        reader.Close();
                    }
                }
            }

            MessageBox.Show("İşlem tamamlandı!");
        }

        private void buttonProcessImages_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestinationFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }


            string destinationFolder = textBoxDestinationFolder.Text;

            if (string.IsNullOrEmpty(destinationFolder))
            {
                MessageBox.Show("Lütfen hedef klasörü seçin.");
                return;
            }
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string imageFolder = textBoxImageFolder.Text;
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.jpg");
            progressBar1.Maximum = imageFiles.Length;
            progressBar1.Value = 0;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string imagePath in imageFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imagePath);

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@barkod", fileName + ".jpg");

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            string urunKodu = reader["UrunKodu"].ToString();
                            string dosya = reader["Dosya"].ToString();
                            string colorCode = reader["ColorCode"].ToString();
                            string newFileName = urunKodu + "_" + colorCode + ".jpg";
                            string newFileName2 = urunKodu + "_" + colorCode + "_1.jpg";
                            string newFileNamePattern = urunKodu + "_" + colorCode + "_{0}.jpg";

                            string newPath = Path.Combine(destinationFolder, urunKodu, dosya);
                            Directory.CreateDirectory(newPath);

                            string newImagePath = Path.Combine(newPath, newFileName);


                            if (!File.Exists(newImagePath))
                            {
                                if (File.Exists(newImagePath))
                                {
                                    File.Delete(newImagePath); // Hedef klasördeki mevcut dosyayı sil
                                }

                                File.Copy(imagePath, newImagePath); // Orijinal klasördeki resmi hedef klasöre kopyala

                            }
                            else
                            {


                                int index = 1;
                                newPath = Path.Combine(newPath, colorCode);
                                Directory.CreateDirectory(newPath);

                                while (File.Exists(newImagePath))
                                {

                                    newImagePath = Path.Combine(newPath, string.Format(newFileNamePattern, index));

                                    index++;
                                }

                                if (!File.Exists(newImagePath))
                                {
                                    File.Copy(imagePath, newImagePath);
                                }
                                else
                                {

                                    File.Copy(imagePath, newImagePath, true);
                                }

                                // Orijinal klasördeki resmi hedef klasöre kopyala
                            }
                        }





                        progressBar1.Value += 1;
                        //if (reader.Read())
                        //{
                        //    string newFileName = reader["Itemcode"].ToString();
                        //    string newImagePath = Path.Combine(imageFolder, newFileName);

                        //    File.Move(imagePath, newImagePath);
                        //}
                        reader.Close();
                    }
                }
            }

            MessageBox.Show("İşlem tamamlandı!");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string outputFolder = Path.Combine(folderPath, "Output");

                // Create the Output folder if it doesn't exist
                Directory.CreateDirectory(outputFolder);

                string[] jpgFiles = Directory.GetFiles(folderPath, "*.jpg");

                foreach (string sourcePath in jpgFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sourcePath);
                    string targetPath = Path.Combine(outputFolder, fileName + ".webp");

                    using (MagickImage image = new MagickImage(sourcePath))
                    {
                        image.Format = MagickFormat.WebP;
                        image.Quality = 75; // Set the quality to 75
                        image.Write(targetPath);
                    }
                }

                MessageBox.Show("Images converted and saved in Output folder successfully!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestinationFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }

            string destinationFolder = textBoxDestinationFolder.Text;

            if (string.IsNullOrEmpty(destinationFolder))
            {
                MessageBox.Show("Lütfen hedef klasörü seçin.");
                return;
            }

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string imageFolder = textBoxImageFolder.Text;
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.jpg");
            progressBar1.Maximum = imageFiles.Length;
            progressBar1.Value = 0;

            List<string> sortedImageFiles = imageFiles.OrderBy(imagePath => GetNumericOrderFromFileName(imagePath)).ToList();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string imagePath in sortedImageFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imagePath);

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@barkod", fileName + ".jpg");

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string urunKodu = reader["UrunKodu"].ToString();
                            string dosya = reader["Dosya"].ToString();
                            string colorCode = reader["ColorCode"].ToString();
                            string newFileName = urunKodu + "_" + colorCode + ".jpg";
                            string newFileNamePattern = urunKodu + "_" + colorCode + "_{0}.jpg";

                            string newPath = Path.Combine(destinationFolder, dosya);
                            Directory.CreateDirectory(newPath);

                            string newImagePath = Path.Combine(newPath, newFileName);

                            int index = 1;

                            while (File.Exists(newImagePath))
                            {
                                newImagePath = Path.Combine(newPath, string.Format(newFileNamePattern, index));
                                index++;
                            }

                            File.Copy(imagePath, newImagePath);
                        }

                        progressBar1.Value += 1;
                        reader.Close();
                    }
                }
            }

            MessageBox.Show("İşlem tamamlandı!");
        }

        private int GetNumericOrderFromFileName(string fileName)
        {
            Match match = Regex.Match(Path.GetFileNameWithoutExtension(fileName), @"(\d+)$");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int order))
            {
                return order;
            }
            return int.MaxValue; // Bir sıra numarası bulunamazsa en sona eklesin
        }


        public class Root
        {
            public List<Item2> item33 { get; set; }
        }

        private void ProcessSelectedFolder(string parentFolder)
        {
            string[] subfolders = Directory.GetDirectories(parentFolder);

            foreach (string subfolder in subfolders)
            {
                ProcessColorPhotosFolders(subfolder);
            }

            foreach (string subfolder in subfolders)
            {
                ProcessMiscPhotosFolders(subfolder);
            }

        }

        private void ProcessColorPhotosFolders(string folder)
        {
            try
            {
                string colorPhotosPath = Path.Combine(folder, "ColorPhotos");

                if (Directory.Exists(colorPhotosPath))
                {
                    string[] colorPhotosFolders = Directory.GetDirectories(colorPhotosPath);

                    foreach (string colorPhotosFolder in colorPhotosFolders)
                    {
                        ProcessImagesInColorPhotosFolder(colorPhotosFolder);
                    }
                }
            }
            catch (Exception)
            {

                
            }
          
        }
        private void ProcessMiscPhotosFolders(string folder)
        {
            try
            {
                string miscPhotosPath = Path.Combine(folder, "MiscPhotos");

                if (Directory.Exists(miscPhotosPath))
                {
                    ProcessImagesInMiscPhotosFolder(miscPhotosPath);
                }
            }
            catch (Exception)
            {
                // Hata işlenmiyor
            }
        }

        //private void ProcessImagesInMiscPhotosFolder(string miscPhotosFolder)
        //{
        //    try
        //    {
        //        string[] imageFiles = Directory.GetFiles(miscPhotosFolder, "*.*"); // Tüm dosya türlerini al

        //        if (imageFiles.Length > 0)
        //        {
        //            string mainFolderName = Path.GetFileName(Path.GetDirectoryName(miscPhotosFolder));

        //            int imageCount = 1;

        //            foreach (string imageFile in imageFiles)
        //            {
        //                string extension = Path.GetExtension(imageFile);
        //                string newFileName = $"{mainFolderName}_{imageCount}.jpg"; // Dosyayı .jpg olarak kaydet
        //                string newFilePath = Path.Combine(miscPhotosFolder, newFileName);
        //                File.Move(imageFile, newFilePath);
        //                imageCount++;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Hata işlenmiyor
        //    }
        //}


        private void ProcessImagesInMiscPhotosFolder(string miscPhotosFolder)
        {
            try
            {
                string[] imageFiles = Directory.GetFiles(miscPhotosFolder, "*.*"); // Tüm dosya türlerini al

                if (imageFiles.Length > 0)
                {
                    string mainFolderName = Path.GetFileName(Path.GetDirectoryName(miscPhotosFolder));

                    int imageCount = 1;

                    foreach (string imageFile in imageFiles)
                    {
                        string extension = Path.GetExtension(imageFile);
                        string newFileName = $"{mainFolderName}_{imageCount}.jpg"; // Dosyayı .jpg olarak kaydet
                        string newFilePath = Path.Combine(miscPhotosFolder, newFileName);

                        while (File.Exists(newFilePath))
                        {
                            imageCount++;
                            newFileName = $"{mainFolderName}_{imageCount}.jpg"; // _1 ile başlayan yeni bir isim kullan
                            newFilePath = Path.Combine(miscPhotosFolder, newFileName);
                        }

                        File.Move(imageFile, newFilePath);
                        imageCount++; // Bir sonraki dosya için artır
                    }
                }
            }
            catch (Exception)
            {
                // Hata işlenmiyor
            }
        }

        private void ProcessImagesInColorPhotosFolder(string colorPhotosFolder)
        {
            try
            {
                string[] imageFiles = Directory.GetFiles(colorPhotosFolder, "*.*"); // Tüm dosya türlerini al

                if (imageFiles.Length > 0)
                {
                    string mainFolderName = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(colorPhotosFolder)));
                    string colorCode = Path.GetFileName(colorPhotosFolder);

                    int imageCount = 1;

                    foreach (string imageFile in imageFiles)
                    {
                        string extension = Path.GetExtension(imageFile);
                        string newFileName = $"{mainFolderName}_{colorCode}_{imageCount}.jpg"; // Dosyayı .jpg olarak kaydet
                        string newFilePath = Path.Combine(colorPhotosFolder, newFileName);
                        File.Move(imageFile, newFilePath);
                        imageCount++;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            ProcessSelectedFolder(folderBrowserDialog1.SelectedPath);
            MessageBox.Show("Düzenleme işlemi tamamlandı.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
        
            if (string.IsNullOrEmpty(textBoxImageFolder.Text))
            {
                MessageBox.Show("Lütfen önce bir klasör seçin.");
                return;
            }

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = "usp_GETZalandoID";

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string imageFolder = textBoxImageFolder.Text;
            string[] imageFiles = Directory.GetFiles(imageFolder, "*.jpg");

            var orderedFiles = imageFiles.OrderBy(file =>
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (string.IsNullOrEmpty(fileName)) return int.MaxValue; //Null veya boş isimli dosyaları listenin sonuna atar.
                return fileName.Contains(" ") || fileName.Contains("-") || fileName.Contains("(") ? int.MaxValue : 0;
            }).ThenBy(file => file).ToArray(); //Eğer dosya ismi " " veya "-" içermiyorsa, o dosyaları önce döndürür, sonrasında kalan dosyaları isim sıralamasına göre döndürür.

            progressBar1.Maximum = orderedFiles.Length;
            progressBar1.Value = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string imagePath in orderedFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imagePath);

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@barkod", fileName + ".jpg");

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string newItemCode = reader["Itemcode"].ToString();
                            int counter = 1;
                            string newFileName = $"{newItemCode}-0{counter}.jpg";
                            string newImagePath = Path.Combine(imageFolder, newFileName);

                            counter = 2;
                            while (File.Exists(newImagePath))
                            {
                                if (counter >= 10)
                                {
                                    newFileName = $"{newItemCode}-{counter}.jpg";
                                }
                                else
                                {
                                    newFileName = $"{newItemCode}-0{counter}.jpg";
                                }
                                newImagePath = Path.Combine(imageFolder, newFileName);
                                counter++;
                            }

                            File.Move(imagePath, newImagePath);
                        }

                        progressBar1.Value += 1;
                        //if (reader.Read())
                        //{
                        //    string newFileName = reader["Itemcode"].ToString();
                        //    string newImagePath = Path.Combine(imageFolder, newFileName);

                        //    File.Move(imagePath, newImagePath);
                        //}
                        reader.Close();
                    }
                }
            }

            MessageBox.Show("İşlem tamamlandı!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            ProcessSelectedFolder2(folderBrowserDialog1.SelectedPath);
            MessageBox.Show("Düzenleme işlemi tamamlandı.");
        }

        private void ProcessSelectedFolder2(string parentFolder)
        {
            // Alt klasörleri al ve her birini işle
            string[] subfolders = Directory.GetDirectories(parentFolder);

            foreach (string subfolder in subfolders)
            {
                RenameImagesInFolder(subfolder);
            }
        }

        private void RenameImagesInFolder(string folder)
        {
            try
            {
                // Klasördeki tüm resim dosyalarını al
                string[] imageFiles = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly)
                                               .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                           s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                           s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                           s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                                           s.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                               .ToArray();

                // Klasör ismini büyük harflerle al
                string folderName = Path.GetFileName(folder).ToUpper();
                int counter = 1;

                foreach (string imageFile in imageFiles)
                {
                    string extension = Path.GetExtension(imageFile);
                    string newFileName = $"{folderName}_{counter}{extension}";
                    string newFilePath = Path.Combine(folder, newFileName);

                    // Dosya zaten varsa counter'ı artır ve yeniden adlandır
                    while (File.Exists(newFilePath))
                    {
                        counter++;
                        newFileName = $"{folderName}_{counter}{extension}";
                        newFilePath = Path.Combine(folder, newFileName);
                    }

                    // Dosyayı yeniden adlandır
                    File.Move(imageFile, newFilePath);
                    counter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

    }
}
