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
        int colID = 1, colCode = 3, colName = 2, colPrice = 4;

        C1FlexGrid grfPkg;

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

            initGrfPkg();
            setGrfPkg();
        }
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

        }

        private void setGrfPkg()
        {
            //grfDept.Rows.Count = 7;

            grfPkg.DataSource = ic.ivfDB.oPkgDB.selectAll();
            grfPkg.Cols.Count = 5;

            grfPkg.Cols[colID].Width = 80;

            grfPkg.Cols[colPrice].Width = 80;
            grfPkg.Cols[colName].Width = 300;

            grfPkg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPkg.Cols[colID].Caption = "รหัส";
            grfPkg.Cols[colName].Caption = "ชื่อPackage";
            grfPkg.Cols[colPrice].Caption = "ราคา";
                        
            for (int i = 1; i < grfPkg.Rows.Count; i++)
            {
                grfPkg[i, 0] = i;
                if (i % 2 == 0)
                    grfPkg.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfPkg.Cols[colCode].Visible = false;
            //grfAgn.Cols[colE].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmPackage_Load(object sender, EventArgs e)
        {

        }
    }
}
