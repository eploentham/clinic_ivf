using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class PatientAppointmentTextDB
    {
        public PatientAppointmentText pApmT;
        ConnectDB conn;

        public PatientAppointmentTextDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pApmT = new PatientAppointmentText();
            pApmT.appointment_text = "appointment_text";
            pApmT.doctor_name = "doctor_name";
            pApmT.patient_appointment_date = "patient_appointment_date";
            pApmT.patient_appointment_text_id = "patient_appointment_text_id";
            pApmT.active = "active";
            pApmT.remark = "remark";
            pApmT.date_cancel = "date_cancel";
            pApmT.date_create = "date_create";
            pApmT.date_modi = "date_modi";
            pApmT.user_cancel = "user_cancel";
            pApmT.user_create = "user_create";
            pApmT.user_modi = "user_modi";

            pApmT.table = "patient_appointment_text";
            pApmT.pkField = "patient_appointment_text_id";
        }
        private void chkNull(PatientAppointmentText p)
        {
            p.appointment_text = p.appointment_text == null ? "" : p.appointment_text;
            p.doctor_name = p.doctor_name == null ? "" : p.doctor_name;
            p.patient_appointment_date = p.patient_appointment_date == null ? "" : p.patient_appointment_date;
            p.patient_appointment_text_id = p.patient_appointment_text_id == null ? "" : p.patient_appointment_text_id;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
        }
        public String insert(PatientAppointmentText p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);

            sql = "Insert Into " + pApmT.table + " Set " +
                ""+pApmT.appointment_text + "='"+p.appointment_text.Replace("'", "''") + "'"+
                "," + pApmT.doctor_name + "='" + p.doctor_name.Replace("'", "''") + "'" +
                "," + pApmT.patient_appointment_date + "='" + p.patient_appointment_date.Replace("'", "''") + "'" +
                "," + pApmT.active + "='" + p.active + "'" +
                "," + pApmT.remark + "='" + p.remark.Replace("'", "''") + "'" +
                "," + pApmT.date_cancel + "='" + p.date_cancel + "'" +
                "," + pApmT.date_create + "=now()" +
                "," + pApmT.date_modi + "='" + p.date_modi + "'" +
                "," + pApmT.user_cancel + "='" + p.user_cancel + "'" +
                "," + pApmT.user_create + "='" + userId + "'" +
                "," + pApmT.user_modi + "='" + p.user_modi + "'" +
                //"," + pApmT.appointment_text + "='" + p.appointment_text + "'" +
                ")";
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
        public String update(PatientAppointmentText p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + pApmT.table + " Set " +
                " " + pApmT.appointment_text + " = '" + p.appointment_text.Replace("'", "''") + "'" +
                "," + pApmT.doctor_name + " = '" + p.doctor_name.Replace("'", "''") + "'" +
                "," + pApmT.patient_appointment_date + " = '" + p.patient_appointment_date + "'" +
                //"," + pApmT.dept_parent_id + " = '" + p.dept_parent_id + "'" +
                "," + pApmT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + pApmT.date_modi + " = now()" +
                "," + pApmT.user_modi + " = '" + userId + "'" +
                "Where " + pApmT.pkField + "='" + p.patient_appointment_text_id + "'"
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
        public String insertPatientAppointmentText(PatientAppointmentText p, String userId)
        {
            String re = "";

            if (p.patient_appointment_text_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select pApmT.* " +
                "From " + pApmT.table + " pApmT ";
            //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
            //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }

        public PatientAppointmentText setAppointmentText(DataTable dt)
        {
            PatientAppointmentText vsold1 = new PatientAppointmentText();
            if (dt.Rows.Count > 0)
            {
                vsold1.appointment_text = dt.Rows[0][pApmT.appointment_text].ToString();
                vsold1.doctor_name = dt.Rows[0][pApmT.doctor_name].ToString();
                vsold1.patient_appointment_date = dt.Rows[0][pApmT.patient_appointment_date].ToString();
                vsold1.patient_appointment_text_id = dt.Rows[0][pApmT.patient_appointment_text_id].ToString();
                vsold1.active = dt.Rows[0][pApmT.active].ToString();
                vsold1.remark = dt.Rows[0][pApmT.remark].ToString();
                vsold1.date_cancel = dt.Rows[0][pApmT.date_cancel].ToString();
                vsold1.date_create = dt.Rows[0][pApmT.date_create].ToString();
                vsold1.date_modi = dt.Rows[0][pApmT.date_modi].ToString();
                vsold1.user_cancel = dt.Rows[0][pApmT.user_cancel].ToString();
                vsold1.user_create = dt.Rows[0][pApmT.user_create].ToString();
                vsold1.user_modi = dt.Rows[0][pApmT.user_modi].ToString();

                
            }
            else
            {
                setAppointmentText1(vsold1);
            }
            return vsold1;
        }
        private PatientAppointmentText setAppointmentText1(PatientAppointmentText stf1)
        {
            stf1.appointment_text = "";
            stf1.doctor_name = "";
            stf1.patient_appointment_date = "";
            stf1.patient_appointment_text_id = "";
            stf1.active = "";
            stf1.remark = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";

            return stf1;
        }
    }
}
