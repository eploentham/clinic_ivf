using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldSpecialItemDB
    {
        public OldSpecialItem sitm;
        ConnectDB conn;
        public List<OldSpecialItem> loBilg;

        public OldSpecialItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            loBilg = new List<OldSpecialItem>();
            sitm = new OldSpecialItem();
            sitm.SID= "SID";
            sitm.SName= "SName";
            sitm.Price= "Price";
            sitm.W1GID= "W1GID";
            sitm.W2GID= "W2GID";
            sitm.W3GID= "W3GID";
            sitm.W4GID= "W4GID";
            sitm.isActive= "isActive";
            sitm.BillGroupID= "BillGroupID";
            sitm.active = "active";
            sitm.item_code = "item_code";

            sitm.table = "SpecialItem";
            sitm.pkField = "SID";
        }
        public String getList(String id)
        {
            String re = "";
            if (loBilg.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldSpecialItem sex in loBilg)
            {
                if (sex.SID.Equals(id))
                {
                    re = sex.SName;
                    break;
                }
            }
            return re;
        }
        public String getBillGroupID(String id)
        {
            String re = "";
            if (loBilg.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldSpecialItem sex in loBilg)
            {
                if (sex.SID.Equals(id))
                {
                    re = sex.BillGroupID;
                    break;
                }
            }
            return re;
        }
        public void getlCreditCardAccount()
        {
            //lDept = new List<Position>();
            loBilg.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldSpecialItem itm1 = new OldSpecialItem();
                itm1.SID = row[sitm.SID].ToString();
                itm1.SName = row[sitm.SName].ToString();
                itm1.BillGroupID = row[sitm.BillGroupID].ToString();
                loBilg.Add(itm1);
            }
        }
        private void chkNull(OldSpecialItem p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";

            p.SName = p.SName == null ? "" : p.SName;
            //p.EUsage = p.EUsage == null ? "" : p.EUsage;
            //p.TUsage = p.TUsage == null ? "" : p.TUsage;
            //p.UnitType = p.UnitType == null ? "" : p.UnitType;
            //p.UnitType = p.UnitType == null ? "" : p.UnitType;

            //p.Alert = p.Alert == null ? "0" : p.Alert;
            //p.QTY = p.QTY == null ? "0" : p.QTY;
            //p.PendingQTY = p.PendingQTY == null ? "0" : p.PendingQTY;
            //p.Price = p.Price.Equals("") ? "0" : p.Price;

            p.W1GID = long.TryParse(p.W1GID, out chk) ? chk.ToString() : "0";
            p.W2GID = long.TryParse(p.W2GID, out chk) ? chk.ToString() : "0";
            p.W3GID = long.TryParse(p.W3GID, out chk) ? chk.ToString() : "0";
            p.W4GID = long.TryParse(p.W4GID, out chk) ? chk.ToString() : "0";
            p.BillGroupID = long.TryParse(p.BillGroupID, out chk) ? chk.ToString() : "0";

            p.Price = Decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            //p.QTY = Decimal.TryParse(p.QTY, out chk1) ? chk1.ToString() : "0";
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public String insert(OldSpecialItem p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + sitm.table + " Set " +
                " " + sitm.SName + " = '" + p.SName.Replace("'", "''") + "'" +
                "," + sitm.Price + "= '" + p.Price + "'" +
                "," + sitm.W1GID + "= '" + p.W1GID + "'" +
                "," + sitm.W2GID + "= '" + p.W2GID + "'" +
                "," + sitm.W3GID + "= '" + p.W3GID + "'" +
                "," + sitm.W4GID + "= '" + p.W4GID + "'" +
                "," + sitm.isActive + "= '1'" +
                "," + sitm.active + "= '1'" +
                "," + sitm.BillGroupID + "= '" + p.BillGroupID + "'" +
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
        public String update(OldSpecialItem p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + sitm.table + " Set " +
                " " + sitm.SName + " = '" + p.SName.Replace("'", "''") + "'" +
                "," + sitm.Price + "= '" + p.Price + "'" +
                "," + sitm.W1GID + "= '" + p.W1GID + "'" +
                "," + sitm.W2GID + "= '" + p.W2GID + "'" +
                "," + sitm.W3GID + "= '" + p.W3GID + "'" +
                "," + sitm.W4GID + "= '" + p.W4GID + "'" +
                "," + sitm.BillGroupID + "= '" + p.BillGroupID + "'" +
                "Where " + sitm.pkField + "='" + p.SID + "'";
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
        public String updateCode(String id, String code, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + sitm.table + " Set " +
                " " + sitm.item_code + " = '" + code + "'" +
                "," + sitm.user_modi + "= '" + userId + "'" +
                "," + sitm.date_modi + "= now()" +
                "Where " + sitm.pkField + "='" + id + "'";
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
        public String updateCodeEx(String id, String code, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + sitm.table + " Set " +
                " " + sitm.item_code + " = '" + code + "'" +
                "," + sitm.user_modi + "= '" + userId + "'" +
                "," + sitm.date_modi + "= now()" +
                "Where " + sitm.pkField + "='" + id + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.connEx, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertSpecialItem(OldSpecialItem p, String userId)
        {
            String re = "";

            if (p.SID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String deleteByPk(String id)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Delete From  " + sitm.table + " " +
                "Where " + sitm.pkField + "='" + id + "'";
            //re = conn.ExecuteNonQuery(conn.conn, sql);
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
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm.*  " +
                "From " + sitm.table + " sitm " +
                "Where sitm."+sitm.active+" = '1'  ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll2()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm."+sitm.SID+" as id,"+sitm.item_code+" as code,"+sitm.SName+" as name " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.active + " = '1'  ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllEx()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm." + sitm.SID + " as id," + sitm.item_code + " as code," + sitm.SName + " as name " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.active + " = '1'  ";
            dt = conn.selectData(conn.connEx, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm."+ sitm.SID+","+ sitm.SName+","+ sitm.Price+",bilg.Name " +
                "From " + sitm.table + " sitm " +
                "Left Join BillGroup bilg on sitm."+sitm.BillGroupID + "= bilg.ID " +
                "Where sitm."+sitm.isActive+ "='1'  and sitm.active = '1' " +
                "Order By "+sitm.SName;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select sitm.* " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldSpecialItem selectByPk1(String pttId)
        {
            OldSpecialItem labi1 = new OldSpecialItem();
            DataTable dt = new DataTable();
            String sql = "select sitm.* " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            labi1 = setSpecialItem(dt);
            return labi1;
        }
        public DataTable selectBySpecialItem1()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm." + sitm.SID + ",sitm." + sitm.SName + ",sitm." + sitm.Price + " " +
                "From " + sitm.table + " sitm " +
                "Where isActive = '1'  and sitm.active = '1' " +
                "Order By sitm." + sitm.SName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpecialItem2()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm." + sitm.SID + ",sitm." + sitm.SName + ",sitm." + sitm.Price + ", bilg.Name as bilgrpname " +
                "From " + sitm.table + " sitm " +
                "Left Join BillGroup bilg on sitm."+sitm.BillGroupID + "=bilg.ID " +
                "Where isActive = '1' and sitm.active = '1' " +
                "Order By sitm." + sitm.SName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldSpecialItem setSpecialItem(DataTable dt)
        {
            OldSpecialItem sitm1 = new OldSpecialItem();
            if (dt.Rows.Count > 0)
            {
                sitm1.SID = dt.Rows[0][sitm.SID].ToString();
                sitm1.SName = dt.Rows[0][sitm.SName].ToString();
                sitm1.Price = dt.Rows[0][sitm.Price].ToString();
                sitm1.W1GID = dt.Rows[0][sitm.W1GID].ToString();
                sitm1.W2GID = dt.Rows[0][sitm.W2GID].ToString();
                sitm1.W3GID = dt.Rows[0][sitm.W3GID].ToString();
                sitm1.W4GID = dt.Rows[0][sitm.W4GID].ToString();
                sitm1.isActive = dt.Rows[0][sitm.isActive].ToString();
                sitm1.BillGroupID = dt.Rows[0][sitm.BillGroupID].ToString();
                sitm1.active = dt.Rows[0][sitm.active].ToString();
                sitm1.item_code = dt.Rows[0][sitm.item_code].ToString();
            }
            else
            {
                setSpecialItem1(sitm1);
            }
            return sitm1;
        }
        private OldSpecialItem setSpecialItem1(OldSpecialItem stf1)
        {
            stf1.SID = "";
            stf1.SName = "";
            stf1.Price = "";
            stf1.W1GID = "";
            stf1.W2GID = "";
            stf1.W3GID = "";
            stf1.W4GID = "";
            stf1.isActive = "";
            stf1.BillGroupID = "";
            stf1.active = "";
            stf1.item_code = "";
            return stf1;
        }
    }
}
