using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmShowImage:Form
    {
        String filename = "";
        public FrmShowImage(String filename)
        {
            this.filename = filename;
            initConfig();
        }
        private void initConfig()
        {
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            
            this.Size = new System.Drawing.Size(800, 600);
            
            //this.Location = pp;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            //this.StartPosition = FormStartPosition.CenterParent;
            Panel panel1 = new Panel();
            panel1.Dock = DockStyle.Fill;

            PictureBox pic = new PictureBox();
            pic.Dock = DockStyle.Fill;
            panel1.Controls.Add(pic);
            Controls.Add(panel1);

            Image loadedImage = Image.FromFile(filename);
            int newWidth = 400;
            int originalWidth = loadedImage.Width;
            Image resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
            pic.Image = resizedImage;

        }
    }
}
