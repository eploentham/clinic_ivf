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
    public class OldPackageHeaderDB
    {
        public OldPackageHeader oPkg;
        ConnectDB conn;
        public List<DoctorOld> ldtrO;
        public OldPackageHeaderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ldtrO = new List<DoctorOld>();
            oPkg = new OldPackageHeader();
            oPkg.PCKID = "PCKID";
            oPkg.PackageName = "PackageName";
            oPkg.Price = "Price";
            oPkg.active = "active";

            oPkg.table = "PackageHeader";
            oPkg.pkField = "PCKID";
        }
        public String insert(OldPackageHeader p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            Decimal chk1 = 0;

            p.PackageName = p.PackageName == null ? "" : p.PackageName;
            //p.Price = p.Price == null ? "0" : p.Price;
            p.Price = Decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";

            sql = "Insert Into " + oPkg.table + 
                " Set " + oPkg.PackageName + " = '" + p.PackageName.Replace("'","''") + "' "+
                "," + oPkg.Price + " = '" + p.Price + "' " +
                "," + oPkg.active + " = '1' " + 
                " ";
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
        public String update(OldPackageHeader p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.PackageName = p.PackageName == null ? "" : p.PackageName;
            p.Price = p.Price == null ? "0" : p.Price;

            sql = "Update " + oPkg.table + " Set " +
                " " + oPkg.PackageName + " = '" + p.PackageName.Replace("'", "''") + "' " +
                "," + oPkg.Price + " = '" + p.Price.Replace(",","") + "' " +
                "Where " + oPkg.pkField + "='" + p.PCKID + "'"
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
        public String insertPackageHeader(OldPackageHeader p, String userId)
        {
            String re = "";

            if (p.PCKID.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkg.* " +
                "From " + oPkg.table + " oPkg " +
                "Where oPkg." + oPkg.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldPackageHeader selectByPk1(String copId)
        {
            OldPackageHeader stf1 = new OldPackageHeader();
            DataTable dt = new DataTable();
            String sql = "select oPkg.*  " +
                "From " + oPkg.table + " oPkg " +
                "Where oPkg." + oPkg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setPackageHeader(dt);
            return stf1;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select oPkg." + oPkg.PCKID + ",oPkg." + oPkg.PackageName + ",oPkg." + oPkg.Price + " " +
                "From " + oPkg.table + " oPkg " +
                "Where active = '1' " +
                "Order By oPkg." + oPkg.PackageName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlDtr()
        {
            //lDept = new List<Position>();
            ldtrO.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                DoctorOld itm1 = new DoctorOld();
                itm1.ID = row[oPkg.PCKID].ToString();
                itm1.Name = row[oPkg.PackageName].ToString();
                ldtrO.Add(itm1);
            }
        }
        public void setCboPackage(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;
            if (ldtrO.Count <= 0) getlDtr();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Clear();
            c.Items.Add(item);
            foreach (DoctorOld cus1 in ldtrO)
            {
                item = new ComboBoxItem();
                item.Value = cus1.ID;
                item.Text = cus1.Name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
        public OldPackageHeader setPackageHeader(DataTable dt)
        {
            OldPackageHeader ostkd1 = new OldPackageHeader();
            if (dt.Rows.Count > 0)
            {
                ostkd1.PCKID = dt.Rows[0][oPkg.PCKID].ToString();
                ostkd1.PackageName = dt.Rows[0][oPkg.PackageName].ToString();
                ostkd1.Price = dt.Rows[0][oPkg.Price].ToString();                

            }
            else
            {
                setPackageHeader1(ostkd1);
            }
            return ostkd1;
        }
        private OldPackageHeader setPackageHeader1(OldPackageHeader stf1)
        {
            stf1.PCKID = "";
            stf1.PackageName = "";
            stf1.Price = "";
            return stf1;
        }
    }
}
