using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
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
    public partial class FrmPackage : Form
    {
        IvfControl ic;
        OldPackageHeader oPkg;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colName = 2, colPrice = 3, colQty=4;
        int coldID = 1, coldName = 2, coldQty = 3;

        C1FlexGrid grfPkg, grfPkgD, grfDrug, grfLab, grfSe;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";

        public FrmPackage(IvfControl x)
        {
            InitializeComponent();
            ic = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            oPkg = new OldPackageHeader();

            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnEdit.Click += BtnEdit_Click;
            //cboGrp.SelectedIndexChanged += CboGrp_SelectedIndexChanged;
            

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            sB1.Text = "";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            //ic.setCboPkgGrp(cboGrp);

            initGrfPkg();
            initGrfPkgD();
            initGrfDrug();
            initGrfSe();
            initGrfLab();
            setGrfPkg();
            setGrfLab();
            setGrfSe();
            setGrfDrug();
        }

        //private void CboGrp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    ic.ivfDB.oLabiDB.setCboLabItem(cboItm, "");
        //}

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setPackage();
                String re = ic.ivfDB.oPkgDB.insertPackageHeader(oPkg, ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    ic.ivfDB.oAgnDB.getlAgent();
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfPkg();
                setControlEnable(false);
                //this.Dispose();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtPkgName.Value = "";
            txtPkgPrice.Value = "";
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void setControl(String posiId)
        {
            oPkg = ic.ivfDB.oPkgDB.selectByPk1(posiId);
            txtID.Value = oPkg.PCKID;
            txtPkgName.Value = oPkg.PackageName;
            txtPkgPrice.Value = oPkg.Price;
            setGrfPkgD(txtID.Text);
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtPkgName.Enabled = flag;
            txtPkgPrice.Enabled = flag;
            //panel4.Enabled = flag;            
        }
        private void setPackage()
        {
            oPkg.PCKID = txtID.Text;
            oPkg.PackageName = txtPkgName.Text;
            oPkg.Price = txtPkgPrice.Text;
            
        }
        private void initGrfDrug()
        {
            grfDrug = new C1FlexGrid();
            grfDrug.Font = fEdit;
            grfDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDrug.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfDrug.AfterRowColChange += GrfDrug_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel10.Controls.Add(this.grfDrug);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDrug, theme);
        }

        private void GrfDrug_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (grfDrug.Row < 0) return;
            
            String id = "", name = "";
            id = grfDrug[grfDrug.Row, colID] != null ? grfDrug[grfDrug.Row, colID].ToString() : "";
            name = grfDrug[grfDrug.Row, colName] != null ? grfDrug[grfDrug.Row, colName].ToString() : "";
            txtDrugId.Value = id;
            txtDrugName.Value = name;
        }

        private void setGrfDrug()
        {
            //grfDept.Rows.Count = 7;

            grfDrug.DataSource = ic.ivfDB.oStkdDB.selectAll1();
            grfDrug.Cols.Count = 5;

            grfDrug.Cols[colID].Width = 80;

            grfDrug.Cols[colPrice].Width = 80;
            grfDrug.Cols[colName].Width = 380;

            grfDrug.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDrug.Cols[colID].Caption = "รหัส";
            grfDrug.Cols[colName].Caption = "ชื่อ DRUG";
            grfDrug.Cols[colPrice].Caption = "ราคา";

            for (int i = 1; i < grfDrug.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfDrug[i, 0] = i;
                if (i % 2 == 0)
                    grfDrug.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfDrug.Cols[colID].Visible = false;
            grfDrug.Cols[colQty].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfSe()
        {
            grfSe = new C1FlexGrid();
            grfSe.Font = fEdit;
            grfSe.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSe.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfSe.AfterRowColChange += GrfSe_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel9.Controls.Add(this.grfSe);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfSe, theme);
        }

        private void GrfSe_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (grfSe.Row < 0) return;

            String id = "", name = "";
            id = grfSe[grfSe.Row, colID] != null ? grfSe[grfSe.Row, colID].ToString() : "";
            name = grfSe[grfSe.Row, colName] != null ? grfSe[grfSe.Row, colName].ToString() : "";
            txtSeId.Value = id;
            txtSeName.Value = name;
        }

        private void setGrfSe()
        {
            //grfDept.Rows.Count = 7;

            grfSe.DataSource = ic.ivfDB.oSItmDB.selectAll1();
            grfSe.Cols.Count = 5;

            grfSe.Cols[colID].Width = 80;

            grfSe.Cols[colPrice].Width = 80;
            grfSe.Cols[colName].Width = 380;

            grfSe.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSe.Cols[colID].Caption = "รหัส";
            grfSe.Cols[colName].Caption = "ชื่อ Speicl Item";
            grfSe.Cols[colPrice].Caption = "ราคา";

            for (int i = 1; i < grfSe.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfSe[i, 0] = i;
                if (i % 2 == 0)
                    grfSe.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfSe.Cols[colID].Visible = false;
            grfSe.Cols[colQty].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfLab()
        {
            grfLab = new C1FlexGrid();
            grfLab.Font = fEdit;
            grfLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfLab.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfLab.AfterRowColChange += GrfLab_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel8.Controls.Add(this.grfLab);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfLab, theme);
        }

        private void GrfLab_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (grfLab.Row < 0) return;

            String id = "", name = "";
            id = grfLab[grfLab.Row, colID] != null ? grfLab[grfLab.Row, colID].ToString() : "";
            name = grfLab[grfLab.Row, colName] != null ? grfLab[grfLab.Row, colName].ToString() : "";
            txtLabId.Value = id;
            txtLabName.Value = name;
        }

        private void setGrfLab()
        {
            //grfDept.Rows.Count = 7;

            grfLab.DataSource = ic.ivfDB.oLabiDB.selectAll1();
            grfLab.Cols.Count = 5;

            grfLab.Cols[colID].Width = 80;

            grfLab.Cols[colPrice].Width = 80;
            grfLab.Cols[colName].Width = 380;

            grfLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfLab.Cols[colID].Caption = "รหัส";
            grfLab.Cols[colName].Caption = "ชื่อ LAB";
            grfLab.Cols[colPrice].Caption = "ราคา";

            for (int i = 1; i < grfLab.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfLab[i, 0] = i;
                if (i % 2 == 0)
                    grfLab.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfLab.Cols[colID].Visible = false;
            grfLab.Cols[colQty].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfPkgD()
        {
            grfPkgD = new C1FlexGrid();
            grfPkgD.Font = fEdit;
            grfPkgD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPkgD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfPkgD.AfterRowColChange += GrfPkg_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel11.Controls.Add(this.grfPkgD);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfPkgD, theme);
        }
        private void setGrfPkgD(String pkgid)
        {
            //grfDept.Rows.Count = 7;

            grfPkgD.DataSource = ic.ivfDB.oPkgdDB.selectByPkgId1(pkgid);
            grfPkgD.Cols.Count = 4;

            grfPkgD.Cols[coldID].Width = 80;

            grfPkgD.Cols[coldQty].Width = 80;
            grfPkgD.Cols[coldName].Width = 300;

            grfPkgD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPkgD.Cols[coldID].Caption = "รหัส";
            grfPkgD.Cols[coldName].Caption = "ชื่อ Item";
            grfPkgD.Cols[coldQty].Caption = "QTY";

            for (int i = 1; i < grfPkgD.Rows.Count; i++)
            {
                grfPkgD[i, 0] = i;
                if (i % 2 == 0)
                    grfPkgD.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfPkgD.Cols[coldID].Visible = false;
            //grfPkgD.Cols[coldName].Visible = false;
            //grfPkgD.Cols[colID].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfPkg()
        {
            grfPkg = new C1FlexGrid();
            grfPkg.Font = fEdit;
            grfPkg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPkg.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfPkg.AfterRowColChange += GrfPkg_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfPkg);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfPkg, theme);
        }

        private void GrfPkg_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String id = "";
            id = grfPkg[grfPkg.Row, colID] != null ? grfPkg[grfPkg.Row, colID].ToString() : "";
            setControl(id);
        }

        private void setGrfPkg()
        {
            //grfDept.Rows.Count = 7;

            grfPkg.DataSource = ic.ivfDB.oPkgDB.selectAll();
            grfPkg.Cols.Count = 5;

            grfPkg.Cols[colID].Width = 80;

            grfPkg.Cols[colPrice].Width = 80;
            grfPkg.Cols[colName].Width = 440;

            grfPkg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPkg.Cols[colID].Caption = "รหัส";
            grfPkg.Cols[colName].Caption = "ชื่อPackage";
            grfPkg.Cols[colPrice].Caption = "ราคา";
            
            for (int i = 1; i < grfPkg.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfPkg[i, 0] = i;
                if (i % 2 == 0)
                    grfPkg.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfPkg.Cols[colID].Visible = false;
            grfPkg.Cols[colQty].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmPackage_Load(object sender, EventArgs e)
        {
            tCItem.SelectedTab = tabDrug;
        }
    }
}
