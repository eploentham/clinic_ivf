﻿using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobSpecialDB
    {
        public OldJobSpecial oJS;
        ConnectDB conn;
        public OldJobSpecialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oJS = new OldJobSpecial();
            oJS.VN = "VN";            
            oJS.Status = "Status";
            oJS.Include_Pkg_Price = "Include_Pkg_Price";
            oJS.Extra_Pkg_Price = "Extra_Pkg_Price";
            oJS.Total_Price = "Total_Price";
            oJS.Date = "Date";
            oJS.PID = "PID";
            oJS.PIDS = "PIDS";
            oJS.status_req = "status_req";

            oJS.table = "JobSpecial";
            oJS.pkField = "VN";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJS.* " +
                "From " + oJS.table + " oJS " +
                "Where oJS." + oJS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusUnAccept1(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select oJS.*, oJSd.SName, oJSd.SID, oJSd.ID as odsd_id, concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as pttname" +
                ", JobDoctor.DID, Doctor.Name as dtrname, Doctor.ID as dtrid, oJSd.status_req_accept, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,oJSd.req_id , vsold.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                //"Left Join Patient ptt on ptt.PID = oJS.PID " +                   //-0020
                //"Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +   //-0020
                "Left Join t_patient ptt on ptt.t_patient_id = oJS.PID " +                 //+0020
                //"Left Join JobDoctor on JobDoctor.VN = oJS.VN " +             //-0020
                //"Left join Doctor on JobDoctor.DName = Doctor.Name " +        //-0020
                "Left join Doctor on JobDoctor.DName = Doctor.ID " +          //+0020
                "Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Left Join Visit vsold on oJSd.VN = vsold.VN " +
                "Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (112,160) " +
                "and oJS.Date >= '"+startdate+ "' and oJS.Date <='"+enddate+"' " +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusUnAccept2(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select oJS.*, oJSd.SName, oJSd.SID, oJSd.ID as odsd_id, concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as name_female" +
                ", JobDoctor.DID, Doctor.Name as dtr_name, Doctor.ID as dtrid, oJSd.status_req_accept, ifnull(lreq.remark,'') as remark, DateOfBirth as dob" +
                ", lforma.status_wait_confirm_day1,lreq.form_a_id,lreq.req_id , vsold.form_a_id, ptt.PIDS,lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date " +
                ", lreq.req_code, ptt.PIDS as hn_female, lreq.req_date, lreq.remark, lforma.status_opu_active, lforma.status_wait_confirm_opu_date, lforma.opu_wait_remark, lforma.remark as form_a_remark " +
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor, lforma.name_donor " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Left Join Patient ptt on ptt.PID = oJS.PID " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Left Join JobDoctor on JobDoctor.VN = oJS.VN " +
                "Left join Doctor on JobDoctor.DName = Doctor.Name " +
                //"Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Left Join lab_t_request lreq on lreq.request_id = oJSd.ID  " +
                "Left Join Visit vsold on oJSd.VN = vsold.VN " +
                "Left Join lab_t_form_a lforma on vsold.form_a_id = lforma.form_a_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (112,160) and oJS.status_req = '0' " +
                "and lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') " +
                "Order By lforma.form_a_id ,oJSd.ID";
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
                ", lforma.opu_date, lforma.opu_time, lforma.opu_remark, lforma.fet_remark, lforma.opu_time_modi, lforma.status_opu_time_modi, lforma.hn_male, lforma.name_male, lforma.hn_donor, lforma.name_donor " +
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
                "Where  lreq.req_date >= '" + startdate + "' and lreq.req_date <='" + enddate + "' and lreq.status_req in ('0','1','2') " +
                "Order By lforma.form_a_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String chkByOPU(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Where oJSd.SID in (112) " +
                "and oJS.VN ='" + vn + "'" +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String chkByFET(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Where oJSd.SID in (160) " +
                "and oJS.VN ='" + vn + "'" +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusSememAnalysis(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Left Join Patient ptt on ptt.PID = oJS.PID " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Left Join JobDoctor on JobDoctor.VN = oJS.VN " +
                "Left join Doctor on JobDoctor.DName = Doctor.Name " +
                "Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (112) " +
                "and oJS.VN ='" + vn + "'" +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusOPU(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Left Join Patient ptt on ptt.PID = oJS.PID " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Left Join JobDoctor on JobDoctor.VN = oJS.VN " +
                "Left join Doctor on JobDoctor.DName = Doctor.Name " +
                "Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (112) " +
                "and oJS.VN ='" +vn + "'"+
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusFET(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Left Join Patient ptt on ptt.PID = oJS.PID " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Left Join JobDoctor on JobDoctor.VN = oJS.VN " +
                "Left join Doctor on JobDoctor.DName = Doctor.Name " +
                "Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (160) " +
                "and oJS.VN ='" + vn + "'" +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusFET1(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select oJSd.ID  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                //"Left Join Patient ptt on ptt.PID = oJS.PID " +
                //"Left Join Patient ptt on ptt.PID = oJS.PID " +
                //"Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                //"Left Join JobDoctor on JobDoctor.VN = oJS.VN " +
                //"Left join Doctor on JobDoctor.DName = Doctor.Name " +
                "Left Join lab_t_request lreq on lreq.req_id = oJSd.req_id " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID in (2640000160) " +
                "and oJS.VN ='" + vn + "'" +
                "Order By oJSd.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public OldJobSpecial selectByPk1(String copId)
        {
            OldJobSpecial cop1 = new OldJobSpecial();
            DataTable dt = new DataTable();
            String sql = "select oJS.* " +
                "From " + oJS.table + " oJS " +
                "Where oJS." + oJS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setVisitOld(dt);
            return cop1;
        }
        public String UpdateStatusRequestAccept(String oJsdId, String reqId)
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
        public OldJobSpecial setVisitOld(DataTable dt)
        {
            OldJobSpecial vsold1 = new OldJobSpecial();
            if (dt.Rows.Count > 0)
            {
                vsold1.VN = dt.Rows[0][oJS.VN].ToString();
                vsold1.Status = dt.Rows[0][oJS.Status].ToString();
                vsold1.Include_Pkg_Price = dt.Rows[0][oJS.Include_Pkg_Price].ToString();
                vsold1.Extra_Pkg_Price = dt.Rows[0][oJS.Extra_Pkg_Price].ToString();
                vsold1.Total_Price = dt.Rows[0][oJS.Total_Price].ToString();
                vsold1.Date = dt.Rows[0][oJS.Date].ToString();
                vsold1.PID = dt.Rows[0][oJS.PID].ToString();
                vsold1.PIDS = dt.Rows[0][oJS.PIDS].ToString();
                vsold1.status_req = dt.Rows[0][oJS.status_req].ToString();
            }
            else
            {
                setVisitOld1(vsold1);
            }
            return vsold1;
        }
        private OldJobSpecial setVisitOld1(OldJobSpecial stf1)
        {
            stf1.VN = "";
            stf1.Status = "";
            stf1.Include_Pkg_Price = "";
            stf1.Extra_Pkg_Price = "";
            stf1.Total_Price = "";
            stf1.Date = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.status_req = "";
            return stf1;
        }
        public String setJobSpecial(String vn, String hn, String pid)
        {
        //  $query = $this->db->query('select VN from JobSpecial Where VN="'. $VN. '"');
        //  $date = date("Y-m-d", time());
        //    if ($query->num_rows() == 0) {
        //    $PID = $this->session->userdata['PID'];
        //    $PIDS = $this->session->userdata['PIDS'];
        //    $this->db->query('insert into JobSpecial set VN="'. $VN. '", Status="1", date="'. $date. '", PID="'. $PID. '", PIDS="'. $PIDS. '"');
        //    }
            DataTable dt = new DataTable();
            String re = "", sql = "";
            sql = "select " + oJS.VN + " from " + oJS.table + " Where " + oJS.VN + "='" + vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count <= 0)
            {
                sql = "insert into "+oJS.table+" set VN='" + vn + "'" +
                    ", Status='1'" +
                    ", date=date(now()) " +
                    ", PID='" + pid + "'" +
                    ", PIDS='" + hn + "' ";
                try
                {
                    re = conn.ExecuteNonQuery(conn.conn, sql);
                }
                catch (Exception ex)
                {
                    sql = ex.Message + " " + ex.InnerException;
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
            sql = "Update " + oJS.table + " Set " +
                " " + oJS.Include_Pkg_Price + " = '" + inprice1 + "'" +
                "," + oJS.Extra_Pkg_Price + " = '" + exprice1 + "'" +
                "," + oJS.Total_Price + " = '" + total + "'" +
                //"," + ojlab.Status + " = '2'" +
                "Where " + oJS.VN + "='" + vn + "'"
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

            sql = "Update " + oJS.table + " Set " +
                " " + oJS.Status + " = '999'" +
                "Where " + oJS.VN + "='" + vn + "'"
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
    }
}
