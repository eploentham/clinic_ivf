using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
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
    public partial class FrmStockDrug : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colName = 2, colPrice = 3, colQty = 4;
        int coldID = 1, coldName = 2, coldQty = 3;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfDrug;

        OldStockDrug sdrk;

        String userIdVoid = "";

        public FrmStockDrug(IvfControl x)
        {
            InitializeComponent();
            ic = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

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

            sdrk = new OldStockDrug();
            ic.ivfDB.oStkdDB.setCboUsageE(cboUsageE);
            ic.ivfDB.oStkdDB.setCboUsageT(cboUsageT);
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            initGrfStockDrug();
            setGrfStockDrug();
        }
        private void setStockDrug()
        {
            //ostkD.DUID = "DUID";
            //ostkD.DUName = "DUName";
            //ostkD.EUsage = "EUsage";
            //ostkD.TUsage = "TUsage";
            //ostkD.UnitType = "UnitType";
            //ostkD.Alert = "Alert";
            //ostkD.QTY = "QTY";
            //ostkD.PendingQTY = "PendingQTY";
            //ostkD.Price = "Price";
            //ostkD.active = "active";
            sdrk.DUID = "";
            sdrk.DUID = txtID.Text;
            sdrk.DUName = txtDrgName.Text.Trim();
            sdrk.EUsage = cboUsageE.Text.Trim();
            sdrk.TUsage = cboUsageT.Text.Trim();
            sdrk.UnitType = cboUnit.Text.Trim();
            sdrk.Price = txtPrice1.Text;
            sdrk.Alert = txtPurchase.Text.Trim();
            sdrk.trade_name = txtDrgTrade.Text.Trim();
            sdrk.comm_name = txtDrgComm.Text.Trim();
            sdrk.cust_id = cboCust.SelectedItem == null ? "" : ((ComboBoxItem)cboCust.SelectedItem).Value;
            //sdrk.status_doctor = chkStatusDoctor.Checked == true ? "1" : "0";
            //sdrk.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            decimal price = 0;
            if(!Decimal.TryParse(txtPrice1.Text, out price))
            {
                MessageBox.Show("ราคายา ไม่ถูกต้อง", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setStockDrug();
                String re = ic.ivfDB.oStkdDB.insertStockDrug(sdrk, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfStockDrug();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtDrgName.Value = "";
            txtRemark.Value = "";
            //ComboBoxItem item = new ComboBoxItem();
            //item.Value = "";
            //item.Text = "";
            cboUsageE.Value = "";
            cboUsageT.Value = "";
            txtTMT.Value = "";
            txtDrgComm.Value = "";
            txtDrgTrade.Value = "";
            cboFreqT.Value = "";
            cboFreqE.Value = "";
            cboIndiT.Value = "";
            cboIndiE.Value = "";
            cboWarnT.Value = "";
            cboWarnE.Value = "";
            cboPrepT.Value = "";
            cboPrepE.Value = "";
            txtPrice3.Value = "";
            txtPrice2.Value = "";
            txtPrice1.Value = "";
            cboUnit.Value = "";
            txtPurchase.Value = "";
        }

        private void setControl(String posiId)
        {
            sdrk = ic.ivfDB.oStkdDB.selectByPk1(posiId);
            txtID.Value = sdrk.DUID;
            txtDrgName.Value = sdrk.DUName;
            txtRemark.Value = sdrk.remark;
            ic.setC1ComboByName(cboUsageE, sdrk.EUsage);
            ic.setC1ComboByName(cboUsageT, sdrk.TUsage);
            //cboUsageE.Text = sdrk.EUsage;
            //cboUsageT.Text = sdrk.TUsage;
            txtPurchase.Value = sdrk.Alert;
            txtPrice1.Value = sdrk.Price;
            txtDrgCode.Value = sdrk.DUID;
            txtDrgTrade.Value = sdrk.trade_name;
            txtDrgComm.Value = sdrk.comm_name;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtDrgCode.Enabled = flag;
            txtDrgName.Enabled = flag;
            txtRemark.Enabled = flag;
            tC.Enabled = flag;
            //panel4.Enabled = flag;            
        }
        private void initGrfStockDrug()
        {
            grfDrug = new C1FlexGrid();
            grfDrug.Font = fEdit;
            grfDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDrug.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfDrug.AfterRowColChange += GrfPkg_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfDrug);
            FilterRow fr = new FilterRow(grfDrug);
            grfDrug.AllowFiltering = true;
            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDrug, theme);
        }
        private void GrfPkg_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String id = "";
            id = grfDrug[grfDrug.Row, colID] != null ? grfDrug[grfDrug.Row, colID].ToString() : "";
            setControl(id);
        }
        private void setGrfStockDrug()
        {
            //grfDept.Rows.Count = 7;

            grfDrug.DataSource = ic.ivfDB.oStkdDB.selectAll1();
            grfDrug.Cols.Count = 5;

            grfDrug.Cols[colID].Width = 80;

            grfDrug.Cols[colPrice].Width = 80;
            grfDrug.Cols[colName].Width = 440;

            grfDrug.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDrug.Cols[colID].Caption = "รหัส";
            grfDrug.Cols[colName].Caption = "ชื่อPackage";
            grfDrug.Cols[colPrice].Caption = "ราคา";
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfDrug.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    grfDrug.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfDrug.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
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
        private void FrmStockDrug_Load(object sender, EventArgs e)
        {
            sCMain.HeaderHeight = 0;
            tC.SelectedTab = tabDrug1;
        }
    }
}
