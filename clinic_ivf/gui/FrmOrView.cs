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
        int colQueId = 1, colQueHn = 2, colQueName = 3, colQueOpera = 4, colQueOrDate = 5, colQueOrTime = 6, colQueSurgeon = 7;

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
            grfQue.Cols.Count = 8;
            

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
                //grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                //grfQue[i, colStatus] = row["VName"].ToString();
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

        }
        private void FrmOrView_Load(object sender, EventArgs e)
        {

        }
    }
}
