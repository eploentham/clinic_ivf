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
    public class LabOpuDB
    {
        public LabOpu opu;
        ConnectDB conn;

        public LabOpuDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opu = new LabOpu();
            opu.opu_id = "opu_id";
            opu.opu_code = "opu_code";
            opu.embryo_freez_stage = "embryo_freez_stage";
            opu.embryoid_freez_position = "embryoid_freez_position";
            opu.hn_male = "hn_male";
            opu.hn_female = "hn_female";
            opu.name_male = "name_male";
            opu.name_female = "name_female";
            opu.dob_male = "dob_male";
            opu.dob_female = "dob_female";
            opu.doctor_id = "doctor_id";
            opu.proce_id = "proce_id";
            opu.opu_date = "opu_date";
            //opu.no_of_opu = "no_of_opu";
            opu.matura_date = "matura_date";
            opu.matura_m_ii = "matura_m_ii";
            opu.matura_m_i = "matura_m_i";
            opu.matura_gv = "matura_gv";
            opu.matura_abmormal = "matura_abnormal";
            opu.matura_dead = "matura_dead";
            opu.fertili_date = "fertili_date";
            opu.fertili_2_pn = "fertili_2_pn";
            opu.fertili_1_pn = "fertili_1_pn";
            opu.fertili_3_pn = "fertili_3_pn";
            opu.fertili_4_pn = "fertili_4_pn";
            opu.fertili_no_pn = "fertili_no_pn";
            opu.fertili_dead = "fertili_dead";
            opu.sperm_date = "sperm_date";
            opu.sperm_volume = "sperm_volume";
            opu.sperm_count = "sperm_count";
            opu.sperm_count_total = "sperm_count_total";
            opu.sperm_motile = "sperm_motile";
            opu.sperm_motile_total = "sperm_motile_total";
            opu.sperm_motility = "sperm_motility";
            opu.sperm_fresh_sperm = "sperm_fresh_sperm";
            opu.sperm_frozen_sperm = "sperm_frozen_sperm";
            opu.embryo_freez_date_0 = "embryo_freez_date_0";
            opu.embryo_freez_day_0 = "embryo_freez_day_0";
            opu.embryo_freez_no_og_0 = "embryo_freez_no_og_0";
            opu.embryo_freez_no_of_straw_0 = "embryo_freez_no_of_straw_0";
            opu.embryo_freez_mothod_0 = "embryo_freez_mothod_0";
            opu.embryo_freez_freeze_media_0 = "embryo_freez_freeze_media_0";
            opu.embryo_freez_position_0 = "embryo_freez_position_0";
            opu.embryo_freez_stage_0 = "embryo_freez_stage_0";

            opu.embryo_for_et_no_of_et = "embryo_for_et_no_of_et";
            opu.embryo_for_et_day = "embryo_for_et_day";
            opu.embryo_for_et_date = "embryo_for_et_date";
            opu.embryo_for_et_assisted = "embryo_for_et_assisted";
            opu.embryo_for_et_remark = "embryo_for_et_remark";
            opu.embryo_for_et_volume = "embryo_for_et_volume";
            opu.embryo_for_et_catheter = "embryo_for_et_catheter";
            opu.embryo_for_et_doctor = "embryo_for_et_doctor";
            opu.embryo_for_et_embryologist_id = "embryo_for_et_embryologist_id";
            opu.embryo_for_et_number_of_transfer = "embryo_for_et_number_of_transfer";
            opu.embryo_for_et_number_of_freeze = "embryo_for_et_number_of_freeze";
            opu.embryo_for_et_number_of_discard = "embryo_for_et_number_of_discard";
            opu.embryologist_report_id = "embryologist_report_id";
            opu.embryologist_approve_id = "embryologist_approve_id";
            opu.date_create = "date_create";
            opu.date_modi = "date_modi";
            opu.date_cancel = "date_cancel";
            opu.user_create = "user_create";
            opu.user_modi = "user_modi";
            opu.user_cancel = "user_cancel";
            opu.active = "active";
            opu.remark = "remark";

            opu.embryo_freez_date_1 = "embryo_freez_date_1";
            opu.embryo_freez_day_1 = "embryo_freez_day_1";
            opu.embryo_freez_no_og_1 = "embryo_freez_no_og_1";
            opu.embryo_freez_no_of_straw_1 = "embryo_freez_no_of_straw_1";
            opu.embryo_freez_mothod_1 = "embryo_freez_mothod_1";
            opu.embryo_freez_freeze_media_1 = "embryo_freez_freeze_media_1";
            opu.embryo_freez_position_1 = "embryo_freez_position_1";
            opu.embryo_freez_stage_1 = "embryo_freez_stage_1";

            opu.embryo_freez_date_2 = "embryo_freez_date_2";
            opu.embryo_freez_day_2 = "embryo_freez_day_2";
            opu.embryo_freez_no_og_2 = "embryo_freez_no_og_2";
            opu.embryo_freez_no_of_straw_2 = "embryo_freez_no_of_straw_2";
            opu.embryo_freez_mothod_2 = "embryo_freez_mothod_2";
            opu.embryo_freez_freeze_media_2 = "embryo_freez_freeze_media_2";
            opu.embryo_freez_position_2 = "embryo_freez_position_2";
            opu.embryo_freez_stage_2 = "embryo_freez_stage_2";

            opu.embryo_freez_date_3 = "embryo_freez_date_3";
            opu.embryo_freez_day_3 = "embryo_freez_day_3";
            opu.embryo_freez_no_og_3 = "embryo_freez_no_og_3";
            opu.embryo_freez_no_of_straw_3 = "embryo_freez_no_of_straw_3";
            opu.embryo_freez_mothod_3 = "embryo_freez_mothod_3";
            opu.embryo_freez_freeze_media_3 = "embryo_freez_freeze_media_3";
            opu.embryo_freez_position_3 = "embryo_freez_position_3";
            opu.embryo_freez_stage_3 = "embryo_freez_stage_3";

            opu.embryo_freez_date_4 = "embryo_freez_date_4";
            opu.embryo_freez_day_4 = "embryo_freez_day_4";
            opu.embryo_freez_no_og_4 = "embryo_freez_no_og_4";
            opu.embryo_freez_no_of_straw_4 = "embryo_freez_no_of_straw_4";
            opu.embryo_freez_mothod_4 = "embryo_freez_mothod_4";
            opu.embryo_freez_freeze_media_4 = "embryo_freez_freeze_media_4";
            opu.embryo_freez_position_4 = "embryo_freez_position_4";
            opu.embryo_freez_stage_4 = "embryo_freez_stage_4";

            opu.embryo_freez_date_5 = "embryo_freez_date_5";
            opu.embryo_freez_day_5 = "embryo_freez_day_5";
            opu.embryo_freez_no_og_5 = "embryo_freez_no_og_5";
            opu.embryo_freez_no_of_straw_5 = "embryo_freez_no_of_straw_5";
            opu.embryo_freez_mothod_5 = "embryo_freez_mothod_5";
            opu.embryo_freez_freeze_media_5 = "embryo_freez_freeze_media_5";
            opu.embryo_freez_position_5 = "embryo_freez_position_5";
            opu.embryo_freez_stage_5 = "embryo_freez_stage_5";

            opu.embryo_freez_date_6 = "embryo_freez_date_6";
            opu.embryo_freez_day_6 = "embryo_freez_day_6";
            opu.embryo_freez_no_og_6 = "embryo_freez_no_og_6";
            opu.embryo_freez_no_of_straw_6 = "embryo_freez_no_of_straw_6";
            opu.embryo_freez_mothod_6 = "embryo_freez_mothod_6";
            opu.embryo_freez_freeze_media_6 = "embryo_freez_freeze_media_6";
            opu.embryo_freez_position_6 = "embryo_freez_position_6";
            opu.embryo_freez_stage_6 = "embryo_freez_stage_6";
            opu.req_id = "req_id";
            opu.status_opu = "status_opu";
            opu.doctor_name = "doctor_name";
            opu.proce_name = "proce_name";
            opu.matura_no_of_opu = "matura_no_of_opu";
            opu.matura_post_mat = "matura_post_mat";
            opu.date_pic_embryo = "date_pic_embryo";
            opu.hn_donor = "hn_donor";
            opu.name_donor = "name_donor";
            opu.remark_1 = "remark_1";
            opu.dob_donor = "dob_donor";
            opu.approve_result_staff_id = "approve_result_staff_id";
            opu.status_approve_result_day1 = "status_approve_result_day1";
            opu.status_approve_result_day3 = "status_approve_result_day3";
            opu.status_approve_result_day5 = "status_approve_result_day5";
            opu.approve_result_day1_staff_id = "approve_result_day1_staff_id";
            opu.approve_result_day3_staff_id = "approve_result_day3_staff_id";
            opu.approve_result_day5_staff_id = "approve_result_day5_staff_id";
            opu.approve_result_day1_date = "approve_result_day1_date";
            opu.approve_result_day3_date = "approve_result_day3_date";
            opu.approve_result_day5_date = "approve_result_day5_date";
            opu.opu_time = "opu_time";
            opu.remark_day2 = "remark_day2";
            opu.remark_day3 = "remark_day3";
            opu.remark_day5 = "remark_day5";
            opu.remark_day6 = "remark_day6";
            opu.report_day1 = "report_day1";
            opu.report_day3 = "report_day3";
            opu.report_day6 = "report_day6";
            opu.fertili_2_pn_add = "fertili_2_pn_add";
            opu.report_day5 = "report_day5";
            opu.approve_result_day6_staff_id = "approve_result_day6_staff_id";
            opu.status_approve_result_day6 = "status_approve_result_day6";
            opu.approve_result_day6_date = "approve_result_day6_date";
            opu.report_day2 = "report_day2";
            opu.report_day0 = "report_day0";
            opu.status_approve_result_day2 = "status_approve_result_day2";
            opu.status_approve_result_day0 = "status_approve_result_day0";
            opu.status_day1_show_embryo_freezing = "status_day1_show_embryo_freezing";

            opu.table = "lab_t_opu";
            opu.pkField = "opu_id";
        }
        public DataTable selectByPrintOPU(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select opu.*, proce.proce_name_t,opu.embryo_freez_no_of_straw_0 , opu.embryo_freez_no_of_straw_1  " +
                ", fdt0.doc_type_name as embryo_freez_mothod_0_name, fdt1.doc_type_name as embryo_freez_mothod_1_name " +
                ", fdt_stage_0.doc_type_name as embryo_freez_stage_0_name, fdt_stage_1.doc_type_name as embryo_freez_stage_1_name " +
                ", fdt_freeze_0.doc_type_name as embryo_freez_freeze_media_0_name " +
                ",CONCAT(IFNULL(fpp_dtr.patient_prefix_description,''),' ', dtr.staff_fname_e ,' ',dtr.staff_lname_e ) as doctor_name " +
                ",CONCAT(IFNULL(fpp_rpt.patient_prefix_description,''),' ', stf_embryo_dev_et_rpt.staff_fname_e ,' ',stf_embryo_dev_et_rpt.staff_lname_e ) as embryo_for_et_embryologist_name_rpt " +
                ",CONCAT(IFNULL(fpp_apv.patient_prefix_description,''),' ', stf_embryo_dev_et_apv.staff_fname_e ,' ',stf_embryo_dev_et_apv.staff_lname_e ) as embryo_for_et_embryologist_name_apv " +
                "From " + opu.table + " opu " +
                "Left Join b_staff dtr on dtr.doctor_id_old = opu." + opu.doctor_id + " " +
                "Left join f_patient_prefix fpp_dtr on fpp_dtr.f_patient_prefix_id = dtr.prefix_id " +
                "Left Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Left Join f_doc_type fdt0 on fdt0.doc_type_id = opu.embryo_freez_mothod_0 " +
                "Left Join f_doc_type fdt1 on fdt1.doc_type_id = opu.embryo_freez_mothod_1 " +
                "Left Join f_doc_type fdt_stage_0 on fdt_stage_0.doc_type_id = opu.embryo_freez_stage_0 " +
                "Left Join f_doc_type fdt_stage_1 on fdt_stage_1.doc_type_id = opu.embryo_freez_stage_1 " +
                "Left Join f_doc_type fdt_freeze_0 on opu.embryo_freez_freeze_media_0 = fdt_freeze_0.doc_type_id " +
                "Left Join b_staff stf_embryo_dev_et_rpt on opu.embryologist_report_id = stf_embryo_dev_et_rpt.staff_id " +
                "Left join f_patient_prefix fpp_rpt on fpp_rpt.f_patient_prefix_id = stf_embryo_dev_et_rpt.prefix_id " +
                "Left Join b_staff stf_embryo_dev_et_apv on opu.embryologist_approve_id = stf_embryo_dev_et_apv.staff_id " +
                "Left join f_patient_prefix fpp_apv on fpp_apv.f_patient_prefix_id = stf_embryo_dev_et_apv.prefix_id " +
                "Where opu." + opu.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select opu.*,dtr.Name, proce.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor dtr on dtr.ID = opu."+opu.doctor_id+" " +
                "LEft Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Where opu." + opu.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabOpu selectByPk1(String copId)
        {
            LabOpu lbReq1 = new LabOpu();
            DataTable dt = new DataTable();
            String sql = "select opu.*,dtr.Name, proce.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor dtr on dtr.ID = opu."+opu.doctor_id+" " +
                "LEft Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Where opu." + opu.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabOPU(dt);
            return lbReq1;
        }
        public LabOpu selectByHnMale(String hn)
        {
            LabOpu lbReq1 = new LabOpu();
            DataTable dt = new DataTable();
            String sql = "select opu.*,dtr.Name, proce.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor dtr on dtr.ID = opu." + opu.doctor_id + " " +
                "LEft Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Where opu." + opu.hn_male + " ='" + hn + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabOPU(dt);
            return lbReq1;
        }
        public LabOpu selectByHnFeMale(String hn)
        {
            LabOpu lbReq1 = new LabOpu();
            DataTable dt = new DataTable();
            String sql = "select opu.*,dtr.Name, proce.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor dtr on dtr.ID = opu." + opu.doctor_id + " " +
                "LEft Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Where opu." + opu.hn_female + " ='" + hn + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabOPU(dt);
            return lbReq1;
        }
        public LabOpu selectByReqID(String copId)
        {
            LabOpu lbReq1 = new LabOpu();
            DataTable dt = new DataTable();
            String sql = "select opu.*,dtr.Name, proce.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor dtr on dtr.ID = opu." + opu.doctor_id + " " +
                "LEft Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Where opu." + opu.req_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabOPU(dt);
            return lbReq1;
        }
        public DataTable selectByStatusProcess()
        {
            DataTable dt = new DataTable();
            String sql = "select opu."+ opu.opu_id + ", opu."+ opu.opu_code+",opu."+ opu.hn_female+",opu."+ opu.name_female+",opu."+ opu.opu_date+"opu."+ opu.remark +
                "From " + opu.table + " opu " +
                "Left Join Doctor on Doctor.ID = opu.doctor_id " +
                "Where opu." + opu.status_opu + " ='1' and opu."+opu.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySearch(String search)
        {
            DataTable dt = new DataTable();
            String sql = "select opu." + opu.opu_id + ", opu." + opu.opu_code + ",opu." + opu.hn_female + ",opu." + opu.name_female + ",opu." + opu.opu_date + ",opu." + opu.remark + " " +
                "From " + opu.table + " opu " +
                "Left Join Doctor on Doctor.ID = opu.doctor_id " +
                "Where opu." + opu.active + "='1' and (opu."+opu.hn_female+" like '%"+search+ "%' or opu." + opu.hn_male + " like '%" + search + "%' or opu." + opu.hn_donor + " like '%" + search + "%') " +
                //"Order By opu." + opu.opu_id + " " +
                "Union " +
                "select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark " +
                "From lab_t_fet fet " +
                "Left Join Doctor on Doctor.ID = fet.doctor_id " +
                "Where  fet.active + '1' and fet." + opu.hn_female + " like '%" + search + "%' " +
                //"Order By fet.fet_id  ";
                "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusProcess1(String search)
        {
            String wherehn = "";
            if (!search.Equals(""))
            {
                wherehn = " and opu."+opu.hn_male+" like '%"+search+"%' and opu."+opu.hn_female+" like '%"+search+"%'";
            }
            DataTable dt = new DataTable();
            String sql = "select opu." + opu.opu_id + ", opu." + opu.opu_code + ",opu." + opu.hn_female + ",opu." + opu.name_female + ",opu." + opu.opu_date + ",opu." + opu.remark+","+ opu.hn_male+","+opu.name_male+ ", lab_b_procedure.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor on Doctor.ID = opu.doctor_id " +
                "Left Join lab_b_procedure on opu.proce_id = lab_b_procedure.proce_id " +
                "Where opu." + opu.status_opu + " ='1' and opu." + opu.active + "='1' "+ wherehn +
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
        public DataTable selectBySearchHn(String search)
        {
            String wherehn = "";
            if (!search.Equals(""))
            {
                wherehn = "  (opu." + opu.hn_male + " like '%" + search + "%' and opu." + opu.active + "='1') or (opu." + opu.hn_female + " like '%" + search + "%' and opu." + opu.active + "='1') ";
            }
            DataTable dt = new DataTable();
            String sql = "select opu." + opu.opu_id + ", opu." + opu.opu_code + ",opu." + opu.hn_female + ",opu." + opu.name_female + ",opu." + opu.opu_date + ",opu." + opu.remark + "," + opu.hn_male + "," + opu.name_male + ", lab_b_procedure.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor on Doctor.ID = opu.doctor_id " +
                "Left Join lab_b_procedure on opu.proce_id = lab_b_procedure.proce_id " +
                "Where  " + wherehn +
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
            String sql = "select opu." + opu.opu_id + ", opu." + opu.opu_code + ",opu." + opu.hn_female + ",opu." + opu.name_female + ",opu." + opu.opu_date + ",opu." + opu.remark + "," + opu.hn_male + "," + opu.name_male + ", lab_b_procedure.proce_name_t " +
                "From " + opu.table + " opu " +
                "Left Join Doctor on Doctor.ID = opu.doctor_id " +
                "Left Join lab_b_procedure on opu.proce_id = lab_b_procedure.proce_id " +
                "Where opu." + opu.status_opu + " ='2' and opu." + opu.active + "='1' " +
                "and opu." + opu.opu_date + " >= '"+datestart+"' and opu." + opu.opu_date + " <= '"+ dateend + "' "+
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
            String sql = "select distinct opu.remark " +
                "From " + opu.table + " opu " +                
                "Where opu." + opu.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByRemark1()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct opu."+opu.remark_1 +" "+
                "From " + opu.table + " opu " +
                "Where opu." + opu.active + "='1' ";
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
                item.Text = row[opu.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboRemark1(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark1();
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
                item.Text = row[opu.remark_1].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByRemarkDay2()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct opu." + opu.remark_day2 + " " +
                "From " + opu.table + " opu " +
                "Where opu." + opu.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemarkDay2(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemarkDay2();
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
                item.Text = row[opu.remark_day2].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByRemarkDay3()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct opu." + opu.remark_day3 + " " +
                "From " + opu.table + " opu " +
                "Where opu." + opu.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemarkDay3(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemarkDay3();
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
                item.Text = row[opu.remark_day3].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByRemarkDay5()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct opu." + opu.remark_day5 + " " +
                "From " + opu.table + " opu " +
                "Where opu." + opu.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemarkDay5(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemarkDay5();
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
                item.Text = row[opu.remark_day5].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByRemarkDay6()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct opu." + opu.remark_day6 + " " +
                "From " + opu.table + " opu " +
                "Where opu." + opu.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemarkDay6(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemarkDay6();
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
                item.Text = row[opu.remark_day6].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        private void chkNull(LabOpu p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.opu_code = p.opu_code == null ? "" : p.opu_code;
            //p.embryo_freez_stage = p.embryo_freez_stage == null ? "" : p.embryo_freez_stage;
            p.embryoid_freez_position = p.embryoid_freez_position == null ? "" : p.embryoid_freez_position;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.opu_date = p.opu_date == null ? "" : p.opu_date;
            p.date_pic_embryo = p.date_pic_embryo == null ? "" : p.date_pic_embryo;
            p.hn_donor = p.hn_donor == null ? "" : p.hn_donor;
            p.name_donor = p.name_donor == null ? "" : p.name_donor;

            p.remark = p.remark == null ? "" : p.remark;
            p.remark_1 = p.remark_1 == null ? "" : p.remark_1;
            p.dob_donor = p.dob_donor == null ? "" : p.dob_donor;
            p.opu_time = p.opu_time == null ? "" : p.opu_time;
            p.remark_day2 = p.remark_day2 == null ? "" : p.remark_day2;
            p.remark_day3 = p.remark_day3 == null ? "" : p.remark_day3;
            p.remark_day5 = p.remark_day5 == null ? "" : p.remark_day5;
            p.remark_day6 = p.remark_day6 == null ? "" : p.remark_day6;
            p.report_day1 = p.report_day1 == null ? "" : p.report_day1;
            p.report_day3 = p.report_day3 == null ? "" : p.report_day3;
            p.report_day6 = p.report_day6 == null ? "" : p.report_day6;
            p.report_day5 = p.report_day5 == null ? "" : p.report_day5;
            p.approve_result_day6_date = p.approve_result_day6_date == null ? "" : p.approve_result_day6_date;
            //p.status_approve_result_day6 = p.status_approve_result_day6 == null ? "0" : p.status_approve_result_day6;
            p.status_day1_show_embryo_freezing = p.status_day1_show_embryo_freezing == null ? "0" : p.status_day1_show_embryo_freezing;
            p.report_day0 = p.report_day0 == null ? "" : p.report_day0;
            p.report_day1 = p.report_day1 == null ? "" : p.report_day1;
            p.report_day2 = p.report_day2 == null ? "" : p.report_day2;
            p.report_day3 = p.report_day3 == null ? "" : p.report_day3;
            p.report_day5 = p.report_day5 == null ? "" : p.report_day5;
            p.report_day6 = p.report_day6 == null ? "" : p.report_day6;
            p.status_approve_result_day0 = p.status_approve_result_day0 == null ? "0" : p.status_approve_result_day0;
            p.status_approve_result_day1 = p.status_approve_result_day1 == null ? "0" : p.status_approve_result_day1;
            p.status_approve_result_day2 = p.status_approve_result_day2 == null ? "0" : p.status_approve_result_day2;
            p.status_approve_result_day3 = p.status_approve_result_day3 == null ? "0" : p.status_approve_result_day3;
            p.status_approve_result_day5 = p.status_approve_result_day5 == null ? "0" : p.status_approve_result_day5;
            p.status_approve_result_day6 = p.status_approve_result_day6 == null ? "0" : p.status_approve_result_day6;

            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.proce_id = long.TryParse(p.proce_id, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.embryo_freez_stage = long.TryParse(p.embryo_freez_stage, out chk) ? chk.ToString() : "0";
            p.embryo_for_et_embryologist_id = long.TryParse(p.embryo_for_et_embryologist_id, out chk) ? chk.ToString() : "0";
            p.embryologist_approve_id = long.TryParse(p.embryologist_approve_id, out chk) ? chk.ToString() : "0";
            p.embryologist_report_id = long.TryParse(p.embryologist_report_id, out chk) ? chk.ToString() : "0";
            p.approve_result_staff_id = long.TryParse(p.approve_result_staff_id, out chk) ? chk.ToString() : "0";
            p.approve_result_day6_staff_id = long.TryParse(p.approve_result_day6_staff_id, out chk) ? chk.ToString() : "0";
            //opu.approve_result_day6_staff_id = "approve_result_day6_staff_id";
            
        }
        public String insert(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //opu.table = "lab_t_opu";
            sql = "Insert Into " + opu.table + " Set " +
                " " + opu.opu_code + " = '" + p.opu_code + "'" +
                "," + opu.embryo_freez_stage + " = '" + p.embryo_freez_stage + "'" +
                "," + opu.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                "," + opu.hn_male + " = '" + p.hn_male.Replace("'", "''") + "'" +
                "," + opu.hn_female + " = '" + p.hn_female.Replace("'", "''") + "'" +
                "," + opu.name_male + " = '" + p.name_male.Replace("'", "''") + "'" +
                "," + opu.active + " = '" + p.active + "'" +
                "," + opu.remark + " = '" + p.remark + "'" +
                "," + opu.dob_female + " = '" + p.dob_female + "'" +
                "," + opu.name_female + " = '" + p.name_female + "'" +
                "," + opu.dob_male + " = '" + p.dob_male + "'" +
                "," + opu.opu_date + " = '" + p.opu_date + "'" +
                "," + opu.doctor_id + " = '" + p.doctor_id + "'" +
                "," + opu.proce_id + " = '" + p.proce_id + "'" +
                "," + opu.date_create + " = now()" +
                "," + opu.date_modi + " = '" + p.date_modi + "'" +
                "," + opu.date_cancel + " = '" + p.date_cancel + "'" +
                "," + opu.user_create + " = '" + userId + "@" + conn._IPAddress + "'" +
                "," + opu.user_modi + " = '" + p.user_modi + "'" +
                "," + opu.user_cancel + " = '" + p.user_cancel + "'" +
                "," + opu.req_id + " = '" + p.req_id + "'" +
                "," + opu.status_opu + " = '1'" +
                "," + opu.date_pic_embryo + " = '" + p.date_pic_embryo + "'" +
                "," + opu.hn_donor + " = '" + p.hn_donor + "'" +
                "," + opu.name_donor + " = '" + p.name_donor + "'" +
                "," + opu.remark_1 + " = '" + p.remark_1 + "'" +
                "," + opu.dob_donor + " = '" + p.dob_donor + "'" +
                "," + opu.opu_time + " = '" + p.opu_time + "'" +
                "," + opu.report_day1 + " = '" + p.report_day1 + "'" +
                "," + opu.report_day3 + " = '" + p.report_day3 + "'" +
                "," + opu.report_day6 + " = '" + p.report_day6 + "'" +
                "," + opu.report_day5 + " = '" + p.report_day5 + "'" +
                "," + opu.report_day0 + " = '" + p.report_day0 + "'" +
                "," + opu.report_day2 + " = '" + p.report_day2 + "'" +
                "," + opu.status_approve_result_day2 + " = '" + p.status_approve_result_day2 + "'" +
                "," + opu.status_approve_result_day0 + " = '" + p.status_approve_result_day0 + "'" +
                "," + opu.status_approve_result_day1 + " = '" + p.status_approve_result_day1 + "'" +
                "," + opu.status_approve_result_day3 + " = '" + p.status_approve_result_day3 + "'" +
                "," + opu.status_approve_result_day5 + " = '" + p.status_approve_result_day5 + "'" +
                "," + opu.status_approve_result_day6 + " = '" + p.status_approve_result_day6 + "'" +
                "," + opu.status_day1_show_embryo_freezing + " = '" + p.status_day1_show_embryo_freezing + "'" +
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
        public String update(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +
                //" " + opu.opu_code + " = '" + p.opu_code + "'" +
                //" " + opu.embryo_freez_stage + " = '" + p.embryo_freez_stage.Replace("'", "''") + "'" +
                " " + opu.opu_time + " = '" + p.opu_time + "'" +
                ", " + opu.hn_male + " = '" + p.hn_male.Replace("'", "''") + "'" +
                "," + opu.hn_female + " = '" + p.hn_female.Replace("'", "''") + "'" +
                "," + opu.name_male + " = '" + p.name_male.Replace("'", "''") + "'" +
                "," + opu.dob_female + " = '" + p.dob_female.Replace("'", "''") + "'" +
                "," + opu.name_female + " = '" + p.name_female.Replace("'", "''") + "'" +
                "," + opu.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + opu.dob_male + " = '" + p.dob_male + "'" +
                "," + opu.opu_date + " = '" + p.opu_date + "'" +
                "," + opu.doctor_id + " = '" + p.doctor_id + "'" +
                "," + opu.proce_id + " = '" + p.proce_id + "'" + 
                "," + opu.date_modi + " = now()" +
                "," + opu.user_modi + " = '" + userId + "@" + conn._IPAddress + "' " +
                "," + opu.date_pic_embryo + " = '" + p.date_pic_embryo + "' " +
                "," + opu.hn_donor + " = '" + p.hn_donor + "' " +
                "," + opu.name_donor + " = '" + p.name_donor + "' " +
                "," + opu.remark_1 + " = '" + p.remark_1 + "' " +
                "," + opu.dob_donor + " = '" + p.dob_donor + "'" +
                "Where " + opu.pkField + "='" + p.opu_id + "'";

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
        public String updateMatura(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +
                
                " " + opu.matura_date + " = '" + p.matura_date.Replace("'", "''") + "'" +
                "," + opu.matura_m_ii + " = '" + p.matura_m_ii.Replace("'", "''") + "'" +
                "," + opu.matura_m_i + " = '" + p.matura_m_i.Replace("'", "''") + "'" +
                "," + opu.matura_gv + " = '" + p.matura_gv.Replace("'", "''") + "'" +
                "," + opu.matura_abmormal + " = '" + p.matura_abmormal.Replace("'", "''") + "'" +
                "," + opu.matura_dead + " = '" + p.matura_dead.Replace("'", "''") + "'" +
                "," + opu.matura_no_of_opu + " = '" + p.matura_no_of_opu + "'" +
                "," + opu.matura_post_mat + " = '" + p.matura_post_mat + "'" +
                
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateFertili(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +
                
                " " + opu.fertili_date + " = '" + p.fertili_date.Replace("'", "''") + "'" +
                "," + opu.fertili_2_pn + " = '" + p.fertili_2_pn.Replace("'", "''") + "'" +
                "," + opu.fertili_1_pn + " = '" + p.fertili_1_pn.Replace("'", "''") + "'" +
                "," + opu.fertili_3_pn + " = '" + p.fertili_3_pn.Replace("'", "''") + "'" +
                "," + opu.fertili_4_pn + " = '" + p.fertili_4_pn.Replace("'", "''") + "'" +
                "," + opu.fertili_no_pn + " = '" + p.fertili_no_pn.Replace("'", "''") + "'" +
                "," + opu.fertili_dead + " = '" + p.fertili_dead + "'" +
                "," + opu.status_day1_show_embryo_freezing + " = '" + p.status_day1_show_embryo_freezing + "'" +
                
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateSperm(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +

                " " + opu.sperm_date + " = '" + p.sperm_date.Replace("'", "''") + "'" +
                "," + opu.sperm_volume + " = '" + p.sperm_volume.Replace("'", "''") + "'" +
                "," + opu.sperm_count + " = '" + p.sperm_count.Replace("'", "''") + "'" +
                "," + opu.sperm_count_total + " = '" + p.sperm_count_total.Replace("'", "''") + "'" +
                "," + opu.sperm_motile + " = '" + p.sperm_motile.Replace("'", "''") + "'" +
                "," + opu.sperm_motile_total + " = '" + p.sperm_motile_total.Replace("'", "''") + "'" +
                "," + opu.sperm_motility + " = '" + p.sperm_motility + "'" +
                "," + opu.sperm_fresh_sperm + " = '" + p.sperm_fresh_sperm + "'" +
                "," + opu.sperm_frozen_sperm + " = '" + p.sperm_frozen_sperm + "'" +
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateEmbryoEt(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +

                " " + opu.embryo_for_et_no_of_et + " = '" + p.embryo_for_et_no_of_et.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_day + " = '" + p.embryo_for_et_day.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_date + " = '" + p.embryo_for_et_date.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_assisted + " = '" + p.embryo_for_et_assisted.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_volume + " = '" + p.embryo_for_et_volume.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_catheter + " = '" + p.embryo_for_et_catheter.Replace("'", "''") + "'" +
                "," + opu.embryo_for_et_doctor + " = '" + p.embryo_for_et_doctor + "'" +
                "," + opu.embryo_for_et_embryologist_id + " = '" + p.embryo_for_et_embryologist_id + "'" +
                "," + opu.embryologist_approve_id + " = '" + p.embryologist_approve_id + "'" +
                "," + opu.embryo_for_et_number_of_transfer + " = '" + p.embryo_for_et_number_of_transfer + "'" +
                "," + opu.embryo_for_et_number_of_freeze + " = '" + p.embryo_for_et_number_of_freeze + "'" +
                "," + opu.embryo_for_et_number_of_discard + " = '" + p.embryo_for_et_number_of_discard + "'" +
                "," + opu.embryologist_report_id + " = '" + p.embryologist_report_id + "'" +
                "," + opu.remark + " = '" + p.remark.Replace("'","''") + "'" +
                "," + opu.embryo_for_et_remark + " = '" + p.embryo_for_et_remark.Replace("'", "''") + "'" +
                "," + opu.remark_1 + " = '" + p.remark_1.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateRemarkDay6(String opuid, String remark)
        {
            String re = "";
            String sql = "";
            int chk = 0;
                        
            sql = "Update " + opu.table + " Set " +

                " " + opu.remark_day6 + " = '" + remark.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateRemarkDay5(String opuid, String remark)
        {
            String re = "";
            String sql = "";
            int chk = 0;
                        
            sql = "Update " + opu.table + " Set " +

                " " + opu.remark_day5 + " = '" + remark.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'";
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
        public String updateRemarkDay3(String opuid, String remark)
        {
            String re = "";
            String sql = "";
            int chk = 0;
                        
            sql = "Update " + opu.table + " Set " +

                " " + opu.remark_day3 + " = '" + remark.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateRemarkDay2(String opuid, String remark)
        {
            String re = "";
            String sql = "";
            int chk = 0;
                        
            sql = "Update " + opu.table + " Set " +

                " " + opu.remark_day2 + " = '" + remark.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateEmbryoFreezDay1(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +

                " " + opu.embryo_freez_day_1 + " = '" + p.embryo_freez_day_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_date_1 + " = '" + p.embryo_freez_date_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_stage_1 + " = '" + p.embryo_freez_stage_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_no_og_1 + " = '" + p.embryo_freez_no_og_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_no_of_straw_1 + " = '" + p.embryo_freez_no_of_straw_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_position_1 + " = '" + p.embryo_freez_position_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_mothod_1 + " = '" + p.embryo_freez_mothod_1.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_freeze_media_1 + " = '" + p.embryo_freez_freeze_media_1 + "'" +

                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateEmbryoFreezDay0(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +

                " " + opu.embryo_freez_day_0 + " = '" + p.embryo_freez_day_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_date_0 + " = '" + p.embryo_freez_date_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_stage_0 + " = '" + p.embryo_freez_stage_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_no_og_0 + " = '" + p.embryo_freez_no_og_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_no_of_straw_0 + " = '" + p.embryo_freez_no_of_straw_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_position_0 + " = '" + p.embryo_freez_position_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_mothod_0 + " = '" + p.embryo_freez_mothod_0.Replace("'", "''") + "'" +
                "," + opu.embryo_freez_freeze_media_0 + " = '" + p.embryo_freez_freeze_media_0 + "'" +
                
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
        public String updateStatusOPUApproveResult(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_opu + " = '2'" +
                "," + opu.approve_result_staff_id + " = '" + userId + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay1(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day1 + " = '1'" +
                "," + opu.approve_result_day1_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day1_date + " = now()" +                
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay1(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day1 + " = '1'" +
                "," + opu.approve_result_day1_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day1_date + " = now()" +
                "," + opu.report_day1 + " = '"+ filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay3(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day3 + " = '1'" +
                "," + opu.approve_result_day3_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day3_date + " = now()" +
                "," + opu.report_day3 + " = '" + filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay2(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day2 + " = '1'" +
                //"," + opu.approve_result_day2_staff_id + " = '" + userId + "'" +
                //"," + opu.approve_result_day2_date + " = now()" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay3(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day3 + " = '1'" +
                "," + opu.approve_result_day3_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day3_date + " = now()" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay5(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day5 + " = '1'" +
                "," + opu.approve_result_day5_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day5_date + " = now()" +
                "," + opu.report_day5 + " = '" + filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay5(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day5 + " = '1'" +
                "," + opu.approve_result_day5_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day5_date + " = now()" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay6(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day6 + " = '1'" +
                "," + opu.approve_result_day6_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day6_date + " = now()" +
                "," + opu.report_day6 + " = '" + filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay6(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day6 + " = '1'" +
                "," + opu.approve_result_day6_staff_id + " = '" + userId + "'" +
                "," + opu.approve_result_day6_date + " = now()" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateFertili(String opuid, String ferti)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.fertili_2_pn + " = '"+ ferti + "'" +
                
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateFertiliAdd(String opuid, String fertiadd)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.fertili_2_pn_add + " = '" + fertiadd + "'" +

                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay0(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day0 + " = '1'" +
                //"," + opu.approve_result_day3_staff_id + " = '" + userId + "'" +
                //"," + opu.approve_result_day3_date + " = now()" +
                "," + opu.report_day0 + " = '" + filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateStatusOPUApproveResultDay2(String opuid, String filename, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.status_approve_result_day2 + " = '1'" +
                //"," + opu.approve_result_day3_staff_id + " = '" + userId + "'" +
                //"," + opu.approve_result_day2_date + " = now()" +
                "," + opu.report_day2 + " = '" + filename + "'" +
                "Where " + opu.pkField + "='" + opuid + "'"
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
        public String updateNameMaleDob(String opuid, String name, String dob)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + opu.table + " Set " +
                " " + opu.name_male + " = '" + name.Replace("'", "''") + "'" +
                "," + opu.dob_male + " = '" + dob.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'";
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
        public String updateNameFeMaleDob(String opuid, String name, String dob)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + opu.table + " Set " +
                " " + opu.name_female + " = '" + name.Replace("'", "''") + "'" +
                "," + opu.dob_female + " = '" + dob.Replace("'", "''") + "'" +
                "Where " + opu.pkField + "='" + opuid + "'";
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
        public LabOpu setLabOPU(DataTable dt)
        {
            LabOpu opu1 = new LabOpu();
            if (dt.Rows.Count > 0)
            {
                //lbReq1.req_id = dt.Rows[0][lbReq.req_id].ToString();
                opu1.opu_id = dt.Rows[0][opu.opu_id].ToString();
                opu1.opu_code = dt.Rows[0][opu.opu_code].ToString();
                opu1.embryo_freez_stage = dt.Rows[0][opu.embryo_freez_stage].ToString();
                opu1.embryoid_freez_position = dt.Rows[0][opu.embryoid_freez_position].ToString();
                opu1.hn_male = dt.Rows[0][opu.hn_male].ToString();
                opu1.hn_female = dt.Rows[0][opu.hn_female].ToString();
                opu1.name_male = dt.Rows[0][opu.name_male].ToString();
                opu1.name_female = dt.Rows[0][opu.name_female].ToString();
                opu1.dob_male = dt.Rows[0][opu.dob_male].ToString();
                opu1.dob_female = dt.Rows[0][opu.dob_female].ToString();
                opu1.doctor_id = dt.Rows[0][opu.doctor_id].ToString();
                opu1.proce_id = dt.Rows[0][opu.proce_id].ToString();
                opu1.opu_date = dt.Rows[0][opu.opu_date].ToString();
                //opu1.no_of_opu = dt.Rows[0][opu.no_of_opu].ToString();
                opu1.matura_date = dt.Rows[0][opu.matura_date].ToString();
                opu1.matura_m_ii = dt.Rows[0][opu.matura_m_ii].ToString();
                opu1.matura_m_i = dt.Rows[0][opu.matura_m_i].ToString();
                opu1.matura_gv = dt.Rows[0][opu.matura_gv].ToString();
                opu1.matura_abmormal = dt.Rows[0][opu.matura_abmormal].ToString();
                opu1.matura_dead = dt.Rows[0][opu.matura_dead].ToString();
                opu1.fertili_date = dt.Rows[0][opu.fertili_date].ToString();
                opu1.fertili_2_pn = dt.Rows[0][opu.fertili_2_pn].ToString();
                opu1.fertili_1_pn = dt.Rows[0][opu.fertili_1_pn].ToString();
                opu1.fertili_3_pn = dt.Rows[0][opu.fertili_3_pn].ToString();
                opu1.fertili_4_pn = dt.Rows[0][opu.fertili_4_pn].ToString();
                opu1.fertili_no_pn = dt.Rows[0][opu.fertili_no_pn].ToString();
                opu1.fertili_dead = dt.Rows[0][opu.fertili_dead].ToString();
                opu1.sperm_date = dt.Rows[0][opu.sperm_date].ToString();
                opu1.sperm_volume = dt.Rows[0][opu.sperm_volume].ToString();
                opu1.sperm_count = dt.Rows[0][opu.sperm_count].ToString();
                opu1.sperm_count_total = dt.Rows[0][opu.sperm_count_total].ToString();
                opu1.sperm_motile = dt.Rows[0][opu.sperm_motile].ToString();
                opu1.sperm_motile_total = dt.Rows[0][opu.sperm_motile_total].ToString();
                opu1.sperm_motility = dt.Rows[0][opu.sperm_motility].ToString();
                opu1.sperm_fresh_sperm = dt.Rows[0][opu.sperm_fresh_sperm].ToString();
                opu1.sperm_frozen_sperm = dt.Rows[0][opu.sperm_frozen_sperm].ToString();
                opu1.embryo_freez_date_0 = dt.Rows[0][opu.embryo_freez_date_0].ToString();
                opu1.embryo_freez_day_0 = dt.Rows[0][opu.embryo_freez_day_0].ToString();
                opu1.embryo_freez_no_og_0 = dt.Rows[0][opu.embryo_freez_no_og_0].ToString();
                opu1.embryo_freez_no_of_straw_0 = dt.Rows[0][opu.embryo_freez_no_of_straw_0].ToString();
                opu1.embryo_freez_mothod_0 = dt.Rows[0][opu.embryo_freez_mothod_0].ToString();
                opu1.embryo_freez_freeze_media_0 = dt.Rows[0][opu.embryo_freez_freeze_media_0].ToString();
                opu1.embryo_freez_position_0 = dt.Rows[0][opu.embryo_freez_position_0].ToString();
                opu1.embryo_freez_stage_0 = dt.Rows[0][opu.embryo_freez_stage_0].ToString();

                opu1.embryo_for_et_no_of_et = dt.Rows[0][opu.embryo_for_et_no_of_et].ToString();
                opu1.embryo_for_et_day = dt.Rows[0][opu.embryo_for_et_day].ToString();
                opu1.embryo_for_et_date = dt.Rows[0][opu.embryo_for_et_date].ToString();
                opu1.embryo_for_et_assisted = dt.Rows[0][opu.embryo_for_et_assisted].ToString();
                opu1.embryo_for_et_remark = dt.Rows[0][opu.embryo_for_et_remark].ToString();
                opu1.embryo_for_et_volume = dt.Rows[0][opu.embryo_for_et_volume].ToString();
                opu1.embryo_for_et_catheter = dt.Rows[0][opu.embryo_for_et_catheter].ToString();
                opu1.embryo_for_et_doctor = dt.Rows[0][opu.embryo_for_et_doctor].ToString();
                opu1.embryo_for_et_embryologist_id = dt.Rows[0][opu.embryo_for_et_embryologist_id].ToString();
                opu1.embryo_for_et_number_of_transfer = dt.Rows[0][opu.embryo_for_et_number_of_transfer].ToString();
                opu1.embryo_for_et_number_of_freeze = dt.Rows[0][opu.embryo_for_et_number_of_freeze].ToString();
                opu1.embryo_for_et_number_of_discard = dt.Rows[0][opu.embryo_for_et_number_of_discard].ToString();
                opu1.embryologist_report_id = dt.Rows[0][opu.embryologist_report_id].ToString();
                opu1.embryologist_approve_id = dt.Rows[0][opu.embryologist_approve_id].ToString();
                opu1.date_create = dt.Rows[0][opu.date_create].ToString();
                opu1.date_modi = dt.Rows[0][opu.date_modi].ToString();
                opu1.date_cancel = dt.Rows[0][opu.date_cancel].ToString();
                opu1.user_create = dt.Rows[0][opu.user_create].ToString();
                opu1.user_modi = dt.Rows[0][opu.user_modi].ToString();
                opu1.user_cancel = dt.Rows[0][opu.user_cancel].ToString();
                opu1.active = dt.Rows[0][opu.active].ToString();
                opu1.remark = dt.Rows[0][opu.remark].ToString();

                opu1.embryo_freez_date_1 = dt.Rows[0][opu.embryo_freez_date_1].ToString();
                opu1.embryo_freez_day_1 = dt.Rows[0][opu.embryo_freez_day_1].ToString();
                opu1.embryo_freez_no_og_1 = dt.Rows[0][opu.embryo_freez_no_og_1].ToString();
                opu1.embryo_freez_no_of_straw_1 = dt.Rows[0][opu.embryo_freez_no_of_straw_1].ToString();
                opu1.embryo_freez_mothod_1 = dt.Rows[0][opu.embryo_freez_mothod_1].ToString();
                opu1.embryo_freez_freeze_media_1 = dt.Rows[0][opu.embryo_freez_freeze_media_1].ToString();
                opu1.embryo_freez_position_1 = dt.Rows[0][opu.embryo_freez_position_1].ToString();
                opu1.embryo_freez_stage_1 = dt.Rows[0][opu.embryo_freez_stage_1].ToString();

                opu1.embryo_freez_date_2 = dt.Rows[0][opu.embryo_freez_date_2].ToString();
                opu1.embryo_freez_day_2 = dt.Rows[0][opu.embryo_freez_day_2].ToString();
                opu1.embryo_freez_no_og_2 = dt.Rows[0][opu.embryo_freez_no_og_2].ToString();
                opu1.embryo_freez_no_of_straw_2 = dt.Rows[0][opu.embryo_freez_no_of_straw_2].ToString();
                opu1.embryo_freez_mothod_2 = dt.Rows[0][opu.embryo_freez_mothod_2].ToString();
                opu1.embryo_freez_freeze_media_2 = dt.Rows[0][opu.embryo_freez_freeze_media_2].ToString();
                opu1.embryo_freez_position_2 = dt.Rows[0][opu.embryo_freez_position_2].ToString();
                opu1.embryo_freez_stage_2 = dt.Rows[0][opu.embryo_freez_stage_2].ToString();

                opu1.embryo_freez_date_3 = dt.Rows[0][opu.embryo_freez_date_3].ToString();
                opu1.embryo_freez_day_3 = dt.Rows[0][opu.embryo_freez_day_3].ToString();
                opu1.embryo_freez_no_og_3 = dt.Rows[0][opu.embryo_freez_no_og_3].ToString();
                opu1.embryo_freez_no_of_straw_3 = dt.Rows[0][opu.embryo_freez_no_of_straw_3].ToString();
                opu1.embryo_freez_mothod_3 = dt.Rows[0][opu.embryo_freez_mothod_3].ToString();
                opu1.embryo_freez_freeze_media_3 = dt.Rows[0][opu.embryo_freez_freeze_media_3].ToString();
                opu1.embryo_freez_position_3 = dt.Rows[0][opu.embryo_freez_position_3].ToString();
                opu1.embryo_freez_stage_3 = dt.Rows[0][opu.embryo_freez_stage_3].ToString();

                opu1.embryo_freez_date_4 = dt.Rows[0][opu.embryo_freez_date_4].ToString();
                opu1.embryo_freez_day_4 = dt.Rows[0][opu.embryo_freez_day_4].ToString();
                opu1.embryo_freez_no_og_4 = dt.Rows[0][opu.embryo_freez_no_og_4].ToString();
                opu1.embryo_freez_no_of_straw_4 = dt.Rows[0][opu.embryo_freez_no_of_straw_4].ToString();
                opu1.embryo_freez_mothod_4 = dt.Rows[0][opu.embryo_freez_mothod_4].ToString();
                opu1.embryo_freez_freeze_media_4 = dt.Rows[0][opu.embryo_freez_freeze_media_4].ToString();
                opu1.embryo_freez_position_4 = dt.Rows[0][opu.embryo_freez_position_4].ToString();
                opu1.embryo_freez_stage_4 = dt.Rows[0][opu.embryo_freez_stage_4].ToString();

                opu1.embryo_freez_date_5 = dt.Rows[0][opu.embryo_freez_date_5].ToString();
                opu1.embryo_freez_day_5 = dt.Rows[0][opu.embryo_freez_day_5].ToString();
                opu1.embryo_freez_no_og_5 = dt.Rows[0][opu.embryo_freez_no_og_5].ToString();
                opu1.embryo_freez_no_of_straw_5 = dt.Rows[0][opu.embryo_freez_no_of_straw_5].ToString();
                opu1.embryo_freez_mothod_5 = dt.Rows[0][opu.embryo_freez_mothod_5].ToString();
                opu1.embryo_freez_freeze_media_5 = dt.Rows[0][opu.embryo_freez_freeze_media_5].ToString();
                opu1.embryo_freez_position_5 = dt.Rows[0][opu.embryo_freez_position_5].ToString();
                opu1.embryo_freez_stage_5 = dt.Rows[0][opu.embryo_freez_stage_5].ToString();

                opu1.embryo_freez_date_6 = dt.Rows[0][opu.embryo_freez_date_6].ToString();
                opu1.embryo_freez_day_6 = dt.Rows[0][opu.embryo_freez_day_6].ToString();
                opu1.embryo_freez_no_og_6 = dt.Rows[0][opu.embryo_freez_no_og_6].ToString();
                opu1.embryo_freez_no_of_straw_6 = dt.Rows[0][opu.embryo_freez_no_of_straw_6].ToString();
                opu1.embryo_freez_mothod_6 = dt.Rows[0][opu.embryo_freez_mothod_6].ToString();
                opu1.embryo_freez_freeze_media_6 = dt.Rows[0][opu.embryo_freez_freeze_media_6].ToString();
                opu1.embryo_freez_position_6 = dt.Rows[0][opu.embryo_freez_position_6].ToString();
                opu1.embryo_freez_stage_6 = dt.Rows[0][opu.embryo_freez_stage_6].ToString();
                opu1.req_id = dt.Rows[0][opu.req_id].ToString();
                opu1.status_opu = dt.Rows[0][opu.status_opu].ToString();
                opu1.doctor_name = dt.Rows[0]["Name"].ToString();
                opu1.proce_name = dt.Rows[0]["proce_name_t"].ToString();

                opu1.matura_post_mat = dt.Rows[0][opu.matura_post_mat].ToString();
                opu1.matura_no_of_opu = dt.Rows[0][opu.matura_no_of_opu].ToString();
                opu1.date_pic_embryo = dt.Rows[0][opu.date_pic_embryo].ToString();
                opu1.hn_donor = dt.Rows[0][opu.hn_donor].ToString();
                opu1.name_donor = dt.Rows[0][opu.name_donor].ToString();
                opu1.remark_1 = dt.Rows[0][opu.remark_1].ToString();
                opu1.dob_donor = dt.Rows[0][opu.dob_donor].ToString();
                opu1.approve_result_staff_id = dt.Rows[0][opu.approve_result_staff_id].ToString();
                opu1.status_approve_result_day1 = dt.Rows[0][opu.status_approve_result_day1].ToString();
                opu1.status_approve_result_day3 = dt.Rows[0][opu.status_approve_result_day3].ToString();
                opu1.status_approve_result_day5 = dt.Rows[0][opu.status_approve_result_day5].ToString();
                opu1.approve_result_day1_staff_id = dt.Rows[0][opu.approve_result_day1_staff_id].ToString();
                opu1.approve_result_day3_staff_id = dt.Rows[0][opu.approve_result_day3_staff_id].ToString();
                opu1.approve_result_day5_staff_id = dt.Rows[0][opu.approve_result_day5_staff_id].ToString();
                opu1.approve_result_day1_date = dt.Rows[0][opu.approve_result_day1_date].ToString();
                opu1.approve_result_day3_date = dt.Rows[0][opu.approve_result_day3_date].ToString();
                opu1.approve_result_day5_date = dt.Rows[0][opu.approve_result_day5_date].ToString();
                opu1.opu_time = dt.Rows[0][opu.opu_time].ToString();
                opu1.remark_day2 = dt.Rows[0][opu.remark_day2].ToString();
                opu1.remark_day3 = dt.Rows[0][opu.remark_day3].ToString();
                opu1.remark_day5 = dt.Rows[0][opu.remark_day5].ToString();
                opu1.remark_day6 = dt.Rows[0][opu.remark_day6].ToString();
                opu1.report_day1 = dt.Rows[0][opu.report_day1].ToString();
                opu1.report_day3 = dt.Rows[0][opu.report_day3].ToString();
                opu1.report_day6 = dt.Rows[0][opu.report_day6].ToString();
                opu1.fertili_2_pn_add = dt.Rows[0][opu.fertili_2_pn_add].ToString();
                opu1.report_day5 = dt.Rows[0][opu.report_day5].ToString();
                opu1.status_approve_result_day6 = dt.Rows[0][opu.status_approve_result_day6].ToString();
                opu1.approve_result_day6_staff_id = dt.Rows[0][opu.approve_result_day6_staff_id].ToString();
                opu1.approve_result_day6_date = dt.Rows[0][opu.approve_result_day6_date].ToString();
                opu1.report_day2 = dt.Rows[0][opu.report_day2].ToString();
                opu1.report_day0 = dt.Rows[0][opu.report_day0].ToString();
                opu1.status_approve_result_day2 = dt.Rows[0][opu.status_approve_result_day2].ToString();
                opu1.status_approve_result_day0 = dt.Rows[0][opu.status_approve_result_day0].ToString();
                opu1.status_day1_show_embryo_freezing = dt.Rows[0][opu.status_day1_show_embryo_freezing].ToString();
            }
            else
            {
                opu1.opu_id = "";
                opu1.opu_code = "";
                opu1.embryo_freez_stage = "";
                opu1.embryoid_freez_position = "";
                opu1.hn_male = "";
                opu1.hn_female = "";
                opu1.name_male = "";
                opu1.name_female = "";
                opu1.dob_male = "";
                opu1.dob_female = "";
                opu1.doctor_id = "";
                opu1.proce_id = "";
                opu1.opu_date = "";
                //opu1.no_of_opu = "";
                opu1.matura_date = "";
                opu1.matura_m_ii = "";
                opu1.matura_m_i = "";
                opu1.matura_gv = "";
                opu1.matura_abmormal = "";
                opu1.matura_dead = "";
                opu1.fertili_date = "";
                opu1.fertili_2_pn = "";
                opu1.fertili_1_pn = "";
                opu1.fertili_3_pn = "";
                opu1.fertili_4_pn = "";
                opu1.fertili_no_pn = "";
                opu1.fertili_dead = "";
                opu1.sperm_date = "";
                opu1.sperm_volume = "";
                opu1.sperm_count = "";
                opu1.sperm_count_total = "";
                opu1.sperm_motile = "";
                opu1.sperm_motile_total = "";
                opu1.sperm_motility = "";
                opu1.sperm_fresh_sperm = "";
                opu1.sperm_frozen_sperm = "";
                opu1.embryo_freez_date_0 = "";
                opu1.embryo_freez_day_0 = "";
                opu1.embryo_freez_no_og_0 = "";
                opu1.embryo_freez_no_of_straw_0 = "";
                opu1.embryo_freez_mothod_0 = "";
                opu1.embryo_freez_freeze_media_0 = "";
                opu1.embryo_freez_position_0 = "";
                opu1.embryo_freez_stage_0 = "";

                opu1.embryo_for_et_no_of_et = "";
                opu1.embryo_for_et_day = "";
                opu1.embryo_for_et_date = "";
                opu1.embryo_for_et_assisted = "";
                opu1.embryo_for_et_remark = "";
                opu1.embryo_for_et_volume = "";
                opu1.embryo_for_et_catheter = "";
                opu1.embryo_for_et_doctor = "";
                opu1.embryo_for_et_embryologist_id = "";
                opu1.embryo_for_et_number_of_transfer = "";
                opu1.embryo_for_et_number_of_freeze = "";
                opu1.embryo_for_et_number_of_discard = "";
                opu1.embryologist_report_id = "";
                opu1.embryologist_approve_id = "";
                opu1.date_create = "";
                opu1.date_modi = "";
                opu1.date_cancel = "";
                opu1.user_create = "";
                opu1.user_modi = "";
                opu1.user_cancel = "";
                opu1.active = "";
                opu1.remark = "";

                opu1.embryo_freez_date_1 = "";
                opu1.embryo_freez_day_1 = "";
                opu1.embryo_freez_no_og_1 = "";
                opu1.embryo_freez_no_of_straw_1 = "";
                opu1.embryo_freez_mothod_1 = "";
                opu1.embryo_freez_freeze_media_1 = "";
                opu1.embryo_freez_position_1 = "";
                opu1.embryo_freez_stage_1 = "";

                opu1.embryo_freez_date_2 = "";
                opu1.embryo_freez_day_2 = "";
                opu1.embryo_freez_no_og_2 = "";
                opu1.embryo_freez_no_of_straw_2 = "";
                opu1.embryo_freez_mothod_2 = "";
                opu1.embryo_freez_freeze_media_2 = "";
                opu1.embryo_freez_position_2 = "";
                opu1.embryo_freez_stage_2 = "";

                opu1.embryo_freez_date_3 = "";
                opu1.embryo_freez_day_3 = "";
                opu1.embryo_freez_no_og_3 = "";
                opu1.embryo_freez_no_of_straw_3 = "";
                opu1.embryo_freez_mothod_3 = "";
                opu1.embryo_freez_freeze_media_3 = "";
                opu1.embryo_freez_position_3 = "";
                opu1.embryo_freez_stage_3 = "";

                opu1.embryo_freez_date_4 = "";
                opu1.embryo_freez_day_4 = "";
                opu1.embryo_freez_no_og_4 = "";
                opu1.embryo_freez_no_of_straw_4 = "";
                opu1.embryo_freez_mothod_4 = "";
                opu1.embryo_freez_freeze_media_4 = "";
                opu1.embryo_freez_position_4 = "";
                opu1.embryo_freez_stage_4 = "";

                opu1.embryo_freez_date_5 = "";
                opu1.embryo_freez_day_5 = "";
                opu1.embryo_freez_no_og_5 = "";
                opu1.embryo_freez_no_of_straw_5 = "";
                opu1.embryo_freez_mothod_5 = "";
                opu1.embryo_freez_freeze_media_5 = "";
                opu1.embryo_freez_position_5 = "";
                opu1.embryo_freez_stage_5 = "";

                opu1.embryo_freez_date_6 = "";
                opu1.embryo_freez_day_6 = "";
                opu1.embryo_freez_no_og_6 = "";
                opu1.embryo_freez_no_of_straw_6 = "";
                opu1.embryo_freez_mothod_6 = "";
                opu1.embryo_freez_freeze_media_6 = "";
                opu1.embryo_freez_position_6 = "";
                opu1.embryo_freez_stage_6 = "";
                opu1.req_id = "";
                opu1.status_opu = "";
                opu1.doctor_name = "";
                opu1.proce_name = "";
                opu1.matura_no_of_opu = "";
                opu1.matura_post_mat = "";
                opu1.date_pic_embryo = "";
                opu1.hn_donor = "";
                opu1.name_donor = "";
                opu1.remark_1 = "";
                opu1.dob_donor = "";
                opu1.approve_result_staff_id = "";
                opu1.status_approve_result_day1 = "";
                opu1.status_approve_result_day3 = "";
                opu1.status_approve_result_day5 = "";
                opu1.approve_result_day1_staff_id = "";
                opu1.approve_result_day3_staff_id = "";
                opu1.approve_result_day5_staff_id = "";
                opu1.approve_result_day1_date = "";
                opu1.approve_result_day3_date = "";
                opu1.approve_result_day5_date = "";
                opu1.opu_time = "";
                opu1.remark_day2 = "";
                opu1.remark_day3 = "";
                opu1.remark_day5 = "";
                opu1.remark_day6 = "";
                opu1.report_day1 = "";
                opu1.report_day3 = "";
                opu1.report_day6 = "";
                opu1.fertili_2_pn_add = "";
                opu1.report_day5 = "";
                opu1.status_approve_result_day6 = "";
                opu1.approve_result_day6_staff_id = "";
                opu1.approve_result_day6_date = "";
                opu1.report_day2 = "";
                opu1.report_day0 = "";
                opu1.status_approve_result_day2 = "";
                opu1.status_approve_result_day0 = "";
                opu1.status_day1_show_embryo_freezing = "";
            }

            return opu1;
        }
    }
}
