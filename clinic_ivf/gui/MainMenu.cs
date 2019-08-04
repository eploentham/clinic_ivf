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
            //MessageBox.Show("111", "");
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
            //menuExamiRoom.Click += MenuExamiRoom_Click;
            menuDrugPatient.Click += MenuDrugPatient_Click;
            menuReqLabFormA.Click += MenuReqLabFormA_Click;
            menuCashierDefault.Click += MenuCashierDefault_Click;
            menuDocGroupScan.Click += MenuDocGroupScan_Click;
            menuDocGroupSubScan.Click += MenuDocGroupSubScan_Click;
            menuMedicalRecordDocScan.Click += MenuMedicalRecordDocScan_Click;
            menuMedicalRecordView.Click += MenuMedicalRecordView_Click;
            menuAgent.Click += MenuAgent_Click;
            menuPackage.Click += MenuPackage_Click;
            menuDrug.Click += MenuDrug_Click;
            menuGrpDiag.Click += MenuGrpDiag_Click;
            menuOrDiag.Click += MenuOrDiag_Click;
            menuOrAnes.Click += MenuOrAnes_Click;
            menuReqOR.Click += MenuReqOR_Click;
            menuOrScreen.Click += MenuOrScreen_Click;
            menuTest.Click += MenuTest_Click;
            menuDoctorDefault.Click += MenuDoctorDefault_Click;
            menuSpecialItem.Click += MenuSpecialItem_Click;
            menuLabItem.Click += MenuLabItem_Click;
            menuStock.Click += MenuStock_Click;
            menuStockRec.Click += MenuStockRec_Click;
            menuLabSperm.Click += MenuLabSperm_Click;
            menuLabBlood.Click += MenuLabBlood_Click;
        }

        private void MenuLabBlood_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabBloodView frm = new FrmLabBloodView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabBlood.Text + " ");
        }

        private void MenuLabSperm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabSpermView frm = new FrmLabSpermView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabSperm.Text + " ");
        }

        private void MenuStockRec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStockRec frm = new FrmStockRec(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuStockRec.Text + " ");
        }

        private void MenuStock_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStockOnhand frm = new FrmStockOnhand(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuStock.Text + " ");
        }

        private void MenuLabItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabItem frm = new FrmLabItem(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuLabItem.Text + " ");
        }

        private void MenuSpecialItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSpecialItem frm = new FrmSpecialItem(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuSpecialItem.Text + " ");
        }

        private void MenuDoctorDefault_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDoctorView frm = new FrmDoctorView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDoctorDefault.Text + " ");
        }

        private void MenuTest_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form3 frm = new Form3(ic);
            frm.ShowDialog(this);
        }

        private void MenuOrScreen_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmOrView frm = new FrmOrView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuOrScreen.Text + " ");
        }

        private void MenuReqOR_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmOrReqAdd frm = new FrmOrReqAdd(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuExamiRoom.Text + " ");
        }

        private void MenuOrAnes_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmOrAnesthesia frm = new FrmOrAnesthesia(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuOrAnes.Text + " ");
        }

        private void MenuOrDiag_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmOrOperation frm = new FrmOrOperation(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuOrDiag.Text + " ");
        }

        private void MenuGrpDiag_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmOrDiagGroup frm = new FrmOrDiagGroup(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuGrpDiag.Text + " ");
        }

        private void MenuDrug_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStockDrug frm = new FrmStockDrug(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDrug.Text + " ");
        }

        private void MenuPackage_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPackage frm = new FrmPackage(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuPackage.Text + " ");
        }

        private void MenuAgent_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAgent frm = new FrmAgent(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuAgent.Text + " ");
        }

        private void MenuMedicalRecordView_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmScanView frm = new FrmScanView(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuMedicalRecordView.Text + " ");
        }

        private void MenuMedicalRecordDocScan_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmScanAdd frm = new FrmScanAdd(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuMedicalRecordDocScan.Text + " ");
        }

        private void MenuDocGroupSubScan_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDocGroupSub frm = new FrmDocGroupSub(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDocGroupSubScan.Text + " ");
        }

        private void MenuDocGroupScan_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDocGroupScan frm = new FrmDocGroupScan(ic);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDocGroupScan.Text + " ");
        }

        private void MenuCashierDefault_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String tabname = "FrmCashierView";
            bool found = false;
            foreach (C1DockingTabPage tab in tC1.TabPages)
            {
                if (tabname.Equals(tab.Name))
                {
                    tC1.SelectedTab = tab;
                    found = true;
                    break;
                }
            }
            //var tabPage = tC1.TabPages["FrmCashierView"];
            if (!found)
            {
                //tC1.SelectedTab = tabPage;
                FrmCashierView frm = new FrmCashierView(ic, this);
                frm.FormBorderStyle = FormBorderStyle.None;
                //frm.Name = "FrmCashierView";
                AddNewTab(frm, menuCashierDefault.Text + " ");
            }
        }

        private void MenuReqLabFormA_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabFormAView frm = new FrmLabFormAView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuReqLabFormA.Text + " ");
            //frm.ShowDialog(this);
        }

        private void MenuDrugPatient_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmPharmaPttView frm = new FrmPharmaPttView(ic, this);
            FrmPharmaView frm = new FrmPharmaView(ic, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuDrugPatient.Text + " ");
        }

        private void MenuExamiRoom_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmOrReqAdd frm = new FrmOrReqAdd(ic);
            //frm.FormBorderStyle = FormBorderStyle.None;
            //AddNewTab(frm, menuExamiRoom.Text + " ");
        }

        private void MenuNurseDefault_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String tabname = "FrmNurseView";
            bool found = false;
            foreach (C1DockingTabPage tab in tC1.TabPages)
            {
                if (tabname.Equals(tab.Name))
                {
                    tC1.SelectedTab = tab;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                FrmNurseView frm = new FrmNurseView(ic, this);
                frm.FormBorderStyle = FormBorderStyle.None;
                AddNewTab(frm, menuNurseDefault.Text + " ");
            }
        }

        private void MenuAppn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAppointmentView frm = new FrmAppointmentView(ic, this);
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
            String tabname = "FrmPatientView";
            bool found = false;
            foreach (C1DockingTabPage tab in tC1.TabPages)
            {
                if (tabname.Equals(tab.Name))
                {
                    tC1.SelectedTab = tab;
                    found = true;
                    break;
                }
            }
            //var tabPage = tC1.TabPages["FrmCashierView"];
            if (!found)
            {
                FrmPatientView frm = new FrmPatientView(ic, this);
                frm.FormBorderStyle = FormBorderStyle.None;
                AddNewTab(frm, menuPatient.Text + " ");
            }
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
            AddNewTab(frm, menuLabFet.Text + " ");
        }

        private void MenuLabOpu_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String tabname = "FrmLabOpuView";
            bool found = false;
            foreach (C1DockingTabPage tab in tC1.TabPages)
            {
                if (tabname.Equals(tab.Name))
                {
                    tC1.SelectedTab = tab;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                FrmLabOpuView frm = new FrmLabOpuView(ic, this);
                frm.FormBorderStyle = FormBorderStyle.None;
                AddNewTab(frm, menuLabOpu.Text + " ");
            }
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
        public void removeTab(C1DockingTabPage tab)
        {
            tC1.TabPages.Remove(tab);
        }
        public C1DockingTabPage AddNewTab(Form frm, String label)
        {
            //foreach (Control y in tC1.Controls)
            //{
            //    if (y is C1DockingTabPage)
            //    {
            //        if (y.Text.Equals("Import JOB"))
            //        {
            //            if (label.Equals("Import JOB"))
            //            {
            //                tC1.SelectedTab = (C1DockingTabPage)y;
            //                return;
            //            }
            //        }
            //    }
            //}
            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = new C1DockingTabPage();
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tCC1.Width - 10;
            tab.Height = tCC1.Height - 35;
            tab.Name = frm.Name;

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
            return tab;
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    // ...
        //    if (keyData == (Keys.Escape))
        //    {
        //        appExit();
        //        //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
        //        //{
        //        //    Close();
        //        //    return true;
        //        //}
        //    }
        //    else
        //    {
        //        //keyData
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        private void MainMenu_Load(object sender, EventArgs e)
        {
            String date = "";
            date = DateTime.Now.Year+"-"+ DateTime.Now.ToString("MM-dd");
            this.Text = ic.iniC.statusAppDonor.Equals("1") ? "โปรแกรมClinic IVF Donor " +"สวัสดี คุณ "+ic.user.staff_fname_t +" "+ic.user.staff_lname_t+" Update 2019-08-03 "
                : "โปรแกรมClinic IVF " + "สวัสดี คุณ " + ic.user.staff_fname_t + " " + ic.user.staff_lname_t + " Update 2019-08-03 format date "+ date;

            //theme1.SetTheme(this, ic.theme);
            theme1.SetTheme(this, ic.theme);
            theme1.SetTheme(menuStrip1, ic.theme);
            theme1.SetTheme(tC1, ic.theme);
            menuRecept.Visible = false;
            menuNurse.Visible = false;
            menuLab.Visible = false;
            menuPharmacy.Visible = false;
            menuInit.Visible = false;
            //MessageBox.Show("222", "");
            try
            {
                if (ic.user.status_module_reception.Equals("1"))
                {
                    //theme1.SetTheme(panel1, "BeigeOne");menuStrip1
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuRecept.Visible = true;
                    //if (ic.iniC.statusAppDonor.Equals("1"))
                    //    menuRecept.Text = "Reception Donor";
                }
                if (ic.user.status_module_nurse.Equals("1"))
                {
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuNurse.Visible = true;
                }
                if (ic.user.status_module_pharmacy.Equals("1"))
                {
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuPharmacy.Visible = true;
                }
                if (ic.user.status_module_lab.Equals("1"))
                {
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuLab.Visible = true;
                }
                if (ic.user.status_admin.Equals("2"))
                {
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuInit.Visible = true;
                }
                if (ic.user.status_module_cashier.Equals("1"))
                {
                    foreach (Control c in menuStrip1.Controls)
                    {
                        theme1.SetTheme(c, ic.theme);
                    }
                    menuCashier.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message, "");
            }
            //MessageBox.Show("333", "");
            //else
            //{

            //    //foreach (Control c in tC1.Controls)
            //    //{
            //    //    if (c is C1DockingTab) continue;
            //    //    if (c is C1CommandDock) continue;
            //    //    if (c is C1DockingTabPage) continue;
            //    //    theme1.SetTheme(c, "Office2007Blue");
            //    //}
            //    menuRecept.Visible = true;
            //    menuNurse.Visible = true;
            //    menuLab.Visible = true;
            //    menuInit.Visible = true;
            //}

        }
    }
}
