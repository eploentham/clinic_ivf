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
    public class OldPackageSellThruDB
    {
        public OldPackageSellThru opkgst;
        ConnectDB conn;
        public List<OldPackageSellThru> lSex;

        public OldPackageSellThruDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opkgst = new OldPackageSellThru();
            opkgst.STID = "STID";
            opkgst.SellThru = "SellThru";

            opkgst.table = "PackageSellThru";
            opkgst.pkField = "STID";

            lSex = new List<OldPackageSellThru>();
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select pkgst.*  " +
                "From " + opkgst.table + " pkgst " +
                " "
                //"Where pkgst." + pkgst.active + " ='1' "
                ;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlSex()
        {
            //lDept = new List<Position>();
            lSex.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldPackageSellThru itm1 = new OldPackageSellThru();
                itm1.STID = row[opkgst.STID].ToString();
                itm1.SellThru = row[opkgst.SellThru].ToString();

                lSex.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lSex.Count <= 0) getlSex();
            foreach (OldPackageSellThru sex in lSex)
            {
                if (sex.STID.Equals(id))
                {
                    re = sex.SellThru;
                    break;
                }
            }
            return re;
        }
        
        public C1ComboBox setCboPackageSellThru(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lSex.Count <= 0) getlSex();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldPackageSellThru row in lSex)
            {
                item = new ComboBoxItem();
                item.Value = row.STID;
                item.Text = row.SellThru;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            if (c.Items.Count > 0) c.SelectedIndex = 0;
            return c;
        }
    }
}
