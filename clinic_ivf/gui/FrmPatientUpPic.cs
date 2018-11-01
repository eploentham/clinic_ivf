using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmPatientUpPic : Form
    {
        String[] filename;
        ListView lv;
        //ImageList il;
        public FrmPatientUpPic(String[] filename)
        {
            InitializeComponent();
            this.filename = filename;
            initConfig();
        }
        private void initConfig()
        {
            //lv = new ListView();
            //lv.Dock = DockStyle.Fill;
            //panel1.Controls.Add(lv);

            //il = new ImageList();
            //foreach(String fileName in filename)
            //{
            //    il.Images.Add(Image.FromFile(fileName));
            //}
            //lv.View = View.LargeIcon;
            //il.ImageSize = new Size(180, 240);
            //lv.LargeImageList = il;
            int newWidth = 180;
            int x = 20, y = 20, maxH = -1;
            foreach (String fileName in filename)
            {
                Image loadedImage = Image.FromFile(fileName);
                int originalWidth = loadedImage.Width;
                Image resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                PictureBox pic = new PictureBox();
                pic.Image = resizedImage;
                pic.SizeMode = PictureBoxSizeMode.CenterImage;
                pic.Height = pic.Image.Height;
                pic.Width = pic.Image.Width;
                pic.Location = new Point(x, y);
                x += pic.Width + 10;
                maxH = Math.Max(pic.Height, maxH);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxH + 10;
                }
                panel1.Controls.Add(pic);
            }
        }

        

        private void FrmPatientUpPic_Load(object sender, EventArgs e)
        {

        }

        
    }
}
