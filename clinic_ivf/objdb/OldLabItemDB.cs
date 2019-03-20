using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldLabItemDB
    {
        public OldLabItem labI;
        ConnectDB conn;

        public OldLabItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            labI = new OldLabItem();
            labI.LID = "LID";
            labI.LGID = "LGID";
            labI.LName = "LName";
            labI.WorkTime = "WorkTime";
            labI.Price = "Price";
            labI.SP1N = "SP1N";
            labI.SP1T = "SP1T";
            labI.SP2N = "SP2N";
            labI.SP2T = "SP2T";
            labI.SP3N = "SP3N";
            labI.SP3T = "SP3T";
            labI.SP4N = "SP4N";
            labI.SP4T = "SP4T";
            labI.SP5N = "SP5N";
            labI.SP5T = "SP5T";
            labI.SP6N = "SP6N";
            labI.SP6T = "SP6T";
            labI.SP7N = "SP7N";
            labI.SP7T = "SP7T";
            labI.SubItem = "SubItem";
            labI.WorkerGroup1 = "WorkerGroup1";
            labI.WorkerGroup2 = "WorkerGroup2";
            labI.WorkerGroup3 = "WorkerGroup3";
            labI.WorkerGroup4 = "WorkerGroup4";
            labI.QTY = "QTY";

            labI.table = "LabItem";
            labI.pkField = "LID";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldLabItem selectByPk1(String pttId)
        {
            OldLabItem labi1 = new OldLabItem();
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            labi1 = setLabItem(dt);
            return labi1;
        }
        public DataTable selectByBloodLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI."+labI.LID+ ",labI." + labI.LName+ ", '1' as qty,labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='1' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByBloodLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='1' and "+labI.SubItem+ "='0'  and active = '1' " +
                "Order By labI."+labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByHormoneLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='2' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByHormoneLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='2' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='3' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='3' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByEmbryoLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='4' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByEmbryoLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='4' and " + labI.SubItem + "='0' and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGeneticLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='5' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGeneticLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='5' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldLabItem setLabItem(DataTable dt)
        {
            OldLabItem vsold1 = new OldLabItem();
            if (dt.Rows.Count > 0)
            {
                vsold1.LID = dt.Rows[0][labI.LID].ToString();
                vsold1.LGID = dt.Rows[0][labI.LGID].ToString();
                vsold1.LName = dt.Rows[0][labI.LName].ToString();
                vsold1.WorkTime = dt.Rows[0][labI.WorkTime].ToString();
                vsold1.Price = dt.Rows[0][labI.Price].ToString();
                vsold1.SP1N = dt.Rows[0][labI.SP1N].ToString();
                vsold1.SP2N = dt.Rows[0][labI.SP2N].ToString();
                vsold1.SP3N = dt.Rows[0][labI.SP3N].ToString();
                vsold1.SP4N = dt.Rows[0][labI.SP4N].ToString();
                vsold1.SP5N = dt.Rows[0][labI.SP5N].ToString();
                vsold1.SP6N = dt.Rows[0][labI.SP6N].ToString();
                vsold1.SP7N = dt.Rows[0][labI.SP7N].ToString();
                vsold1.SP1T = dt.Rows[0][labI.SP1T].ToString();
                vsold1.SP2T = dt.Rows[0][labI.SP2T].ToString();
                vsold1.SP3T = dt.Rows[0][labI.SP3T].ToString();
                vsold1.SP4T = dt.Rows[0][labI.SP4T].ToString();
                vsold1.SP5T = dt.Rows[0][labI.SP5T].ToString();
                vsold1.SP6T = dt.Rows[0][labI.SP6T].ToString();
                vsold1.SP7T = dt.Rows[0][labI.SP7T].ToString();
                vsold1.SubItem = dt.Rows[0][labI.SubItem].ToString();
                vsold1.WorkerGroup1 = dt.Rows[0][labI.WorkerGroup1].ToString();
                vsold1.WorkerGroup2 = dt.Rows[0][labI.WorkerGroup2].ToString();
                vsold1.WorkerGroup3 = dt.Rows[0][labI.WorkerGroup3].ToString();
                vsold1.WorkerGroup4 = dt.Rows[0][labI.WorkerGroup4].ToString();
                vsold1.QTY = dt.Rows[0][labI.QTY].ToString();
                //vsold1.form_a_id = dt.Rows[0][labI.form_a_id].ToString();
            }
            else
            {
                setLabItem1(vsold1);
            }
            return vsold1;
        }
        private OldLabItem setLabItem1(OldLabItem stf1)
        {
            stf1.LID = "";
            stf1.LGID = "";
            stf1.LName = "";
            stf1.WorkTime = "";
            stf1.Price = "";
            stf1.SP1N = "";
            stf1.SP1T = "";
            stf1.SP2N = "";
            stf1.SP2T = "";
            stf1.SP3N = "";
            stf1.SP3T = "";
            stf1.SP4N = "";
            stf1.SP4T = "";
            stf1.SP5N = "";
            stf1.SP5T = "";
            stf1.SP6N = "";
            stf1.SP6T = "";
            stf1.SP7N = "";
            stf1.SP7T = "";
            stf1.SubItem = "";
            stf1.WorkerGroup1 = "";
            stf1.WorkerGroup2 = "";
            stf1.WorkerGroup3 = "";
            stf1.WorkerGroup4 = "";
            stf1.QTY = "";
            return stf1;
        }
    }
}
