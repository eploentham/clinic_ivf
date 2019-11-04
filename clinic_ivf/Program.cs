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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            IvfControl ic = null;
            try
            {
                //MessageBox.Show("00000", "");
                
                if (File.Exists("log.txt"))
                {
                    long length = new System.IO.FileInfo("log.txt").Length;
                    if (length >= 1024) length = length / 1024;     // kb
                    if (length >= 1024) length = length / 1024;     // mb
                    //if (length >= 2) File.Delete("log.txt");
                }
                //MessageBox.Show("444444", "");
                if (args.Length > 0)
                {
                    ic = new IvfControl(args);
                    //MessageBox.Show("555555", "");
                    ic.args = args;
                }
                else
                {
                    ic = new IvfControl(null);
                    ic.args = args;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error delete log.txt\n"+ " log.txtlength "+ new FileInfo("log.txt").Length + "\n" + Application.ExecutablePath.ToString()+ " args Length " + args.Length+" args 0 "+ args[0], "");
            }

            if (ic.args.Length > 0)
            {
                //MessageBox.Show(Application.ExecutablePath.ToString() + "args Length" + args.Length + " args 0 " + args[0], "");
                Application.Run(new gui.FrmLabLIS());
            }
            else
            {
                FrmSplash spl = new FrmSplash();
                spl.Show();
                //MessageBox.Show("444", "");
                //try
                //{
                //MessageBox.Show("6666666", "");
                Application.Run(new gui.MainMenu(ic, spl));
            }
            
            //}
            //catch(Exception ex)
            //{

            //}
        }
    }
}
