using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldFilePatientDB
    {
        public OldFilePatient ofp;
        ConnectDB conn;
        public List<OldFilePatient> lofp;

        public OldFilePatientDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ofp = new OldFilePatient();
            lofp = new List<OldFilePatient>();
            ofp.ID = "ID";
            ofp.PID = "PID";
            ofp.Filename = "Filename";
            ofp.OrderFileNumber = "OrderFileNumber";
            ofp.DateTreatment = "DateTreatment";
            
            ofp.table = "FilePatient";
            ofp.pkField = "ID";
        }
        public DataTable selectByPID(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ofp.* " +
                "From " + ofp.table + " ofp " +
                "Where ofp." + ofp.PID + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
