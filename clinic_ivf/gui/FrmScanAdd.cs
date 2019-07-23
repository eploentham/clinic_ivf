﻿using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Leadtools;
//using Leadtools.Ocr;

namespace clinic_ivf.gui
{
    public partial class FrmScanAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        C1FlexGrid grf;
        C1DockingTab tcDtr;
        C1DockingTabPage tabScan;
        C1DockingTabPage[] tabPage1;
        Font fEdit, fEditB;
        //private IOcrEngine _ocrEngine;

        int colPic1 = 1, colPic2 = 2, colPic3 = 3, colPic4 = 4;
        ArrayList array1,arrayImg;
        Timer timer1;
        public FrmScanAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            //menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            tcDtr = new C1DockingTab();
            tcDtr.Dock = System.Windows.Forms.DockStyle.Fill;
            tcDtr.Location = new System.Drawing.Point(0, 266);
            tcDtr.Name = "c1DockingTab1";
            tcDtr.Size = new System.Drawing.Size(669, 200);
            tcDtr.TabIndex = 0;
            tcDtr.TabsSpacing = 5;
            panel1.Controls.Add(tcDtr);
            //theme1.SetTheme(tcDtr, "Office2010Blue");
            tabScan = new C1DockingTabPage();
            tabScan.Location = new System.Drawing.Point(1, 24);
            tabScan.Name = "c1DockingTabPage1";
            tabScan.Size = new System.Drawing.Size(667, 175);
            tabScan.TabIndex = 0;
            tabScan.Text = "PageScan";
            tabScan.Name = "Page Scan";
            tcDtr.Controls.Add(tabScan);
            txtAnDate.Left = txtVisitDate.Left;
            txtAnDate.Top = txtVisitDate.Top;

            //bc.ivfDB.dgsDB.setCboBsp(cboDgs, "");
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-1);
            txtVisitDate.Value = dt.Year + "-" + dt.ToString("MM-dd");
            array1 = new ArrayList();
            arrayImg = new ArrayList();
            timer1 = new Timer();
            int chk = 0;
            int.TryParse(ic.iniC.timerImgScanNew, out chk);
            timer1.Interval = chk;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            timer1.Stop();
            //_ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);

            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(groupBox1, theme1.Theme);
            theme1.SetTheme(panel1, theme1.Theme);
            theme1.SetTheme(tcDtr, theme1.Theme);
            foreach (Control con in groupBox1.Controls)
            {
                if(con is ProgressBar)
                {
                    
                }
                else
                {
                    theme1.SetTheme(con, theme1.Theme);
                }
                
            }
            foreach (Control con in panel1.Controls)
            {
                //theme1.SetTheme(con, theme1.Theme);
            }
            
            btnOpen.Click += BtnOpen_Click;
            btnHn.Click += BtnHn_Click;
            btnDel.Click += BtnDel_Click;

            sB.Text = "aaaaaaaaaa";
            initGrf();
            setGrf();
            //pB1.Hide();
            int i = 0;
            String idOld = "";
            //foreach (DocGroupScan dgs in bc.ivfDB.dgsDB.lDgs)
            //{
            //    C1DockingTabPage tabPage = new C1DockingTabPage();
            //    tabPage.Location = new System.Drawing.Point(1, 24);
            //    tabPage.Size = new System.Drawing.Size(667, 175);

            //    tabPage.TabIndex = 0;
            //    tabPage.Text = "Page" + dgs.doc_group_name;
            //    tabPage.Name = " " + dgs.doc_group_id+"  ";
            //    tcDtr.Controls.Add(tabPage);
            //    i++;
            //    String dgsid = "";
            //    dgsid = bc.ivfDB.dgssDB.getDgsIdDgss(dgss.doc_group_sub_name);
            //    if (!dgsid.Equals(idOld))
            //    {

            //    }
            //}
            //MessageBox.Show("111", "");
            if (ic.ivfDB.dgssDB.lDgss.Count <= 0) ic.ivfDB.dgssDB.getlBsp();
            foreach (DocGroupSubScan dgss in ic.ivfDB.dgssDB.lDgss)
            {
                String dgsid = "";
                dgsid = ic.ivfDB.dgssDB.getDgsIdDgss(dgss.doc_group_sub_name);
                if (!dgsid.Equals(idOld))
                {
                    //MessageBox.Show("222", "");
                    idOld = dgsid;
                    String name = "";
                    name = ic.ivfDB.dgsDB.getNameDgs(dgss.doc_group_id);
                    C1DockingTabPage tabPage = new C1DockingTabPage();
                    tabPage.Location = new System.Drawing.Point(1, 24);
                    tabPage.Size = new System.Drawing.Size(667, 175);

                    tabPage.TabIndex = 0;
                    tabPage.Text = " " + name+"  ";
                    tabPage.Name = dgsid;
                    tcDtr.Controls.Add(tabPage);
                    i++;
                    C1DockingTab tabDtr1 = new C1DockingTab();
                    tabDtr1.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabDtr1.Location = new System.Drawing.Point(0, 266);
                    tabDtr1.Name = "c1DockingTab1";
                    tabDtr1.Size = new System.Drawing.Size(669, 200);
                    tabDtr1.TabIndex = 0;
                    tabDtr1.TabsSpacing = 5;
                    tabPage.Controls.Add(tabDtr1);
                    theme1.SetTheme(tabDtr1, "Office2010Red");
                    foreach (DocGroupSubScan dgsss in ic.ivfDB.dgssDB.lDgss)
                    {
                        if (dgsss.doc_group_id.Equals(dgss.doc_group_id))
                        {
                            //MessageBox.Show("333", "");
                            //addDevice.MenuItems.Add(new MenuItem(dgsss.doc_group_sub_name, new EventHandler(ContextMenu_upload)));

                            C1DockingTabPage tabPage2 = new C1DockingTabPage();
                            tabPage2.Location = new System.Drawing.Point(1, 24);
                            tabPage2.Size = new System.Drawing.Size(667, 175);
                            tabPage2.TabIndex = 0;
                            tabPage2.Text = " " + dgsss.doc_group_sub_name + "  ";
                            tabPage2.Name = "tab"+dgsss.doc_group_sub_id;
                            tabDtr1.Controls.Add(tabPage2);
                            C1FlexGrid grf = new C1FlexGrid();
                            grf.Font = fEdit;
                            grf.Dock = System.Windows.Forms.DockStyle.Fill;
                            grf.Location = new System.Drawing.Point(0, 0);
                            grf.Rows[0].Visible = false;
                            grf.Cols[0].Visible = false;
                            grf.Rows.Count = 1;
                            grf.Name = dgsss.doc_group_sub_id;
                            grf.Cols.Count = 5;
                            Column colpic1 = grf.Cols[colPic1];
                            colpic1.DataType = typeof(Image);
                            Column colpic2 = grf.Cols[colPic2];
                            colpic2.DataType = typeof(String);
                            Column colpic3 = grf.Cols[colPic3];
                            colpic3.DataType = typeof(Image);
                            Column colpic4 = grf.Cols[colPic4];
                            colpic4.DataType = typeof(Image);
                            grf.Cols[colPic1].Width = 310;
                            grf.Cols[colPic2].Width = 310;
                            grf.Cols[colPic3].Width = 310;
                            grf.Cols[colPic4].Width = 310;
                            grf.ShowCursor = true;
                            grf.Cols[colPic2].Visible = false;
                            grf.Cols[colPic3].Visible = false;
                            grf.Cols[colPic4].Visible = false;
                            tabPage2.Controls.Add(grf);
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();            
            
            if (Directory.Exists(ic.iniC.pathImageScan))
            {
                if (MessageBox.Show("ต้องการ ลบข้อมูล รูป scan ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //DirectoryInfo dir = new DirectoryInfo(ic.iniC.pathImageScan);
                    //foreach (FileInfo fi in dir.GetFiles())
                    //{
                    //    fi.Delete();
                    //}
                    int i = 0;
                    String dgs = "", name = "";
                    Boolean chk = false;
                    txtVN.Hide();
                    btnVn.Hide();
                    label3.Hide();
                    txtAN.Hide();
                    txtAnCnt.Hide();
                    chkIPD.Hide();
                    label6.Hide();
                    txtVisitDate.Hide();
                    txtAnDate.Hide();
                    txtPreNo.Hide();

                    ProgressBar pB1 = new ProgressBar();
                    pB1.Location = new System.Drawing.Point(113, 36);
                    pB1.Name = "pB1";
                    pB1.Size = new System.Drawing.Size(862, 23);
                    pB1.Left = txtVN.Left;
                    pB1.Show();
                    pB1.Value = 0;
                    pB1.Minimum = 0;
                    pB1.Maximum = array1.Count;
                    groupBox1.Controls.Add(pB1);
                    Application.DoEvents();
                    foreach (String aa in array1)
                    {
                        i++;
                        pB1.Value++;
                        String[] aaa = aa.Split(',');
                        if (aaa.Length == 3)
                        {
                            name = aaa[2].Replace("*", "");
                            string ext = Path.GetExtension(name);
                            String dgssname = "", dgssid = "", vn = "", an = "";
                            dgssid = ic.ivfDB.dgssDB.getIdDgss("Document Other");
                            DocGroupSubScan dgss = new DocGroupSubScan();
                            dgss = ic.ivfDB.dgssDB.selectByPk(dgssid);
                            DocScan dsc = new DocScan();
                            dsc.active = "1";
                            dsc.doc_scan_id = "";
                            dsc.doc_group_id = dgss.doc_group_id;
                            dsc.hn = txtHn.Text;
                            dsc.vn = txtVN.Text;
                            dsc.an = txtAN.Text;
                            dsc.visit_date = ic.datetoDB(txtVisitDate.Text);
                            dsc.host_ftp = ic.iniC.hostFTP;
                            //dsc.image_path = txtHn.Text + "//" + txtHn.Text + "_" + dgssid + "_" + dsc.row_no + "." + ext[ext.Length - 1];
                            dsc.image_path = "";
                            dsc.doc_group_sub_id = dgssid;
                            dsc.pre_no = txtPreNo.Text;
                            dsc.an = txtAN.Text;
                            DateTime dt = new DateTime();

                            dsc.an_date = (DateTime.TryParse(txtAnDate.Text, out dt)) ? ic.datetoDB(txtAnDate.Text) : "";
                            if (dsc.an_date.Equals("1-01-01"))
                            {
                                dsc.an_date = "";
                            }
                            dsc.folder_ftp = ic.iniC.folderFTP;
                            dsc.status_ipd = chkIPD.Checked ? "I" : "O";
                            String re = ic.ivfDB.dscDB.insertDocScan(dsc, ic.userId);
                            //dsc.image_path = txtHn.Text + "//" + txtHn.Text + "_" + re + ext;
                            if (chkIPD.Checked)
                            {
                                vn = txtAN.Text.Replace("/", "_").Replace("(", "_").Replace(")", "");
                            }
                            else
                            {
                                vn = txtVN.Text.Replace("/", "_").Replace("(", "_").Replace(")", "");
                            }
                            dsc.image_path = txtHn.Text.Replace("-", "").Replace("/", "") + "_" + vn + "//" + txtHn.Text.Replace("-", "").Replace("/", "") + "_" + vn + "_" + re + ext;
                            String re1 = ic.ivfDB.dscDB.updateImagepath(dsc.image_path, re);
                            FtpClient ftp = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
                            //MessageBox.Show("111", "");
                            //ftp.createDirectory(txtHn.Text);
                            ftp.createDirectory(ic.iniC.folderFTP + "//" + txtHn.Text.Replace("/", "") + "_" + vn);
                            //MessageBox.Show("222", "");
                            ftp.delete(ic.iniC.folderFTP + "//" + dsc.image_path);
                            //MessageBox.Show("333", "");
                            ftp.upload(ic.iniC.folderFTP + "//" + dsc.image_path, name);
                            //break;
                            //Application.DoEvents();
                        }
                    }
                    pB1.Dispose();
                    txtVN.Show();
                    btnVn.Show();
                    label3.Show();
                    txtAN.Show();
                    txtAnCnt.Show();
                    chkIPD.Show();
                    label6.Show();
                    delFile();
                    grf.Dispose();
                    initGrf();
                    setGrf();
                    setImage1(true);
                    MessageBox.Show("Upload รูป เวชระเบียน เรียบร้อย", "");
                }
            }
        }
        private void delFile()
        {
            DirectoryInfo dir = new DirectoryInfo(ic.iniC.pathImageScan);
            foreach (FileInfo fi in dir.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error delFile -> " + ex.Message, "");
                }

            }
        }
        private void BtnHn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            //String[] an = ic.sPtt.an.Split('/');
            //if (an.Length > 1)
            //{
            //    txtAN.Value = an[0];
            //    txtAnCnt.Value = an[1];
            //}
            //else
            //{
                //txtAN.Value = ic.sPtt.an;
                //txtAnCnt.Value = "";
            //}
            txtHn.Value = ic.sVsOld.PIDS;
            txtName.Value = ic.sVsOld.PName;
            txtVN.Value = ic.sVsOld.VN;
            //txtVisitDate.Value = ic.sPtt.visitDate;
            //txtPreNo.Value = ic.sPtt.preno;
            
            //txtAnDate.Value = ic.sPtt.anDate;
            //chkIPD.Checked = ic.sPtt.statusIPD.Equals("I") ? true : false;
            
            if (chkIPD.Checked)
            {
                txtVisitDate.Hide();
                txtAnDate.Show();
                label6.Text = "AN Date :";
            }
            else
            {
                txtVisitDate.Show();
                txtAnDate.Hide();
                label6.Text = "Visit Date :";
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //bool exists = System.IO.Directory.Exists(bc.iniC.pathImgScanNew);
            //MessageBox.Show("Timer1_Tick", "");
            DirectoryInfo folderImg = null;
            if (!Directory.Exists(ic.iniC.pathImageScan))
                folderImg = Directory.CreateDirectory(ic.iniC.pathImageScan);
            setImage1(true);
            //String[] Files = Directory.GetFiles(bc.iniC.pathImgScanNew,"*.*", SearchOption.AllDirectories);
            //if (Files.Length > 0)
            //{
            //    setImage(Files);
            //    timer1.Stop();
            //}
        }
        private void setImage1(Boolean flagStop)
        {
            String[] Files = Directory.GetFiles(ic.iniC.pathImageScan, "*.*", SearchOption.AllDirectories);
            if (Files.Length > 0)
            {
                //MessageBox.Show("setImage1", "");
                setGrf();
                setImage(Files);
                if (flagStop)
                {
                    timer1.Stop();
                }
            }
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                String[] file1 = ofd.FileNames;
                setImage(file1);
            }
            
        }
        private void setImage(String[] file1)
        {
            String err = "";
            txtVN.Hide();
            btnVn.Hide();
            label3.Hide();
            txtAN.Hide();
            txtAnCnt.Hide();
            chkIPD.Hide();
            label6.Hide();
            txtVisitDate.Hide();
            txtAnDate.Hide();
            txtPreNo.Hide();
            err = "01";
            //MessageBox.Show("222", "");
            ProgressBar pB1 = new ProgressBar();
            pB1.Location = new System.Drawing.Point(113, 36);
            pB1.Name = "pB1";
            pB1.Size = new System.Drawing.Size(862, 23);
            groupBox1.Controls.Add(pB1);
            pB1.Left = txtVN.Left;
            pB1.Show();
            int i = 1, j = 1, row = grf.Rows.Count;
            grf.Rows.Add();
            row = grf.Rows.Count;
            String re = "";
            array1.Clear();
            try
            {
                err = "02";
                pB1.Value = 0;
                pB1.Minimum = 0;
                pB1.Maximum = file1.Length;
                foreach (String file in file1)
                {
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        err = "021";
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            //byte[] buff = System.IO.File.ReadAllBytes(file);
                            //System.IO.MemoryStream ms = new System.IO.MemoryStream(buff);
                            //MemoryStream stream = new MemoryStream(buff);

                            //loadedImage.Save(stream, ImageFormat.Jpeg);
                            //loadedImage.Dispose();
                            //loadedImage = Image.FromStream(stream);
                            int originalWidth = 0;
                            originalWidth = loadedImage.Width;
                            int newWidth = 280;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            arrayImg.Add(file+",");
                            loadedImage.Dispose();
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        if (j > 4)
                        {
                            grf.Rows.Add();
                            row = grf.Rows.Count;
                            j = 1;
                            i++;
                        }
                        err = "022";
                        //grf.Cols[colPic1].ImageAndText = true;
                        //grf.Cols[colPic2].ImageAndText = true;
                        //grf.Cols[colPic3].ImageAndText = true;
                        //grf.Cols[colPic4].ImageAndText = true;
                        int hei = grf.Rows.DefaultSize;

                        //grf[row - 1, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";
                        array1.Add(i + "," + j + ",*" + file);
                        if (j == 1)
                        {
                            //grf[i, colPic1] = resizedImage;
                            grf.SetCellImage(i, colPic1, resizedImage);
                        }
                        else if (j == 2)
                        {
                            //grf[i, colPic2] = resizedImage;
                            grf.SetCellImage(i, colPic2, resizedImage);
                        }
                        else if (j == 3)
                        {
                            //grf[i, colPic3] = resizedImage;
                            grf.SetCellImage(i, colPic3, resizedImage);
                        }
                        else if (j == 4)
                        {
                            //grf[i, colPic4] = resizedImage;
                            grf.SetCellImage(i, colPic4, resizedImage);
                        }
                        err = "023";
                        j++;
                        pB1.Value++;
                        //resizedImage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        re = ex.Message;
                        MessageBox.Show("Error" + ex.Message, "err "+err);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ex.Message, "");
            }
            //MessageBox.Show("555", "");
            grf.AutoSizeCols();
            grf.AutoSizeRows();
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            pB1.Dispose();
            txtVN.Show();
            btnVn.Show();
            label3.Show();
            txtAN.Show();
            txtAnCnt.Show();
            chkIPD.Show();
            label6.Show();
            if (chkIPD.Checked)
            {
                txtVisitDate.Hide();
                txtAnDate.Show();
            }
            else
            {
                txtVisitDate.Show();
                txtAnDate.Hide();
            }
            txtPreNo.Show();
        }
        private void initGrf()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grf.AfterRowColChange += Grf_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));

            tabScan.Controls.Add(grf);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            //theme1.SetTheme(grf, "Office2010Blue");

        }
        private void setGrf()
        {
            //grf.Clear();
            grf.Rows.Count = 0;
            grf.Rows.Count = 1;
            grf.Cols.Count = 5;
            //Column colpic1 = grf.Cols[colPic1];
            //colpic1.DataType = typeof(Image);
            //Column colpic2 = grf.Cols[colPic2];
            //colpic2.DataType = typeof(Image);
            //Column colpic3 = grf.Cols[colPic3];
            //colpic3.DataType = typeof(Image);
            //Column colpic4 = grf.Cols[colPic4];
            //colpic4.DataType = typeof(Image);
            grf.Cols[colPic1].Width = 310;
            grf.Cols[colPic2].Width = 310;
            grf.Cols[colPic3].Width = 310;
            grf.Cols[colPic4].Width = 310;
            grf.ShowCursor = true;
            //grf.Cols[colPic1].ImageAndText = true;
            //grf.Cols[colPic2].ImageAndText = true;
            //grf.Cols[colPic3].ImageAndText = true;
            //grf.Cols[colPic4].ImageAndText = true;
            //grf.Styles.Normal.ImageAlign = ImageAlignEnum.CenterTop;
            //grf.Styles.Normal.TextAlign = TextAlignEnum.CenterBottom;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Image", new EventHandler(ContextMenu_edit));
            menuGw.MenuItems.Add("&Rotate Image", new EventHandler(ContextMenu_retate));
            //foreach (DocGroupScan dgs in bc.ivfDB.dgsDB.lDgs)
            //{
                //menuGw.MenuItems.Add("&เลือกประเภทเอกสาร และUpload Image ["+dgs.doc_group_name+"]", new EventHandler(ContextMenu_upload));
            String idOld = "";
            //if (lDgss.Count <= 0) getlBsp();
            if (ic.ivfDB.dgssDB.lDgss.Count <= 0) ic.ivfDB.dgssDB.getlBsp();
            if (ic.ivfDB.dgsDB.lDgs.Count <= 0) ic.ivfDB.dgsDB.getlBsp();
            foreach (DocGroupSubScan dgss in ic.ivfDB.dgssDB.lDgss)
            {
                String dgsid = "";
                dgsid = ic.ivfDB.dgssDB.getDgsIdDgss(dgss.doc_group_sub_name);
                if (!dgsid.Equals(idOld))
                {
                    idOld = dgsid;
                    String name = "";
                    name = ic.ivfDB.dgsDB.getNameDgs(dgss.doc_group_id);
                    MenuItem addDevice = new MenuItem("[" + name + "]");
                    menuGw.MenuItems.Add(addDevice);
                    foreach (DocGroupSubScan dgsss in ic.ivfDB.dgssDB.lDgss)
                    {
                        if (dgsss.doc_group_id.Equals(dgss.doc_group_id))
                        {
                            addDevice.MenuItems.Add(new MenuItem(dgsss.doc_group_sub_name, new EventHandler(ContextMenu_upload)));

                        }
                    }
                }
                else
                {
                    
                }
            }
                
            //addDevice.MenuItems.Add("", new EventHandler(ContextMenu_upload));
            //menuGw.MenuItems.Add(addDevice);
            //}
            grf.ContextMenu = menuGw;
            grf.AutoSizeRows();
            //row1[colVSE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;

        }
        //private void Grf_AfterRowColChange(object sender, RangeEventArgs e)
        //{
        //    //throw new NotImplementedException();

        //}
        private String searchInArray()
        {
            String dgs = "", name = "";
            int i = 0;
            Boolean chk = false;
            foreach (String aa in array1)
            {
                i++;
                if (aa.IndexOf(grf.Row + "," + grf.Col) >= 0)
                {
                    name = array1[i - 1].ToString();
                    chk = true;
                    break;
                }
            }
            return name;
        }
        private String addInArrayImg(String filename, String dgssid)
        {
            String dgs = "", name = "";
            int i = 0;
            Boolean chk = false;
            foreach (String aa in arrayImg)
            {
                i++;
                if (aa.IndexOf(filename) >= 0)
                {
                    if (aa.Equals(filename + ","))
                    {
                        arrayImg.Remove(aa);
                        arrayImg.Add(filename + ","+ dgssid);
                    }
                    else
                    {
                        String[] aaa = aa.Split(',');
                        if (aaa.Length > 1)
                        {
                            String filename1 = "", dgssidold = "";
                            filename1 = aaa[0];
                            dgssidold = aaa[1];
                            arrayImg.Remove(aa);
                            arrayImg.Add(aa + "," + dgssid);
                            Boolean findTrue = false;
                            foreach (Control con in this.Controls)
                            {
                                if (findTrue) break;
                                if (con is Panel)
                                {
                                    foreach (Control conp in con.Controls)
                                    {
                                        if (findTrue) break;
                                        if (conp is C1DockingTab)
                                        {
                                            foreach (Control cond in conp.Controls)
                                            {
                                                if (findTrue) break;
                                                if (cond is C1DockingTabPage)
                                                {
                                                    foreach (Control cong in cond.Controls)
                                                    {
                                                        if (findTrue) break;
                                                        if (cong is C1DockingTab)
                                                        {
                                                            foreach (Control congd in cong.Controls)
                                                            {
                                                                if (findTrue) break;
                                                                if (congd is C1DockingTabPage)
                                                                {
                                                                    foreach (Control congd1 in congd.Controls)
                                                                    {
                                                                        if (findTrue) break;
                                                                        if (congd1 is C1FlexGrid)
                                                                        {
                                                                            if (congd1.Name.Equals(dgssidold))
                                                                            {
                                                                                C1FlexGrid grf1;
                                                                                grf1 = (C1FlexGrid)congd1;
                                                                                int j = 0;
                                                                                foreach(Row rowa in grf1.Rows)
                                                                                {
                                                                                    String namerow = "";
                                                                                    if(rowa[colPic2] != null)
                                                                                    {
                                                                                        namerow = rowa[colPic2].ToString();
                                                                                        if (namerow.Equals(filename1))
                                                                                        {
                                                                                            grf1.RemoveItem(j);
                                                                                        }
                                                                                    }
                                                                                    j++;
                                                                                    findTrue = true;
                                                                                    break;
                                                                                }
                                                                                grf1.AutoSizeRows();
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
            return name;
        }
        private void ContextMenu_retate(object sender, System.EventArgs e)
        {
            String dgs = "", filename = "", id = "";
            filename = searchInArray();
            try
            {
                filename = filename.Substring(filename.IndexOf('*') + 1);
                Image img = Image.FromFile(filename);
                Image resizedImage;
                int originalWidth = img.Width;
                int newWidth = 280;
                resizedImage = img.GetThumbnailImage(newWidth, (newWidth * img.Height) / originalWidth, null, IntPtr.Zero);
                resizedImage = ic.RotateImage(resizedImage);
                grf[grf.Row, grf.Col] = resizedImage;
                grf.AutoSizeCols();
                grf.AutoSizeRows();
            }
            catch (Exception ex)
            {

            }
        }
        private void ContextMenu_upload(object sender, System.EventArgs e)
        {
            String dgs = "", filename = "", id = "";
            filename = searchInArray();
            if (txtHn.Text.Equals(""))
            {
                MessageBox.Show("กรุณาป้อน HN", "");
                return;
            }
            try
            {
                filename = filename.Substring(filename.IndexOf('*') + 1);
                //String[] ext = filename.Split('.');
                string ext = Path.GetExtension(filename);
                String dgssname = "", dgssid="";
                dgssname = ((MenuItem)sender).Text;
                dgssid = ic.ivfDB.dgssDB.getIdDgss(dgssname);
                DocGroupSubScan dgss = new DocGroupSubScan();
                dgss = ic.ivfDB.dgssDB.selectByPk(dgssid);
                if (!dgss.doc_group_sub_id.Equals(""))
                {
                    //dgs = cboDgs.SelectedItem == null ? "" : ((ComboBoxItem)cboDgs.SelectedItem).Value;
                    int row = 0, col = 0;
                    row = grf.Row;
                    col = grf.Col;
                    DocScan dsc = new DocScan();
                    dsc.active = "1";
                    dsc.doc_scan_id = "";
                    dsc.doc_group_id = dgss.doc_group_id;
                    dsc.hn = txtHn.Text;
                    dsc.vn = txtVN.Text;
                    dsc.an = txtAN.Text;
                    dsc.visit_date = ic.datetoDB(txtVisitDate.Text);
                    //if (!txtVN.Text.Equals(""))
                    //{
                    //    dsc.row_no = bc.ivfDB.dscDB.selectRowNoByHnVn(txtHn.Text, txtVN.Text, dgs);
                    //}
                    //else
                    //{
                    //    dsc.row_no = bc.ivfDB.dscDB.selectRowNoByHn(txtHn.Text, dgs);
                    //}
                    dsc.host_ftp = ic.iniC.hostFTP;
                    //dsc.image_path = txtHn.Text + "//" + txtHn.Text + "_" + dgssid + "_" + dsc.row_no + "." + ext[ext.Length - 1];
                    dsc.image_path = "";
                    dsc.doc_group_sub_id = dgssid;
                    dsc.pre_no = txtPreNo.Text;
                    dsc.an = txtAN.Text;
                    DateTime dt = new DateTime();

                    dsc.an_date = (DateTime.TryParse(txtAnDate.Text, out dt)) ? ic.datetoDB(txtAnDate.Text) : "";
                    if (dsc.an_date.Equals("1-01-01"))
                    {
                        dsc.an_date = "";
                    }
                    dsc.status_ipd = chkIPD.Checked ? "I" : "O";
                    dsc.folder_ftp = ic.iniC.folderFTP;
                    String re = ic.ivfDB.dscDB.insertDocScan(dsc, ic.userId);
                    dsc.image_path = txtVN.Text + "//" + txtHn.Text.Replace("/","-") + "_"+ txtVN.Text + "_" + re + ext;
                    String re1 = ic.ivfDB.dscDB.updateImagepath(dsc.image_path, re);
                    FtpClient ftp = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
                    //MessageBox.Show("111", "");
                    ftp.createDirectory(ic.iniC.folderFTP+"//"+ txtVN.Text);
                    //MessageBox.Show("222", "");
                    ftp.delete(dsc.image_path);
                    //MessageBox.Show("333", "");
                    ftp.upload(ic.iniC.folderFTP+"//"+dsc.image_path, filename);
                    Boolean findTrue = false;
                    foreach(Control con in this.Controls)
                    {
                        if (findTrue) break;
                        if (con is Panel)
                        {
                            foreach (Control conp in con.Controls)
                            {
                                if (findTrue) break;
                                if (conp is C1DockingTab)
                                {
                                    foreach (Control cond in conp.Controls)
                                    {
                                        if (findTrue) break;
                                        if (cond is C1DockingTabPage)
                                        {
                                            foreach (Control cong in cond.Controls)
                                            {
                                                if (findTrue) break;
                                                if (cong is C1DockingTab)
                                                {
                                                    foreach (Control congd in cong.Controls)
                                                    {
                                                        if (findTrue) break;
                                                        if (congd is C1DockingTabPage)
                                                        {
                                                            foreach (Control congd1 in congd.Controls)
                                                            {
                                                                if (findTrue) break;
                                                                if (congd1 is C1FlexGrid)
                                                                {
                                                                    if (congd1.Name.Equals(dsc.doc_group_sub_id))
                                                                    {
                                                                        String aa = "";
                                                                        C1FlexGrid grf1;
                                                                        grf1 = (C1FlexGrid)congd1;
                                                                        Row rowg = grf1.Rows.Add();
                                                                        Image loadedImage, resizedImage;
                                                                        loadedImage = Image.FromFile(filename);
                                                                        int originalWidth = 0;
                                                                        originalWidth = loadedImage.Width;
                                                                        int newWidth = 280;
                                                                        resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                                                                        //
                                                                        rowg[colPic1] = resizedImage;
                                                                        rowg[colPic2] = filename;
                                                                        //grf[grf.Row, grf.Col] = dsc.doc_group_sub_id;
                                                                        grf1.AutoSizeRows();
                                                                        Application.DoEvents();
                                                                        addInArrayImg(filename, dsc.doc_group_sub_id);

                                                                        grf.SetData(grf.Row, grf.Col, dgssname);
                                                                        grf.AutoSizeRows(grf.Row, grf.Col, grf.Row, grf.Col, 20 , AutoSizeFlags.SameSize);
                                                                        
                                                                        findTrue = true;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //grf.AutoSizeRows();
                    //grf.AutoSizeCols();
                    //CellRange cr = grf.GetCellRange(grf.Row, grf.Col);
                    CellStyle cs = grf.Styles.Add("CellNeWStyle");
                    cs.BackColor = Color.Green;
                    cs.Border.Color = Color.FromArgb(196, 228, 223);
                    cs.Border.Color = Color.Black;
                    //cr.Style = cs;
                    grf.SetCellStyle(grf.Row, grf.Col, cs);
                    grf.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterTop;
                    grf.Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterBottom;
                    grf.SetData(grf.Row, grf.Col, dgssname);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String pttId = "", filename = "", id = "";
            int i = 0;
            Boolean chk = false;
            foreach (String aa in array1)
            {
                i++;
                if(aa.IndexOf(grf.Row + "," + grf.Col) >= 0)
                {
                    filename = array1[i-1].ToString();
                    chk = true;
                    break;
                }
            }
            try
            {
                filename = filename.Substring(filename.IndexOf('*') + 1);
                //MessageBox.Show("row " + grf.Row + " col " + grf.Col + "\n" + name, "");
                if (chk)
                {
                    String dgs = "";
                    //dgs = cboDgs.SelectedItem == null ? "" : ((ComboBoxItem)cboDgs.SelectedItem).Value;
                    FrmScanAddView frm = new FrmScanAddView(ic, txtHn.Text, txtVN.Text, txtName.Text, filename, dgs, txtVisitDate.Text);
                    frm.ShowDialog(this);
                    setGrf();
                    setImage1(false);
                }
            }
            catch(Exception ex)
            {
                filename = ex.Message;
            }
            //id = grfPtt[grfPtt.Row, colID] != null ? grfPtt[grfPtt.Row, colID].ToString() : "";
        }
        private void FrmScanNew_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
