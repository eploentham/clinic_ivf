using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageSoldDB
    {
        public OldPackageSold opkgs;
        ConnectDB conn;

        public OldPackageSoldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opkgs = new OldPackageSold();
            opkgs.PCKSID = "PCKSID";
            opkgs.PID = "PID";
            opkgs.SellThruID = "SellThruID";
            opkgs.PCKID = "PCKID";
            opkgs.PackageName = "PackageName";
            opkgs.Price = "Price";
            opkgs.Date = "Date";
            opkgs.PaymentTimes = "PaymentTimes";
            opkgs.Status = "Status";
            opkgs.Payment1 = "Payment1";
            opkgs.Payment2 = "Payment2";
            opkgs.Payment3 = "Payment3";
            opkgs.Payment4 = "Payment4";
            opkgs.P1BDetailID = "P1BDetailID";
            opkgs.P2BDetailID = "P2BDetailID";
            opkgs.P3BDetailID = "P3BDetailID";
            opkgs.P4BDetailID = "P4BDetailID";
            opkgs.VN = "VN";
            opkgs.row1 = "row1";

            opkgs.table = "PackageSold";
            opkgs.pkField = "PCKSID";
        }
        private void chkNull(OldPackageSold p)
        {
            decimal chk = 0;
            long chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.PackageName = p.PackageName == null ? "" : p.PackageName;
            p.Date = p.Date == null ? "" : p.Date;
            p.Status = p.Status == null ? "0" : p.Status;

            p.PID = long.TryParse(p.PID, out chk1) ? chk1.ToString() : "0";
            p.SellThruID = long.TryParse(p.SellThruID, out chk1) ? chk1.ToString() : "0";
            p.PCKID = long.TryParse(p.PCKID, out chk1) ? chk1.ToString() : "0";
            
            p.PaymentTimes = long.TryParse(p.PaymentTimes, out chk1) ? chk1.ToString() : "0";
            p.P1BDetailID = long.TryParse(p.P1BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P2BDetailID = long.TryParse(p.P2BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P3BDetailID = long.TryParse(p.P3BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P4BDetailID = long.TryParse(p.P4BDetailID, out chk1) ? chk1.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk1) ? chk1.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk1) ? chk1.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk) ? chk.ToString() : "0";
            p.Payment1 = decimal.TryParse(p.Payment1, out chk) ? chk.ToString() : "0";
            p.Payment2 = decimal.TryParse(p.Payment2, out chk) ? chk.ToString() : "0";
            p.Payment3 = decimal.TryParse(p.Payment3, out chk) ? chk.ToString() : "0";
            p.Payment4 = decimal.TryParse(p.Payment4, out chk) ? chk.ToString() : "0";
        }
        public String insert(OldPackageSold p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + opkgs.table + " Set " +
                " " + opkgs.PID + " = '" + p.PID + "'" +
                "," + opkgs.SellThruID + "= '" + p.SellThruID + "'" +
                "," + opkgs.PCKID + "= '" + p.PCKID + "'" +
                "," + opkgs.PackageName + "= '" + p.PackageName.Replace("'", "''") + "'" +
                "," + opkgs.Price + "= '" + p.Price.Replace("'", "''") + "'" +
                "," + opkgs.Date + "= now()" +
                "," + opkgs.PaymentTimes + "= '" + p.PaymentTimes + "'" +
                "," + opkgs.Status + "= '" + p.Status + "'" +
                "," + opkgs.Payment1 + "= '" + p.Payment1 + "'" +
                "," + opkgs.Payment2 + "= '" + p.Payment2 + "'" +
                "," + opkgs.Payment3 + "= '" + p.Payment3 + "'" +
                "," + opkgs.Payment4 + "= '" + p.Payment4 + "'" +
                "," + opkgs.P1BDetailID + "= '" + p.P1BDetailID + "'" +
                "," + opkgs.P2BDetailID + "= '" + p.P2BDetailID + "'" +
                "," + opkgs.P3BDetailID + "= '" + p.P3BDetailID + "'" +
                "," + opkgs.P4BDetailID + "= '" + p.P4BDetailID + "'" +
                "," + opkgs.VN + "= '" + p.VN + "'" +
                "," + opkgs.row1 + "= '" + p.row1 + "'" +
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
        public String updateStatus3(String pkgid)
        {
            //$this->db->query("UPDATE PackageSold Set Status='3' Where PCKSID='".$PCKSID."'");
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + opkgs.table + " Set " +
                " " + opkgs.Status + " = '3'" +
                "Where " + opkgs.PCKSID + "='" + pkgid + "'"
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
        public String updateP4321(String vn)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Select * from PackageSold Where VN = '" + vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                if(int.TryParse(dt.Rows[0][opkgs.P4BDetailID].ToString(), out chk))
                {
                    if (chk > 0)
                    {
                        sql = "Update PackageSold set P4BDetailID=0 Where VN='"+vn+"' and P4BDetailID != 9999";
                        re = conn.ExecuteNonQuery(conn.conn, sql);
                    }
                    else
                    {
                        if (int.TryParse(dt.Rows[0][opkgs.P3BDetailID].ToString(), out chk))
                        {
                            if (chk > 0)
                            {
                                sql = "Update PackageSold set P3BDetailID=0 Where VN='" + vn + "' and P3BDetailID != 9999";
                                re = conn.ExecuteNonQuery(conn.conn, sql);
                            }
                            else
                            {
                                if (int.TryParse(dt.Rows[0][opkgs.P2BDetailID].ToString(), out chk))
                                {
                                    if (chk > 0)
                                    {
                                        sql = "Update PackageSold set P2BDetailID=0 Where VN='" + vn + "' and P2BDetailID != 9999";
                                        re = conn.ExecuteNonQuery(conn.conn, sql);
                                    }
                                    else
                                    {
                                        sql = "Update PackageSold set P1BDetailID=0 Where VN='" + vn + "' and P1BDetailID != 9999";
                                        re = conn.ExecuteNonQuery(conn.conn, sql);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return re;
        }
        public String deleteByPk(String pkgid)
        {
            //$this->db->query('delete from PackageSold Where PCKSID="' . $ID . '"');
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Delete From " + opkgs.table + "  " +                
                "Where " + opkgs.PCKSID + "='" + pkgid + "'"
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
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select opkgs.* " +
                "From " + opkgs.table + " opkgs " +
                "Where opkgs." + opkgs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldPackageSold selectByPk1(String pttId)
        {
            OldPackageSold labi1 = new OldPackageSold();
            DataTable dt = new DataTable();
            String sql = "select opkgs.* " +
                "From " + opkgs.table + " opkgs " +
                "Where opkgs." + opkgs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            labi1 = setLabItem(dt);
            return labi1;
        }
        public DataTable selectByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select opkgs.* " +
                "From " + opkgs.table + " opkgs " +
                "Where opkgs." + opkgs.VN + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPID(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select opkgs.* " +
                "From " + opkgs.table + " opkgs " +
                "Where opkgs." + opkgs.PID + " ='" + pttId + "' and Status<>3 ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldPackageSold setLabItem(DataTable dt)
        {
            OldPackageSold opkgs1 = new OldPackageSold();
            if (dt.Rows.Count > 0)
            {
                opkgs1.PCKSID = dt.Rows[0][opkgs.PCKSID].ToString();
                opkgs1.PID = dt.Rows[0][opkgs.PID].ToString();
                opkgs1.SellThruID = dt.Rows[0][opkgs.SellThruID].ToString();
                opkgs1.PCKID = dt.Rows[0][opkgs.PCKID].ToString();
                opkgs1.PackageName = dt.Rows[0][opkgs.PackageName].ToString();
                opkgs1.Price = dt.Rows[0][opkgs.Price].ToString();
                opkgs1.Date = dt.Rows[0][opkgs.Date].ToString();
                opkgs1.PaymentTimes = dt.Rows[0][opkgs.PaymentTimes].ToString();
                opkgs1.Status = dt.Rows[0][opkgs.Status].ToString();
                opkgs1.Payment1 = dt.Rows[0][opkgs.Payment1].ToString();
                opkgs1.Payment2 = dt.Rows[0][opkgs.Payment2].ToString();
                opkgs1.Payment3 = dt.Rows[0][opkgs.Payment3].ToString();
                opkgs1.Payment4 = dt.Rows[0][opkgs.Payment4].ToString();
                opkgs1.P1BDetailID = dt.Rows[0][opkgs.P1BDetailID].ToString();
                opkgs1.P2BDetailID = dt.Rows[0][opkgs.P2BDetailID].ToString();
                opkgs1.P3BDetailID = dt.Rows[0][opkgs.P3BDetailID].ToString();
                opkgs1.P4BDetailID = dt.Rows[0][opkgs.P4BDetailID].ToString();
                opkgs1.VN = dt.Rows[0][opkgs.VN].ToString();
                opkgs1.row1 = dt.Rows[0][opkgs.row1].ToString();
            }
            else
            {
                setLabItem1(opkgs1);
            }
            return opkgs1;
        }
        private OldPackageSold setLabItem1(OldPackageSold stf1)
        {
            stf1.PCKSID = "";
            stf1.PID = "";
            stf1.SellThruID = "";
            stf1.PCKID = "";
            stf1.PackageName = "";
            stf1.Price = "";
            stf1.Date = "";
            stf1.PaymentTimes = "";
            stf1.Status = "";
            stf1.Payment1 = "";
            stf1.Payment2 = "";
            stf1.Payment3 = "";
            stf1.Payment4 = "";
            stf1.P1BDetailID = "";
            stf1.P2BDetailID = "";
            stf1.P3BDetailID = "";
            stf1.P4BDetailID = "";
            stf1.VN = "";
            stf1.row1 = "";
            return stf1;
        }
    }
}
