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
    public partial class FrmLabReqAccept : Form
    {
        IvfControl ic;
        MainMenu menu;
        LabRequest lbReq;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colRqReqNum = 2, colRqHn = 3, colRqVn = 4, colRqName = 5, colPttName=6, colRqDate = 7, colRqRemark = 9, colDtrName=8, colDtrId=10, colStatusReq=11, colDob=12;

        C1FlexGrid grfReq;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;

        public FrmLabReqAccept(IvfControl ic, MainMenu m)
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
            txtDateEnd.Value = System.DateTime.Now;
            txtDateStart.Value = System.DateTime.Now;

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lbReq = new LabRequest();

            //btnNew.Click += BtnNew_Click;
            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);

            btnSearch.Click += BtnSearch_Click;
            timer = new Timer();
            timer.Interval = timerlab*1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

            initGrfReq();
            setGrfReq();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
        }
        private void setLabRequest(String pttName, String vn, String doctorId, String remark, String hn, String dobfemale)
        {
            lbReq.req_id = "";
            lbReq.req_code = ic.ivfDB.copDB.genReqDoc();
            lbReq.req_date = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            lbReq.hn_male = "";
            lbReq.name_male = "";
            lbReq.hn_female = hn;
            lbReq.name_female = pttName;
            lbReq.status_req = "1";
            lbReq.accept_date = "";
            lbReq.start_date = "";
            lbReq.result_date = "";
            lbReq.visit_id = "";
            lbReq.vn = vn;
            lbReq.active = "1";
            lbReq.remark = remark;
            lbReq.date_create = "";
            lbReq.date_modi = "";
            lbReq.date_cancel = "";
            lbReq.user_create = "";
            lbReq.user_modi = "";
            lbReq.user_cancel = "";
            lbReq.item_id = "112";      //OPU
            lbReq.lab_id = "";
            lbReq.dob_donor = "";
            lbReq.dob_female = dobfemale;
            lbReq.dob_male = "";
            lbReq.hn_donor = "";
            lbReq.name_donor = "";
            lbReq.doctor_id = doctorId;
        }
        private void initGrfReq()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfReq.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&รับ request", new EventHandler(ContextMenu_edit));
            menuGw.MenuItems.Add("&ป้อน LAB", new EventHandler(ContextMenu_Gw_Add));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfReq.ContextMenu = menuGw;
            gB.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", vn = "", remark = "", dtrid = "", dtrname = "", hn = "", statusReq = "", dob="";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colPttName] != null ? grfReq[grfReq.Row, colPttName].ToString() : "";
            vn = grfReq[grfReq.Row, colRqVn] != null ? grfReq[grfReq.Row, colRqVn].ToString() : "";
            remark = grfReq[grfReq.Row, colRqRemark] != null ? grfReq[grfReq.Row, colRqRemark].ToString() : "";
            dtrid = grfReq[grfReq.Row, colDtrId] != null ? grfReq[grfReq.Row, colDtrId].ToString() : "";
            dtrname = grfReq[grfReq.Row, colDtrName] != null ? grfReq[grfReq.Row, colDtrName].ToString() : "";
            hn = grfReq[grfReq.Row, colRqHn] != null ? grfReq[grfReq.Row, colRqHn].ToString() : "";
            statusReq = grfReq[grfReq.Row, colStatusReq] != null ? grfReq[grfReq.Row, colStatusReq].ToString() : "";
            dob = grfReq[grfReq.Row, colDob] != null ? grfReq[grfReq.Row, colDob].ToString() : "";
            if (statusReq.Equals("1"))
            {
                MessageBox.Show("รับ request ไปแล้ว", "");
                return;
            }
            if (MessageBox.Show("ต้องการ รับ request \n  req number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //grfReq.Rows.Remove(grfReq.Row);

                acceptLabOPUAdd(id, name, vn, dtrid, remark, hn, false, dob);
                setGrfReq();
            }
        }
        private void ContextMenu_Gw_Add(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", vn = "", remark = "", dtrid = "", dtrname = "", hn = "", statusReq = "", dob="";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colPttName] != null ? grfReq[grfReq.Row, colPttName].ToString() : "";
            vn = grfReq[grfReq.Row, colRqVn] != null ? grfReq[grfReq.Row, colRqVn].ToString() : "";
            remark = grfReq[grfReq.Row, colRqRemark] != null ? grfReq[grfReq.Row, colRqRemark].ToString() : "";
            dtrid = grfReq[grfReq.Row, colDtrId] != null ? grfReq[grfReq.Row, colDtrId].ToString() : "";
            dtrname = grfReq[grfReq.Row, colDtrName] != null ? grfReq[grfReq.Row, colDtrName].ToString() : "";
            hn = grfReq[grfReq.Row, colRqHn] != null ? grfReq[grfReq.Row, colRqHn].ToString() : "";
            statusReq = grfReq[grfReq.Row, colStatusReq] != null ? grfReq[grfReq.Row, colStatusReq].ToString() : "";
            dob = grfReq[grfReq.Row, colDob] != null ? grfReq[grfReq.Row, colDob].ToString() : "";
            if (statusReq.Equals("1"))
            {
                MessageBox.Show("รับ request ไปแล้ว", "");
                return;
            }
            if (MessageBox.Show("ต้องการ ป้อน LAB  \n  req number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //grfReq.Rows.Remove(grfReq.Row);

                acceptLabOPUAdd(id, name, vn, dtrid, remark, hn, true, dob);
                setGrfReq();
            }
        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfReq()
        {
            gB.Enabled = false;
            groupBox1.Enabled = false;
            try
            {
                String startdate = "", enddate = "";
                DateTime datestart, dateend;
                String datestart1 = "", dateend1 = "";
                if (DateTime.TryParse(txtDateStart.Text, out datestart))
                {
                    datestart1 = datestart.ToString("yyyy-MM-dd");
                }
                else
                {
                    datestart1 = ic.datetoDB(txtDateStart.Text);
                }
                if (DateTime.TryParse(txtDateEnd.Text, out datestart))
                {
                    dateend1 = datestart.ToString("yyyy-MM-dd");
                }
                else
                {
                    dateend1 = ic.datetoDB(txtDateEnd.Text);
                }
                grfReq.Clear();
                grfReq.Cols.Count = 13;
                grfReq.Rows.Count = 1;
                DataTable dt = new DataTable();
                grfReq.DataSource = null;
                dt = ic.ivfDB.oJsDB.selectByStatusUnAccept1(datestart1, dateend1);
                //grfExpn.Rows.Count = dt.Rows.Count + 1;
                //grfCu.Rows.Count = 41;
                //grfCu.Cols.Count = 4;
                C1TextBox txt = new C1TextBox();
                //C1ComboBox cboproce = new C1ComboBox();
                //ic.ivfDB.itmDB.setCboItem(cboproce);
                grfReq.Cols[colRqReqNum].Editor = txt;
                grfReq.Cols[colRqHn].Editor = txt;
                grfReq.Cols[colRqVn].Editor = txt;
                grfReq.Cols[colRqName].Editor = txt;

                grfReq.Cols[colRqHn].Width = 120;
                grfReq.Cols[colRqVn].Width = 120;
                grfReq.Cols[colRqName].Width = 120;
                grfReq.Cols[colRqDate].Width = 100;
                grfReq.Cols[colPttName].Width = 200;
                grfReq.Cols[colDtrName].Width = 200;

                grfReq.ShowCursor = true;
                //grdFlex.Cols[colID].Caption = "no";
                //grfDept.Cols[colCode].Caption = "รหัส";

                grfReq.Cols[colRqReqNum].Caption = "req number";
                grfReq.Cols[colRqHn].Caption = "HN";
                grfReq.Cols[colRqVn].Caption = "VN";
                grfReq.Cols[colRqName].Caption = "LAB Name";
                grfReq.Cols[colPttName].Caption = "Patient Name";
                grfReq.Cols[colRqDate].Caption = "Date";
                grfReq.Cols[colRqRemark].Caption = "Remark";
                grfReq.Cols[colDtrId].Caption = "Remark";
                grfReq.Cols[colDtrName].Caption = "Doctor";

                Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
                //rg1.Style = grfBank.Styles["date"];
                //grfCu.Cols[colID].Visible = false;
                int i = 1;
                foreach (DataRow row in dt.Rows)
                {
                    Row row1 = grfReq.Rows.Add();
                    row1[colRqId] = row["odsd_id"].ToString();
                    row1[colRqReqNum] = row["odsd_id"].ToString();
                    row1[colRqHn] = row["PIDS"].ToString();
                    row1[colRqVn] = row["VN"].ToString();
                    row1[colRqName] = row["SName"].ToString();
                    row1[colPttName] = row["pttname"].ToString();
                    row1[colRqDate] = ic.datetoShow(row["Date"].ToString());
                    row1[colDtrId] = row["dtrid"].ToString();
                    row1[colDtrName] = row["dtrname"].ToString();
                    row1[colRqRemark] = row["remark"].ToString();
                    row1[colStatusReq] = row["status_req_accept"].ToString();
                    row1[colDob] = row["dob"].ToString();
                    row1[0] = i;
                    if (row["status_req_accept"].ToString().Equals("1"))
                    {
                        grfReq.Rows[i].StyleNew.BackColor = color;
                    }

                    i++;
                }
                grfReq.Cols[colRqId].Visible = false;
                grfReq.Cols[colRqVn].Visible = false;
                grfReq.Cols[colDtrId].Visible = false;
                grfReq.Cols[colStatusReq].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message, "");
            }

            gB.Enabled = true;
            groupBox1.Enabled = true;
        }
        private LabOpu setOPU(String reqid)
        {
            LabOpu opu = new LabOpu();
            LabRequest lbreq = new LabRequest();
            lbreq = ic.ivfDB.lbReqDB.selectByPk1(reqid);
            opu.opu_id = "";
            opu.opu_code = ic.ivfDB.copDB.genOPUDoc();
            opu.embryo_freez_stage = "";
            opu.embryoid_freez_position = "";
            opu.hn_male = "";
            opu.hn_female = lbreq.hn_female;
            opu.name_male = "";
            opu.name_female = lbreq.name_female;
            opu.remark = lbreq.remark;
            opu.dob_female = lbreq.dob_female;
            opu.dob_male = "";
            opu.doctor_id = lbreq.doctor_id;
            opu.proce_id = "";
            opu.opu_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.req_id = reqid;
            //opu.dob_female = lbreq.dob_female;
            return opu;
        }
        private void acceptLabOPUAdd(String reqid,String name, String vn, String dtrid, String remark, String hn, Boolean flagOpen, String dobfemale)
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setLabRequest(name, vn, dtrid, remark, hn, dobfemale);
                String re = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, "");
                long chk1 = 0;
                if (long.TryParse(re, out chk1))
                {
                    String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestAccept(re, ic.cStf.staff_id);
                    String re4 = ic.ivfDB.lbReqDB.UpdateStatusRequestProcess(re, ic.cStf.staff_id);
                    String re2 = ic.ivfDB.lbReqDB.UpdateStatusRequestAcceptOld(reqid, re);
                    if (long.TryParse(re2, out chk1))
                    {
                        //LabOpu opu = new LabOpu();
                        //LabRequest lbreq = new LabRequest();
                        //lbreq = ic.ivfDB.lbReqDB.selectByPk1(reqId);
                        //opu.opu_id = "";
                        //opu.opu_code = ic.ivfDB.copDB.genOPUDoc();
                        //opu.embryo_freez_stage = "";
                        //opu.embryoid_freez_position = "";
                        //opu.hn_male = "";
                        //opu.hn_female = lbreq.hn_female;
                        //opu.name_male = "";
                        //opu.name_female = lbreq.name_female;
                        //opu.remark = "";
                        //opu.dob_female = "";
                        //opu.dob_male = "";
                        //opu.doctor_id = lbreq.doctor_id;
                        //opu.proce_id = "";
                        //opu.opu_date = DateTime.Now.Year.ToString()+"-"+ System.DateTime.Now.ToString("MM-dd");
                        //opu.req_id = reqId;
                        LabOpu opu = setOPU(re);
                        String re3 = ic.ivfDB.opuDB.insert(opu, ic.cStf.staff_id);
                        if (long.TryParse(re3, out chk1))
                        {
                            setGrfReq();
                            if (flagOpen)
                            {
                                FrmLabOPUAdd frm1 = new FrmLabOPUAdd(ic, "", re3);
                                String txt = "";
                                if (!name.Equals(""))
                                {
                                    txt = "ป้อน LAB OPU " + name;
                                }
                                else
                                {
                                    txt = "ป้อน LAB OPU ใหม่ ";
                                }

                                frm1.FormBorderStyle = FormBorderStyle.None;
                                menu.AddNewTab(frm1, txt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error gen OPU", "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถ update status accept", "error");
                    }
                }
                
                //int chk = 0;                
            }
        }
        private void FrmLabReqAccept_Load(object sender, EventArgs e)
        {

        }
    }
}
