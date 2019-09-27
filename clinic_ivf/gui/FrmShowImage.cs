using C1.Win.C1Input;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmShowImage:Form
    {
        IvfControl ic;

        String filename = "", pttOldId="", pttImgId="";
        C1PictureBox pic;
        Panel panel1, pnR, pnL;
        Image loadedImage;
        TextBox txtDesc,txtId;
        Button btnSend, btnPrn;
        Label lb2;
        int newWidth = 320;
        public Font fV1B, fV1;
        Font fEdit, fEditB;

        int gapLine = 5;
        int grd0 = 0, grd1 = 10, grd2 = 240, grd3 = 320, grd4 = 570, grd5 = 700, grd51 = 700, grd6 = 820, grd7 = 900, grd8 = 1070, grd9 = 1200;
        int line1 = 35, line2 = 27, line3 = 85, line4 = 125, line41 = 120, line42 = 111, line5 = 270, ControlHeight = 30, lineGap = 5;
        public int tcW = 0, tcH = 0, tcWMinus = 25, tcHMinus = 70, formFirstLineX = 5, formFirstLineY = 5;        //standard

        PatientOld pttOld;
        PatientImage pttImg;
        Image resizedImage;
        MemoryStream stream;
        public enum statusModule { Patient, LabOPU}
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmShowImage(IvfControl ic, String pttImgId, String pttOldId, String filename, statusModule statusmodule)
        {
            this.filename = filename;
            this.ic = ic;
            this.pttOldId = pttOldId;
            this.pttImgId = pttImgId;
            initConfig();
        }
        private void initConfig()
        {
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            pttOld = new PatientOld();
            pttImg = new PatientImage();
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(pttOldId);
            pttImg = ic.ivfDB.pttImgDB.selectByPk1(pttImgId);

            this.Size = new System.Drawing.Size(1224, 768);
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);

            //this.Location = pp;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            //this.StartPosition = FormStartPosition.CenterParent;
            panel1 = new Panel();
            panel1.Dock = DockStyle.Fill;
            pnR = new Panel();
            pnR.Dock = DockStyle.Right;
            pnR.Width = newWidth;
            pnL = new Panel();
            pnL.Dock = DockStyle.Fill;

            lb2 = new Label();
            lb2.Font = fEdit;
            lb2.Text = "Description";
            lb2.AutoSize = true;
            pnR.Controls.Add(lb2);
            lb2.Location = new System.Drawing.Point(grd1,  gapLine);

            txtId = new TextBox();

            txtDesc = new TextBox();
            txtDesc.Font = fEdit;
            txtDesc.Text = "";
            txtDesc.Size = new System.Drawing.Size(200 , ControlHeight);
            pnR.Controls.Add(txtDesc);
            txtDesc.Location = new System.Drawing.Point(grd1, lb2.Height + gapLine + gapLine);

            btnSend = new Button();
            btnSend.Font = fEdit;
            btnSend.Text = "Save";
            btnSend.Size = new System.Drawing.Size(120, ControlHeight);
            pnR.Controls.Add(btnSend);
            btnSend.Location = new System.Drawing.Point(grd1, line3);
            btnSend.Click += BtnSend_Click;

            btnPrn = new Button();
            btnPrn.Font = fEdit;
            btnPrn.Text = "Print";
            btnPrn.Size = new System.Drawing.Size(120, ControlHeight);
            pnR.Controls.Add(btnPrn);
            btnPrn.Location = new System.Drawing.Point(grd1, line4);
            btnPrn.Click += BtnPrn_Click;

            pic = new C1PictureBox();
            pic.Dock = DockStyle.Fill;
            panel1.Controls.Add(pnR);
            panel1.Controls.Add(pnL);
            pnL.Controls.Add(pic);
            
            pnR.Controls.Add(btnSend);
            Controls.Add(panel1);
            String ext = Path.GetExtension(filename);
            //String[] sur = filename.Split('.');
            //String ex = "";
            //if (sur.Length == 2)
            //{
            //    ex = sur[1];
            //}
            stream = new MemoryStream();
            if (ext.IndexOf("pdf")<0)
            {
                try
                {

                    //loadedImage = Image.FromFile(filename);
                    stream = ic.ftpC.download(filename);
                    Bitmap bitmap = new Bitmap(stream);
                    loadedImage = bitmap;
                    int originalWidth = loadedImage.Width;
                    int newWidth = 1000;
                    if (originalWidth > newWidth)
                    {
                        resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                    }
                    else
                    {
                        resizedImage = loadedImage;
                    }
                }
                catch(Exception ex1)
                {

                }
            }
            else
            {
                resizedImage = Resources.pdf_symbol_300;
            }

            //loadedImage = Image.FromFile(filename);

            //int originalWidth = loadedImage.Width;
            //resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
            //pic.Image = resizedImage;
            if (stream.Length > 0)
            {
                pic.Image = Image.FromStream(stream);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void BtnPrn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerA4);
            System.Threading.Thread.Sleep(500);

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            //here to select the printer attached to user PC
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = pd;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();//this will trigger the Print Event handeler PrintPage
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                //if (File.Exists(this.ImagePath))
                //{
                //Load the image from the file
                System.Drawing.Image img = Image.FromStream(stream);
                //Adjust the size of the image to the page to print the full image without loosing any part of it
                Rectangle m = e.MarginBounds;
                if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
                {
                    m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                }
                e.Graphics.DrawImage(img, m);
                //}
            }
            catch (Exception)
            {

            }
        }

        private void setPatientImage()
        {
            pttImg.patient_image_id = txtId.Text;
            pttImg.t_patient_id = pttOld.PID;
            pttImg.t_visit_id = "";
            pttImg.desc1 = txtDesc.Text;
            pttImg.desc2 = "";
            pttImg.desc3 = "";
            pttImg.desc4 = "";
            pttImg.active = "1";
            pttImg.remark = "";
            pttImg.date_create = "";
            pttImg.date_modi = "";
            pttImg.date_cancel = "";
            pttImg.user_create = "";
            pttImg.user_modi = "";
            pttImg.user_cancel = "";
            pttImg.image_path = "";
            pttImg.status_image = "1";
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String folder = "";
            int chk = 0;
            folder = DateTime.Now.Year.ToString();
            setPatientImage();
            String re = ic.ivfDB.pttImgDB.insertpatientImage(pttImg, "");
            if(int.TryParse(re, out chk))
            {
                ic.saveFilePatienttoServer(pttImg.t_patient_id, re, filename);

                btnSend.Text = "Save OK";
            }
            //image1 = picPtt.Image;
            //image1.Save(@"temppic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmShowImage
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmShowImage";
            this.Load += new System.EventHandler(this.FrmShowImage_Load);
            this.ResumeLayout(false);

        }

        private void FrmShowImage_Load(object sender, EventArgs e)
        {

        }
    }
}
