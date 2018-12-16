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
        public AppointmentOld appnOld;
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
            appnOld = new AppointmentOld();
            appnOld.ID = "ID";
            appnOld.PID = "PID";
            appnOld.PIDS = "PIDS";
            appnOld.AppTime = "AppTime";
            appnOld.AppDate = "AppDate";
            appnOld.Doctor = "Doctor";
            appnOld.Status = "Status";
            appnOld.PatientName = "PatientName";
            appnOld.MobilePhoneNo = "MobilePhoneNo";
            appnOld.PName = "PName";
            appnOld.PSurname = "PSurname";
            appnOld.DateOfBirth = "DateOfBirth";
            appnOld.HormoneTest = "HormoneTest";
            appnOld.TVS = "TVS";
            appnOld.OPU = "OPU";
            appnOld.OPUTime = "OPUTime";
            appnOld.OPURemark = "OPURemark";
            appnOld.ET_FET = "ET_FET";
            appnOld.ET_FET_Time = "ET_FET_Time";
            appnOld.BetaHCG = "BetaHCG";
            appnOld.Other = "Other";
            appnOld.OtherRemark = "OtherRemark";
            appnOld.Comment = "Comment";
            appnOld.e2 = "e2";
            appnOld.lh = "lh";
            appnOld.endo = "endo";
            appnOld.prl = "prl";
            appnOld.fsh = "fsh";
            appnOld.rt_ovary = "rt_ovary";
            appnOld.lt_ovary = "lt_ovary";
            appnOld.day1 = "day1";
            appnOld.et = "et";
            appnOld.et_time = "et_time";
            appnOld.tvs_time = "tvs_time";

            appnOld.table = "Appointment";
            appnOld.pkField = "ID";
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
            //p.item_billing_subgroop_id = int.TryParse(p.item_billing_subgroop_id, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select appnOld.*  " +
                "From " + appnOld.table + " appnOld " +
                " ";
            //"Where agnO." + agnO.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select appnOld.* " +
                "From " + appnOld.table + " appnOld ";
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
            wheredate = " appnOld." + appnOld.AppDate + " >='" + startDate + " 00:00:00' and appnOld." + appnOld.AppDate + " <='" + endDate + " 23:59:59'";
            //wheredoctor = !doctor.Equals("") ? " and appnOld." + appnOld.Doctor + " like '%" + doctor + "%'" : "";
            sql = "select appnOld.Doctor  as dtr_name, Doctor.ID as patient_appointment_doctor " +
                "From " + appnOld.table + " appnOld " +
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
            wheredate = " appnOld." + appnOld.AppDate + " >='" + startDate + " 00:00:00' and appnOld." + appnOld.AppDate + " <='" + endDate + " 23:59:59'";
            //wheredoctor = !doctor.Equals("") ? " and appnOld." + appnOld.ID+" like '%"+ doctor + "%'":"";
            wheredoctor = !doctor.Equals("") ? " and Doctor.ID like '%" + doctor + "%'" : "";
            sql = "select appnOld.*, STR_TO_DATE(AppTime, '%h:%i %p')  as aaa " +
            //sql = "select appnOld.*, case length(AppTime)  when 5 then AppTime when 4 then concat('0',AppTime) else AppTime end as aaa " +
            //sql = "select appnOld.* " +
                "From " + appnOld.table + " appnOld " +
                "Left Join Doctor  On LOWER(Doctor.Name) = LOWER(appnOld.Doctor) " +
            "Where " + wheredate + wheredoctor +
            " Order By " + appnOld.AppDate + ",aaa ";

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
                "From " + appnOld.table + " appnOld " +
                "Where appnOld." + appnOld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAppointmentOld(dt);
            return cop1;
        }
        public AppointmentOld setAppointmentOld(DataTable dt)
        {
            AppointmentOld vsold1 = new AppointmentOld();
            if (dt.Rows.Count > 0)
            {
                vsold1.ID = dt.Rows[0][appnOld.ID].ToString();
                vsold1.PID = dt.Rows[0][appnOld.PID].ToString();
                vsold1.PIDS = dt.Rows[0][appnOld.PIDS].ToString();
                vsold1.AppTime = dt.Rows[0][appnOld.AppTime].ToString();
                vsold1.AppDate = dt.Rows[0][appnOld.AppDate].ToString();
                vsold1.Doctor = dt.Rows[0][appnOld.Doctor].ToString();
                vsold1.Status = dt.Rows[0][appnOld.Status].ToString();
                vsold1.PatientName = dt.Rows[0][appnOld.PatientName].ToString();
                vsold1.MobilePhoneNo = dt.Rows[0][appnOld.MobilePhoneNo].ToString();
                vsold1.PName = dt.Rows[0][appnOld.PName].ToString();
                vsold1.PSurname = dt.Rows[0][appnOld.PSurname].ToString();
                vsold1.DateOfBirth = dt.Rows[0][appnOld.DateOfBirth].ToString();
                vsold1.HormoneTest = dt.Rows[0][appnOld.HormoneTest].ToString();
                vsold1.TVS = dt.Rows[0][appnOld.TVS].ToString();
                vsold1.OPU = dt.Rows[0][appnOld.OPU].ToString();
                vsold1.OPUTime = dt.Rows[0][appnOld.OPUTime].ToString();
                vsold1.OPURemark = dt.Rows[0][appnOld.OPURemark].ToString();
                vsold1.ET_FET = dt.Rows[0][appnOld.ET_FET].ToString();
                vsold1.ET_FET_Time = dt.Rows[0][appnOld.ET_FET_Time].ToString();
                vsold1.BetaHCG = dt.Rows[0][appnOld.BetaHCG].ToString();
                vsold1.Other = dt.Rows[0][appnOld.Other].ToString();
                vsold1.OtherRemark = dt.Rows[0][appnOld.OtherRemark].ToString();
                vsold1.Comment = dt.Rows[0][appnOld.Comment].ToString();
                vsold1.e2 = dt.Rows[0][appnOld.e2].ToString();
                vsold1.lh = dt.Rows[0][appnOld.lh].ToString();
                vsold1.endo = dt.Rows[0][appnOld.endo].ToString();
                vsold1.prl = dt.Rows[0][appnOld.prl].ToString();
                vsold1.fsh = dt.Rows[0][appnOld.fsh].ToString();
                vsold1.rt_ovary = dt.Rows[0][appnOld.rt_ovary].ToString();
                vsold1.lt_ovary = dt.Rows[0][appnOld.lt_ovary].ToString();
                vsold1.day1 = dt.Rows[0][appnOld.day1].ToString();
                vsold1.et = dt.Rows[0][appnOld.et].ToString();
                vsold1.et_time = dt.Rows[0][appnOld.et_time].ToString();
                vsold1.tvs_time = dt.Rows[0][appnOld.tvs_time].ToString();
                //vsold1.Comment = dt.Rows[0][appnOld.Comment].ToString();
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

            return stf1;
        }
    }
}
