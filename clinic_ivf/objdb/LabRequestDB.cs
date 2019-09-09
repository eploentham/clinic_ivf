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
    public class LabRequestDB
    {
        public LabRequest lbReq;
        ConnectDB conn;

        public LabRequestDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbReq = new LabRequest();
            lbReq.req_id = "req_id";
            lbReq.req_code = "req_code";
            lbReq.req_date = "req_date";
            lbReq.hn_male = "hn_male";
            lbReq.name_male = "name_male";
            lbReq.hn_female = "hn_female";
            lbReq.name_female = "name_female";
            lbReq.status_req = "status_req";
            lbReq.accept_date = "accept_date";
            lbReq.start_date = "start_date";
            lbReq.result_date = "result_date";
            lbReq.visit_id = "visit_id";
            lbReq.vn = "vn";
            lbReq.active = "active";
            lbReq.remark = "remark";
            lbReq.date_create = "date_create";
            lbReq.date_modi = "date_modi";
            lbReq.date_cancel = "date_cancel";
            lbReq.user_create = "user_create";
            lbReq.user_modi = "user_modi";
            lbReq.user_cancel = "user_cancel";
            lbReq.item_id = "item_id";
            lbReq.accept_staff_id = "accept_staff_id";
            lbReq.start_staff_id = "start_staff_id";
            lbReq.result_staff_id = "result_staff_id";
            lbReq.doctor_id = "doctor_id";
            lbReq.lab_id = "lab_id";
            lbReq.dob_donor = "dob_donor";
            lbReq.dob_female = "dob_female";
            lbReq.dob_male = "dob_male";
            lbReq.hn_donor = "hn_donor";
            lbReq.name_donor = "name_donor";
            lbReq.request_id = "request_id";
            lbReq.form_a_id = "form_a_id";
            lbReq.req_time = "req_time";

            lbReq.table = "lab_t_request";
            lbReq.pkField = "req_id";
        }
        private void chkNull(LabRequest p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.req_code = p.req_code == null ? "" : p.req_code;
            p.req_date = p.req_date == null ? "" : p.req_date;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.accept_date = p.accept_date == null ? "" : p.accept_date;
            p.start_date = p.start_date == null ? "" : p.start_date;
            p.result_date = p.result_date == null ? "" : p.result_date;
            p.remark = p.remark == null ? "" : p.remark;
            p.dob_donor = p.dob_donor == null ? "" : p.dob_donor;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.hn_donor = p.hn_donor == null ? "" : p.hn_donor;
            p.name_donor = p.name_donor == null ? "" : p.name_donor;
            p.req_time = p.req_time == null ? "" : p.req_time;

            p.status_req = p.status_req == null ? "0" : p.status_req;

            p.item_id = long.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.visit_id = long.TryParse(p.visit_id, out chk) ? chk.ToString() : "0";
            p.accept_staff_id = long.TryParse(p.accept_staff_id, out chk) ? chk.ToString() : "0";
            p.start_staff_id = long.TryParse(p.start_staff_id, out chk) ? chk.ToString() : "0";
            p.result_staff_id = long.TryParse(p.result_staff_id, out chk) ? chk.ToString() : "0";
            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";
            p.request_id = long.TryParse(p.request_id, out chk) ? chk.ToString() : "0";
            p.form_a_id = long.TryParse(p.form_a_id, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq.* " +
                "From " + lbReq.table + " lbReq " +
                "Where lbReq." + lbReq.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabRequest selectByPk1(String copId)
        {
            LabRequest lbReq1 = new LabRequest();
            DataTable dt = new DataTable();
            String sql = "select lbReq.* " +
                "From " + lbReq.table + " lbReq " +
                "Where lbReq." + lbReq.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabRequest(dt);
            return lbReq1;
        }
        public DataTable selectByReq1()
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq."+lbReq.req_id+ ", lbReq." + lbReq.req_code + ", lbReq." + lbReq.hn_female + ", lbReq." + lbReq.vn + ", lbReq." + lbReq.name_female
                + ", lbReq." + lbReq.req_date + ", lbReq." + lbReq.remark +" "+
                "From " + lbReq.table + " lbReq " +
                "Where lbReq." + lbReq.status_req + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByProcess(String vsid)
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq.*, LabItem.LName " +
                "From " + lbReq.table + " lbReq " +
                "Left Join LabItem on lbReq." + lbReq.item_id + " = LabItem.LID " +
                "Where lbReq." + lbReq.status_req + " ='2' and LabItem.LGID='1' " +
                "Order By lbReq." + lbReq.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByProcess()
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq.*, LabItem.LName " +
                "From " + lbReq.table + " lbReq " +
                "Left Join LabItem on lbReq." + lbReq.item_id + " = LabItem.LID " +
                "Where lbReq." + lbReq.status_req + " ='2' and LabItem.LGID='1' " +
                "Order By lbReq." + lbReq.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByReq1()
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq.*, LabItem.LName " +
                "From " + lbReq.table + " lbReq " +
                "Left Join LabItem on lbReq."+ lbReq.item_id+" = LabItem.LID " +
                "Where lbReq." + lbReq.status_req + " ='1' and LabItem.LGID='1' " +
                "Order By lbReq."+lbReq.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByVsid(String vsid)
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq.*, LabItem.LName " +
                "From " + lbReq.table + " lbReq " +
                "Left Join LabItem on lbReq." + lbReq.item_id + " = LabItem.LID " +
                "Where lbReq." + lbReq.status_req + " ='1' and LabItem.LGID='1' and lbReq."+ lbReq.visit_id+" = '" + vsid + "' " +
                "Order By lbReq." + lbReq.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusReqAccept()
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq." + lbReq.req_id + ", lbReq." + lbReq.req_code + ", lbReq." + lbReq.hn_female + ", lbReq." + lbReq.vn + ", lbReq." + lbReq.name_female
                + ", lbReq." + lbReq.req_date + ", lbReq." + lbReq.remark + ",lbReq." + lbReq.doctor_id+", Doctor.Name as dtr_name, spi.SName " +
                ",lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date,lbReq.form_a_id, lforma.opu_wait_remark, lforma.remark as form_a_remark,lforma.status_opu_active,lforma.opu_time " +
                "From " + lbReq.table + " lbReq " +
                "Left Join Doctor on Doctor.ID = lbReq.doctor_id " +
                "Left Join SpecialItem spi on lbReq.item_id = spi.SID " +
                "Left Join lab_t_form_a lforma on lbReq.form_a_id = lforma.form_a_id " +
                "Where lbReq." + lbReq.status_req + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct lbReq.remark " +
                "From " + lbReq.table + " lbReq " +
                "Where lbReq." + lbReq.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusOPURequest(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select  concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, 'OPU' SName " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                //"Left join SpecialItem si on lreq.item_id = si.SID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where  lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') and lforma.status_opu_active ='1' " +
                //"Order By lforma.form_a_id ";
                "Order By lforma.opu_date, lforma.opu_time ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusOPURequest()
        {
            DataTable dt = new DataTable();
            String sql = "Select  lforma.name_female,lforma.hn_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, lforma.dob_female " +
                ", lforma.status_wait_confirm_day1,lforma.form_a_id,lforma.req_id_opu , lforma.form_a_id,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lforma.form_a_code, lforma.form_a_date, lforma.vn_old, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor" +
                ", lforma.name_donor, 'OPU' SName " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                //"Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                //"Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                //"Left join SpecialItem si on lreq.item_id = si.SID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where lreq.status_req in ('0','1','2') and lforma.status_opu_active ='1' " +
                //"Order By lforma.form_a_id ";
                "Order By lforma.opu_date, lforma.opu_time ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusUnAccept3(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select  concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, si.SName " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                "Left join SpecialItem si on lreq.item_id = si.SID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where  lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') " +
                //"Order By lforma.form_a_id ";
                "Order By lforma.opu_date, lforma.opu_time ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByNurse(String pttid)
        {
            DataTable dt = new DataTable();
            String sql = "Select  lreq.*,litem.LName " +
                "From lab_t_request lreq " +
                "Left Join t_visit vs on lreq.visit_id = vs.t_visit_id  " +
                "Left Join LabItem litem on lreq.item_id = litem.LID " +
                "Where  vs.t_patient_id = '" + pttid + "'  and lreq.active= '1' " +
                //"and lreq.item_id in ('14','18','66') " +
                "Order By lreq.req_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByNurseVn(String vn)
        {
            DataTable dt = new DataTable();
            String sql = "Select  lreq.*,litem.LName, lbres.*,litem.method_id, litem.lab_unit_id " +
                "From lab_t_request lreq " +
                //"Left Join t_visit vs on lreq.visit_id = vs.t_visit_id  " +
                "Left Join LabItem litem on lreq.item_id = litem.LID " +
                "Left Join lab_t_result lbres on lreq.req_id = lbres.req_id " +
                "Where  lreq.vn = '" + vn + "'  and lreq.active= '1' " +
                //"and lreq.item_id in ('14','18','66') " +
                "Order By lreq.req_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermStatusUnAccept()
        {
            DataTable dt = new DataTable();
            String sql = "Select  concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.sperm_analysis_date_start, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor, lforma.hn_female, lforma.name_female" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, si.LName, lforma.pasa_tese_date,lforma.iui_date,lforma.sperm_freezing_date_start " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                "Left join LabItem si on lreq.item_id = si.LID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where lreq.status_req in ('0','1','2') " +
                "and lreq.item_id in ('14','18','66')  and lreq.form_a_id > 0 " +
                "Order By lreq.req_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermStatusUnAccept(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select  concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.sperm_analysis_date_start, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, si.LName " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                "Left join LabItem si on lreq.item_id = si.LID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where  lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') " +
                "and lreq.item_id in ('14','18','66') "+
                "Order By lreq.req_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusUnAccept3FET(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select  concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, si.SName " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join Patient ptt on lreq.hn_female = ptt.PIDS " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID  " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                "Left join SpecialItem si on lreq.item_id = si.SID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where  lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') " +
                "and lreq.item_id in ('160') " +
                //"Order By lforma.form_a_id ";
                "Order By lforma.opu_date, lforma.opu_time ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusResult(String startdate, String enddate, String hn)
        {
            DataTable dt = new DataTable();
            String wheredate = "", wherehn = "";
            if (hn.Length > 0)
            {
                wherehn = " and lreq."+ lbReq.hn_female+" like '%"+hn+"%'";
            }
            if (startdate.Length > 0)
            {
                //wheredate = " and lreq.req_date >= '" + startdate + "' and lreq.req_date <= '" + enddate + "' ";
                wheredate = " and lreq.result_date >= '" + startdate + " 00:00:00' and lreq.result_date <= '" + enddate + " 23:59:59' ";
            }
            String sql = "Select lreq.req_id, concat(fpp.patient_prefix_description,' ',pttf.patient_firstname_e,' ',pttf.patient_lastname_e) as name_female" +
                ", concat(fppm.patient_prefix_description,' ',pttm.patient_firstname_e,' ',pttm.patient_lastname_e) as name_male" +
                ", Doctor.ID, Doctor.Name as dtr_name, Doctor.ID as dtrid, ifnull(lreq.remark,'') as remark " +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , lforma.form_a_id, lreq.hn_male,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, lreq.hn_female, lreq.req_date, lreq.remark, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_donor" +
                ", lforma.name_donor,lreq.vn, lreq.item_id, si.LName,si.LGID " +
                "From lab_t_request lreq " +
                "Left Join lab_t_form_a lforma on lreq.form_a_id = lforma.form_a_id  " +
                "Left Join t_patient pttf on lreq.hn_female = pttf.patient_hn and lreq.hn_female <> '' " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = pttf.f_patient_prefix_id " +
                "Left Join t_patient pttm on lreq.hn_male = pttm.patient_hn and lreq.hn_male <> '' " +
                "Left join f_patient_prefix fppm on fppm.f_patient_prefix_id = pttm.f_patient_prefix_id " +
                "Left join Doctor on lforma.doctor_id = Doctor.ID  " +
                "Left join LabItem si on lreq.item_id = si.LID " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                //"Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                //"Left Join Visit vsold on oJSd.VN = vsold.VN " +
                //"Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where  lreq.status_req = '5' " + wheredate + wherehn +
                "Order By lforma.form_a_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String UpdateStatusRequestAccept(String lbReqId, String userIdAccept)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + lbReq.table + " Set " +
                "" + lbReq.status_req + "='2' " +
                "," + lbReq.accept_date + "= now() " +
                "," + lbReq.accept_staff_id + "='" + userIdAccept + "' " +
                "Where " + lbReq.pkField + "='" + lbReqId + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        public String UpdateStatusRequestProcess(String lbReqId, String userIdAccept)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + lbReq.table + " Set " +
                "" + lbReq.status_req + "='4' " +
                "," + lbReq.start_date + "= now() " +
                "," + lbReq.start_staff_id + "='" + userIdAccept + "' " +
                "Where " + lbReq.pkField + "='" + lbReqId + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        public String UpdateStatusRequestResult(String lbReqId, String userIdAccept)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + lbReq.table + " Set " +
                "" + lbReq.status_req + "='5' " +
                "," + lbReq.result_date + "= now() " +
                "," + lbReq.result_staff_id + "='" + userIdAccept + "' " +
                "Where " + lbReq.pkField + "='" + lbReqId + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        public String UpdateStatusRequestAcceptOld(String oJsdId, String reqId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update JobSpecialDetail Set " +
                "status_req_accept='1' " +
                ",req_id='" + reqId + "' " +
                "Where id='" + oJsdId + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        public String VoidRequest(String reqId, String userId)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + lbReq.table + " Set " +
                "" + lbReq.active + "='3' " +
                "," + lbReq.date_cancel + "= now() " +
                "," + lbReq.user_cancel + "='" + userId + "' " +
                "Where " + lbReq.pkField + "='" + reqId + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        public String insert(LabRequest p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + lbReq.table + " Set " +
                " " + lbReq.req_code + " = '" + p.req_code + "'" +
                "," + lbReq.req_date + "= '" + p.req_date + "'" +
                "," + lbReq.hn_male + "= '" + p.hn_male + "'" +
                "," + lbReq.name_male + "= '" + p.name_male.Replace("'", "''") + "'" +
                "," + lbReq.hn_female + "= '" + p.hn_female.Replace("'", "''") + "'" +
                "," + lbReq.name_female + "= '" + p.name_female + "'" +
                "," + lbReq.active + "= '" + p.active + "'" +
                "," + lbReq.remark + "= '" + p.remark + "'" +
                "," + lbReq.status_req + "= '" + p.status_req + "'" +
                "," + lbReq.accept_date + "= '" + p.accept_date + "'" +
                "," + lbReq.start_date + "= '" + p.start_date + "'" +
                "," + lbReq.result_date + "= '" + p.result_date + "'" +
                "," + lbReq.visit_id + "= '" + p.visit_id + "'" +
                "," + lbReq.vn + "= '" + p.vn + "'" +
                "," + lbReq.item_id + "= '" + p.item_id + "'" +
                "," + lbReq.date_create + "= now()" +
                "," + lbReq.date_modi + "= ''" +
                "," + lbReq.date_cancel + "= ''" +
                "," + lbReq.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lbReq.user_modi + "= ''" +
                "," + lbReq.user_cancel + "= ''" +
                "," + lbReq.accept_staff_id + "= '" + p.accept_staff_id + "'" +
                "," + lbReq.start_staff_id + "= '" + p.start_staff_id + "'" +
                "," + lbReq.result_staff_id + "= '" + p.result_staff_id + "'" +
                "," + lbReq.doctor_id + " = '" + p.doctor_id + "'" +
                "," + lbReq.dob_donor + " = '" + p.dob_donor + "'" +
                "," + lbReq.dob_female + " = '" + p.dob_female + "'" +
                "," + lbReq.dob_male + " = '" + p.dob_male + "'" +
                "," + lbReq.hn_donor + " = '" + p.hn_donor + "'" +
                "," + lbReq.name_donor + " = '" + p.name_donor.Replace("'", "''") + "'" +
                "," + lbReq.lab_id + " = '" + p.lab_id + "'" +
                "," + lbReq.request_id + " = '" + p.request_id + "' " +
                "," + lbReq.form_a_id + " = '" + p.form_a_id + "' " +
                "," + lbReq.req_time + " = '" + p.req_time + "' " +
                "";
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
        public String insertLabRequest(LabRequest p, String userId)
        {
            String re = "";

            if (p.req_id.Equals("") || p.req_id.Equals("0"))
            {
                re = insert(p, userId);
            }
            else
            {
                //re = update(p, "");
            }

            return re;
        }
        public C1ComboBox setCboRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[lbReq.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public LabRequest setLabRequest(DataTable dt)
        {
            LabRequest lbReq1 = new LabRequest();
            if (dt.Rows.Count > 0)
            {
                lbReq1.req_id = dt.Rows[0][lbReq.req_id].ToString();
                lbReq1.req_code = dt.Rows[0][lbReq.req_code].ToString();
                lbReq1.req_date = dt.Rows[0][lbReq.req_date].ToString();
                lbReq1.hn_male = dt.Rows[0][lbReq.hn_male].ToString();
                lbReq1.name_male = dt.Rows[0][lbReq.name_male].ToString();
                lbReq1.hn_female = dt.Rows[0][lbReq.hn_female].ToString();
                lbReq1.name_female = dt.Rows[0][lbReq.name_female].ToString();
                lbReq1.status_req = dt.Rows[0][lbReq.status_req].ToString();
                lbReq1.accept_date = dt.Rows[0][lbReq.accept_date].ToString();
                lbReq1.start_date = dt.Rows[0][lbReq.start_date].ToString();
                lbReq1.result_date = dt.Rows[0][lbReq.result_date].ToString();
                lbReq1.visit_id = dt.Rows[0][lbReq.visit_id].ToString();
                lbReq1.vn = dt.Rows[0][lbReq.vn].ToString();
                lbReq1.active = dt.Rows[0][lbReq.active].ToString();
                lbReq1.remark = dt.Rows[0][lbReq.remark].ToString();
                lbReq1.date_create = dt.Rows[0][lbReq.date_create].ToString();
                lbReq1.date_modi = dt.Rows[0][lbReq.date_modi].ToString();
                lbReq1.date_cancel = dt.Rows[0][lbReq.date_cancel].ToString();
                lbReq1.user_create = dt.Rows[0][lbReq.user_create].ToString();
                lbReq1.user_modi = dt.Rows[0][lbReq.user_modi].ToString();
                lbReq1.user_cancel = dt.Rows[0][lbReq.user_cancel].ToString();
                lbReq1.item_id = dt.Rows[0][lbReq.item_id].ToString();
                lbReq1.accept_staff_id = dt.Rows[0][lbReq.accept_staff_id].ToString();
                lbReq1.start_staff_id = dt.Rows[0][lbReq.start_staff_id].ToString();
                lbReq1.result_staff_id = dt.Rows[0][lbReq.result_staff_id].ToString();
                lbReq1.doctor_id = dt.Rows[0][lbReq.doctor_id].ToString();
                lbReq1.form_a_id = dt.Rows[0][lbReq.form_a_id].ToString();
                lbReq1.request_id = dt.Rows[0][lbReq.request_id].ToString();
                lbReq1.dob_donor = dt.Rows[0][lbReq.dob_donor].ToString();
                lbReq1.req_time = dt.Rows[0][lbReq.req_time].ToString();
            }
            else
            {
                lbReq1.req_id = "";
                lbReq1.req_code = "";
                lbReq1.req_date = "";
                lbReq1.hn_male = "";
                lbReq1.name_male = "";
                lbReq1.hn_female = "";
                lbReq1.name_female = "";
                lbReq1.status_req = "";
                lbReq1.accept_date = "";
                lbReq1.start_date = "";
                lbReq1.result_date = "";
                lbReq1.visit_id = "";
                lbReq1.vn = "";
                lbReq1.active = "";
                lbReq1.remark = "";
                lbReq1.date_create = "";
                lbReq1.date_modi = "";
                lbReq1.date_cancel = "";
                lbReq1.user_create = "";
                lbReq1.user_modi = "";
                lbReq1.user_cancel = "";
                lbReq1.item_id = "";
                lbReq1.accept_staff_id = "";
                lbReq1.start_staff_id = "";
                lbReq1.result_staff_id = "";
                lbReq1.doctor_id = "";
                lbReq1.request_id = "";
                lbReq1.form_a_id = "";
                lbReq1.dob_donor = "";
                lbReq1.req_time = "";
            }

            return lbReq1;
        }
    }
}
