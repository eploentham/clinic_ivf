using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class PatientImageDB
    {
        public PatientImage pttI;
        ConnectDB conn;
        public List<BItem> lItm;
        public PatientImageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pttI = new PatientImage();
            pttI.patient_image_id = "patient_image_id";
            pttI.t_patient_id = "t_patient_id";
            pttI.t_visit_id = "t_visit_id";
            pttI.desc1 = "desc1";
            pttI.desc2 = "desc2";
            pttI.desc3 = "desc3";
            pttI.desc4 = "desc4";
            pttI.active = "active";
            pttI.remark = "remark";
            pttI.date_create = "date_create";
            pttI.date_modi = "date_modi";
            pttI.date_cancel = "date_cancel";
            pttI.user_create = "user_create";
            pttI.user_modi = "user_modi";
            pttI.user_cancel = "user_cancel";
            pttI.image_path = "image_path";
            pttI.status_image = "status_image";

            pttI.table = "t_patient_image";
            pttI.pkField = "patient_image_id";
        }
        private void chkNull(PatientImage p)
        {
            int chk = 0;
            Int64 chk1 = 0;

            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.desc2 = p.desc2 == null ? "" : p.desc2;
            p.desc3 = p.desc3 == null ? "" : p.desc3;
            p.desc4 = p.desc4 == null ? "" : p.desc4;
            p.remark = p.remark == null ? "" : p.remark;
            p.image_path = p.image_path == null ? "" : p.image_path;
            p.status_image = p.status_image == null ? "0" : p.status_image;
            //p.LVSID = p.LVSID == null ? "" : p.LVSID;
            //p.IntLock = p.IntLock == null ? "" : p.IntLock;

            p.t_patient_id = int.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = int.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            
        }
        public String insert(PatientImage p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + pttI.table + "(" + pttI.t_patient_id + "," + pttI.t_visit_id + "," + pttI.desc1 + "," +
                pttI.desc2 + "," + pttI.desc3 + "," + pttI.desc4 + "," +
                pttI.remark + "," + pttI.image_path + "," + pttI.status_image + "," +
                pttI.date_create + "," + pttI.date_modi + "," + pttI.date_cancel + ", " +
                pttI.user_create + "," + pttI.user_modi + "," + pttI.user_cancel + " " +
                ") " +
                "Values ('" + p.t_patient_id + "','" + p.t_visit_id.Replace("'", "''") + "','" + p.desc1.Replace("'", "''") + "'," +
                "'" + p.desc2.Replace("'", "''") + "','" + p.desc3.Replace("'", "''") + "','" + p.desc4.Replace("'", "''") + "'," +
                "'" + p.remark.Replace("'", "''") + "','" + p.image_path + "','" + p.status_image + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "' " +
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
        public String update(PatientImage p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;


            chkNull(p);
            sql = "Update " + pttI.table + " Set " +
                " " + pttI.desc1 + " = '" + p.desc1 + "'" +
                "," + pttI.desc2 + " = '" + p.desc2.Replace("'", "''") + "'" +
                "," + pttI.desc3 + " = '" + p.desc3 + "'" +
                "," + pttI.desc4 + " = '" + p.desc4 + "'" +
                "," + pttI.remark + " = '" + p.remark + "'" +
                "," + pttI.image_path + " = '" + p.image_path + "'" +
                "," + pttI.status_image + " = '" + p.status_image + "'" +
                "," + pttI.date_modi + " = now()" +
                "," + pttI.user_modi + " = '" + userId + "'" +

                "Where " + pttI.pkField + "='" + p.patient_image_id + "'"
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

        public String insertpatientImage(PatientImage p, String userId)
        {
            String re = "";

            if (p.patient_image_id.Equals(""))
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
            String sql = "select pttI.* " +
                "From " + pttI.table + " pttI " +
                "Where pttI." + pttI.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPttID(String pttid)
        {
            DataTable dt = new DataTable();
            String sql = "select pttI.* " +
                "From " + pttI.table + " pttI " +
                "Where pttI." + pttI.t_patient_id + " ='" + pttid + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PatientImage selectByPk1(String copId)
        {
            PatientImage cop1 = new PatientImage();
            DataTable dt = new DataTable();
            String sql = "select pttI.* " +
                "From " + pttI.table + " pttI " +
                "Where pttI." + pttI.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPatientImage(dt);
            return cop1;
        }
        
        public PatientImage setPatientImage(DataTable dt)
        {
            PatientImage vsold1 = new PatientImage();
            if (dt.Rows.Count > 0)
            {
                vsold1.patient_image_id = dt.Rows[0][pttI.patient_image_id].ToString();
                vsold1.t_patient_id = dt.Rows[0][pttI.t_patient_id].ToString();
                vsold1.t_visit_id = dt.Rows[0][pttI.t_visit_id].ToString();
                vsold1.desc1 = dt.Rows[0][pttI.desc1].ToString();
                vsold1.desc2 = dt.Rows[0][pttI.desc2].ToString();
                vsold1.desc3 = dt.Rows[0][pttI.desc3].ToString();
                vsold1.desc4 = dt.Rows[0][pttI.desc4].ToString();
                vsold1.active = dt.Rows[0][pttI.active].ToString();
                vsold1.remark = dt.Rows[0][pttI.remark].ToString();
                vsold1.date_create = dt.Rows[0][pttI.date_create].ToString();
                vsold1.date_modi = dt.Rows[0][pttI.date_modi].ToString();
                vsold1.date_cancel = dt.Rows[0][pttI.date_cancel].ToString();
                vsold1.user_create = dt.Rows[0][pttI.user_create].ToString();
                vsold1.user_modi = dt.Rows[0][pttI.user_modi].ToString();
                vsold1.user_cancel = dt.Rows[0][pttI.user_cancel].ToString();
                vsold1.image_path = dt.Rows[0][pttI.image_path].ToString();
                vsold1.status_image = dt.Rows[0][pttI.status_image].ToString();
            }
            else
            {
                setPatientImage1(vsold1);
            }
            return vsold1;
        }
        private PatientImage setPatientImage1(PatientImage stf1)
        {
            stf1.patient_image_id = "";
            stf1.t_patient_id = "";
            stf1.t_visit_id = "";
            stf1.desc1 = "";
            stf1.desc2 = "";
            stf1.desc3 = "";
            stf1.desc4 = "";
            stf1.active = "";
            stf1.remark = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.date_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.user_cancel = "";
            stf1.image_path = "";
            stf1.status_image = "";

            return stf1;
        }
    }
}
