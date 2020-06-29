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
    public class JobPxDetailDB
    {
        public JobPxDetail jobpxD;
        ConnectDB conn;
        public List<JobPxDetail> lItm;
        public JobPxDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jobpxD = new JobPxDetail();
            lItm = new List<JobPxDetail>();
            jobpxD.ID = "ID";
            jobpxD.VN = "VN";
            jobpxD.DUID = "DUID";
            jobpxD.QTY = "QTY";
            jobpxD.Extra = "Extra";
            jobpxD.Price = "Price";
            jobpxD.Status = "Status";
            jobpxD.PID = "PID";
            jobpxD.PIDS = "PIDS";
            jobpxD.DUName = "DUName";
            jobpxD.Comment = "Comment";
            jobpxD.TUsage = "TUsage";
            jobpxD.EUsage = "EUsage";
            

            jobpxD.table = "JobPxDetail";
            jobpxD.pkField = "ID";
        }
        private void chkNull(JobPxDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;
            

            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.DUName = p.DUName == null ? "" : p.DUName;
            p.Comment = p.Comment == null ? "" : p.Comment;
            p.TUsage = p.TUsage == null ? "" : p.TUsage;
            p.EUsage = p.EUsage == null ? "" : p.EUsage;
            

            p.ID = long.TryParse(p.ID, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.DUID = long.TryParse(p.DUID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            //p.PIDS = long.TryParse(p.PIDS, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk.ToString() : "0";
            //p.PIDS = decimal.TryParse(p.PIDS, out chk1) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jobpxD.* " +
                "From " + jobpxD.table + " jobpxD " +
                "Where jobpxD." + jobpxD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jobpxD.*  " +
                "From " + jobpxD.table + " jobpxD " +
                " " +
                "Where cop." + jobpxD.Comment + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVN( String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +
                ", jobpxD.DUName as drug_name, jobpxD.QTY as qty, jobpxD.DUID, JobPx.Date,StockDrug.DUName as unitname " +
                "From " + jobpxD.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                "left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
                "left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where JobPx.VN = '" + vn + "' " ;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN1(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +
                ", jobpxD.DUName as drug_name, jobpxD.QTY as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
                "From " + jobpxD.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                "left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
                "left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where JobPx.VN = '" + vn + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDate(String startDate, String endDate, String hn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            if (!hn.Equals(""))
            {
                wherehn = " and jobpxD."+jobpxD.PIDS +" like '%"+hn+"%'";
            }
            String sql = "select jobpxD.* " +
                "From " + jobpxD.table + " jobpxD " +
                "Left Join jobpx  on jobpxD."+jobpxD.VN + " = jobpx.VN " +
                "Where jobpx.Date = >'" + startDate + "' and jobpx.Date <= '" + endDate + "' "+ wherehn;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lItm.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                JobPxDetail itm1 = new JobPxDetail();
                itm1.ID = row[jobpxD.ID].ToString();
                itm1.VN = row[jobpxD.VN].ToString();
                itm1.DUID = row[jobpxD.DUID].ToString();
                itm1.QTY = row[jobpxD.QTY].ToString();
                itm1.Extra = row[jobpxD.Extra].ToString();
                itm1.Price = row[jobpxD.Price].ToString();
                itm1.Status = row[jobpxD.Status].ToString();
                itm1.PID = row[jobpxD.PID].ToString();
                itm1.PIDS = row[jobpxD.PIDS].ToString();
                itm1.DUName = row[jobpxD.DUName].ToString();
                itm1.Comment = row[jobpxD.Comment].ToString();
                itm1.TUsage = row[jobpxD.TUsage].ToString();
                itm1.EUsage = row[jobpxD.EUsage].ToString();
                
                lItm.Add(itm1);
            }
        }
        public void setCboItem(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            int i = 0;
            if (lItm.Count <= 0) getlStf();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (JobPxDetail cus1 in lItm)
            {
                item = new ComboBoxItem();
                item.Value = cus1.ID;
                item.Text = cus1.DUID;
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
