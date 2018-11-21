using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
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
    public partial class FrmLabOPUAdd : Form
    {
        IvfControl ic;
        String reqId = "", opuId="";
        LabRequest lbReq;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3, colDesc2=4, colDesc3=5;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabOPUAdd(IvfControl ic, String reqid, String opuid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            opuId = opuid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");                       

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.OPUProcedure);
            ic.setCboDay(CboEmbryoDay, "");

            setControl();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            
            btnSave.Click += BtnSave_Click;

            setFocusColor();
            initGrfDay2();
            initGrfDay3();
            initGrfDay5();
            initGrfDay6();
            setGrfDay2();
            setGrfDay3();
            setGrfDay5();
            setGrfDay6();
        }
        private void setFocusColor()
        {
            this.txtHnFeMale.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHnFeMale.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtPosiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtPosiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setControl()
        {
            if (!reqId.Equals(""))
            {
                lbReq = ic.ivfDB.lbReqDB.selectByPk1(reqId);

                txtHnFeMale.Value = lbReq.hn_female;
                txtHnMale.Value = lbReq.hn_male;
                txtNameFeMale.Value = lbReq.name_female;
                txtNameMale.Value = lbReq.name_male;
                txtLabReqCode.Value = lbReq.req_code;
            }
            else
            {

            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //setDeptment();
                //String re = ic.ivfDB.posiDB.insertPosition(posi, ic.user.staff_id);
                //int chk = 0;
                //if (int.TryParse(re, out chk))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //setGrfPosi();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void initGrfDay2()
        {
            grfDay2 = new C1FlexGrid();
            grfDay2.Font = fEdit;
            grfDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay2.ContextMenu = menuGw;
            gbDay2.Controls.Add(grfDay2);

            theme1.SetTheme(grfDay2, "Office2010Blue");
        }
        private void initGrfDay6()
        {
            grfDay6 = new C1FlexGrid();
            grfDay6.Font = fEdit;
            grfDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay6.ContextMenu = menuGw;
            gbDay6.Controls.Add(grfDay6);

            theme1.SetTheme(grfDay6, "Office2010Blue");
        }
        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay3.ContextMenu = menuGw;
            gbDay3.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, "Office2010Silver");
        }
        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            gbDay5.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Red");
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }
        private void setGrfDay2()
        {
            //grfDept.Rows.Count = 7;
            grfDay2.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay2.Rows.Count = 41;
            grfDay2.Cols.Count = 64;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfDay2.Cols[colID].Editor = txt;
            grfDay2.Cols[colNum].Editor = txt;
            grfDay2.Cols[colDesc].Editor = txt;

            grfDay2.Cols[colNum].Width = 40;
            grfDay2.Cols[colDesc].Width = 150;

            grfDay2.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay2.Cols[colNum].Caption = "no";
            grfDay2.Cols[colDesc].Caption = "desc";
            grfDay2.Cols[colDesc2].Caption = "desc2";
            grfDay2.Cols[colDesc3].Caption = "desc3";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay2.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay2[i, 0] = i;
            }
            grfDay2.Cols[colNum].Visible = false;
        }
        private void setGrfDay3()
        {
            //grfDept.Rows.Count = 7;
            grfDay3.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay3.Rows.Count = 41;
            grfDay3.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay3.Cols[colID].Editor = txt;
            grfDay3.Cols[colNum].Editor = txt;
            grfDay3.Cols[colDesc].Editor = txt;

            grfDay3.Cols[colNum].Width = 40;
            grfDay3.Cols[colDesc].Width = 150;

            grfDay3.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay3.Cols[colNum].Caption = "no";
            grfDay3.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay3.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay3[i, 0] = i;
            }
            grfDay3.Cols[colNum].Visible = false;
        }
        private void setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay5.Rows.Count = 41;
            grfDay5.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay5.Cols[colID].Editor = txt;
            grfDay5.Cols[colNum].Editor = txt;
            grfDay5.Cols[colDesc].Editor = txt;

            grfDay5.Cols[colNum].Width = 40;
            grfDay5.Cols[colDesc].Width = 150;

            grfDay5.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay5.Cols[colNum].Caption = "no";
            grfDay5.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay5.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay5[i, 0] = i;
            }
            grfDay5.Cols[colNum].Visible = false;
        }
        private void setGrfDay6()
        {
            //grfDept.Rows.Count = 7;
            grfDay6.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay6.Rows.Count = 41;
            grfDay6.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay6.Cols[colID].Editor = txt;
            grfDay6.Cols[colNum].Editor = txt;
            grfDay6.Cols[colDesc].Editor = txt;

            grfDay6.Cols[colNum].Width = 40;
            grfDay6.Cols[colDesc].Width = 150;

            grfDay6.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay6.Cols[colNum].Caption = "no";
            grfDay6.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay6.Cols[colID].Visible = false;
            for(int i = 1; i <= 40; i++)
            {
                grfDay6[i, 0] = i;
            }
            grfDay6.Cols[colNum].Visible = false;
        }
        private void FrmLabOPUAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
