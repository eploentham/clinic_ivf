using C1.Win.C1Input;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class JobPxDB
    {
        public JobPx jobpx;
        ConnectDB conn;
        public List<JobPx> lJobPx;
        public JobPxDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jobpx = new JobPx();
            lJobPx = new List<JobPx>();
            jobpx.VN = "VN";
            jobpx.Status = "Status";
            jobpx.Include_Pkg_Price = "Include_Pkg_Price";
            jobpx.Extra_Pkg_Price = "Extra_Pkg_Price";
            jobpx.Total_Price = "Total_Price";
            jobpx.Date = "Date";
            jobpx.PID = "PID";
            jobpx.PIDS = "PIDS";                        

            jobpx.table = "JobPx";
            jobpx.pkField = "VN";
        }
        private void chkNull(JobPx p)
        {
            long chk = 0;
            decimal chk1 = 0;

            //p.Status = p.Status == null ? "" : p.Status;
            //p.Include_Pkg_Price = p.Include_Pkg_Price == null ? "" : p.PID;
            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            //p.VN = p.VN == null ? "0" : p.VN;
            //p.Extra_Pkg_Price = p.Extra_Pkg_Price == null ? "" : p.Extra_Pkg_Price;
            p.Date = p.Date == null ? "" : p.Date;
            p.remark = p.remark == null ? "" : p.remark;

            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            //p.Total_Price = long.TryParse(p.Total_Price, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";

            p.Include_Pkg_Price = decimal.TryParse(p.Include_Pkg_Price, out chk1) ? chk.ToString() : "0";
            p.Extra_Pkg_Price = decimal.TryParse(p.Extra_Pkg_Price, out chk1) ? chk.ToString() : "0";
            p.Total_Price = decimal.TryParse(p.Total_Price, out chk1) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jobpx.* " +
                "From " + jobpx.table + " jobpx " +
                "Where jobpx." + jobpx.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jobpx.*  " +
                "From " + jobpx.table + " jobpx " +
                " " +
                "Where jobpx." + jobpx.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByDate(String startDate, String endDate, String hn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            if (!hn.Equals(""))
            {
                wherehn = " and patient.PIDS like '%" + hn + "%'";
            }
            String sql = "select jobpx.*, CONCAT( SurfixName.SurfixName  ,' ', Patient.PName  ,' ',Patient.PSurname ) as name " +
                "From " + jobpx.table + " jobpx " +
                "Left Join Patient  on Patient.PID = jobpx.PID " +
                "Left Join SurfixName on Patient.SurfixID = SurfixName.SurfixID " +
                "Where jobpx.Date >= '" + startDate + "' and jobpx.Date <= '" + endDate + "' " + wherehn +
                "Order By jobpx.Date, jobpx.VN";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lJobPx.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                JobPx itm1 = new JobPx();
                itm1.VN = row[jobpx.VN].ToString();
                itm1.Status = row[jobpx.Status].ToString();
                itm1.Include_Pkg_Price = row[jobpx.Include_Pkg_Price].ToString();
                itm1.Extra_Pkg_Price = row[jobpx.Extra_Pkg_Price].ToString();
                itm1.Total_Price = row[jobpx.Total_Price].ToString();
                itm1.Date = row[jobpx.Date].ToString();
                itm1.PID = row[jobpx.PID].ToString();
                itm1.PIDS = row[jobpx.PIDS].ToString();
                
                lJobPx.Add(itm1);
            }
        }
        public void setCboItem(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            int i = 0;
            if (lJobPx.Count <= 0) getlStf();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (JobPx cus1 in lJobPx)
            {
                item = new ComboBoxItem();
                item.Value = cus1.VN;
                item.Text = cus1.Include_Pkg_Price;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
    }
}
