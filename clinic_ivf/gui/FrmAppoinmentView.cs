using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmAppoinmentView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colpttId = 2, colPttHn = 4, colVsTime = 3, colVsCode = 4, colVsPttName = 5, colVsDoctor = 6, colVsSperm = 7, colVsDay1 = 8, colVsDay2 = 9, colVs1St = 10, colVsDay8=11, colVsDay11=12;
        int colVsTVS = 13, colVsEndo = 14, colVsDC = 15, colVsOPU = 16, colVsET_FET = 17, colVsHCG = 18, colVsScreen = 19, colVsTrans = 20, colVsANC = 21, colVsAnes = 22, colVsRemark = 23;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Image imgCorr, imgTran;

        public FrmAppoinmentView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            this.menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            txtDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.dtrOldDB.setCboBsp(cboDoctor,"");

            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            btnNew.Click += BtnNew_Click;

            initGrfPtt();
            setGrfPtt();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAppointmentAdd frm = new FrmAppointmentAdd();
            frm.ShowDialog(this);

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfPtt();
        }
        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            grfPtt.AfterRowColChange += GrfPtt_AfterRowColChange;
            grfPtt.DoubleClick += GrfPtt_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPtt.ContextMenu = menuGw;
            gb.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");

        }

        private void GrfPtt_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            if (grfPtt.Row <= 0) return;
            if (grfPtt.Col <= 0) return;
            
            if (grfPtt.Col == colVsDoctor)
            {
                //MessageBox.Show("", "aaa");
                //byte[] data = (byte[])grfPtt[grfPtt.Row, colVsDoctor];
                //MemoryStream stream = new MemoryStream(data);
                //Bitmap bitmap = new Bitmap(stream);
                //Image aaa = bitmap;
                if (grfPtt[grfPtt.Row, colVsDoctor] == null)
                {
                    grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDoctor];
                    if(compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDoctor] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                    }
                    //if (grfPtt[grfPtt.Row, colVsDoctor] == null || grfPtt[grfPtt.Row, colVsDoctor].ToString().Equals(""))
                    //{
                    //    grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                    //}
                    //else
                    //{
                    //    grfPtt[grfPtt.Row, colVsDoctor] = imgTran;
                    //}
                }
            }
            else if (grfPtt.Col == colVsOPU)
            {
                if (grfPtt[grfPtt.Row, colVsOPU] == null)
                {
                    grfPtt[grfPtt.Row, colVsOPU] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsOPU];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsOPU] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsOPU] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsTVS)
            {
                if (grfPtt[grfPtt.Row, colVsTVS] == null)
                {
                    grfPtt[grfPtt.Row, colVsTVS] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsTVS];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsTVS] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsTVS] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsDay8)
            {
                if (grfPtt[grfPtt.Row, colVsDay8] == null)
                {
                    grfPtt[grfPtt.Row, colVsDay8] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDay8];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDay8] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDay8] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsDay11)
            {
                if (grfPtt[grfPtt.Row, colVsDay11] == null)
                {
                    grfPtt[grfPtt.Row, colVsDay11] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDay11];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDay11] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDay11] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsHCG)
            {
                if (grfPtt[grfPtt.Row, colVsHCG] == null)
                {
                    grfPtt[grfPtt.Row, colVsHCG] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsHCG];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsHCG] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsHCG] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsSperm)
            {
                if (grfPtt[grfPtt.Row, colVsSperm] == null)
                {
                    grfPtt[grfPtt.Row, colVsSperm] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsSperm];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsSperm] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsSperm] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsEndo)
            {
                if (grfPtt[grfPtt.Row, colVsEndo] == null)
                {
                    grfPtt[grfPtt.Row, colVsEndo] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsEndo];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsEndo] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsEndo] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsDC)
            {
                if (grfPtt[grfPtt.Row, colVsDC] == null)
                {
                    grfPtt[grfPtt.Row, colVsDC] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDC];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDC] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDC] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsET_FET)
            {
                if (grfPtt[grfPtt.Row, colVsET_FET] == null)
                {
                    grfPtt[grfPtt.Row, colVsET_FET] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsET_FET];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsET_FET] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsET_FET] = imgCorr;
                    }
                }
            }
            //grfPtt.Renderer ;
            grfPtt.Redraw = true;
            grfPtt.Refresh();
            //grfPtt.AutoSizeCols();
            //grfPtt.AutoSizeRows();
        }
        private bool compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }
        private void GrfPtt_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfPtt()
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            DataTable dt = new DataTable();
            DateTime datestart, dateend;
            String datestart1="", dateend1="";
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            if(DateTime.TryParse(txtDateEnd.Text, out dateend))
            {
                dateend1 = dateend.ToString("yyyy-MM-dd");
            }
            
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            dt = ic.ivfDB.appnOldDB.selectByDateDtr(datestart1, dateend1, cboDoctor.Text);


            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            
            grfPtt.Rows.Count = 2;
            grfPtt.Cols.Count = 24;
            grfPtt.Rows.Fixed = 2;
            grfPtt.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            grfPtt.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Free;

            grfPtt.Rows[0].AllowMerging = true;
            grfPtt.Rows[1].AllowMerging = true;
            for(int j = 0; j< grfPtt.Cols.Count; j++)
            {
                grfPtt.Cols[j].AllowMerging = true;
            }

            C1TextBox txt = new C1TextBox();
            PictureBox img = new PictureBox();
            Image img1 ;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colPttHn].Editor = txt;
            grfPtt.Cols[colVsCode].Editor = txt;
            grfPtt.Cols[colVsTime].Editor = txt;
            grfPtt.Cols[colVsPttName].Editor = txt;
            grfPtt.Cols[colVsDoctor].Editor = txt;
            //grfPtt.Cols[colVsDoctor].ImageAndText = false;
            grfPtt.Cols[colVsSperm].Editor = txt;
            grfPtt.Cols[colVsDay1].Editor = txt;
            grfPtt.Cols[colVsDay2].Editor = txt;
            grfPtt.Cols[colVs1St].Editor = txt;
            grfPtt.Cols[colVsDay8].Editor = txt;
            grfPtt.Cols[colVsDay11].Editor = txt;
            grfPtt.Cols[colVsTVS].Editor = txt;
            grfPtt.Cols[colVsEndo].Editor = txt;
            grfPtt.Cols[colVsDC].Editor = txt;
            grfPtt.Cols[colVsOPU].Editor = txt;
            grfPtt.Cols[colVsET_FET].Editor = txt;
            grfPtt.Cols[colVsHCG].Editor = txt;
            grfPtt.Cols[colVsScreen].Editor = txt;
            grfPtt.Cols[colVsTrans].Editor = txt;
            grfPtt.Cols[colVsANC].Editor = txt;
            grfPtt.Cols[colVsAnes].Editor = txt;
            grfPtt.Cols[colVsRemark].Editor = txt;
            //grfPtt.Cols[colVsAppn].Editor = txt;
            Column col = grfPtt.Cols[colVsDoctor];
            col.DataType = typeof(Image);
            Column colOPU = grfPtt.Cols[colVsOPU];
            colOPU.DataType = typeof(Image);
            Column colTVS = grfPtt.Cols[colVsTVS];
            colTVS.DataType = typeof(Image);
            Column colDay8 = grfPtt.Cols[colVsDay8];
            colDay8.DataType = typeof(Image);
            Column colDay11 = grfPtt.Cols[colVsDay11];
            colDay11.DataType = typeof(Image);
            Column colHCG = grfPtt.Cols[colVsHCG];
            colHCG.DataType = typeof(Image);
            Column colSperm = grfPtt.Cols[colVsSperm];
            colSperm.DataType = typeof(Image);
            Column colEndo = grfPtt.Cols[colVsEndo];
            colEndo.DataType = typeof(Image);
            Column colDC = grfPtt.Cols[colVsDC];
            colDC.DataType = typeof(Image);
            Column colFET = grfPtt.Cols[colVsET_FET];
            colFET.DataType = typeof(Image);

            grfPtt.Cols[colPttHn].Width = 120;
            grfPtt.Cols[colVsCode].Width = 60;
            grfPtt.Cols[colVsTime].Width = 60;
            grfPtt.Cols[colVsPttName].Width = 200;
            grfPtt.Cols[colVsDoctor].Width = 80;
            grfPtt.Cols[colVsSperm].Width = 60;
            grfPtt.Cols[colVsDay1].Width = 60;
            grfPtt.Cols[colVsDay2].Width = 60;
            grfPtt.Cols[colVs1St].Width = 60;
            grfPtt.Cols[colVsDay8].Width = 60;
            grfPtt.Cols[colVsDay11].Width = 60;
            grfPtt.Cols[colVsTVS].Width = 60;
            grfPtt.Cols[colVsEndo].Width = 60;
            grfPtt.Cols[colVsDC].Width = 60;
            grfPtt.Cols[colVsOPU].Width = 60;
            grfPtt.Cols[colVsET_FET].Width = 60;
            grfPtt.Cols[colVsHCG].Width = 60;
            grfPtt.Cols[colVsScreen].Width = 60;
            grfPtt.Cols[colVsTrans].Width = 60;
            grfPtt.Cols[colVsANC].Width = 60;
            grfPtt.Cols[colVsAnes].Width = 100;
            grfPtt.Cols[colVsRemark].Width = 60;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colVsCode].Caption = "Code";
            grfPtt.Cols[colVsTime].Caption = "Time";
            grfPtt.Cols[colVsPttName].Caption = "Name";
            //grfPtt.Cols[colVsPttName].Caption = "Doctor";
            grfPtt.Cols[colVsDoctor].Caption = "Consult";
            grfPtt.Cols[colVsSperm].Caption = "Sperm";
            grfPtt.Cols[colVsDay1].Caption = "Day1";
            grfPtt.Cols[colVsDay2].Caption = "Day2";
            grfPtt.Cols[colVs1St].Caption = "1st";
            grfPtt.Cols[colVsDay8].Caption = "Day8";
            grfPtt.Cols[colVsDay11].Caption = "Day11";
            grfPtt.Cols[colVsTVS].Caption = "TVS";
            grfPtt.Cols[colVsEndo].Caption = "Endo";
            grfPtt.Cols[colVsDC].Caption = "D&C";
            grfPtt.Cols[colVsOPU].Caption = "OPU";
            grfPtt.Cols[colVsET_FET].Caption = "ET/FET";
            grfPtt.Cols[colVsHCG].Caption = "HCG";
            grfPtt.Cols[colVsScreen].Caption = "Screen";
            grfPtt.Cols[colVsTrans].Caption = "Trans";
            grfPtt.Cols[colVsANC].Caption = "ANC";
            grfPtt.Cols[colVsAnes].Caption = "Anes";
            grfPtt.Cols[colVsRemark].Caption = "Remark";
            CellRange rng1 = grfPtt.GetCellRange(0, colVsTime, 1, colVsTime);
            rng1.Data = "Time";
            CellRange rng2 = grfPtt.GetCellRange(0, colPttHn, 1, colPttHn);
            rng1.Data = "HN";
            CellRange rng3 = grfPtt.GetCellRange(0, colVsCode, 1, colVsCode);
            rng3.Data = "Code";
            CellRange rng4 = grfPtt.GetCellRange(0, colVsPttName, 1, colVsPttName);
            rng4.Data = "Name";
            CellRange rng5 = grfPtt.GetCellRange(0, colVsTVS, 1, colVsTVS);
            rng5.Data = "TVS";
            CellRange rng6 = grfPtt.GetCellRange(0, colVsDC, 1, colVsDC);
            rng6.Data = "D&C";
            CellRange rng7 = grfPtt.GetCellRange(0, colVsOPU, 1, colVsOPU);
            rng7.Data = "OPU";
            CellRange rng8 = grfPtt.GetCellRange(0, colVsET_FET, 1, colVsET_FET);
            rng8.Data = "ET/FET";
            CellRange rng9 = grfPtt.GetCellRange(0, colVsScreen, 1, colVsScreen);
            rng9.Data = "Screen";
            CellRange rng10 = grfPtt.GetCellRange(0, colVsANC, 1, colVsANC);
            rng10.Data = "ANC";
            CellRange rng11 = grfPtt.GetCellRange(0, colVsAnes, 1, colVsAnes);
            rng11.Data = "Anes";
            CellRange rng12 = grfPtt.GetCellRange(0, colVsRemark, 1, colVsRemark);
            rng12.Data = "Remark";
            grfPtt[1, colVsDoctor] = "Dr.";
            grfPtt[1, colVsSperm] = "Collect";
            grfPtt[1, colVsDay1] = "period";
            grfPtt[1, colVsDay2] = "Bld/TVS";
            grfPtt[1, colVs1St] = "Inject";
            grfPtt[1, colVsDay8] = "Bld/TVS";
            grfPtt[1, colVsDay11] = "Bld/TVS";
            grfPtt[1, colVsEndo] = "Scan";
            grfPtt[1, colVsHCG] = "Scan";
            grfPtt[1, colVsTrans] = "Sperm";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfPtt.Rows.Add();
                String hormo="", tvs="", opu="", fet="", beta="", other="", appn = "";
                hormo = row[ic.ivfDB.appnOldDB.appnOld.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
                tvs = row[ic.ivfDB.appnOldDB.appnOld.TVS].ToString().Equals("1") ? "TVS " : "";
                opu = row[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1") ? "OPU " + row[ic.ivfDB.appnOldDB.appnOld.OPUTime] != null ? row[ic.ivfDB.appnOldDB.appnOld.OPUTime].ToString()+ row[ic.ivfDB.appnOldDB.appnOld.OPURemark]!=null ? row[ic.ivfDB.appnOldDB.appnOld.OPURemark].ToString() : "" : "" : "";
                beta = row[ic.ivfDB.appnOldDB.appnOld.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
                fet = row[ic.ivfDB.appnOldDB.appnOld.ET_FET].ToString().Equals("1") ? "ET/FET " + row[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time] != null ? row[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time].ToString() : "" : "";
                other = row[ic.ivfDB.appnOldDB.appnOld.Other].ToString().Equals("1") ? "Other " + row[ic.ivfDB.appnOldDB.appnOld.OtherRemark] != null ? row[ic.ivfDB.appnOldDB.appnOld.OtherRemark].ToString() : "" : "";
                appn = hormo + tvs + opu + beta + fet + other;
                row1[0] = i;
                row1[colID] = row[ic.ivfDB.appnOldDB.appnOld.ID].ToString();
                row1[colVsPttName] = row[ic.ivfDB.appnOldDB.appnOld.PatientName].ToString();
                row1[colpttId] = row[ic.ivfDB.appnOldDB.appnOld.PID].ToString();
                row1[colPttHn] = row[ic.ivfDB.appnOldDB.appnOld.PIDS].ToString();
                row1[colVsTime] = row[ic.ivfDB.appnOldDB.appnOld.AppTime].ToString();
                row1[colVsCode] = "";
                if (row[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1"))
                {
                    row1[colVsDoctor] = imgCorr;
                }
                else
                {
                    row1[colVsDoctor] = imgTran;
                }
                row1[colVsSperm] = "";
                row1[colVsDay1] = "";
                row1[colVsDay2] = "";
                row1[colVs1St] = "";
                row1[colVsDay8] = "";
                row1[colVsDay11] = "";
                row1[colVsTVS] = "";
                row1[colVsEndo] = "";
                row1[colVsDC] = "";
                if (row[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1"))
                {
                    row1[colVsOPU] = imgCorr;
                }
                else
                {
                    row1[colVsOPU] = imgTran;
                }
                
                row1[colVsET_FET] = "";
                row1[colVsHCG] = "";
                row1[colVsScreen] = "";
                row1[colVsTrans] = "";
                row1[colVsANC] = "";
                row1[colVsAnes] = row[ic.ivfDB.appnOldDB.appnOld.Doctor].ToString();
                row1[colVsRemark] = "";
                                
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfPtt.Cols[colVsDay8].AllowEditing = false;
            grfPtt.Cols[colVsDay11].AllowEditing = false;
            grfPtt.Cols[colVsHCG].AllowEditing = false;
            grfPtt.Cols[colVsET_FET].AllowEditing = false;
            grfPtt.Cols[colVsDC].AllowEditing = false;
            grfPtt.Cols[colVsEndo].AllowEditing = false;
            grfPtt.Cols[colVsTVS].AllowEditing = false;
            grfPtt.Cols[colVsDoctor].AllowEditing = false;
            grfPtt.Cols[colVsOPU].AllowEditing = false;
            grfPtt.Cols[colID].Visible = false;
            grfPtt.Cols[colpttId].Visible = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfPtt[grfPtt.Row, colpttId] != null ? grfPtt[grfPtt.Row, colpttId].ToString() : "";
            chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colVsPttName] != null ? grfPtt[grfPtt.Row, colVsPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void FrmAppoinmentView_Load(object sender, EventArgs e)
        {

        }
    }
}
