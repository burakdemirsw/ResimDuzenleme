using System;
using System.IO;
using System.Windows.Forms;




namespace ResimDuzenleme
{
    public partial class FaturaGorsel : DevExpress.XtraEditors.XtraForm
    {
        private readonly ResimDuzenlemeClient _ResimDuzenlemeClient = new ResimDuzenlemeClient();
        public WebBrowser webBrowserControl;
        public FaturaGorsel( )
        {
            InitializeComponent();

            webBrowserControl = webBrowser1;
            webBrowserControl.DocumentCompleted += WebBrowserControl_DocumentCompleted;



        }

        private void WebBrowserControl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Belge yüklendikten sonra yazdırma işlemi başlat
            //PrintDocument();
            ShowPrintDialog();
        }
        private void ShowPrintDialog( )
        {
            // Yazdırma diyalogunu göster
            webBrowserControl.ShowPrintDialog();
        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = sender as WebBrowser;
            if (webBrowser != null)
            {
                // Formun boyutlarını içerik boyutuna göre ayarla
                this.Width = webBrowser.Document.Body.ScrollRectangle.Width;
                this.Height = webBrowser.Document.Body.ScrollRectangle.Height;

                // FaturaGorsel formunu göster
                this.Show();
                PrintDocument();
            }
        }
        private void PrintDocument( )
        {
            // WebBrowser kontrolünde yazdırma işlemi
            webBrowserControl.Print();

            // Alternatif olarak, yazdırma diyalogu gösterilebilir
            // webBrowserControl.ShowPrintDialog();
        }
        public void LoadHtmlFile(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".xml")
            {
                webBrowserControl.Url = new Uri(filePath);
            }
            else
            {
                //   MessageBox.Show("Bu dosya bir HTML dosyası değil: " + filePath);
            }
        }
        private void FaturaGorsel_Load(object sender, EventArgs e)
        {

        }
    }
}