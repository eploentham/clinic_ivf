using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1List;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmStockRecView:Form
    {
        IvfControl ic;
        C1FlexGrid grfStk;
        Font fEdit, fEditB;
        Color bg, fc;
        Boolean pageLoad = false;
        Panel pnTop, pnBody;
        C1ThemeController theme1;
        C1Button btnNew;
        Label lbYear, lbStkSubName;
        C1ComboBox cboYear, cboStkSubName;
        MainMenu menu;
        int colRecDoc = 1, colRecDate = 2, colRecRemark = 3;
        public FrmStockRecView(IvfControl ic, MainMenu m)
        {
            this.ic = ic;
            menu = m;
            InitComponent();
            initConfig();
        }
        private void InitComponent()
        {
            int gapY = 30, gapX = 20, gapLine = 5, gapColName = 70;
            Size size = new Size();            
            
            theme1 = new C1ThemeController();
            theme1.Theme = ic.iniC.themeApplication;
            pnTop = new Panel();
            pnTop.Dock = DockStyle.Top;
            pnTop.Size = new Size(20, 60);
            pnBody = new Panel();
            pnBody.Dock = DockStyle.Fill;
            pnTop.SuspendLayout();
            pnBody.SuspendLayout();

            lbYear = new Label();
            lbYear.Text = "Year :";
            lbYear.Font = fEdit;
            lbYear.Location = new System.Drawing.Point(gapX, gapLine);
            lbYear.AutoSize = true;
            lbYear.Name = "lbYear";
            size = ic.MeasureString(lbYear);
            cboYear = new C1ComboBox();
            cboYear.AllowSpinLoop = false;
            cboYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboYear.Font = fEdit;
            cboYear.GapHeight = 0;
            cboYear.ImagePadding = new System.Windows.Forms.Padding(0);
            cboYear.ItemsDisplayMember = "";
            cboYear.ItemsValueMember = "";
            cboYear.Location = new System.Drawing.Point(size.Width+20, lbYear.Location.Y);
            cboYear.Name = "cboYear";
            cboYear.Size = new System.Drawing.Size(184, 20);
            cboYear.TabIndex = 562;
            cboYear.Tag = null;
            theme1.SetTheme(cboYear, "(default)");
            cboYear.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboYear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboYear.Location = new Point(gapColName, lbYear.Location.Y);

            lbStkSubName = new Label();
            lbStkSubName.Text = "รับเข้า :";
            lbStkSubName.Font = fEdit;
            lbStkSubName.Location = new System.Drawing.Point(gapX, lbYear.Location.Y);
            lbStkSubName.AutoSize = true;
            lbStkSubName.Name = "lbStkSubName";
            cboStkSubName = new C1ComboBox();
            cboStkSubName.AllowSpinLoop = false;
            cboStkSubName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboYear.Font = fEdit;
            cboStkSubName.GapHeight = 0;
            cboStkSubName.ImagePadding = new System.Windows.Forms.Padding(0);
            cboStkSubName.ItemsDisplayMember = "";
            cboStkSubName.ItemsValueMember = "";
            cboStkSubName.Location = new System.Drawing.Point(662, lbStkSubName.Location.Y);
            cboStkSubName.Name = "cboStkSubName";
            cboStkSubName.Size = new System.Drawing.Size(400, 20);
            cboStkSubName.TabIndex = 562;
            cboStkSubName.Tag = null;
            theme1.SetTheme(cboStkSubName, "(default)");
            cboStkSubName.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboStkSubName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboStkSubName.Location = new Point(gapColName, lbStkSubName.Location.Y);

            btnNew = new C1Button();
            btnNew.Name = "btnNew";
            btnNew.Text = "Print";
            btnNew.Font = this.fEdit;
            size = ic.MeasureString(btnNew);
            btnNew.Size = new Size(60,40);
            btnNew.Location = new Point(pnBody.Width - size.Width - 40, lbStkSubName.Location.Y);
            btnNew.Click += BtnNew_Click;

            pnTop.Controls.Add(lbYear);
            pnTop.Controls.Add(cboYear);
            pnTop.Controls.Add(lbStkSubName);
            pnTop.Controls.Add(cboStkSubName);
            pnTop.Controls.Add(btnNew);
            this.Controls.Add(pnBody);
            this.Controls.Add(pnTop);
            theme1.SetTheme(pnBody, ic.iniC.themeApp);
            theme1.SetTheme(pnTop, "Office2010Red");
            pnTop.ResumeLayout(false);
            pnBody.ResumeLayout(false);
            pnBody.PerformLayout();
            pnTop.PerformLayout();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ic.setCboYear(cboYear);
            ic.ivfDB.stknDB.setCboStockSubName(cboStkSubName);
            initGrfStk();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openStockRec();
        }
        private void openStockRec()
        {
            String name = "", txt = "";
            FrmStockRec frm = new FrmStockRec(ic);
            if (!name.Equals(""))
            {
                txt = " " + name;
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, txt);
            //frm.tab = tab;
        }        
        private void initGrfStk()
        {
            grfStk = new C1FlexGrid();
            grfStk.Font = fEdit;
            grfStk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfStk.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfBloodLab);
            this.Load += FrmStockRecView_Load;
            grfStk.DoubleClick += GrfStk_DoubleClick;
            
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            //}

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfStk.ContextMenu = menuGw;
            pnBody.Controls.Add(grfStk);

            theme1.SetTheme(grfStk, "Office2010Red");

        }
        private void GrfStk_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfQue(String search)
        {
            //grfDept.Rows.Count = 7;
            grfStk.Clear();
            grfStk.Rows.Count = 0;
            DataTable dt = new DataTable();            
            
            dt = ic.ivfDB.ovsDB.selectByReceptionSend1();                

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfStk.Rows.Count = dt.Rows.Count + 1;
            grfStk.Cols.Count = 18;            

            grfStk.Cols[colRecDoc].Width = 120;
            grfStk.Cols[colRecDate].Width = 120;
            grfStk.Cols[colRecRemark].Width = 300;
            
            grfStk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfStk.Cols[colRecDoc].Caption = "Doc";
            grfStk.Cols[colRecDate].Caption = "Date";
            grfStk.Cols[colRecRemark].Caption = "Remark";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            
            grfStk.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfStk[i, 0] = i;
                    grfStk[i, colRecDoc] = row["id"].ToString();
                    grfStk[i, colRecDate] = ic.showVN(row["VN"].ToString());
                    grfStk[i, colRecRemark] = row["VN"].ToString();
                    
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    new LogWriter("e", "FrmNurseView SetGrfQue " + ex.Message + " InnerException " + ex.InnerException);
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfStk);
            //grfStk.Cols[colID].Visible = false;
            

            grfStk.Cols[colRecDoc].AllowEditing = false;
            grfStk.Cols[colRecDate].AllowEditing = false;
            grfStk.Cols[colRecRemark].AllowEditing = false;
            
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void FrmStockRecView_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            btnNew.Location = new Point(pnBody.Width - btnNew.Width - 40, lbStkSubName.Location.Y);
            cboStkSubName.Location = new Point(btnNew.Location.X - btnNew.Width- cboStkSubName.Width - 20, lbStkSubName.Location.Y);
            lbStkSubName.Location = new System.Drawing.Point(cboStkSubName.Location.X - (ic.MeasureString(lbStkSubName)).Width-10, lbStkSubName.Location.Y);
        }
    }
}
