using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabOrderGroupDB
    {
        public LabOrderGroup log;
        ConnectDB conn;

        public LabOrderGroupDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            log = new LabOrderGroup();
            log.active = "active";
            log.date_cancel = "date_cancel";
            log.date_create = "date_create";
            log.date_modi = "date_modi";
            log.lab_id = "lab_id";
            log.lab_order_group_id = "lab_order_group_id";
            log.lab_order_id = "lab_order_id";

            log.remark = "remark";
            log.sort1 = "sort1";
            log.user_cancel = "user_cancel";
            log.user_create = "user_create";
            log.user_modi = "user_modi";

            log.qty = "qty";

            log.table = "lab_b_order_group";
            log.pkField = "lab_order_group_id";
        }
        private void chkNull(LabOrderGroup p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "0" : p.sort1;

            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";
            p.lab_order_id = long.TryParse(p.lab_order_id, out chk) ? chk.ToString() : "0";
            p.qty = Decimal.TryParse(p.lab_order_id, out chk1) ? chk1.ToString() : "0";
        }
        public DataTable selectByLabOrderId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select note.*, LabItem.LName " +
                "From " + log.table + " note " +
                "Left Join LabItem on note."+log.lab_id+"= LabItem.LID " +
                "Where note." + log.lab_order_id + " ='" + copId + "' and note." + log.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select note.* " +
                "From " + log.table + " note " +
                "Where note." + log.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select note.*  " +
                "From " + log.table + " note " +
                " " +
                "Where note." + log.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String insert(LabOrderGroup p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + log.table + " Set " +
                " " + log.lab_id + " = '" + p.lab_id.Replace("'", "''") + "'" +
                "," + log.lab_order_id + "= '" + p.lab_order_id.Replace("'", "''") + "'" +
                "," + log.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + log.date_create + "= now() " +
                "," + log.date_cancel + "= '" + p.date_cancel + "'" +
                "," + log.date_modi + "= '" + p.date_modi + "'" +
                "," + log.user_cancel + "= '" + p.user_cancel + "'" +
                "," + log.user_create + "= '" + userId + "'" +
                "," + log.user_modi + "= '" + p.user_modi + "'" +
                "," + log.sort1 + "= '" + p.sort1 + "'" +
                "," + log.active + "= '" + p.active + "'" +
                "," + log.qty + "= '" + p.qty + "'" +
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
        public String update(LabOrderGroup p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + log.table + " Set " +
                " " + log.sort1 + " = '" + p.sort1.Replace("'", "''") + "'" +
                "," + log.lab_id + "= '" + p.lab_id.Replace("'", "''") + "'" +
                "," + log.lab_order_id + "= '" + p.lab_order_id.Replace("'", "''") + "'" +
                "," + log.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + log.date_modi + "= now() " +
                "," + log.date_cancel + "= '" + p.date_cancel + "'" +
                "," + log.user_cancel + "= '" + p.user_cancel + "'" +
                "," + log.user_modi + "= '" + userId + "'" +
                "," + log.qty + "= '" + p.qty + "'" +
                "Where " + log.pkField + "='" + p.lab_order_group_id + "'";

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
        public String insertNote(LabOrderGroup p, String userId)
        {
            String re = "";

            if (p.lab_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public LabOrderGroup setNote(DataTable dt)
        {
            LabOrderGroup ostkd1 = new LabOrderGroup();
            if (dt.Rows.Count > 0)
            {
                ostkd1.active = dt.Rows[0][log.active].ToString();
                ostkd1.date_cancel = dt.Rows[0][log.date_cancel].ToString();
                ostkd1.date_create = dt.Rows[0][log.date_create].ToString();
                ostkd1.date_modi = dt.Rows[0][log.date_modi].ToString();
                ostkd1.sort1 = dt.Rows[0][log.sort1].ToString();
                ostkd1.lab_id = dt.Rows[0][log.lab_id].ToString();
                ostkd1.lab_order_group_id = dt.Rows[0][log.lab_order_group_id].ToString();
                ostkd1.remark = dt.Rows[0][log.remark].ToString();
                ostkd1.lab_order_id = dt.Rows[0][log.lab_order_id].ToString();
                ostkd1.user_cancel = dt.Rows[0][log.user_cancel].ToString();
                ostkd1.user_create = dt.Rows[0][log.user_create].ToString();
                ostkd1.user_modi = dt.Rows[0][log.user_modi].ToString();
                ostkd1.qty = dt.Rows[0][log.qty].ToString();
            }
            else
            {
                setNote1(ostkd1);
            }
            return ostkd1;
        }
        private LabOrderGroup setNote1(LabOrderGroup stf1)
        {
            stf1.active = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.sort1 = "";
            stf1.lab_id = "";
            stf1.lab_order_group_id = "";
            stf1.remark = "";
            stf1.lab_order_id = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.qty = "";

            return stf1;
        }
    }
}
