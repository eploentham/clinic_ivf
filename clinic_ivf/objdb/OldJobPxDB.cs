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
    /*
     * 63-10-27     0020    เรื่อง		เลิก insert table Visit
     * 63-10-23     0021    ให้เริ่ม HN ใหม่ แต่ให้ใช้ข้อมูลเก่า
     */
    public class OldJobPxDB
    {
        public OldJobPx jobpx;
        ConnectDB conn;
        public List<OldJobPx> lJobPx;
        public OldJobPxDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jobpx = new OldJobPx();
            lJobPx = new List<OldJobPx>();
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
        private void chkNull(OldJobPx p)
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
            String sql = "select jobpx.*, t_visit.patient_name, t_visit.status_nurse, t_visit.status_cashier  " +
                "From " + jobpx.table + " jobpx " +
                //"Left Join Patient  on Patient.PID = jobpx.PID " +            //-0020
                //"Left Join SurfixName on Patient.SurfixID = SurfixName.SurfixID " +       //-0020
                //"Left Join t_patient on Patient.PID = t_patient.t_patient_id_old " +
                //"Left Join t_visit on t_patient.t_patient_id = t_visit.t_patient_id " +       //-0020
                "Left Join t_visit on jobpx.PID = t_visit.t_patient_id " +         //+0020
                "Where jobpx.Date >= '" + startDate + "' and jobpx.Date <= '" + endDate + "' " + wherehn +
                "Order By jobpx.Date, jobpx.VN";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String setJobPx(String vn, String hn, String pid)
        {
            //    $query = $this->db->query('select VN from JobPx Where VN="'. $VN. '"');
            //      $date = date("Y-m-d", time());
            //    if ($query->num_rows() == 0) {
            //    $PID = $this->session->userdata['PID'];
            //    $PIDS = $this->session->userdata['PIDS'];
            //    $this->db->query('insert into JobPx set VN="'. $VN. '", Status="1", date="'. $date. '", PID="'. $PID. '", PIDS="'. $PIDS. '"');
            //    }
            DataTable dt = new DataTable();
            String re = "", sql="";
            sql = "select "+ jobpx .VN+ " from "+ jobpx .table+ " Where "+ jobpx .VN+ "='"+ vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count <= 0)
            {
                sql = "insert into JobPx set VN='"+vn+"'" +
                    ", Status='1'" +
                    ", date=date(now()) " +
                    ", PID='"+ pid + "'" +
                    ", PIDS='"+ hn + "' ";
                try
                {
                    re = conn.ExecuteNonQuery(conn.conn, sql);
                }
                catch (Exception ex)
                {
                    sql = ex.Message + " " + ex.InnerException;
                    new LogWriter("e", "Error insert JobPx " + sql);
                }
            }

            return re;
        }
        public String updateIncludePriceFormDetail(String inprice, String exprice, String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Decimal inprice1 = 0, exprice1 = 0, total = 0; ;
            Decimal.TryParse(inprice, out inprice1);
            Decimal.TryParse(exprice, out exprice1);
            total = inprice1 + exprice1;
            sql = "Update " + jobpx.table + " Set " +
                " " + jobpx.Include_Pkg_Price + " = '"+ inprice1 + "'" +
                "," + jobpx.Extra_Pkg_Price + " = '" + exprice1 + "'" +
                "," + jobpx.Total_Price + " = '" + total + "' " +
                "," + jobpx.Status + " = '2'" +
                "Where " + jobpx.VN + "='" + vn + "'"
                ;
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateStatusCloseJobPx(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;
                        
            sql = "Update " + jobpx.table + " Set " +
                " " + jobpx.Status + " = '3'" +
                "Where " + jobpx.VN + "='" + vn + "'"
                ;
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lJobPx.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldJobPx itm1 = new OldJobPx();
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
            foreach (OldJobPx cus1 in lJobPx)
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
