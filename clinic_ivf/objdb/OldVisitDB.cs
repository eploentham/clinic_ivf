using clinic_ivf.object1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldVisitDB
    {
        public VisitOld vsold;
        ConnectDB conn;

        public OldVisitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            vsold = new VisitOld();
            vsold.VN = "VN";
            vsold.VSID = "VSID";
            vsold.PID = "PID";
            vsold.PIDS = "PIDS";
            vsold.PName = "PName";
            vsold.OName = "OName";
            vsold.VDate = "VDate";
            vsold.VStartTime = "VStartTime";
            vsold.VEndTime = "VEndTime";
            vsold.VUpdateTime = "VUpdateTime";
            vsold.LVSID = "LVSID";
            vsold.IntLock = "IntLock";
            vsold.form_a_id = "form_a_id";
            vsold.doctorname = "";

            vsold.table = "Visit";
            vsold.pkField = "VN";
        }
        private void chkNull(VisitOld p)
        {
            int chk = 0;
            Int64 chk1 = 0;

            //p.VN = p.VN == null ? "" : p.VN;
            //p.VSID = p.VSID == null ? "" : p.VSID;
            //p.PID = p.PID == null ? "" : p.PID;
            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.PName = p.PName == null ? "" : p.PName;

            p.OName = p.OName == null ? "" : p.OName;
            p.VDate = p.VDate == null ? "" : p.VDate;
            p.VStartTime = p.VStartTime == null ? "" : p.VStartTime;
            p.VEndTime = p.VEndTime == null ? "" : p.VEndTime;
            p.VUpdateTime = p.VUpdateTime == null ? "" : p.VUpdateTime;
            //p.LVSID = p.LVSID == null ? "" : p.LVSID;
            //p.IntLock = p.IntLock == null ? "" : p.IntLock;

            p.IntLock = int.TryParse(p.IntLock, out chk) ? chk.ToString() : "0";
            p.LVSID = int.TryParse(p.LVSID, out chk) ? chk.ToString() : "0";
            //p.PIDS = int.TryParse(p.PIDS, out chk) ? chk.ToString() : "0";
            p.PID = Int64.TryParse(p.PID, out chk1) ? chk1.ToString() : "0";
            p.VN = Int64.TryParse(p.VN, out chk1) ? chk1.ToString() : "0";
            p.VSID = int.TryParse(p.VSID, out chk) ? chk.ToString() : "0";
            p.form_a_id = int.TryParse(p.form_a_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(VisitOld p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + vsold.table + "(" + vsold.PID + "," + vsold.PIDS + "," + vsold.PName + "," +
                vsold.OName + "," + vsold.VDate + "," + vsold.VStartTime + "," +
                vsold.VEndTime + "," + vsold.VUpdateTime + "," + vsold.LVSID + "," +
                vsold.IntLock + "," + vsold.VN + "," + vsold.VSID + " " +
                ") " +
                "Values ('" + p.PID + "','" + p.PIDS.Replace("'", "''") + "','" + p.PName + "'," +
                "'" + p.OName + "','" + p.VDate.Replace("'", "''") + "','" + p.VStartTime + "'," +
                "'" + p.VEndTime + "','" + p.VUpdateTime + "','" + p.LVSID + "'," +
                "'" + p.IntLock + "','" + p.VN + "','" + p.VSID + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("e", "Err insert VisitOld " + sql);
            }
            return re;
        }
        public String update(VisitOld p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + vsold.table + " Set " +
                " " + vsold.PName + " = '" + p.PName + "'" +
                "," + vsold.OName + " = '" + p.OName.Replace("'", "''") + "'" +
                "," + vsold.VDate + " = '" + p.VDate + "' " +
                
                "Where " + vsold.pkField + "='" + p.VN + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("e", "Err update VisitOld " + sql);
            }

            return re;
        }
        public String updateVEndTimeNull(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + vsold.table + " Set " +
                " " + vsold.VEndTime + " = null " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateFormA(String vn, String formaid)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.form_a_id + " = '"+ formaid + "' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateStatusSendtoCashier(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = " + vsold.VSID + " " +
                "Where " + vsold.pkField + "='" + vn + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '160' " +
                "Where " + vsold.pkField + "='" + vn + "'";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateStatusCashierReceive(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = " + vsold.VSID + " " +
                "Where " + vsold.pkField + "='" + vn + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '165' " +
                "Where " + vsold.pkField + "='" + vn + "'";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateStatusVoidVisit(String vn)
        {
            //function cancel_visit($VN)
              //      $this->db->query('update Visit set VSID="998" Where VN="'.$VN.'"');
              //$date = date("Y-m-d", time());
              //$query =$this->db->query('select PID from Visit Where VN="'.$VN.'"');
              //$row =$query->row();
              //$PID =$row->PID;
              //$this->db->query('update Appointment Set Status=1 Where PID="'.$PID.'" and AppDate="'.$date.'"');
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '998' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateStatusNurseReceive(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = " + vsold.VSID + " " +
                "Where " + vsold.pkField + "='" + vn + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '110' " +
                "Where " + vsold.pkField + "='" + vn + "'";
                re = conn.ExecuteNonQuery(conn.conn, sql);

            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateStatusNurseComfirm(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = " + vsold.VSID + " " +
                "Where " + vsold.pkField + "='" + vn + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '111' " +
                "Where " + vsold.pkField + "='" + vn + "'";
                re = conn.ExecuteNonQuery(conn.conn, sql);

            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String updateStatusCashierbackNurse(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;                        
            try
            {
                sql = "Update " + vsold.table + " Set " +
                " " + vsold.VSID + " = '115' " +
                "Where " + vsold.pkField + "='" + vn + "'";
                re = conn.ExecuteNonQuery(conn.conn, sql);

            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String updateStatusNurseAutoComfirm(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = '110' " +
                "," + vsold.LVSID + " = '111' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateStatusNurseFinish(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = VSID " +
                "," + vsold.VSID + " = '160' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateStatusCashierFinish(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = VSID " +
                "," + vsold.VSID + " = '166' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateStatusPharmacyFinish(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.LVSID + " = VSID " +
                "," + vsold.VSID + " = '999' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String insertVisitOld(VisitOld p, String userId, String flagnew)
        {
            String re = "";

            if (flagnew.Equals("new"))
            {
                //p.VN = genVN();
                re = insert(p, userId);
                if (re.Equals("1"))
                {
                    re = p.VN;
                }
            }
            else
            {
                re = update(p, userId);
                if (re.Equals("1"))
                {
                    re = p.VN;
                }
            }

            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select vsold.* " +
                "From " + vsold.table + " vsold " +
                "Where vsold." + vsold.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public VisitOld selectByPk1(String copId)
        {
            VisitOld cop1 = new VisitOld();
            DataTable dt = new DataTable();
            String sql = "select vsold.* " +
                "From " + vsold.table + " vsold " +
                "Where vsold." + vsold.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setVisitOld(dt);
            return cop1;
        }
        public DataTable selectLikeByHN(String hn, MySqlConnection con)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID  " +
                "Where vsold." + vsold.PIDS + " like ('%" + hn + "%') and vsold."+vsold.VSID + " <> '998' " +
                "Order By vsold.VN ";
            dt = conn.selectData(con, sql);

            return dt;
        }
        public DataTable selectLikeByHNMale(String hn, MySqlConnection con)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select '' as id,'' as VN, Patient.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID  " +
                "Where vsold." + vsold.PIDS + " like ('%" + hn + "%') " +
                "Order By vsold.VN ";
            dt = conn.selectData(con, sql);

            return dt;
        }
        public DataTable selectByHN(String hn)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.PIDS + " ='" + hn + "' and vsold.PID <> 0 and vsold."+vsold.VSID+"<>998 " +
                "Order By vsold.VN ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHNLike(String hn)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.PIDS + " like '%" + hn + "%' " +
                "Order By vsold.VN desc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public DataTable selectCurrentVisit()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='"+ date + "' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectCurrentVisit(MySqlConnection con)
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(con, sql);

            return dt;
        }
        public DataTable selectByStatusNurseWaiting()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID = '110' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierWaiting1()
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
            //    ",vsold.form_a_id, t_visit.status_nurse, t_visit.status_cashier  " +
            //    "From " + vsold.table + " vsold " +
            //    "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
            //    "Left Join Patient on  vsold.PID = Patient.PID " +
            //    "Left Join t_patient on Patient.PID = t_patient.t_patient_id_old " +
            //    "Left Join t_visit on t_patient.t_patient_id = t_visit.t_patient_id " +
            //    "Where  vsold.VSID in('110','160','161','162','163','164','165','166') " +
            //    "Order By vsold.VSID desc,vsold.VDate desc, vsold.VStartTime desc ";
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, t_patient.agent, agt.AgentName  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_patient on Patient.PID = t_patient.t_patient_id_old " +
                "Left Join Agent agt on t_patient.agent = agt.AgentID " +
                "Where  vsold.VSID in('110','160','161','162','163','164','165') " +
                "Order By vsold.VSID desc,vsold.VDate desc, vsold.VStartTime desc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierWaiting()
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
            //    ",vsold.form_a_id, t_visit.status_nurse, t_visit.status_cashier  " +
            //    "From " + vsold.table + " vsold " +
            //    "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
            //    "Left Join Patient on  vsold.PID = Patient.PID " +
            //    "Left Join t_patient on Patient.PID = t_patient.t_patient_id_old " +
            //    "Left Join t_visit on t_patient.t_patient_id = t_visit.t_patient_id " +
            //    "Where  vsold.VSID in('110','160','161','162','163','164','165','166') " +
            //    "Order By vsold.VSID desc,vsold.VDate desc, vsold.VStartTime desc ";
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                //"Left Join t_patient on Patient.PID = t_patient.t_patient_id_old " +
                //"Left Join t_visit on t_patient.t_patient_id = t_visit.t_patient_id " +
                "Where  vsold.VSID in('110','160','161','162','163','164','165') " +
                "Order By vsold.VSID desc,vsold.VDate desc, vsold.VStartTime desc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierFinish()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime" +
                ", VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, bilh.bill_id  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join t_visit vs on vsold.VN = vs.visit_vn " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join BillHeader bilh on vs.visit_vn = bilh.VN and bilh.active = '1' " +
                //"Where  vsold.VSID in('166') and VDate = '"+date+"' " +
                "Where  vs.status_cashier = '2' and bilh.Date = '" + date + "' " +
                "Order By vsold.VSID desc,vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierSearch1(String hn, String visitdate)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            if (hn.Length > 0)
            {
                wherehn = " and Patient.PIDS like '%" + hn + "%'";
            }
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime" +
                ", VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, t_patient.agent  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_patient on  Patient.PIDS = t_patient.patient_hn " +
                "Where  vsold.VSID in('166') and VDate = '" + visitdate + "' " + wherehn +
                "Order By vsold.VSID desc,vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierSearch(String hn, String visitdate)
        {
            DataTable dt = new DataTable();
            String wherehn = "", wheredate="";
            if (hn.Length > 0)
            {
                wherehn = " and Patient.PIDS like '%" + hn + "%'";
            }
            if (visitdate.Length > 0)
            {
                wheredate = " and vsold.VDate = '" + visitdate + "'";
            }
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime" +
                ", VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where  vsold.VSID in('166')  " + wheredate + wherehn +
                "Order By vsold.VSID desc,vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByReceptionSend()
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "Select t_visit.t_visit_id as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', stf.staff_fname_e ,' ',stf.staff_lname_e)  as dtrname, t_visit.status_nurse, t_visit.status_cashier " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Left Join b_staff stf on t_visit.doctor_id = stf.doctor_id_old " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = stf.prefix_id " +
                "Where  vsold.VSID in ('110','115') " +
                "Order By vsold.VDate desc, vsold.VStartTime desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusCashierFinish(String bspid)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime" +
                ", VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id,CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', stf.staff_fname_e ,' ',stf.staff_lname_e)  as dtrname,t_visit.status_nurse, t_visit.status_cashier  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Left Join b_staff stf on t_visit.doctor_id = stf.doctor_id_old " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = stf.prefix_id " +
                "Where  vsold.VSID in('166','160','165')  " +//and t_visit.b_service_point_id = '" + bspid + "' " +
                "Order By vsold.VSID desc,vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHnFormA(String hn)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.form_a_id as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, lforma.status_fet " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join lab_t_form_a lforma on lforma.hn_female = Patient.PIDS " +
                "Where vsold." + vsold.PIDS + " like '%" + hn + "%' and vsold.form_a_id <> 0 " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByDate(String date)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID = '110' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByReceptionSendBsp(String bspid)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select t_visit.t_visit_id as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id, CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', stf.staff_fname_e ,' ',stf.staff_lname_e)  as dtrname, t_visit.status_nurse, t_visit.status_cashier " +                 
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Left Join b_staff stf on t_visit.doctor_id = stf.doctor_id_old " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = stf.prefix_id " +
                "Where  vsold.VSID in ('110','115') and t_visit.b_service_point_id = '" + bspid + "' " +
                "Order By vsold.VDate desc, vsold.VStartTime desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByReceptionSendBsp1(String bspid)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select t_visit.t_visit_id as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, ptt.patient_birthday as dob" +
                ",vsold.form_a_id, CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', stf.staff_fname_e ,' ',stf.staff_lname_e)  as dtrname, t_visit.status_nurse, t_visit.status_cashier " +
                 ", ptt.patient_hn_1 ,CONCAT(IFNULL(fpp_1.patient_prefix_description,''),' ', ptt_1.patient_firstname_e ,' ',ptt_1.patient_lastname_e ) as name_1" +
                ", ptt.patient_hn_2 ,CONCAT(IFNULL(fpp_2.patient_prefix_description,''),' ', ptt_2.patient_firstname_e ,' ',ptt_2.patient_lastname_e ) as name_2 " +
                ", ptt.agent, agt.AgentName " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Left Join t_patient ptt on  t_visit.t_patient_id = ptt.t_patient_id " +
                "Left Join b_staff stf on t_visit.doctor_id = stf.doctor_id_old " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = stf.prefix_id " +
                "Left join t_patient ptt_1 on ptt.patient_hn_1 = ptt_1.patient_hn and ptt.patient_hn_1 <> '' and ptt.patient_hn_1 is not null " +
                "Left join f_patient_prefix fpp_1 on fpp_1.f_patient_prefix_id = ptt_1.f_patient_prefix_id " +
                "Left join t_patient ptt_2 on ptt.patient_hn_2 = ptt_2.patient_hn and ptt.patient_hn_2 <> '' and ptt.patient_hn_2 is not null " +
                "Left join f_patient_prefix fpp_2 on fpp_2.f_patient_prefix_id = ptt_2.f_patient_prefix_id " +
                "Left Join Agent agt on ptt.agent = agt.AgentID " +
                "Where  vsold.VSID in ('110','115') and t_visit.b_service_point_id = '" + bspid + "' " +
                "Order By vsold.VDate desc, vsold.VStartTime desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByReceptionSendDoctor(String dtrid)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Where  vsold.VSID in ('110',115) and t_visit.doctor_id = '"+dtrid+"' " +
                "Order By vsold.VDate desc, vsold.VStartTime desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public DataTable selectByReceptionSend1()
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "Select t_visit.t_visit_id as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, ptt.patient_birthday as dob" +
                ",vsold.form_a_id, CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', stf.staff_fname_e ,' ',stf.staff_lname_e)  as dtrname, t_visit.status_nurse, t_visit.status_cashier, ptt.t_patient_id " +
                ", ptt.patient_hn_1 ,CONCAT(IFNULL(fpp_1.patient_prefix_description,''),' ', ptt_1.patient_firstname_e ,' ',ptt_1.patient_lastname_e ) as name_1" +
                ", ptt.patient_hn_2 ,CONCAT(IFNULL(fpp_2.patient_prefix_description,''),' ', ptt_2.patient_firstname_e ,' ',ptt_2.patient_lastname_e ) as name_2 " +
                ", ptt.agent, agt.AgentName " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +                
                "Left Join t_visit on  vsold.VN = t_visit.visit_vn " +
                "Left Join t_patient ptt on  t_visit.t_patient_id = ptt.t_patient_id " +
                "Left Join b_staff stf on t_visit.doctor_id = stf.doctor_id_old " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = stf.prefix_id " +
                "Left join t_patient ptt_1 on ptt.patient_hn_1 = ptt_1.patient_hn and ptt.patient_hn_1 <> '' and ptt.patient_hn_1 is not null " +
                "Left join f_patient_prefix fpp_1 on fpp_1.f_patient_prefix_id = ptt_1.f_patient_prefix_id " +
                "Left join t_patient ptt_2 on ptt.patient_hn_2 = ptt_2.patient_hn and ptt.patient_hn_2 <> '' and ptt.patient_hn_2 is not null " +
                "Left join f_patient_prefix fpp_2 on fpp_2.f_patient_prefix_id = ptt_2.f_patient_prefix_id " +
                "Left Join Agent agt on ptt.agent = agt.AgentID " +
                "Where  vsold.VSID in ('110','115') " +
                "Order By vsold.VDate desc, vsold.VStartTime desc";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusNurseDiag()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "Select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID in ('115','144','135','112','113','114') " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusNurseFinish()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID in ('999','166','165','998','160') " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusNurseFinish(String date)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            if (date.Equals(""))
            {
                dt = selectByStatusNurseFinish();
            }
            else
            {
                String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID in ('999','166','165','998','160') " +
                "Order By vsold.VDate, vsold.VStartTime";
                dt = conn.selectData(conn.conn, sql);
            }
            return dt;
        }
        public DataTable selectByStatusNurseFinishLike(String search)
        {
            DataTable dt = new DataTable();
            String whereHN = "", whereName = "", wherepid = "", wherepassport = "", wherenameE = "";
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            if (search.Equals(""))
            {
                dt = selectByStatusNurseFinish();
            }
            else
            {
                if (!search.Equals(""))
                {
                    whereHN = " ptt.PIDS  like '%" + search.Trim().ToUpper() + "%'";
                }
                if (!search.Equals(""))
                {
                    String[] txt = search.Split(' ');
                    if (txt.Length == 2)
                    {
                        whereName = " or ( lcase(ptt.OName) like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt.OSurname) like '%" + txt[1].Trim().ToLower() + "%')";
                        wherenameE = " or ( lcase(ptt.PName) like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt.PSurname) like '%" + txt[1].Trim().ToLower() + "%')";
                        wherenameE += " or ( lcase(ptt.PName) like '%" + txt[0].Trim().ToLower() + " " + txt[1].Trim().ToLower() + "%') ";
                    }
                    else if (txt.Length == 1)
                    {
                        whereName = " or ( lcase(ptt.OName) like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt.OSurname) like '%" + txt[0].Trim().ToLower() + "%')";
                        wherenameE = " or ( lcase(ptt.PName) like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt.PSurname) like '%" + txt[0].Trim().ToLower() + "%')";
                    }
                    else
                    {
                        whereName = " or ( lcase(ptt.OName) like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt.OSurname) like '%" + search.Trim().ToLower() + "%')";
                        wherenameE = " or ( lcase(ptt.PName) like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt.PSurname) like '%" + search.Trim().ToLower() + "%')";
                    }
                }
                if (!search.Equals(""))
                {
                    wherepid = " or ( ptt.IDNumber  like '%" + search.Trim() + "%' )";
                }
                String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, ptt.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient ptt on  vsold.PID = ptt.PID " +
                "Left join SurfixName fpp on fpp.SurfixID = ptt.SurfixID " +
                //"Where vsold." + vsold.VDate + " ='" + search + "' and vsold.VSID in ('999','166','165') " +
                "Where " + whereHN + whereName + wherepid + wherenameE + " " +
                "Order By vsold.VDate, vsold.VStartTime";
                dt = conn.selectData(conn.conn, sql);
            }
            return dt;
        }
        public String genVN()
        {
            DataTable dt = new DataTable();
            Int64 year = (DateTime.Now.Year * 1000);
            String sql = "select max(VN) as VN from Visit ";
            Int64 max = 0, vn=0;
            
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                Int64.TryParse(dt.Rows[0]["VN"].ToString(), out max);
            }
            if (max > year)
            {
                vn = max + 1;
            }
            else
            {
                vn = year+1;
            }
            return vn.ToString();
        }
        public VisitOld setVisitOld(DataTable dt)
        {
            VisitOld vsold1 = new VisitOld();
            if (dt.Rows.Count > 0)
            {
                vsold1.VN = dt.Rows[0][vsold.VN].ToString();
                vsold1.VSID = dt.Rows[0][vsold.VSID].ToString();
                vsold1.PID = dt.Rows[0][vsold.PID].ToString();
                vsold1.PIDS = dt.Rows[0][vsold.PIDS].ToString();
                vsold1.PName = dt.Rows[0][vsold.PName].ToString();
                vsold1.OName = dt.Rows[0][vsold.OName].ToString();
                vsold1.VDate = dt.Rows[0][vsold.VDate].ToString();
                vsold1.VStartTime = dt.Rows[0][vsold.VStartTime].ToString();
                vsold1.VEndTime = dt.Rows[0][vsold.VEndTime].ToString();
                vsold1.VUpdateTime = dt.Rows[0][vsold.VUpdateTime].ToString();
                vsold1.LVSID = dt.Rows[0][vsold.LVSID].ToString();
                vsold1.IntLock = dt.Rows[0][vsold.IntLock].ToString();
                vsold1.form_a_id = dt.Rows[0][vsold.form_a_id].ToString();
                vsold1.doctorname = "";
            }
            else
            {
                setVisitOld1(vsold1);
            }
            return vsold1;
        }
        private VisitOld setVisitOld1(VisitOld stf1)
        {
            stf1.VN = "";
            stf1.VSID = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.PName = "";
            stf1.OName = "";
            stf1.VDate = "";
            stf1.VStartTime = "";
            stf1.VEndTime = "";
            stf1.VUpdateTime = "";
            stf1.LVSID = "";
            stf1.IntLock = "";
            stf1.form_a_id = "";
            stf1.doctorname = "";
            return stf1;
        }
    }
}
