using C1.Win.C1Command;
using clinic_ivf.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class MainMenu : Form
    {
        IvfControl ic;
        Login login;

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);
        Image CloseImage;
        
        Boolean flagExit = false;

        public MainMenu(IvfControl ic, FrmSplash splash)
        {
            this.ic = ic;
            InitializeComponent();
            login = new Login(ic, splash);
            login.ShowDialog(this);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                ic.ivfDB = new objdb.IvfDB(ic.conn);
                ic.getInit();
            }).Start();
            splash.Dispose();
            if (login.LogonSuccessful.Equals("1"))
            {
                initConfig();
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    /* run your code here */
                    
                }).Start();
            }
            else
            {
                Application.Exit();
            }
        }
        private void initConfig()
        {
            this.FormClosing += MainMenu4_FormClosing;
            menuExit.Click += MenuExit_Click;
            menuLabOpu.Click += MenuLabOpu_Click;
            menuLabFet.Click += MenuLabFet_Click;
            menuDept.Click += MenuDept_Click;
            menuPosi.Click += MenuPosi_Click;
            menuStaff.Click += MenuStaff_Click;
            menuOpuProce.Click += MenuOpuProce_Click;
            menuFetProce.Click += MenuFetProce_Click;
            menuTestForm.Click += MenuTestForm_Click;
            menuReqLab.Click += MenuReqLab_Click;
            menuLabAccept.Click += MenuLabAccept_Click;
            menuPatient.Click += MenuPatient_Click;
            convertPatientDonorToolStripMenuItem.Click += ConvertPatientDonorToolStripMenuItem_Click;
            menuVisitNew.Click += MenuVisitNew_Click;
            menuAppn.Click += MenuAppn_Click;
            menuNurseDefault.Click += MenuNurseDefault_Click;
            menuExamiRoom.Click += MenuExamiRoom_Click;
        }

        private void MenuExamiRoom_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmNurseView frm = new FrmNurseView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuExamiRoom.Text + " ");
        }

        private void MenuNurseDefault_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmNurseView frm = new FrmNurseView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuNurseDefault.Text + " ");
        }

        private void MenuAppn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAppoinmentView frm = new FrmAppoinmentView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuAppn.Text + " ");
        }

        private void MenuVisitNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmVisitView frm = new FrmVisitView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuVisitNew.Text + " ");
        }

        private void ConvertPatientDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmConvertData frm = new FrmConvertData(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, convertPatientDonorToolStripMenuItem.Text + " ");
        }

        private void MenuPatient_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPatientView frm = new FrmPatientView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuPatient.Text + " ");
        }

        private void MenuLabAccept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabReqAccept frm = new FrmLabReqAccept(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabAccept.Text + " ");
        }

        private void MenuReqLab_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabReqView frm = new FrmLabReqView(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuReqLab.Text + " ");
        }

        private void MenuTestForm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUAdd1 frm = new FrmLabOPUAdd1();
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuFetProce.Text + " ");
        }

        private void MenuFetProce_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOpuProce frm = new FrmLabOpuProce(ic, objdb.LabProcedureDB.StatusLab.FETProcedure);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuFetProce.Text + " ");
        }

        private void MenuOpuProce_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOpuProce frm = new FrmLabOpuProce(ic,objdb.LabProcedureDB.StatusLab.OPUProcedure);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuOpuProce.Text + " ");
        }

        private void MenuStaff_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStaff frm = new FrmStaff(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuStaff.Text + " ");
        }

        private void MenuPosi_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPosition frm = new FrmPosition(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuPosi.Text + " ");
        }

        private void MenuDept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDepartment1 frm = new FrmDepartment1(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDept.Text + " ");
        }

        private void MenuLabFet_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabFetView frm = new FrmLabFetView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabOpu.Text + " ");
        }

        private void MenuLabOpu_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOpuView frm = new FrmLabOpuView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabOpu.Text + " ");
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            appExit();
        }
        private void MainMenu4_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!flagExit)
                {
                    if (MessageBox.Show("ต้องการออกจากโปรแกรม3", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        //Close();
                        //return true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                //appExit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private Boolean appExit()
        {
            flagExit = true;
            if (MessageBox.Show("ต้องการออกจากโปรแกรม2", "ออกจากโปรแกรม menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (ic.video != null && ic.video.IsRunning)
                {
                    ic.video.SignalToStop();
                    ic.video.WaitForStop();
                    ic.video.Stop();
                    ic.video = null;
                }
                Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddNewTab(Form frm, String label)
        {
            foreach (Control y in tC1.Controls)
            {
                if (y is C1DockingTabPage)
                {
                    if (y.Text.Equals("Import JOB"))
                    {
                        if (label.Equals("Import JOB"))
                        {
                            tC1.SelectedTab = (C1DockingTabPage)y;
                            return;
                        }
                    }
                }
            }
            C1DockingTabPage tab = new C1DockingTabPage();
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tCC1.Width - 10;
            tab.Height = tCC1.Height - 35;

            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Width = tab.Width;
            frm.Height = tab.Height;
            tab.Text = label;
            //foreach (Control x in frm.Controls)
            //{
            //    if (x is DataGridView)
            //    {
            //        //x.Dock = DockStyle.Fill;
            //    }
            //}
            //tab.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            frm.Visible = true;

            tC1.TabPages.Add(tab);

            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
            frm.Location = new Point(0, 0);
            tab.ResumeLayout();
            tab.Refresh();
            tab.Text = label;
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                theme1.SetTheme(tC1, ic.iniC.themeDonor);
            }
            else
            {
                theme1.SetTheme(tC1, "Office2007Blue");
            }
            tC1.SelectedTab = tab;
            //theme1.SetTheme(tC1, "Office2010Blue");
            //theme1.SetTheme(tC1, "Office2010Green");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //    Close();
                //    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            
            this.Text = "สวัสดี คุณ "+ic.user.staff_fname_t +" "+ic.user.staff_lname_t+" Update 2018-11-10 ";
            //theme1.SetTheme(this, ic.theme);
            theme1.SetTheme(this, ic.theme);
            theme1.SetTheme(menuStrip1, ic.theme);
            theme1.SetTheme(tC1, ic.theme);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                //theme1.SetTheme(panel1, "BeigeOne");menuStrip1
                foreach (Control c in menuStrip1.Controls)
                {
                    theme1.SetTheme(c, ic.theme);
                }
                menuRecept.Visible = true;
                menuNurse.Visible = false;
                menuLab.Visible = false;
                menuInit.Visible = false;
                menuRecept.Text = "Reception Donor";
            }
            else
            {
                
                //foreach (Control c in tC1.Controls)
                //{
                //    if (c is C1DockingTab) continue;
                //    if (c is C1CommandDock) continue;
                //    if (c is C1DockingTabPage) continue;
                //    theme1.SetTheme(c, "Office2007Blue");
                //}
                menuRecept.Visible = true;
                menuNurse.Visible = true;
                menuLab.Visible = true;
                menuInit.Visible = true;
            }

        }
    }
}
