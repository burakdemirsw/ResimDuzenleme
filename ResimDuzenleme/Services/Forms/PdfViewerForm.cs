namespace ResimDuzenleme.Services.Forms
{
    public partial class PdfViewerForm : DevExpress.XtraEditors.XtraForm
    {
        public PdfViewerForm(string pdfFilePath)
        {
            // Load the PDF into the PdfViewer
            InitializeComponent();
            pdfViewer1.LoadDocument(pdfFilePath);

            // Optionally, show a print button and print the document

        }
    }
}