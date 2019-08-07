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
        Color color;
        Font ff, ffB;
        int colID = 1, colName = 2, colSubName = 4, colPrice=3;
        int colInId = 1, colInValMin = 2, colInCriMin = 3, colInxx=4, colInCriMax=5, colInValMax=6, colInInterpret=7, colInEdit=8;

        C1FlexGrid grfLab, grfInt;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        OldLabItem labI;
        String theme2 = "Office2007Blue";
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
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            

            bg = txtLabName.BackColor;
            fc = txtLabName.ForeColor;
            ff = txtLabName.Font;
            ic.ivfDB.olabgDB.setCboBloodGroup(cboLabGroup, "");
            ic.ivfDB.lbuDB.setCboLabUnit(cboUnit, "");
            ic.ivfDB.lbmDB.setCboLabMethod(cboMethod, "");
            //ic.ivfDB.lbDtDB.setCboLabDataTypeComboBox(cboDataTypeCbo, "");

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnDataTypePlus.Click += BtnDataTypePlus_Click;
            chkInterpretCbo.Click += ChkInterpretCbo_Click;
            chkInterpretText.Click += ChkInterpretText_Click;
            btnInterpretPlus.Click += BtnInterpretPlus_Click;
            btnInterpretMinus.Click += BtnInterpretMinus_Click;
            btnInterpretSave.Click += BtnInterpretSave_Click;

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

        private void BtnInterpretSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "", edit = "",re="", xx="";
            
            foreach(Row row in grfInt.Rows)
            {
                String min = "", max = "", interpret="";
                xx = row[colInxx] != null ? row[colInxx].ToString() : "";
                id = row[colInId] != null ? row[colInId].ToString() : "";
                edit = row[colInEdit] != null ? row[colInEdit].ToString() : "";
                if (xx.Equals("Value")) continue;
                if (!edit.Equals("1")) continue;
                min = row[colInValMin] != null ? row[colInValMin].ToString() : "";
                max = row[colInValMax] != null ? row[colInValMax].ToString() : "";
                interpret = row[colInInterpret] != null ? row[colInInterpret].ToString() : "";
                //String re = "";
                LabInterpretComboBox lbM = new LabInterpretComboBox();                

                lbM.active = "";
                lbM.date_cancel = "";
                lbM.date_create = "";
                lbM.date_modi = "";
                lbM.user_cancel = "";
                lbM.user_create = "";
                lbM.user_modi = "";
                lbM.remark = "";
                lbM.sort1 = "";

                lbM.interpret_combobox_id = id;
                lbM.interpret_combobox_name = "";
                lbM.lab_id = txtID.Text;
                lbM.min_value = min;
                lbM.max_value = max;
                lbM.min_value_criteria = "";
                lbM.max_value_criteria = "";
                lbM.interpret = interpret;
                re = ic.ivfDB.lbinDB.insertLabInterpretComboBox(lbM, "");
            }
        }

        private void BtnInterpretMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "", edit="";
            id = grfInt[grfInt.Row, colInId].ToString();
            edit = grfInt[grfInt.Row, colInEdit].ToString();
            if (MessageBox.Show("ต้องการ ลบข้อมูล  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                re = ic.ivfDB.lbinDB.voidLabInterPret(id, "");
                setGrfInterpret();
            }
        }

        private void BtnInterpretPlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfIntAddRow();
        }

        private void ChkInterpretText_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlEnableInterpret(false);
        }

        private void ChkInterpretCbo_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlEnableInterpret(true);
            setGrfInterpret();
        }

        private void BtnDataTypePlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LabDataTypeComboBox lbM = new LabDataTypeComboBox();

            lbM.active = "";
            lbM.date_cancel = "";
            lbM.date_create = "";
            lbM.date_modi = "";
            lbM.user_cancel = "";
            lbM.user_create = "";
            lbM.user_modi = "";
            lbM.remark = "";
            lbM.sort1 = "";
            lbM.lab_id = txtID.Text;

            lbM.datatype_combobox_id = cboDataTypeCbo.SelectedItem == null ? "" : ((ComboBoxItem)cboDataTypeCbo.SelectedItem).Value;
            lbM.datatype_combobox_name = cboDataTypeCbo.Text;
            lbM.status_datatype = "1";
            if (cboDataTypeCbo.Text.Equals(""))
            {
                MessageBox.Show("ไม่พบข้อมูล data type", "");
                return;
            }
            String re = "";
            long chk = 0;
            re = ic.ivfDB.lbDtDB.insertLabDataTypeComboBox(lbM, "");
            if(long.TryParse(re, out chk))
            {
                cboDataTypeCbo.Items.Clear();
                ic.ivfDB.lbDtDB.setCboLabDataTypeComboBox(cboDataTypeCbo, "", txtID.Text);
            }
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
            grfInt.ChangeEdit += GrfInt_ChangeEdit;
            //FilterRow fr = new FilterRow(grfPosi);                        

            gbInterpret.Controls.Add(this.grfInt);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfInt, theme);
        }

        private void GrfInt_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfInt[grfInt.Row, colInEdit] = "1";

            grfInt.Rows[grfInt.Row].StyleNew.BackColor = color;
        }

        private void setGrfInterpret()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbinDB.selectAll(txtID.Text);
            grfInt.DataSource = null;
            grfInt.Cols.Count = 9;
            grfInt.Rows.Count = 1;

            //C1TextBox txt = new C1TextBox();
            //grfInt.Cols[colName].Editor = txt;
            //grfInt.Cols[colID].Width = 60;

            //C1ComboBox cboMin = new C1ComboBox();
            //cboMin.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cboMin.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBoxItem item = new ComboBoxItem();
            //item = new ComboBoxItem();
            //item.Value = ">";
            //item.Text = ">";
            //cboMin.Items.Add(item);
            //item = new ComboBoxItem();
            //item.Value = ">=";
            //item.Text = ">=";
            //cboMin.Items.Add(item);

            //grfInt.Cols[colRsMethod].Editor = cboMethod;
            //grfPosi.Cols[colCode].Width = 80;
            grfInt.Cols[colInValMin].Width = 65;
            grfInt.Cols[colInValMax].Width = 65;
            grfInt.Cols[colInCriMin].Width = 65;
            grfInt.Cols[colInCriMax].Width = 65;
            grfInt.Cols[colInxx].Width = 65;
            grfInt.Cols[colInInterpret].Width = 80;

            grfInt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfInt.Cols[colInValMin].Caption = "Value Min";
            grfInt.Cols[colInCriMin].Caption = "เงื่อนไข";
            grfInt.Cols[colInCriMax].Caption = "เงื่อนไข";
            grfInt.Cols[colInValMax].Caption = "Value Max";
            grfInt.Cols[colInInterpret].Caption = "Interpret";
            grfInt.Cols[colInxx].Caption = "Value";

            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grfPosi.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfIntAddRow();
                row[colInId] = dt.Rows[i][ic.ivfDB.lbinDB.lbM.interpret_combobox_id].ToString();
                row[colInValMin] = dt.Rows[i][ic.ivfDB.lbinDB.lbM.min_value].ToString();
                row[colInValMax] = dt.Rows[i][ic.ivfDB.lbinDB.lbM.max_value].ToString();
                row[colInInterpret] = dt.Rows[i][ic.ivfDB.lbinDB.lbM.interpret].ToString();
                row[0] = (i + 1);
                if (i % 2 != 0)
                    grfLab.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            if (grfInt.Rows.Count <= 1) grfIntAddRow();

            grfInt.Cols[colInId].Visible = false;
            grfInt.Cols[colInCriMin].AllowEditing = false;
            grfInt.Cols[colInCriMax].AllowEditing = false;
            grfInt.Cols[colInxx].AllowEditing = false;
            //grfInt.Cols[colInCriMin].AllowEditing = false;
            grfInt.Cols[colInEdit].Visible = false;
        }
        private Row grfIntAddRow()
        {
            Row row = grfInt.Rows.Add();
            row[colInValMin] = "";
            row[colInCriMin] = ">=";
            row[colInCriMax] = "<";
            row[colInValMax] = "";
            row[colInxx] = "x";
            row[colInInterpret] = "";
            row[colInEdit] = "";
            return row;
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

            cboDataTypeCbo.Items.Clear();
            if (labI.status_datatype_result.Equals("4"))
            {
                ic.ivfDB.lbDtDB.setCboLabDataTypeComboBox(cboDataTypeCbo, "", txtID.Text);
            }
            chkInterpretText.Checked = labI.status_interpret.Equals("0") ? true : false;
            chkInterpretCbo.Checked = labI.status_interpret.Equals("1") ? true : false;
            if (chkInterpretCbo.Checked)
            {
                setControlEnableInterpret(true);
                setGrfInterpret();
            }
            else
            {
                setControlEnableInterpret(false);
            }
        }
        private void setControlEnableInterpret(Boolean flag)
        {
            gbInterpret.Visible = flag;
            btnInterpretPlus.Visible = flag;
            btnInterpretMinus.Visible = flag;
            btnInterpretSave.Visible = flag;
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
            labI.status_interpret = chkInterpretText.Checked ? "0" : chkInterpretCbo.Checked ? "1" : "0";
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
            theme1.SetTheme(panel2, theme2);
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, theme2);
            }
            
        }
    }
}
