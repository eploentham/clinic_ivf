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
            sql = "Select row_id, regisdate, idcard, hn, yot, name, surname, dbirth, age, phone, sex, status" +
                ", lastupdate, officer, blood, beActive, pg, tcname, agen, hnmale, namemale, hnfemale, namefemale, doctor, pttype " +
                ", namefemale " +
                "From opcard " +
                "Where status_convert = '0' " +
                "Order By regisdate ";

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
                    sql = "Update opcard Set status_convert = '1' Where row_id = '"+row["row_id"].ToString()+"'";
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
