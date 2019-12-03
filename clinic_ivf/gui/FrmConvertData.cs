using clinic_ivf.control;
using clinic_ivf.objdb;
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
    public partial class FrmConvertData : Form
    {
        IvfControl ic;
        public FrmConvertData(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            pB1.Hide();

            txtShost.Value = "192.168.10.4";
            txtSdatabase.Value = "ivf";
            txtSuser.Value = "root";
            txtSpassword.Value = "ivf2017";
            txtSport.Value = "3306";

            ic.ivfDB.fpfDB.setCboPrefix(cboPrefix,"");

            btnConvertDonor.Click += BtnConvertDonor_Click;
            btnTestConnection.Click += BtnTestConnection_Click;
            btnConvertVisit.Click += BtnConvertVisit_Click;
            btnConvertApm.Click += BtnConvertApm_Click;
        }

        private void BtnConvertApm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ConnectDB connS;
            pB1.Show();
            pB1.Minimum = 0;
            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            DataTable dtPtt = new DataTable();
            String sql = "";
            sql = "Select * " +
                "From t_patient ";
            dtPtt = connS.selectData(connS.conn, sql);
            DataTable dtVs = new DataTable();
            sql = "Select * " +
                "From t_patient ";
            dtVs = connS.selectData(connS.conn, sql);

            DataTable dtApm = new DataTable();
            sql = "Select ID, PID, PIDS, AppTime, DATE_FORMAT(AppDate, '%Y-%m-%d') as AppDate, Doctor, Status, PatientName, MobilePhoneNo, PName, PSurname,  HormoneTest, TVS, OPU, OPUTime, OPURemark, ET_FET, ET_FET_Time, BetaHCG, Other, OtherRemark, Comment  " +
                "From Appointment ";
            //sql = "Select ID, PID, PIDS, AppTime, Doctor, Status, PatientName, MobilePhoneNo, PName, PSurname,  HormoneTest, TVS, OPU, OPUTime, OPURemark, ET_FET, ET_FET_Time, BetaHCG, Other, OtherRemark, Comment  " +
            //    "From Appointment ";
            dtApm = connS.selectData(connS.conn, sql);

            if (dtApm.Rows.Count > 0)
            {
                pB1.Maximum = dtApm.Rows.Count + 1;
                //sql = "Delete From t_patient Where status_convert = '1' ";
                //connS.ExecuteNonQuery(ic.conn.conn, sql);
                foreach (DataRow row in dtApm.Rows)
                {
                    String time = "", pttid="", dtr="";
                    time = "0"+row["AppTime"].ToString();
                    if (time.Length >= 5)
                    {
                        time = time.Substring(time.Length - 5);
                    }

                    DataRow[] resPtt = dtPtt.Select("patient_hn = '" + row["PIDS"].ToString() + "'");
                    if (resPtt.Length > 0)
                    {
                        try
                        {
                            pttid = resPtt[0]["PIDS"].ToString();
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                    //DataRow[] resVs = dtVs.Select("PIDS = '" + row["PIDS"].ToString() + "'");
                    //if (resPtt.Length > 0)
                    //{
                    //    pttid = resPtt[0]["PIDS"].ToString();
                    //}
                    //Patient ptt = new Patient();
                    //ptt = ic.ivfDB.pttDB.selectByHn(row["PIDS"].ToString());

                    PatientAppointment pApm = new PatientAppointment();
                    pApm.t_patient_appointment_id = "";
                    pApm.t_patient_id = pttid;
                    pApm.patient_appoint_date_time = ic.datetoDB(row["AppDate"].ToString());
                    pApm.patient_appointment_date = ic.datetoDB(row["AppDate"].ToString());
                    pApm.patient_appointment_time = time;
                    pApm.patient_appointment = row["Comment"].ToString();
                    pApm.patient_appointment_doctor = row["Doctor"].ToString().Trim().Equals("DR. Thitikorn") ? "1" : row["Doctor"].ToString().Trim().Equals("DR. Thitikorn Wanichkul") ? "1" : 
                        row["Doctor"].ToString().Trim().Equals("Thitikorn") ? "1" : row["Doctor"].ToString().Trim().Equals("DR. Wisut") ? "2" : row["Doctor"].ToString().Trim().Equals("DR. Visut Suvithayasiri") ? "2" :
                        row["Doctor"].ToString().Trim().Equals("DR. Sakchai") ? "5" : row["Doctor"].ToString().Trim().Equals("DR. Niwat") ? "3" : row["Doctor"].ToString().Trim().Equals("DR. Niwar") ? "3" : "0";
                    pApm.patient_appointment_servicepoint = "2120000002";
                    pApm.patient_appointment_notice = row["Comment"].ToString();
                    pApm.t_visit_id = "";
                    pApm.patient_appointment_vn = "";
                    pApm.remark = row["OtherRemark"].ToString();
                    pApm.opu_remark = row["OPURemark"].ToString();
                    pApm.opu_time = row["OPUTime"].ToString();
                    pApm.opu = row["OPU"].ToString();
                    pApm.hormone_test = row["HormoneTest"].ToString();
                    pApm.tvs = row["TVS"].ToString();
                    //pApm.et = row["HormoneTest"].ToString();
                    pApm.fet = row["ET_FET"].ToString();
                    pApm.fet_time = row["ET_FET_Time"].ToString();
                    pApm.beta_hgc = row["BetaHCG"].ToString();
                    pApm.other = row["Other"].ToString();
                    pApm.other_remark = row["OtherRemark"].ToString();
                    pApm.status_convert = "1";
                    pApm.active = row["Status"].ToString().Equals("1") ? "1" : "3";
                    pApm.patient_hn = row["PIDS"].ToString();
                    ic.ivfDB.pApmDB.insertPatientAppointment(pApm, "");

                    pB1.Value++;
                }
            }
            pB1.Hide();
        }
        
        private void BtnConvertVisit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ConnectDB connS;
            pB1.Show();
            pB1.Minimum = 0;
            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            DataTable dtS = new DataTable();
            String sql = "";
            sql = "Select * " +
                "From Visit ";

            dtS = connS.selectData(connS.conn, sql);
            if (dtS.Rows.Count > 0)
            {
                pB1.Maximum = dtS.Rows.Count + 1;
                //sql = "Delete From t_patient Where status_convert = '1' ";
                //connS.ExecuteNonQuery(ic.conn.conn, sql);
                foreach (DataRow row in dtS.Rows)
                {
                    Visit vs = new Visit();
                    vs.t_visit_id = "";
                    vs.visit_vn = row["VN"].ToString();
                    vs.visit_hn = row["PIDS"].ToString();
                    vs.visit_begin_visit_time = row["VDate"].ToString();
                    vs.f_visit_type_id = "1";
                    vs.b_service_point_id = "2120000002";

                    ic.ivfDB.vsDB.insertVisit(vs, "");
                    
                    pB1.Value++;
                }
            }
            pB1.Hide();
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ConnectDB connS;


            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            connS.conn.Open();
            if(connS.conn.State == ConnectionState.Open)
            {
                listBox1.Items.Add("connect OK");
            }
            else
            {
                listBox1.Items.Add("connect not OK");
            }
            connS.conn.Close();
        }

        private void BtnConvertDonor_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ConnectDB connS;
            pB1.Show();
            pB1.Minimum = 0;
            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            DataTable dtS = new DataTable();
            String sql = "";
            sql = "Select * " +
                "From Patient " ;

            dtS = connS.selectData(connS.conn,sql);
            if (dtS.Rows.Count > 0)
            {
                pB1.Maximum = dtS.Rows.Count+1;
                //sql = "Delete From t_patient Where status_convert = '1' ";
                //connS.ExecuteNonQuery(ic.conn.conn, sql);
                foreach(DataRow row in dtS.Rows)
                {
                    Patient ptt = new Patient();
                    ptt.t_patient_id = "";
                    ptt.patient_hn = row["PIDS"].ToString();
                    ptt.patient_firstname_e = row["PName"].ToString();
                    ptt.patient_lastname_e = row["PSurname"].ToString();
                    ptt.patient_birthday = row["DateofBirth"].ToString();
                    ptt.mobile1 = "";
                    ptt.f_sex_id = row["SexID"].ToString();
                    ptt.agent = row["agentID"].ToString();
                    ptt.patient_type = row["PatientTypeID"].ToString();
                    ptt.patient_group ="";
                    ptt.patient_private_doctor = "";
                    ptt.status_convert = "1";
                    ptt.remark = "";
                    ptt.passport = row["IDNumber"].ToString();
                    ptt.f_patient_prefix_id = row["SurfixID"].ToString();
                    ptt.f_patient_nation_id = row["Nationality"].ToString();
                    ptt.patient_tambon = row["District"].ToString();
                    ptt.patient_changwat = row["Province"].ToString();
                    ptt.status_convert = "1";
                    ptt.contact_namet = row["EmergencyPersonalContact"].ToString();
                    
                    ic.ivfDB.pttDB.insertPatient(ptt, "");
                    //sql = "Update opcard Set status_convert = '1' Where row_id = '"+row["row_id"].ToString()+"'";
                    //connS.ExecuteNonQuery(connS.conn, sql);
                    pB1.Value++;
                }
                
            }
            pB1.Hide();
        }
        private void convertPtt()
        {
            ConnectDB connS;
            pB1.Show();
            pB1.Minimum = 0;
            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            DataTable dtS = new DataTable();
            String sql = "";
            sql = "Select row_id, regisdate, idcard, hn, yot, name, surname, dbirth, age, phone, sex, status" +
                ", lastupdate, officer, blood, beActive, pg, tcname, agen, hnmale, namemale, hnfemale, namefemale, doctor, pttype " +
                ", namefemale " +
                "From opcard " +
                "Where status_convert = '0' " +
                "Order By regisdate ";

            dtS = connS.selectData(connS.conn, sql);
            if (dtS.Rows.Count > 0)
            {
                pB1.Maximum = dtS.Rows.Count + 1;
                //sql = "Delete From t_patient Where status_convert = '1' ";
                //connS.ExecuteNonQuery(ic.conn.conn, sql);
                foreach (DataRow row in dtS.Rows)
                {
                    Patient ptt = new Patient();
                    ptt.t_patient_id = "";
                    ptt.patient_hn = row["hn"].ToString();
                    ptt.patient_firstname_e = row["name"].ToString();
                    ptt.patient_lastname_e = row["surname"].ToString();
                    ptt.patient_birthday = row["dbirth"].ToString();
                    ptt.mobile1 = row["phone"].ToString();
                    ptt.f_sex_id = row["sex"].ToString().Equals("M") ? "2100000001" : "2100000002";
                    ptt.agent = row["agen"].ToString();
                    ptt.patient_type = row["pttype"].ToString();
                    ptt.patient_group = row["pg"].ToString();
                    ptt.patient_private_doctor = row["doctor"].ToString();
                    ptt.status_convert = "1";
                    ptt.remark = row["tcname"].ToString();
                    ptt.pid = row["idcard"].ToString();
                    ptt.f_patient_prefix_id = ic.getC1Combo(cboPrefix, row["yot"].ToString());
                    ic.ivfDB.pttDB.insertPatient(ptt, "");
                    sql = "Update opcard Set status_convert = '1' Where row_id = '" + row["row_id"].ToString() + "'";
                    connS.ExecuteNonQuery(connS.conn, sql);
                    pB1.Value++;
                }

            }
            pB1.Hide();
        }
        private void FrmConvertData_Load(object sender, EventArgs e)
        {

        }
    }
}
