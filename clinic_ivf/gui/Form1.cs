using clinic_ivf.control;
using clinic_ivf.gui;
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

namespace clinic_ivf
{
    public partial class Form1 : Form
    {
        IvfControl ic;
        public Form1(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();

            txtBarcode.KeyUp += TxtBarcode_KeyUp;
            btnBarcodePrint.KeyUp += BtnBarcodePrint_KeyUp;
        }

        private void BtnBarcodePrint_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            genbarcode();
        }

        private void TxtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            ///throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                genbarcode();
            }
        }
        private void genbarcode()
        {
            C1.BarCode.CodeType codetype = new C1.BarCode.CodeType();
            foreach (C1.BarCode.CodeType value1 in Enum.GetValues(typeof(C1.BarCode.CodeType)))
            {
                if (value1.ToString().Equals(cboBarcodeType.Text))
                {
                    c1BarCode1.CodeType = value1;
                    break;
                }
            }
            //codetype = Enum.get(C1.BarCode.CodeType, codetype);
            //c1BarCode1.CodeType = cboBarcodeType.Text;
            try
            {
                if (!Directory.Exists("report"))
                {
                    Directory.CreateDirectory("report");
                }
                if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\report\\barcode.jpg"))
                {
                    File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\report\\barcode.jpg");
                }
                c1BarCode1.Text = txtBarcode.Text;
                //Image img = c1BarCode1.Image;
                //img.Save(System.IO.Directory.GetCurrentDirectory() + "\\report\\barcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //barc.Size = new Size(100, 60);
                //barc.BarHeight = 60;
                c1BarCode1.Image.Save(System.IO.Directory.GetCurrentDirectory() + "\\report\\barcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //barc.Text = lis1.barcode;
                //Bitmap bitm = new Bitmap(100, 120);
                //bitm = barc.Image;
                //Image img = c1BarCode1.Image;
                //img.Size = new Size(100, 40);
                //img.Save(System.IO.Directory.GetCurrentDirectory() + "\\report\\" + lis1.barcode + ".jpg", ImageFormat.Jpeg);

                DataTable dt = new DataTable();
                dt.Columns.Add("hn", typeof(String));
                dt.Columns.Add("name", typeof(String));
                dt.Columns.Add("age", typeof(String));
                dt.Columns.Add("vn", typeof(String));
                dt.Columns.Add("path_barcode", typeof(String));
                DataRow row11 = dt.NewRow();
                row11["hn"] = "Test Barcode ";
                row11["name"] = cboBarcodeType.Text;
                row11["age"] = "";
                row11["vn"] = "";
                row11["path_barcode"] = System.IO.Directory.GetCurrentDirectory() + "\\report\\barcode.jpg";
                dt.Rows.Add(row11);

                FrmReport frm = new FrmReport(ic);
                frm.setStickerPatientThemalLIS(dt);
                frm.ShowDialog(this);
            }
            catch(Exception ex)
            {

            }
            
            
        }
        private void initConfig()
        {
            ic.setCboBarcodeType(cboBarcodeType);
        }
        private void C1TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
