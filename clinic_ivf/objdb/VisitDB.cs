using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class VisitDB
    {
        public Visit vs;
        ConnectDB conn;

        public VisitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            vs = new Visit();
            vs.b_contract_plans_id = "b_contract_plans_id";
            vs.b_ncd_group_id = "b_ncd_group_id";
            vs.b_service_point_id = "b_service_point_id";
            vs.b_visit_bed_id = "b_visit_bed_id";
            vs.b_visit_clinic_id = "b_visit_clinic_id";
            vs.b_visit_office_id_refer_in = "b_visit_office_id_refer_in";
            vs.b_visit_office_id_refer_out = "b_visit_office_id_refer_out";
            vs.b_visit_room_id = "b_visit_room_id";
            vs.b_visit_ward_id = "b_visit_ward_id";
            vs.contact_id = "contact_id";
            vs.contact_join_id = "contact_join_id";
            vs.contact_join_namet = "contact_join_namet";
            vs.contact_namet = "contact_namet";
            vs.f_emergency_status_id = "f_emergency_status_id";
            vs.f_refer_cause_id = "f_refer_cause_id";
            vs.f_trama_status_id = "f_trama_status_id";
            vs.f_transportation_type_id = "f_transportation_type_id";
            vs.f_visit_ipd_discharge_status_id = "f_visit_ipd_discharge_status_id";
            vs.f_visit_ipd_discharge_type_id = "f_visit_ipd_discharge_type_id";
            vs.f_visit_opd_discharge_status_id = "f_visit_opd_discharge_status_id";
            vs.f_visit_service_type_id = "f_visit_service_type_id";
            vs.f_visit_status_id = "f_visit_status_id";
            vs.f_visit_type_id = "f_visit_type_id";
            vs.ipd_discharge_doctor = "ipd_discharge_doctor";
            vs.modify_discharge_datetime = "modify_discharge_datetime";
            vs.other_transportation = "other_transportation";
            vs.prepare_discharge_date_time = "prepare_discharge_date_time";
            vs.prepare_discharge_message = "prepare_discharge_message";
            vs.service_location = "service_location";
            vs.status_prepare_discharge = "status_prepare_discharge";
            vs.surveillance_case_id = "surveillance_case_id";
            vs.t_patient_appointment_id = "t_patient_appointment_id";
            vs.t_patient_id = "t_patient_id";
            vs.t_visit_id = "t_visit_id";
            vs.visit_an = "visit_an";
            vs.visit_bed = "visit_bed";
            vs.visit_begin_admit_date_time = "visit_begin_admit_date_time";
            vs.visit_begin_visit_time = "visit_begin_visit_time";
            vs.visit_cal_date_appointment = "visit_cal_date_appointment";
            vs.visit_cause_appointment = "visit_cause_appointment";
            vs.visit_deny_allergy = "visit_deny_allergy";
            vs.visit_diagnosis_notice = "visit_diagnosis_notice";
            vs.visit_doctor_discharge_status = "visit_doctor_discharge_status";
            vs.visit_doctor_reverse_date_time = "visit_doctor_reverse_date_time";
            vs.visit_dx = "visit_dx";
            vs.visit_dx_stat = "visit_dx_stat";
            vs.visit_emergency_staff = "visit_emergency_staff";
            vs.visit_financial_discharge_time = "visit_financial_discharge_time";
            vs.visit_financial_record_date_time = "visit_financial_record_date_time";
            vs.visit_financial_record_staff = "visit_financial_record_staff";
            vs.visit_financial_reverse_date_time = "visit_financial_reverse_date_time";
            vs.visit_first_visit = "visit_first_visit";
            vs.visit_have_admit = "visit_have_admit";
            vs.visit_have_appointment = "visit_have_appointment";
            vs.visit_have_refer = "visit_have_refer";
            vs.visit_have_scan_sn_dx = "visit_have_scan_sn_dx";
            vs.visit_hn = "visit_hn";
            vs.visit_hospital_service = "visit_hospital_service";
            vs.visit_ipd_discharge_date_time = "visit_ipd_discharge_date_time";
            vs.visit_ipd_discharge_status = "visit_ipd_discharge_status";
            vs.visit_ipd_reverse_date_time = "visit_ipd_reverse_date_time";
            vs.visit_ipd_staff_discharge = "visit_ipd_staff_discharge";
            vs.visit_ipd_staff_reverse = "visit_ipd_staff_reverse";
            vs.visit_lab_approve_staff = "visit_lab_approve_staff";
            vs.visit_lab_status_id = "visit_lab_status_id";
            vs.visit_lock_date_time = "visit_lock_date_time";
            vs.visit_locking = "visit_locking";
            vs.visit_modify_date_time = "visit_modify_date_time";
            vs.visit_modify_staff = "visit_modify_staff";
            vs.visit_money_discharge_status = "visit_money_discharge_status";
            vs.visit_ncd = "visit_ncd";
            vs.visit_notice = "visit_notice";
            vs.visit_observe = "visit_observe";
            vs.visit_patient_age = "visit_patient_age";
            vs.visit_patient_self_doctor = "visit_patient_self_doctor";
            vs.visit_patient_type = "visit_patient_type";
            vs.visit_pcu_service = "visit_pcu_service";
            vs.visit_pregnant = "visit_pregnant";
            vs.visit_primary_symtom = "visit_primary_symtom";
            vs.visit_queue = "visit_queue";
            vs.visit_record_date_time = "visit_record_date_time";
            vs.visit_record_staff = "visit_record_staff";
            vs.visit_staff_doctor_discharge = "visit_staff_doctor_discharge";
            vs.visit_staff_doctor_discharge_date_time = "visit_staff_doctor_discharge_date_time";
            vs.visit_staff_doctor_reverse = "visit_staff_doctor_reverse";
            vs.visit_staff_financial_discharge = "visit_staff_financial_discharge";
            vs.visit_staff_financial_reverse = "visit_staff_financial_reverse";
            vs.visit_staff_lock = "visit_staff_lock";
            vs.visit_staff_observe = "visit_staff_observe";
            vs.visit_status_lab_approve = "visit_status_lab_approve";
            vs.visit_vn = "visit_vn";

            vs.table = "t_visit";
            vs.pkField = "t_visit_id";
        }
        private void chkNull(Visit p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.visit_vn = p.visit_vn == null ? "" : p.visit_vn;
            p.visit_record_date_time = p.visit_record_date_time == null ? "" : p.visit_record_date_time;
            p.visit_record_staff = p.visit_record_staff == null ? "" : p.visit_record_staff;
            p.visit_staff_doctor_discharge = p.visit_staff_doctor_discharge == null ? "" : p.visit_staff_doctor_discharge;
            p.visit_staff_doctor_discharge_date_time = p.visit_staff_doctor_discharge_date_time == null ? "" : p.visit_staff_doctor_discharge_date_time;
            p.visit_notice = p.visit_notice == null ? "" : p.visit_notice;
            p.visit_observe = p.visit_observe == null ? "" : p.visit_observe;
            p.visit_patient_self_doctor = p.visit_patient_self_doctor == null ? "" : p.visit_patient_self_doctor;
            p.visit_primary_symtom = p.visit_primary_symtom == null ? "" : p.visit_primary_symtom;
            p.visit_patient_type = p.visit_patient_type == null ? "" : p.visit_patient_type;
            p.visit_money_discharge_status = p.visit_money_discharge_status == null ? "" : p.visit_money_discharge_status;
            p.visit_modify_staff = p.visit_modify_staff == null ? "" : p.visit_modify_staff;
            p.visit_modify_date_time = p.visit_modify_date_time == null ? "" : p.visit_modify_date_time;
            p.visit_hn = p.visit_hn == null ? "" : p.visit_hn;
            p.visit_have_appointment = p.visit_have_appointment == null ? "" : p.visit_have_appointment;
            p.visit_first_visit = p.visit_first_visit == null ? "" : p.visit_first_visit;
            p.visit_financial_discharge_time = p.visit_financial_discharge_time == null ? "" : p.visit_financial_discharge_time;
            p.visit_financial_record_date_time = p.visit_financial_record_date_time == null ? "" : p.visit_financial_record_date_time;
            p.visit_financial_record_staff = p.visit_financial_record_staff == null ? "" : p.visit_financial_record_staff;
            p.visit_dx_stat = p.visit_dx_stat == null ? "" : p.visit_dx_stat;
            p.visit_dx = p.visit_dx == null ? "" : p.visit_dx;
            p.visit_doctor_discharge_status = p.visit_doctor_discharge_status == null ? "" : p.visit_doctor_discharge_status;
            p.visit_diagnosis_notice = p.visit_diagnosis_notice == null ? "" : p.visit_diagnosis_notice;
            p.visit_deny_allergy = p.visit_deny_allergy == null ? "" : p.visit_deny_allergy;
            p.visit_begin_visit_time = p.visit_begin_visit_time == null ? "" : p.visit_begin_visit_time;
            p.status_prepare_discharge = p.status_prepare_discharge == null ? "" : p.status_prepare_discharge;
            p.prepare_discharge_date_time = p.prepare_discharge_date_time == null ? "" : p.prepare_discharge_date_time;
            p.prepare_discharge_message = p.prepare_discharge_message == null ? "" : p.prepare_discharge_message;
            //p.visit_vn1 = p.visit_vn1 == null ? "" : p.visit_vn1;


            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_patient_appointment_id = long.TryParse(p.t_patient_appointment_id, out chk) ? chk.ToString() : "0";
            p.f_visit_type_id = long.TryParse(p.f_visit_type_id, out chk) ? chk.ToString() : "0";
            p.f_visit_status_id = long.TryParse(p.f_visit_status_id, out chk) ? chk.ToString() : "0";
            p.b_visit_clinic_id = long.TryParse(p.b_visit_clinic_id, out chk) ? chk.ToString() : "0";
            p.b_contract_plans_id = long.TryParse(p.b_contract_plans_id, out chk) ? chk.ToString() : "0";
            p.b_service_point_id = long.TryParse(p.b_service_point_id, out chk) ? chk.ToString() : "0";
            p.f_visit_opd_discharge_status_id = long.TryParse(p.f_visit_opd_discharge_status_id, out chk) ? chk.ToString() : "0";
            //p.f_patient_prefix_id = long.TryParse(p.f_patient_prefix_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(Visit p, String userId)
        {
            String re = "";
            String sql = "";

            chkNull(p);
            try
            {
                sql = "Insert Into " +vs.table + " "+
                    "Set "+vs.visit_vn+"='"+p.visit_vn+"'" +
                    "," + vs.visit_record_date_time + "='" + p.visit_record_date_time + "'" +
                    "," + vs.visit_record_staff + "='" + p.visit_record_staff + "'" +
                    "," + vs.visit_staff_doctor_discharge + "='" + p.visit_staff_doctor_discharge + "'" +
                    "," + vs.visit_staff_doctor_discharge_date_time + "='" + p.visit_staff_doctor_discharge_date_time + "'" +
                    "," + vs.visit_notice + "='" + p.visit_notice + "'" +
                    "," + vs.visit_observe + "='" + p.visit_observe + "'" +
                    "," + vs.visit_patient_self_doctor + "='" + p.visit_patient_self_doctor + "'" +
                    "," + vs.visit_primary_symtom + "='" + p.visit_primary_symtom + "'" +
                    "," + vs.visit_patient_type + "='" + p.visit_patient_type + "'" +
                    "," + vs.visit_money_discharge_status + "='" + p.visit_money_discharge_status + "'" +
                    "," + vs.visit_modify_staff + "='" + p.visit_modify_staff + "'" +
                    "," + vs.visit_modify_date_time + "='" + p.visit_modify_date_time + "'" +
                    "," + vs.visit_hn + "='" + p.visit_hn + "'" +
                    "," + vs.visit_have_appointment + "='" + p.visit_have_appointment + "'" +
                    "," + vs.visit_first_visit + "='" + p.visit_first_visit + "'" +
                    "," + vs.visit_financial_discharge_time + "='" + p.visit_financial_discharge_time + "'" +
                    "," + vs.visit_financial_record_date_time + "='" + p.visit_financial_record_date_time + "'" +
                    "," + vs.visit_financial_record_staff + "='" + p.visit_financial_record_staff + "'" +
                    "," + vs.visit_dx_stat + "='" + p.visit_dx_stat + "'" +
                    "," + vs.visit_dx + "='" + p.visit_dx + "'" +
                    "," + vs.visit_doctor_discharge_status + "='" + p.visit_doctor_discharge_status + "'" +
                    "," + vs.visit_diagnosis_notice + "='" + p.visit_diagnosis_notice + "'" +
                    "," + vs.visit_deny_allergy + "='" + p.visit_deny_allergy + "'" +
                    "," + vs.visit_begin_visit_time + "='" + p.visit_begin_visit_time + "'" +
                    "," + vs.status_prepare_discharge + "='" + p.status_prepare_discharge + "'" +
                    "," + vs.prepare_discharge_date_time + "='" + p.prepare_discharge_date_time + "'" +
                    "," + vs.prepare_discharge_message + "='" + p.prepare_discharge_message + "'" +
                    "," + vs.t_patient_id + "='" + p.t_patient_id + "'" +
                    "," + vs.t_patient_appointment_id + "='" + p.t_patient_appointment_id + "'" +
                    "," + vs.f_visit_type_id + "='" + p.f_visit_type_id + "'" +
                    "," + vs.f_visit_status_id + "='" + p.f_visit_status_id + "'" +
                    "," + vs.b_visit_clinic_id + "='" + p.b_visit_clinic_id + "'" +
                    "," + vs.b_contract_plans_id + "='" + p.b_contract_plans_id + "'" +
                    "," + vs.b_service_point_id + "='" + p.b_service_point_id + "'" +
                    "," + vs.f_visit_opd_discharge_status_id + "='" + p.f_visit_opd_discharge_status_id + "' " +
                    "";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String insertVisit(Visit p, String userId)
        {
            String re = "";

            if (p.t_visit_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                //re = update(p, "");
            }

            return re;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select vs.* " +
                "From " + vs.table + " vs " +
                "Where vs." + vs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Visit selectByPk1(String pttId)
        {
            Visit cop1 = new Visit();
            DataTable dt = new DataTable();
            String sql = "select vs.* " +
                "From " + vs.table + " vs " +
                "Where vs." + vs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setVisit(dt);
            return cop1;
        }
        public DataTable selectCurrentVisit()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vs.t_visit_id as id,vs.visit_vn as VN ,ptt.patient_hn as PIDS,CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', ptt.patient_firstname_e ,' ',ptt.patient_lastname_e)  as PName, vs.visit_begin_visit_time as VDate, vs.visit_begin_visit_time as VStartTime, vs.visit_financial_discharge_time as VEndTime, bsp.service_point_description as VSID, '' as Vname " +
                "From " + vs.table + " vs " +
                "Left Join t_patient ptt on  ptt.t_patient_id = vs."+vs.t_patient_id +" "+
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Left Join b_service_point bsp on bsp.b_service_point_id = vs.b_service_point_id " +
                "Where vs." + vs.visit_begin_visit_time + " >='" + date + " 00:00:00' " +
                "Order By vs.visit_begin_visit_time ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public Visit setVisit(DataTable dt)
        {
            Visit ptt1 = new Visit();
            if (dt.Rows.Count > 0)
            {
                vs.b_contract_plans_id = dt.Rows[0][vs.b_contract_plans_id].ToString();
                vs.b_ncd_group_id = dt.Rows[0][vs.b_ncd_group_id].ToString();
                vs.b_service_point_id = dt.Rows[0][vs.b_service_point_id].ToString();
                vs.b_visit_bed_id = dt.Rows[0][vs.b_visit_bed_id].ToString();
                vs.b_visit_clinic_id = dt.Rows[0][vs.b_visit_clinic_id].ToString();
                vs.b_visit_office_id_refer_in = dt.Rows[0][vs.b_visit_office_id_refer_in].ToString();
                vs.b_visit_office_id_refer_out = dt.Rows[0][vs.b_visit_office_id_refer_out].ToString();
                vs.b_visit_room_id = dt.Rows[0][vs.b_visit_room_id].ToString();
                vs.b_visit_ward_id = dt.Rows[0][vs.b_visit_ward_id].ToString();
                vs.contact_id = dt.Rows[0][vs.contact_id].ToString();
                vs.contact_join_id = dt.Rows[0][vs.contact_join_id].ToString();
                vs.contact_join_namet = dt.Rows[0][vs.contact_join_namet].ToString();
                vs.contact_namet = dt.Rows[0][vs.contact_namet].ToString();
                vs.f_emergency_status_id = dt.Rows[0][vs.f_emergency_status_id].ToString();
                vs.f_refer_cause_id = dt.Rows[0][vs.f_refer_cause_id].ToString();
                vs.f_trama_status_id = dt.Rows[0][vs.f_trama_status_id].ToString();
                vs.f_transportation_type_id = dt.Rows[0][vs.f_transportation_type_id].ToString();
                vs.f_visit_ipd_discharge_status_id = dt.Rows[0][vs.f_visit_ipd_discharge_status_id].ToString();
                vs.f_visit_ipd_discharge_type_id = dt.Rows[0][vs.f_visit_ipd_discharge_type_id].ToString();
                vs.f_visit_opd_discharge_status_id = dt.Rows[0][vs.f_visit_opd_discharge_status_id].ToString();
                vs.f_visit_service_type_id = dt.Rows[0][vs.f_visit_service_type_id].ToString();
                vs.f_visit_status_id = dt.Rows[0][vs.f_visit_status_id].ToString();
                vs.f_visit_type_id = dt.Rows[0][vs.f_visit_type_id].ToString();
                vs.ipd_discharge_doctor = dt.Rows[0][vs.ipd_discharge_doctor].ToString();
                vs.modify_discharge_datetime = dt.Rows[0][vs.modify_discharge_datetime].ToString();
                vs.other_transportation = dt.Rows[0][vs.other_transportation].ToString();
                vs.prepare_discharge_date_time = dt.Rows[0][vs.prepare_discharge_date_time].ToString();
                vs.prepare_discharge_message = dt.Rows[0][vs.prepare_discharge_message].ToString();
                vs.service_location = dt.Rows[0][vs.service_location].ToString();
                vs.status_prepare_discharge = dt.Rows[0][vs.status_prepare_discharge].ToString();
                vs.surveillance_case_id = dt.Rows[0][vs.surveillance_case_id].ToString();
                vs.t_patient_appointment_id = dt.Rows[0][vs.t_patient_appointment_id].ToString();
                vs.t_patient_id = dt.Rows[0][vs.t_patient_id].ToString();
                vs.t_visit_id = dt.Rows[0][vs.t_visit_id].ToString();
                vs.visit_an = dt.Rows[0][vs.visit_an].ToString();
                vs.visit_bed = dt.Rows[0][vs.visit_bed].ToString();
                vs.visit_begin_admit_date_time = dt.Rows[0][vs.visit_begin_admit_date_time].ToString();
                vs.visit_begin_visit_time = dt.Rows[0][vs.visit_begin_visit_time].ToString();
                vs.visit_cal_date_appointment = dt.Rows[0][vs.visit_cal_date_appointment].ToString();
                vs.visit_cause_appointment = dt.Rows[0][vs.visit_cause_appointment].ToString();
                vs.visit_deny_allergy = dt.Rows[0][vs.visit_deny_allergy].ToString();
                vs.visit_diagnosis_notice = dt.Rows[0][vs.visit_diagnosis_notice].ToString();
                vs.visit_doctor_discharge_status = dt.Rows[0][vs.visit_doctor_discharge_status].ToString();
                vs.visit_doctor_reverse_date_time = dt.Rows[0][vs.visit_doctor_reverse_date_time].ToString();
                vs.visit_dx = dt.Rows[0][vs.visit_dx].ToString();
                vs.visit_dx_stat = dt.Rows[0][vs.visit_dx_stat].ToString();
                vs.visit_emergency_staff = dt.Rows[0][vs.visit_emergency_staff].ToString();
                vs.visit_financial_discharge_time = dt.Rows[0][vs.visit_financial_discharge_time].ToString();
                vs.visit_financial_record_date_time = dt.Rows[0][vs.visit_financial_record_date_time].ToString();
                vs.visit_financial_record_staff = dt.Rows[0][vs.visit_financial_record_staff].ToString();
                vs.visit_financial_reverse_date_time = dt.Rows[0][vs.visit_financial_reverse_date_time].ToString();
                vs.visit_first_visit = dt.Rows[0][vs.visit_first_visit].ToString();
                vs.visit_have_admit = dt.Rows[0][vs.visit_have_admit].ToString();
                vs.visit_have_appointment = dt.Rows[0][vs.visit_have_appointment].ToString();
                vs.visit_have_refer = dt.Rows[0][vs.visit_have_refer].ToString();
                vs.visit_have_scan_sn_dx = dt.Rows[0][vs.visit_have_scan_sn_dx].ToString();
                vs.visit_hn = dt.Rows[0][vs.visit_hn].ToString();
                vs.visit_hospital_service = dt.Rows[0][vs.visit_hospital_service].ToString();
                vs.visit_ipd_discharge_date_time = dt.Rows[0][vs.visit_ipd_discharge_date_time].ToString();
                vs.visit_ipd_discharge_status = dt.Rows[0][vs.visit_ipd_discharge_status].ToString();
                vs.visit_ipd_reverse_date_time = dt.Rows[0][vs.visit_ipd_reverse_date_time].ToString();
                vs.visit_ipd_staff_discharge = dt.Rows[0][vs.visit_ipd_staff_discharge].ToString();
                vs.visit_ipd_staff_reverse = dt.Rows[0][vs.visit_ipd_staff_reverse].ToString();
                vs.visit_lab_approve_staff = dt.Rows[0][vs.visit_lab_approve_staff].ToString();
                vs.visit_lab_status_id = dt.Rows[0][vs.visit_lab_status_id].ToString();
                vs.visit_lock_date_time = dt.Rows[0][vs.visit_lock_date_time].ToString();
                vs.visit_locking = dt.Rows[0][vs.visit_locking].ToString();
                vs.visit_modify_date_time = dt.Rows[0][vs.visit_modify_date_time].ToString();
                vs.visit_modify_staff = dt.Rows[0][vs.visit_modify_staff].ToString();
                vs.visit_money_discharge_status = dt.Rows[0][vs.visit_money_discharge_status].ToString();
                vs.visit_ncd = dt.Rows[0][vs.visit_ncd].ToString();
                vs.visit_notice = dt.Rows[0][vs.visit_notice].ToString();
                vs.visit_observe = dt.Rows[0][vs.visit_observe].ToString();
                vs.visit_patient_age = dt.Rows[0][vs.visit_patient_age].ToString();
                vs.visit_patient_self_doctor = dt.Rows[0][vs.visit_patient_self_doctor].ToString();
                vs.visit_patient_type = dt.Rows[0][vs.visit_patient_type].ToString();
                vs.visit_pcu_service = dt.Rows[0][vs.visit_pcu_service].ToString();
                vs.visit_pregnant = dt.Rows[0][vs.visit_pregnant].ToString();
                vs.visit_primary_symtom = dt.Rows[0][vs.visit_primary_symtom].ToString();
                vs.visit_queue = dt.Rows[0][vs.visit_queue].ToString();
                vs.visit_record_date_time = dt.Rows[0][vs.visit_record_date_time].ToString();
                vs.visit_record_staff = dt.Rows[0][vs.visit_record_staff].ToString();
                vs.visit_staff_doctor_discharge = dt.Rows[0][vs.visit_staff_doctor_discharge].ToString();
                vs.visit_staff_doctor_discharge_date_time = dt.Rows[0][vs.visit_staff_doctor_discharge_date_time].ToString();
                vs.visit_staff_doctor_reverse = dt.Rows[0][vs.visit_staff_doctor_reverse].ToString();
                vs.visit_staff_financial_discharge = dt.Rows[0][vs.visit_staff_financial_discharge].ToString();
                vs.visit_staff_financial_reverse = dt.Rows[0][vs.visit_staff_financial_reverse].ToString();
                vs.visit_staff_lock = dt.Rows[0][vs.visit_staff_lock].ToString();
                vs.visit_staff_observe = dt.Rows[0][vs.visit_staff_observe].ToString();
                vs.visit_status_lab_approve = dt.Rows[0][vs.visit_status_lab_approve].ToString();
                vs.visit_vn = dt.Rows[0][vs.visit_vn].ToString();
            }
            else
            {
                setVisit1(ptt1);
            }
            return ptt1;
        }
        public Visit setVisit1(Visit stf1)
        {
            vs.b_contract_plans_id = "";
            vs.b_ncd_group_id = "";
            vs.b_service_point_id = "";
            vs.b_visit_bed_id = "";
            vs.b_visit_clinic_id = "";
            vs.b_visit_office_id_refer_in = "";
            vs.b_visit_office_id_refer_out = "";
            vs.b_visit_room_id = "";
            vs.b_visit_ward_id = "";
            vs.contact_id = "";
            vs.contact_join_id = "";
            vs.contact_join_namet = "";
            vs.contact_namet = "";
            vs.f_emergency_status_id = "";
            vs.f_refer_cause_id = "";
            vs.f_trama_status_id = "";
            vs.f_transportation_type_id = "";
            vs.f_visit_ipd_discharge_status_id = "";
            vs.f_visit_ipd_discharge_type_id = "";
            vs.f_visit_opd_discharge_status_id = "";
            vs.f_visit_service_type_id = "";
            vs.f_visit_status_id = "";
            vs.f_visit_type_id = "";
            vs.ipd_discharge_doctor = "";
            vs.modify_discharge_datetime = "";
            vs.other_transportation = "";
            vs.prepare_discharge_date_time = "";
            vs.prepare_discharge_message = "";
            vs.service_location = "";
            vs.status_prepare_discharge = "";
            vs.surveillance_case_id = "";
            vs.t_patient_appointment_id = "";
            vs.t_patient_id = "";
            vs.t_visit_id = "";
            vs.visit_an = "";
            vs.visit_bed = "";
            vs.visit_begin_admit_date_time = "";
            vs.visit_begin_visit_time = "";
            vs.visit_cal_date_appointment = "";
            vs.visit_cause_appointment = "";
            vs.visit_deny_allergy = "";
            vs.visit_diagnosis_notice = "";
            vs.visit_doctor_discharge_status = "";
            vs.visit_doctor_reverse_date_time = "";
            vs.visit_dx = "";
            vs.visit_dx_stat = "";
            vs.visit_emergency_staff = "";
            vs.visit_financial_discharge_time = "";
            vs.visit_financial_record_date_time = "";
            vs.visit_financial_record_staff = "";
            vs.visit_financial_reverse_date_time = "";
            vs.visit_first_visit = "";
            vs.visit_have_admit = "";
            vs.visit_have_appointment = "";
            vs.visit_have_refer = "";
            vs.visit_have_scan_sn_dx = "";
            vs.visit_hn = "";
            vs.visit_hospital_service = "";
            vs.visit_ipd_discharge_date_time = "";
            vs.visit_ipd_discharge_status = "";
            vs.visit_ipd_reverse_date_time = "";
            vs.visit_ipd_staff_discharge = "";
            vs.visit_ipd_staff_reverse = "";
            vs.visit_lab_approve_staff = "";
            vs.visit_lab_status_id = "";
            vs.visit_lock_date_time = "";
            vs.visit_locking = "";
            vs.visit_modify_date_time = "";
            vs.visit_modify_staff = "";
            vs.visit_money_discharge_status = "";
            vs.visit_ncd = "";
            vs.visit_notice = "";
            vs.visit_observe = "";
            vs.visit_patient_age = "";
            vs.visit_patient_self_doctor = "";
            vs.visit_patient_type = "";
            vs.visit_pcu_service = "";
            vs.visit_pregnant = "";
            vs.visit_primary_symtom = "";
            vs.visit_queue = "";
            vs.visit_record_date_time = "";
            vs.visit_record_staff = "";
            vs.visit_staff_doctor_discharge = "";
            vs.visit_staff_doctor_discharge_date_time = "";
            vs.visit_staff_doctor_reverse = "";
            vs.visit_staff_financial_discharge = "";
            vs.visit_staff_financial_reverse = "";
            vs.visit_staff_lock = "";
            vs.visit_staff_observe = "";
            vs.visit_status_lab_approve = "";
            vs.visit_vn = "";
            return stf1;
        }
    }
}
