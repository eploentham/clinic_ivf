﻿using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class PatientAppointmentDB
    {
        public PatientAppointment pApm;
        ConnectDB conn;

        public PatientAppointmentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pApm = new PatientAppointment();
            pApm.t_patient_appointment_id = "t_patient_appointment_id";
            pApm.t_patient_id = "t_patient_id";
            pApm.patient_appoint_date_time = "patient_appoint_date_time";
            pApm.patient_appointment_date = "patient_appointment_date";
            pApm.patient_appointment_time = "patient_appointment_time";
            pApm.patient_appointment = "patient_appointment";
            pApm.patient_appointment_doctor = "patient_appointment_doctor";
            pApm.patient_appointment_servicepoint = "patient_appointment_servicepoint";
            pApm.patient_appointment_notice = "patient_appointment_notice";
            pApm.patient_appointment_staff = "patient_appointment_staff";
            pApm.t_visit_id = "t_visit_id";
            pApm.patient_appointment_auto_visit = "patient_appointment_auto_visit";
            pApm.b_visit_queue_setup_id = "b_visit_queue_setup_id";
            pApm.patient_appointment_status = "patient_appointment_status";
            pApm.patient_appointment_vn = "patient_appointment_vn";
            pApm.patient_appointment_staff_record = "patient_appointment_staff_record";
            pApm.patient_appointment_record_date_time = "patient_appointment_record_date_time";
            pApm.patient_appointment_staff_update = "patient_appointment_staff_update";
            pApm.patient_appointment_update_date_time = "patient_appointment_update_date_time";
            pApm.patient_appointment_staff_cancel = "patient_appointment_staff_cancel";
            pApm.patient_appointment_cancel_date_time = "patient_appointment_cancel_date_time";
            pApm.patient_appointment_active = "patient_appointment_active";
            pApm.r_rp1853_aptype_id = "r_rp1853_aptype_id";
            pApm.patient_appointment_end_time = "patient_appointment_end_time";
            pApm.appointment_confirm_date = "appointment_confirm_date";
            pApm.change_appointment_cause = "change_appointment_cause";
            pApm.visit_id_make_appointment = "visit_id_make_appointment";
            pApm.patient_appointment_clinic = "patient_appointment_clinic";            

            pApm.date_cancel = "date_cancel";
            pApm.date_create = "date_create";
            pApm.date_modi = "date_modi";
            pApm.user_cancel = "user_cancel";
            pApm.user_create = "user_create";
            pApm.user_modi = "user_modi";
            pApm.active = "active";            
            pApm.remark = "remark";

            pApm.pkField = "t_patient_appointment_id";
            pApm.table = "t_patient_appointment";
        }
        private void chkNull(PatientAppointment p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.patient_appoint_date_time = p.patient_appoint_date_time == null ? "" : p.patient_appoint_date_time;
            p.patient_appointment_date = p.patient_appointment_date == null ? "" : p.patient_appointment_date;
            p.patient_appointment_time = p.patient_appointment_time == null ? "" : p.patient_appointment_time;
            p.patient_appointment = p.patient_appointment == null ? "" : p.patient_appointment;
            p.patient_appointment_doctor = p.patient_appointment_doctor == null ? "" : p.patient_appointment_doctor;
            p.patient_appointment_servicepoint = p.patient_appointment_servicepoint == null ? "" : p.patient_appointment_servicepoint;
            p.patient_appointment_notice = p.patient_appointment_notice == null ? "" : p.patient_appointment_notice;
            p.patient_appointment_auto_visit = p.patient_appointment_auto_visit == null ? "0" : p.patient_appointment_auto_visit;
            //p.t_visit_id = p.t_visit_id == null ? "" : p.t_visit_id;
            p.patient_appointment_status = p.patient_appointment_status == null ? "" : p.patient_appointment_status;
            p.patient_appointment_vn = p.patient_appointment_vn == null ? "" : p.patient_appointment_vn;
            p.patient_appointment_staff_record = p.patient_appointment_staff_record == null ? "" : p.patient_appointment_staff_record;
            p.patient_appointment_record_date_time = p.patient_appointment_record_date_time == null ? "" : p.patient_appointment_record_date_time;
            p.patient_appointment_staff_update = p.patient_appointment_staff_update == null ? "" : p.patient_appointment_staff_update;
            p.patient_appointment_update_date_time = p.patient_appointment_update_date_time == null ? "" : p.patient_appointment_update_date_time;
            p.patient_appointment_staff_cancel = p.patient_appointment_staff_cancel == null ? "" : p.patient_appointment_staff_cancel;
            p.patient_appointment_cancel_date_time = p.patient_appointment_cancel_date_time == null ? "" : p.patient_appointment_cancel_date_time;
            p.patient_appointment_clinic = p.patient_appointment_clinic == null ? "" : p.patient_appointment_clinic;
            p.patient_appointment_active = p.patient_appointment_active == null ? "" : p.patient_appointment_active;
            p.patient_appointment_end_time = p.patient_appointment_end_time == null ? "" : p.patient_appointment_end_time;
            p.appointment_confirm_date = p.appointment_confirm_date == null ? "" : p.appointment_confirm_date;
            p.change_appointment_cause = p.change_appointment_cause == null ? "" : p.change_appointment_cause;

            p.remark = p.remark == null ? "" : p.remark;

            p.r_rp1853_aptype_id = long.TryParse(p.r_rp1853_aptype_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.b_visit_queue_setup_id = long.TryParse(p.b_visit_queue_setup_id, out chk) ? chk.ToString() : "0";
            p.patient_appointment_clinic = long.TryParse(p.patient_appointment_clinic, out chk) ? chk.ToString() : "0";
            p.visit_id_make_appointment = long.TryParse(p.visit_id_make_appointment, out chk) ? chk.ToString() : "0";
            p.patient_appointment_staff = long.TryParse(p.patient_appointment_staff, out chk) ? chk.ToString() : "0";

        }
        public String insert(PatientAppointment p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //p.date_create = "";
            chkNull(p);

            try
            {
                sql = "Insert Into " + pApm.table + "(" + pApm.patient_appoint_date_time + "," + pApm.patient_appointment_time + "," + pApm.patient_appointment + "," +
                pApm.patient_appointment_doctor + "," + pApm.patient_appointment_notice + "," + pApm.patient_appointment_staff + "," +
                pApm.active + "," + pApm.remark + "," + pApm.t_visit_id + "," +
                pApm.patient_appointment_auto_visit + "," + pApm.b_visit_queue_setup_id + "," + pApm.patient_appointment_status + "," +
                pApm.patient_appointment_vn + "," + pApm.r_rp1853_aptype_id + "," + pApm.patient_appointment_end_time + "," +
                pApm.date_create + "," + pApm.date_modi + "," + pApm.date_cancel + ", " +
                pApm.user_create + "," + pApm.user_modi + "," + pApm.user_cancel + ", " +
                pApm.appointment_confirm_date + "," + pApm.change_appointment_cause + "," + pApm.patient_appointment_clinic + "," +
                pApm.patient_appointment_date + "," +
                pApm.patient_appointment_servicepoint + "," + pApm.patient_appointment_staff_record + "," + pApm.patient_appointment_record_date_time + "," +
                pApm.patient_appointment_staff_update + "," + pApm.patient_appointment_update_date_time + "," + pApm.patient_appointment_staff_cancel + "," +
                pApm.patient_appointment_cancel_date_time + "," + pApm.patient_appointment_active + "," + pApm.visit_id_make_appointment + "," +
                
                ") " +
                "Values ('" + p.patient_appoint_date_time + "','" + p.patient_appointment_time.Replace("'", "''") + "','" + p.patient_appointment.Replace("'", "''") + "'," +
                "'" + p.patient_appointment_doctor.Replace("'", "''") + "','" + p.patient_appointment_notice.Replace("'", "''") + "','" + p.patient_appointment_staff.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.t_visit_id.Replace("'", "''") + "'," +
                "'" + p.patient_appointment_auto_visit.Replace("'", "''") + "','" + p.b_visit_queue_setup_id + "','" + p.patient_appointment_status + "'," +
                "'" + p.patient_appointment_vn + "','" + p.r_rp1853_aptype_id.Replace("'", "''") + "','" + p.patient_appointment_end_time.Replace("'", "''") + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.appointment_confirm_date.Replace("'", "''") + "','" + p.change_appointment_cause + "','" + p.patient_appointment_clinic + "'," +
                "'" + p.patient_appointment_date + "'," +
                "'" + p.patient_appointment_servicepoint + "','" + p.patient_appointment_staff_record + "','" + p.patient_appointment_record_date_time + "'," +
                "'" + p.patient_appointment_staff_update + "','" + p.patient_appointment_update_date_time + "','" + p.patient_appointment_staff_cancel + "'," +
                "'" + p.patient_appointment_cancel_date_time + "','" + p.patient_appointment_active + "','" + p.visit_id_make_appointment + "' " +
                
                ")";

                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String insertPatientAppointment(PatientAppointment p, String userId)
        {
            String re = "";

            if (p.t_patient_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String update(PatientAppointment p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + pApm.table + " " +
                //" Set "+pApm.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + pApm.patient_appoint_date_time + "='" + p.patient_appoint_date_time.Replace("'", "''") + "' " +
                "," + pApm.patient_appointment_time + "='" + p.patient_appointment_time.Replace("'", "''") + "' " +
                "," + pApm.patient_appointment + "='" + p.patient_appointment + "' " +
                "," + pApm.patient_appointment_doctor + "='" + p.patient_appointment_doctor + "' " +
                "," + pApm.patient_appointment_notice + "='" + p.patient_appointment_notice.Replace("'", "''") + "' " +
                "," + pApm.patient_appointment_staff + "='" + p.patient_appointment_staff.Replace("'", "''") + "' " +
                "," + pApm.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + pApm.t_visit_id + "='" + p.t_visit_id.Replace("'", "''") + "' " +
                "," + pApm.patient_appointment_auto_visit + "='" + p.patient_appointment_auto_visit + "' " +
                "," + pApm.b_visit_queue_setup_id + "='" + p.b_visit_queue_setup_id + "' " +
                "," + pApm.patient_appointment_status + "='" + p.patient_appointment_status + "' " +
                "," + pApm.patient_appointment_vn + "='" + p.patient_appointment_vn.Replace("'", "''") + "' " +
                "," + pApm.r_rp1853_aptype_id + "='" + p.r_rp1853_aptype_id.Replace("'", "''") + "' " +
                "," + pApm.patient_appointment_end_time + "='" + p.patient_appointment_end_time.Replace("'", "''") + "' " +
                
                "," + pApm.appointment_confirm_date + "='" + p.appointment_confirm_date + "' " +
                
                "," + pApm.change_appointment_cause + "='" + p.change_appointment_cause + "' " +
                "," + pApm.patient_appointment_clinic + "='" + p.patient_appointment_clinic + "' " +
                "," + pApm.patient_appointment_date + "='" + p.patient_appointment_date + "' " +
                "," + pApm.patient_appointment_servicepoint + "='" + p.patient_appointment_servicepoint + "' " +
                
                "," + pApm.patient_appointment_staff_update + "='" + p.patient_appointment_staff_update + "' " +
                "," + pApm.patient_appointment_update_date_time + "='" + p.patient_appointment_update_date_time + "' " +                

                " Where " + pApm.pkField + " = '" + p.t_patient_id + "' "
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
        
        public String VoidPatientAppointment(String pttId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + pApm.table + " Set " +
                "" + pApm.active + "='3'" +
                "," + pApm.date_cancel + "=now() " +
                "," + pApm.user_cancel + "='" + userIdVoid + "' " +
                "Where " + pApm.pkField + "='" + pttId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select pApm.* " +
                "From " + pApm.table + " pApm " +
                "Where pApm." + pApm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PatientAppointment selectByPk1(String pttId)
        {
            PatientAppointment cop1 = new PatientAppointment();
            DataTable dt = new DataTable();
            String sql = "select pApm.* " +
                "From " + pApm.table + " pApm " +
                "Where pApm." + pApm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPatient(dt);
            return cop1;
        }
        public DataTable selectByDate(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select pApm.* " +
                "From " + pApm.table + " pApm " +
                "Where pApm." + pApm.patient_appointment_date + " >='" + date + "' and pApm." + pApm.patient_appointment_date + " <='" + date + "'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PatientAppointment setPatient(DataTable dt)
        {
            PatientAppointment ptt1 = new PatientAppointment();
            if (dt.Rows.Count > 0)
            {
                ptt1.t_patient_appointment_id = dt.Rows[0][pApm.t_patient_appointment_id].ToString();
                ptt1.t_patient_id = dt.Rows[0][pApm.t_patient_id].ToString();
                ptt1.patient_appoint_date_time = dt.Rows[0][pApm.patient_appoint_date_time].ToString();
                ptt1.patient_appointment_date = dt.Rows[0][pApm.patient_appointment_date].ToString();
                ptt1.patient_appointment_time = dt.Rows[0][pApm.patient_appointment_time].ToString();
                ptt1.patient_appointment = dt.Rows[0][pApm.patient_appointment].ToString();
                ptt1.patient_appointment_doctor = dt.Rows[0][pApm.patient_appointment_doctor].ToString();
                ptt1.patient_appointment_servicepoint = dt.Rows[0][pApm.patient_appointment_servicepoint].ToString();
                ptt1.patient_appointment_notice = dt.Rows[0][pApm.patient_appointment_notice].ToString();
                ptt1.patient_appointment_staff = dt.Rows[0][pApm.patient_appointment_staff].ToString();
                ptt1.t_visit_id = dt.Rows[0][pApm.t_visit_id].ToString();
                ptt1.patient_appointment_auto_visit = dt.Rows[0][pApm.patient_appointment_auto_visit].ToString();
                ptt1.b_visit_queue_setup_id = dt.Rows[0][pApm.b_visit_queue_setup_id].ToString();
                ptt1.patient_appointment_status = dt.Rows[0][pApm.patient_appointment_status].ToString();
                ptt1.patient_appointment_vn = dt.Rows[0][pApm.patient_appointment_vn].ToString();
                ptt1.patient_appointment_staff_record = dt.Rows[0][pApm.patient_appointment_staff_record].ToString();
                ptt1.patient_appointment_record_date_time = dt.Rows[0][pApm.patient_appointment_record_date_time].ToString();
                ptt1.patient_appointment_staff_update = dt.Rows[0][pApm.patient_appointment_staff_update].ToString();
                ptt1.patient_appointment_update_date_time = dt.Rows[0][pApm.patient_appointment_update_date_time].ToString();
                ptt1.patient_appointment_staff_cancel = dt.Rows[0][pApm.patient_appointment_staff_cancel].ToString();
                ptt1.patient_appointment_cancel_date_time = dt.Rows[0][pApm.patient_appointment_cancel_date_time].ToString();
                ptt1.patient_appointment_active = dt.Rows[0][pApm.patient_appointment_active].ToString();
                ptt1.r_rp1853_aptype_id = dt.Rows[0][pApm.r_rp1853_aptype_id].ToString();
                ptt1.patient_appointment_end_time = dt.Rows[0][pApm.patient_appointment_end_time].ToString();
                ptt1.appointment_confirm_date = dt.Rows[0][pApm.appointment_confirm_date].ToString();
                ptt1.change_appointment_cause = dt.Rows[0][pApm.change_appointment_cause].ToString();
                ptt1.visit_id_make_appointment = dt.Rows[0][pApm.visit_id_make_appointment].ToString();
                ptt1.patient_appointment_clinic = dt.Rows[0][pApm.patient_appointment_clinic].ToString();


                ptt1.date_cancel = dt.Rows[0][pApm.date_cancel].ToString();
                ptt1.date_create = dt.Rows[0][pApm.date_create].ToString();
                ptt1.date_modi = dt.Rows[0][pApm.date_modi].ToString();
                ptt1.user_cancel = dt.Rows[0][pApm.user_cancel].ToString();
                ptt1.user_create = dt.Rows[0][pApm.user_create].ToString();
                ptt1.user_modi = dt.Rows[0][pApm.user_modi].ToString();
                ptt1.active = dt.Rows[0][pApm.active].ToString();
                
                ptt1.remark = dt.Rows[0][pApm.remark].ToString();
                
            }
            else
            {
                setPatient1(ptt1);
            }
            return ptt1;
        }
        private PatientAppointment setPatient1(PatientAppointment stf1)
        {
            stf1.t_patient_appointment_id = "";
            stf1.t_patient_id = "";
            stf1.patient_appoint_date_time = "";
            stf1.patient_appointment_date = "";
            stf1.patient_appointment_time = "";
            stf1.patient_appointment = "";
            stf1.patient_appointment_doctor = "";
            stf1.patient_appointment_servicepoint = "";
            stf1.patient_appointment_notice = "";
            stf1.patient_appointment_staff = "";

            stf1.t_visit_id = "";
            stf1.patient_appointment_auto_visit = "";
            stf1.b_visit_queue_setup_id = "";
            stf1.patient_appointment_status = "";
            stf1.patient_appointment_vn = "";
            stf1.patient_appointment_staff_record = "";
            stf1.patient_appointment_record_date_time = "";
            stf1.patient_appointment_staff_update = "";
            stf1.patient_appointment_update_date_time = "";
            stf1.patient_appointment_staff_cancel = "";
            stf1.patient_appointment_cancel_date_time = "";
            stf1.patient_appointment_active = "";
            stf1.r_rp1853_aptype_id = "";
            stf1.patient_appointment_end_time = "";
            stf1.appointment_confirm_date = "";
            stf1.change_appointment_cause = "";
            stf1.visit_id_make_appointment = "";
            stf1.patient_appointment_clinic = "";

            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.active = "";
            
            stf1.remark = "";
            
            return stf1;
        }
    }
}
