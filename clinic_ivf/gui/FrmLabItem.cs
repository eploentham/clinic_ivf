using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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
    public partial class FrmLabItem : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colName = 2, colSubName = 4, colPrice=3;
        int colInId = 1, colInValMin = 2, colInCri = 3, colInValMax=4, colInInterpret=5;

        C1FlexGrid grfLab, grfInt;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        OldLabItem labI;

        String userIdVoid = "";
        public FrmLabItem(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            labI = new OldLabItem();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtLabName.BackColor;
            fc = txtLabName.ForeColor;
            ff = txtLabName.Font;
            ic.ivfDB.olabgDB.setCboBloodGroup(cboLabGroup, "");
            ic.ivfDB.lbuDB.setCboLabUnit(cboUnit, "");
            ic.ivfDB.lbmDB.setCboLabMethod(cboMethod, "");

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;

            initGrfLabItem();
            setGrfLabItem();
            setControlEnable(false);
            setFocusColor();
            initGrfInterpret();

            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Decimal qty = 0;
            if(!Decimal.TryParse(txtQty.Text, out qty))
            {
                MessageBox.Show("จำนวนไม่ถูกต้อง หรือน้อยกว่า 0", "");
                return;
            }
            
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n"+"รายการ "+txtLabName.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setLabItem();
                String re = ic.ivfDB.oLabiDB.insertLabItem(labI, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfLabItem();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtLabName.Value = "";
            cboLabGroup.Text = "";
            txtPrice.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(true);
        }
        private void initGrfInterpret()
        {
            grfInt = new C1FlexGrid();
            grfInt.Font = fEdit;
            grfInt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfInt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);                        

            panel1.Controls.Add(this.grfInt);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfInt, theme);
        }
        private void setGrfInterpret()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectAll1();
            grfInt.DataSource = null;
            grfInt.Cols.Count = 5;
            grfInt.Rows.Count = 1;

            C1TextBox txt = new C1TextBox();
            grfInt.Cols[colName].Editor = txt;
            grfInt.Cols[colID].Width = 60;

            //grfPosi.Cols[colCode].Width = 80;
            grfInt.Cols[colName].Width = 300;
            grfInt.Cols[colSubName].Width = 300;

            grfInt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfInt.Cols[colInValMin].Caption = "Value Min";
            grfInt.Cols[colInCri].Caption = "เงื่อนไข";
            grfInt.Cols[colInValMax].Caption = "Value Max";
            grfInt.Cols[colInInterpret].Caption = "Interpret";

            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grfPosi.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfInt.Rows.Add();
                row[colInId] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.LID].ToString();
                row[colInValMin] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.LName].ToString();
                row[colInCri] = dt.Rows[i]["LGName"].ToString();
                row[colInValMax] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.Price].ToString();
                row[0] = (i + 1);
                if (i % 2 != 0)
                    grfLab.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }

            grfInt.Cols[colID].Visible = false;
            //grfPosi.Cols[colE].Visible = false;
            //grfPosi.Cols[colS].Visible = false;
        }
        private void initGrfLabItem()
        {
            grfLab = new C1FlexGrid();
            grfLab.Font = fEdit;
            grfLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfLab.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfLab.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfLab.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfLab.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfLab);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfLab, theme);
        }
        private void setGrfLabItem()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectAll1();
            grfLab.DataSource = null;
            grfLab.Cols.Count = 5;
            grfLab.Rows.Count = 1;

            C1TextBox txt = new C1TextBox();
            grfLab.Cols[colName].Editor = txt;
            grfLab.Cols[colID].Width = 60;

            //grfPosi.Cols[colCode].Width = 80;
            grfLab.Cols[colName].Width = 300;
            grfLab.Cols[colSubName].Width = 300;

            grfLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfLab.Cols[colSubName].Caption = "Group";
            grfLab.Cols[colName].Caption = "ชื่อประเภทเอกสารย่อย";
            grfLab.Cols[colPrice].Caption = "ราคา";

            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grfPosi.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfLab.Rows.Add();
                row[colID] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.LID].ToString();
                row[colName] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.LName].ToString();
                row[colSubName] = dt.Rows[i]["LGName"].ToString();
                row[colPrice] = dt.Rows[i][ic.ivfDB.oLabiDB.labI.Price].ToString();
                row[0] = (i + 1);
                if (i % 2 != 0)
                    grfLab.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }

            grfLab.Cols[colID].Visible = false;
            //grfPosi.Cols[colE].Visible = false;
            //grfPosi.Cols[colS].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtLabName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLabName.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String posiId)
        {
            labI = ic.ivfDB.oLabiDB.selectByPk1(posiId);
            ic.setC1Combo(cboLabGroup, labI.LGID);
            txtID.Value = labI.LID;
            txtLabName.Value = labI.LName;
            txtPrice.Value = labI.Price;
            chkShowQty.Checked = labI.status_show_qty.Equals("1") ? true : false;
            chkOutLab.Checked = labI.status_outlab.Equals("1") ? true : false;
            chkOrderGroup.Checked = labI.status_order_group.Equals("1") ? true : false;
            txtNormalValue.Value = labI.normal_vaule;
            ic.setC1Combo(cboUnit, labI.lab_unit_id);
            ic.setC1Combo(cboMethod, labI.method_id);
            txtQty.Value = labI.QTY;

            chkDataTypeText.Checked = labI.status_datatype_result.Equals("1") ? true : false;
            chkDataTypeInt.Checked = labI.status_datatype_result.Equals("2") ? true : false;
            chkDataTypeDec.Checked = labI.status_datatype_result.Equals("3") ? true : false;
            chkDataTypeCbo.Checked = labI.status_datatype_result.Equals("4") ? true : false;

            txtDataTypeDec.Value = labI.datatype_decimal;

        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtLabName.Enabled = flag;
            chkVoid.Enabled = flag;
            txtPrice.Enabled = flag;
            cboLabGroup.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setLabItem()
        {
            labI.LID = txtID.Text;
            labI.LName = txtLabName.Text;
            labI.LGID = cboLabGroup.SelectedItem == null ? "" : ((ComboBoxItem)cboLabGroup.SelectedItem).Value;
            labI.Price = txtPrice.Text;
            labI.status_show_qty = chkShowQty.Checked ? "1" : "0";
            labI.method = cboMethod.Text;
            labI.unit = cboUnit.Text;
            labI.status_outlab = chkOutLab.Checked ? "1" : "0";
            labI.status_order_group = chkOrderGroup.Checked ? "1" : "0";
            labI.normal_vaule = txtNormalValue.Text;
            labI.QTY = txtQty.Text;
            labI.lab_unit_id = cboUnit.SelectedItem == null ? "" : ((ComboBoxItem)cboUnit.SelectedItem).Value;
            labI.method_id = cboMethod.SelectedItem == null ? "" : ((ComboBoxItem)cboMethod.SelectedItem).Value;
            labI.status_datatype_result = chkDataTypeText.Checked ? "1" : chkDataTypeInt.Checked ? "2" : chkDataTypeDec.Checked ? "3" : chkDataTypeCbo.Checked ? "4" : "0";
            labI.datatype_decimal = txtDataTypeDec.Text;
            labI.status_datatype_result = chkDataTypeText.Checked ? "1" : chkDataTypeInt.Checked ? "2" : chkDataTypeDec.Checked ? "3" : chkDataTypeCbo.Checked ? "4" : "0";
            labI.datatype_decimal = txtDataTypeDec.Text;
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfLab[e.NewRange.r1, colID] != null ? grfLab[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfPosi_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfPosi_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == 0) return;
            //CellStyle cs = grfDept.Styles.Add("text");
            //cs.BackColor = Color.DimGray;
            //sB1.Text = grfDept[e.Row, e.Col].ToString();
            ////grfDept[e.Row, coledit] = "1";
            //grfDept.Rows[e.Row].Style = cs;
            //if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            //{
            //    ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            //}
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                //userIdVoid = bc.ivfDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }


        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกข้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //bc.ivfDB.dgsDB.v(txtID.Text, userIdVoid);
                setGrfLabItem();
            }
        }

        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void FrmLabItem_Load(object sender, EventArgs e)
        {
            sCMain.HeaderHeight = 0;
        }
    }
}
