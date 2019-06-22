
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;

namespace clinic_ivf.gui
{
    public partial class FrmStaff : Form
    {
        Staff stf;
        IvfControl ic;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colCode=2, colNameT = 3, colMobile = 4, colEmail = 5, colPosiName=6, colDept=7, colRemark=8, colPid=9;
        int colCnt = 8;

        C1FlexGrid grfStf;
        //Boolean flagNew = false;
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmStaff(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();

            //bg = txtStfCode.BackColor;
            //fc = txtStfCode.ForeColor;
            ff = txtStfCode.Font;

            ContextMenu custommenu = new ContextMenu();
            custommenu.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_void));
            btnVoid.Click += BtnVoid_Click;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnPasswordCompirm.Click += BtnPasswordCompirm_Click;
            //custommenu.MenuItems.Add("&ยกเลิก";
            //grdView.ContextMenu = custommenu;
            //bg = txtStfCode.BackColor;
            //fc = txtStfCode.ForeColor;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(groupBox1, "Office2013Red");
            theme1.SetTheme(label1, "Office2013Red");
            theme1.SetTheme(txtStfCode, "Office2013Red");
            foreach(Control c in groupBox1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            foreach (Control c in panelModule.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            //theme1.SetTheme(chkAdmin, "Office2013Red");
            //theme1.SetTheme(chkUser, "Office2013Red");
            //theme1.SetTheme(chkExpJob, "Office2013Red");
            //theme1.SetTheme(chkImpJob, "Office2013Red");
            //theme1.SetTheme(chkOtherJob, "Office2013Red");
            bg = txtStfCode.BackColor;
            fc = txtStfCode.ForeColor;
            setFocusColor();
            initGrfStfH();
            setGrfStfH();
            setFocusColor();
            setFocus();
            cboPrefix = ic.ivfDB.fpfDB.setCboPrefix(cboPrefix);
            
            ic.ivfDB.posiDB.setC1CboPosi(cboPosi);
            ic.ivfDB.deptDB.setC1CboDept(cboDept);
            setControlEnable(false);
            btnVoid.Hide();
            btnPassword.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnPasswordCompirm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.stfID = txtID.Text;
            FrmSetPassword frm = new FrmSetPassword(ic, FrmSetPassword.StatusPassword.confirm);
            frm.ShowDialog(this);
        }

        private void ContextMenu_void(object sender, System.EventArgs e)
        {
            //FarPoint.Win.Spread.Row row = grdView.ActiveSheet.ActiveRow;
            //FarPoint.Win.Spread.Column c;
            //c = grdView.ActiveSheet.ActiveColumn;
            //String aa = grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colCode].Value.ToString();
            //if (MessageBox.Show("ต้องการ ยกเลิก \nรายการ" + aa, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //    String re = xC.ivfDB.banDB.voidBank(grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value == null ? "" : grdView.Sheets[0].Cells[grdView.ActiveSheet.ActiveRow.Index, colID].Value.ToString());
            //    if (re.Equals("1"))
            //    {
            //        grdView.Sheets[grdView.ActiveSheet.SheetName].Cells[grdView.ActiveSheet.ActiveRow.Index, 0, grdView.ActiveSheet.ActiveRow.Index, colCnt - 1].BackColor = Color.Gray;
            //    }
            //}
        }
        private void initGrfStfH()
        {
            grfStf = new C1FlexGrid();
            grfStf.Font = fEdit;
            grfStf.Dock = System.Windows.Forms.DockStyle.Fill;
            grfStf.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfStf);

            grfStf.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.StatusBar_AfterDataRefresh);
            grfStf.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfStf_CellChanged);
            grfStf.LeaveCell += new System.EventHandler(this.grfStf_LeaveCell);
            grfStf.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfStf_AfterRowColChange);
            //this.grfCus.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfCus_AfterRowColChange);
            //new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGrid1_AfterRowColChange);
            //splitContainer1.Panel1.Controls.Add(this.grfCus);
            panel2.Controls.Add(this.grfStf);
            //grfCus.ShowThemedHeaders = ShowThemedHeadersEnum.None;
            //grfCus.Styles.Clear();
            //Mac(grfCus.Styles);
            //Controls.Add(sB);
            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfStf, theme);
        }
        private void setGrfStfH()
        {
            DataTable dt = new DataTable();

            dt = ic.ivfDB.stfDB.selectAll1();
            //grfCus.Cols.Count = 2;
            //grfCus.Rows.Count = 7;
            grfStf.DataSource = dt;
            grfStf.Cols[colID].Width = 60;
            grfStf.Cols[colCode].Width = 80;
            grfStf.Cols[colNameT].Width = 100;
            grfStf.Cols[colMobile].Width = 100;
            grfStf.Cols[colEmail].Width = 100;
            grfStf.Cols[colPosiName].Width = 100;
            grfStf.Cols[colDept].Width = 100;
            grfStf.Cols[colRemark].Width = 100;
            grfStf.Cols[colPid].Width = 100;
            
            grfStf.ShowCursor = true;
            grfStf.Cols[colCode].Caption = "รหัส";
            grfStf.Cols[colID].Caption = "รก";
            grfStf.Cols[colNameT].Caption = "ชื่อ นามสกุล";
            grfStf.Cols[colMobile].Caption = "มือถือ";
            grfStf.Cols[colEmail].Caption = "email";
            grfStf.Cols[colPosiName].Caption = "ตำแหน่ง";
            grfStf.Cols[colDept].Caption = "แผนก";
            grfStf.Cols[colRemark].Caption = "หมายเหตุ";
            grfStf.Cols[colPid].Caption = "ID";
            //grfStf.Cols[colcontact2].Caption = "ชื่อผู้ติดต่อ2";
            grfStf.Cols[colID].Visible = false;
            for (int i = 1; i < grfStf.Rows.Count; i++)
            {
                grfStf[i, 0] = i;
                if (i % 2 == 0)
                    grfStf.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            //grfCus.Col = colCnt;
        }
        private void setControlEnable(Boolean flag)
        {
            txtStfCode.Enabled = flag;
            txtStfFNameT.Enabled = flag;
            txtStfFNameE.Enabled = flag;
            txtEmail.Enabled = flag;
            txtStfLNameT.Enabled = flag;
            txtStfLNameE.Enabled = flag;
            txtMobile.Enabled = flag;
            txtPid.Enabled = flag;
            txtTele.Enabled = flag;
            txtRemark.Enabled = flag;
            txtLogo.Enabled = flag;
            cboPrefix.Enabled = flag;
            cboDept.Enabled = flag;
            cboPosi.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
            btnPassword.Enabled = flag;
            btnLogoPath.Enabled = flag;
            btnLogoView.Enabled = flag;
            btnPosiAdd.Enabled = flag;
            btnDeptAdd.Enabled = flag;
            txtUserName.Enabled = flag;
            panelAdmin.Enabled = flag;
            panelModule.Enabled = flag;
            chkVoid.Enabled = flag;
            btnPasswordCompirm.Enabled = flag;
        }
        void StatusBar_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            int cnt = grfStf.Rows.Count - grfStf.Rows.Fixed;
            sB.Text = cnt.ToString() + " rows in data source";
        }
        private void grfStf_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            sB.Text = grfStf.Rows[e.Row].ToString();
        }
        private void grfStf_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            String aaa = "";
            sB1.Text = e.NewRange.r1.ToString();
            if (e.NewRange.Data == null) return;
            sB1.Text = e.NewRange.Data.ToString();
            String cusId = "";
            cusId = grfStf[e.NewRange.r1, colID] != null ? grfStf[e.NewRange.r1, colID].ToString() : "";
            setControl(cusId);
            flagEdit = false;
            setControlEnable(flagEdit);
            //setGrfAddrH(cusId);
            //setGrfContH(cusId);
            //setGrfRmkH(cusId);
            //setGrfTaxH(cusId);
            //setControlEdit(false);
            //chkVoid.Show();
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
                //btnVoid.Show();
            }
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = ic.ivfDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length>0)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            setControlEnable(true);
            btnPassword.Hide();

            txtID.Value = "";
            txtStfCode.Value = "";
            txtStfFNameT.Value = "";
            txtStfFNameE.Value = "";
            txtEmail.Value = "";
            txtStfLNameT.Value = "";
            txtStfLNameE.Value = "";
            txtMobile.Value = "";
            txtPid.Value = "";
            txtTele.Value = "";
            txtRemark.Value = "";
            txtUserName.Value = "";
            txtLogo.Value = "";
            cboPrefix.Text = "";
            cboDept.Text = "";
            cboPosi.Text = "";
            chkUser.Checked = true;
            chkAdmin.Checked = false;
            txtDoctorId.Value = "";
            chkStfDoctor.Checked = false;
        }

        private void btnLogoPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog res = new OpenFileDialog();
            //res.Filter = "Excel Files|*.xls;";
            res.Filter = "All Files|*.*;";
            if (res.ShowDialog() == DialogResult.OK)
            {
                //Get the file's path
                txtLogo.Text = res.FileName;
                //Do something
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            ic.stfID = txtID.Text;
            FrmSetPassword frm = new FrmSetPassword(ic, FrmSetPassword.StatusPassword.login);
            frm.ShowDialog(this);
        }                
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            String deptid = cboDept.SelectedItem == null ? "" : ((ComboBoxItem)cboDept.SelectedItem).Value;
            String posiid = cboPosi.SelectedItem == null ? "" : ((ComboBoxItem)cboPosi.SelectedItem).Value;

            Department dept = ic.ivfDB.deptDB.selectByPk1(deptid);
            Position posi = ic.ivfDB.posiDB.selectByPk1(posiid);

            if (dept.dept_id.Equals(""))
            {
                MessageBox.Show("แผนกไม่ถูกต้อง", "");
                return;
            }
            if (posi.posi_id.Equals(""))
            {
                MessageBox.Show("ตำแหน่งไม่ถูกต้อง", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setStaff();
                String re = ic.ivfDB.stfDB.insertStaff(stf,ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    ic.ivfDB.stfDB.getlStf();
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfStfH();
                setControlEnable(false);
                //this.Dispose();
            }
        }
        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.stfDB.VoidStaff(txtID.Text, userIdVoid);
                setGrfStfH();
            }
        }
        private void grfStf_LeaveCell(object sender, EventArgs e)
        {

        }
        
        //private void setGrdViewH()
        //{
        //    FarPoint.Win.Spread.EnhancedInterfaceRenderer outlinelook = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
        //    outlinelook.RangeGroupBackgroundColor = Color.LightGreen;
        //    outlinelook.RangeGroupButtonBorderColor = Color.Red;
        //    outlinelook.RangeGroupLineColor = Color.Blue;
        //    grdView.InterfaceRenderer = outlinelook;
        //    grdView.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

        //    grdView.BorderStyle = BorderStyle.None;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoFilter = true;
        //    grdView.Sheets[0].Columns[colCode, colRemark].AllowAutoSort = true;
        //    grdView.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

        //    FarPoint.Win.Spread.CellType.TextCellType objTextCell = new FarPoint.Win.Spread.CellType.TextCellType();
        //    FarPoint.Win.Spread.CellType.ButtonCellType buttoncell = new FarPoint.Win.Spread.CellType.ButtonCellType();

        //    grdView.Sheets[0].ColumnCount = colCnt;
        //    grdView.Sheets[0].RowCount = 1;
        //    grdView.Font = fEdit;

        //    grdView.Sheets[0].Columns[colID].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colE].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colS].CellType = buttoncell;
        //    grdView.Sheets[0].Columns[colCode].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colNameT].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colNameE].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[colRemark].CellType = objTextCell;
        //    grdView.Sheets[0].Columns[coledit].CellType = objTextCell;

        //    grdView.Sheets[0].ColumnHeader.Cells[0, colE].Text = "edit";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colS].Text = "save";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colCode].Text = "code";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameT].Text = "ชื่อไทย";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colNameE].Text = "ชื่ออังกฤษ";
        //    grdView.Sheets[0].ColumnHeader.Cells[0, colRemark].Text = "หมายเหตุ";

        //    grdView.Sheets[0].Columns[colE].Width = 50;
        //    grdView.Sheets[0].Columns[colS].Width = 50;
        //    grdView.Sheets[0].Columns[colCode].Width = 80;
        //    grdView.Sheets[0].Columns[colNameT].Width = 200;
        //    grdView.Sheets[0].Columns[colNameE].Width = 200;
        //    grdView.Sheets[0].Columns[colRemark].Width = 200;

        //    grdView.Sheets[0].Columns[colID].Visible = false;
        //    grdView.Sheets[0].Columns[coledit].Visible = false;

        //    grdView.AllowColumnMove = true;
        //}       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }

        //private void grdView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    stf = xC.ivfDB.stfDB.selectByPk1(grdView.Sheets[0].Cells[e.Row, colID].Value == null ? "" : grdView.Sheets[0].Cells[e.Row, colID].Value.ToString());
        //    setControl();
        //    setEnable(false);
        //}

        //private void setGrdView()
        //{
        //    DataTable dt = new DataTable();
        //    int i = 0;
        //    FarPoint.Win.Spread.Column columnobj;
        //    columnobj = grdView.ActiveSheet.Columns[colCode, colRemark];

        //    dt = xC.ivfDB.stfDB.selectAll();
        //    grdView.Sheets[0].Rows.Clear();
        //    setGrdViewH();
        //    grdView.Sheets[0].RowCount = dt.Rows.Count + 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        grdView.Sheets[0].Cells[i, colID].Value = row[xC.ivfDB.stfDB.stf.staff_id] == null ? "" : row[xC.ivfDB.stfDB.stf.staff_id].ToString();
        //        grdView.Sheets[0].Cells[i, colCode].Value = row[xC.ivfDB.stfDB.stf.staff_code].ToString();
        //        grdView.Sheets[0].Cells[i, colNameT].Value = row[xC.ivfDB.stfDB.stf.staff_fname_t].ToString()+" "+ row[xC.ivfDB.stfDB.stf.staff_lname_t].ToString();
        //        grdView.Sheets[0].Cells[i, colNameE].Value = row[xC.ivfDB.stfDB.stf.staff_fname_e].ToString()+" "+ row[xC.ivfDB.stfDB.stf.staff_lname_e].ToString();
        //        grdView.Sheets[0].Cells[i, colRemark].Value = row[xC.ivfDB.stfDB.stf.remark].ToString();

        //        grdView.Sheets[0].Cells[i, coledit].Value = "0";
        //        if (i % 2 != 0)
        //        {
        //            grdView.Sheets[0].Cells[i, 0, i, colCnt - 1].BackColor = System.Drawing.Color.FromArgb(235, 241, 222);
        //        }

        //        columnobj.Locked = true;

        //        i++;
        //    }
        //}
        private void setFocus()
        {
            this.txtStfCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfFNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfFNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfLNameT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtStfLNameE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtPid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);            
            this.txtTele.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);            
            this.txtRemark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            this.txtLogo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                C1TextBox a = (C1TextBox)sender;
                if (a.Name.Equals("txtStfCode"))
                {
                    txtStfFNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtStfFNameT"))
                {
                    txtStfLNameT.Focus();
                    return;
                }
                if (a.Name.Equals("txtStfLNameT"))
                {
                    txtTele.Focus();
                    return;
                }
                if (a.Name.Equals("txtTele"))
                {
                    txtMobile.Focus();
                    return;
                }
                if (a.Name.Equals("txtMobile"))
                {
                    txtEmail.Focus();
                    return;
                }
                if (a.Name.Equals("txtEmail"))
                {
                    txtRemark.Focus();
                    return;
                }
                if (a.Name.Equals("txtRemark"))
                {
                    txtPid.Focus();
                    return;
                }
                if (a.Name.Equals("txtPid"))
                {
                    txtLogo.Focus();
                    return;
                }
                if (a.Name.Equals("txtLogo"))
                {
                    btnSave.Focus();
                    return;
                }
                
            }

            //a.BackColor = Color.DarkCyan;txtZipCode
            //a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtStfCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfLNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfLNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfLNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfLNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfFNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfFNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtStfFNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtStfFNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);            

            this.txtLogo.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLogo.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtTele.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtTele.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboDept.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboDept.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboPosi.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboPosi.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboPrefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboPrefix.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            if (sender is C1TextBox)
            {
                C1TextBox a = (C1TextBox)sender;
                a.BackColor = ic.cTxtFocus;
                a.Font = new Font(ff, FontStyle.Bold);
            }
            else if (sender is ComboBox)
            {
                ComboBox a = (ComboBox)sender;
                a.BackColor = ic.cTxtFocus;
                a.Font = new Font(ff, FontStyle.Bold);
            }

            //a.ForeColor = Color.Black;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (sender is C1TextBox)
            {
                C1TextBox a = (C1TextBox)sender;
                a.BackColor = bg;
                a.ForeColor = fc;
                a.Font = new Font(ff, FontStyle.Regular);
            }
            else if (sender is ComboBox)
            {
                ComboBox a = (ComboBox)sender;
                a.BackColor = bg;
                a.ForeColor = fc;
                a.Font = new Font(ff, FontStyle.Regular);
            }
        }
        private void setControl(String stfId)
        {
            stf = ic.ivfDB.stfDB.selectByPk1(stfId);
            txtID.Value = stf.staff_id;
            txtStfCode.Value = stf.staff_code;
            txtStfFNameT.Value = stf.staff_fname_t;
            txtStfFNameE.Value = stf.staff_fname_e;
            txtEmail.Value = stf.email;
            txtStfLNameT.Value = stf.staff_lname_t;
            txtStfLNameE.Value = stf.staff_lname_e;
            txtMobile.Value = stf.mobile;
            txtPid.Value = stf.pid;
            txtTele.Value = stf.tele;
            txtRemark.Value = stf.remark;
            txtUserName.Value = stf.username;
            txtLogo.Value = stf.logo;
            cboPrefix.Text = stf.prefix_name_t;
            //cboDept.Text = stf.dept_name_t;
            //cboPosi.Text = stf.posi_name_t;
            ic.setC1Combo(cboPosi, stf.posi_id);
            ic.setC1Combo(cboDept, stf.dept_id);
            chkAdmin.Checked = stf.status_admin.Equals("2") ? true : false;
            chkUser.Checked = !stf.status_admin.Equals("2") ? true : false;
            chkReception.Checked = stf.status_module_reception.Equals("1") ? true : false;
            chkNurse.Checked = stf.status_module_nurse.Equals("1") ? true : false;
            chkDoctor.Checked = stf.status_module_doctor.Equals("1") ? true : false;
            chkExpnAppv.Checked = stf.status_expense_appv.Equals("1") ? true : false;
            chkExpnD.Checked = stf.status_expense_draw.Equals("1") ? true : false;
            chkExpnP.Checked = stf.status_expense_pay.Equals("1") ? true : false;
            chkPharmacy.Checked = stf.status_module_pharmacy.Equals("1") ? true : false;
            chkLab.Checked = stf.status_module_lab.Equals("1") ? true : false;
            btnPassword.Show();
            chkCashier.Checked = stf.status_module_cashier.Equals("1") ? true : false;
            chkMedicalRecord.Checked = stf.status_module_medicalrecord.Equals("1") ? true : false;
            chkStfDoctor.Checked = stf.status_doctor.Equals("1") ? true : false;
            txtDoctorId.Value = stf.doctor_id;
            txtDoctorOldId.Value = stf.doctor_id_old;
        }
        private void setStaff()
        {
            stf.staff_id = txtID.Text;
            stf.staff_code = txtStfCode.Text;
            stf.staff_fname_t = txtStfFNameT.Text;
            stf.staff_fname_e = txtStfFNameE.Text;
            stf.email = txtEmail.Text;
            stf.staff_lname_t = txtStfLNameT.Text;
            stf.staff_lname_e = txtStfLNameE.Text;
            stf.mobile = txtMobile.Text;
            stf.pid = txtPid.Text;
            stf.tele = txtTele.Text;
            stf.remark = txtRemark.Text;
            stf.logo = txtLogo.Text;
            stf.username = txtUserName.Text;
            stf.dept_id = cboDept.SelectedItem == null ? "" : ((ComboBoxItem)cboDept.SelectedItem).Value;
            stf.prefix_id = cboPrefix.SelectedItem == null ? "" :  ((ComboBoxItem)cboPrefix.SelectedItem).Value;
            stf.posi_id = cboPosi.SelectedItem == null ? "" : ((ComboBoxItem)cboPosi.SelectedItem).Value;
            stf.status_admin = chkAdmin.Checked ? "1" : "1";
            stf.status_module_reception = chkReception.Checked ? "1" : "0";
            stf.status_module_nurse = chkNurse.Checked ? "1" : "0";
            stf.status_module_doctor = chkDoctor.Checked ? "1" : "0";
            stf.status_expense_appv = chkExpnAppv.Checked ? "1" : "0";
            stf.status_expense_draw = chkExpnD.Checked ? "1" : "0";
            stf.status_expense_pay = chkExpnP.Checked ? "1" : "0";
            stf.status_module_pharmacy = chkPharmacy.Checked ? "1" : "0";
            stf.status_module_lab = chkLab.Checked ? "1" : "0";
            stf.status_module_cashier = chkCashier.Checked ? "1" : "0";
            stf.status_module_medicalrecord = chkMedicalRecord.Checked ? "1" : "0";
            stf.status_doctor = chkStfDoctor.Checked ? "1" : "0";
            stf.doctor_id = txtDoctorId.Text.Equals("") ? "99" : txtDoctorId.Text;
            stf.doctor_id_old = chkStfDoctor.Checked ? txtDoctorOldId.Text : "99";
            //txtCopCode.Value = xC.ivfDB.copDB.cop.comp_id;
        }
        //private void setEnable(Boolean flag)
        //{
        //    txtStfCode.Enabled = flag;
        //    txtID.Enabled = flag;
        //    txtStfFNameT.Enabled = flag;
        //    txtStfFNameE.Enabled = flag;
        //    txtEmail.Enabled = flag;
        //    txtStfLNameT.Enabled = flag;
        //    txtStfLNameE.Enabled = flag;
        //    txtMobile.Enabled = flag;
        //    txtPid.Enabled = flag;
        //    txtTele.Enabled = flag;
        //    txtRemark.Enabled = flag;
        //    txtLogo.Enabled = flag;
            
        //}
        private void FrmStaff_Load(object sender, EventArgs e)
        {

        }
    }
}
