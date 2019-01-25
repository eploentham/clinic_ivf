﻿using C1.Win.C1Input;
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
        public DataTable selectByStatusReqAccept()
        {
            DataTable dt = new DataTable();
            String sql = "select lbReq." + lbReq.req_id + ", lbReq." + lbReq.req_code + ", lbReq." + lbReq.hn_female + ", lbReq." + lbReq.vn + ", lbReq." + lbReq.name_female
                + ", lbReq." + lbReq.req_date + ", lbReq." + lbReq.remark + ",lbReq." + lbReq.doctor_id+", Doctor.Name as dtr_name, spi.SName " +
                ",lforma.status_wait_confirm_day1,lforma.status_wait_confirm_opu_date,lbReq.form_a_id " +
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
                "," + lbReq.date_modi + "= '" + p.date_modi + "'" +
                "," + lbReq.date_cancel + "= '" + p.date_cancel + "'" +
                "," + lbReq.user_create + "= '" + userId + "'" +
                "," + lbReq.user_modi + "= '" + p.user_modi + "'" +
                "," + lbReq.user_cancel + "= '" + p.user_cancel + "'" +
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

            if (p.req_id.Equals(""))
            {
                re = insert(p, "");
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
            }

            return lbReq1;
        }
    }
}
