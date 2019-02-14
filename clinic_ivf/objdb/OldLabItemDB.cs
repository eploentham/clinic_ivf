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
        public DataTable selectByBloodLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI."+labI.LID+ ",labI." + labI.LName+ ",labI." + labI.Price + " " +
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
    }
}
