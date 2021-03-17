using C1.C1Pdf;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmDoctorTemplateDrug:Form
    {
        IvfControl ic;
        Font fEdit, fEditB, fEdit3B, fEdit5B;
        C1DockingTab tcMain;

        C1DockingTabPage tabDeposit;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1PdfDocument pdfDoc;
        C1ThemeController theme1;
        C1Button btnSave, btnNew;
        C1FlexGrid grfDrug;

        Label lbcboDrugName, lbtxtRemark, lbtxtQty, lbtxtThai, lbtxtEng, lbtxtDtrName, lbcboTempDrugName;
        C1TextBox txtRemark, txtQty, txtThai, txtEng, txtDtrName, txtTempDrugName, txtId;
        C1ComboBox cboDrugName, cboTempDrugName;
        Staff stf;
        int coltempname = 1, colDrugName = 2, colQty=3, colThai = 4, colEng = 5,colId = 6, colStfId = 7, colDrugId=8;
        Boolean pageLoad = false;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        public FrmDoctorTemplateDrug(IvfControl ic)
        {
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            theme1 = new C1ThemeController();
            theme1.Theme = ic.iniC.themeApplication;
            sep = new C1SuperErrorProvider();
            stt = new C1SuperTooltip();

            stf = new Staff();
            stf = ic.ivfDB.stfDB.selectByPk1(ic.userId);

            initCompoment();
            setControl();
            setGrfTemplateDrug(ic.userId,"", grfDrug);

            ic.ivfDB.oStkdDB.setCboStockDrug(cboDrugName,"");
            ic.ivfDB.tdrugDB.setCboUsageT(cboTempDrugName, stf.staff_id);

            this.Load += FrmDoctorTemplateDrug_Load;
            cboDrugName.SelectedItemChanged += CboDrugName_SelectedItemChanged;
            btnSave.Click += BtnSave_Click;
            cboTempDrugName.SelectedItemChanged += CboTempDrugName_SelectedItemChanged;
            grfDrug.DoubleClick += GrfDrug_DoubleClick;
            btnNew.Click += BtnNew_Click;
            cboTempDrugName.KeyPress += CboTempDrugName_KeyPress;
            cboDrugName.KeyPress += CboDrugName_KeyPress;
            txtQty.KeyPress += TxtQty_KeyPress;
            txtEng.KeyPress += TxtEng_KeyPress;
            txtThai.KeyPress += TxtThai_KeyPress;

            pageLoad = false;
        }

        private void TxtThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            sep.Clear();
            stt.Hide();
        }

        private void TxtEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            sep.Clear();
            stt.Hide();
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            sep.Clear();
            stt.Hide();
        }

        private void CboDrugName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            sep.Clear();
            stt.Hide();
        }

        private void CboTempDrugName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            sep.Clear();
            stt.Hide();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtId.Value = "";
            txtThai.Value = "";
            txtEng.Value = "";
            txtQty.Value = "";
            txtRemark.Value = "";
            ic.setC1Combo(cboDrugName, "");
        }
        private void GrfDrug_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            if (grfDrug.Row < 0) return;
            if (grfDrug.Col < 0) return;

            String tempdrugid = "";
            tempdrugid = grfDrug[grfDrug.Row, colId].ToString();
            setControlTemplateDrug(tempdrugid);
        }

        private void CboTempDrugName_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            sep.Clear();
            stt.Hide();

            String tempdrugname = "";

            tempdrugname = cboTempDrugName.SelectedItem == null ? "" : ((ComboBoxItem)cboTempDrugName.SelectedItem).Value;
            setGrfTemplateDrug(ic.userId, tempdrugname, grfDrug);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Decimal qty = 0;
            if (cboTempDrugName.Text.Trim().Length <= 0)
            {
                //MessageBox.Show
                sep.SetError(cboTempDrugName, "Error");
                stt.Show("ไม่มี ชื่อ Template", cboTempDrugName);
                return;
            }
            if (cboDrugName.Text.Trim().Length <= 0)
            {
                sep.SetError(cboDrugName, "Error");
                stt.Show("ไม่มี ชื่อ Drug", cboDrugName);
                return;
            }
            if(!decimal.TryParse(txtQty.Text.Trim(), out qty) && qty <=0)
            {
                sep.SetError(txtQty, "Error");
                stt.Show("QTY error", txtQty);
                return;
            }
            if (txtEng.Text.Trim().Length <= 0)
            {
                sep.SetError(txtEng, "Error");
                stt.Show("English error", txtEng);
                return;
            }
            if (txtThai.Text.Trim().Length <= 0)
            {
                sep.SetError(txtThai, "Error");
                stt.Show("Thai error", txtThai);
                return;
            }
            TemplateDrug tdrug = new TemplateDrug();
            tdrug = setTemplateDrug();
            if (tdrug.temp_drug_id != null)
            {
                String re = ic.ivfDB.tdrugDB.insertTemplateDrug(tdrug, ic.userId);
                txtId.Value = re;
                setGrfTemplateDrug(stf.staff_id, cboTempDrugName.Text, grfDrug);
                ic.ivfDB.tdrugDB.setCboUsageT(cboTempDrugName, "");
                txtId.Value = "";
                txtThai.Value = "";
                txtEng.Value = "";
                txtQty.Value = "0";
                txtRemark.Value = "";
                cboDrugName.Text = "";
            }
        }
        private TemplateDrug setTemplateDrug()
        {
            TemplateDrug tdrug = new TemplateDrug();
            decimal qty = 0;
            decimal.TryParse(txtQty.Text.Trim(), out qty);
            if (qty > 0)
            {
                tdrug.temp_drug_id = txtId.Text.Trim();
                tdrug.active = "1";
                tdrug.drug_id = cboDrugName.SelectedItem == null ? "" : ((ComboBoxItem)cboDrugName.SelectedItem).Value;
                tdrug.qty = qty.ToString();
                tdrug.usage_eng = txtEng.Text.Trim();
                tdrug.usage_thai = txtThai.Text.Trim();
                tdrug.temp_drug_name = cboTempDrugName.Text;
                tdrug.staff_id = stf.staff_id;
            }
            return tdrug;
        }
        private void CboDrugName_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            String drugid = "";
            sep.Clear();
            stt.Hide();

            drugid = cboDrugName.SelectedItem == null ? "" : ((ComboBoxItem)cboDrugName.SelectedItem).Value;
            setControlDrug(drugid);
        }
        private void setControlTemplateDrug(String tempdrugid)
        {
            pageLoad = true;
            TemplateDrug tdrug = new TemplateDrug();
            tdrug = ic.ivfDB.tdrugDB.selectByPk(tempdrugid);

            txtId.Value = tdrug.temp_drug_id;
            txtThai.Value = tdrug.usage_thai;
            txtEng.Value = tdrug.usage_eng;
            txtQty.Value = tdrug.qty;
            txtRemark.Value = tdrug.remark;
            ic.setC1Combo(cboDrugName, tdrug.drug_id);
            pageLoad = false;
        }
        private void setControlDrug(String drugid)
        {
            OldStockDrug ostkD = new OldStockDrug();
            ostkD = ic.ivfDB.oStkdDB.selectByPk1(drugid);
            txtThai.Value = ostkD.TUsage;
            txtEng.Value = ostkD.EUsage;
            txtQty.Value = "0";
            txtRemark.Value = ostkD.remark;
        }
        private void setControl()
        {
            txtDtrName.Value = stf.name_full;
        }
        private void initCompoment()
        {
            int gapLine = 25, gapX = 20, gapY = 20, xCol2 = 150, xCol1 = 80, xCol3 = 330, xCol4 = 640, xCol5 = 950;
            Size size = new Size();

            tcMain = new C1DockingTab();
            tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tcMain.Location = new System.Drawing.Point(0, 266);
            tcMain.Name = "tcMain";
            //tcMain.Size = new System.Drawing.Size(669, 200);
            tcMain.TabIndex = 0;
            tcMain.TabsSpacing = 5;
            tcMain.ShowCaption = false;

            tabDeposit = new C1DockingTabPage();
            tabDeposit.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabDeposit.Size = new System.Drawing.Size(667, 175);
            tabDeposit.TabIndex = 0;
            tabDeposit.Text = "Template Drug";
            tabDeposit.Name = "tabDeposit";
            tcMain.Controls.Add(tabDeposit);

            lbcboDrugName = new Label();
            lbtxtRemark = new Label();
            lbtxtQty = new Label();
            lbtxtThai = new Label();
            lbtxtEng = new Label();
            lbtxtDtrName = new Label();
            txtRemark = new C1TextBox();
            txtQty = new C1TextBox();
            txtThai = new C1TextBox();
            txtEng = new C1TextBox();
            txtDtrName = new C1TextBox();
            cboDrugName = new C1ComboBox();
            lbcboTempDrugName = new Label();
            txtTempDrugName = new C1TextBox();
            txtId = new C1TextBox();
            cboTempDrugName = new C1ComboBox();

            btnNew = new C1Button();
            btnSave = new C1Button();

            ic.setControlLabel(ref lbcboTempDrugName, fEdit, "Template Name :", "lbtxtTempDrugName", gapX, gapY);
            //ic.setControlC1TextBox(ref txtTempDrugName, fEdit, "txtTempDrugName", 400, xCol2, gapY);
            ic.setControlC1ComboBox(ref cboTempDrugName, fEdit, "cboTempDrugName", 400, xCol2, gapY);
            gapY += gapLine;
            ic.setControlLabel(ref lbtxtDtrName, fEdit, "Doctor Name :", "lbtxtDtrName", gapX, gapY);
            ic.setControlC1TextBox(ref txtDtrName, fEdit, "txtDtrName", 400, xCol2, gapY);
            gapY += gapLine;
            ic.setControlLabel(ref lbcboDrugName, fEdit, "Drug Name :", "lbcboDrugName", gapX, gapY);
            ic.setControlC1ComboBox(ref cboDrugName, "cboDrugName", 400, xCol2, gapY);
            cboDrugName.Font = fEdit;

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtRemark, fEdit, "Remark :", "lbtxtRemark", gapX, gapY);
            ic.setControlC1TextBox(ref txtRemark, fEdit, "txtRemark", 400, xCol2, gapY);
            ic.setControlC1Button(ref btnNew, fEdit, "New", "btnNew", xCol4, gapY -10);
            btnNew.Width = 70;

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtThai, fEdit, "Thai :", "lbtxtThai", gapX, gapY);
            ic.setControlC1TextBox(ref txtThai, fEdit, "txtThai", 600, xCol2, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtEng, fEdit, "English :", "lbtxtEng", gapX, gapY);
            ic.setControlC1TextBox(ref txtEng, fEdit, "txtEng", 600, xCol2, gapY);
            

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtQty, fEdit, "QTY :", "lbtxtQty", gapX, gapY);
            ic.setControlC1TextBox(ref txtQty, fEdit, "txtQty", 80, xCol2, gapY);
            txtQty.DataType = typeof(decimal);

            ic.setControlC1Button(ref btnSave, fEdit, "Save", "btnSave", xCol4, gapY);
            btnSave.Width = 70;

            grfDrug = new C1FlexGrid();
            grfDrug.Name = "grfDeposit";
            grfDrug.Font = fEdit;
            grfDrug.Dock = System.Windows.Forms.DockStyle.Bottom;
            grfDrug.Location = new System.Drawing.Point(0, 0);
            grfDrug.Rows.Count = 1;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Void Drug", new EventHandler(ContextMenu_void_drug));
            grfDrug.ContextMenu = menuGw;

            tabDeposit.Controls.Add(lbtxtDtrName);
            tabDeposit.Controls.Add(txtDtrName);

            tabDeposit.Controls.Add(lbcboDrugName);
            tabDeposit.Controls.Add(cboDrugName);
            tabDeposit.Controls.Add(lbtxtRemark);
            tabDeposit.Controls.Add(txtRemark);
            tabDeposit.Controls.Add(lbtxtThai);
            tabDeposit.Controls.Add(txtThai);
            tabDeposit.Controls.Add(lbtxtEng);
            tabDeposit.Controls.Add(txtEng);
            tabDeposit.Controls.Add(lbtxtQty);
            tabDeposit.Controls.Add(txtQty);
            tabDeposit.Controls.Add(btnSave);
            tabDeposit.Controls.Add(lbcboTempDrugName);
            tabDeposit.Controls.Add(cboTempDrugName);
            tabDeposit.Controls.Add(btnNew);

            tabDeposit.Controls.Add(grfDrug);

            this.Controls.Add(tcMain);

            theme1.SetTheme(lbcboDrugName, ic.theme);
            theme1.SetTheme(txtEng, ic.theme);


            Action<Control> setTheme = null;
            setTheme = (c) =>
            {
                if (C1.Win.C1Themes.C1ThemeController.IsObjectThemeable(c))
                    this.theme1.SetTheme(c, "Office2010Blue");
                foreach (Control cc in c.Controls)
                    setTheme(cc);
            };
            setTheme(this);

        }
        private void ContextMenu_void_drug(object sender, System.EventArgs e)
        {
            String drug = "", id="";
            drug = grfDrug[grfDrug.Row, colDrugName] != null ? grfDrug[grfDrug.Row, colDrugName].ToString() : "";
            id = grfDrug[grfDrug.Row, colId] != null ? grfDrug[grfDrug.Row, colId].ToString() : "";
            if (MessageBox.Show("void item template drug \n" + "Drug " + drug, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                String re = ic.ivfDB.tdrugDB.voidTemplateDrug(id, ic.userId);
                setGrfTemplateDrug(ic.userId, cboTempDrugName.Text, grfDrug);
            }
        }
        private void setGrfTemplateDrug(String dtrid, String tempdrugname, C1FlexGrid grf)
        {
            DataTable dt = new DataTable();
            grf.Rows.Count = 1;
            grf.Cols.Count = 9;
            
            dt = ic.ivfDB.tdrugDB.selectByDtrId(dtrid, tempdrugname);

            grf.Rows.Count = dt.Rows.Count + 1;
            grf.Cols[coltempname].Width = 100;
            grf.Cols[colDrugName].Width = 300;
            grf.Cols[colQty].Width = 60;
            grf.Cols[colThai].Width = 300;
            grf.Cols[colEng].Width = 300;

            grf.Cols[coltempname].Caption = "Template";
            grf.Cols[colDrugName].Caption = "Drug Name";
            grf.Cols[colQty].Caption = "QTY";
            grf.Cols[colThai].Caption = "Thai";
            grf.Cols[colEng].Caption = "English";
            
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Receive operation", new EventHandler(ContextMenu_order_finish));
            //grf.ContextMenu = menuGw;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grf[i, 0] = i;
                grf[i, colId] = row["temp_drug_id"].ToString();
                grf[i, coltempname] = row["temp_drug_name"].ToString();
                grf[i, colDrugName] = row["DUName"].ToString();
                grf[i, colQty] = row["qty"].ToString();
                grf[i, colThai] = row["usage_thai"].ToString();
                grf[i, colEng] = row["usage_eng"].ToString();
                grf[i, colStfId] = row["staff_id"].ToString();
                grf[i, colDrugId] = row["drug_id"].ToString();

                i++;
            }
            grf.Cols[colId].Visible = false;
            grf.Cols[colStfId].Visible = false;

            grf.Cols[coltempname].AllowEditing = false;
            grf.Cols[colDrugName].AllowEditing = false;
            grf.Cols[colQty].AllowEditing = false;
            grf.Cols[colThai].AllowEditing = false;
            grf.Cols[colEng].AllowEditing = false;
            
        }
        private void FrmDoctorTemplateDrug_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Size = new Size(900, 900);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Top = 100;
            this.Left = this.Left - 200;

            grfDrug.Height = this.Height - 300;
            grfDrug.Top = 190;
        }
    }
}
