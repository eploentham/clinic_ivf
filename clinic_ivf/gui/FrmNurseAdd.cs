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

        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colBlId = 1, colBlName = 2, colBlInclude = 4, colBlPrice = 3, colBlRemark=5;

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
            setGrfGenetic();
            initGrfSpecialLab();
            setGrfSpecial();
            initGrfRx();
            setGrfRx();
            initGrfRxSet();
            setGrfRxSet();
            initGrfOrder();
            //initGrfPtt();
            //setGrfPtt("");
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
            //txtBg.Value = pttOld.b
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfRx);

            grfOrder.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "Violette");

        }
        private void initGrfRxSet()
        {
            grfRxSet = new C1FlexGrid();
            grfRxSet.Font = fEdit;
            grfRxSet.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSet.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfRxSet);

            grfRxSet.AfterRowColChange += GrfMed_AfterRowColChange;
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
        private void setGrfRxSet()
        {
            //grfDept.Rows.Count = 7;
            grfRxSet.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGrpDb.selectBySockDrug1();

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

            grfRxSet.Cols[colBlName].Width = 220;
            grfRxSet.Cols[colBlInclude].Width = 120;
            grfRxSet.Cols[colBlPrice].Width = 80;
            grfRxSet.Cols[colBlRemark].Width = 100;

            grfRxSet.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSet.Cols[colBlName].Caption = "Name";
            grfRxSet.Cols[colBlInclude].Caption = "Include";
            grfRxSet.Cols[colBlPrice].Caption = "QTY";
            grfRxSet.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfRxSet[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
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
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRx.ContextMenu = menuGw;
            pnRx.Controls.Add(grfRx);

            theme1.SetTheme(grfRx, "Office2010Black");

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

            grfRx.Cols[colBlName].Width = 220;
            grfRx.Cols[colBlInclude].Width = 120;
            grfRx.Cols[colBlPrice].Width = 80;
            grfRx.Cols[colBlRemark].Width = 100;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRx.Cols[colBlName].Caption = "Name";
            grfRx.Cols[colBlInclude].Caption = "Include";
            grfRx.Cols[colBlPrice].Caption = "QTY";
            grfRx.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfRx[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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

            grfSpecial.Cols[colBlName].Width = 220;
            grfSpecial.Cols[colBlInclude].Width = 120;
            grfSpecial.Cols[colBlPrice].Width = 80;
            grfSpecial.Cols[colBlRemark].Width = 100;

            grfSpecial.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSpecial.Cols[colBlName].Caption = "Name";
            grfSpecial.Cols[colBlInclude].Caption = "Include";
            grfSpecial.Cols[colBlPrice].Caption = "QTY";
            grfSpecial.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfSpecial[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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

            grfGenetic.Cols[colBlName].Width = 220;
            grfGenetic.Cols[colBlInclude].Width = 120;
            grfGenetic.Cols[colBlPrice].Width = 80;
            grfGenetic.Cols[colBlRemark].Width = 100;

            grfGenetic.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfGenetic.Cols[colBlName].Caption = "Name";
            grfGenetic.Cols[colBlInclude].Caption = "Include";
            grfGenetic.Cols[colBlPrice].Caption = "QTY";
            grfGenetic.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfGenetic[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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

            grfEmbryo.Cols[colBlName].Width = 220;
            grfEmbryo.Cols[colBlInclude].Width = 120;
            grfEmbryo.Cols[colBlPrice].Width = 80;
            grfEmbryo.Cols[colBlRemark].Width = 100;

            grfEmbryo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfEmbryo.Cols[colBlName].Caption = "Name";
            grfEmbryo.Cols[colBlInclude].Caption = "Include";
            grfEmbryo.Cols[colBlPrice].Caption = "QTY";
            grfEmbryo.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfEmbryo[i, 0] = i;

                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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

            grfSperm.Cols[colBlName].Width = 220;
            grfSperm.Cols[colBlInclude].Width = 120;
            grfSperm.Cols[colBlPrice].Width = 80;
            grfSperm.Cols[colBlRemark].Width = 100;

            grfSperm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSperm.Cols[colBlName].Caption = "Name";
            grfSperm.Cols[colBlInclude].Caption = "Include";
            grfSperm.Cols[colBlPrice].Caption = "QTY";
            grfSperm.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfSperm[i, 0] = i;
                    
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
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
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfBloodLab.Cols[colBlName].Editor = txt;
            grfBloodLab.Cols[colBlInclude].Editor = txt;
            grfBloodLab.Cols[colBlPrice].Editor = txt;
            grfBloodLab.Cols[colBlRemark].Editor = txt;

            grfBloodLab.Cols[colBlName].Width = 220;
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
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfBloodLab[i, 0] = i;
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
                    i++;
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
