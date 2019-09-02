using clinic_ivf.control;
using clinic_ivf.gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            try
            {
                if (File.Exists("log.txt"))
                {
                    long length = new System.IO.FileInfo("log.txt").Length;
                    if (length >= 1024) length = length / 1024;     // kb
                    if (length >= 1024) length = length / 1024;     // mb
                    if (length >= 2) File.Delete("log.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error delete log.txt", "");
            }
            
            IvfControl ic = new IvfControl();
            FrmSplash spl = new FrmSplash();
            spl.Show();
            //MessageBox.Show("444", "");
            //try
            //{
            Application.Run(new gui.MainMenu(ic, spl));
            //}
            //catch(Exception ex)
            //{

            //}
        }
    }
}
