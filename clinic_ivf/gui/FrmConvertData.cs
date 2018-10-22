using clinic_ivf.control;
using clinic_ivf.objdb;
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
            

            connS = new ConnectDB(ic.iniC);
            connS.conn.ConnectionString = "Server=" + txtShost.Text + ";Database=" + txtSdatabase.Text + ";Uid=" + txtSuser.Text + ";Pwd=" + txtSpassword.Text +
                ";port = " + txtSport.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";

            DataTable dtS = new DataTable();
            String sql = "";
            sql = "Select regisdate, idcard, hn, yot, name, surname, dbirth, age, phone, sex, status" +
                ", lastupdate, officer, blood, beActive, pg, tcname, agen, hnmale, namemale, hnfemale, namefemale, doctor, pttype " +
                ", namefemale, doctor, pttype " +
                "From opcard " +
                "Order By regisdate ";

            dtS = connS.selectData(connS.conn,sql);
            if (dtS.Rows.Count > 0)
            {

            }

        }

        private void FrmConvertData_Load(object sender, EventArgs e)
        {

        }
    }
}
