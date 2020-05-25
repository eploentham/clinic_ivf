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
    public class LabFormDay1DB
    {
        public LabFormDay1 lformDay1;
        ConnectDB conn;

        public LabFormDay1DB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lformDay1 = new LabFormDay1();
            lformDay1.form_day1_id = "form_day1_id";
            lformDay1.t_patient_id = "t_patient_id";
            lformDay1.t_visit_id = "t_visit_id";
            lformDay1.day1_date = "day1_date";
            lformDay1.form_day1_code = "form_day1_code";
            lformDay1.hn_male = "hn_male";
            lformDay1.hn_female = "hn_female";
            lformDay1.name_male = "name_male";
            lformDay1.name_female = "name_female";
            lformDay1.hn_donor = "hn_donor";
            lformDay1.name_donor = "name_donor";
            lformDay1.day1_remark = "day1_remark";
            lformDay1.dob_male = "dob_male";
            lformDay1.dob_female = "dob_female";
            lformDay1.dob_donor = "dob_donor";
            lformDay1.status_no_biopsy = "status_no_biopsy";
            lformDay1.status_biopsy_pgs = "status_biopsy_pgs";
            lformDay1.status_biopsy_ngs = "status_biopsy_ngs";
            lformDay1.status_biopsy_ngs_7_pair = "status_biopsy_ngs_7_pair";
            lformDay1.status_biopsy_ngs_23_pair = "status_biopsy_ngs_23_pair";
            lformDay1.biopsy_pgs_min = "biopsy_pgs_min";
            lformDay1.biopsy_pgs_max = "biopsy_pgs_max";
            lformDay1.biopsy_ngs_min = "biopsy_ngs_min";
            lformDay1.biopsy_ngs_max = "biopsy_ngs_max";
            lformDay1.status_embryo_freezing_day = "status_embryo_freezing_day";
            lformDay1.embryo_freezing_day = "embryo_freezing_day";
            lformDay1.embryo_freezing_day_max = "embryo_freezing_day_max";
            lformDay1.status_stage_blastocyst = "status_stage_blastocyst";
            lformDay1.status_stage_morula = "status_stage_morula";
            lformDay1.status_stage_cleavage = "status_stage_cleavage";
            lformDay1.status_embryo_tranfer = "status_embryo_tranfer";
            lformDay1.status_embryo_tranfer_day = "status_embryo_tranfer_day";
            lformDay1.status_embryo_tranfer_embryo_glue = "status_embryo_tranfer_embryo_glue";
            lformDay1.status_discard_all = "status_discard_all";
            lformDay1.status_remark = "status_remark";
            lformDay1.remark_other = "remark_other";
            lformDay1.active = "active";
            lformDay1.remark = "remark";
            lformDay1.date_create = "date_create";
            lformDay1.date_modi = "date_modi";
            lformDay1.date_cancel = "date_cancel";
            lformDay1.user_create = "user_create";
            lformDay1.user_modi = "user_modi";
            lformDay1.user_cancel = "user_cancel";
            lformDay1.form_a_id = "form_a_id";
            lformDay1.fertili_2_pn = "fertili_2_pn";

            lformDay1.pkField = "form_day1_id";
            lformDay1.table = "lab_t_form_day1";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select lformDay1.* " +
                "From " + lformDay1.table + " lformDay1 " +
                "Where lformDay1." + lformDay1.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabFormDay1 selectByPk1(String pttId)
        {
            LabFormDay1 cop1 = new LabFormDay1();
            DataTable dt = new DataTable();
            String sql = "select lformDay1.* " +
                "From " + lformDay1.table + " lformDay1 " +
                "Where lformDay1." + lformDay1.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabFormDay1(dt);
            return cop1;
        }
        public LabFormDay1 selectByVsId(String vsid)
        {
            LabFormDay1 cop1 = new LabFormDay1();
            DataTable dt = new DataTable();
            String sql = "select lformDay1.* " +
                "From " + lformDay1.table + " lformDay1 " +
                "Where lformDay1." + lformDay1.t_visit_id + " ='" + vsid + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabFormDay1(dt);
            return cop1;
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct lformDay1.remark " +
                "From " + lformDay1.table + " lformDay1 " +
                "Where lformDay1." + lformDay1.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
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
                item.Text = row[lformDay1.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        private void chkNull(LabFormDay1 p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.day1_date = p.day1_date == null ? "" : p.day1_date;
            p.form_day1_code = p.form_day1_code == null ? "" : p.form_day1_code;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.hn_donor = p.hn_donor == null ? "" : p.hn_donor;
            p.name_donor = p.name_donor == null ? "" : p.name_donor;
            p.day1_remark = p.day1_remark == null ? "" : p.day1_remark;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.dob_donor = p.dob_donor == null ? "" : p.dob_donor;
            p.biopsy_pgs_min = p.biopsy_pgs_min == null ? "" : p.biopsy_pgs_min;
            p.biopsy_pgs_max = p.biopsy_pgs_max == null ? "" : p.biopsy_pgs_max;
            p.biopsy_ngs_min = p.biopsy_ngs_min == null ? "" : p.biopsy_ngs_min;
            p.biopsy_ngs_max = p.biopsy_ngs_max == null ? "" : p.biopsy_ngs_max;
            p.embryo_freezing_day = p.embryo_freezing_day == null ? "" : p.embryo_freezing_day;
            p.embryo_freezing_day_max = p.embryo_freezing_day_max == null ? "" : p.embryo_freezing_day_max;
            p.remark_other = p.remark_other == null ? "" : p.remark_other;
            p.active = p.active == null ? "1" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.fertili_2_pn = p.fertili_2_pn == null ? "" : p.fertili_2_pn;
            //p.opu_date = p.opu_date == null ? "" : p.opu_date;
            //p.opu_date = p.opu_date == null ? "" : p.opu_date;
            //p.opu_date = p.opu_date == null ? "" : p.opu_date;
            //p.opu_date = p.opu_date == null ? "" : p.opu_date;
            //p.opu_date = p.opu_date == null ? "" : p.opu_date;

            p.status_no_biopsy = p.status_no_biopsy == null ? "0" : p.status_no_biopsy;
            p.status_biopsy_pgs = p.status_biopsy_pgs == null ? "0" : p.status_biopsy_pgs;
            p.status_biopsy_ngs = p.status_biopsy_ngs == null ? "0" : p.status_biopsy_ngs;
            p.status_biopsy_ngs_7_pair = p.status_biopsy_ngs_7_pair == null ? "0" : p.status_biopsy_ngs_7_pair;
            p.status_biopsy_ngs_23_pair = p.status_biopsy_ngs_23_pair == null ? "0" : p.status_biopsy_ngs_23_pair;
            p.status_embryo_freezing_day = p.status_embryo_freezing_day == null ? "0" : p.status_embryo_freezing_day;
            p.status_stage_blastocyst = p.status_stage_blastocyst == null ? "0" : p.status_stage_blastocyst;
            p.status_stage_morula = p.status_stage_morula == null ? "0" : p.status_stage_morula;
            p.status_stage_cleavage = p.status_stage_cleavage == null ? "0" : p.status_stage_cleavage;
            p.status_embryo_tranfer = p.status_embryo_tranfer == null ? "0" : p.status_embryo_tranfer;
            p.status_embryo_tranfer_day = p.status_embryo_tranfer_day == null ? "0" : p.status_embryo_tranfer_day;
            p.status_embryo_tranfer_embryo_glue = p.status_embryo_tranfer_embryo_glue == null ? "0" : p.status_embryo_tranfer_embryo_glue;
            p.status_discard_all = p.status_discard_all == null ? "0" : p.status_discard_all;
            p.status_remark = p.status_remark == null ? "0" : p.status_remark;
            //p.y_selection = p.y_selection == null ? "0" : p.y_selection;
            //p.y_selection = p.y_selection == null ? "0" : p.y_selection;
            //p.y_selection = p.y_selection == null ? "0" : p.y_selection;
            //p.y_selection = p.y_selection == null ? "0" : p.y_selection;
            //p.y_selection = p.y_selection == null ? "0" : p.y_selection;

            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.form_a_id = long.TryParse(p.form_a_id, out chk) ? chk.ToString() : "0";
            //p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            //p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            //p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(LabFormDay1 p, String userId)
        {
            String re = "";
            String sql = "";

            chkNull(p);
            try
            {
                sql = "Insert Into " + lformDay1.table + " " +
                    "Set " + lformDay1.t_patient_id + "='" + p.t_patient_id + "'" +
                    "," + lformDay1.t_visit_id + "='" + p.t_visit_id + "'" +
                    "," + lformDay1.day1_date + "='" + p.day1_date + "'" +
                    "," + lformDay1.form_day1_code + "='" + p.form_day1_code + "'" +
                    "," + lformDay1.hn_male + "='" + p.hn_male + "'" +
                    "," + lformDay1.hn_female + "='" + p.hn_female + "'" +
                    "," + lformDay1.hn_donor + "='" + p.hn_donor + "'" +
                    "," + lformDay1.name_donor + "='" + p.name_donor + "'" +
                    "," + lformDay1.day1_remark + "='" + p.day1_remark + "'" +
                    "," + lformDay1.dob_male + "='" + p.dob_male + "'" +
                    "," + lformDay1.dob_female + "='" + p.dob_female + "'" +
                    "," + lformDay1.dob_donor + "='" + p.dob_donor + "'" +
                    "," + lformDay1.status_no_biopsy + "='" + p.status_no_biopsy + "'" +
                    "," + lformDay1.status_biopsy_pgs + "='" + p.status_biopsy_pgs + "'" +
                    "," + lformDay1.status_biopsy_ngs + "='" + p.status_biopsy_ngs + "'" +
                    "," + lformDay1.status_biopsy_ngs_7_pair + "='" + p.status_biopsy_ngs_7_pair + "'" +
                    "," + lformDay1.status_biopsy_ngs_23_pair + "='" + p.status_biopsy_ngs_23_pair + "'" +
                    "," + lformDay1.biopsy_pgs_min + "='" + p.biopsy_pgs_min + "'" +
                    "," + lformDay1.biopsy_pgs_max + "='" + p.biopsy_pgs_max + "'" +
                    "," + lformDay1.biopsy_ngs_min + "='" + p.biopsy_ngs_min + "'" +
                    "," + lformDay1.biopsy_ngs_max + "='" + p.biopsy_ngs_max + "'" +
                    "," + lformDay1.status_embryo_freezing_day + "='" + p.status_embryo_freezing_day + "'" +
                    "," + lformDay1.embryo_freezing_day + "='" + p.embryo_freezing_day + "'" +
                    "," + lformDay1.embryo_freezing_day_max + "='" + p.embryo_freezing_day_max + "'" +
                    "," + lformDay1.status_stage_blastocyst + "='" + p.status_stage_blastocyst + "'" +
                    "," + lformDay1.status_stage_morula + "='" + p.status_stage_morula + "'" +
                    "," + lformDay1.status_stage_cleavage + "='" + p.status_stage_cleavage + "'" +
                    "," + lformDay1.status_embryo_tranfer + "='" + p.status_embryo_tranfer + "'" +
                    "," + lformDay1.status_embryo_tranfer_day + "='" + p.status_embryo_tranfer_day + "'" +
                    "," + lformDay1.status_embryo_tranfer_embryo_glue + "='" + p.status_embryo_tranfer_embryo_glue + "'" +
                    "," + lformDay1.status_discard_all + "='" + p.status_discard_all + "'" +
                    "," + lformDay1.status_remark + "='" + p.status_remark + "'" +
                    "," + lformDay1.remark_other + "='" + p.remark_other + "'" +
                    
                    "," + lformDay1.active + "='" + p.active + "' " +
                    "," + lformDay1.remark + "='" + p.remark + "' " +
                    "," + lformDay1.date_create + "=now() " +
                    "," + lformDay1.date_modi + "='' " +

                    "," + lformDay1.date_cancel + "='' " +
                    "," + lformDay1.user_create + "='" + userId + "@" + conn._IPAddress + "' " +
                    "," + lformDay1.user_modi + "='' " +
                    "," + lformDay1.user_cancel + "='' " +
                    "," + lformDay1.form_a_id + "='" + p.form_a_id + "'" +
                    "," + lformDay1.fertili_2_pn + "='" + p.fertili_2_pn + "'" +

                    "";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String update(LabFormDay1 p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + lformDay1.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformDay1.t_patient_id + "='" + p.t_patient_id + "'" +
                    "," + lformDay1.t_visit_id + "='" + p.t_visit_id + "'" +
                    "," + lformDay1.day1_date + "='" + p.day1_date + "'" +
                    "," + lformDay1.form_day1_code + "='" + p.form_day1_code + "'" +
                    "," + lformDay1.hn_male + "='" + p.hn_male + "'" +
                    "," + lformDay1.hn_female + "='" + p.hn_female + "'" +
                    "," + lformDay1.hn_donor + "='" + p.hn_donor + "'" +
                    "," + lformDay1.name_donor + "='" + p.name_donor.Replace("'", "''") + "'" +
                    "," + lformDay1.day1_remark + "='" + p.day1_remark + "'" +
                    "," + lformDay1.dob_male + "='" + p.dob_male + "'" +
                    "," + lformDay1.dob_female + "='" + p.dob_female + "'" +
                    "," + lformDay1.dob_donor + "='" + p.dob_donor + "'" +
                    "," + lformDay1.status_no_biopsy + "='" + p.status_no_biopsy + "'" +
                    "," + lformDay1.status_biopsy_pgs + "='" + p.status_biopsy_pgs + "'" +
                    "," + lformDay1.status_biopsy_ngs + "='" + p.status_biopsy_ngs + "'" +
                    "," + lformDay1.status_biopsy_ngs_7_pair + "='" + p.status_biopsy_ngs_7_pair + "'" +
                    "," + lformDay1.status_biopsy_ngs_23_pair + "='" + p.status_biopsy_ngs_23_pair + "'" +
                    "," + lformDay1.biopsy_pgs_min + "='" + p.biopsy_pgs_min + "'" +
                    "," + lformDay1.biopsy_pgs_max + "='" + p.biopsy_pgs_max + "'" +
                    "," + lformDay1.biopsy_ngs_min + "='" + p.biopsy_ngs_min + "'" +
                    "," + lformDay1.biopsy_ngs_max + "='" + p.biopsy_ngs_max + "'" +
                    "," + lformDay1.status_embryo_freezing_day + "='" + p.status_embryo_freezing_day + "'" +
                    "," + lformDay1.embryo_freezing_day + "='" + p.embryo_freezing_day + "'" +
                    "," + lformDay1.embryo_freezing_day_max + "='" + p.embryo_freezing_day_max + "'" +
                    "," + lformDay1.status_stage_blastocyst + "='" + p.status_stage_blastocyst + "'" +
                    "," + lformDay1.status_stage_morula + "='" + p.status_stage_morula + "'" +
                    "," + lformDay1.status_stage_cleavage + "='" + p.status_stage_cleavage + "'" +
                    "," + lformDay1.status_embryo_tranfer + "='" + p.status_embryo_tranfer + "'" +
                    "," + lformDay1.status_embryo_tranfer_day + "='" + p.status_embryo_tranfer_day + "'" +
                    "," + lformDay1.status_embryo_tranfer_embryo_glue + "='" + p.status_embryo_tranfer_embryo_glue + "'" +
                    "," + lformDay1.status_discard_all + "='" + p.status_discard_all + "'" +
                    "," + lformDay1.status_remark + "='" + p.status_remark + "'" +
                    "," + lformDay1.remark_other + "='" + p.remark_other.Replace("'", "''") + "'" +
                    "," + lformDay1.date_modi + "=now() " +
                    "," + lformDay1.user_modi + "='" + userId + "@" + conn._IPAddress + "' " +
                    "," + lformDay1.form_a_id + "='" + p.form_a_id + "'" +
                    "," + lformDay1.fertili_2_pn + "='" + p.fertili_2_pn + "'" +
                " Where " + lformDay1.pkField + " = '" + p.form_day1_id + "' "
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
        public String insertLabFormday1(LabFormDay1 p, String userId)
        {
            String re = "";

            if (p.form_day1_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public LabFormDay1 setLabFormDay1(DataTable dt)
        {
            LabFormDay1 vs1 = new LabFormDay1();
            if (dt.Rows.Count > 0)
            {
                vs1.form_day1_id = dt.Rows[0][lformDay1.form_day1_id].ToString();
                vs1.t_patient_id = dt.Rows[0][lformDay1.t_patient_id].ToString();
                vs1.t_visit_id = dt.Rows[0][lformDay1.t_visit_id].ToString();
                vs1.day1_date = dt.Rows[0][lformDay1.day1_date].ToString();
                vs1.form_day1_code = dt.Rows[0][lformDay1.form_day1_code].ToString();
                vs1.hn_male = dt.Rows[0][lformDay1.hn_male].ToString();
                vs1.hn_female = dt.Rows[0][lformDay1.hn_female].ToString();
                vs1.name_male = dt.Rows[0][lformDay1.name_male].ToString();
                vs1.name_female = dt.Rows[0][lformDay1.name_female].ToString();
                vs1.hn_donor = dt.Rows[0][lformDay1.hn_donor].ToString();
                vs1.name_donor = dt.Rows[0][lformDay1.name_donor].ToString();
                vs1.day1_remark = dt.Rows[0][lformDay1.day1_remark].ToString();
                vs1.dob_male = dt.Rows[0][lformDay1.dob_male].ToString();
                vs1.dob_female = dt.Rows[0][lformDay1.dob_female].ToString();
                vs1.dob_donor = dt.Rows[0][lformDay1.dob_donor].ToString();
                vs1.status_no_biopsy = dt.Rows[0][lformDay1.status_no_biopsy].ToString();
                vs1.status_biopsy_pgs = dt.Rows[0][lformDay1.status_biopsy_pgs].ToString();
                vs1.status_biopsy_ngs = dt.Rows[0][lformDay1.status_biopsy_ngs].ToString();
                vs1.status_biopsy_ngs_7_pair = dt.Rows[0][lformDay1.status_biopsy_ngs_7_pair].ToString();
                vs1.status_biopsy_ngs_23_pair = dt.Rows[0][lformDay1.status_biopsy_ngs_23_pair].ToString();
                vs1.biopsy_pgs_min = dt.Rows[0][lformDay1.biopsy_pgs_min].ToString();
                vs1.biopsy_pgs_max = dt.Rows[0][lformDay1.biopsy_pgs_max].ToString();
                vs1.biopsy_ngs_min = dt.Rows[0][lformDay1.biopsy_ngs_min].ToString();
                vs1.biopsy_ngs_max = dt.Rows[0][lformDay1.biopsy_ngs_max].ToString();
                vs1.status_embryo_freezing_day = dt.Rows[0][lformDay1.status_embryo_freezing_day].ToString();
                vs1.embryo_freezing_day = dt.Rows[0][lformDay1.embryo_freezing_day].ToString();
                vs1.embryo_freezing_day_max = dt.Rows[0][lformDay1.embryo_freezing_day_max].ToString();
                vs1.status_stage_blastocyst = dt.Rows[0][lformDay1.status_stage_blastocyst].ToString();
                vs1.status_stage_morula = dt.Rows[0][lformDay1.status_stage_morula].ToString();
                vs1.status_stage_cleavage = dt.Rows[0][lformDay1.status_stage_cleavage].ToString();
                vs1.status_embryo_tranfer = dt.Rows[0][lformDay1.status_embryo_tranfer].ToString();
                vs1.status_embryo_tranfer_day = dt.Rows[0][lformDay1.status_embryo_tranfer_day].ToString();
                vs1.status_embryo_tranfer_embryo_glue = dt.Rows[0][lformDay1.status_embryo_tranfer_embryo_glue].ToString();
                vs1.status_discard_all = dt.Rows[0][lformDay1.status_discard_all].ToString();
                vs1.status_remark = dt.Rows[0][lformDay1.status_remark].ToString();
                vs1.remark_other = dt.Rows[0][lformDay1.remark_other].ToString();
                vs1.active = dt.Rows[0][lformDay1.active].ToString();
                vs1.remark = dt.Rows[0][lformDay1.remark].ToString();
                vs1.date_create = dt.Rows[0][lformDay1.date_create].ToString();
                vs1.date_modi = dt.Rows[0][lformDay1.date_modi].ToString();
                vs1.date_cancel = dt.Rows[0][lformDay1.date_cancel].ToString();
                vs1.user_create = dt.Rows[0][lformDay1.user_create].ToString();
                vs1.user_modi = dt.Rows[0][lformDay1.user_modi].ToString();
                vs1.user_cancel = dt.Rows[0][lformDay1.user_cancel].ToString();
                vs1.form_a_id = dt.Rows[0][lformDay1.form_a_id].ToString();
                vs1.fertili_2_pn = dt.Rows[0][lformDay1.fertili_2_pn].ToString();
            }
            else
            {
                setLabFormDay1(vs1);
            }
            return vs1;
        }
        public LabFormDay1 setLabFormDay1(LabFormDay1 vs1)
        {
            vs1.form_day1_id = "";
            vs1.t_patient_id = "";
            vs1.t_visit_id = "";
            vs1.day1_date = "";
            vs1.form_day1_code = "";
            vs1.hn_male = "";
            vs1.hn_female = "";
            vs1.name_male = "";
            vs1.name_female = "";
            vs1.hn_donor = "";
            vs1.name_donor = "";
            vs1.day1_remark = "";
            vs1.dob_male = "";
            vs1.dob_female = "";
            vs1.dob_donor = "";
            vs1.status_no_biopsy = "";
            vs1.status_biopsy_pgs = "";
            vs1.status_biopsy_ngs = "";
            vs1.status_biopsy_ngs_7_pair = "";
            vs1.status_biopsy_ngs_23_pair = "";
            vs1.biopsy_pgs_min = "";
            vs1.biopsy_pgs_max = "";
            vs1.biopsy_ngs_min = "";
            vs1.biopsy_ngs_max = "";
            vs1.status_embryo_freezing_day = "";
            vs1.embryo_freezing_day = "";
            vs1.embryo_freezing_day_max = "";
            vs1.status_stage_blastocyst = "";
            vs1.status_stage_morula = "";
            vs1.status_stage_cleavage = "";
            vs1.status_embryo_tranfer = "";
            vs1.status_embryo_tranfer_day = "";
            vs1.status_embryo_tranfer_embryo_glue = "";
            vs1.status_discard_all = "";
            vs1.status_remark = "";
            vs1.remark_other = "";
            vs1.active = "";
            vs1.remark = "";
            vs1.date_create = "";
            vs1.date_modi = "";
            vs1.date_cancel = "";
            vs1.user_create = "";
            vs1.user_modi = "";
            vs1.user_cancel = "";
            vs1.form_a_id = "";
            vs1.fertili_2_pn = "";
            return vs1;
        }
    }
}
