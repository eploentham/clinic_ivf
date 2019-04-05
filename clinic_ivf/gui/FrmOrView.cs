using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmOrView : Form
    {
        IvfControl ic;
        MainMenu menu;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colQueId = 1, colQueHn = 2, colQueName = 3, colQueOpera = 4, colQueOrDate = 5, colQueOrTime = 6, colQueSurgeon = 7, colQueRemark=8, colQueAge=9, colQueAnes=10;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;
        C1FlexGrid grfQue, grfOpera, grfFinish;

        public FrmOrView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC, "Office2010Blue");
            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            initGrfQue();
            setGrfQue();
            initGrfOpera();
            setGrfOpera();
            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initGrfOpera()
        {
            grfOpera = new C1FlexGrid();
            grfOpera.Font = fEdit;
            grfOpera.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOpera.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfOpera.AfterRowColChange += GrfQue_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOpera.ContextMenu = menuGw;
            pnOpera.Controls.Add(grfOpera);

            theme1.SetTheme(grfOpera, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }
        private void setGrfOpera()
        {
            //grfDept.Rows.Count = 7;
            grfOpera.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.oropDB.selectByStatusOperation();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfOpera.Rows.Count = dt.Rows.Count + 1;
            grfOpera.Cols.Count = 11;

            grfOpera.Cols[colQueHn].Width = 100;
            grfOpera.Cols[colQueName].Width = 200;
            grfOpera.Cols[colQueOpera].Width = 300;
            grfOpera.Cols[colQueOrDate].Width = 100;
            grfOpera.Cols[colQueOrTime].Width = 60;
            grfOpera.Cols[colQueSurgeon].Width = 160;
            //grfQue.Cols[colStatus].Width = 200;

            grfOpera.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOpera.Cols[colQueHn].Caption = "HN";
            grfOpera.Cols[colQueName].Caption = "Patient Name";
            grfOpera.Cols[colQueOpera].Caption = "Operation";
            grfOpera.Cols[colQueOrDate].Caption = "OR Date";
            grfOpera.Cols[colQueOrTime].Caption = "OR Time";
            grfOpera.Cols[colQueSurgeon].Caption = "Surgeon";
            //grfQue.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("edit operation", new EventHandler(ContextMenu_order_edit));

            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            addDevice.MenuItems.Add(new MenuItem("Form DF ผ่าตัด", new EventHandler(ContextMenu_order_prn_df)));
            addDevice.MenuItems.Add(new MenuItem("Form A ค่าใช้จ่าย", new EventHandler(ContextMenu_order_prn_form_a)));
            addDevice.MenuItems.Add(new MenuItem("Form B ค่าใช้จ่าย", new EventHandler(ContextMenu_orderprn_form_b)));

            grfOpera.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfOpera[i, 0] = i;
                grfOpera[i, colQueId] = row[ic.ivfDB.oropDB.orop.or_id].ToString();
                grfOpera[i, colQueHn] = row[ic.ivfDB.oropDB.orop.patient_hn].ToString();
                grfOpera[i, colQueName] = row[ic.ivfDB.oropDB.orop.patient_name].ToString();
                grfOpera[i, colQueOpera] = row["operation"].ToString();
                grfOpera[i, colQueOrDate] = ic.datetoShow(row[ic.ivfDB.oropDB.orop.or_date].ToString());
                grfOpera[i, colQueOrTime] = row[ic.ivfDB.oropDB.orop.or_time].ToString();
                grfOpera[i, colQueSurgeon] = row["surgeon"].ToString();
                grfOpera[i, colQueRemark] = row["remark"].ToString();
                grfOpera[i, colQueAge] = row["age"].ToString();
                grfOpera[i, colQueAnes] = row["anesthesia_name"].ToString();
                if (!row[ic.ivfDB.oropDB.orop.or_req_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfOpera.GetCellRange(i, colQueHn);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfQue);
            grfOpera.Cols[colQueId].Visible = false;
            grfOpera.Cols[colQueHn].AllowEditing = false;
            grfOpera.Cols[colQueName].AllowEditing = false;
            grfOpera.Cols[colQueOpera].AllowEditing = false;
            grfOpera.Cols[colQueOrDate].AllowEditing = false;
            grfOpera.Cols[colQueOrTime].AllowEditing = false;
            grfOpera.Cols[colQueSurgeon].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void ContextMenu_order_edit(object sender, System.EventArgs e)
        {
            //if (grfQue.Row <= 0) return;
            if (grfQue.Row <= 0) return;
            String chk = "", name = "", id = "";
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            id = grfOpera[grfOpera.Row, colQueId] != null ? grfOpera[grfOpera.Row, colQueId].ToString() : "";
            name = grfOpera[grfOpera.Row, colQueName] != null ? grfOpera[grfOpera.Row, colQueName].ToString() : "";
            //openOrNew(id, "");
            FrmOrAdd frm = new FrmOrAdd(ic, menu, id, "", "", "edit");
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน OR " + name;
            }
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
            this.Cursor = curOld;
        }
        private void ContextMenu_order_prn_df(object sender, System.EventArgs e)
        {
            String or_date = "", name = "", diagnosis = "", operation = "", hn = "";

            or_date = grfOpera[grfOpera.Row, colQueOrDate] != null ? grfOpera[grfOpera.Row, colQueOrDate].ToString() : "";
            diagnosis = grfOpera[grfOpera.Row, colQueRemark] != null ? grfOpera[grfOpera.Row, colQueRemark].ToString() : "";
            name = grfOpera[grfOpera.Row, colQueName] != null ? grfOpera[grfOpera.Row, colQueName].ToString() : "";
            hn = grfOpera[grfOpera.Row, colQueHn] != null ? grfOpera[grfOpera.Row, colQueHn].ToString() : "";
            operation = grfOpera[grfOpera.Row, colQueOpera] != null ? grfOpera[grfOpera.Row, colQueOpera].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setORDf(name, hn, or_date, diagnosis, operation);
            frm.ShowDialog(this);
        }
        private void ContextMenu_order_prn_form_a(object sender, System.EventArgs e)
        {
            String or_date = "", name = "", diagnosis = "", operation = "", hn = "", surgeon="", age="", anesthesia;

            or_date = grfOpera[grfOpera.Row, colQueOrDate] != null ? grfOpera[grfOpera.Row, colQueOrDate].ToString() : "";
            diagnosis = grfOpera[grfOpera.Row, colQueRemark] != null ? grfOpera[grfOpera.Row, colQueRemark].ToString() : "";
            name = grfOpera[grfOpera.Row, colQueName] != null ? grfOpera[grfOpera.Row, colQueName].ToString() : "";
            hn = grfOpera[grfOpera.Row, colQueHn] != null ? grfOpera[grfOpera.Row, colQueHn].ToString() : "";
            operation = grfOpera[grfOpera.Row, colQueOpera] != null ? grfOpera[grfOpera.Row, colQueOpera].ToString() : "";
            surgeon = grfOpera[grfOpera.Row, colQueSurgeon] != null ? grfOpera[grfOpera.Row, colQueSurgeon].ToString() : "";
            age = grfOpera[grfOpera.Row, colQueOpera] != null ? grfOpera[grfOpera.Row, colQueOpera].ToString() : "";
            anesthesia = grfOpera[grfOpera.Row, colQueAnes] != null ? grfOpera[grfOpera.Row, colQueAnes].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setORFormA(name, hn, or_date, diagnosis, operation, surgeon, age, anesthesia);
            frm.ShowDialog(this);
        }
        private void ContextMenu_orderprn_form_b(object sender, System.EventArgs e)
        {

        }
        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.AfterRowColChange += GrfQue_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfQue.ContextMenu = menuGw;
            pnQue.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfQue_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfQue()
        {
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt = new DataTable();
            
            dt = ic.ivfDB.orreqDB.selectByStatusReq();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 10;
            

            grfQue.Cols[colQueHn].Width = 100;
            grfQue.Cols[colQueName].Width = 200;
            grfQue.Cols[colQueOpera].Width = 300;
            grfQue.Cols[colQueOrDate].Width = 100;
            grfQue.Cols[colQueOrTime].Width = 60;
            grfQue.Cols[colQueSurgeon].Width = 160;
            //grfQue.Cols[colStatus].Width = 200;

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colQueHn].Caption = "HN";
            grfQue.Cols[colQueName].Caption = "Patient Name";
            grfQue.Cols[colQueOpera].Caption = "Operation";
            grfQue.Cols[colQueOrDate].Caption = "OR Date";
            grfQue.Cols[colQueOrTime].Caption = "OR Time";
            grfQue.Cols[colQueSurgeon].Caption = "Surgeon";
            //grfQue.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            addDevice.MenuItems.Add(new MenuItem("Form1", new EventHandler(ContextMenu_order)));
            addDevice.MenuItems.Add(new MenuItem("Form2", new EventHandler(ContextMenu_order)));
            addDevice.MenuItems.Add(new MenuItem("Form3", new EventHandler(ContextMenu_order)));
            
            grfQue.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfQue[i, 0] = i;
                grfQue[i, colQueId] = row[ic.ivfDB.orreqDB.orreq.or_req_id].ToString();
                grfQue[i, colQueHn] = row[ic.ivfDB.orreqDB.orreq.patient_hn].ToString();
                grfQue[i, colQueName] = row[ic.ivfDB.orreqDB.orreq.patient_name].ToString();
                grfQue[i, colQueOpera] = row["operation"].ToString();
                grfQue[i, colQueOrDate] = ic.datetoShow(row[ic.ivfDB.orreqDB.orreq.or_date].ToString());
                grfQue[i, colQueOrTime] = row[ic.ivfDB.orreqDB.orreq.or_time].ToString();
                grfQue[i, colQueSurgeon] = row["surgeon"].ToString();
                grfQue[i, colQueRemark] = row["remark"].ToString();
                grfQue[i, colQueAge] = row["age"].ToString();
                //grfQue[i, colPttId] = row["PID"].ToString();
                if (!row[ic.ivfDB.orreqDB.orreq.or_req_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfQue.GetCellRange(i, colQueHn);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfQue);
            grfQue.Cols[colQueId].Visible = false;
            grfQue.Cols[colQueHn].AllowEditing = false;
            grfQue.Cols[colQueName].AllowEditing = false;
            grfQue.Cols[colQueOpera].AllowEditing = false;
            grfQue.Cols[colQueOrDate].AllowEditing = false;
            grfQue.Cols[colQueOrTime].AllowEditing = false;
            grfQue.Cols[colQueSurgeon].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void ContextMenu_order(object sender, System.EventArgs e)
        {
            //if (grfQue.Row <= 0) return;
            if (grfQue.Row <= 0) return;
            String chk = "", name = "", id = "";
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            id = grfQue[grfQue.Row, colQueId] != null ? grfQue[grfQue.Row, colQueId].ToString() : "";
            name = grfQue[grfQue.Row, colQueName] != null ? grfQue[grfQue.Row, colQueName].ToString() : "";
            openOrNew(id, "");
            this.Cursor = curOld;
        }
        private void openOrNew(String reqId, String name)
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm1 = new FrmPasswordConfirm(ic);
            frm1.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String re = ic.ivfDB.orreqDB.UpdateStatusOrAccept(reqId, ic.cStf.staff_id);
                long chk1 = 0;
                if (long.TryParse(re, out chk1))
                {
                    OrTOperation opu1 = ic.ivfDB.setOR(reqId);
                    String re1 = ic.ivfDB.oropDB.insert(opu1, ic.cStf.staff_id);
                    if (long.TryParse(re1, out chk1))
                    {
                        FrmOrAdd frm = new FrmOrAdd(ic, menu, re1,"", "", re1);
                        String txt = "";
                        if (!name.Equals(""))
                        {
                            txt = "ป้อน OR " + name;
                        }
                        frm.FormBorderStyle = FormBorderStyle.None;
                        menu.AddNewTab(frm, txt);
                    }
                }
            }
        }
        private void FrmOrView_Load(object sender, EventArgs e)
        {

        }
    }
}
