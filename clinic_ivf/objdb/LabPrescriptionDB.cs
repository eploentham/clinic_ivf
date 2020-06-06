using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabPrescriptionDB
    {
        public LabPrescription labPresc;
        ConnectDB conn;

        public LabPrescriptionDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            labPresc = new LabPrescription();
            labPresc.presc_id = "presc_id";
            labPresc.opu_fet_id = "opu_fet_id";
            labPresc.presc_date = "presc_date";
            labPresc.pkg_id = "pkg_id";
            labPresc.status_embryo_freezing = "status_embryo_freezing";
            labPresc.embryo_freezing = "embryo_freezing";
            labPresc.embryo_straws = "embryo_straws";
            labPresc.embryo_straws_extra = "embryo_straws_extra";
            labPresc.status_ngs = "status_ngs";
            labPresc.embryo_ngs = "embryo_ngs";
            labPresc.embryo_ngs_extra = "embryo_ngs_extra";
            labPresc.status_pgs = "status_pgs";
            labPresc.embryo_pgs = "embryo_pgs";
            labPresc.embryo_pgs_extra = "embryo_pgs_extra";
            labPresc.status_day6 = "status_day6";
            labPresc.status_assisted_hatching = "status_assisted_hatching";
            labPresc.status_ha = "status_ha";
            labPresc.status_sperm_selection = "status_sperm_selection";
            labPresc.status_sperm_precaution = "status_sperm_precaution";
            labPresc.status_embryo_glue = "status_embryo_glue";
            labPresc.status_embryo_remaining = "status_embryo_remaining";
            labPresc.embryo_remaining = "embryo_remaining";
            labPresc.status_discard_all = "status_discard_all";
            labPresc.staff_id = "staff_id";
            labPresc.checkby_id = "checkby_id";

            labPresc.table = "lab_t_prescription";
            labPresc.pkField = "closeday_id";

        }
        public LabPrescription selectByPk(String id)
        {
            LabPrescription cop1 = new LabPrescription();
            DataTable dt = new DataTable();
            String sql = "select labPresc.* " +
                "From " + labPresc.table + " labPresc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where labPresc." + labPresc.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrescription(dt);
            return cop1;
        }
        private void chkNull(LabPrescription p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.presc_date = p.presc_date == null ? "" : p.presc_date;
            p.status_embryo_freezing = p.status_embryo_freezing == null ? "" : p.status_embryo_freezing;
            p.embryo_freezing = p.embryo_freezing == null ? "" : p.embryo_freezing;
            p.embryo_straws = p.embryo_straws == null ? "" : p.embryo_straws;
            p.embryo_straws_extra = p.embryo_straws_extra == null ? "" : p.embryo_straws_extra;
            p.status_ngs = p.status_ngs == null ? "" : p.status_ngs;
            p.embryo_ngs = p.embryo_ngs == null ? "" : p.embryo_ngs;
            p.embryo_ngs_extra = p.embryo_ngs_extra == null ? "" : p.embryo_ngs_extra;
            p.status_pgs = p.status_pgs == null ? "" : p.status_pgs;
            p.embryo_pgs = p.embryo_pgs == null ? "" : p.embryo_pgs;
            p.embryo_pgs_extra = p.embryo_pgs_extra == null ? "" : p.embryo_pgs_extra;
            p.status_day6 = p.status_day6 == null ? "" : p.status_day6;
            p.status_assisted_hatching = p.status_assisted_hatching == null ? "" : p.status_assisted_hatching;
            p.status_ha = p.status_ha == null ? "" : p.status_ha;
            p.status_sperm_selection = p.status_sperm_selection == null ? "" : p.status_sperm_selection;
            p.status_sperm_precaution = p.status_sperm_precaution == null ? "" : p.status_sperm_precaution;
            p.status_embryo_glue = p.status_embryo_glue == null ? "" : p.status_embryo_glue;
            p.status_embryo_remaining = p.status_embryo_remaining == null ? "" : p.status_embryo_remaining;
            p.embryo_remaining = p.embryo_remaining == null ? "" : p.embryo_remaining;
            p.status_discard_all = p.status_discard_all == null ? "" : p.status_discard_all;
            p.staff_id = p.staff_id == null ? "" : p.staff_id;
            p.checkby_id = p.checkby_id == null ? "" : p.checkby_id;

            p.opu_fet_id = long.TryParse(p.opu_fet_id, out chk) ? chk.ToString() : "0";
            p.pkg_id = long.TryParse(p.pkg_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(LabPrescription p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + labPresc.table + " set " +
                "" + labPresc.opu_fet_id + "= '" + p.opu_fet_id + "'" +
                "," + labPresc.active + "= '" + p.active + "'" +
                "," + labPresc.presc_date + "= '" + p.presc_date + "'" +
                "," + labPresc.pkg_id + "= '" + p.pkg_id + "'" +
                "," + labPresc.status_embryo_freezing + "= '" + p.status_embryo_freezing + "'" +
                "," + labPresc.embryo_freezing + "= '" + p.embryo_freezing + "'" +
                "," + labPresc.embryo_straws + "= '" + p.embryo_straws + "'" +
                "," + labPresc.embryo_straws_extra + "= '" + p.embryo_straws_extra + "'" +
                "," + labPresc.remark + "= '" + p.remark + "'" +
                "," + labPresc.date_create + "= now()" +
                "," + labPresc.date_modi + "= ''" +
                "," + labPresc.date_cancel + "= ''" +
                "," + labPresc.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + labPresc.user_modi + "= ''" +
                "," + labPresc.user_cancel + "= ''" +
                "," + labPresc.status_ngs + "= '" + p.status_ngs + "'" +
                "," + labPresc.embryo_ngs + "= '" + p.embryo_ngs + "'" +
                "," + labPresc.embryo_ngs_extra + "= '" + p.embryo_ngs_extra + "'" +
                "," + labPresc.status_pgs + "= '" + p.status_pgs + "'" +
                "," + labPresc.embryo_pgs + "= '" + p.embryo_pgs + "'" +
                "," + labPresc.embryo_pgs_extra + "= '" + p.embryo_pgs_extra + "'" +
                "," + labPresc.status_day6 + "= '" + p.status_day6 + "'" +
                "," + labPresc.status_assisted_hatching + "= '" + p.status_assisted_hatching + "'" +
                "," + labPresc.status_ha + "= '" + p.status_ha + "'" +
                "," + labPresc.status_sperm_selection + "= '" + p.status_sperm_selection + "'" +
                "," + labPresc.status_sperm_precaution + "= '" + p.status_sperm_precaution + "'" +
                "," + labPresc.status_embryo_glue + "= '" + p.status_embryo_glue + "'" +
                "," + labPresc.status_embryo_remaining + "= '" + p.status_embryo_remaining + "'" +
                "," + labPresc.embryo_remaining + "= '" + p.embryo_remaining + "'" +
                "," + labPresc.status_discard_all + "= '" + p.status_discard_all + "'" +
                "," + labPresc.staff_id + "= '" + p.staff_id + "'" +
                "," + labPresc.checkby_id + "= '" + p.checkby_id + "'" +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
                //conn.comStore.Dispose();
            }
            return re;
        }
        public String update(LabPrescription p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + labPresc.table + " Set " +
                "" + labPresc.opu_fet_id + "= '" + p.opu_fet_id + "'" +
                "," + labPresc.active + "= '" + p.active + "'" +
                "," + labPresc.presc_date + "= '" + p.presc_date + "'" +
                "," + labPresc.pkg_id + "= '" + p.pkg_id + "'" +
                "," + labPresc.status_embryo_freezing + "= '" + p.status_embryo_freezing + "'" +
                "," + labPresc.embryo_freezing + "= '" + p.embryo_freezing + "'" +
                "," + labPresc.embryo_straws + "= '" + p.embryo_straws + "'" +
                "," + labPresc.embryo_straws_extra + "= '" + p.embryo_straws_extra + "'" +
                "," + labPresc.remark + "= '" + p.remark + "'" +
                "," + labPresc.date_modi + "= now()" +
                "," + labPresc.user_modi + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + labPresc.status_ngs + "= '" + p.status_ngs + "'" +
                "," + labPresc.embryo_ngs + "= '" + p.embryo_ngs + "'" +
                "," + labPresc.embryo_ngs_extra + "= '" + p.embryo_ngs_extra + "'" +
                "," + labPresc.status_pgs + "= '" + p.status_pgs + "'" +
                "," + labPresc.embryo_pgs + "= '" + p.embryo_pgs + "'" +
                "," + labPresc.embryo_pgs_extra + "= '" + p.embryo_pgs_extra + "'" +
                "," + labPresc.status_day6 + "= '" + p.status_day6 + "'" +
                "," + labPresc.status_assisted_hatching + "= '" + p.status_assisted_hatching + "'" +
                "," + labPresc.status_ha + "= '" + p.status_ha + "'" +
                "," + labPresc.status_sperm_selection + "= '" + p.status_sperm_selection + "'" +
                "," + labPresc.status_sperm_precaution + "= '" + p.status_sperm_precaution + "'" +
                "," + labPresc.status_embryo_glue + "= '" + p.status_embryo_glue + "'" +
                "," + labPresc.status_embryo_remaining + "= '" + p.status_embryo_remaining + "'" +
                "," + labPresc.embryo_remaining + "= '" + p.embryo_remaining + "'" +
                "," + labPresc.status_discard_all + "= '" + p.status_discard_all + "'" +
                "," + labPresc.staff_id + "= '" + p.staff_id + "'" +
                "," + labPresc.checkby_id + "= '" + p.checkby_id + "'" +
                "Where " + labPresc.pkField + "='" + p.presc_id + "'"
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
        public String insertPrescription(LabPrescription p, String userId)
        {
            String re = "";

            if (p.presc_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public LabPrescription setPrescription(DataTable dt)
        {
            LabPrescription dgs1 = new LabPrescription();
            if (dt.Rows.Count > 0)
            {
                dgs1.presc_id = dt.Rows[0][labPresc.presc_id].ToString();
                dgs1.opu_fet_id = dt.Rows[0][labPresc.opu_fet_id].ToString();
                dgs1.presc_date = dt.Rows[0][labPresc.presc_date].ToString();
                dgs1.pkg_id = dt.Rows[0][labPresc.pkg_id].ToString();
                dgs1.status_embryo_freezing = dt.Rows[0][labPresc.status_embryo_freezing].ToString();
                dgs1.embryo_freezing = dt.Rows[0][labPresc.embryo_freezing].ToString();
                dgs1.embryo_straws = dt.Rows[0][labPresc.embryo_straws].ToString();
                dgs1.embryo_straws_extra = dt.Rows[0][labPresc.embryo_straws_extra].ToString();
                dgs1.active = dt.Rows[0][labPresc.active].ToString();
                dgs1.remark = dt.Rows[0][labPresc.remark].ToString();
                dgs1.date_create = dt.Rows[0][labPresc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][labPresc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][labPresc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][labPresc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][labPresc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][labPresc.user_cancel].ToString();
                dgs1.status_ngs = dt.Rows[0][labPresc.status_ngs].ToString();
                dgs1.embryo_ngs = dt.Rows[0][labPresc.embryo_ngs].ToString();
                dgs1.embryo_ngs_extra = dt.Rows[0][labPresc.embryo_ngs_extra].ToString();
                dgs1.status_pgs = dt.Rows[0][labPresc.status_pgs].ToString();
                dgs1.embryo_pgs = dt.Rows[0][labPresc.embryo_pgs].ToString();
                dgs1.embryo_pgs_extra = dt.Rows[0][labPresc.embryo_pgs_extra].ToString();
                dgs1.status_day6 = dt.Rows[0][labPresc.status_day6].ToString();
                dgs1.status_assisted_hatching = dt.Rows[0][labPresc.status_assisted_hatching].ToString();
                dgs1.status_ha = dt.Rows[0][labPresc.status_ha].ToString();
                dgs1.status_sperm_selection = dt.Rows[0][labPresc.status_sperm_selection].ToString();
                dgs1.status_sperm_precaution = dt.Rows[0][labPresc.status_sperm_precaution].ToString();
                dgs1.status_embryo_glue = dt.Rows[0][labPresc.status_embryo_glue].ToString();
                dgs1.status_embryo_remaining = dt.Rows[0][labPresc.status_embryo_remaining].ToString();
                dgs1.embryo_remaining = dt.Rows[0][labPresc.embryo_remaining].ToString();
                dgs1.status_discard_all = dt.Rows[0][labPresc.status_discard_all].ToString();
                dgs1.staff_id = dt.Rows[0][labPresc.staff_id].ToString();
                dgs1.checkby_id = dt.Rows[0][labPresc.checkby_id].ToString();
            }
            else
            {
                setPrescription(dgs1);
            }
            return dgs1;
        }
        public LabPrescription setPrescription(LabPrescription dgs1)
        {
            dgs1.presc_id = "";
            dgs1.opu_fet_id = "";
            dgs1.presc_date = "";
            dgs1.pkg_id = "";
            dgs1.status_embryo_freezing = "";
            dgs1.embryo_freezing = "";
            dgs1.embryo_straws = "";
            dgs1.embryo_straws_extra = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.status_ngs = "";
            dgs1.embryo_ngs = "";
            dgs1.embryo_ngs_extra = "";
            dgs1.status_pgs = "";
            dgs1.embryo_pgs = "";
            dgs1.embryo_pgs_extra = "";
            dgs1.status_day6 = "";
            dgs1.status_assisted_hatching = "";
            dgs1.status_ha = "";
            dgs1.status_sperm_selection = "";
            dgs1.status_sperm_precaution = "";
            dgs1.status_embryo_glue = "";
            dgs1.status_embryo_remaining = "";
            dgs1.embryo_remaining = "";
            dgs1.status_discard_all = "";
            dgs1.staff_id = "";
            dgs1.checkby_id = "";
            return dgs1;
        }
    }
}
