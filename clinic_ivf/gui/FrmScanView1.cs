﻿using clinic_ivf.control;
using clinic_ivf.object1;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace clinic_ivf.gui
{
    public partial class FrmScanView1 : Form
    {
        IvfControl ic;

        C1FlexGrid grfVs;
        Font fEdit, fEditB;
        C1DockingTab tcDtr;
        C1DockingTabPage tabStfNote, tabOrder,  tabScan;
        C1FlexGrid grfOrder, grfScan;

        int colVsVsDate=1, colVsVn = 2, colVsStatus=3, colVsDept = 4, colVsPreno=5, colVsAn=6, colVsAndate=7;
        int colPic1 = 1, colPic2 = 2, colPic3 = 3, colPic4 = 4;
        int colOrderId = 1, colOrderName = 2, colOrderMed = 3, colOrderQty = 4;
        int newHeight = 720;
        int mouseWheel = 0;
        int originalHeight = 0;
        ArrayList array1 = new ArrayList();
        List<listStream> lStream;
        listStream strm;
        Image resizedImage, img;
        C1PictureBox pic, picL,picR;
        FlowLayoutPanel fpL, fpR;
        SplitContainer sct;
        //VScrollBar vScroller;
        //int y = 0;
        Form frmImg;
        String dsc_id = "", hn="";
        //Timer timer1;
        Patient ptt;
        Stream streamPrint;
        [STAThread]
        private void txtStatus(String msg)
        {
            txt.Invoke(new EventHandler(delegate
            {
                txt.Value = msg;
            }));
        }
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmScanView1(IvfControl bc)
        {
            InitializeComponent();
            this.ic = bc;
            initConfig();
        }
        public FrmScanView1(IvfControl bc, String hn)
        {
            InitializeComponent();
            this.ic = bc;
            this.hn = hn;
            initConfig();
        }
        private void initConfig()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ic.ivfDB.dgsDB.setCboBsp(cboDgs, "");

            array1 = new ArrayList();
            lStream = new List<listStream>();
            strm = new listStream();
            grfOrder = new C1FlexGrid();
            ptt = new Patient();
            //timer1 = new Timer();
            //int chk = 0;
            //int.TryParse(bc.iniC.timerImgScanNew, out chk);
            //timer1.Interval = chk;
            //timer1.Enabled = true;
            //timer1.Tick += Timer1_Tick;
            //timer1.Stop();

            theme1.SetTheme(sb1, ic.iniC.themeApp);
            theme1.SetTheme(groupBox1, ic.iniC.themeApp);
            theme1.SetTheme(panel2, ic.iniC.themeApp);
            theme1.SetTheme(panel3, ic.iniC.themeApp);
            theme1.SetTheme(sC1, ic.iniC.themeApp);
            foreach (Control con in groupBox1.Controls)
            {
                theme1.SetTheme(con, ic.iniC.themeApp);
            }
            //foreach (Control con in grfScan.Controls)
            //{
            //    theme1.SetTheme(con, "ExpressionDark");
            //}
            initGrf();
            txtHn.Value = hn;
            ptt = ic.ivfDB.pttDB.selectByHn(txtHn.Text.Trim());
            txtName.Value = ptt.Name;
            setGrfVs();
            
            btnHn.Click += BtnHn_Click;
            btnOpen.Click += BtnOpen_Click;
            //btnRefresh.Click += BtnRefresh_Click;
            txtHn.KeyUp += TxtHn_KeyUp;
            //tcDtr.SelectedTabChanged += TcDtr_SelectedTabChanged;
            //sC1.TabIndexChanged += SC1_TabIndexChanged;
            //tcDtr.TabClick += TcDtr_TabClick;
            
            tcDtr = new C1DockingTab();
            tcDtr.Dock = System.Windows.Forms.DockStyle.Fill;
            tcDtr.Location = new System.Drawing.Point(0, 266);
            tcDtr.Name = "c1DockingTab1";
            tcDtr.Size = new System.Drawing.Size(669, 200);
            tcDtr.TabIndex = 0;
            tcDtr.TabsSpacing = 5;
            panel3.Controls.Add(tcDtr);
            theme1.SetTheme(tcDtr, ic.iniC.themeApplication);
            //tabStfNote = new C1DockingTabPage();
            //tabStfNote.Location = new System.Drawing.Point(1, 24);
            ////tabScan.Name = "c1DockingTabPage1";
            //tabStfNote.Size = new System.Drawing.Size(667, 175);
            //tabStfNote.TabIndex = 0;
            //tabStfNote.Text = "ใบยา / Staff's Note";
            //tabStfNote.Name = "tabPageScan";
            //tcDtr.Controls.Add(tabStfNote);
            tcDtr.TabClick += TcDtr_TabClick;

            tabOrder = new C1DockingTabPage();
            tabOrder.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabOrder.Size = new System.Drawing.Size(667, 175);
            tabOrder.TabIndex = 0;
            tabOrder.Text = "ประวัติการสั่งการ";
            tabOrder.Name = "tabOrder";
            tcDtr.Controls.Add(tabOrder);

            tabScan = new C1DockingTabPage();
            tabScan.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabScan.Size = new System.Drawing.Size(667, 175);
            tabScan.TabIndex = 0;
            tabScan.Text = "เวชระเบียน Scan";
            tabScan.Name = "tabPageScan";
            
            tcDtr.Controls.Add(tabScan);

            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);
            grfOrder.Rows[0].Visible = false;
            grfOrder.Cols[0].Visible = false;
            grfOrder.Cols[colOrderId].Visible = false;
            grfOrder.Rows.Count = 1;
            grfOrder.Cols.Count = 5;
            grfOrder.Cols[colOrderName].Caption = "ชื่อ";
            grfOrder.Cols[colOrderMed].Caption = "-";
            grfOrder.Cols[colOrderQty].Caption = "QTY";
            grfOrder.Cols[colOrderName].Width = 300;
            grfOrder.Cols[colOrderMed].Width = 200;
            grfOrder.Cols[colOrderQty].Width = 60;
            grfOrder.Name = "grfOrder";

            grfScan = new C1FlexGrid();
            grfScan.Font = fEdit;
            grfScan.Dock = System.Windows.Forms.DockStyle.Fill;
            grfScan.Location = new System.Drawing.Point(0, 0);
            grfScan.Rows[0].Visible = false;
            grfScan.Cols[0].Visible = false;
            grfScan.Rows.Count = 1;
            grfScan.Name = "grfScan";
            grfScan.Cols.Count = 5;
            Column colpic1 = grfScan.Cols[colPic1];
            colpic1.DataType = typeof(Image);
            Column colpic2 = grfScan.Cols[colPic2];
            colpic2.DataType = typeof(String);
            Column colpic3 = grfScan.Cols[colPic3];
            colpic3.DataType = typeof(Image);
            Column colpic4 = grfScan.Cols[colPic4];
            colpic4.DataType = typeof(String);
            grfScan.Cols[colPic1].Width = 310;
            grfScan.Cols[colPic2].Width = 310;
            grfScan.Cols[colPic3].Width = 310;
            grfScan.Cols[colPic4].Width = 310;
            grfScan.ShowCursor = true;
            grfScan.Cols[colPic2].Visible = false;
            grfScan.Cols[colPic3].Visible = true;
            grfScan.Cols[colPic4].Visible = false;
            grfScan.Cols[colPic1].AllowEditing = false;
            grfScan.Cols[colPic3].AllowEditing = false;
            grfScan.DoubleClick += Grf_DoubleClick;
            //grfScan.AutoSizeRows();
            //grfScan.AutoSizeCols();
            //tabScan.Controls.Add(grfScan);

            theme1.SetTheme(grfOrder, "Office2016Black");
            tabOrder.Controls.Add(grfOrder);
            tabScan.Controls.Add(grfScan);
            //setPicStaffNote();
            theme1.SetTheme(tcDtr, theme1.Theme);
            
        }

        private void TcDtr_TabClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (tcDtr.SelectedTab == tabScan)
            {
                grfScan.AutoSizeCols();
                grfScan.AutoSizeRows();
            }
        }

        private void TcDtr_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tcDtr.SelectedTab == tabScan)
            {
                grfScan.AutoSizeCols();
                grfScan.AutoSizeRows();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //frmmain.Show();
                Close();
                //    return true;
                //}
            }
            //else
            //{
            //    switch (keyData)
            //    {
            //        case Keys.K | Keys.Control:
            //            if (flagShowTitle)
            //                flagShowTitle = false;
            //            else
            //                flagShowTitle = true;
            //            setTitle(flagShowTitle);
            //            return true;
            //        case Keys.X | Keys.Control:
            //            //frmmain.Show();
            //            Close();
            //            return true;
            //    }
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void setPicStaffNote()
        {

            //pnL = new Panel();
            //pnL.Dock = DockStyle.Left;
            //pnL.Width = tabScan.Width / 2;
            //tabScan.Controls.Add(pnL);
            //pnR = new Panel();
            //pnR.Dock = DockStyle.Fill;
            //pnR.Width = tabScan.Width / 2;
            //tabScan.Controls.Add(pnR);
            sct = new SplitContainer();
            sct.Dock = DockStyle.Fill;
            tabStfNote.Controls.Add(sct);

            fpL = new FlowLayoutPanel();
            fpL.Dock = DockStyle.Fill;
            fpL.AutoScroll = true;
            sct.Panel1.Controls.Add(fpL);
            //tabScan.Controls.Add(fpL);
            fpR = new FlowLayoutPanel();
            fpR.Dock = DockStyle.Fill;
            fpR.AutoScroll = true;
            //tabScan.Controls.Add(fpR);
            sct.Panel2.Controls.Add(fpR);

            picL = new C1PictureBox();
            picL = new C1PictureBox();
            picL.Dock = DockStyle.Fill;
            picL.SizeMode = PictureBoxSizeMode.AutoSize;
            fpL.Controls.Add(picL);

            picR = new C1PictureBox();
            picR = new C1PictureBox();
            picR.Dock = DockStyle.Fill;
            picR.SizeMode = PictureBoxSizeMode.AutoSize;
            fpR.Controls.Add(picR);
        }
        private void Grf_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("Row " + ((C1FlexGrid)sender).Row+"\n grf name "+ ((C1FlexGrid)sender).Name, "Col "+((C1FlexGrid)sender).Col+" id "+ ((C1FlexGrid)sender)[((C1FlexGrid)sender).Row,colPic2].ToString());
            if (((C1FlexGrid)sender)[((C1FlexGrid)sender).Row, colPic2] == null) return;
            if (((C1FlexGrid)sender).Row < 0) return;
            String id = "";
            ((C1FlexGrid)sender).AutoSizeCols();
            ((C1FlexGrid)sender).AutoSizeRows();
            id = ((C1FlexGrid)sender)[((C1FlexGrid)sender).Row, colPic2].ToString();
            dsc_id = id;
            MemoryStream strm = null;
            foreach(listStream lstrmm in lStream)
            {
                if (lstrmm.id.Equals(id))
                {
                    strm = lstrmm.stream;
                    break;
                }
            }
            if(strm != null)
            {
                img = Image.FromStream(strm);
                frmImg = new Form();
                FlowLayoutPanel pn = new FlowLayoutPanel();
                //vScroller = new VScrollBar();
                //vScroller.Height = frmImg.Height;
                //vScroller.Width = 15;
                //vScroller.Dock = DockStyle.Right;
                frmImg.WindowState = FormWindowState.Normal;
                frmImg.StartPosition = FormStartPosition.CenterScreen;
                frmImg.Size = new Size(1024, 764);
                frmImg.AutoScroll = true;
                pn.Dock = DockStyle.Fill;
                pn.AutoScroll = true;
                pic = new C1PictureBox();
                pic.Dock = DockStyle.Fill;
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
                //int newWidth = 440;
                int originalWidth = 0;
                
                originalHeight = 0;
                originalWidth = img.Width;
                originalHeight = img.Height;
                //resizedImage = img.GetThumbnailImage(newWidth, (newWidth * img.Height) / originalWidth, null, IntPtr.Zero);
                resizedImage = img.GetThumbnailImage((newHeight* img.Width) / originalHeight, newHeight, null, IntPtr.Zero);
                pic.Image = resizedImage;
                frmImg.Controls.Add(pn);
                pn.Controls.Add(pic);
                //pn.Controls.Add(vScroller);
                ContextMenu menuGw = new ContextMenu();
                menuGw.MenuItems.Add("ต้องการ ลบข้อมูลนี้", new EventHandler(ContextMenu_Delete));
                mouseWheel = 0;
                pic.MouseWheel += Pic_MouseWheel;
                pic.ContextMenu = menuGw;
                //vScroller.Scroll += VScroller_Scroll;
                //pic.Paint += Pic_Paint;
                //vScroller.Hide();
                frmImg.ShowDialog(this);
            }
        }
        private void ContextMenu_Delete(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ลบข้อมูลนี้ ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int chk = 0;
                String re = ic.ivfDB.dscDB.voidDocScan(dsc_id,"");
                if(int.TryParse(re, out chk))
                {
                    frmImg.Dispose();
                    setGrfVs();
                    grfScan.Rows.Count = 0;
                    //clearGrf();
                }
            }
        }
        //private void Pic_Paint(object sender, PaintEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    //pBox = sender as PictureBox;
        //    e.Graphics.DrawImage(pic.Image, e.ClipRectangle, pic.Image.Height, y, e.ClipRectangle.Width,
        //      e.ClipRectangle.Height, GraphicsUnit.Pixel);
        //}

        //private void VScroller_Scroll(object sender, ScrollEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    //Graphics g = pic.CreateGraphics();
        //    //g.DrawImage(pic.Image, newRectangle(0, 0, pic.Height, vScroller.Value));
        //    y = (sender as VScrollBar).Value;
        //    pic.Refresh();
        //}

        private void Pic_MouseWheel(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (e.Delta < 0)
            {
                newHeight += SystemInformation.MouseWheelScrollLines*10;
                this.Text = e.Y.ToString();
            }
            else
            {
                newHeight -= SystemInformation.MouseWheelScrollLines * 10;
            }
            resizedImage = img.GetThumbnailImage((newHeight * img.Width) / originalHeight, newHeight, null, IntPtr.Zero);
            pic.Image = resizedImage;
            //if(resizedImage.Height > frmImg.Height)
            //{
            //    vScroller.Show();
            //}
            //else
            //{
            //    vScroller.Hide();
            //    //Graphics g = pictureBox1.CreateGraphics();
            //    //g.DrawImage(pictureBox1.Image, newRectangle(0, 0, pictureBox1.Height, vScroller.Value));
            //}
        }

        private void TxtHn_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                if (ic.cop.comp_name_e.IndexOf("World Wide IVF") >= 0 || ic.cop.comp_name_e.IndexOf("IVF Worldwide Co., Ltd.") >= 0)
                {
                    PatientOld ptto = new PatientOld();
                    ptto = ic.ivfDB.pttOldDB.selectByHnLike1(txtHn.Text.Trim());
                    ptt.Name = ptto.FullName;
                    ptt.patient_hn = ptto.PIDS;
                }
                else
                {
                    ptt = ic.ivfDB.pttDB.selectByHnLike1(txtHn.Text.Trim());
                }
                txtName.Value = ptt.Name;
                txtHn.Value = ptt.patient_hn;
                setGrfVs();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfVs.AutoSizeCols();
            grfVs.AutoSizeRows();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfVs();
        }

        private void BtnHn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            txtHn.Value = ic.sVsOld.PIDS;
            txtName.Value = ic.sVsOld.PName;
            setGrfVs();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initGrf()
        {
            grfVs = new C1FlexGrid();
            grfVs.Font = fEdit;
            grfVs.Dock = System.Windows.Forms.DockStyle.Fill;
            grfVs.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfVs.AfterRowColChange += GrfVs_AfterRowColChange;
            //grfVs.row
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ต้องการลบข้อมูลมั้งหมด ของ รายการนี้", new EventHandler(ContextMenu_delete_opd_all));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfVs.ContextMenu = menuGw;
            panel2.Controls.Add(grfVs);

            theme1.SetTheme(grfVs, "ExpressionDark");

        }
        private void ContextMenu_delete_opd_all(object sender, System.EventArgs e)
        {
            String id = "", vn = "";
            vn = grfVs[grfVs.Row, colVsVn].ToString();
            if (MessageBox.Show("ต้องการลบข้อมูล ทั้งหมดของ VN " + vn, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int chk = 0;
                String re = ic.ivfDB.dscDB.voidDocScanVN(vn, "");
                if (int.TryParse(re, out chk))
                {
                    setGrfScan(grfVs.Row);
                }
            }
        }
        private void ContextMenu_Gw_Cancel(object sender, System.EventArgs e)
        {
            String id = "";
            if (grfScan.Col <= 0) return;
            if (grfScan.Row < 0) return;
            if (grfScan.Col == 1)
            {
                id = grfScan[grfScan.Row, colPic2].ToString();
            }
            else
            {
                id = grfScan[grfScan.Row, colPic4].ToString();
            }
            if (MessageBox.Show("ต้องการ ลบข้อมูลนี้ "+ id+" - "+ grfVs.Row, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int chk = 0;
                String re = ic.ivfDB.dscDB.voidDocScan(id, "");
                if (int.TryParse(re, out chk))
                {
                    frmImg.Dispose();
                    setGrfScan(grfVs.Row);
                    grfScan.Rows.Count = 0;
                    //clearGrf();
                }
            }
        }
        private void setStaffNote(String vsDate, String preno)
        {
            String file = "", dd = "", mm = "", yy = "";
            Image stffnoteL, stffnoteR;
            if (vsDate.Length > 8)
            {
                try
                {
                    String preno1 = preno;
                    int chk = 0;
                    dd = vsDate.Substring(0, 2);
                    mm = vsDate.Substring(3, 2);
                    yy = vsDate.Substring(vsDate.Length - 4);
                    int.TryParse(yy, out chk);
                    if (chk > 2500)
                        chk -= 543;
                    file = "\\\\172.25.10.5\\image\\OPD\\" + chk + "\\" + mm + "\\" + dd + "\\";
                    preno1 = "000000" + preno1;
                    preno1 = preno1.Substring(preno1.Length - 6);
                    stffnoteL = Image.FromFile(file + preno1 + "R.JPG");
                    stffnoteR = Image.FromFile(file + preno1 + "S.JPG");
                    picL.Image = stffnoteL;
                    picR.Image = stffnoteR;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message, "");
                }
            }
        }
        private void GrfVs_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            if (txtHn.Text.Equals("")) return;

            setGrfScan(e.NewRange.r1);
        }
        private void setGrfScan(int row)
        {
            panel2.Enabled = false;

            ProgressBar pB1 = new ProgressBar();
            pB1.Location = new System.Drawing.Point(20, 16);
            pB1.Name = "pB1";
            pB1.Size = new System.Drawing.Size(862, 23);
            groupBox1.Controls.Add(pB1);
            pB1.Left = txtHn.Left;
            pB1.Show();
            txtVN.Hide();
            txtHn.Hide();
            txtName.Hide();
            label1.Hide();
            cboDgs.Hide();
            btnOpen.Hide();
            btnHn.Hide();

            txt.Hide();
            //label6.Hide();
            //txtVisitDate.Hide();
            chkIPD.Hide();
            //txtPreNo.Hide();

            //clearGrf();
            String statusOPD = "", vsDate = "", vn = "", an = "", anDate = "", hn = "", preno = "";
            statusOPD = grfVs[row, colVsStatus] != null ? grfVs[row, colVsStatus].ToString() : "";
            preno = grfVs[row, colVsPreno] != null ? grfVs[row, colVsPreno].ToString() : "";
            vsDate = grfVs[row, colVsVsDate] != null ? grfVs[row, colVsVsDate].ToString() : "";
            //txtVisitDate.Value = vsDate;
            //if (statusOPD.Equals("OPD"))
            //{
                chkIPD.Checked = false;
                vn = grfVs[row, colVsVn] != null ? grfVs[row, colVsVn].ToString() : "";
                txtVN.Value = vn;
                label2.Text = "VN :";
            //}
            //else
            //{
            //    chkIPD.Checked = true;
            //    an = grfVs[row, colVsAn] != null ? grfVs[row, colVsAn].ToString() : "";
            //    anDate = grfVs[row, colVsAndate] != null ? grfVs[row, colVsAndate].ToString() : "";
            //    txtVN.Value = an;
            //    label2.Text = "AN :";
            //    //txtVisitDate.Value = anDate;
            //}
            //setStaffNote(vsDate, preno);

            DataTable dtOrder = new DataTable();
            vn = grfVs[row, colVsVn] != null ? grfVs[row, colVsVn].ToString() : "";
            if (vn.IndexOf("(") > 0)
            {
                vn = vn.Substring(0, vn.IndexOf("("));
            }
            if (vn.IndexOf("/") > 0)
            {
                vn = vn.Substring(0, vn.IndexOf("/"));
            }
            Application.DoEvents();
            /* ดึง order
             * เดียวค่อยกลับมาเขียนต่อ
            */
            //dtOrder = ic.ivfDB.vsDB.selectDrug(txtHn.Text, vn, preno);
            //grfOrder.Rows.Count = 1;
            //if (dtOrder.Rows.Count > 0)
            //{
            //    try
            //    {
            //        pB1.Value = 0;
            //        pB1.Minimum = 0;
            //        pB1.Maximum = dtOrder.Rows.Count;
            //        foreach (DataRow row1 in dtOrder.Rows)
            //        {
            //            Row rowg = grfOrder.Rows.Add();
            //            rowg[colOrderName] = row1["MNC_PH_TN"].ToString();
            //            rowg[colOrderMed] = "";
            //            rowg[colOrderQty] = row1["qty"].ToString();
            //            pB1.Value++;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("" + ex.Message, "");
            //    }
            //}
            GC.Collect();
            /* ดึง scan
             * เดียวค่อยกลับมาเขียนต่อ
            */
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ต้องการ Print ภาพนี้", new EventHandler(ContextMenu_grfscan__print));
            menuGw.MenuItems.Add("ต้องการ Print ภาพทั้งหมด", new EventHandler(ContextMenu_grfscan_print_all));
            menuGw.MenuItems.Add("ต้องการ ยกเลิก ภาพนี้", new EventHandler(ContextMenu_Gw_Cancel));
            grfScan.ContextMenu = menuGw;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.dscDB.selectByVn(txtHn.Text, vn);
            grfScan.Rows.Count = 0;
            if (dt.Rows.Count > 0)
            {
                try
                {
                    int cnt = 0;
                    cnt = dt.Rows.Count / 2;

                    grfScan.Rows.Count = cnt + 1;
                    foreach (Row row1 in grfScan.Rows)
                    {
                        row1.Height = 100;
                    }
                    pB1.Value = 0;
                    pB1.Minimum = 0;
                    pB1.Maximum = dt.Rows.Count;
                    //MemoryStream stream;
                    //Image loadedImage, resizedImage;

                    FtpClient ftp = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive, ic.iniC.pathChar);
                    Boolean findTrue = false;
                    int colcnt = 0, rowrun = -1;
                    foreach (DataRow row1 in dt.Rows)
                    {
                        if (findTrue) break;
                        colcnt++;
                        String dgssid = "", filename = "", ftphost = "", id = "", folderftp = "";
                        id = row1[ic.ivfDB.dscDB.dsc.doc_scan_id].ToString();
                        dgssid = row1[ic.ivfDB.dscDB.dsc.doc_group_sub_id].ToString();
                        filename = row1[ic.ivfDB.dscDB.dsc.image_path].ToString();
                        ftphost = row1[ic.ivfDB.dscDB.dsc.host_ftp].ToString();
                        folderftp = row1[ic.ivfDB.dscDB.dsc.folder_ftp].ToString();

                        //new Thread(() =>
                        //{
                        String err = "";
                        try
                        {
                            FtpWebRequest ftpRequest = null;
                            FtpWebResponse ftpResponse = null;
                            Stream ftpStream = null;
                            int bufferSize = 2048;
                            err = "00";
                            Row rowd;
                            if ((colcnt % 2) == 0)
                            {
                                rowd = grfScan.Rows[rowrun];
                            }
                            else
                            {
                                rowrun++;
                                rowd = grfScan.Rows[rowrun];
                            }

                            MemoryStream stream;
                            Image loadedImage, resizedImage;
                            stream = new MemoryStream();
                            //stream = ftp.download(folderftp + "//" + filename);

                            //loadedImage = Image.FromFile(filename);
                            err = "01";

                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(ftphost + "/" + folderftp + "/" + filename);
                            ftpRequest.Credentials = new NetworkCredential(ic.iniC.userFTP, ic.iniC.passFTP);
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            err = "02";
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            err = "03";


                            loadedImage = new Bitmap(stream);
                            err = "04";
                            int originalWidth = 0;
                            originalWidth = loadedImage.Width;
                            int newWidth = 640;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            //
                            err = "05";
                            if ((colcnt % 2) == 0)
                            {
                                err = "052 " + colPic3 + " cnt " + grfScan.Cols.Count;
                                rowd[colPic3] = resizedImage;
                                err = "061";
                                rowd[colPic4] = id;
                                //grfScan[grfScan.Row, colPic4] = id;
                                err = "071";
                            }
                            else
                            {
                                err = "051";
                                rowd[colPic1] = resizedImage;
                                err = "06";
                                rowd[colPic2] = id;
                                err = "07";
                            }

                            strm = new listStream();
                            strm.id = id;
                            err = "08";
                            strm.stream = stream;
                            err = "09";
                            lStream.Add(strm);

                            //grf1.AutoSizeRows();
                            //err = "10";
                            //grf1.AutoSizeCols();
                            //err = "11";
                            //loadedImage.Dispose();
                            //resizedImage.Dispose();
                            //stream.Dispose();
                            Application.DoEvents();
                            err = "12";
                            //findTrue = true;
                            //break;
                            //GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            String aaa = ex.Message + " " + err;
                        }
                        //}).Start();

                        pB1.Value++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "");
                }

            }
            pB1.Dispose();
            txtVN.Show();
            txtHn.Show();
            txtName.Show();
            label1.Show();
            cboDgs.Show();
            btnOpen.Show();
            btnHn.Show();
            txt.Show();
            //label6.Show();
            chkIPD.Show();
            //grf1.AutoSizeRows();
            //grf1.AutoSizeRows();
            panel2.Enabled = true;
        }
        private void ContextMenu_grfscan__print(object sender, System.EventArgs e)
        {
            String id = "";
            if (grfScan.Col <= 0) return;
            if (grfScan.Row < 0) return;
            if (grfScan.Col == 1)
            {
                id = grfScan[grfScan.Row, colPic2].ToString();
            }
            else
            {
                id = grfScan[grfScan.Row, colPic4].ToString();
            }
            dsc_id = id;
            MemoryStream strm = null;
            foreach (listStream lstrmm in lStream)
            {
                if (lstrmm.id.Equals(id))
                {
                    strm = lstrmm.stream;
                    streamPrint = lstrmm.stream;
                    break;
                }
            }
            setGrfScanToPrint(false);
            //MessageBox.Show("row "+ grfScan.Row+"\n"+"col "+grfScan.Col+"\n ", "");

        }
        private void ContextMenu_grfscan_print_all(object sender, System.EventArgs e)
        {
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.StartPosition = FormStartPosition.CenterScreen;
            //frmW.ShowDialog(this);

            int i = 0;
            foreach (Row row in grfScan.Rows)
            {
                String id = "";
                if (i == 0)
                {
                    id = row[colPic2] != null ? row[colPic2].ToString() : "";
                    i = 1;
                }
                else
                {
                    id = row[colPic4] != null ? row[colPic4].ToString() : "";
                    i = 0;
                }
                if (id == "") continue;
                dsc_id = id;
                MemoryStream strm = null;
                foreach (listStream lstrmm in lStream)
                {
                    if (lstrmm.id.Equals(id))
                    {
                        strm = lstrmm.stream;
                        streamPrint = lstrmm.stream;
                        break;
                    }
                }
                setGrfScanToPrint(false);
            }

            //frmW.Dispose();
        }
        private void setGrfScanToPrint(Boolean dialogPrint)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            System.Threading.Thread.Sleep(500);

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPageA4;
            //here to select the printer attached to user PC
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = pd;
            if (dialogPrint)
            {
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pd.Print();//this will trigger the Print Event handeler PrintPage
                }
            }
            else
            {
                pd.Print();
            }
            
        }
        private void Pd_PrintPageA4(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                System.Drawing.Image img = Image.FromStream(streamPrint);

                float newWidth = img.Width * 100 / img.HorizontalResolution;
                float newHeight = img.Height * 100 / img.VerticalResolution;

                float widthFactor = newWidth / e.MarginBounds.Width;
                float heightFactor = newHeight / e.MarginBounds.Height;

                if (widthFactor > 1 | heightFactor > 1)
                {
                    if (widthFactor > heightFactor)
                    {
                        widthFactor = 1;
                        newWidth = newWidth / widthFactor;
                        newHeight = newHeight / widthFactor;
                        //newWidth = newWidth / 1.2;
                        //newHeight = newHeight / 1.2;
                    }
                    else
                    {
                        newWidth = newWidth / heightFactor;
                        newHeight = newHeight / heightFactor;
                    }
                }
                e.Graphics.DrawImage(img, 0, 0, (int)newWidth, (int)newHeight);
                //}
            }
            catch (Exception)
            {

            }
        }
        //private void clearGrf()
        //{
        //    foreach (Control con in panel3.Controls)
        //    {
        //        if (con is C1DockingTab)
        //        {
        //            foreach (Control cond in con.Controls)
        //            {
        //                if (cond is C1DockingTabPage)
        //                {
        //                    foreach (Control cong in cond.Controls)
        //                    {
        //                        if (cong is C1DockingTab)
        //                        {
        //                            foreach (Control congd in cong.Controls)
        //                            {
        //                                if (congd is C1DockingTabPage)
        //                                {
        //                                    foreach (Control congd1 in congd.Controls)
        //                                    {
        //                                        if (congd1 is C1FlexGrid)
        //                                        {
        //                                            C1FlexGrid grf1;
        //                                            grf1 = (C1FlexGrid)congd1;
        //                                            //grf1.Clear();
        //                                            grf1.Rows.Count = 0;
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void setGrfVs()
        {
            //grfVs.Clear();
            grfVs.Rows.Count = 0;
            grfVs.Rows.Count = 2;
            grfVs.Cols.Count = 8;
            
            //C1TextBox text = new C1TextBox();
            //grfVs.Cols[colVsVsDate].Editor = text;
            //grfVs.Cols[colVsVn].Editor = text;
            //grfVs.Cols[colVsDept].Editor = text;
            //grfVs.Cols[colVsPreno].Editor = text;

            grfVs.Cols[colVsVsDate].Width = 100;
            grfVs.Cols[colVsVn].Width = 80;
            grfVs.Cols[colVsDept].Width = 240;
            grfVs.Cols[colVsPreno].Width = 100;
            grfVs.Cols[colVsStatus].Width = 60;
            grfVs.ShowCursor = true;
            //grfVs.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfVs.Cols[colVsVsDate].Caption = "Visit Date";
            grfVs.Cols[colVsVn].Caption = "VN";
            grfVs.Cols[colVsDept].Caption = "แผนก";
            grfVs.Cols[colVsPreno].Caption = "";
            grfVs.Cols[colVsPreno].Visible = false;
            grfVs.Cols[colVsVn].Visible = true;
            grfVs.Cols[colVsAn].Visible = false;
            grfVs.Cols[colVsAndate].Visible = false;
            grfVs.Rows[0].Visible = false;
            grfVs.Cols[0].Visible = false;
            grfVs.Cols[colVsVsDate].AllowEditing = false;
            grfVs.Cols[colVsVn].AllowEditing = false;
            grfVs.Cols[colVsDept].AllowEditing = false;
            grfVs.Cols[colVsPreno].AllowEditing = false;

            DataTable dt = new DataTable();
            //MessageBox.Show("hn "+hn, "");
            if (ic.cop.comp_name_e.IndexOf("World Wide IVF") >= 0 || ic.cop.comp_name_e.IndexOf("IVF Worldwide Co., Ltd.") >= 0)
            {
                dt = ic.ivfDB.ovsDB.selectByHN(txtHn.Text);
            }
            else
            {
                dt = ic.ivfDB.vsDB.selectByHN(txtHn.Text);
            }
            int i = 1, j = 1, row = grfVs.Rows.Count;
            //txtVN.Value = dt.Rows.Count;
            //txtName.Value = "";
            //txt.Value = "";
            foreach (DataRow row1 in dt.Rows)
            {
                Row rowa = grfVs.Rows.Add();
                String status = "", vn = "";

                //status = row1["MNC_PAT_FLAG"] != null ? row1["MNC_PAT_FLAG"].ToString().Equals("O") ? "OPD" : "IPD" : "-";
                rowa[colVsVsDate] = ic.datetoShow(row1["VDate"]);
                //rowa[colVsVn] = vn;
                rowa[colVsStatus] = status;
                rowa[colVsVn] = row1["VN"].ToString();
                //vn = row1["MNC_VN_NO"].ToString() + "/" + row1["MNC_VN_SEQ"].ToString() + "(" + row1["MNC_VN_SUM"].ToString() + ")" ;
                //rowa[colVsVsDate] = ic.datetoShow(row1["mnc_date"]);
                //rowa[colVsVn] = vn;
                //rowa[colVsStatus] = status;
                //rowa[colVsPreno] = row1["mnc_pre_no"].ToString();
                //rowa[colVsDept] = row1["MNC_SHIF_MEMO"].ToString();
                //rowa[colVsAn] = row1["mnc_an_no"].ToString()+"/"+ row1["mnc_an_yr"].ToString();
                //rowa[colVsAndate] = ic.datetoShow(row1["mnc_ad_date"].ToString());
            }
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ยกเลิก รูปภาพนี้", new EventHandler(ContextMenu_Void));
            //menuGw.MenuItems.Add("&Update ข้อมูล", new EventHandler(ContextMenu_Update));
            //foreach (DocGroupScan dgs in bc.bcDB.dgsDB.lDgs)
            //{
            //    menuGw.MenuItems.Add("&เลือกประเภทเอกสาร และUpload Image [" + dgs.doc_group_name + "]", new EventHandler(ContextMenu_upload));
            //}
            //grfVs.ContextMenu = menuGw;
            grfVs.Cols[colVsVsDate].AllowEditing = false;
            grfVs.Cols[colVsVn].AllowEditing = false;
            grfVs.Cols[colVsStatus].AllowEditing = false;
            //grfVs.Cols[colImagePath].Visible = false;
            //row1[colVSE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
            //grfVs.AutoSizeCols();
            //grfVs.AutoSizeRows();
            //grfVs.Refresh();
            //theme1.SetTheme(grfVs, "ExpressionDark");
        }
        private void ContextMenu_Void(object sender, System.EventArgs e)
        {
            
        }
        class listStream
        {
            public String id = "";
            public MemoryStream stream;
        }
        private void FrmScanView1_Load(object sender, EventArgs e)
        {
            //fpL.Width = tabStfNote.Width / 2;
            //fpR.Width = fpL.Width+5;
            //sct.SplitterDistance = fpL.Width;
            sC1.HeaderHeight = 0;
            scVs.Width = 240;
            //sct.Panel1.Width = fpL.Width;
            //sct.Panel2.Width = fpR.Width;
            //pnR.Width = 0;
        }
    }
}
