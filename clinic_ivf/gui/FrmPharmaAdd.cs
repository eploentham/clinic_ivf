using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmPharmaAdd : Form
    {
        /*
         * 63-10-27     0020        เรื่อง		เลิก insert table Visit
         */
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;
        public FrmPharmaView frmPharView;

        String pttId = "", webcamname = "", vsid = "", flagedit = "", pApmId = "", printerOld="";
        Patient ptt;
        //VisitOld vsOld;
        Visit vs;
        //PatientOld pttOld, pttO;

        C1FlexGrid grfRx, grfOrder, grfNote;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colBlId = 1, colBlName = 2, colBlQty = 3, colBlPrice = 4, colBlInclude = 5, colBlRemark = 6;
        int colRxdId = 1, colRxName = 2, colRxQty = 3, colRxPrice = 4, colRxInclude = 5, colRxRemark = 6, colRxUsE = 7, colRxUsT = 8, colRxId = 9, colRxItmId = 10;
        int colNoteId = 1, colNote = 2, colNoteStatusAll = 3;
        int colOrdid = 1, colOrdlpid = 2, colOrdName = 3, colOrdPrice = 4, colOrdQty = 5, colOrdstatus = 6, colOrdrow1 = 7, colOrditmid = 8, colOrdInclude = 9, colOrdAmt = 10, colOrdUsE = 11, colOrdUsT = 12, colOrdEdit=13;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        Image imgCorr, imgTran;
        static String filenamepic = "";
        decimal rat = 0;
        Color color;
        int rowOrder = 0, spHeight = 150;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        public FrmPharmaAdd(IvfControl ic, MainMenu m, String pttid, String vsid, String flagedit)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vsid = vsid;
            this.pttId = pttid;
            this.flagedit = flagedit;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(tabOrder, "MacSilver");     //spPatient
            theme1.SetTheme(sC, theme1.Theme);

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            //vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            //pttOld = new PatientOld();
            //pttO = new PatientOld();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;

            ic.setCboLangSticker(cboLangSticker,"Thai");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.pttDB.setCboAllergy(cboAllergyDesc);

            btnFinish.Click += BtnFinish_Click;
            cboLangSticker.SelectedIndexChanged += CboLangSticker_SelectedIndexChanged;
            btnNoteAdd.Click += BtnNoteAdd_Click;
            tlpPatient.Resize += TlpPatient_Resize;
            btnPrnSticker.Click += BtnPrnSticker_Click;
            btnCalBack.Click += BtnCalBack_Click;

            setControl(vsid);
            initGrfRx();
            setGrfRx();
            initGrfNote();
            setGrfNote();
            initGrfOrder();
            setGrfOrder(txtVn.Text);
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void BtnCalBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //ic.ivfDB.accountsendtonurse(txtVn.Text, ic.userId);
            //VisitOld ovs = new VisitOld();
            //ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);

            ic.ivfDB.nurseFinish(txtVnOld.Text, ic.cStf.staff_id);
            frmPharView.setGrfQuePublic();
            frmPharView.setGrfFinishPublic();
            menu.removeTab(tab);
            //}
        }
        private void BtnPrnSticker_Click(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            PrinterSettings settings = new PrinterSettings();
            printerOld = settings.PrinterName;
            SetDefaultPrinter(ic.iniC.printerSticker);
            //ic.logw.WriteLog("d", "PrinterSticker " + ic.iniC.printerSticker);
            String date = "", date1 = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            DataTable dt = new DataTable();
            //date = "2018-11-05";
            //date1 = "05-11-2018";
            foreach(Row row in grfOrder.Rows)
            {
                String pxid = "", status = "", re = "", edit = "", usage = "";
                pxid = row[colOrdid] != null ? row[colOrdid].ToString() : "";
                status = row[colOrdstatus] != null ? row[colOrdstatus].ToString() : "";
                edit = row[colOrdEdit] != null ? row[colOrdEdit].ToString() : "";
                if (edit.Equals("1"))
                {
                    if (cboLangSticker.Text.Trim().Equals("English"))
                    {
                        usage = row[colOrdUsE].ToString();
                        re = ic.ivfDB.oJpxdDB.updateUsageEByID(pxid, usage);
                    }
                    else
                    {
                        usage = row[colOrdUsT].ToString();
                        re = ic.ivfDB.oJpxdDB.updateUsageTByID(pxid, usage);
                    }
                }
            }
            if (cboLangSticker.Text.Trim().Equals("English"))
            {
                dt = ic.ivfDB.oJpxdDB.selectByVN1FreqEN(txtVn.Text);
            }
            else
            {
                dt = ic.ivfDB.oJpxdDB.selectByVN1FreqTH(txtVn.Text);
            }
            
            //if (dt.Rows.Count <= 0) return;
            foreach ( DataRow row in dt.Rows)
            {
                String qty = "", unit = "";
                qty = row["qty"] != null ? row["qty"].ToString() : " ";
                unit = row["unit_name"] != null ? row["unit_name"].ToString() : " ";
                row["unit_name"] = qty +" "+ unit;
                if (ptt.f_patient_nation_id.Equals("1"))        // thai
                {
                    row["patient_name"] = ic.ivfDB.fpfDB.getList1(ptt.f_patient_prefix_id)+" "+ptt.patient_firstname+" "+ ptt.patient_lastname;
                }
                //if (cboLangSticker.Text.Trim().Equals("English"))
                //{
                //    row["patient_name"] = txtPttNameE.Text.Trim();
                //}
                //else
                //{
                //    row["patient_name"] = txtPttName.Text.Trim();
                //}
                //MessageBox.Show("unit "+ row["unit_name"].ToString(), "");
            }
            ic.ivfDB.oJpxdDB.updateStatusPrintOKByVN(txtVn.Text);
            ic.ivfDB.oJpxdDB.updateStatusUpStockOKByVN(txtVn.Text);
            //PrinterSettings settings1 = new PrinterSettings();
            //settings1.DefaultPageSettings.PrinterSettings.PrinterName = ic.iniC.printerSticker;
            //settings1.PrinterName = ic.iniC.printerSticker;
            FrmReport frm = new FrmReport(ic);
            frm.setStickerDrugReport(date, dt, cboLangSticker.Text.Trim());
            frm.ShowDialog(this);
        }
        private void setControl(String vsid)
        {
            //vsOld = ic.ivfDB.ovsDB.selectByPk1(vsid);             //      -0020
            //pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);      //      -0020
            //vs = ic.ivfDB.vsDB.selectByVn(vsid);              //      -0020
            vs = ic.ivfDB.vsDB.selectByPk1(vsid);                //  +0020
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

            //txtHn.Value = ptt.patient_hn;//      -0020
            txtHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);//  +0020
            txtVn.Value = vs.visit_vn;
            txtPttNameE.Value = ptt.Name;
            txtPttName.Value = ic.ivfDB.fpfDB.getList1(ptt.f_patient_prefix_id) + " " + ptt.patient_firstname + " " + ptt.patient_lastname;
            txtVnShow.Value = ic.showVN(vs.visit_vn);

            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtAllergy.Value = ptt.allergy_description;
            txtIdOld.Value = ptt.t_patient_id_old;
            txtVnOld.Value = vs.visit_vn;
            txtVsId.Value = vs.t_visit_id;
            txtPttId.Value = ptt.t_patient_id;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtVisitHeight.Value = vs.height;
            txtVisitBW.Value = vs.bw;
            txtVisitBP.Value = vs.bp;
            txtVisitPulse.Value = vs.pulse;
            chkChronic.Checked = ptt.status_congenial.Equals("1") ? true : false;
            ic.setC1Combo(cboDoctor, vs.doctor_id);
            Patient ptt1 = new Patient();
            ptt1 = ic.ivfDB.pttDB.selectByHn(vs.patient_hn_male);
            txtNameMale.Value = ptt1.Name;
            stt.Show("<p><b>สวัสดี</b></p>คุณ " + ptt.congenital_diseases_description + "<br> กรุณา ป้อนรหัสผ่าน", chkChronic);
            txtCongenital.Value = ptt.congenital_diseases_description;
            if (!ptt.t_patient_id.Equals(""))
            {
                PatientImage pttI = new PatientImage();
                pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(ptt.t_patient_id);
                filenamepic = pttI.image_path;
                Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
                threadA.Start();
            }
            //if (!vsOld.VSID.Equals("166"))            //      -0020

            //  ต้องการ พิมพ์ sticker ย้อยหลัง
            //if (!vs.vsid.Equals("166"))               //  ต้องการ พิมพ์ sticker ย้อยหลัง
            //{                                         //  ต้องการ พิมพ์ sticker ย้อยหลัง
            //    btnPrnSticker.Enabled = false;        //  ต้องการ พิมพ์ sticker ย้อยหลัง
            //}                                         //  ต้องการ พิมพ์ sticker ย้อยหลัง

            //txtBg.Value = pttOld.b
            //txtAllergy.Value = 
        }
        private void ExecuteA(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                //MemoryStream stream = new MemoryStream();
                //FtpClient ftp = new FtpClient(host, user, pass);
                //stream = ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
                //Bitmap bitmap = new Bitmap(stream);
                //Bitmap bitmap = new Bitmap(ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg));
                //picPtt.Image = bitmap;
                //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
                //setPic(bitmap);
                String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + txtIdOld.Text + "." + System.Drawing.Imaging.ImageFormat.Jpeg;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                setPic(new Bitmap(ic.ftpC.download(aaa)));
            }
            catch (Exception ex)
            {

            }
        }
        private void setPic(Bitmap bitmap)
        {
            picPtt.Image = bitmap;
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfOrder.AfterDataRefresh += GrfOrder_AfterDataRefresh;
            grfOrder.ChangeEdit += GrfOrder_ChangeEdit;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            grfOrder.SelectionMode = SelectionModeEnum.RowRange;
            //grfOrder.mou
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_or_void));
                menuGw.MenuItems.Add("Print Sticker", new EventHandler(ContextMenu_print_sticker));
            }
            else
            {
                //menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_or_void));
                menuGw.MenuItems.Add("Print Sticker", new EventHandler(ContextMenu_print_sticker));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "GreenHouse");

        }

        private void GrfOrder_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfOrder == null) return;
            if (grfOrder.Row <= 0) return;
            if (grfOrder.Col <= 0) return;
            grfOrder[grfOrder.Row, colOrdEdit] = "1";
        }

        private void ContextMenu_print_sticker(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            //if (!vsOld.VSID.Equals("166") && vsOld.VSID.Equals("999"))        //      -0020
            if (!vs.vsid.Equals("166") && vs.vsid.Equals("999"))                //      +0020
            {
                MessageBox.Show("รอ รับชำระ ไม่สามารถพิมพ์ Sticker ได้", "");
                //return;
            }
            String id = "", date = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            CellRange cell = grfOrder.Selection;
            //if (cell is null) return;
            if (cell.TopRow < 1) return;
            for (int i = cell.TopRow; i <= cell.BottomRow; i++)
            {
                String pxid = "", status = "", re="", edit="", usage="";
                pxid = grfOrder[i, colOrdid].ToString();
                status = grfOrder[i, colOrdstatus].ToString();
                edit = grfOrder[i, colOrdEdit].ToString();
                if (status.Equals("px"))
                {
                    id += pxid + ",";
                }
                if (cboLangSticker.Text.Trim().Equals("English"))
                {
                    usage = grfOrder[i, colOrdUsE].ToString();
                    if (edit.Equals("1"))
                    {
                        re = ic.ivfDB.oJpxdDB.updateUsageEByID(id, usage);
                    }
                }
                else
                {
                    usage = grfOrder[i, colOrdUsT].ToString();
                    if (edit.Equals("1"))
                    {
                        re = ic.ivfDB.oJpxdDB.updateUsageTByID(id, usage);
                    }
                }
            }
            id = id.Trim();
            if (id.Length > 0)
            {
                if (id.Substring(id.Length - 1).IndexOf(',') >= 0)
                {
                    id = id.Substring(0, id.Length - 1);
                }
                PrinterSettings settings = new PrinterSettings();
                printerOld = settings.PrinterName;
                SetDefaultPrinter(ic.iniC.printerSticker);
                
                DataTable dt = new DataTable();
                if (cboLangSticker.Text.Trim().Equals("English"))
                {
                    dt = ic.ivfDB.oJpxdDB.selectBypxidFreqEN(id);
                }
                else
                {
                    dt = ic.ivfDB.oJpxdDB.selectBypxidFreqTH(id);
                }
                if (dt.Rows.Count > 0)
                {
                    //if (dt.Rows.Count <= 0) return;
                    foreach (DataRow row in dt.Rows)
                    {
                        String qty = "", unit = "";
                        qty = row["qty"] != null ? row["qty"].ToString() : " ";
                        unit = row["unit_name"] != null ? row["unit_name"].ToString() : " ";
                        row["unit_name"] = qty + " " + unit;
                        //MessageBox.Show("unit "+ row["unit_name"].ToString(), "");
                    }
                    ic.ivfDB.oJpxdDB.updateStatusPrintOKByID(id);
                    if (flagedit.Equals("edit"))
                    {
                        ic.ivfDB.oJpxdDB.updateStatusUpStockOKByID(id);
                    }
                    FrmReport frm = new FrmReport(ic);
                    frm.setStickerDrugReport(date, dt, cboLangSticker.Text.Trim());
                    frm.ShowDialog(this);
                }
            }
        }
        private void GrfOrder_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void ContextMenu_or_void(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            String id = "", status = "";
            rowOrder--;
            id = grfOrder[grfOrder.Row, colOrdid].ToString();
            status = grfOrder[grfOrder.Row, colOrdstatus].ToString();
            if (status.Equals("bloodlab") || status.Equals("Sperm Lab") || status.Equals("Embryo Lab") || status.Equals("Genetic Lab"))
            {
                ic.ivfDB.oJlabdDB.deleteByPk(id);
            }
            else if (status.Equals("specialitem"))
            {
                ic.ivfDB.ojsdDB.deleteByPk(id);
            }
            else if (status.Equals("px"))
            {
                ic.ivfDB.oJpxdDB.deleteByPk(id);
            }
            else if (status.Equals("package"))
            {
                ic.ivfDB.opkgsDB.deleteByPk(id);
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();
            grfOrder.Rows.Count = 1;
            if (vn.Length <= 0) return;
            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            //dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectSumQtyByVN(vn);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID(pttId);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            dtAll.Columns.Add("usage", typeof(String));
            dtAll.Columns.Add("usageE", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["usageE"] = "";
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["usageE"] = "";
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = row["TUsage"];
                row1["usageE"] = row["EUsage"];
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }
            foreach (DataRow row in dtpkg.Rows)
            {
                String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
                Decimal price = 0, pay1 = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
                Decimal.TryParse(row["price"].ToString(), out price);
                Decimal.TryParse(row["payment1"].ToString(), out pay1);
                Decimal.TryParse(row["payment2"].ToString(), out pay2);
                Decimal.TryParse(row["payment3"].ToString(), out pay3);
                Decimal.TryParse(row["payment4"].ToString(), out pay4);
                times = row["payment_times"].ToString();
                bill1 = row["P1BDetailID"].ToString();
                bill2 = row["P2BDetailID"].ToString();
                bill3 = row["P3BDetailID"].ToString();
                bill4 = row["P4BDetailID"].ToString();
                name = row["PackageName"].ToString();
                if (price > 0)
                {
                    if ((pay1 > 0) && bill1.Equals("0"))
                    {
                        pay = pay1;
                        name += "1/" + times;
                    }
                    else if ((pay2 > 0) && bill2.Equals("0"))
                    {
                        pay = pay2;
                        name += "2/" + times;
                    }
                    else if ((pay3 > 0) && bill3.Equals("0"))
                    {
                        pay = pay3;
                        name += "3/" + times;
                    }
                    else if ((pay4 > 0) && bill4.Equals("0"))
                    {
                        pay = pay4;
                        name += "4/" + times;
                    }
                    DataRow row1 = dtAll.NewRow();
                    row1["id"] = row["PCKSID"];
                    row1["itmid"] = row["PCKID"];
                    row1["lgid"] = "";
                    row1["name"] = name;
                    row1["price"] = pay;
                    row1["qty"] = "1";
                    row1["status"] = "package";
                    row1["row1"] = row["row1"];
                    row1["extra"] = "0";
                    row1["usage"] = "";
                    row1["usageE"] = "";
                    dtAll.Rows.InsertAt(row1, i);
                    i++;
                }
            }
            dtAll.DefaultView.Sort = "row1";
            DataView view = dtAll.DefaultView;
            view.Sort = "row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 14;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;

            grfOrder.Cols[colOrdName].Width = 280;
            grfOrder.Cols[colOrdPrice].Width = 120;
            grfOrder.Cols[colOrdQty].Width = 80;
            grfOrder.Cols[colOrdUsT].Width = 500;
            grfOrder.Cols[colOrdUsE].Width = 500;
            grfOrder.Cols[colOrdInclude].Width = 60;
            grfOrder.Cols[colOrdstatus].Width = 60;

            grfOrder.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOrder.Cols[colOrdName].Caption = "Name.";
            grfOrder.Cols[colOrdPrice].Caption = "Price";
            grfOrder.Cols[colOrdQty].Caption = "QTY";
            grfOrder.Cols[colOrdInclude].Caption = "Include Package";
            grfOrder.Cols[colOrdUsT].Caption = "Usage";
            grfOrder.Cols[colOrdUsE].Caption = "Usage";
            grfOrder.Cols[colOrdAmt].Caption = "Amount";
            //grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfOrder.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0;
                    Row row1 = grfOrder.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    row1[colOrdUsT] = row["usage"].ToString();
                    row1[colOrdUsE] = row["usageE"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";

                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["extra"].ToString().Equals("1"))
                    {
                        ext += (price * qty);
                    }
                    else
                    {
                        if (row["status"].ToString().Equals("package"))
                        {
                            inc += (price * qty);
                        }
                    }
                    row1[colOrdEdit] = "";
                    row1[0] = (i);
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            rowOrder = grfOrder.Rows.Count;
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colOrdrow1].Visible = false;
            grfOrder.Cols[colOrdlpid].Visible = false;
            grfOrder.Cols[colOrdid].Visible = false;
            grfOrder.Cols[colOrdEdit].Visible = false;
            grfOrder.Cols[colOrditmid].Visible = false;
            if (cboLangSticker.Text.Trim().Equals("English"))
            {
                grfOrder.Cols[colOrdUsT].Visible = false;
                grfOrder.Cols[colOrdUsE].Visible = true;
            }
            else
            {
                grfOrder.Cols[colOrdUsT].Visible = true;
                grfOrder.Cols[colOrdUsE].Visible = false;
            }
            
            grfOrder.Cols[colOrdUsT].AllowEditing = true;
            grfOrder.Cols[colOrdUsE].AllowEditing = true;
            grfOrder.Cols[colOrdName].AllowEditing = false;
            grfOrder.Cols[colOrdPrice].AllowEditing = false;
            grfOrder.Cols[colOrdQty].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            //UpdateTotals();
            String total = "";
            Decimal total1 = 0;
            //total = grfOrder[grfOrder.Rows.Count - 1, colOrdAmt] != null ? grfOrder[grfOrder.Rows.Count - 1, colOrdAmt].ToString() : "";
            total1 = inc + ext;
            //Decimal.TryParse(total, out total1);
            txtTotal.Value = total1.ToString("#,###.00");
            txtInclude.Value = inc.ToString("#,###.00");
            txtExtra.Value = ext.ToString("#,###.00");
        }
        private void UpdateTotals()
        {
            // clear existing totals
            //grfOrder.Subtotal(AggregateEnum.Clear);
            //grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colOrdAmt, "Total");
        }
        private void initGrfRx()
        {
            grfRx = new C1FlexGrid();
            grfRx.Font = fEdit;
            grfRx.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRx.Location = new System.Drawing.Point(0, 0);

            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);

            grfRx.DoubleClick += GrfRx_DoubleClick;
            //grfRx.AfterFilter += GrfRx_AfterFilter;

            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRx.ContextMenu = menuGw;
            pnRx.Controls.Add(grfRx);

            theme1.SetTheme(grfRx, "Office2010Black");

        }
        private void GrfRx_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRx.Col == colBlQty) return;
            setOrderRx();
        }
        private void setOrderRx()
        {
            if (grfRx.Row <= 0) return;
            if (grfRx[grfRx.Row, colBlId] == null) return;
            String chk = "", name = "", drugid = "", qty = "", include = "", usage = "";
            drugid = grfRx[grfRx.Row, colRxdId] != null ? grfRx[grfRx.Row, colRxdId].ToString() : "";
            qty = grfRx[grfRx.Row, colRxQty] != null ? grfRx[grfRx.Row, colRxQty].ToString() : "";
            include = grfRx[grfRx.Row, colRxInclude] != null ? grfRx[grfRx.Row, colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
            if (cboLangSticker.Text.Trim().Equals("English"))
            {
                usage = grfRx[grfRx.Row, colRxUsE] != null ? grfRx[grfRx.Row, colRxUsE].ToString() : "";
            }
            else
            {
                usage = grfRx[grfRx.Row, colRxUsT] != null ? grfRx[grfRx.Row, colRxUsT].ToString() : "";
            }
            //sep.Clear();
            if (include.Equals("1"))
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, ptt.patient_hn, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage,"");
            }
            else
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, ptt.patient_hn, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage,"");
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            setOrderRx();
        }
        private void setGrfRx()
        {
            //grfDept.Rows.Count = 7;
            //grfRx.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectBySockDrug1();

            grfRx.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRx.DataSource = dt;
            grfRx.Cols.Count = 9;
            CellStyle cs = grfRx.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRx.Cols[colRxName].Width = 300;
            grfRx.Cols[colRxInclude].Width = 60;
            grfRx.Cols[colRxPrice].Width = 80;
            grfRx.Cols[colRxRemark].Width = 100;
            grfRx.Cols[colRxUsE].Width = 400;
            grfRx.Cols[colRxUsT].Width = 400;
            grfRx.Cols[colRxQty].Width = 60;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";



            CellRange rg = grfRx.GetCellRange(2, colBlInclude, grfRx.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfRx.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfRx.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfRx.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfRx.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfRx.Cols[colRxName].Caption = "Name";
            grfRx.Cols[colRxInclude].Caption = "Include";
            grfRx.Cols[colRxPrice].Caption = "Price";
            grfRx.Cols[colRxQty].Caption = "QTY";
            grfRx.Cols[colRxRemark].Caption = "Remark";
            grfRx.Cols[colRxUsE].Caption = "Usage English.";
            grfRx.Cols[colRxUsT].Caption = "Usage Thai";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    grfRx[i, colBlId] = row["DUID"].ToString();
                    grfRx[i, colRxName] = row["DUName"].ToString();
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfRx[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRx[i, colRxQty] = "1";
                    grfRx[i, colBlRemark] = "";
                    grfRx[i, colRxUsE] = row["EUsage"].ToString();
                    grfRx[i, colRxUsT] = row["TUsage"].ToString();
                    //Row row1 = grfRx.Rows.Add();
                    //row1[colBlId] = row["DUID"].ToString();
                    //row1[colBlName] = row["DUName"].ToString();
                    //row1[colBlPrice] = row["Price"].ToString();
                    //row1[colBlRemark] = "";
                    //if (i == 1) continue;
                    //if (i == 2) continue;
                    grfRx[i, 0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
            grfRx.Cols[colBlId].Visible = false;
            grfRx.Cols[colBlRemark].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;
            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);
            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = true;
            grfRx.Cols[colRxUsE].AllowEditing = true;
            grfRx.Cols[colRxUsT].AllowEditing = true;

            FilterRow fr = new FilterRow(grfRx);
            grfRx.AllowFiltering = true;
            grfRx.AfterFilter += GrfRx_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfRx_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfRx.Cols.Fixed; col < grfRx.Cols.Count; ++col)
            {
                var filter = grfRx.Cols[col].ActiveFilter;
            }
        }
        private void TlpPatient_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            decimal hei = 0;
            hei = tlpPatient.Height;
            //label19.Text = hei.ToString();

        }
        private void BtnNoteAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                Note1 note = new Note1();
                note.active = "1";
                note.date_cancel = "";
                note.date_create = "";
                note.date_modi = "";
                note.note_1 = txtNote.Text;
                note.note_2 = "";
                note.note_id = txtNoteId.Text;
                note.remark = "";
                note.t_patient_id = ptt.t_patient_id;
                note.user_cancel = "";
                note.user_create = "";
                note.user_modi = "";
                note.status_all = chkNoteAll.Checked ? "1" : "0";
                note.b_service_point_id = "2120000000";
                ic.ivfDB.noteDB.insertNote(note, ic.cStf.staff_id);
                setGrfNote();
                txtNote.Value = "";
            }
        }
        private void initGrfNote()
        {
            grfNote = new C1FlexGrid();
            grfNote.Font = fEdit;
            grfNote.Dock = System.Windows.Forms.DockStyle.Fill;
            grfNote.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfImg.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            grfNote.DoubleClick += GrfNote_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnNote.Controls.Add(grfNote);

            theme1.SetTheme(grfNote, "Office2016Colorful");

        }
        private void GrfNote_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfNote.Row < 0) return;
            String id = grfNote[grfNote.Row, colNoteId] != null ? grfNote[grfNote.Row, colNoteId].ToString() : "";
            String note = grfNote[grfNote.Row, colNote] != null ? grfNote[grfNote.Row, colNote].ToString() : "";
            txtNoteId.Value = id;
            txtNote.Value = note;
        }
        private void setGrfNote()
        {
            grfNote.Clear();
            grfNote.Rows.Count = 1;
            grfNote.Cols.Count = 4;
            DataTable dt = ic.ivfDB.noteDB.selectByPttId(ptt.t_patient_id);

            grfNote.Rows.Count = dt.Rows.Count + 1;

            grfNote.Cols[colNoteId].Width = 250;
            grfNote.Cols[colNote].Width = 600;

            grfNote.ShowCursor = true;

            grfNote.Cols[colNote].Caption = "Note";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfNote[i, colNoteId] = row[ic.ivfDB.noteDB.note.note_id].ToString();
                grfNote[i, colNote] = row[ic.ivfDB.noteDB.note.note_1].ToString();
                grfNote[i, colNoteStatusAll] = row[ic.ivfDB.noteDB.note.status_all].ToString();
                i++;
            }
            grfNote.Cols[colNoteId].Visible = false;
            grfNote.Cols[colNoteStatusAll].Visible = false;
            grfNote.Cols[colNote].AllowEditing = false;

            theme1.SetTheme(grfNote, "Office2016DarkGray");
        }
        private void setChangeLanguage()
        {
            foreach (Row row in grfOrder.Rows)
            {
                String pxid = "", itmid = "", status = "", re = "", edit = "", usage = "";
                pxid = row[colOrdid] != null ? row[colOrdid].ToString() : "";
                if (pxid.Equals("")) continue;
                itmid = row[colOrditmid] != null ? row[colOrditmid].ToString() : "";
                status = row[colOrdstatus] != null ? row[colOrdstatus].ToString() : "";
                if (status.Equals("px"))
                {
                    OldStockDrug ostkd = new OldStockDrug();
                    ostkd = ic.ivfDB.oStkdDB.selectByPk1(itmid);
                    if (ostkd.DUID.Length <= 0) continue;
                    if (cboLangSticker.Text.Trim().Equals("English"))
                    {
                        row[colOrdUsE] = ostkd.EUsage;
                        re = ic.ivfDB.oJpxdDB.updateUsageEByID(pxid, ostkd.EUsage);
                    }
                    else
                    {
                        row[colOrdUsT] = ostkd.TUsage;
                        re = ic.ivfDB.oJpxdDB.updateUsageTByID(pxid, ostkd.TUsage);
                    }
                }
                

            }
        }
        private void CboLangSticker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cboLangSticker.Text.Trim().Equals("English"))
            {
                grfRx.Cols[colRxUsT].Visible = false;
                grfRx.Cols[colRxUsE].Visible = true;

                grfOrder.Cols[colOrdUsE].Visible = true;
                grfOrder.Cols[colOrdUsT].Visible = false;
                //grfRxSetD.Cols[colRxUsT].Visible = false;
                //grfRxSetD.Cols[colRxUsE].Visible = true;
            }
            else
            {
                grfRx.Cols[colRxUsT].Visible = true;
                grfRx.Cols[colRxUsE].Visible = false;

                grfOrder.Cols[colOrdUsE].Visible = false;
                grfOrder.Cols[colOrdUsT].Visible = true;
                //grfRxSetD.Cols[colRxUsT].Visible = true;
                //grfRxSetD.Cols[colRxUsE].Visible = false;
            }
            setChangeLanguage();
        }
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //ic.ivfDB.nurseFinish(txtVnOld.Text);
            ic.ivfDB.oJpxdDB.updateStatusFinishByVN(txtVn.Text);
            ic.ivfDB.vsDB.updateStatusPharmacyFinish(txtVn.Text);
            //VisitOld ovs = new VisitOld();
            //ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);
            //if (vs.VSID.Equals("999"))
            //{
                frmPharView.setGrfQuePublic();
                frmPharView.setGrfFinishPublic();
                menu.removeTab(tab);
                //return;
            //}
            //setGrfOrder(txtVn.Text);
        }

        private void FrmPharmaAdd_Load(object sender, EventArgs e)
        {
            sC.HeaderHeight = 0;
            sCOrder.HeaderHeight = 0;

            PrinterSettings settings1 = new PrinterSettings();
            settings1.DefaultPageSettings.PrinterSettings.PrinterName = ic.iniC.printerSticker;
            settings1.PrinterName = ic.iniC.printerSticker;

            Application.DoEvents();
            PrinterSettings settings2 = new PrinterSettings();
            //if (!vsOld.VSID.Equals("166"))        //      -0020
            if (!vs.vsid.Equals("166"))          //      +0020
            {
                lbPrinterStickerName.Text = settings1.DefaultPageSettings.PrinterSettings.PrinterName + "รอ รับชำระ ไม่สามารถพิมพ์ Sticker ได้";
            }
            else
            {
                lbPrinterStickerName.Text = settings1.DefaultPageSettings.PrinterSettings.PrinterName;
            }
            
            c1SplitterPanel1.SizeRatio = 5;
        }
    }
}
