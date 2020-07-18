using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SplitContainer;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmCustomer:Form
    {
        IvfControl ic;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1SplitContainer sC;
        C1SplitterPanel scLeft, scRight;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfDrug;
        C1ThemeController theme;
        C1Button btnNew, btnEdit, btnSave, btnVoid;
        Label lbTxtCustCode, lbtxtCusNameT, lbtxtCusNameE, lbtxtTaxId, lbtxtRemark, lbtxtAddrT1, lbtxtAddrT2, lbtxtAddrT3, lbtxtAddrT4, lbtxtTele, lbtxtFax, lbtxtEmail, lbtxtContactName1, lbtxtContactName2, lbtxtContactTel1, lbtxtContactTel2;
        C1TextBox txtCustCode, txtID, txtCusNameT, txtCusNameE, txtTaxId, txtRemark, txtAddrT1, txtAddrT2, txtAddrT3, txtAddrT4, txtTele, txtFax, txtEmail, txtContactName1, txtContactName2, txtContactTel1, txtContactTel2;
        C1FlexGrid grfReq;
        Panel panel1;

        Customer cust;

        Boolean flagNew = false, flagEdit = false;
        Image imgStart;
        public FrmCustomer(IvfControl x)
        {
            ic = x;
            initCompoment();
            initConfig();
        }
        private void initCompoment()
        {
            int gapLine = 20, gapX = 20;
            Size size = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;

            sC = new C1SplitContainer();
            scLeft = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scRight = new C1.Win.C1SplitContainer.C1SplitterPanel();
            panel1 = new Panel();

            sC.SuspendLayout();
            scLeft.SuspendLayout();
            scRight.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();

            sC.Dock = System.Windows.Forms.DockStyle.Fill;
            sC.Location = new System.Drawing.Point(0, 0);
            sC.Name = "splitContainer1";
            sC.Size = new System.Drawing.Size(800, 450);
            sC.TabIndex = 0;

            scLeft.Collapsible = true;
            scLeft.Height = 86;
            scLeft.Location = new System.Drawing.Point(0, 21);
            scLeft.Name = "scLeft";
            scLeft.Size = new System.Drawing.Size(298, 58);
            scLeft.TabIndex = 0;
            scLeft.Text = "Customer List";
            scLeft.Dock = PanelDockStyle.Left;
            scRight.Height = 85;
            scRight.Location = new System.Drawing.Point(0, 111);
            scRight.Name = "scRight";
            scRight.Dock = PanelDockStyle.Right;
            scRight.Size = new System.Drawing.Size(298, 64);
            scRight.TabIndex = 1;
            scRight.Text = "Customer Add/Edit";

            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Name = "panel1";

            setControlComponent();
            sC.Panels.Add(scLeft);
            sC.Panels.Add(scRight);
            scRight.Controls.Add(panel1);
            this.Controls.Add(sC);

            panel1.ResumeLayout(false);
            sC.ResumeLayout(false);
            scLeft.ResumeLayout(false);
            scRight.ResumeLayout(false);
            
            this.ResumeLayout(false);

            panel1.PerformLayout();
            sC.PerformLayout();
            scLeft.PerformLayout();
            scRight.PerformLayout();
            

            this.PerformLayout();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            theme = new C1ThemeController();
            theme.Theme = C1ThemeController.ApplicationTheme;
            //theme.SetTheme(sB, "BeigeOne");
            //foreach (Control c in panel2.Controls)
            //{
            //    theme1.SetTheme(c, "Office2013Red");
            //}
            imgStart = Resources.accept_database24;
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            cust = new Customer();
            initGrfReq();
        }
        private void setControlComponent()
        {
            int gapLine = 20, gapX = 20, gapY=20;
            Size size = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));

            txtID = new C1TextBox();
            txtID.Font = fEdit;
            txtID.Location = new System.Drawing.Point(gapX, 20);
            txtID.Size = new Size(120, 20);

            lbTxtCustCode = new Label();
            lbTxtCustCode.Text = "รหัส : ";
            lbTxtCustCode.Font = fEditB;
            lbTxtCustCode.Location = new System.Drawing.Point(gapX, gapLine);
            lbTxtCustCode.AutoSize = true;
            lbTxtCustCode.Name = "lbTxtCustCode";
            txtCustCode = new C1TextBox();
            txtCustCode.Font = fEdit;
            size = ic.MeasureString(lbTxtCustCode);
            txtCustCode.Location = new System.Drawing.Point(lbTxtCustCode.Location.X + size.Width + 5, lbTxtCustCode.Location.Y);
            txtCustCode.Size = new Size(120, 20);
            txtCustCode.Name = "txtCustCode";

            gapLine += gapY;
            lbtxtCusNameT = new Label();
            lbtxtCusNameT.Text = "ชื่อ : ";
            lbtxtCusNameT.Font = fEditB;
            lbtxtCusNameT.Location = new System.Drawing.Point(gapX, gapLine);
            lbtxtCusNameT.AutoSize = true;
            lbtxtCusNameT.Name = "lbtxtCusNameT";
            txtCusNameT = new C1TextBox();
            txtCusNameT.Font = fEdit;
            size = ic.MeasureString(lbtxtCusNameT);
            txtCusNameT.Location = new System.Drawing.Point(lbtxtCusNameT.Location.X + size.Width + 5, lbtxtCusNameT.Location.Y);
            txtCusNameT.Size = new Size(120, 20);
            txtCusNameT.Name = "txtCusNameT";

            gapLine += gapY;
            lbtxtCusNameE = new Label();
            lbtxtCusNameE.Text = "Name : ";
            lbtxtCusNameE.Font = fEditB;
            lbtxtCusNameE.Location = new System.Drawing.Point(gapX, gapLine);
            lbtxtCusNameE.AutoSize = true;
            lbtxtCusNameE.Name = "lbtxtCusNameE";
            txtCusNameE = new C1TextBox();
            txtCusNameE.Font = fEdit;
            size = ic.MeasureString(lbtxtCusNameE);
            txtCusNameE.Location = new System.Drawing.Point(lbtxtCusNameE.Location.X + size.Width + 5, lbtxtCusNameE.Location.Y);
            txtCusNameE.Size = new Size(120, 20);
            txtCusNameE.Name = "txtCusNameE";

            gapLine += gapY;
            lbtxtTaxId = new Label();
            lbtxtTaxId.Text = "Name : ";
            lbtxtTaxId.Font = fEditB;
            lbtxtTaxId.Location = new System.Drawing.Point(gapX, gapLine);
            lbtxtTaxId.AutoSize = true;
            lbtxtTaxId.Name = "lbtxtTaxId";
            txtTaxId = new C1TextBox();
            txtTaxId.Font = fEdit;
            size = ic.MeasureString(lbtxtTaxId);
            txtTaxId.Location = new System.Drawing.Point(lbtxtCusNameE.Location.X + size.Width + 5, lbtxtCusNameE.Location.Y);
            txtTaxId.Size = new Size(120, 20);
            txtTaxId.Name = "txtTaxId";

            btnNew = new C1Button();
            btnNew.Name = "btnLisStart";
            btnNew.Text = "Start";
            btnNew.Font = fEdit;
            //size = bc.MeasureString(btnHnSearch);
            btnNew.Location = new System.Drawing.Point(txtTaxId.Location.X + txtTaxId.Width + 40, lbtxtCusNameE.Location.Y);
            btnNew.Size = new Size(60, 80);
            btnNew.Font = fEdit;
            btnNew.Image = imgStart;
            btnNew.TextAlign = ContentAlignment.MiddleRight;
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;

            panel1.Controls.Add(txtID);
            panel1.Controls.Add(lbTxtCustCode);
            panel1.Controls.Add(txtCustCode);
            panel1.Controls.Add(lbtxtCusNameT);
            panel1.Controls.Add(txtCusNameT);
            panel1.Controls.Add(lbtxtCusNameE);
            panel1.Controls.Add(txtCusNameE);
            panel1.Controls.Add(lbtxtTaxId);
            panel1.Controls.Add(txtTaxId);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(txtID);
        }
        private void initGrfReq()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfReq.DoubleClick += GrfReq_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfBillD.AfterDataRefresh += GrfBillD_AfterDataRefresh;
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            //menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfBillD.ContextMenu = menuGw;
            //grfBillD.SubtotalPosition = SubtotalPositionEnum.BelowData;
            scLeft.Controls.Add(grfReq);

            theme.SetTheme(grfReq, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }
        private void setControlEnable(Boolean flag)
        {
            txtCustCode.Enabled = flag;
            txtCusNameT.Enabled = flag;
            txtCusNameE.Enabled = flag;
            txtAddrT1.Enabled = flag;
            txtAddrT2.Enabled = flag;
            txtAddrT3.Enabled = flag;
            txtAddrT4.Enabled = flag;
            
            txtTele.Enabled = flag;
            txtFax.Enabled = flag;
            txtEmail.Enabled = flag;
            txtRemark.Enabled = flag;
            
            txtTaxId.Enabled = flag;
            txtContactName1.Enabled = flag;
            txtContactName2.Enabled = flag;
            txtContactTel1.Enabled = flag;
            txtContactTel2.Enabled = flag;
            //groupBox1.Enabled = flag;
            //chkVoid.Enabled = flag;
            //btnChkTaxId.Enabled = flag;
            //btnCont1.Enabled = flag;
            //btnCont2.Enabled = flag;
            btnSave.Enabled = flag;
            btnEdit.Enabled = !flagEdit;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
            //txtInsrNameT.Enabled = flag;
        }
        private void setCustomer()
        {
            cust.cust_id = txtID.Text;
            cust.cust_code = txtCustCode.Text.Trim();
            cust.cust_name_t = txtCusNameT.Text.Trim();
            cust.cust_name_e = txtCusNameE.Text.Trim();
            cust.tax_id = txtTaxId.Text.Trim();

            cust.address_t = "";
            cust.address_e = "";
            cust.addr = "";
            cust.amphur_id = "";
            cust.district_id = "";

            cust.province_id = "";
            cust.zipcode = "";
            cust.sale_id = "";
            cust.sale_name_t = "";
            cust.fax = txtFax.Text;

            cust.tele = txtTele.Text;
            cust.email = txtEmail.Text.Trim();
            cust.tax_id = txtTaxId.Text.Trim();
            cust.remark = txtRemark.Text;
            cust.contact_name1 = txtContactName1.Text.Trim();

            cust.contact_name2 = txtContactName2.Text.Trim();
            cust.contact_name1_tel = txtContactTel1.Text.Trim();
            cust.contact_name2_tel = txtContactTel2.Text.Trim();
            cust.status_company = "1";
            cust.status_vendor = "";

            cust.date_create = "";
            cust.date_modi = "";
            cust.date_cancel = "";
            cust.user_create = "";
            cust.user_modi = "";

            cust.user_cancel = "";
            //cust.remark2 = txtRemark2.Text;
            cust.po_due_period = "";
            cust.taddr1 = txtAddrT1.Text.Trim();
            cust.taddr2 = txtAddrT2.Text.Trim();

            cust.taddr3 = txtAddrT3.Value.ToString().Trim();
            cust.taddr4 = txtAddrT4.Value.ToString().Trim();
            //cust.eaddr1 = txtAddrE1.Value.ToString().Trim();
            //cust.eaddr2 = txtAddrE2.Value.ToString().Trim();
            //cust.eaddr3 = txtAddrE3.Value.ToString().Trim();

            //cust.eaddr4 = txtAddrE4.Value.ToString().Trim();
            cust.sort1 = "";

            //cust.status_cust = chkCus.Checked ? "1" : "0";
            //cust.status_imp = chkImp.Checked ? "1" : "0";
            //cust.status_fwd = chkFwd.Checked ? "1" : "0";
            //cust.status_exp = chkExp.Checked ? "1" : "0";
            //cust.status_cons_imp = chkCons.Checked ? "1" : "0";
            //cust.status_insr = ChkInsr.Checked ? "1" : "0";
            //cust.status_truck = chkTrk.Checked ? "1" : "0";
            //cust.status_container_yard = chkContainerYard.Checked ? "1" : "0";
            //cust.insr_id = insrId;
        }
        private void saveCustomer()
        {
            //Customer cus = new Customer();
            setCustomer();
            String re = ic.ivfDB.custDB.insertCustomer(cust);
            int chk = 0;
            if (int.TryParse(re, out chk))
            {
                if (flagNew)
                {
                    Address addr = new Address();
                    addr.address_id = "";
                    addr.address_code = "";
                    addr.line_t1 = txtAddrT1.Value.ToString().Trim();
                    addr.line_t2 = txtAddrT2.Value.ToString().Trim();
                    addr.line_t3 = txtAddrT3.Value.ToString().Trim();
                    addr.line_t4 = txtAddrT4.Value.ToString().Trim();
                    //addr.line_e1 = txtAddrE1.Value.ToString().Trim();
                    //addr.line_e2 = txtAddrE2.Value.ToString().Trim();
                    //addr.line_e3 = txtAddrE3.Value.ToString().Trim();
                    //addr.line_e4 = txtAddrE4.Value.ToString().Trim();
                    addr.prov_id = "";
                    addr.amphur_id = "";
                    addr.district_id = "";
                    addr.zipcode = "";
                    addr.email = txtEmail.Value.ToString().Trim();
                    addr.email2 = "";
                    addr.tele = txtTele.Value.ToString().Trim();
                    addr.mobile = "";
                    addr.fax = "";
                    addr.remark = "";
                    addr.address_type_id = "";
                    addr.table_id = re;
                    addr.date_create = "";
                    addr.date_modi = "";
                    addr.date_cancel = "";
                    addr.user_create = "";
                    addr.user_modi = "";
                    addr.user_cancel = "";
                    addr.active = "";
                    addr.address_name = "";
                    addr.contact_id = "";
                    addr.contact_name1 = txtContactName1.Text;
                    addr.contact_name2 = txtContactName2.Text;
                    addr.contact_name_tel1 = txtContactTel1.Text;
                    addr.contact_name_tel2 = txtContactTel2.Text;

                    addr.web_site1 = "";
                    addr.web_site2 = "";
                    addr.google_map = "";
                    addr.status_defalut_customer = "1";
                    String re1 = ic.ivfDB.addrDB.insertAddress(addr);

                }

                btnSave.Image = Resources.accept_database24;
                //sB1.Text = "บันทึกข้อมูล " + cust.cust_code + " เรียบร้อย ";
            }
        }
    }
}
