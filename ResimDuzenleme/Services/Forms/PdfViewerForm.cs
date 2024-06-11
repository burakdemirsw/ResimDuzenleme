using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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