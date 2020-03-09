using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
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
    public partial class FrmItem : Form
    {
        IvfControl ic;
        MainMenu menu;
        Font fEdit, fEditB, ff, ffB;
        Color bg, fc;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1DockingTab tC1;
        C1DockingTabPage tabItem, tabDrug, tabSpecial, tabLab ;
        Panel pnItem;
        Label lbCboname, lbItemName, lbItem, lbCapPtt, lbCapLink, lbItemCode, lbLinkCode, lbMessage;
        C1ComboBox cboItemType;
        C1TextBox txtCode, txtItemCode, txtLinkCode;
        C1FlexGrid grfItem, grfPtt, grfLink;
        C1Button btnSave, btnClear;

        int colItmId = 1, colItmCode = 2, colItmName = 3;
        int colLabId = 1, colLabCode = 2, colLabName = 3;

        Boolean pageLoad = false;
        String itmPttId = "", itmLinkId = "", itmId="";
        public FrmItem(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize+3, FontStyle.Bold);
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            initTab();
            ic.setCboBItemType(cboItemType);

            setGrfItem();
            setGrfPtt(grfPtt, "");
            setGrfPtt(grfLink, "ex");
            pageLoad = false;
        }
        private void initTab()
        {
            int gapLine = 15, gapX=20;
            Size size = new Size();
            Size size1 = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;
            tC1 = new C1.Win.C1Command.C1DockingTab();
            tC1.Dock = System.Windows.Forms.DockStyle.Fill;
            tC1.HotTrack = true;
            tC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tC1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tC1.TabsShowFocusCues = true;
            tabItem = new C1.Win.C1Command.C1DockingTabPage();
            tabItem.Name = "tabItem";
            tabItem.TabIndex = 0;
            tabItem.Text = "Item Master";

            tabDrug = new C1.Win.C1Command.C1DockingTabPage();
            tabDrug.Name = "tabDrug";
            tabDrug.TabIndex = 0;
            tabDrug.Text = "Drug";
            tabSpecial = new C1.Win.C1Command.C1DockingTabPage();
            tabSpecial.Name = "tabSpecial";
            tabSpecial.TabIndex = 0;
            tabSpecial.Text = "Special Item";
            tabLab = new C1.Win.C1Command.C1DockingTabPage();
            tabLab.Name = "tabLab";
            tabLab.TabIndex = 0;
            tabLab.Text = "Lab Item";

            pnItem = new Panel();
            pnItem.Dock = DockStyle.Fill;
            lbCboname = new Label();
            lbCboname.Text = "Type :";
            lbCboname.Font = fEdit;
            lbCboname.Location = new System.Drawing.Point(gapX, 10);
            lbCboname.AutoSize = true;
            cboItemType = new C1ComboBox();
            size = ic.MeasureString(lbCboname);
            cboItemType.Location = new System.Drawing.Point(gapX + size.Width, lbCboname.Location.Y);
            cboItemType.SelectedItemChanged += CboItemType_SelectedItemChanged;

            lbItem = new Label();
            lbItem.Text = "Item :";
            lbItem.Font = fEdit;
            lbItem.Location = new System.Drawing.Point(gapX, gapLine + cboItemType.Height);
            lbItem.AutoSize = true;
            txtCode = new C1TextBox();
            txtCode.Font = fEdit;
            txtCode.Location = new System.Drawing.Point(cboItemType.Location.X, lbItem.Location.Y);
            lbItemName = new Label();
            lbItemName.Text = "...";
            lbItemName.Font = fEdit;
            lbItemName.Location = new System.Drawing.Point(txtCode.Location.X+txtCode.Width, txtCode.Location.Y);
            lbItemName.AutoSize = true;
            btnSave = new C1Button();
            btnSave.Name = "";
            btnSave.Text = "Save";
            btnSave.Font = fEdit;
            btnSave.Location = new System.Drawing.Point(txtCode.Location.X + txtCode.Width+300, txtCode.Location.Y);
            btnSave.Click += BtnSave_Click;
            btnClear = new C1Button();
            btnClear.Name = "";
            btnClear.Text = "Clear";
            btnClear.Font = fEdit;
            btnClear.Location = new System.Drawing.Point(btnSave.Location.X + btnSave.Width + 10, btnSave.Location.Y);
            btnClear.Click += BtnClear_Click;
            lbMessage = new Label();
            lbMessage.Text = "";
            lbMessage.Font = fEditB;
            lbMessage.Location = new System.Drawing.Point(btnClear.Location.X + btnClear.Width + 10, btnClear.Location.Y);
            lbMessage.AutoSize = true;

            panel1.Controls.Add(tC1);
            tC1.Controls.Add(tabItem);
            tC1.Controls.Add(tabDrug);
            tC1.Controls.Add(tabSpecial);
            tC1.Controls.Add(tabLab);

            grfItem = new C1FlexGrid();
            grfItem.Font = fEdit;
            grfItem.Location = new System.Drawing.Point(gapX, gapLine + txtCode.Height + txtCode.Location.Y);
            grfItem.Size = new Size(900, 300);
            grfItem.RowColChange += GrfItem_RowColChange;

            lbCapPtt = new Label();
            lbCapPtt.Text = "Master";
            lbCapPtt.Font = fEdit;
            lbCapPtt.Location = new System.Drawing.Point(gapX, gapLine + grfItem.Location.Y + grfItem.Height);
            lbCapPtt.AutoSize = true;
            size = ic.MeasureString(lbCapPtt);
            txtItemCode = new C1TextBox();
            txtItemCode.Font = fEdit;
            txtItemCode.Location = new System.Drawing.Point(gapX + size.Width, lbCapPtt.Location.Y);
            lbItemCode = new Label();
            lbItemCode.Text = "...";
            lbItemCode.Font = fEdit;
            lbItemCode.Location = new System.Drawing.Point(gapX + txtItemCode.Location.X + txtItemCode.Width, lbCapPtt.Location.Y);
            lbItemCode.AutoSize = true;

            lbCapLink = new Label();
            lbCapLink.Text = "Link";
            lbCapLink.Font = fEdit;
            lbCapLink.Location = new System.Drawing.Point(scrW / 2, lbCapPtt.Location.Y);
            lbCapLink.AutoSize = true;
            size = ic.MeasureString(lbCapLink);
            txtLinkCode = new C1TextBox();
            txtLinkCode.Font = fEdit;
            txtLinkCode.Location = new System.Drawing.Point(lbCapLink.Location.X + size.Width, lbCapLink.Location.Y);
            lbLinkCode = new Label();
            lbLinkCode.Text = "...";
            lbLinkCode.Font = fEdit;
            lbLinkCode.Location = new System.Drawing.Point(gapX + txtLinkCode.Location.X + txtLinkCode.Width, lbCapPtt.Location.Y);
            lbLinkCode.AutoSize = true;

            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Location = new System.Drawing.Point(gapX, lbCapPtt.Height + lbCapPtt.Location.Y);
            grfPtt.Size = new Size((scrW / 2)-50, 300);
            grfPtt.RowColChange += GrfPtt_RowColChange;
            grfLink = new C1FlexGrid();
            grfLink.Font = fEdit;
            grfLink.Location = new System.Drawing.Point(gapX + grfPtt.Width+ gapX, grfPtt.Location.Y);
            grfLink.Size = new Size((scrW / 2) - 50, 300);
            grfLink.RowColChange += GrfLink_RowColChange;
            
            tabItem.Controls.Add(pnItem);
            pnItem.Controls.Add(lbCboname);
            pnItem.Controls.Add(cboItemType);
            pnItem.Controls.Add(lbItemName);
            pnItem.Controls.Add(lbItem);
            pnItem.Controls.Add(txtCode);
            pnItem.Controls.Add(grfItem);
            pnItem.Controls.Add(lbCapPtt);
            pnItem.Controls.Add(lbCapLink);
            pnItem.Controls.Add(grfPtt);
            pnItem.Controls.Add(grfLink);
            pnItem.Controls.Add(txtItemCode);
            pnItem.Controls.Add(txtLinkCode);
            pnItem.Controls.Add(lbItemCode);
            pnItem.Controls.Add(lbLinkCode);
            pnItem.Controls.Add(btnSave);
            pnItem.Controls.Add(btnClear);
            pnItem.Controls.Add(lbMessage);
            theme1.SetTheme(panel1, ic.iniC.themeApp);
            theme1.SetTheme(tC1, ic.iniC.themeApp);
            theme1.SetTheme(tC1, ic.iniC.themeApp);
            theme1.SetTheme(lbMessage, ic.iniC.themeApp);
            lbMessage.Text = "สร้างข้อมูลLinkใหม่";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            itmId = "";
            txtCode.Value = "";
            lbItemName.Text = "";
            lbMessage.Text = "สร้างข้อมูลLinkใหม่";
        }

        private void GrfItem_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfItem.Row <= 0) return;
            if (grfItem.Col <= 0) return;
            if (grfItem[grfItem.Row, colItmId] == null) return;
            itmId = grfItem[grfItem.Row, colItmId].ToString().Trim();
            txtCode.Value = grfItem[grfItem.Row, colItmCode].ToString().Trim();
            lbItemName.Text = grfItem[grfItem.Row, colItmName].ToString().Trim();
            lbMessage.Text = "แก้ไขข้อมูล";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!lbLinkCode.Text.Equals(lbItemCode.Text))
            {
                MessageBox.Show("ชื่อ รายการ ไม่เหมือนกัน", "");
                return;
            }
            if (itmLinkId.Length<=0)
            {
                MessageBox.Show("ไม่พบรหัส Link", "");
                return;
            }
            if (itmPttId.Length <= 0)
            {
                MessageBox.Show("ไม่พบรหัส Master", "");
                return;
            }
            String type = "";
            type = cboItemType.SelectedItem == null ? "" : cboItemType.SelectedItem.ToString();
            if (type.Length <= 0)
            {
                MessageBox.Show("ไม่พบรหัส Type", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n"+ lbItemCode.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.genItem(itmId, txtCode.Text, itmPttId, lbItemCode.Text.Trim(), itmLinkId, type, ic.stfID);
            }
        }

        private void GrfLink_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfLink.Row <= 0) return;
            if (grfLink.Col <= 0) return;
            if (grfLink[grfLink.Row, colItmCode] == null) return;

            txtLinkCode.Value = grfLink[grfLink.Row, colItmCode].ToString().Trim();
            lbLinkCode.Text = grfLink[grfLink.Row, colItmName].ToString().Trim();
            itmLinkId = grfLink[grfPtt.Row, colItmId].ToString().Trim();
        }

        private void GrfPtt_RowColChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPtt.Row <= 0) return;
            if (grfPtt.Col <= 0) return;
            if (grfPtt[grfPtt.Row, colItmCode] == null) return;

            txtItemCode.Value = grfPtt[grfPtt.Row, colItmCode].ToString().Trim();
            lbItemCode.Text = grfPtt[grfPtt.Row, colItmName].ToString().Trim();
            itmPttId = grfPtt[grfPtt.Row, colItmId].ToString().Trim();
        }

        private void CboItemType_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!pageLoad)
            {
                setGrfPtt(grfPtt, "");
                setGrfPtt(grfLink, "ex");
            }
        }

        private void setGrfItem()
        {
            grfItem.Clear();
            grfItem.Rows.Count = 1;
            grfItem.Cols.Count = 4;
            DataTable dt = ic.ivfDB.itmDB.selectAll();
            grfItem.Cols[colItmName].Width = 250;
            grfItem.Cols[colItmCode].Width = 250;
            //grfItem.Cols[colVsVN].Width = 250;
            grfItem.ShowCursor = true;
            grfItem.Cols[colItmName].Caption = "Item Name";
            grfItem.Cols[colItmCode].Caption = "CODE";
            //grfItem.Cols[colVsVN].Caption = "VN";
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit_visit));
            grfItem.ContextMenu = menuGw;
            grfItem.Rows.Count = dt.Rows.Count + 1;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfItem[i, colItmCode] = row[ic.ivfDB.itmDB.itm.item_code].ToString();
                grfItem[i, colItmName] = row[ic.ivfDB.itmDB.itm.item_name_e].ToString();
                grfItem[i, colItmId] = row[ic.ivfDB.itmDB.itm.item_id].ToString();
                grfItem[i, 0] = i;
                i++;
            }
            grfItem.Cols[colItmId].Visible = false;
            grfItem.Cols[colItmCode].AllowEditing = false;
            grfItem.Cols[colItmName].AllowEditing = false;

            theme1.SetTheme(grfItem ,ic.iniC.themeApp);
        }
        private void setGrfPtt(C1FlexGrid grf, String flagEx)
        {
            String type = "";
            type = cboItemType.SelectedItem == null ? "" : cboItemType.SelectedItem.ToString();

            grf.Clear();
            grf.Rows.Count = 1;
            grf.Cols.Count = 4;

            DataTable dt = null;
            if (type.Equals("LAB"))
            {
                if (type.Equals("ex"))
                {
                    dt = ic.ivfDB.oLabiDB.selectAllEx();
                }
                else
                {
                    dt = ic.ivfDB.oLabiDB.selectAll2();
                }
            }
            else if (type.Equals("Special"))
            {
                if (type.Equals("ex"))
                {
                    dt = ic.ivfDB.oSItmDB.selectAllEx();
                }
                else
                {
                    dt = ic.ivfDB.oSItmDB.selectAll2();
                }
            }
            else if (type.Equals("Drug"))
            {
                if (type.Equals("ex"))
                {
                    dt = ic.ivfDB.oStkdDB.selectAllEx();
                }
                else
                {
                    dt = ic.ivfDB.oStkdDB.selectAll2();
                }
            }
            grf.Cols[colItmName].Width = 250;
            grf.Cols[colItmCode].Width = 100;
            grf.Cols[colItmId].Width = 80;
            grf.ShowCursor = true;

            grf.Cols[colItmName].Caption = "Item Name";
            grf.Cols[colItmCode].Caption = "CODE";
            //grfItem.Cols[colVsVN].Caption = "VN";
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit_visit));
            grf.ContextMenu = menuGw;
            grf.Rows.Count = dt.Rows.Count + 1;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grf[i, colItmCode] = row["code"].ToString();
                grf[i, colItmName] = row["name"].ToString();
                grf[i, colItmId] = row["id"].ToString();
                grf[i, 0] = i;
                i++;
            }
            //grf.Cols[colItmId].Visible = false;
            grf.Cols[colItmCode].AllowEditing = false;
            grf.Cols[colItmName].AllowEditing = false;

            theme1.SetTheme(grf, ic.iniC.themeApplication);
        }
        private void FrmItem_Load(object sender, EventArgs e)
        {

        }
    }
}
