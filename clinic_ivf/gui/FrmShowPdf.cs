using C1.Win.C1Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmShowPdf : Form
    {
        MemoryStream stream;
        public FrmShowPdf(MemoryStream stream)
        {
            InitializeComponent();
            this.stream = stream;

        }

        private void FrmShowPdf_Load(object sender, EventArgs e)
        {
            if (stream == null) return;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            pds.LoadFromStream(stream);
            c1FlexViewer1.DocumentSource = pds;
        }
    }
}
