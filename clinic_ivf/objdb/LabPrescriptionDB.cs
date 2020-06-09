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
        public LabPrescription lPresc;
        ConnectDB conn;

        public LabPrescriptionDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lPresc = new LabPrescription();
            lPresc.presc_id = "presc_id";
            lPresc.opu_fet_id = "opu_fet_id";
            lPresc.presc_date = "presc_date";
            lPresc.pkg_id = "pkg_id";
            lPresc.status_embryo_freezing = "status_embryo_freezing";
            lPresc.embryo_freezing = "embryo_freezing";
            lPresc.embryo_straws = "embryo_straws";
            lPresc.embryo_straws_extra = "embryo_straws_extra";
            lPresc.status_ngs = "status_ngs";
            lPresc.embryo_ngs = "embryo_ngs";
            lPresc.embryo_ngs_extra = "embryo_ngs_extra";
            lPresc.status_pgs = "status_pgs";
            lPresc.embryo_pgs = "embryo_pgs";
            lPresc.embryo_pgs_extra = "embryo_pgs_extra";
            lPresc.status_day6 = "status_day6";
            lPresc.status_assisted_hatching = "status_assisted_hatching";
            lPresc.status_ha = "status_ha";
            lPresc.status_sperm_selection = "status_sperm_selection";
            lPresc.status_sperm_precaution = "status_sperm_precaution";
            lPresc.status_embryo_glue = "status_embryo_glue";
            lPresc.status_embryo_remaining = "status_embryo_remaining";
            lPresc.embryo_remaining = "embryo_remaining";
            lPresc.status_discard_all = "status_discard_all";
            lPresc.staff_id = "staff_id";
            lPresc.checkby_id = "checkby_id";
            lPresc.sperm_selection = "sperm_selection";
            lPresc.sperm_precaution = "sperm_precaution";
            lPresc.visit_hn = "visit_hn";

            lPresc.table = "lab_t_prescription";
            lPresc.pkField = "closeday_id";

        }
        public LabPrescription selectByPk(String id)
        {
            LabPrescription cop1 = new LabPrescription();
            DataTable dt = new DataTable();
            String sql = "select labPresc.* " +
                "From " + lPresc.table + " labPresc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where labPresc." + lPresc.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrescription(dt);
            return cop1;
        }
        public LabPrescription selectByOpuFetID(String opudetid)
        {
            LabPrescription cop1 = new LabPrescription();
            DataTable dt = new DataTable();
            String sql = "select labPresc.* " +
                "From " + lPresc.table + " labPresc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where labPresc." + lPresc.opu_fet_id + " ='" + opudetid + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrescription(dt);
            return cop1;
        }
        public LabPrescription selectByHN(String hn)
        {
            LabPrescription cop1 = new LabPrescription();
            DataTable dt = new DataTable();
            String sql = "select labPresc.* " +
                "From " + lPresc.table + " labPresc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where labPresc." + lPresc.visit_hn + " ='" + hn + "' " +
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
            p.sperm_precaution = p.sperm_precaution == null ? "" : p.sperm_precaution;
            p.sperm_selection = p.sperm_selection == null ? "" : p.sperm_selection;
            p.visit_hn = p.visit_hn == null ? "" : p.visit_hn;

            p.opu_fet_id = long.TryParse(p.opu_fet_id, out chk) ? chk.ToString() : "0";
            p.pkg_id = long.TryParse(p.pkg_id, out chk) ? chk.ToString() : "0";
            p.staff_id = long.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            p.checkby_id = long.TryParse(p.checkby_id, out chk) ? chk.ToString() : "0";
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
            sql = "Insert Into " + lPresc.table + " set " +
                "" + lPresc.opu_fet_id + "= '" + p.opu_fet_id + "'" +
                "," + lPresc.active + "= '" + p.active + "'" +
                "," + lPresc.presc_date + "= '" + p.presc_date + "'" +
                "," + lPresc.pkg_id + "= '" + p.pkg_id + "'" +
                "," + lPresc.status_embryo_freezing + "= '" + p.status_embryo_freezing + "'" +
                "," + lPresc.embryo_freezing + "= '" + p.embryo_freezing + "'" +
                "," + lPresc.embryo_straws + "= '" + p.embryo_straws + "'" +
                "," + lPresc.embryo_straws_extra + "= '" + p.embryo_straws_extra + "'" +
                "," + lPresc.remark + "= '" + p.remark + "'" +
                "," + lPresc.date_create + "= now()" +
                "," + lPresc.date_modi + "= ''" +
                "," + lPresc.date_cancel + "= ''" +
                "," + lPresc.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lPresc.user_modi + "= ''" +
                "," + lPresc.user_cancel + "= ''" +
                "," + lPresc.status_ngs + "= '" + p.status_ngs + "'" +
                "," + lPresc.embryo_ngs + "= '" + p.embryo_ngs + "'" +
                "," + lPresc.embryo_ngs_extra + "= '" + p.embryo_ngs_extra + "'" +
                "," + lPresc.status_pgs + "= '" + p.status_pgs + "'" +
                "," + lPresc.embryo_pgs + "= '" + p.embryo_pgs + "'" +
                "," + lPresc.embryo_pgs_extra + "= '" + p.embryo_pgs_extra + "'" +
                "," + lPresc.status_day6 + "= '" + p.status_day6 + "'" +
                "," + lPresc.status_assisted_hatching + "= '" + p.status_assisted_hatching + "'" +
                "," + lPresc.status_ha + "= '" + p.status_ha + "'" +
                "," + lPresc.status_sperm_selection + "= '" + p.status_sperm_selection + "'" +
                "," + lPresc.status_sperm_precaution + "= '" + p.status_sperm_precaution + "'" +
                "," + lPresc.status_embryo_glue + "= '" + p.status_embryo_glue + "'" +
                "," + lPresc.status_embryo_remaining + "= '" + p.status_embryo_remaining + "'" +
                "," + lPresc.embryo_remaining + "= '" + p.embryo_remaining + "'" +
                "," + lPresc.status_discard_all + "= '" + p.status_discard_all + "'" +
                "," + lPresc.staff_id + "= '" + p.staff_id + "'" +
                "," + lPresc.checkby_id + "= '" + p.checkby_id + "'" +
                "," + lPresc.sperm_precaution + "= '" + p.sperm_precaution + "'" +
                "," + lPresc.sperm_selection + "= '" + p.sperm_selection + "'" +
                "," + lPresc.visit_hn + "= '" + p.visit_hn + "'" +
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
            sql = "Update " + lPresc.table + " Set " +
                "" + lPresc.opu_fet_id + "= '" + p.opu_fet_id + "'" +
                "," + lPresc.active + "= '" + p.active + "'" +
                "," + lPresc.presc_date + "= '" + p.presc_date + "'" +
                "," + lPresc.pkg_id + "= '" + p.pkg_id + "'" +
                "," + lPresc.status_embryo_freezing + "= '" + p.status_embryo_freezing + "'" +
                "," + lPresc.embryo_freezing + "= '" + p.embryo_freezing + "'" +
                "," + lPresc.embryo_straws + "= '" + p.embryo_straws + "'" +
                "," + lPresc.embryo_straws_extra + "= '" + p.embryo_straws_extra + "'" +
                "," + lPresc.remark + "= '" + p.remark + "'" +
                "," + lPresc.date_modi + "= now()" +
                "," + lPresc.user_modi + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lPresc.status_ngs + "= '" + p.status_ngs + "'" +
                "," + lPresc.embryo_ngs + "= '" + p.embryo_ngs + "'" +
                "," + lPresc.embryo_ngs_extra + "= '" + p.embryo_ngs_extra + "'" +
                "," + lPresc.status_pgs + "= '" + p.status_pgs + "'" +
                "," + lPresc.embryo_pgs + "= '" + p.embryo_pgs + "'" +
                "," + lPresc.embryo_pgs_extra + "= '" + p.embryo_pgs_extra + "'" +
                "," + lPresc.status_day6 + "= '" + p.status_day6 + "'" +
                "," + lPresc.status_assisted_hatching + "= '" + p.status_assisted_hatching + "'" +
                "," + lPresc.status_ha + "= '" + p.status_ha + "'" +
                "," + lPresc.status_sperm_selection + "= '" + p.status_sperm_selection + "'" +
                "," + lPresc.status_sperm_precaution + "= '" + p.status_sperm_precaution + "'" +
                "," + lPresc.status_embryo_glue + "= '" + p.status_embryo_glue + "'" +
                "," + lPresc.status_embryo_remaining + "= '" + p.status_embryo_remaining + "'" +
                "," + lPresc.embryo_remaining + "= '" + p.embryo_remaining + "'" +
                "," + lPresc.status_discard_all + "= '" + p.status_discard_all + "'" +
                "," + lPresc.staff_id + "= '" + p.staff_id + "'" +
                "," + lPresc.checkby_id + "= '" + p.checkby_id + "'" +
                "," + lPresc.sperm_precaution + "= '" + p.sperm_precaution + "'" +
                "," + lPresc.sperm_selection + "= '" + p.sperm_selection + "'" +
                "," + lPresc.visit_hn + "= '" + p.visit_hn + "'" +
                "Where " + lPresc.pkField + "='" + p.presc_id + "'"
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
                dgs1.presc_id = dt.Rows[0][lPresc.presc_id].ToString();
                dgs1.opu_fet_id = dt.Rows[0][lPresc.opu_fet_id].ToString();
                dgs1.presc_date = dt.Rows[0][lPresc.presc_date].ToString();
                dgs1.pkg_id = dt.Rows[0][lPresc.pkg_id].ToString();
                dgs1.status_embryo_freezing = dt.Rows[0][lPresc.status_embryo_freezing].ToString();
                dgs1.embryo_freezing = dt.Rows[0][lPresc.embryo_freezing].ToString();
                dgs1.embryo_straws = dt.Rows[0][lPresc.embryo_straws].ToString();
                dgs1.embryo_straws_extra = dt.Rows[0][lPresc.embryo_straws_extra].ToString();
                dgs1.active = dt.Rows[0][lPresc.active].ToString();
                dgs1.remark = dt.Rows[0][lPresc.remark].ToString();
                dgs1.date_create = dt.Rows[0][lPresc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lPresc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][lPresc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lPresc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lPresc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lPresc.user_cancel].ToString();
                dgs1.status_ngs = dt.Rows[0][lPresc.status_ngs].ToString();
                dgs1.embryo_ngs = dt.Rows[0][lPresc.embryo_ngs].ToString();
                dgs1.embryo_ngs_extra = dt.Rows[0][lPresc.embryo_ngs_extra].ToString();
                dgs1.status_pgs = dt.Rows[0][lPresc.status_pgs].ToString();
                dgs1.embryo_pgs = dt.Rows[0][lPresc.embryo_pgs].ToString();
                dgs1.embryo_pgs_extra = dt.Rows[0][lPresc.embryo_pgs_extra].ToString();
                dgs1.status_day6 = dt.Rows[0][lPresc.status_day6].ToString();
                dgs1.status_assisted_hatching = dt.Rows[0][lPresc.status_assisted_hatching].ToString();
                dgs1.status_ha = dt.Rows[0][lPresc.status_ha].ToString();
                dgs1.status_sperm_selection = dt.Rows[0][lPresc.status_sperm_selection].ToString();
                dgs1.status_sperm_precaution = dt.Rows[0][lPresc.status_sperm_precaution].ToString();
                dgs1.status_embryo_glue = dt.Rows[0][lPresc.status_embryo_glue].ToString();
                dgs1.status_embryo_remaining = dt.Rows[0][lPresc.status_embryo_remaining].ToString();
                dgs1.embryo_remaining = dt.Rows[0][lPresc.embryo_remaining].ToString();
                dgs1.status_discard_all = dt.Rows[0][lPresc.status_discard_all].ToString();
                dgs1.staff_id = dt.Rows[0][lPresc.staff_id].ToString();
                dgs1.checkby_id = dt.Rows[0][lPresc.checkby_id].ToString();
                dgs1.sperm_selection = dt.Rows[0][lPresc.sperm_selection].ToString();
                dgs1.sperm_precaution = dt.Rows[0][lPresc.sperm_precaution].ToString();
                dgs1.visit_hn = dt.Rows[0][lPresc.visit_hn].ToString();
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
            dgs1.sperm_selection = "";
            dgs1.sperm_precaution = "";
            dgs1.visit_hn = "";
            return dgs1;
        }
    }
}
