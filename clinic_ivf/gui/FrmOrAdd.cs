using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmOrAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;

        String pttId = "", webcamname = "", vsid = "", flagedit = "", pApmId = "";
        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder, grfRxSetD, grfNote, grfpApmAll;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        Image imgCorr, imgTran;
        public FrmOrAdd(IvfControl ic, MainMenu m, String pttid, String vsid, String flagedit)
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
            //theme1.SetTheme(tabOrder, "MacSilver");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;

            initGrfBloodLab();
            setGrfBloodLab();
            initGrfSpermLab();
            setGrfSperm();
            initGrfEmbryoLab();
            setGrfEmbryo();
            initGrfGeneticLab();
            initGrfSpecialLab();
            initGrfRx();
            initGrfOrder();
            setGrfGenetic();
            setGrfSpecial();
            setGrfRx();
            initGrfNote();
            setGrfNote();
            initGrfAdm();
            setGrfpApmAll();
        }
        private void initGrfAdm()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);


            grfpApmAll.DoubleClick += GrfAdm_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnAdm.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }

        private void GrfAdm_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfpApmAll()
        {
            //grfDept.Rows.Count = 7;
            grfpApmAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByPtt(ptt.t_patient_id);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmAll.Rows.Count = 1;
            grfpApmAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmAll.Cols[colApmNotice].Editor = txt;
            grfpApmAll.Cols[colApmAppointment].Editor = txt;
            grfpApmAll.Cols[colApmDoctor].Editor = txt;
            Column colE21 = grfpApmAll.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApmAll.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApmAll.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApmAll.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApmAll.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApmAll.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApmAll.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApmAll.Cols[colApmDate].Width = 100;
            grfpApmAll.Cols[colApmTime].Width = 80;
            grfpApmAll.Cols[colApmAppointment].Width = 120;
            grfpApmAll.Cols[colApmDoctor].Width = 100;
            grfpApmAll.Cols[colApmSp].Width = 80;
            grfpApmAll.Cols[colApmNotice].Width = 200;
            grfpApmAll.Cols[colE2].Width = 60;
            grfpApmAll.Cols[colLh].Width = 60;
            grfpApmAll.Cols[colEndo].Width = 60;
            grfpApmAll.Cols[colPrl].Width = 60;
            grfpApmAll.Cols[colFsh].Width = 60;
            grfpApmAll.Cols[colRt].Width = 60;
            grfpApmAll.Cols[colLt].Width = 60;

            grfpApmAll.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApmAll.Cols[colApmDate].Caption = "Date";
            grfpApmAll.Cols[colApmTime].Caption = "time";
            grfpApmAll.Cols[colApmAppointment].Caption = "นัด";
            grfpApmAll.Cols[colApmDoctor].Caption = "Doctor";
            grfpApmAll.Cols[colApmSp].Caption = "จุดบริการ";
            grfpApmAll.Cols[colApmNotice].Caption = "แจ้ง";
            grfpApmAll.Cols[colE2].Caption = "E2";
            grfpApmAll.Cols[colLh].Caption = "LH";
            grfpApmAll.Cols[colEndo].Caption = "Endo";
            grfpApmAll.Cols[colPrl].Caption = "PRL";
            grfpApmAll.Cols[colFsh].Caption = "FSH";
            grfpApmAll.Cols[colRt].Caption = "Rt";
            grfpApmAll.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit_papm));
            grfpApmAll.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmAll.Rows.Add();
                row1[0] = i;
                row1[colApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colApmAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colApmDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colApmSp] = row["service_point_description"].ToString();
                row1[colApmNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

                //row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString();
                //row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString();
                //row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo].ToString();
                //row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString();
                //row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString();
                //row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString();
                //row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString();

                row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.endo].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfpApmAll.Cols[colE2].AllowEditing = false;
            grfpApmAll.Cols[colLh].AllowEditing = false;
            grfpApmAll.Cols[colEndo].AllowEditing = false;
            grfpApmAll.Cols[colPrl].AllowEditing = false;
            grfpApmAll.Cols[colFsh].AllowEditing = false;
            grfpApmAll.Cols[colRt].AllowEditing = false;
            grfpApmAll.Cols[colLt].AllowEditing = false;
            //menuGw = new ContextMenu();
            //grfpApmAll.ContextMenu = menuGw;
            grfpApmAll.Cols[colApmId].Visible = false;
            theme1.SetTheme(grfpApmAll, ic.theme);

        }
        private void ContextMenu_edit_papm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmAll[grfpApmAll.Row, colApmId] != null ? grfpApmAll[grfpApmAll.Row, colApmId].ToString() : "";
            pApmId = id;
            FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, pApmId, pttId, vsid);
            frm.ShowDialog(this);
            setGrfpApmAll();

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

        private void GrfRx_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfRx.Cols.Fixed; col < grfRx.Cols.Count; ++col)
            {
                var filter = grfRx.Cols[col].ActiveFilter;
            }
        }

        private void GrfRx_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRx.Row < 0) return;
            String duid = "";
        }

        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            if (grfRx.Row <= 0) return;
            if (grfRx[grfRx.Row, colBlId] == null) return;
            String chk = "", name = "", drugid = "", qty = "", include = "", usage = "";
            drugid = grfRx[grfRx.Row, colRxdId] != null ? grfRx[grfRx.Row, colRxdId].ToString() : "";
            qty = grfRx[grfRx.Row, colRxQty] != null ? grfRx[grfRx.Row, colRxQty].ToString() : "";
            include = grfRx[grfRx.Row, colRxInclude] != null ? grfRx[grfRx.Row, colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
            if (cboLangSticker.Text.Equals("English"))
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
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage);
            }
            else
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage);
            }

            setGrfOrder(txtVnOld.Text);
            //}
            //ic.ivfDB.PxAdd(drugid,)
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
            grfRx.Cols[colRxUsE].Width = 200;
            grfRx.Cols[colRxUsT].Width = 200;
            grfRx.Cols[colRxQty].Width = 60;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRx.Cols[colRxName].Caption = "Name";
            grfRx.Cols[colRxInclude].Caption = "Include";
            grfRx.Cols[colRxPrice].Caption = "Price";
            grfRx.Cols[colRxQty].Caption = "QTY";
            grfRx.Cols[colRxRemark].Caption = "Remark";
            grfRx.Cols[colRxUsE].Caption = "Usage English";
            grfRx.Cols[colRxUsT].Caption = "Usage Thai";

            CellRange rg = grfRx.GetCellRange(2, colBlInclude, grfRx.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfRx.Styles["bool"];
            int i = 1;
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
            FilterRowUnBound fr = new FilterRowUnBound(grfRx);
            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = true;
            grfRx.AllowFiltering = true;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfSpecialLab()
        {
            grfSpecial = new C1FlexGrid();
            grfSpecial.Font = fEdit;
            grfSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpecial.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfSpecial);

            grfSpecial.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_se_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSpecial.ContextMenu = menuGw;
            pnSpecial.Controls.Add(grfSpecial);

            theme1.SetTheme(grfSpecial, "Office2010Barbie");

        }
        private void ContextMenu_order_se_set(object sender, System.EventArgs e)
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString());
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSpecial()
        {
            //grfDept.Rows.Count = 7;
            grfSpecial.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem2();

            grfSpecial.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfSpecial.DataSource = dt;
            grfSpecial.Cols.Count = 7;
            CellStyle cs = grfSpecial.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSpecial.Cols[colBlName].Width = 320;
            grfSpecial.Cols[colBlQty].Width = 60;
            grfSpecial.Cols[colBlInclude].Width = 80;
            grfSpecial.Cols[colBlPrice].Width = 80;
            grfSpecial.Cols[colBlRemark].Width = 200;

            grfSpecial.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSpecial.Cols[colBlName].Caption = "Name";
            grfSpecial.Cols[colBlInclude].Caption = "Include";
            grfSpecial.Cols[colBlPrice].Caption = "Price";
            grfSpecial.Cols[colBlRemark].Caption = "Remark";
            grfSpecial.Cols[colBlQty].Caption = "QTY";

            CellRange rg = grfSpecial.GetCellRange(2, colBlInclude, grfSpecial.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSpecial.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oSItmDB.sitm.Price].ToString(), out aaa);
                    grfSpecial[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSpecial[i, colBlId] = row[ic.ivfDB.oSItmDB.sitm.SID].ToString();
                    grfSpecial[i, colBlName] = row[ic.ivfDB.oSItmDB.sitm.SName].ToString();
                    grfSpecial[i, colBlQty] = "1";
                    grfSpecial[i, colBlRemark] = row["bilgrpname"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSpecial);
            grfSpecial.Cols[colBlId].Visible = false;
            //grfSpecial.Cols[colBlInclude].Visible = false;
            //grfSpecial.Cols[colBlPrice].Visible = false;

            grfSpecial.Cols[colBlName].AllowEditing = false;
            grfSpecial.Cols[colBlPrice].AllowEditing = false;
            grfSpecial.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfGeneticLab()
        {
            grfGenetic = new C1FlexGrid();
            grfGenetic.Font = fEdit;
            grfGenetic.Dock = System.Windows.Forms.DockStyle.Fill;
            grfGenetic.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfGenetic);

            grfGenetic.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_ge_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfGenetic.ContextMenu = menuGw;
            pnGenetic.Controls.Add(grfGenetic);

            theme1.SetTheme(grfGenetic, "RainerOrange");

        }
        private void ContextMenu_order_ge_set(object sender, System.EventArgs e)
        {
            if (grfGenetic.Row <= 0) return;
            if (grfGenetic[grfGenetic.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfGenetic[grfGenetic.Row, colBlId].ToString();
            include = grfGenetic[grfGenetic.Row, colBlInclude] != null ? grfGenetic[grfGenetic.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfGenetic[grfGenetic.Row, colBlQty] != null ? grfGenetic[grfGenetic.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfGenetic()
        {
            //grfDept.Rows.Count = 7;
            grfGenetic.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByGeneticLab1();

            grfGenetic.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfGenetic.DataSource = dt;
            grfGenetic.Cols.Count = 7;
            CellStyle cs = grfGenetic.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfGenetic.Cols[colBlName].Width = 320;
            grfGenetic.Cols[colBlInclude].Width = 120;
            grfGenetic.Cols[colBlPrice].Width = 80;
            grfGenetic.Cols[colBlRemark].Width = 100;

            grfGenetic.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfGenetic.Cols[colBlName].Caption = "Name";
            grfGenetic.Cols[colBlInclude].Caption = "Include";
            grfGenetic.Cols[colBlPrice].Caption = "Price";
            grfGenetic.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfGenetic.GetCellRange(2, colBlInclude, grfGenetic.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfGenetic.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfGenetic[i, colBlPrice] = aaa.ToString("#,##0");
                    grfGenetic[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfGenetic[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfGenetic[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfGenetic);
            grfGenetic.Cols[colBlId].Visible = false;
            //grfGenetic.Cols[colBlInclude].Visible = false;
            //grfGenetic.Cols[colBlPrice].Visible = false;

            grfGenetic.Cols[colBlName].AllowEditing = false;
            grfGenetic.Cols[colBlPrice].AllowEditing = false;
            grfGenetic.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfEmbryoLab()
        {
            grfEmbryo = new C1FlexGrid();
            grfEmbryo.Font = fEdit;
            grfEmbryo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEmbryo.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfEmbryo);

            grfEmbryo.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_em_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfEmbryo.ContextMenu = menuGw;
            pnEmbryo.Controls.Add(grfEmbryo);

            theme1.SetTheme(grfEmbryo, "ShinyBlue");

        }
        private void ContextMenu_order_em_set(object sender, System.EventArgs e)
        {
            if (grfEmbryo.Row <= 0) return;
            if (grfEmbryo[grfEmbryo.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfEmbryo[grfEmbryo.Row, colBlId].ToString();
            include = grfEmbryo[grfEmbryo.Row, colBlInclude] != null ? grfEmbryo[grfEmbryo.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfEmbryo[grfEmbryo.Row, colBlQty] != null ? grfEmbryo[grfEmbryo.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfEmbryo()
        {
            //grfDept.Rows.Count = 7;
            grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByEmbryoLab1();

            grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.DataSource = dt;
            grfEmbryo.Cols.Count = 7;
            CellStyle cs = grfEmbryo.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEmbryo.Cols[colBlName].Width = 320;
            grfEmbryo.Cols[colBlInclude].Width = 120;
            grfEmbryo.Cols[colBlPrice].Width = 80;
            grfEmbryo.Cols[colBlRemark].Width = 100;

            grfEmbryo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfEmbryo.Cols[colBlName].Caption = "Name";
            grfEmbryo.Cols[colBlInclude].Caption = "Include";
            grfEmbryo.Cols[colBlPrice].Caption = "Price";
            grfEmbryo.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfEmbryo.GetCellRange(2, colBlInclude, grfEmbryo.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfEmbryo.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfEmbryo[i, colBlPrice] = aaa.ToString("#,##0");
                    grfEmbryo[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfEmbryo[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfEmbryo[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfEmbryo);
            grfEmbryo.Cols[colBlId].Visible = false;
            //grfEmbryo.Cols[colBlInclude].Visible = false;
            //grfEmbryo.Cols[colBlPrice].Visible = false;

            grfEmbryo.Cols[colBlName].AllowEditing = false;
            grfEmbryo.Cols[colBlPrice].AllowEditing = false;
            grfEmbryo.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfSpermLab()
        {
            grfSperm = new C1FlexGrid();
            grfSperm.Font = fEdit;
            grfSperm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSperm.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfSperm);

            grfSperm.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_sp_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSperm.ContextMenu = menuGw;
            pnSperm.Controls.Add(grfSperm);

            theme1.SetTheme(grfSperm, "Office2010Green");

        }
        private void ContextMenu_order_sp_set(object sender, System.EventArgs e)
        {
            if (grfSperm.Row <= 0) return;
            if (grfSperm[grfSperm.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfSperm[grfSperm.Row, colBlId].ToString();
            include = grfSperm[grfSperm.Row, colBlInclude] != null ? grfSperm[grfSperm.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSperm[grfSperm.Row, colBlQty] != null ? grfSperm[grfSperm.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSperm()
        {
            //grfDept.Rows.Count = 7;
            grfSperm.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectBySpermLab1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSperm.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfSperm.Cols.Count = 7;
            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSperm.Cols[colBlName].Width = 320;
            grfSperm.Cols[colBlInclude].Width = 120;
            grfSperm.Cols[colBlPrice].Width = 80;
            grfSperm.Cols[colBlRemark].Width = 100;

            grfSperm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSperm.Cols[colBlName].Caption = "Name";
            grfSperm.Cols[colBlInclude].Caption = "Include";
            grfSperm.Cols[colBlPrice].Caption = "Price";
            grfSperm.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfSperm.GetCellRange(2, colBlInclude, grfSperm.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfSperm[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSperm[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfSperm[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfSperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSperm);
            grfSperm.Cols[colBlId].Visible = false;
            //grfSperm.Cols[colBlInclude].Visible = false;
            //grfSperm.Cols[colBlPrice].Visible = false;

            grfSperm.Cols[colBlName].AllowEditing = false;
            grfSperm.Cols[colBlPrice].AllowEditing = false;
            grfSperm.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfBloodLab()
        {
            grfBloodLab = new C1FlexGrid();
            grfBloodLab.Font = fEdit;
            grfBloodLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBloodLab.Location = new System.Drawing.Point(0, 0);

            FilterRow fr = new FilterRow(grfBloodLab);

            grfBloodLab.DoubleClick += GrfBloodLab_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            }

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBloodLab.ContextMenu = menuGw;
            pnBloodLab.Controls.Add(grfBloodLab);

            theme1.SetTheme(grfBloodLab, "Office2010Red");

        }
        private void ContextMenu_order_bl_set(object sender, System.EventArgs e)
        {
            if (grfBloodLab.Row <= 0) return;
            if (grfBloodLab[grfBloodLab.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfBloodLab[grfBloodLab.Row, colBlId].ToString();
            include = grfBloodLab[grfBloodLab.Row, colBlInclude] != null ? grfBloodLab[grfBloodLab.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfBloodLab[grfBloodLab.Row, colBlQty] != null ? grfBloodLab[grfBloodLab.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void GrfBloodLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfBloodLab()
        {
            //grfDept.Rows.Count = 7;
            grfBloodLab.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByBloodLab1();
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grfBloodLab.Cols.Count = 7;

            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfBloodLab.Cols[colBlName].Width = 330;
            grfBloodLab.Cols[colBlInclude].Width = 120;
            grfBloodLab.Cols[colBlPrice].Width = 80;
            grfBloodLab.Cols[colBlRemark].Width = 100;

            grfBloodLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfBloodLab.Cols[colBlName].Caption = "Name";
            grfBloodLab.Cols[colBlInclude].Caption = "Include";
            grfBloodLab.Cols[colBlPrice].Caption = "Price";
            grfBloodLab.Cols[colBlQty].Caption = "QTY";
            grfBloodLab.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfBloodLab.GetCellRange(2, colBlInclude, grfBloodLab.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfBloodLab[i, colBlPrice] = aaa.ToString("#,##0");
                    grfBloodLab[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfBloodLab[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfBloodLab[i, colBlQty] = "1";

                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfBloodLab);
            grfBloodLab.Cols[colBlId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grfBloodLab.Cols[colBlName].AllowEditing = false;
            grfBloodLab.Cols[colBlPrice].AllowEditing = false;
            grfBloodLab.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void FrmOrAdd_Load(object sender, EventArgs e)
        {

        }

    }
}
