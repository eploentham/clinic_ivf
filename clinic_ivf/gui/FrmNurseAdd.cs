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
        String pttId = "", webcamname = "", vsid = "";
        Patient ptt;
        VisitOld vsOld;
        PatientOld pttOld;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder, grfPackage, grfPackageD, grfRxSetD;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colBlId = 1, colBlName = 2, colBlInclude = 4, colBlPrice = 3, colBlRemark=5;
        int colPkgdId = 1, colPkgId = 2, colPkgType = 3, colPkgItmName = 4, colPkgItmId = 5, colPkgQty = 6;
        int colRxdId = 1, colRxId = 2, colRxItmId = 3, colRxName = 4, colRxQty = 5;

        int colOrderId = 1, colOrderVn = 2, colOrderLID = 3, colOrderExtra = 4, colOrderPrice = 5, colOrderStatus=6;
        int colOrderPID = 7, colOrderPIDS = 8, colOrderLName = 9, colOrderSP1V = 10, colOrderSP2V = 11, colOrderSP3V = 12;
        int colOrderSP4V = 13, colOrderSP5V = 14, colOrderSP6V = 15, colOrderSP7V = 16, colOrderSubItem = 17;
        int colOrderFileName = 18, colOrderWorder1 = 19, colOrderWorker2 = 20, colOrderWorker3 = 21, colOrderWorkder4 = 22;
        int colOrderWorker5 = 23, colOrderLGID = 24, colOrderQTY = 25, colOrderActive = 26;

        public FrmNurseAdd(IvfControl ic, String pttid, String vsid)
        {
            InitializeComponent();
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
            ptt = new Patient();
            pttOld = new PatientOld();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            tabOrder.Click += TabOrder_Click;
            btnPkgOrder.Click += BtnPkgOrder_Click;

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

        private void BtnPkgOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRxSetD.Rows.Count > 0)
            {
                String gdid = "";
                gdid = grfRxSet[grfRxSet.Row, colBlId].ToString();
                ic.ivfDB.PxSetAdd(gdid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "");
                setGrfOrder(txtVnOld.Text);
            }
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

        private void setControl(String vsid)
        {
            vsOld = ic.ivfDB.vsOldDB.selectByPk1(vsid);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            ptt.patient_birthday = pttOld.DateOfBirth;
            txtHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtPttName.Value = vsOld.PName;
            txtDob.Value = ic.datetoShow(pttOld.DateOfBirth) + " ["+ptt.AgeStringShort()+"]";
            txtAllergy.Value = pttOld.Allergy;
            txtIdOld.Value = pttOld.PID;
            txtVnOld.Value = vsOld.VN;
            //txtBg.Value = pttOld.b
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            //grfPackageD.AfterRowColChange += GrfPackageD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "GreenHouse");

        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dt = new DataTable();
            DataTable dts = new DataTable();
            DataTable dtpx = new DataTable();
            dt = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dts = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
                                                                                 
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            
            foreach (DataRow row in dt.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = "";
                row1["qty"] = row["QTY"];
                row1["status"] = "bloodlab";
                dtAll.Rows.InsertAt(row1, dt.Rows.Count);               
                
            }
            foreach (DataRow row in dts.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["lgid"] = row["SID"];
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = "";
                row1["status"] = "specialitem";
                dtAll.Rows.InsertAt(row1, dt.Rows.Count);

            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["lgid"] = row["DUID"];
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                dtAll.Rows.InsertAt(row1, dt.Rows.Count);

            }
            grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
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

            grfOrder.Cols[3].Caption = "Name";
            grfOrder.Cols[4].Caption = "Price";
            grfOrder.Cols[5].Caption = "QTY";
            //grfOrder.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfOrder[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[1].Visible = false;
            grfOrder.Cols[2].Visible = false;
            grfOrder.Cols[5].Visible = false;
            //grfOrder.Cols[colOrderExtra].Visible = false;
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

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfPackage.DataSource = dt;
            grfPackage.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPackage.Cols[colBlName].Editor = txt;
            grfPackage.Cols[colBlInclude].Editor = txt;
            grfPackage.Cols[colBlPrice].Editor = txt;
            grfPackage.Cols[colBlRemark].Editor = txt;

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

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfPackage.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
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

            FilterRow fr = new FilterRow(grfPackage);

            grfPackage.AfterRowColChange += GrfPackage_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPackage.ContextMenu = menuGw;
            pnPackage.Controls.Add(grfPackage);

            theme1.SetTheme(grfPackage, "GreenHouse");

        }

        private void GrfPackage_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPackage.Row < 0) return;
            if (grfPackage[grfPackage.Row, colBlId]==null) return;

            String id = "";
            id = grfPackage[grfPackage.Row, colBlId].ToString();
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
            dt = ic.ivfDB.oGudDB.selectByGdId(id);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfRxSetD.DataSource = dt;
            grfRxSetD.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfRxSetD.Cols[colRxName].Editor = txt;
            grfRxSetD.Cols[colRxItmId].Editor = txt;
            grfRxSetD.Cols[colRxQty].Editor = txt;
            grfRxSetD.Cols[colRxId].Editor = txt;

            grfRxSetD.Cols[colRxName].Width = 220;
            grfRxSetD.Cols[colRxQty].Width = 80;
            //grfRxSetD.Cols[colBlPrice].Width = 80;
            //grfRxSetD.Cols[colBlRemark].Width = 100;

            grfRxSetD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSetD.Cols[colRxName].Caption = "Name";
            grfRxSetD.Cols[colRxQty].Caption = "QTY";
            //grfRxSetD.Cols[colBlPrice].Caption = "QTY";
            //grfRxSetD.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfRxSetD[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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

            FilterRow fr = new FilterRow(grfRxSet);

            grfRxSet.AfterRowColChange += GrfRxSet_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSet.ContextMenu = menuGw;
            pnRxSet.Controls.Add(grfRxSet);

            theme1.SetTheme(grfRxSet, "Office2016DarkGray");

        }

        private void GrfRxSet_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRxSet.Row < 0) return;
            if (grfRxSet[grfRxSet.Row, colBlId] == null) return;
            btnPkgOrder.Enabled = false;
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
            grfRxSet.Cols.Count = 6;
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
                    if (i == 2) continue;
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

            FilterRow fr = new FilterRow(grfRx);

            grfRx.AfterRowColChange += GrfMed_AfterRowColChange;
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
        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            String chk = "", name = "", drugid = "";
            drugid = grfRx[grfRx.Row, colBlId] != null ? grfRx[grfRx.Row, colBlId].ToString() : "";

        }
        private void setGrfRx()
        {
            //grfDept.Rows.Count = 7;
            grfRx.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectBySockDrug1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfRx.DataSource = dt;
            grfRx.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfRx.Cols[colBlName].Editor = txt;
            grfRx.Cols[colBlInclude].Editor = txt;
            grfRx.Cols[colBlPrice].Editor = txt;
            grfRx.Cols[colBlRemark].Editor = txt;

            grfRx.Cols[colBlName].Width = 320;
            grfRx.Cols[colBlInclude].Width = 120;
            grfRx.Cols[colBlPrice].Width = 80;
            grfRx.Cols[colBlRemark].Width = 100;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRx.Cols[colBlName].Caption = "Name";
            grfRx.Cols[colBlInclude].Caption = "Include";
            grfRx.Cols[colBlPrice].Caption = "Price";
            grfRx.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfRx.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
            grfRx.Cols[colBlId].Visible = false;
            grfRx.Cols[colBlInclude].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;

            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = false;
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
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSpecial.ContextMenu = menuGw;
            pnSpecial.Controls.Add(grfSpecial);

            theme1.SetTheme(grfSpecial, "Office2010Barbie");

        }
        private void setGrfSpecial()
        {
            //grfDept.Rows.Count = 7;
            grfSpecial.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfSpecial.DataSource = dt;
            grfSpecial.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfSpecial.Cols[colBlName].Editor = txt;
            grfSpecial.Cols[colBlInclude].Editor = txt;
            grfSpecial.Cols[colBlPrice].Editor = txt;
            grfSpecial.Cols[colBlRemark].Editor = txt;

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

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfSpecial.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSpecial);
            grfSpecial.Cols[colBlId].Visible = false;
            grfSpecial.Cols[colBlInclude].Visible = false;
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
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfGenetic.ContextMenu = menuGw;
            pnGenetic.Controls.Add(grfGenetic);

            theme1.SetTheme(grfGenetic, "RainerOrange");

        }
        private void setGrfGenetic()
        {
            //grfDept.Rows.Count = 7;
            grfGenetic.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByGeneticLab1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfGenetic.DataSource = dt;
            grfGenetic.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfGenetic.Cols[colBlName].Editor = txt;
            grfGenetic.Cols[colBlInclude].Editor = txt;
            grfGenetic.Cols[colBlPrice].Editor = txt;
            grfGenetic.Cols[colBlRemark].Editor = txt;

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

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfGenetic.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfGenetic);
            grfGenetic.Cols[colBlId].Visible = false;
            grfGenetic.Cols[colBlInclude].Visible = false;
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
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfEmbryo.ContextMenu = menuGw;
            pnEmbryo.Controls.Add(grfEmbryo);

            theme1.SetTheme(grfEmbryo, "ShinyBlue");

        }
        private void setGrfEmbryo()
        {
            //grfDept.Rows.Count = 7;
            grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByEmbryoLab1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfEmbryo.DataSource = dt;
            grfEmbryo.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfEmbryo.Cols[colBlName].Editor = txt;
            grfEmbryo.Cols[colBlInclude].Editor = txt;
            grfEmbryo.Cols[colBlPrice].Editor = txt;
            grfEmbryo.Cols[colBlRemark].Editor = txt;

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

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfEmbryo.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfEmbryo);
            grfEmbryo.Cols[colBlId].Visible = false;
            grfEmbryo.Cols[colBlInclude].Visible = false;
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
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSperm.ContextMenu = menuGw;
            pnSperm.Controls.Add(grfSperm);

            theme1.SetTheme(grfSperm, "Office2010Green");

        }
        private void setGrfSperm()
        {
            //grfDept.Rows.Count = 7;
            grfSperm.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectBySpermLab1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.Rows.Count = dt.Rows.Count + 1;
            grfSperm.DataSource = dt;
            grfSperm.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfSperm.Cols[colBlName].Editor = txt;
            grfSperm.Cols[colBlInclude].Editor = txt;
            grfSperm.Cols[colBlPrice].Editor = txt;
            grfSperm.Cols[colBlRemark].Editor = txt;

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

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfSperm.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSperm);
            grfSperm.Cols[colBlId].Visible = false;
            grfSperm.Cols[colBlInclude].Visible = false;
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

            grfBloodLab.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBloodLab.ContextMenu = menuGw;
            pnBloodLab.Controls.Add(grfBloodLab);

            theme1.SetTheme(grfBloodLab, "Office2010Red");

        }
        private void setGrfBloodLab()
        {
            //grfDept.Rows.Count = 7;
            grfBloodLab.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByBloodLab1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfBloodLab.DataSource = dt;
            grfBloodLab.Cols.Count = 6;
            C1TextBox txt = new C1TextBox();
            C1TextBox num = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            num.FormatType = FormatTypeEnum.Currency;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfBloodLab.Cols[colBlName].Editor = txt;
            grfBloodLab.Cols[colBlInclude].Editor = txt;
            grfBloodLab.Cols[colBlPrice].Editor = num;
            grfBloodLab.Cols[colBlRemark].Editor = txt;

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
            grfBloodLab.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfBloodLab.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    if (i == 2) continue;
                    row[0] = (i-2);
                    //decimal aaa = 0;
                    //Decimal.TryParse(row[colBlPrice].ToString(), out aaa);
                    //row[colBlPrice] = aaa.ToString("#,##0");
                    //grfBloodLab[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    //grfBloodLab[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    ////grfBloodLab[i, colBlInclude] = false;
                    //grfBloodLab[i, colBlQty] = row[ic.ivfDB.oLabiDB.labI.QTY].ToString();
                    //grfBloodLab[i, colBlRemark] = "";

                    //if (row[ic.ivfDB.vsDB.vs.visit_have_appointment].ToString().Equals("1"))
                    //{
                    //    String txt1 = "";
                    //    txt1 = "นัดวันที่  " + ic.datetoShow(row["patient_appointment_date"].ToString()) + " " + row["patient_appointment_time"].ToString() + " " + row["patient_appointment"].ToString();
                    //    CellNote note = new CellNote(txt1);
                    //    CellRange rg = grfBloodLab.GetCellRange(i, colVN);
                    //    rg.UserData = note;
                    //}
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;

                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfBloodLab);
            grfBloodLab.Cols[colBlId].Visible = false;
            grfBloodLab.Cols[colBlInclude].Visible = false;
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
        }
    }
}
