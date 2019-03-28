using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class NoteDB
    {
        public Note1 note;
        ConnectDB conn;

        public NoteDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            note = new Note1();
            note.active = "active";
            note.date_cancel = "date_cancel";
            note.date_create = "date_create";
            note.date_modi = "date_modi";
            note.note_1 = "note_1";
            note.note_2 = "note_2";
            note.note_id = "note_id";
            note.remark = "remark";
            note.t_patient_id = "t_patient_id";
            note.user_cancel = "user_cancel";
            note.user_create = "user_create";
            note.user_modi = "user_modi";

            note.b_service_point_id = "b_service_point_id";
            note.status_all = "status_all";

            note.table = "t_note";
            note.pkField = "note_id";
        }
        private void chkNull(Note1 p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_all = p.status_all == null ? "0" : p.status_all;

            p.note_1 = p.note_1 == null ? "" : p.note_1;            
            p.note_2 = p.note_2 == null ? "" : p.note_2;

            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.b_service_point_id = long.TryParse(p.b_service_point_id, out chk) ? chk.ToString() : "0";

        }
        public DataTable selectByPttId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select note.* " +
                "From " + note.table + " note " +
                "Where note." + note.t_patient_id + " ='" + copId + "' and note."+note.active+"='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select note.* " +
                "From " + note.table + " note " +
                "Where note." + note.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select note.*  " +
                "From " + note.table + " note " +
                " " +
                "Where note." + note.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String insert(Note1 p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);            
            sql = "Insert Into " + note.table + " Set " +
                " " + note.note_1 + " = '" + p.note_1.Replace("'", "''") + "'" +
                "," + note.note_2 + "= '" + p.note_2.Replace("'", "''") + "'" +
                "," + note.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + note.date_create + "= now() " +
                "," + note.date_cancel + "= '" + p.date_cancel + "'" +
                "," + note.date_modi + "= '" + p.date_modi + "'" +
                "," + note.user_cancel + "= '" + p.user_cancel + "'" +
                "," + note.user_create + "= '" + userId + "'" +
                "," + note.user_modi + "= '" + p.user_modi + "'" +
                "," + note.t_patient_id + "= '" + p.t_patient_id + "'" +
                "," + note.active + "= '" + p.active + "'" +
                "," + note.b_service_point_id + "= '" + p.b_service_point_id + "'" +
                "," + note.status_all + "= '" + p.status_all + "'" +
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
        public String update(Note1 p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + note.table + " Set " +
                " " + note.note_1 + " = '" + p.note_1.Replace("'", "''") + "'" +
                "," + note.note_2 + "= '" + p.note_2.Replace("'", "''") + "'" +
                "," + note.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + note.date_modi + "= now() " +
                "," + note.date_cancel + "= '" + p.date_cancel + "'" +                
                "," + note.user_cancel + "= '" + p.user_cancel + "'" +
                "," + note.user_modi + "= '" + userId + "'" +                
                "," + note.t_patient_id + "= '" + p.t_patient_id + "'" +
                "," + note.status_all + "= '" + p.status_all + "'" +
                "Where " + note.pkField + "='" + p.note_id + "'"; ;

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
        public String insertNote(Note1 p, String userId)
        {
            String re = "";

            //if (p.VN.Equals(""))
            //{
            re = insert(p, "");
            //}
            //else
            //{
            //    //re = update(p, "");
            //}

            return re;
        }
        public Note1 setNote(DataTable dt)
        {
            Note1 ostkd1 = new Note1();
            if (dt.Rows.Count > 0)
            {
                ostkd1.active = dt.Rows[0][note.active].ToString();
                ostkd1.date_cancel = dt.Rows[0][note.date_cancel].ToString();
                ostkd1.date_create = dt.Rows[0][note.date_create].ToString();
                ostkd1.date_modi = dt.Rows[0][note.date_modi].ToString();
                ostkd1.note_1 = dt.Rows[0][note.note_1].ToString();
                ostkd1.note_2 = dt.Rows[0][note.note_2].ToString();
                ostkd1.note_id = dt.Rows[0][note.note_id].ToString();
                ostkd1.remark = dt.Rows[0][note.remark].ToString();
                ostkd1.t_patient_id = dt.Rows[0][note.t_patient_id].ToString();
                ostkd1.user_cancel = dt.Rows[0][note.user_cancel].ToString();
                ostkd1.user_create = dt.Rows[0][note.user_create].ToString();
                ostkd1.user_modi = dt.Rows[0][note.user_modi].ToString();
                ostkd1.status_all = dt.Rows[0][note.status_all].ToString();
            }
            else
            {
                setNote1(ostkd1);
            }
            return ostkd1;
        }
        private Note1 setNote1(Note1 stf1)
        {
            stf1.active = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.note_1 = "";
            stf1.note_2 = "";
            stf1.note_id = "";
            stf1.remark = "";
            stf1.t_patient_id = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.status_all = "";
            return stf1;
        }
    }
}
