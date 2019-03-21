using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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
    public partial class FrmNurseAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;

        String pttId = "", webcamname = "", vsid = "";
        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder, grfPackage, grfPackageD, grfRxSetD;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colBlId = 1, colBlName = 2, colBlQty=3, colBlPrice = 4, colBlInclude = 5, colBlRemark=6;
        int colPkgdId = 1, colPkgId = 2, colPkgType = 3, colPkgItmName = 4, colPkgItmId = 5, colPkgQty = 6;
        int colRxdId = 1, colRxName = 2, colRxQty = 3, colRxPrice=4, colRxInclude=5, colRxRemark=6, colRxUsE=7, colRxUsT=8, colRxId = 9, colRxItmId = 10;

        int colOrderId = 1, colOrderVn = 2, colOrderLID = 3, colOrderExtra = 4, colOrderPrice = 5, colOrderStatus=6;
        int colOrderPID = 7, colOrderPIDS = 8, colOrderLName = 9, colOrderSP1V = 10, colOrderSP2V = 11, colOrderSP3V = 12;
        int colOrderSP4V = 13, colOrderSP5V = 14, colOrderSP6V = 15, colOrderSP7V = 16, colOrderSubItem = 17;
        int colOrderFileName = 18, colOrderWorder1 = 19, colOrderWorker2 = 20, colOrderWorker3 = 21, colOrderWorkder4 = 22;
        int colOrderWorker5 = 23, colOrderLGID = 24, colOrderQTY = 25, colOrderActive = 26;
        int colOrdid = 1, colOrdlpid=2, colOrdName=3, colOrdPrice=4, colOrdQty=5, colOrdstatus=6, colOrdrow1=7, colOrditmid=8, colOrdInclude=9, colOrdAmt=10, colOrdUsE = 11, colOrdUsT = 12;
        int rowOrder = 0;

        public FrmNurseAdd(IvfControl ic, MainMenu m, String pttid, String vsid)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vsid = vsid;
            this.pttId = pttid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tabOrder, "MacSilver");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            ic.setCboLangSticker(cboLangSticker);

            ic.ivfDB.opkgstDB.setCboSex(cboSellThruID, "");
            tabOrder.Click += TabOrder_Click;
            btnPkgOrder.Click += BtnPkgOrder_Click;
            btnRxSetOrder.Click += BtnRxSetOrder_Click;
            btnFinish.Click += BtnFinish_Click;
            cboLangSticker.SelectedIndexChanged += CboLangSticker_SelectedIndexChanged;

            setControl(vsid);
            //btnNew.Click += BtnNew_Click;
            //txtSearch.KeyUp += TxtSearch_KeyUp;
            initGrfBloodLab();
            setGrfBloodLab();
            initGrfSpermLab();
            setGrfSperm();
            initGrfEmbryoLab();
            setGrfEmbryo();
            initGrfGeneticLab();
            initGrfSpecialLab();
            initGrfRx();
            initGrfRxSet();
            initGrfOrder();
            initGrfPackage();
            initGrfPackageD();
            initGrfRxSetD();
            setGrfGenetic();
            setGrfSpecial();
            setGrfRx();
            setGrfRxSet();
            setGrfpackage();
            setGrfOrder(txtVn.Text);
            //initGrfPtt();
            //setGrfPtt("");
        }

        private void CboLangSticker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cboLangSticker.Text.Equals("English"))
            {
                grfRx.Cols[colRxUsT].Visible = false;
                grfRx.Cols[colRxUsE].Visible = true;

                grfRxSetD.Cols[colRxUsT].Visible = false;
                grfRxSetD.Cols[colRxUsE].Visible = true;
            }
            else
            {
                grfRx.Cols[colRxUsT].Visible = true;
                grfRx.Cols[colRxUsE].Visible = false;
                grfRxSetD.Cols[colRxUsT].Visible = true;
                grfRxSetD.Cols[colRxUsE].Visible = false;
            }
        }

        private void CboLangSticker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void CboLangSticker_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.nurseFinish(txtVnOld.Text);
            VisitOld ovs = new VisitOld();
            ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);
            if (ovs.VSID.Equals("160"))
            {
                menu.removeTab(tab);
                //return;
            }
            //setGrfOrder(txtVn.Text);
        }

        private void BtnRxSetOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setRxSet();
            //if (grfRxSetD.Rows.Count > 0)
            //{
            //    String gdid = "";
            //    gdid = grfRxSet[grfRxSet.Row, colBlId].ToString();
            //    ic.ivfDB.PxSetAdd(gdid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "");
            //    setGrfOrder(txtVnOld.Text);
            //}
        }

        private void BtnPkgOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            OldPackageSold opkgs = new OldPackageSold();
            opkgs.PCKSID = "";
            opkgs.PID = txtHn.Text;
            opkgs.SellThruID = cboSellThruID.SelectedItem == null ? "" : ((ComboBoxItem)cboSellThruID.SelectedItem).Value;
            opkgs.PCKID = txtPkgId.Text;
            opkgs.PackageName = txtPkgName.Text;
            opkgs.Price = txtPrice.Text;
            opkgs.Date = "";
            opkgs.PaymentTimes = "";
            opkgs.Status = "1";
            opkgs.Payment1 = txtPayment1.Text;
            opkgs.Payment2 = txtPayment2.Text;
            opkgs.Payment3 = txtPayment3.Text;
            opkgs.Payment4 = txtPayment4.Text;
            opkgs.P1BDetailID = "";
            opkgs.P2BDetailID = "";
            opkgs.P3BDetailID = "";
            opkgs.P4BDetailID = "";
            opkgs.VN = txtVnOld.Text;
            opkgs.row1 = grfOrder.Rows.Count.ToString();
            ic.ivfDB.PackageAdd(opkgs);
            setGrfOrder(txtVn.Text);
        }

        private void TabOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tabOrder.SelectedTab == tabRx)
            {
                ic.ivfDB.oJpxDB.setJobPx(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabSpecialItem)
            {
                ic.ivfDB.oJsDB.setJobSpecial(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabGeneticLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabEmbryoLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabSpermLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabBloodLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabRxSet)
            {
                btnPkgOrder.Enabled = false;
            }
            else if (tabOrder.SelectedTab == tabPackage)
            {

            }
        }
        private void UpdateTotals()
        {
            // clear existing totals
            grfOrder.Subtotal(AggregateEnum.Clear);
            grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colOrdAmt, "Total");
        }
        private void setControl(String vsid)
        {
            vsOld = ic.ivfDB.ovsDB.selectByPk1(vsid);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            ptt = ic.ivfDB.pttDB.selectByHn(vsOld.PIDS);
            ptt.patient_birthday = pttOld.DateOfBirth;
            txtHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtPttNameE.Value = vsOld.PName;
            txtDob.Value = ic.datetoShow(pttOld.DateOfBirth) + " ["+ptt.AgeStringShort()+"]";
            txtAllergy.Value = ptt.allergy_description;
            txtIdOld.Value = pttOld.PID;
            txtVnOld.Value = vsOld.VN;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง" ;
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O" 
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B" 
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            //txtBg.Value = pttOld.b
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfOrder.AfterDataRefresh += GrfOrder_AfterDataRefresh;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_or_void));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "GreenHouse");

        }

        private void GrfOrder_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }

        private void ContextMenu_or_void(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            String id = "", status="";
            rowOrder--;
            id = grfOrder[grfOrder.Row, colOrdid].ToString();
            status = grfOrder[grfOrder.Row, colOrdstatus].ToString();
            if (status.Equals("bloodlab") || status.Equals("Sperm Lab") || status.Equals("Embryo Lab") || status.Equals("Genetic Lab"))
            {
                ic.ivfDB.oJlabdDB.deleteByPk(id);
            }
            else if (status.Equals("specialitem"))
            {
                ic.ivfDB.ojsdDB.deleteByPk(id);
            }
            else if (status.Equals("px"))
            {
                ic.ivfDB.oJpxdDB.deleteByPk(id);
            }
            else if (status.Equals("package"))
            {
                ic.ivfDB.opkgsDB.deleteByPk(id);
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();
            
            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }
            foreach (DataRow row in dtpkg.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["PCKSID"];
                row1["itmid"] = row["PCKID"];
                row1["lgid"] = "";
                row1["name"] = row["PackageName"];
                row1["price"] = row["Price"];
                row1["qty"] = "1";
                row1["status"] = "package";
                row1["row1"] = row["row1"];
                row1["extra"] = "0";
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }
            dtAll.DefaultView.Sort = "row1";
            DataView view = dtAll.DefaultView;
            view.Sort = "row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 13;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;

            grfOrder.Cols[3].Width = 220;
            grfOrder.Cols[4].Width = 120;
            grfOrder.Cols[5].Width = 80;
            //grfOrder.Cols[colBlRemark].Width = 100;

            grfOrder.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOrder.Cols[colOrdName].Caption = "Name";
            grfOrder.Cols[colOrdPrice].Caption = "Price";
            grfOrder.Cols[colOrdQty].Caption = "QTY";
            grfOrder.Cols[colOrdInclude].Caption = "Include Package";
            //grfOrder.Cols[colBlRemark].Caption = "Remark";
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfOrder.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0;
                    Row row1 = grfOrder.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    //row1[colOrdPrice] = row["price"].ToString();
                    //row1[colOrdQty] = row["qty"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";
                    
                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["extra"].ToString().Equals("1"))
                    {
                        ext += (price * qty);
                    }
                    else
                    {
                        inc += (price * qty);
                    }
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            rowOrder = grfOrder.Rows.Count;
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colOrdrow1].Visible = false;
            grfOrder.Cols[colOrdlpid].Visible = false;
            grfOrder.Cols[colOrdid].Visible = false;
            grfOrder.Cols[colOrdstatus].Visible = false;
            grfOrder.Cols[colOrditmid].Visible = false;

            //grfOrder.Cols[colOrderStatus].Visible = false;
            //grfOrder.Cols[colOrderPID].Visible = false;
            //grfOrder.Cols[colOrderPIDS].Visible = false;
            //grfOrder.Cols[colOrderSP1V].Visible = false;
            //grfOrder.Cols[colOrderSP2V].Visible = false;
            //grfOrder.Cols[colOrderSP3V].Visible = false;
            //grfOrder.Cols[colOrderSP4V].Visible = false;
            //grfOrder.Cols[colOrderSP5V].Visible = false;
            //grfOrder.Cols[colOrderSP6V].Visible = false;
            //grfOrder.Cols[colOrderSP7V].Visible = false;
            //grfOrder.Cols[colOrderSubItem].Visible = false;
            //grfOrder.Cols[colOrderFileName].Visible = false;
            //grfOrder.Cols[colOrderWorder1].Visible = false;
            //grfOrder.Cols[colOrderWorker2].Visible = false;
            //grfOrder.Cols[colOrderWorker3].Visible = false;
            //grfOrder.Cols[colOrderWorkder4].Visible = false;
            //grfOrder.Cols[colOrderWorker5].Visible = false;
            //grfOrder.Cols[colOrderLGID].Visible = false;
            //grfOrder.Cols[colOrderActive].Visible = false;
            //grfOrder.Cols[colOrderLID].Visible = false;

            grfOrder.Cols[3].AllowEditing = false;
            grfOrder.Cols[4].AllowEditing = false;
            grfOrder.Cols[5].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            UpdateTotals();
            String total = "";
            Decimal total1 = 0;
            total = grfOrder[grfOrder.Rows.Count - 1, colOrdAmt] != null ? grfOrder[grfOrder.Rows.Count - 1, colOrdAmt].ToString() : "";
            Decimal.TryParse(total, out total1);
            txtTotal.Value = total1.ToString("#,###.00");
            txtInclude.Value = inc.ToString("#,###.00");
            txtExtra.Value = ext.ToString("#,###.00");
        }
        private void setGrfpackageD(String id)
        {
            //grfDept.Rows.Count = 7;
            grfPackageD.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oPkgdDB.selectByPkgId(id);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfPackageD.DataSource = dt;
            grfPackageD.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPackageD.Cols[colBlName].Editor = txt;
            grfPackageD.Cols[colBlInclude].Editor = txt;
            grfPackageD.Cols[colBlPrice].Editor = txt;
            grfPackageD.Cols[colBlRemark].Editor = txt;

            grfPackageD.Cols[colBlName].Width = 220;
            grfPackageD.Cols[colBlInclude].Width = 120;
            grfPackageD.Cols[colBlPrice].Width = 80;
            grfPackageD.Cols[colBlRemark].Width = 100;

            grfPackageD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPackageD.Cols[colPkgType].Caption = "Type";
            grfPackageD.Cols[colPkgItmName].Caption = "Name";
            grfPackageD.Cols[colPkgQty].Caption = "QTY";
            //grfPackageD.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfPackageD[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfPackageD);
            grfPackageD.Cols[colPkgdId].Visible = false;
            grfPackageD.Cols[colPkgId].Visible = false;
            grfPackageD.Cols[colPkgItmId].Visible = false;

            grfPackageD.Cols[colPkgType].AllowEditing = false;
            grfPackageD.Cols[colPkgItmName].AllowEditing = false;
            grfPackageD.Cols[colPkgQty].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfPackageD()
        {
            grfPackageD = new C1FlexGrid();
            grfPackageD.Font = fEdit;
            grfPackageD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPackageD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            //grfPackageD.AfterRowColChange += GrfPackageD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPackageD.ContextMenu = menuGw;
            pnPackageD.Controls.Add(grfPackageD);

            theme1.SetTheme(grfPackageD, "GreenHouse");

        }

        private void GrfPackageD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfpackage()
        {
            //grfDept.Rows.Count = 7;
            grfPackage.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oPkgDB.selectAll();

            grfPackage.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfPackage.DataSource = dt;
            grfPackage.Cols.Count = 7;
            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfPackage.Cols[colBlName].Width = 320;
            grfPackage.Cols[colBlInclude].Width = 120;
            grfPackage.Cols[colBlPrice].Width = 80;
            grfPackage.Cols[colBlRemark].Width = 100;

            grfPackage.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPackage.Cols[colBlName].Caption = "Name";
            grfPackage.Cols[colBlInclude].Caption = "Include";
            grfPackage.Cols[colBlPrice].Caption = "Price";
            grfPackage.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfBloodLab.GetCellRange(2, colBlInclude, grfBloodLab.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oPkgDB.oPkg.Price].ToString(), out aaa);
                    grfPackage[i, colBlPrice] = aaa.ToString("#,##0");
                    grfPackage[i, colBlId] = row[ic.ivfDB.oPkgDB.oPkg.PCKID].ToString();
                    grfPackage[i, colBlName] = row[ic.ivfDB.oPkgDB.oPkg.PackageName].ToString();
                    grfPackage[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfPackage);
            grfPackage.Cols[colBlId].Visible = false;
            grfPackage.Cols[colBlInclude].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;

            grfPackage.Cols[colBlName].AllowEditing = false;
            grfPackage.Cols[colBlPrice].AllowEditing = false;
            grfPackage.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfPackage()
        {
            grfPackage = new C1FlexGrid();
            grfPackage.Font = fEdit;
            grfPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPackage.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackage);

            grfPackage.AfterRowColChange += GrfPackage_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_pkg));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPackage.ContextMenu = menuGw;
            pnPackage.Controls.Add(grfPackage);

            theme1.SetTheme(grfPackage, "GreenHouse");

        }
        private void ContextMenu_order_pkg(object sender, System.EventArgs e)
        {
            if (grfPackage.Row <= 0) return;
            if (grfPackage[grfPackage.Row, colBlId] == null) return;
            String pkgid = "", include = "", qty = "";
            pkgid = grfPackage[grfPackage.Row, colBlId].ToString();
            ic.ivfDB.SpecialAdd(pkgid, "1", txtIdOld.Text, txtHn.Text, txtVnOld.Text, "", "", "", "", "","");
            setGrfOrder(txtVnOld.Text);
        }
        private void GrfPackage_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPackage.Row < 0) return;
            if (grfPackage[grfPackage.Row, colBlId]==null) return;

            String id = "";
            id = grfPackage[grfPackage.Row, colBlId].ToString();
            OldPackageHeader opkg = new OldPackageHeader();
            opkg = ic.ivfDB.oPkgDB.selectByPk1(id);
            txtPkgName.Value = opkg.PackageName;
            txtPkgId.Value = opkg.PCKID;
            txtPrice.Value = opkg.Price;

            setGrfpackageD(id);
        }
        
        private void initGrfRxSetD()
        {
            grfRxSetD = new C1FlexGrid();
            grfRxSetD.Font = fEdit;
            grfRxSetD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSetD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfRxSetD.AfterRowColChange += GrfRxSetD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSetD.ContextMenu = menuGw;
            pnRxSetD.Controls.Add(grfRxSetD);

            theme1.SetTheme(grfRxSetD, "Office2016DarkGray");

        }

        private void GrfRxSetD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfRxSetD(String id)
        {
            //grfDept.Rows.Count = 7;
            grfRxSetD.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGudDB.selectByGdId1(id);

            grfRxSetD.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRxSetD.DataSource = dt;
            grfRxSetD.Cols.Count = 11;
            CellStyle cs = grfRxSetD.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRxSetD.Cols[colRxName].Width = 300;
            grfRxSetD.Cols[colRxInclude].Width = 60;
            grfRxSetD.Cols[colRxPrice].Width = 80;
            grfRxSetD.Cols[colRxRemark].Width = 100;
            grfRxSetD.Cols[colRxUsE].Width = 200;
            grfRxSetD.Cols[colRxUsT].Width = 200;
            grfRxSetD.Cols[colRxQty].Width = 60;

            grfRxSetD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSetD.Cols[colRxName].Caption = "Name";
            grfRxSetD.Cols[colRxInclude].Caption = "Include";
            grfRxSetD.Cols[colRxPrice].Caption = "Price";
            grfRxSetD.Cols[colRxQty].Caption = "QTY";
            grfRxSetD.Cols[colRxRemark].Caption = "Remark";

            CellRange rg = grfRxSetD.GetCellRange(1, colRxInclude, grfRxSetD.Rows.Count - 1, colRxInclude);
            rg.Style = cs;
            rg.Style = grfRxSetD.Styles["bool"];
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;

                    Decimal.TryParse(row["Price"].ToString(), out aaa);
                    grfRxSetD[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRxSetD[i, colRxdId] = row[ic.ivfDB.oGudDB.oGuD.DUID].ToString();
                    grfRxSetD[i, colRxName] = row[ic.ivfDB.oGudDB.oGuD.DUName].ToString();
                    grfRxSetD[i, colRxQty] = row[ic.ivfDB.oGudDB.oGuD.QTY].ToString();
                    grfRxSetD[i, colRxUsE] = row["EUsage"].ToString();
                    grfRxSetD[i, colRxUsT] = row["TUsage"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRxSetD);
            grfRxSetD.Cols[colRxdId].Visible = false;
            grfRxSetD.Cols[colRxId].Visible = false;
            grfRxSetD.Cols[colRxItmId].Visible = false;
            grfRxSetD.Cols[colBlRemark].Visible = false;

            grfRxSetD.Cols[colRxName].AllowEditing = false;
            grfRxSetD.Cols[colRxQty].AllowEditing = false;
            //grfRxSetD.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            
            if (dt.Rows.Count>0)
                btnPkgOrder.Enabled = true;
        }
        private void initGrfRxSet()
        {
            grfRxSet = new C1FlexGrid();
            grfRxSet.Font = fEdit;
            grfRxSet.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSet.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfRxSet);

            grfRxSet.AfterRowColChange += GrfRxSet_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSet.ContextMenu = menuGw;
            pnRxSet.Controls.Add(grfRxSet);

            theme1.SetTheme(grfRxSet, "Office2016DarkGray");

        }
        private void setRxSet()
        {
            if (grfRxSetD.Rows.Count > 0)
            {
                if (grfRxSetD.Row <= 0) return;
                foreach (Row row in grfRxSetD.Rows)
                {
                    if (row[colRxdId] == null) continue;
                    String duid = "", include = "", qty = "", usaget = "", usagee = "", duname = "", price = "";
                    duid = row[colRxdId].ToString();
                    usaget = row[colRxUsT].ToString();
                    usagee = row[colRxUsE].ToString();
                    duname = row[colRxName].ToString();
                    price = row[colRxPrice].ToString();
                    include = row[colRxInclude] != null ? row[colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
                    qty = row[colBlQty] != null ? row[colBlQty].ToString() : "1";
                    if (include.Equals("1"))
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                    else
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                }

                setGrfOrder(txtVnOld.Text);
            }
        }
        private void ContextMenu_order_rx_set(object sender, System.EventArgs e)
        {
            setRxSet();
        }
        private void GrfRxSet_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRxSet.Row < 0) return;
            if (grfRxSet[grfRxSet.Row, colBlId] == null) return;
            //btnPkgOrder.Enabled = false;
            String id = grfRxSet[grfRxSet.Row, colBlId].ToString();
            setGrfRxSetD(id);

        }

        private void setGrfRxSet()
        {
            //grfDept.Rows.Count = 7;
            grfRxSet.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGrpDb.selectByGrpDrugH1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfRxSet.DataSource = dt;
            grfRxSet.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfRxSet.Cols[colBlName].Editor = txt;
            grfRxSet.Cols[colBlInclude].Editor = txt;
            grfRxSet.Cols[colBlPrice].Editor = txt;
            grfRxSet.Cols[colBlRemark].Editor = txt;

            grfRxSet.Cols[colBlName].Width = 320;
            grfRxSet.Cols[colBlInclude].Width = 120;
            grfRxSet.Cols[colBlPrice].Width = 80;
            grfRxSet.Cols[colBlRemark].Width = 100;

            grfRxSet.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSet.Cols[colBlName].Caption = "Name";
            grfRxSet.Cols[colBlInclude].Caption = "Include";
            grfRxSet.Cols[colBlPrice].Caption = "Price";
            grfRxSet.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfRxSet.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    //if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRxSet);
            grfRxSet.Cols[colBlId].Visible = false;
            grfRxSet.Cols[colBlInclude].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;

            grfRxSet.Cols[colBlName].AllowEditing = false;
            grfRxSet.Cols[colBlPrice].AllowEditing = false;
            grfRxSet.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfRx()
        {
            grfRx = new C1FlexGrid();
            grfRx.Font = fEdit;
            grfRx.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRx.Location = new System.Drawing.Point(0, 0);

            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);

            grfRx.DoubleClick += GrfRx_DoubleClick;
            //grfRx.AfterFilter += GrfRx_AfterFilter;

            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRx.ContextMenu = menuGw;
            pnRx.Controls.Add(grfRx);

            theme1.SetTheme(grfRx, "Office2010Black");

        }

        private void GrfRx_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfRx.Cols.Fixed; col < grfRx.Cols.Count; ++col)
            {
                var filter = grfRx.Cols[col].ActiveFilter;
            }
        }

        private void GrfRx_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRx.Row < 0) return;
            String duid = "";
        }

        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            if (grfRx.Row <= 0) return;
            if (grfRx[grfRx.Row, colBlId] == null) return;
            String chk = "", name = "", drugid = "",qty="", include = "", usage="";
            drugid = grfRx[grfRx.Row, colRxdId] != null ? grfRx[grfRx.Row, colRxdId].ToString() : "";
            qty = grfRx[grfRx.Row, colRxQty] != null ? grfRx[grfRx.Row, colRxQty].ToString() : "";
            include = grfRx[grfRx.Row, colRxInclude] != null ? grfRx[grfRx.Row, colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
            if (cboLangSticker.Text.Equals("English"))
            {
                usage = grfRx[grfRx.Row, colRxUsE] != null ? grfRx[grfRx.Row, colRxUsE].ToString().Equals("True") ? "1" : "0" : "0";
            }
            else
            {
                usage = grfRx[grfRx.Row, colRxUsT] != null ? grfRx[grfRx.Row, colRxUsT].ToString().Equals("True") ? "1" : "0" : "0";
            }
            //sep.Clear();
            if (include.Equals("1"))
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage);
            }
            else
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage);
            }

            setGrfOrder(txtVnOld.Text);
            //}
            //ic.ivfDB.PxAdd(drugid,)
        }
        private void setGrfRx()
        {
            //grfDept.Rows.Count = 7;
            //grfRx.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectBySockDrug1();

            grfRx.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRx.DataSource = dt;
            grfRx.Cols.Count = 9;
            CellStyle cs = grfRx.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRx.Cols[colRxName].Width = 300;
            grfRx.Cols[colRxInclude].Width = 60;
            grfRx.Cols[colRxPrice].Width = 80;
            grfRx.Cols[colRxRemark].Width = 100;
            grfRx.Cols[colRxUsE].Width = 200;
            grfRx.Cols[colRxUsT].Width = 200;
            grfRx.Cols[colRxQty].Width = 60;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRx.Cols[colRxName].Caption = "Name";
            grfRx.Cols[colRxInclude].Caption = "Include";
            grfRx.Cols[colRxPrice].Caption = "Price";
            grfRx.Cols[colRxQty].Caption = "QTY";
            grfRx.Cols[colRxRemark].Caption = "Remark";
            grfRx.Cols[colRxUsE].Caption = "Usage English";
            grfRx.Cols[colRxUsT].Caption = "Usage Thai";

            CellRange rg = grfRx.GetCellRange(2, colBlInclude, grfRx.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfRx.Styles["bool"];
            int i = 1;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    grfRx[i,colBlId] = row["DUID"].ToString();
                    grfRx[i, colRxName] = row["DUName"].ToString();
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfRx[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRx[i, colRxQty] = "1";
                    grfRx[i, colBlRemark] = "";
                    grfRx[i, colRxUsE] = row["EUsage"].ToString();
                    grfRx[i, colRxUsT] = row["TUsage"].ToString();
                    //Row row1 = grfRx.Rows.Add();
                    //row1[colBlId] = row["DUID"].ToString();
                    //row1[colBlName] = row["DUName"].ToString();
                    //row1[colBlPrice] = row["Price"].ToString();
                    //row1[colBlRemark] = "";
                    //if (i == 1) continue;
                    //if (i == 2) continue;
                    grfRx[i, 0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
            grfRx.Cols[colBlId].Visible = false;
            grfRx.Cols[colBlRemark].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;
            FilterRowUnBound fr = new FilterRowUnBound(grfRx);
            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = true;
            grfRx.AllowFiltering = true;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfSpecialLab()
        {
            grfSpecial = new C1FlexGrid();
            grfSpecial.Font = fEdit;
            grfSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpecial.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfSpecial);

            grfSpecial.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_se_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSpecial.ContextMenu = menuGw;
            pnSpecial.Controls.Add(grfSpecial);

            theme1.SetTheme(grfSpecial, "Office2010Barbie");

        }
        private void ContextMenu_order_se_set(object sender, System.EventArgs e)
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "","", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "","", grfOrder.Rows.Count.ToString());
            }
                
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSpecial()
        {
            //grfDept.Rows.Count = 7;
            grfSpecial.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem1();

            grfSpecial.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfSpecial.DataSource = dt;
            grfSpecial.Cols.Count = 7;
            CellStyle cs = grfSpecial.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSpecial.Cols[colBlName].Width = 320;
            grfSpecial.Cols[colBlInclude].Width = 120;
            grfSpecial.Cols[colBlPrice].Width = 80;
            grfSpecial.Cols[colBlRemark].Width = 100;

            grfSpecial.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSpecial.Cols[colBlName].Caption = "Name";
            grfSpecial.Cols[colBlInclude].Caption = "Include";
            grfSpecial.Cols[colBlPrice].Caption = "Price";
            grfSpecial.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfSpecial.GetCellRange(2, colBlInclude, grfSpecial.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSpecial.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oSItmDB.sitm.Price].ToString(), out aaa);
                    grfSpecial[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSpecial[i, colBlId] = row[ic.ivfDB.oSItmDB.sitm.SID].ToString();
                    grfSpecial[i, colBlName] = row[ic.ivfDB.oSItmDB.sitm.SName].ToString();
                    grfSpecial[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSpecial);
            grfSpecial.Cols[colBlId].Visible = false;
            //grfSpecial.Cols[colBlInclude].Visible = false;
            //grfSpecial.Cols[colBlPrice].Visible = false;

            grfSpecial.Cols[colBlName].AllowEditing = false;
            grfSpecial.Cols[colBlPrice].AllowEditing = false;
            grfSpecial.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfGeneticLab()
        {
            grfGenetic = new C1FlexGrid();
            grfGenetic.Font = fEdit;
            grfGenetic.Dock = System.Windows.Forms.DockStyle.Fill;
            grfGenetic.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfGenetic);

            grfGenetic.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_ge_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfGenetic.ContextMenu = menuGw;
            pnGenetic.Controls.Add(grfGenetic);

            theme1.SetTheme(grfGenetic, "RainerOrange");

        }
        private void ContextMenu_order_ge_set(object sender, System.EventArgs e)
        {
            if (grfGenetic.Row <= 0) return;
            if (grfGenetic[grfGenetic.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfGenetic[grfGenetic.Row, colBlId].ToString();
            include = grfGenetic[grfGenetic.Row, colBlInclude] != null ? grfGenetic[grfGenetic.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfGenetic[grfGenetic.Row, colBlQty] != null ? grfGenetic[grfGenetic.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
                
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfGenetic()
        {
            //grfDept.Rows.Count = 7;
            grfGenetic.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByGeneticLab1();

            grfGenetic.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfGenetic.DataSource = dt;
            grfGenetic.Cols.Count = 7;
            CellStyle cs = grfGenetic.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfGenetic.Cols[colBlName].Width = 320;
            grfGenetic.Cols[colBlInclude].Width = 120;
            grfGenetic.Cols[colBlPrice].Width = 80;
            grfGenetic.Cols[colBlRemark].Width = 100;

            grfGenetic.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfGenetic.Cols[colBlName].Caption = "Name";
            grfGenetic.Cols[colBlInclude].Caption = "Include";
            grfGenetic.Cols[colBlPrice].Caption = "Price";
            grfGenetic.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfGenetic.GetCellRange(2, colBlInclude, grfGenetic.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfGenetic.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfGenetic[i, colBlPrice] = aaa.ToString("#,##0");
                    grfGenetic[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfGenetic[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfGenetic[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfGenetic);
            grfGenetic.Cols[colBlId].Visible = false;
            //grfGenetic.Cols[colBlInclude].Visible = false;
            //grfGenetic.Cols[colBlPrice].Visible = false;

            grfGenetic.Cols[colBlName].AllowEditing = false;
            grfGenetic.Cols[colBlPrice].AllowEditing = false;
            grfGenetic.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfEmbryoLab()
        {
            grfEmbryo = new C1FlexGrid();
            grfEmbryo.Font = fEdit;
            grfEmbryo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEmbryo.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfEmbryo);

            grfEmbryo.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_em_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfEmbryo.ContextMenu = menuGw;
            pnEmbryo.Controls.Add(grfEmbryo);

            theme1.SetTheme(grfEmbryo, "ShinyBlue");

        }
        private void ContextMenu_order_em_set(object sender, System.EventArgs e)
        {
            if (grfEmbryo.Row <= 0) return;
            if (grfEmbryo[grfEmbryo.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfEmbryo[grfEmbryo.Row, colBlId].ToString();
            include = grfEmbryo[grfEmbryo.Row, colBlInclude] != null ? grfEmbryo[grfEmbryo.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfEmbryo[grfEmbryo.Row, colBlQty] != null ? grfEmbryo[grfEmbryo.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfEmbryo()
        {
            //grfDept.Rows.Count = 7;
            grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByEmbryoLab1();

            grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.DataSource = dt;
            grfEmbryo.Cols.Count = 7;
            CellStyle cs = grfEmbryo.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEmbryo.Cols[colBlName].Width = 320;
            grfEmbryo.Cols[colBlInclude].Width = 120;
            grfEmbryo.Cols[colBlPrice].Width = 80;
            grfEmbryo.Cols[colBlRemark].Width = 100;

            grfEmbryo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfEmbryo.Cols[colBlName].Caption = "Name";
            grfEmbryo.Cols[colBlInclude].Caption = "Include";
            grfEmbryo.Cols[colBlPrice].Caption = "Price";
            grfEmbryo.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfEmbryo.GetCellRange(2, colBlInclude, grfEmbryo.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfEmbryo.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfEmbryo[i, colBlPrice] = aaa.ToString("#,##0");
                    grfEmbryo[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfEmbryo[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfEmbryo[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfEmbryo);
            grfEmbryo.Cols[colBlId].Visible = false;
            //grfEmbryo.Cols[colBlInclude].Visible = false;
            //grfEmbryo.Cols[colBlPrice].Visible = false;

            grfEmbryo.Cols[colBlName].AllowEditing = false;
            grfEmbryo.Cols[colBlPrice].AllowEditing = false;
            grfEmbryo.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfSpermLab()
        {
            grfSperm = new C1FlexGrid();
            grfSperm.Font = fEdit;
            grfSperm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSperm.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfSperm);

            grfSperm.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_sp_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSperm.ContextMenu = menuGw;
            pnSperm.Controls.Add(grfSperm);

            theme1.SetTheme(grfSperm, "Office2010Green");

        }
        private void ContextMenu_order_sp_set(object sender, System.EventArgs e)
        {
            if (grfSperm.Row <= 0) return;
            if (grfSperm[grfSperm.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfSperm[grfSperm.Row, colBlId].ToString();
            include = grfSperm[grfSperm.Row, colBlInclude] != null ? grfSperm[grfSperm.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSperm[grfSperm.Row, colBlQty] != null ? grfSperm[grfSperm.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
                
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSperm()
        {
            //grfDept.Rows.Count = 7;
            grfSperm.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectBySpermLab1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSperm.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfSperm.Cols.Count = 7;
            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSperm.Cols[colBlName].Width = 320;
            grfSperm.Cols[colBlInclude].Width = 120;
            grfSperm.Cols[colBlPrice].Width = 80;
            grfSperm.Cols[colBlRemark].Width = 100;

            grfSperm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSperm.Cols[colBlName].Caption = "Name";
            grfSperm.Cols[colBlInclude].Caption = "Include";
            grfSperm.Cols[colBlPrice].Caption = "Price";
            grfSperm.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfSperm.GetCellRange(2, colBlInclude, grfSperm.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfSperm[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSperm[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfSperm[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfSperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSperm);
            grfSperm.Cols[colBlId].Visible = false;
            //grfSperm.Cols[colBlInclude].Visible = false;
            //grfSperm.Cols[colBlPrice].Visible = false;

            grfSperm.Cols[colBlName].AllowEditing = false;
            grfSperm.Cols[colBlPrice].AllowEditing = false;
            grfSperm.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfBloodLab()
        {
            grfBloodLab = new C1FlexGrid();
            grfBloodLab.Font = fEdit;
            grfBloodLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBloodLab.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfBloodLab);

            grfBloodLab.DoubleClick += GrfBloodLab_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBloodLab.ContextMenu = menuGw;
            pnBloodLab.Controls.Add(grfBloodLab);

            theme1.SetTheme(grfBloodLab, "Office2010Red");

        }
        private void ContextMenu_order_bl_set(object sender, System.EventArgs e)
        {
            if (grfBloodLab.Row <= 0) return;
            if (grfBloodLab[grfBloodLab.Row, colBlId] == null) return;
            String labid = "", include="", qty="";
            rowOrder++;
            labid = grfBloodLab[grfBloodLab.Row, colBlId].ToString();
            include = grfBloodLab[grfBloodLab.Row, colBlInclude] != null ? grfBloodLab[grfBloodLab.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfBloodLab[grfBloodLab.Row, colBlQty] != null ? grfBloodLab[grfBloodLab.Row, colBlQty].ToString() : "1" ;
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void GrfBloodLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfBloodLab()
        {
            //grfDept.Rows.Count = 7;
            grfBloodLab.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByBloodLab1();
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grfBloodLab.Cols.Count = 7;
            
            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfBloodLab.Cols[colBlName].Width = 330;
            grfBloodLab.Cols[colBlInclude].Width = 120;
            grfBloodLab.Cols[colBlPrice].Width = 80;
            grfBloodLab.Cols[colBlRemark].Width = 100;
            
            grfBloodLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfBloodLab.Cols[colBlName].Caption = "Name";
            grfBloodLab.Cols[colBlInclude].Caption = "Include";
            grfBloodLab.Cols[colBlPrice].Caption = "Price";
            grfBloodLab.Cols[colBlQty].Caption = "QTY";
            grfBloodLab.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfBloodLab.GetCellRange(2, colBlInclude, grfBloodLab.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];
                        
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfBloodLab[i,colBlPrice] = aaa.ToString("#,##0");
                    grfBloodLab[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfBloodLab[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfBloodLab[i, colBlQty] = "1";

                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfBloodLab);
            grfBloodLab.Cols[colBlId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grfBloodLab.Cols[colBlName].AllowEditing = false;
            grfBloodLab.Cols[colBlPrice].AllowEditing = false;
            grfBloodLab.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void GrfMed_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmNurseAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabDrug;
            tabOrder.SelectedTab = tabBloodLab;
            tcPackage.SelectedTab = tabPkgOrder;
        }
    }
}
