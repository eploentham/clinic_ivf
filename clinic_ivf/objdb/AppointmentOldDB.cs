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
    public class AppointmentOldDB
    {
        public AppointmentOld pApmO;
        ConnectDB conn;
        public List<AppointmentOld> lAgnO;

        public AppointmentOldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lAgnO = new List<AppointmentOld>();
            pApmO = new AppointmentOld();
            pApmO.ID = "ID";
            pApmO.PID = "PID";
            pApmO.PIDS = "PIDS";
            pApmO.AppTime = "AppTime";
            pApmO.AppDate = "AppDate";
            pApmO.Doctor = "Doctor";
            pApmO.Status = "Status";
            pApmO.PatientName = "PatientName";
            pApmO.MobilePhoneNo = "MobilePhoneNo";
            pApmO.PName = "PName";
            pApmO.PSurname = "PSurname";
            pApmO.DateOfBirth = "DateOfBirth";
            pApmO.HormoneTest = "HormoneTest";
            pApmO.TVS = "TVS";
            pApmO.OPU = "OPU";
            pApmO.OPUTime = "OPUTime";
            pApmO.OPURemark = "OPURemark";
            pApmO.ET_FET = "ET_FET";
            pApmO.ET_FET_Time = "ET_FET_Time";
            pApmO.BetaHCG = "BetaHCG";
            pApmO.Other = "Other";
            pApmO.OtherRemark = "OtherRemark";
            pApmO.Comment = "Comment";
            pApmO.e2 = "e2";
            pApmO.lh = "lh";
            pApmO.endo = "endo";
            pApmO.prl = "prl";
            pApmO.fsh = "fsh";
            pApmO.rt_ovary = "rt_ovary";
            pApmO.lt_ovary = "lt_ovary";
            pApmO.day1 = "day1";
            pApmO.et = "et";
            pApmO.et_time = "et_time";
            pApmO.tvs_time = "tvs_time";
            pApmO.sperm_colloect = "sperm_collect";

            pApmO.table = "Appointment";
            pApmO.pkField = "ID";
        }
        private void chkNull(AppointmentOld p)
        {
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.AppTime = p.AppTime == null ? "" : p.AppTime;
            p.AppDate = p.AppDate == null ? "" : p.AppDate;
            p.Doctor = p.Doctor == null ? "" : p.Doctor;
            //p.Status = p.Status == null ? "" : p.Status;
            p.PatientName = p.PatientName == null ? "" : p.PatientName;
            p.MobilePhoneNo = p.MobilePhoneNo == null ? "" : p.MobilePhoneNo;
            p.PName = p.PName == null ? "" : p.PName;
            p.PSurname = p.PSurname == null ? "" : p.PSurname;
            p.DateOfBirth = p.DateOfBirth == null ? "" : p.DateOfBirth;
            p.HormoneTest = p.HormoneTest == null ? "" : p.HormoneTest;
            p.OPUTime = p.OPUTime == null ? "" : p.OPUTime;
            p.OPURemark = p.OPURemark == null ? "" : p.OPURemark;
            p.ET_FET_Time = p.ET_FET_Time == null ? "" : p.ET_FET_Time;
            p.OtherRemark = p.OtherRemark == null ? "" : p.OtherRemark;
            p.Comment = p.Comment == null ? "" : p.Comment;
            p.remark = p.remark == null ? "" : p.remark;
            p.day1 = p.day1 == null ? "" : p.day1;
            p.et_time = p.et_time == null ? "" : p.et_time;
            p.tvs_time = p.tvs_time == null ? "" : p.tvs_time;

            p.ID = int.TryParse(p.ID, out chk) ? chk.ToString() : "0";
            p.PID = int.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.Status = int.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.HormoneTest = int.TryParse(p.HormoneTest, out chk) ? chk.ToString() : "0";
            p.TVS = int.TryParse(p.TVS, out chk) ? chk.ToString() : "0";
            p.OPU = int.TryParse(p.OPU, out chk) ? chk.ToString() : "0";
            p.ET_FET = int.TryParse(p.ET_FET, out chk) ? chk.ToString() : "0";
            p.BetaHCG = int.TryParse(p.BetaHCG, out chk) ? chk.ToString() : "0";
            p.Other = int.TryParse(p.Other, out chk) ? chk.ToString() : "0";
            p.e2 = int.TryParse(p.e2, out chk) ? chk.ToString() : "0";
            p.lh = int.TryParse(p.lh, out chk) ? chk.ToString() : "0";
            p.endo = int.TryParse(p.endo, out chk) ? chk.ToString() : "0";
            p.prl = int.TryParse(p.prl, out chk) ? chk.ToString() : "0";
            p.fsh = int.TryParse(p.fsh, out chk) ? chk.ToString() : "0";
            p.rt_ovary = int.TryParse(p.rt_ovary, out chk) ? chk.ToString() : "0";
            p.lt_ovary = int.TryParse(p.lt_ovary, out chk) ? chk.ToString() : "0";
            p.et = int.TryParse(p.et, out chk) ? chk.ToString() : "0";
            p.sperm_colloect = int.TryParse(p.sperm_colloect, out chk) ? chk.ToString() : "0";
            //p.item_billing_subgroop_id = int.TryParse(p.item_billing_subgroop_id, out chk) ? chk.ToString() : "0";
        }
        public String insertAppointmentOld(AppointmentOld p, String userId)
        {
            String re = "";

            if (p.ID.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String insert(AppointmentOld p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //p.date_create = "";
            chkNull(p);
            pApmO.sperm_colloect = "sperm_collect";
            //p.patient_appointment_staff_record = userId;
            try
            {
                sql = "Insert Into " + pApmO.table + " Set " +
                    pApmO.PID + "='" + p.PID + "'," +
                    pApmO.PIDS + "='" + p.PIDS + "'," +
                    pApmO.AppTime + "='" + p.AppTime + "'," +
                    pApmO.AppDate + "='" + p.AppDate + "'," +
                    pApmO.Doctor + "='" + p.Doctor.Replace("'", "''") + "'," +
                    pApmO.Status + "='" + p.Status + "'," +
                    pApmO.PatientName + "='" + p.PatientName.Replace("'", "''") + "'," +
                    pApmO.MobilePhoneNo + "='" + p.MobilePhoneNo + "'," +
                    pApmO.PName + "='" + p.PName.Replace("'", "''") + "'," +
                    pApmO.PSurname + "='" + p.PSurname.Replace("'", "''") + "'," +
                    pApmO.DateOfBirth + "='" + p.DateOfBirth + "'," +
                    pApmO.HormoneTest + "='" + p.HormoneTest + "'," +
                    pApmO.TVS + "='" + p.TVS + "'," +
                    pApmO.OPU + "='" + p.OPU + "'," +
                    pApmO.OPUTime + "='" + p.OPUTime + "'," +
                    pApmO.OPURemark + "='" + p.OPURemark.Replace("'", "''") + "'," +
                    pApmO.ET_FET + "='" + p.ET_FET + "'," +
                    pApmO.ET_FET_Time + "='" + p.ET_FET_Time + "'," +
                    pApmO.BetaHCG +"='" + p.BetaHCG + "'," +
                    pApmO.Other + "='" + p.Other.Replace("'", "''") + "'," +
                    pApmO.OtherRemark + "='" + p.OtherRemark.Replace("'", "''") + "'," +
                    pApmO.Comment + "='" + p.Comment.Replace("'", "''") + "'," +
                    pApmO.e2 + "='" + p.e2 + "'," +
                    pApmO.lh + "='" + p.lh + "'," +
                    pApmO.endo + "='" + p.endo + "'," +
                    pApmO.prl + "='" + p.prl + "'," +
                    pApmO.fsh + "='" + p.fsh + "'," +
                    pApmO.rt_ovary + "='" + p.rt_ovary + "'," +
                    pApmO.lt_ovary + "='" + p.lt_ovary + "'," +
                    pApmO.day1 + "='" + p.day1 + "'," +
                    pApmO.et + "='" + p.et + "'," +
                    pApmO.et_time + "='" + p.et_time + "'," +
                    pApmO.tvs_time + "='" + p.tvs_time + "'," +
                    pApmO.sperm_colloect + "='" + p.sperm_colloect + "' " +
                    " ";

                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String update(AppointmentOld p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + pApmO.table + " Set " +
                //" Set "+pApm.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                pApmO.PID + "='" + p.PID + "'," +
                    pApmO.PIDS + "='" + p.PIDS + "'," +
                    pApmO.AppTime + "='" + p.AppTime + "'," +
                    pApmO.AppDate + "='" + p.AppDate + "'," +
                    pApmO.Doctor + "='" + p.Doctor.Replace("'", "''") + "'," +
                    pApmO.Status + "='" + p.Status + "'," +
                    pApmO.PatientName + "='" + p.PatientName.Replace("'", "''") + "'," +
                    pApmO.MobilePhoneNo + "='" + p.MobilePhoneNo + "'," +
                    pApmO.PName + "='" + p.PName.Replace("'", "''") + "'," +
                    pApmO.PSurname + "='" + p.PSurname.Replace("'", "''") + "'," +
                    pApmO.DateOfBirth + "='" + p.DateOfBirth + "'," +
                    pApmO.HormoneTest + "='" + p.HormoneTest + "'," +
                    pApmO.TVS + "='" + p.TVS + "'," +
                    pApmO.OPU + "='" + p.OPU + "'," +
                    pApmO.OPUTime + "='" + p.OPUTime + "'," +
                    pApmO.OPURemark + "='" + p.OPURemark.Replace("'", "''") + "'," +
                    pApmO.ET_FET + "='" + p.ET_FET + "'," +
                    pApmO.ET_FET_Time + "='" + p.ET_FET_Time + "'," +
                    pApmO.BetaHCG + "='" + p.BetaHCG + "'," +
                    pApmO.Other + "='" + p.Other.Replace("'", "''") + "'," +
                    pApmO.OtherRemark + "='" + p.OtherRemark.Replace("'", "''") + "'," +
                    pApmO.Comment + "='" + p.Comment.Replace("'", "''") + "'," +
                    pApmO.e2 + "='" + p.e2 + "'," +
                    pApmO.lh + "='" + p.lh + "'," +
                    pApmO.endo + "='" + p.endo + "'," +
                    pApmO.prl + "='" + p.prl + "'," +
                    pApmO.fsh + "='" + p.fsh + "'," +
                    pApmO.rt_ovary + "='" + p.rt_ovary + "'," +
                    pApmO.lt_ovary + "='" + p.lt_ovary + "'," +
                    pApmO.day1 + "='" + p.day1 + "'," +
                    pApmO.et + "='" + p.et + "'," +
                    pApmO.et_time + "='" + p.et_time + "'," +
                    pApmO.tvs_time + "='" + p.tvs_time + "'," +
                    pApmO.sperm_colloect + "='" + p.sperm_colloect + "' " +
                " Where " + pApmO.pkField + " = '" + p.ID + "' "
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
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select appnOld.*  " +
                "From " + pApmO.table + " appnOld " +
                " ";
            //"Where agnO." + agnO.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select appnOld.* " +
                "From " + pApmO.table + " appnOld ";
            //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
            //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDateDtrGroupByDtr(String startDate, String endDate)
        {
            DataTable dt = new DataTable();
            dt = selectByDateDtrGroupByDtr(conn.conn, startDate, endDate);
            return dt;
        }
        public DataTable selectByDateDtrGroupByDtr(MySqlConnection con, String startDate, String endDate)
        {
            DataTable dt = new DataTable();
            String wheredate = "", sql = "", wheredoctor = "";
            wheredate = " appnOld." + pApmO.AppDate + " >='" + startDate + " 00:00:00' and appnOld." + pApmO.AppDate + " <='" + endDate + " 23:59:59'";
            //wheredoctor = !doctor.Equals("") ? " and appnOld." + appnOld.Doctor + " like '%" + doctor + "%'" : "";
            sql = "select appnOld.Doctor  as dtr_name, Doctor.ID as patient_appointment_doctor " +
                "From " + pApmO.table + " appnOld " +
                "Left Join Doctor on Doctor.Name = appnOld.Doctor " +
            //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
            "Where " + wheredate + wheredoctor +
            "Group By appnOld.Doctor " +
            " Order By appnOld.Doctor";

            dt = conn.selectData(con, sql);
            return dt;
        }
        public DataTable selectByDateDtr(String startDate, String endDate, String doctor)
        {
            DataTable dt = new DataTable();
            dt = selectByDateDtr(conn.conn, startDate, endDate, doctor);
            return dt;
        }
        public DataTable selectByDateDtr(MySqlConnection con, String startDate, String endDate, String doctor)
        {
            DataTable dt = new DataTable();
            String wheredate = "", sql="", wheredoctor="";
            wheredate = " appnOld." + pApmO.AppDate + " >='" + startDate + " 00:00:00' and appnOld." + pApmO.AppDate + " <='" + endDate + " 23:59:59'";
            //wheredoctor = !doctor.Equals("") ? " and appnOld." + appnOld.ID+" like '%"+ doctor + "%'":"";
            wheredoctor = !doctor.Equals("") ? " and Doctor.ID like '%" + doctor + "%'" : "";
            sql = "select appnOld.*, STR_TO_DATE(AppTime, '%h:%i %p')  as aaa " +
            //sql = "select appnOld.*, case length(AppTime)  when 5 then AppTime when 4 then concat('0',AppTime) else AppTime end as aaa " +
            //sql = "select appnOld.* " +
                "From " + pApmO.table + " appnOld " +
                "Left Join Doctor  On LOWER(Doctor.Name) = LOWER(appnOld.Doctor) " +
            "Where " + wheredate + wheredoctor +
            " Order By " + pApmO.AppDate + ",aaa ";

            //sql = "select appnOld.* " +
            //    "From " + appnOld.table + " appnOld " +
            //    //"Left Join Doctor  On LOWER(Doctor.Name) = LOWER(appnOld.Doctor) " +
            //"Where " + wheredate + wheredoctor +
            //" Order By " + appnOld.AppDate + " ";

            dt = conn.selectData(con, sql);
            return dt;
        }
        public AppointmentOld selectByPk1(String copId)
        {
            AppointmentOld cop1 = new AppointmentOld();
            DataTable dt = new DataTable();
            String sql = "select appnOld.* " +
                "From " + pApmO.table + " appnOld " +
                "Where appnOld." + pApmO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAppointmentOld(dt);
            return cop1;
        }
        public AppointmentOld setAppointmentOld(DataTable dt)
        {
            AppointmentOld vsold1 = new AppointmentOld();
            if (dt.Rows.Count > 0)
            {
                vsold1.ID = dt.Rows[0][pApmO.ID].ToString();
                vsold1.PID = dt.Rows[0][pApmO.PID].ToString();
                vsold1.PIDS = dt.Rows[0][pApmO.PIDS].ToString();
                vsold1.AppTime = dt.Rows[0][pApmO.AppTime].ToString();
                vsold1.AppDate = dt.Rows[0][pApmO.AppDate].ToString();
                vsold1.Doctor = dt.Rows[0][pApmO.Doctor].ToString();
                vsold1.Status = dt.Rows[0][pApmO.Status].ToString();
                vsold1.PatientName = dt.Rows[0][pApmO.PatientName].ToString();
                vsold1.MobilePhoneNo = dt.Rows[0][pApmO.MobilePhoneNo].ToString();
                vsold1.PName = dt.Rows[0][pApmO.PName].ToString();
                vsold1.PSurname = dt.Rows[0][pApmO.PSurname].ToString();
                vsold1.DateOfBirth = dt.Rows[0][pApmO.DateOfBirth].ToString();
                vsold1.HormoneTest = dt.Rows[0][pApmO.HormoneTest].ToString();
                vsold1.TVS = dt.Rows[0][pApmO.TVS].ToString();
                vsold1.OPU = dt.Rows[0][pApmO.OPU].ToString();
                vsold1.OPUTime = dt.Rows[0][pApmO.OPUTime].ToString();
                vsold1.OPURemark = dt.Rows[0][pApmO.OPURemark].ToString();
                vsold1.ET_FET = dt.Rows[0][pApmO.ET_FET].ToString();
                vsold1.ET_FET_Time = dt.Rows[0][pApmO.ET_FET_Time].ToString();
                vsold1.BetaHCG = dt.Rows[0][pApmO.BetaHCG].ToString();
                vsold1.Other = dt.Rows[0][pApmO.Other].ToString();
                vsold1.OtherRemark = dt.Rows[0][pApmO.OtherRemark].ToString();
                vsold1.Comment = dt.Rows[0][pApmO.Comment].ToString();
                vsold1.e2 = dt.Rows[0][pApmO.e2].ToString();
                vsold1.lh = dt.Rows[0][pApmO.lh].ToString();
                vsold1.endo = dt.Rows[0][pApmO.endo].ToString();
                vsold1.prl = dt.Rows[0][pApmO.prl].ToString();
                vsold1.fsh = dt.Rows[0][pApmO.fsh].ToString();
                vsold1.rt_ovary = dt.Rows[0][pApmO.rt_ovary].ToString();
                vsold1.lt_ovary = dt.Rows[0][pApmO.lt_ovary].ToString();
                vsold1.day1 = dt.Rows[0][pApmO.day1].ToString();
                vsold1.et = dt.Rows[0][pApmO.et].ToString();
                vsold1.et_time = dt.Rows[0][pApmO.et_time].ToString();
                vsold1.tvs_time = dt.Rows[0][pApmO.tvs_time].ToString();
                vsold1.sperm_colloect = dt.Rows[0][pApmO.sperm_colloect].ToString();
            }
            else
            {
                setAppoinmentOld1(vsold1);
            }
            return vsold1;
        }
        private AppointmentOld setAppoinmentOld1(AppointmentOld stf1)
        {
            stf1.ID = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.AppTime = "";
            stf1.AppDate = "";
            stf1.Doctor = "";
            stf1.Status = "";
            stf1.PatientName = "";
            stf1.MobilePhoneNo = "";
            stf1.PName = "";
            stf1.PSurname = "";
            stf1.DateOfBirth = "";
            stf1.HormoneTest = "";
            stf1.TVS = "";
            stf1.OPU = "";
            stf1.OPUTime = "";
            stf1.OPURemark = "";
            stf1.ET_FET = "";
            stf1.ET_FET_Time = "";
            stf1.BetaHCG = "";
            stf1.Other = "";
            stf1.OtherRemark = "";
            stf1.Comment = "";
            stf1.e2 = "";
            stf1.lh = "";
            stf1.endo = "";
            stf1.prl = "";
            stf1.fsh = "";
            stf1.rt_ovary = "";
            stf1.lt_ovary = "";
            stf1.day1 = "";
            stf1.et = "";
            stf1.et_time = "";
            stf1.tvs_time = "";
            stf1.sperm_colloect = "";
            return stf1;
        }
    }
}
