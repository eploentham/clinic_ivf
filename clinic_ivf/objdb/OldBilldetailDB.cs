using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldBilldetailDB
    {
        public OldBilldetail obilld;
        ConnectDB conn;

        public OldBilldetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            obilld = new OldBilldetail();
            obilld.ID= "ID";
            obilld.VN= "VN";
            obilld.Name= "Name";
            obilld.Extra= "Extra";
            obilld.Price= "Price";
            obilld.Total= "Total";
            obilld.GroupType= "GroupType";
            obilld.Comment= "Comment";

            obilld.table = "BillDetail";
            obilld.pkField = "ID";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select obilld.* " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld.VN = '" + vn + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(OldBilldetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.Name = p.Name == null ? "" : p.Name;
            p.GroupType = p.GroupType == null ? "" : p.GroupType;
            p.Comment = p.Comment == null ? "" : p.Comment;
            

            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";            
            p.Total = decimal.TryParse(p.Total, out chk1) ? chk1.ToString() : "0";
            
        }
        public String insert(OldBilldetail p, String userId)
        {
            String re = "";
            String sql = "";
            //p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + obilld.table + " Set " +
                " " + obilld.VN + " = '" + p.VN + "'" +
                "," + obilld.Name + "= '" + p.Name.Replace("'", "''") + "'" +
                "," + obilld.Extra + "= '" + p.Extra + "'" +
                "," + obilld.Price + "= '" + p.Price + "'" +
                "," + obilld.Total + "= '" + p.Total + "'" +
                "," + obilld.GroupType + "= '" + p.GroupType + "'" +
                "," + obilld.Comment + "= '" + p.Comment.Replace("'", "''") + "'" +

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
        public String update(OldBilldetail p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + obilld.table + " Set " +
                " " + obilld.Name + " = '" + p.Name.Replace("'", "''") + "'" +
                "," + obilld.Extra + " = '" + p.Extra + "'" +
                "," + obilld.Price + " = '" + p.Price + "'" +
                "," + obilld.Total + " = '" + p.Total + "'" +
                "," + obilld.GroupType + " = '" + p.GroupType + "'" +
                "," + obilld.Comment + " = '" + p.Comment.Replace("'", "''") + "'" +

                "Where " + obilld.pkField + "='" + p.ID + "'"
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
        public String insertBillDetail(OldBilldetail p, String userId)
        {
            String re = "";

            if (p.ID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                //re = update(p, "");
            }

            return re;
        }
        public String delete(String vn)
        {
            String re = "";
            String sql = "";

            sql = "Delete From " + obilld.table + " Where " +
                " " + obilld.VN + " = '" + vn + "'"
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
        public String deletePk(String id)
        {
            String re = "";
            String sql = "";

            sql = "Delete From " + obilld.table + " Where " +
                " " + obilld.pkField + " = '" + id + "'"
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
    }
}
