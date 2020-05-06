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
    public class LabSpermDB
    {
        public LabSperm lsperm;
        ConnectDB conn;
        public LabSpermDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lsperm = new LabSperm();
            lsperm.sperm_id = "sperm_id";
            lsperm.sperm_code = "sperm_code";
            lsperm.hn_male = "hn_male";
            lsperm.hn_female = "hn_female";
            lsperm.name_male = "name_male";
            lsperm.name_female = "name_female";
            lsperm.dob_female = "dob_female";
            lsperm.dob_male = "dob_male";
            lsperm.doctor_id = "doctor_id";
            lsperm.abstinence_day = "abstinence_day";
            lsperm.sperm_date = "sperm_date";
            lsperm.appearance = "appearance";
            lsperm.liquefaction = "liquefaction";

            lsperm.status_fresh_sperm = "status_fresh_sperm";
            lsperm.status_frozen_sperm = "status_frozen_sperm";

            lsperm.viscosity = "viscosity";
            lsperm.viability = "viability";
            lsperm.volume1 = "volume1";
            lsperm.count1 = "count1";
            lsperm.total_count = "total_count";
            lsperm.motile = "motile";
            lsperm.total_motile = "total_motile";
            lsperm.motility = "motility";
            lsperm.motility_rate_4 = "motility_rate_4";
            lsperm.motility_rate_3 = "motility_rate_3";
            lsperm.motility_rate_2 = "motility_rate_2";
            lsperm.motility_rate_1 = "motility_rate_1";
            lsperm.recive_time = "recive_time";
            lsperm.examination_time = "examination_time";
            lsperm.finish_time = "finish_time";
            lsperm.sort1 = "sort1";
            lsperm.staff_id_report = "staff_id_report";
            lsperm.staff_id_approve = "staff_id_approve";
            lsperm.date_report = "date_report";
            lsperm.date_approve = "date_approve";
            lsperm.morphology_normal = "morphology_normal";
            lsperm.morphology_abnormal = "morphology_abnormal";
            lsperm.morphology_head_defect = "morphology_head_defect";
            lsperm.morphology_neck_defect = "morphology_neck_defect";
            lsperm.morphology_tail_defect = "morphology_tail_defect";
            lsperm.no_of_vail = "no_of_vail";
            lsperm.wbc = "wbc";
            lsperm.active = "active";
            lsperm.remark = "remark";
            lsperm.date_create = "date_create";
            lsperm.date_modi = "date_modi";
            lsperm.date_cancel = "date_cancel";
            lsperm.user_create = "user_create";
            lsperm.user_modi = "user_modi";
            lsperm.user_cancel = "user_cancel";
            lsperm.ph = "ph";
            lsperm.status_owner_sperm = "status_owner_sperm";
            lsperm.status_donor_sperm = "status_donor_sperm";
            lsperm.status_fresh_sperm = "status_fresh_sperm";

            lsperm.status_frozen_sperm = "status_frozen_sperm";
            lsperm.frozen_sperm_vail = "frozen_sperm_vail";
            
            lsperm.status_lab_sperm = "status_lab_sperm";
            lsperm.req_id = "req_id";
            lsperm.status_lab = "status_lab";
            lsperm.sperm_analysis_date_start = "sperm_analysis_date_start";
            lsperm.spern_freezing_date_start = "spern_freezing_date_start";
            lsperm.pasa_tese_date = "pasa_tese_date";
            lsperm.iui_date = "iui_date";
            lsperm.form_a_id = "form_a_id";
            lsperm.ejaculation_time = "ejaculation_time";
            lsperm.post_count = "post_count";
            lsperm.post_motile = "post_motile";
            lsperm.post_motility_rate_1 = "post_motility_rate_1";
            lsperm.post_motility_rate_2 = "post_motility_rate_2";
            lsperm.post_motility_rate_3 = "post_motility_rate_3";
            lsperm.post_motility_rate_4 = "post_motility_rate_4";
            lsperm.post_total_count = "post_total_count";
            lsperm.post_total_motile = "post_total_motile";
            lsperm.post_volume1 = "post_volume1";
            lsperm.post_motility = "post_motility";
            lsperm.morphology_head_defect1 = "morphology_head_defect1";
            lsperm.morphology_neck_defect1 = "morphology_neck_defect1";
            lsperm.morphology_tail_defect1 = "morphology_tail_defect1";
            lsperm.staff_id_finish = "staff_id_finish";
            lsperm.date_finish = "date_finish";
            lsperm.appearance_text = "appearance_text";

            lsperm.pkField = "sperm_id";
            lsperm.table = "lab_t_sperm";

        }
        private void chkNull(LabSperm p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.sperm_date = p.sperm_date == null ? "" : p.sperm_date;
            p.appearance = p.appearance == null ? "" : p.appearance;
            p.liquefaction = p.liquefaction == null ? "" : p.liquefaction;
            p.status_fresh_sperm = p.status_fresh_sperm == null ? "" : p.status_fresh_sperm;
            p.status_frozen_sperm = p.status_frozen_sperm == null ? "" : p.status_frozen_sperm;
            p.viscosity = p.viscosity == null ? "" : p.viscosity;
            p.viability = p.viability == null ? "" : p.viability;
            p.volume1 = p.volume1 == null ? "" : p.volume1;
            //p.abstinence_day = p.abstinence_day == null ? "" : p.abstinence_day;
            p.count1 = p.count1 == null ? "" : p.count1;
            p.total_count = p.total_count == null ? "" : p.total_count;
            p.motile = p.motile == null ? "" : p.motile;
            p.total_motile = p.total_motile == null ? "" : p.total_motile;
            p.motility = p.motility == null ? "" : p.motility;
            p.motility_rate_4 = p.motility_rate_4 == null ? "" : p.motility_rate_4;
            p.motility_rate_3 = p.motility_rate_3 == null ? "" : p.motility_rate_3;
            p.motility_rate_2 = p.motility_rate_2 == null ? "" : p.motility_rate_2;
            p.motility_rate_1 = p.motility_rate_1 == null ? "" : p.motility_rate_1;
            p.recive_time = p.recive_time == null ? "" : p.recive_time;
            
            p.finish_time = p.finish_time == null ? "" : p.finish_time;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.staff_id_report = p.staff_id_report == null ? "" : p.staff_id_report;
            p.staff_id_approve = p.staff_id_approve == null ? "" : p.staff_id_approve;
            p.date_report = p.date_report == null ? "" : p.date_report;
            p.date_approve = p.date_approve == null ? "" : p.date_approve;
            p.morphology_normal = p.morphology_normal == null ? "" : p.morphology_normal;
            p.morphology_abnormal = p.morphology_abnormal == null ? "" : p.morphology_abnormal;
            p.morphology_head_defect = p.morphology_head_defect == null ? "" : p.morphology_head_defect;
            p.morphology_neck_defect = p.morphology_neck_defect == null ? "" : p.morphology_neck_defect;
            p.morphology_tail_defect = p.morphology_tail_defect == null ? "" : p.morphology_tail_defect;
            p.no_of_vail = p.no_of_vail == null ? "" : p.no_of_vail;
            p.wbc = p.wbc == null ? "" : p.wbc;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_owner_sperm = p.status_owner_sperm == null ? "" : p.status_owner_sperm;
            p.status_donor_sperm = p.status_donor_sperm == null ? "" : p.status_donor_sperm;
            p.status_fresh_sperm = p.status_fresh_sperm == null ? "" : p.status_fresh_sperm;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.status_frozen_sperm = p.status_frozen_sperm == null ? "" : p.status_frozen_sperm;
            p.frozen_sperm_vail = p.frozen_sperm_vail == null ? "" : p.frozen_sperm_vail;
            p.status_lab_sperm = p.status_lab_sperm == null ? "" : p.status_lab_sperm;
            p.req_id = p.req_id == null ? "" : p.req_id;
            
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;

            p.status_lab = p.status_lab == null ? "0" : p.status_lab;
            p.ph = p.ph == null ? "" : p.ph;
            p.abstinence_day = p.abstinence_day == null ? "" : p.abstinence_day;
            p.abstinence_day = p.abstinence_day == null ? "" : p.abstinence_day;
            p.sperm_analysis_date_start = p.sperm_analysis_date_start == null ? "" : p.sperm_analysis_date_start;
            p.spern_freezing_date_start = p.spern_freezing_date_start == null ? "" : p.spern_freezing_date_start;
            p.pasa_tese_date = p.pasa_tese_date == null ? "" : p.pasa_tese_date;
            p.iui_date = p.iui_date == null ? "" : p.iui_date;
            p.recive_time = p.recive_time == null ? "" : p.recive_time;
            p.examination_time = p.examination_time == null ? "" : p.examination_time;
            p.finish_time = p.finish_time == null ? "" : p.finish_time;
            p.ejaculation_time = p.ejaculation_time == null ? "" : p.ejaculation_time;
            p.no_of_vail = p.no_of_vail == null ? "" : p.no_of_vail;
            p.post_count = p.post_count == null ? "" : p.post_count;
            p.post_motile = p.post_motile == null ? "" : p.post_motile;
            p.post_motility_rate_1 = p.post_motility_rate_1 == null ? "" : p.post_motility_rate_1;
            p.post_motility_rate_2 = p.post_motility_rate_2 == null ? "" : p.post_motility_rate_2;
            p.post_motility_rate_3 = p.post_motility_rate_3 == null ? "" : p.post_motility_rate_3;
            p.post_motility_rate_4 = p.post_motility_rate_4 == null ? "" : p.post_motility_rate_4;
            p.post_total_count = p.post_total_count == null ? "" : p.post_total_count;
            p.post_total_motile = p.post_total_motile == null ? "" : p.post_total_motile;
            p.post_volume1 = p.post_volume1 == null ? "" : p.post_volume1;
            p.post_motility = p.post_motility == null ? "" : p.post_motility;
            p.morphology_head_defect1 = p.morphology_head_defect1 == null ? "" : p.morphology_head_defect1;
            p.morphology_neck_defect1 = p.morphology_neck_defect1 == null ? "" : p.morphology_neck_defect1;
            p.morphology_tail_defect1 = p.morphology_tail_defect1 == null ? "" : p.morphology_tail_defect1;
            p.date_finish = p.date_finish == null ? "" : p.date_finish;
            p.appearance_text = p.appearance_text == null ? "" : p.appearance_text;

            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.form_a_id = long.TryParse(p.form_a_id, out chk) ? chk.ToString() : "0";
            p.staff_id_report = long.TryParse(p.staff_id_report, out chk) ? chk.ToString() : "0";
            p.staff_id_approve = long.TryParse(p.staff_id_approve, out chk) ? chk.ToString() : "0";
            p.staff_id_finish = long.TryParse(p.staff_id_finish, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            LabSperm lbReq1 = new LabSperm();
            DataTable dt = new DataTable();
            //String sql = "select lsperm.*,dtr.Name as doctorname" +
            //    ",fdtapp.doc_type_name as doc_type_name_app" +
            //    ",fdtliq.doc_type_name as doc_type_name_liq" +
            //    ",fdtvis.doc_type_name as doc_type_name_vis" +
            //    ",fdtwbc.doc_type_name as doc_type_name_wbc" +
            //    ",fdtnoo.doc_type_name as doc_type_name_noo, concat(fpprpt.patient_prefix_description,' ',stfrpt.staff_fname_e,' ',stfrpt.staff_lname_e) as staff_report_name " +
            //    ", concat(fppapp.patient_prefix_description,' ',stfapp.staff_fname_e,' ',stfapp.staff_lname_e) as staff_approve_name " +
            //    "From " + lsperm.table + " lsperm " +
            //    "Left Join Doctor dtr on dtr.ID = lsperm." + lsperm.doctor_id + " " +
            //    "Left Join f_doc_type fdtapp on lsperm.appearance = fdtapp.doc_type_id " +
            //    "Left Join f_doc_type fdtliq on lsperm.liquefaction = fdtliq.doc_type_id " +
            //    "Left Join f_doc_type fdtvis on lsperm.viscosity = fdtvis.doc_type_id " +
            //    "Left Join f_doc_type fdtwbc on lsperm.wbc = fdtwbc.doc_type_id " +
            //    "Left Join f_doc_type fdtnoo on lsperm.no_of_vail = fdtnoo.doc_type_id " +
            //    "Left Join b_staff stfrpt on lsperm.staff_id_report = stfrpt.staff_id " +
            //    "Left Join f_patient_prefix fpprpt on stfrpt.prefix_id = fpprpt.f_patient_prefix_id " +
            //    "Left Join b_staff stfapp on lsperm.staff_id_approve = stfapp.staff_id " +
            //    "Left Join f_patient_prefix fppapp on stfapp.prefix_id = fppapp.f_patient_prefix_id " +
            //    "Where lsperm." + lsperm.pkField + " ='" + copId + "' ";
            String sql = "select lsperm.*,dtr.Name as doctorname" +
               ",fdtapp.doc_type_name as doc_type_name_app" +
               ",fdtliq.doc_type_name as doc_type_name_liq" +
               ",fdtvis.doc_type_name as doc_type_name_vis" +
               ",fdtwbc.doc_type_name as doc_type_name_wbc" +
               ",fdtnoo.doc_type_name as doc_type_name_noo, concat(stfrpt.staff_fname_e,' ',stfrpt.staff_lname_e) as staff_report_name " +
               ", concat(stfapp.staff_fname_e,' ',stfapp.staff_lname_e) as staff_approve_name " +
               "From " + lsperm.table + " lsperm " +
               "Left Join Doctor dtr on dtr.ID = lsperm." + lsperm.doctor_id + " " +
               "Left Join f_doc_type fdtapp on lsperm.appearance = fdtapp.doc_type_id " +
               "Left Join f_doc_type fdtliq on lsperm.liquefaction = fdtliq.doc_type_id " +
               "Left Join f_doc_type fdtvis on lsperm.viscosity = fdtvis.doc_type_id " +
               "Left Join f_doc_type fdtwbc on lsperm.wbc = fdtwbc.doc_type_id " +
               "Left Join f_doc_type fdtnoo on lsperm.no_of_vail = fdtnoo.doc_type_id " +
               "Left Join b_staff stfrpt on lsperm.staff_id_report = stfrpt.staff_id " +
               "Left Join f_patient_prefix fpprpt on stfrpt.prefix_id = fpprpt.f_patient_prefix_id " +
               "Left Join b_staff stfapp on lsperm.staff_id_approve = stfapp.staff_id " +
               "Left Join f_patient_prefix fppapp on stfapp.prefix_id = fppapp.f_patient_prefix_id " +
               "Where lsperm." + lsperm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            
            return dt;
        }
        public LabSperm selectByPk1(String copId)
        {
            LabSperm lbReq1 = new LabSperm();
            DataTable dt = new DataTable();
            String sql = "select lsperm.*,dtr.Name as doctorname " +
                "From " + lsperm.table + " lsperm " +
                "Left Join Doctor dtr on dtr.ID = lsperm." + lsperm.doctor_id + " " +                
                "Where lsperm." + lsperm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabSperm(dt);
            return lbReq1;
        }
        public LabSperm selectByReqId(String reqId)
        {
            LabSperm lbReq1 = new LabSperm();
            DataTable dt = new DataTable();
            String sql = "select lsperm.* , '' as doctorname " +
                "From " + lsperm.table + " lsperm " +
                //"Left Join Doctor dtr on dtr.ID = lsperm." + lsperm.doctor_id + " " +
                "Where lsperm." + lsperm.req_id + " ='" + reqId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabSperm(dt);
            return lbReq1;
        }
        public DataTable selectByStatusProcess1()
        {
            DataTable dt = new DataTable();
            String sql = "select lsperm.*, Doctor.Name as dtr_name  " +
                
                "From " + lsperm.table + " lsperm " +
                "Left Join Doctor on Doctor.ID = lsperm.doctor_id " +
                //"Left Join lab_b_procedure on opu.proce_id = lab_b_procedure.proce_id " +
                "Where lsperm." + lsperm.status_lab + " = '1' and lsperm." + lsperm.active + "='1' " +
                //"Order By opu." + opu.opu_id + " " +
                //"Union " +
                //"select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark, fet.hn_male, fet.name_male, lab_b_procedure.proce_name_t " +
                //"From lab_t_fet fet  " +
                //"Left Join Doctor on Doctor.ID = fet.doctor_id " +
                //"Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                //"Where fet.status_fet ='1' and fet.active + '1' " +
                //"Order By fet.fet_id  ";
                "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusFinish(String datestart, String dateend)
        {
            DataTable dt = new DataTable();
            String sql = "select lsperm.*, Doctor.Name as dtr_name " +
                "From " + lsperm.table + " lsperm " +
                "Left Join Doctor on Doctor.ID = lsperm.doctor_id " +
                //"Left Join lab_b_procedure on opu.proce_id = lab_b_procedure.proce_id " +
                "Where lsperm." + lsperm.status_lab + " ='2' and lsperm." + lsperm.active + "='1' " +
                "and lsperm." + lsperm.date_finish + " >= '" + datestart + " 00:00:00' and lsperm." + lsperm.date_finish + " <= '" + dateend + " 23:59:59' " +
            //"Order By opu." + opu.opu_id + " " +
            //"Union " +
            //"select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark, fet.hn_male, fet.name_male, lab_b_procedure.proce_name_t " +
            //"From lab_t_fet fet  " +
            //"Left Join Doctor on Doctor.ID = fet.doctor_id " +
            //"Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
            //"Where fet.status_fet ='1' and fet.active + '1' " +
            //"Order By fet.fet_id  ";
            "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct lsperm.remark " +
                "From " + lsperm.table + " lsperm " +
                "Where lsperm." + lsperm.active + "='1' ";
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
                item.Text = row[lsperm.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public String insert(LabSperm p, String userId)
        {
            String re = "";
            String sql = "";

            chkNull(p);
            try
            {
                sql = "Insert Into " + lsperm.table + " " +
                    "Set " + lsperm.sperm_code + "='" + p.sperm_code + "'" +
                    "," + lsperm.abstinence_day + "='" + p.abstinence_day.Replace("'", "''") + "'" +
                    "," + lsperm.sperm_date + "='" + p.sperm_date.Replace("'", "''") + "'" +
                    "," + lsperm.appearance + "='" + p.appearance.Replace("'", "''") + "'" +
                    "," + lsperm.liquefaction + "='" + p.liquefaction.Replace("'", "''") + "'" +
                    "," + lsperm.status_fresh_sperm + "='" + p.status_fresh_sperm + "'" +
                    "," + lsperm.status_frozen_sperm + "='" + p.status_frozen_sperm + "'" +
                    "," + lsperm.viscosity + "='" + p.viscosity.Replace("'", "''") + "'" +
                    "," + lsperm.viability + "='" + p.viability.Replace("'", "''") + "'" +
                    "," + lsperm.volume1 + "='" + p.volume1.Replace("'", "''") + "'" +
                    "," + lsperm.count1 + "='" + p.count1.Replace("'", "''") + "'" +
                    "," + lsperm.total_count + "='" + p.total_count.Replace("'", "''") + "'" +
                    "," + lsperm.motile + "='" + p.motile.Replace("'", "''") + "'" +
                    "," + lsperm.total_motile + "='" + p.total_motile.Replace("'", "''") + "'" +
                    "," + lsperm.motility + "='" + p.motility.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_4 + "='" + p.motility_rate_4.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_3 + "='" + p.motility_rate_3.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_2 + "='" + p.motility_rate_2.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_1 + "='" + p.motility_rate_1.Replace("'", "''") + "'" +                    
                    "," + lsperm.finish_time + "='" + p.finish_time + "'" +
                    "," + lsperm.sort1 + "='" + p.sort1 + "'" +
                    "," + lsperm.staff_id_report + "='" + p.staff_id_report + "'" +
                    "," + lsperm.staff_id_approve + "='" + p.staff_id_approve + "'" +
                    "," + lsperm.date_report + "='" + p.date_report + "'" +
                    "," + lsperm.date_approve + "='" + p.date_approve + "'" +
                    "," + lsperm.morphology_normal + "='" + p.morphology_normal.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_abnormal + "='" + p.morphology_abnormal.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_head_defect + "='" + p.morphology_head_defect.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_neck_defect + "='" + p.morphology_neck_defect.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_tail_defect + "='" + p.morphology_tail_defect.Replace("'", "''") + "'" +
                    "," + lsperm.no_of_vail + "='" + p.no_of_vail.Replace("'", "''") + "'" +
                    "," + lsperm.wbc + "='" + p.wbc.Replace("'", "''") + "'" +
                    "," + lsperm.active + "='1' " +
                    "," + lsperm.remark + "='" + p.remark.Replace("'", "''") + "' " +
                    "," + lsperm.date_create + "=now() " +
                    "," + lsperm.date_modi + "='' " +
                    "," + lsperm.date_cancel + "='' " +
                    "," + lsperm.user_create + "='" + userId + "@" + conn._IPAddress + "' " +
                    "," + lsperm.user_modi + "='' " +
                    "," + lsperm.user_cancel + "='' " +
                    "," + lsperm.ph + "='" + p.ph + "' " +
                    "," + lsperm.status_owner_sperm + "='" + p.status_owner_sperm + "' " +
                    "," + lsperm.status_donor_sperm + "='" + p.status_donor_sperm + "' " +
                    //"," + lsperm.dob_female + "='" + p.dob_female + "' " +
                    "," + lsperm.hn_male + "='" + p.hn_male.Replace("'", "''") + "' " +
                    "," + lsperm.hn_female + "='" + p.hn_female.Replace("'", "''") + "' " +
                    "," + lsperm.name_male + "='" + p.name_male.Replace("'", "''") + "' " +
                    "," + lsperm.name_female + "='" + p.name_female.Replace("'", "''") + "' " +
                    //"," + lsperm.status_frozen_sperm + "='" + p.status_frozen_sperm + "' " +
                    "," + lsperm.frozen_sperm_vail + "='" + p.frozen_sperm_vail + "' " +
                    "," + lsperm.doctor_id + "='" + p.doctor_id + "' " +
                    "," + lsperm.status_lab_sperm + "='" + p.status_lab_sperm + "' " +
                    "," + lsperm.req_id + "='" + p.req_id + "' " +                    
                    "," + lsperm.dob_female + "='" + p.dob_female.Replace("'", "''") + "' " +
                    "," + lsperm.dob_male + "='" + p.dob_male.Replace("'", "''") + "' " +
                    "," + lsperm.status_lab + "='1' " +
                    "," + lsperm.sperm_analysis_date_start + "='" + p.sperm_analysis_date_start + "' " +
                    "," + lsperm.spern_freezing_date_start + "='" + p.spern_freezing_date_start + "' " +
                    "," + lsperm.pasa_tese_date + "='" + p.pasa_tese_date + "' " +
                    "," + lsperm.iui_date + "='" + p.iui_date + "' " +
                    "," + lsperm.form_a_id + "='" + p.form_a_id + "' " +
                    "," + lsperm.recive_time + "='" + p.recive_time + "' " +
                    "," + lsperm.examination_time + "='" + p.examination_time + "' " +
                    //"," + lsperm.finish_time + "='" + p.finish_time + "' " +
                    "," + lsperm.ejaculation_time + "='" + p.ejaculation_time + "' " +
                    "," + lsperm.post_count + "='" + p.post_count.Replace("'", "''") + "' " +
                    "," + lsperm.post_motile + "='" + p.post_motile.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_1 + "='" + p.post_motility_rate_1.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_2 + "='" + p.post_motility_rate_2.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_3 + "='" + p.post_motility_rate_3.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_4 + "='" + p.post_motility_rate_4.Replace("'", "''") + "' " +
                    "," + lsperm.post_total_count + "='" + p.post_total_count.Replace("'", "''") + "' " +
                    "," + lsperm.post_total_motile + "='" + p.post_total_motile.Replace("'", "''") + "' " +
                    "," + lsperm.post_volume1 + "='" + p.post_volume1.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility + "='" + p.post_motility.Replace("'", "''") + "' " +
                    "," + lsperm.morphology_head_defect1 + "='" + p.morphology_head_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_neck_defect1 + "='" + p.morphology_neck_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_tail_defect1 + "='" + p.morphology_tail_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.staff_id_finish + "='" + p.staff_id_finish + "'" +
                    "," + lsperm.date_finish + "=''" +
                    "," + lsperm.appearance_text + "='" + p.appearance_text.Replace("'", "''") + "'" +
                    "";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("e", "Error insert LabSperm " + sql);
            }
            return re;
        }
        public String update(LabSperm p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + lsperm.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lsperm.sperm_code + "='" + p.sperm_code.Replace("'", "''") + "' " +
                "," + lsperm.abstinence_day + "='" + p.abstinence_day.Replace("'", "''") + "'" +
                    "," + lsperm.sperm_date + "='" + p.sperm_date.Replace("'", "''") + "'" +
                    "," + lsperm.appearance + "='" + p.appearance.Replace("'", "''") + "'" +
                    "," + lsperm.liquefaction + "='" + p.liquefaction.Replace("'", "''") + "'" +
                    "," + lsperm.status_fresh_sperm + "='" + p.status_fresh_sperm + "'" +
                    "," + lsperm.status_frozen_sperm + "='" + p.status_frozen_sperm + "'" +
                    "," + lsperm.viscosity + "='" + p.viscosity.Replace("'", "''") + "'" +
                    "," + lsperm.viability + "='" + p.viability.Replace("'", "''") + "'" +
                    "," + lsperm.volume1 + "='" + p.volume1.Replace("'", "''") + "'" +
                    "," + lsperm.count1 + "='" + p.count1.Replace("'", "''") + "'" +
                    "," + lsperm.total_count + "='" + p.total_count.Replace("'", "''") + "'" +
                    "," + lsperm.motile + "='" + p.motile.Replace("'", "''") + "'" +
                    "," + lsperm.total_motile + "='" + p.total_motile.Replace("'", "''") + "'" +
                    "," + lsperm.motility + "='" + p.motility.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_4 + "='" + p.motility_rate_4.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_3 + "='" + p.motility_rate_3.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_2 + "='" + p.motility_rate_2.Replace("'", "''") + "'" +
                    "," + lsperm.motility_rate_1 + "='" + p.motility_rate_1.Replace("'", "''") + "'" +
                    
                    "," + lsperm.finish_time + "='" + p.finish_time + "'" +
                    "," + lsperm.sort1 + "='" + p.sort1 + "'" +
                    "," + lsperm.staff_id_report + "='" + p.staff_id_report + "'" +
                    "," + lsperm.staff_id_approve + "='" + p.staff_id_approve + "'" +
                    "," + lsperm.date_report + "='" + p.date_report + "'" +
                    "," + lsperm.date_approve + "='" + p.date_approve + "'" +
                    "," + lsperm.morphology_normal + "='" + p.morphology_normal.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_abnormal + "='" + p.morphology_abnormal.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_head_defect + "='" + p.morphology_head_defect.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_neck_defect + "='" + p.morphology_neck_defect.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_tail_defect + "='" + p.morphology_tail_defect.Replace("'", "''") + "'" +
                    "," + lsperm.no_of_vail + "='" + p.no_of_vail + "'" +
                    "," + lsperm.wbc + "='" + p.wbc + "'" +
                    "," + lsperm.active + "='" + p.active + "' " +
                    "," + lsperm.remark + "='" + p.remark.Replace("'", "''") + "' " +
                    "," + lsperm.date_modi + "=now() " +
                    "," + lsperm.user_modi + "='" + userId + "@" + conn._IPAddress + "' " +
                    "," + lsperm.ph + "='" + p.ph + "' " +
                    "," + lsperm.status_owner_sperm + "='" + p.status_owner_sperm + "' " +
                    //"," + lformA.status_donor_sperm + "='" + p.status_donor_sperm + "' " +
                    "," + lsperm.status_fresh_sperm + "='" + p.status_fresh_sperm + "' " +
                    "," + lsperm.hn_male + "='" + p.hn_male.Replace("'", "''") + "' " +
                    "," + lsperm.hn_female + "='" + p.hn_female.Replace("'", "''") + "' " +
                    "," + lsperm.name_male + "='" + p.name_male.Replace("'", "''") + "' " +
                    "," + lsperm.name_female + "='" + p.name_female.Replace("'", "''") + "' " +
                    "," + lsperm.status_frozen_sperm + "='" + p.status_frozen_sperm + "' " +
                    "," + lsperm.frozen_sperm_vail + "='" + p.frozen_sperm_vail + "' " +
                    "," + lsperm.doctor_id + "='" + p.doctor_id + "' " +
                    "," + lsperm.status_lab_sperm + "='" + p.status_lab_sperm + "' " +
                    "," + lsperm.req_id + "='" + p.req_id + "' " +
                    
                    "," + lsperm.dob_female + "='" + p.dob_female + "' " +
                    "," + lsperm.dob_male + "='" + p.dob_male + "' " +
                    "," + lsperm.sperm_analysis_date_start + "='" + p.sperm_analysis_date_start + "' " +
                    "," + lsperm.spern_freezing_date_start + "='" + p.spern_freezing_date_start + "' " +
                    "," + lsperm.pasa_tese_date + "='" + p.pasa_tese_date + "' " +
                    "," + lsperm.iui_date + "='" + p.iui_date + "' " +
                    "," + lsperm.recive_time + "='" + p.recive_time.Replace("'", "''") + "' " +
                    "," + lsperm.examination_time + "='" + p.examination_time.Replace("'", "''") + "' " +
                    "," + lsperm.finish_time + "='" + p.finish_time.Replace("'", "''") + "' " +
                    "," + lsperm.ejaculation_time + "='" + p.ejaculation_time.Replace("'", "''") + "' " +
                    "," + lsperm.no_of_vail + "='" + p.no_of_vail.Replace("'", "''") + "' " +
                    "," + lsperm.post_count + "='" + p.post_count.Replace("'", "''") + "' " +
                    "," + lsperm.post_motile + "='" + p.post_motile.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_1 + "='" + p.post_motility_rate_1.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_2 + "='" + p.post_motility_rate_2.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_3 + "='" + p.post_motility_rate_3.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility_rate_4 + "='" + p.post_motility_rate_4.Replace("'", "''") + "' " +
                    "," + lsperm.post_total_count + "='" + p.post_total_count.Replace("'", "''") + "' " +
                    "," + lsperm.post_total_motile + "='" + p.post_total_motile.Replace("'", "''") + "' " +
                    "," + lsperm.post_volume1 + "='" + p.post_volume1.Replace("'", "''") + "' " +
                    "," + lsperm.post_motility + "='" + p.post_motility.Replace("'", "''") + "' " +
                    "," + lsperm.morphology_head_defect1 + "='" + p.morphology_head_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_neck_defect1 + "='" + p.morphology_neck_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.morphology_tail_defect1 + "='" + p.morphology_tail_defect1.Replace("'", "''") + "'" +
                    "," + lsperm.appearance_text + "='" + p.appearance_text.Replace("'", "''") + "'" +
                " Where " + lsperm.pkField + " = '" + p.sperm_id + "' "
                ;
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("e", "Error insert LabSperm " + sql);
            }
            return re;
        }
        public String insertLabSperm(LabSperm p, String userId)
        {
            String re = "";

            if (p.sperm_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String updateStatusLabFinish(String id, String userId)
        {
            String re = "";
            String sql = "";
            //p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + lsperm.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lsperm.staff_id_finish + "='" + userId + "' " +
                    "," + lsperm.date_finish + "= now() " +
                    "," + lsperm.status_lab + "='2' " +
                " Where " + lsperm.pkField + " = '" + id + "' "
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
        public LabSperm setLabSperm(DataTable dt)
        {
            LabSperm vs1 = new LabSperm();
            if (dt.Rows.Count > 0)
            {
                vs1.sperm_id = dt.Rows[0][lsperm.sperm_id].ToString();
                vs1.sperm_code = dt.Rows[0][lsperm.sperm_code].ToString();
                vs1.abstinence_day = dt.Rows[0][lsperm.abstinence_day].ToString();
                vs1.sperm_date = dt.Rows[0][lsperm.sperm_date].ToString();
                vs1.appearance = dt.Rows[0][lsperm.appearance].ToString();
                vs1.liquefaction = dt.Rows[0][lsperm.liquefaction].ToString();
                vs1.status_fresh_sperm = dt.Rows[0][lsperm.status_fresh_sperm].ToString();
                vs1.status_frozen_sperm = dt.Rows[0][lsperm.status_frozen_sperm].ToString();
                vs1.viscosity = dt.Rows[0][lsperm.viscosity].ToString();
                vs1.viability = dt.Rows[0][lsperm.viability].ToString();
                vs1.volume1 = dt.Rows[0][lsperm.volume1].ToString();
                vs1.count1 = dt.Rows[0][lsperm.count1].ToString();
                vs1.total_count = dt.Rows[0][lsperm.total_count].ToString();
                vs1.motile = dt.Rows[0][lsperm.motile].ToString();
                vs1.total_motile = dt.Rows[0][lsperm.total_motile].ToString();
                vs1.motility = dt.Rows[0][lsperm.motility].ToString();
                vs1.motility_rate_4 = dt.Rows[0][lsperm.motility_rate_4].ToString();
                vs1.motility_rate_3 = dt.Rows[0][lsperm.motility_rate_3].ToString();
                vs1.motility_rate_2 = dt.Rows[0][lsperm.motility_rate_2].ToString();
                vs1.motility_rate_1 = dt.Rows[0][lsperm.motility_rate_1].ToString();
                
                vs1.finish_time = dt.Rows[0][lsperm.finish_time].ToString();
                vs1.sort1 = dt.Rows[0][lsperm.sort1].ToString();
                vs1.staff_id_report = dt.Rows[0][lsperm.staff_id_report].ToString();
                vs1.staff_id_approve = dt.Rows[0][lsperm.staff_id_approve].ToString();
                vs1.date_report = dt.Rows[0][lsperm.date_report].ToString();
                vs1.date_approve = dt.Rows[0][lsperm.date_approve].ToString();
                vs1.morphology_normal = dt.Rows[0][lsperm.morphology_normal].ToString();
                vs1.morphology_abnormal = dt.Rows[0][lsperm.morphology_abnormal].ToString();
                vs1.morphology_head_defect = dt.Rows[0][lsperm.morphology_head_defect].ToString();
                vs1.morphology_neck_defect = dt.Rows[0][lsperm.morphology_neck_defect].ToString();
                vs1.morphology_tail_defect = dt.Rows[0][lsperm.morphology_tail_defect].ToString();
                vs1.no_of_vail = dt.Rows[0][lsperm.no_of_vail].ToString();
                vs1.wbc = dt.Rows[0][lsperm.wbc].ToString();
                vs1.active = dt.Rows[0][lsperm.active].ToString();
                vs1.remark = dt.Rows[0][lsperm.remark].ToString();
                vs1.date_create = dt.Rows[0][lsperm.date_create].ToString();
                vs1.date_modi = dt.Rows[0][lsperm.date_modi].ToString();
                vs1.date_cancel = dt.Rows[0][lsperm.date_cancel].ToString();
                vs1.user_create = dt.Rows[0][lsperm.user_create].ToString();
                vs1.user_modi = dt.Rows[0][lsperm.user_modi].ToString();
                vs1.user_cancel = dt.Rows[0][lsperm.user_cancel].ToString();
                vs1.ph = dt.Rows[0][lsperm.ph].ToString();
                vs1.status_owner_sperm = dt.Rows[0][lsperm.status_owner_sperm].ToString();
                vs1.status_donor_sperm = dt.Rows[0][lsperm.status_donor_sperm].ToString();
                vs1.status_fresh_sperm = dt.Rows[0][lsperm.status_fresh_sperm].ToString();
                vs1.hn_male = dt.Rows[0][lsperm.hn_male].ToString();
                vs1.hn_female = dt.Rows[0][lsperm.hn_female].ToString();
                vs1.name_male = dt.Rows[0][lsperm.name_male].ToString();
                vs1.name_female = dt.Rows[0][lsperm.name_female].ToString();
                vs1.status_frozen_sperm = dt.Rows[0][lsperm.status_frozen_sperm].ToString();
                vs1.frozen_sperm_vail = dt.Rows[0][lsperm.frozen_sperm_vail].ToString();
                vs1.doctor_id = dt.Rows[0][lsperm.doctor_id].ToString();
                vs1.status_lab_sperm = dt.Rows[0][lsperm.status_lab_sperm].ToString();
                vs1.req_id = dt.Rows[0][lsperm.req_id].ToString();
                
                vs1.dob_female = dt.Rows[0][lsperm.dob_female].ToString();
                vs1.dob_male = dt.Rows[0][lsperm.dob_male].ToString();
                vs1.status_lab = dt.Rows[0][lsperm.status_lab].ToString();
                vs1.doctorname = dt.Rows[0]["doctorname"].ToString();
                vs1.sperm_analysis_date_start = dt.Rows[0][lsperm.sperm_analysis_date_start].ToString();
                vs1.spern_freezing_date_start = dt.Rows[0][lsperm.spern_freezing_date_start].ToString();
                vs1.pasa_tese_date = dt.Rows[0][lsperm.pasa_tese_date].ToString();
                vs1.iui_date = dt.Rows[0][lsperm.iui_date].ToString();
                vs1.form_a_id = dt.Rows[0][lsperm.form_a_id].ToString();
                vs1.recive_time = dt.Rows[0][lsperm.recive_time].ToString();
                vs1.examination_time = dt.Rows[0][lsperm.examination_time].ToString();
                vs1.finish_time = dt.Rows[0][lsperm.finish_time].ToString();
                vs1.ejaculation_time = dt.Rows[0][lsperm.ejaculation_time].ToString();
                vs1.no_of_vail = dt.Rows[0][lsperm.no_of_vail].ToString();
                vs1.post_count = dt.Rows[0][lsperm.post_count].ToString();
                vs1.post_motile = dt.Rows[0][lsperm.post_motile].ToString();
                vs1.post_motility_rate_1 = dt.Rows[0][lsperm.post_motility_rate_1].ToString();
                vs1.post_motility_rate_2 = dt.Rows[0][lsperm.post_motility_rate_2].ToString();
                vs1.post_motility_rate_3 = dt.Rows[0][lsperm.post_motility_rate_3].ToString();
                vs1.post_motility_rate_4 = dt.Rows[0][lsperm.post_motility_rate_4].ToString();
                vs1.post_total_count = dt.Rows[0][lsperm.post_total_count].ToString();
                vs1.post_total_motile = dt.Rows[0][lsperm.post_total_motile].ToString();
                vs1.post_volume1 = dt.Rows[0][lsperm.post_volume1].ToString();
                vs1.post_motility = dt.Rows[0][lsperm.post_motility].ToString();
                vs1.morphology_head_defect1 = dt.Rows[0][lsperm.morphology_head_defect1].ToString();
                vs1.morphology_neck_defect1 = dt.Rows[0][lsperm.morphology_neck_defect1].ToString();
                vs1.morphology_tail_defect1 = dt.Rows[0][lsperm.morphology_tail_defect1].ToString();
                vs1.staff_id_finish = dt.Rows[0][lsperm.staff_id_finish].ToString();
                vs1.date_finish = dt.Rows[0][lsperm.date_finish].ToString();
                vs1.appearance_text = dt.Rows[0][lsperm.appearance_text].ToString();
            }
            else
            {
                setLabSperm1(vs1);
            }
            return vs1;
        }
        public LabSperm setLabSperm1(LabSperm lforma1)
        {
            lforma1.sperm_id = "";
            lforma1.sperm_code = "";
            lforma1.abstinence_day = "";
            lforma1.sperm_date = "";
            lforma1.appearance = "";
            lforma1.liquefaction = "";
            lforma1.status_fresh_sperm = "";
            lforma1.status_frozen_sperm = "";
            lforma1.viscosity = "";
            lforma1.viability = "";
            lforma1.volume1 = "";
            lforma1.count1 = "";
            lforma1.total_count = "";
            lforma1.motile = "";
            lforma1.total_motile = "";
            lforma1.motility = "";
            lforma1.motility_rate_4 = "";
            lforma1.motility_rate_3 = "";
            lforma1.motility_rate_2 = "";
            lforma1.motility_rate_1 = "";
            
            lforma1.finish_time = "";
            lforma1.sort1 = "";
            lforma1.staff_id_report = "";
            lforma1.staff_id_approve = "";
            lforma1.date_report = "";
            lforma1.date_approve = "";
            lforma1.morphology_normal = "";
            lforma1.morphology_abnormal = "";
            lforma1.morphology_head_defect = "";
            lforma1.morphology_neck_defect = "";
            lforma1.morphology_tail_defect = "";
            lforma1.no_of_vail = "";
            lforma1.wbc = "";
            lforma1.active = "";
            lforma1.remark = "";
            lforma1.date_create = "";
            lforma1.date_modi = "";
            lforma1.date_cancel = "";
            lforma1.user_create = "";
            lforma1.user_modi = "";
            lforma1.user_cancel = "";
            lforma1.ph = "";
            lforma1.status_owner_sperm = "";
            lforma1.status_donor_sperm = "";
            lforma1.status_fresh_sperm = "";
            lforma1.hn_male = "";
            lforma1.hn_female = "";
            lforma1.name_male = "";
            lforma1.name_female = "";
            lforma1.status_frozen_sperm = "";
            lforma1.frozen_sperm_vail = "";
            lforma1.doctor_id = "";
            lforma1.status_lab_sperm = "";
            lforma1.req_id = "";
            
            lforma1.dob_female = "";
            lforma1.dob_male = "";
            lforma1.status_lab = "";
            lforma1.doctorname = "";
            lforma1.sperm_analysis_date_start = "";
            lforma1.spern_freezing_date_start = "";
            lforma1.pasa_tese_date = "";
            lforma1.iui_date = "";
            lforma1.form_a_id = "";
            lforma1.recive_time = "";
            lforma1.examination_time = "";
            lforma1.finish_time = "";
            lforma1.ejaculation_time = "";
            lforma1.no_of_vail = "";
            lforma1.post_count = "";
            lforma1.post_motile = "";
            lforma1.post_motility_rate_1 = "";
            lforma1.post_motility_rate_2 = "";
            lforma1.post_motility_rate_3 = "";
            lforma1.post_motility_rate_4 = "";
            lforma1.post_total_count = "";
            lforma1.post_total_motile = "";
            lforma1.post_volume1 = "";
            lforma1.post_motility = "";
            lforma1.morphology_head_defect1 = "";
            lforma1.morphology_neck_defect1 = "";
            lforma1.morphology_tail_defect1 = "";
            lforma1.staff_id_finish = "";
            lforma1.date_finish = "";
            lforma1.appearance_text = "";
            return lforma1;
        }
    }
}
