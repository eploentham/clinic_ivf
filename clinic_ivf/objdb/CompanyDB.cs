using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic_ivf.object1;

namespace clinic_ivf.objdb
{
    public class CompanyDB
    {
        public Company cop;
        ConnectDB conn;
        public CompanyDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cop = new Company();
            cop.comp_id = "comp_id";
            cop.comp_code = "comp_code";
            cop.comp_name_t = "comp_name_t";
            cop.comp_name_e = "comp_name_e";
            cop.comp_address_e = "comp_address_e";
            cop.comp_address_t = "comp_address_t";
            cop.addr1 = "addr1";
            cop.addr2 = "addr2";
            cop.amphur_id = "amphur_id";
            cop.district_id = "district_id";
            cop.province_id = "province_id";
            cop.zipcode = "zipcode";
            cop.tele = "tele";
            cop.fax = "fax";
            cop.email = "email";
            cop.website = "website";
            cop.logo = "logo";
            cop.tax_id = "tax_id";
            cop.vat = "vat";
            cop.spec1 = "spec1";
            cop.date_create = "date_create";
            cop.date_modi = "date_modi";
            cop.date_cancel = "date_cancel";
            cop.user_create = "user_create";
            cop.user_modi = "user_modi";
            cop.user_cancel = "user_cancel";
            cop.qu_line1 = "qu_line1";
            cop.qu_line2 = "qu_line2";
            cop.qu_line3 = "qu_line3";
            cop.qu_line4 = "qu_line4";
            cop.qu_line5 = "qu_line5";
            cop.qu_line6 = "qu_line6";
            cop.inv_line1 = "inv_line1";
            cop.inv_line2 = "inv_line2";
            cop.inv_line3 = "inv_line3";
            cop.inv_line4 = "inv_line4";
            cop.inv_line5 = "inv_line5";
            cop.inv_line6 = "inv_line6";
            cop.po_line1 = "po_line1";
            cop.po_due_period = "po_due_period";
            cop.active = "active";
            cop.remark = "remark";
            cop.taddr1 = "taddr1";
            cop.taddr2 = "taddr2";
            cop.taddr3 = "taddr3";
            cop.taddr4 = "taddr4";
            cop.eaddr1 = "eaddr1";
            cop.eaddr2 = "eaddr2";
            cop.eaddr3 = "eaddr3";
            cop.eaddr4 = "eaddr4";
            cop.year_curr = "year_curr";
            cop.cash_draw_doc = "cash_draw_doc";
            cop.amount_reserve = "amount_reserve";
            cop.billing_doc = "billing_doc";
            cop.receipt_doc = "receipt_doc";
            cop.billing_cover_doc = "billing_cover_doc";
            cop.req_doc = "req_doc";
            cop.month_curr = "month_curr";
            cop.prefix_opu_doc = "prefix_opu_doc";
            cop.prefix_billing_doc = "prefix_billing_doc";
            cop.prefix_receipt_doc = "prefix_receipt_doc";
            cop.prefix_billing_cover_doc = "prefix_billing_cover_doc";
            cop.prefix_req_doc = "prefix_req_doc";
            cop.opu_doc = "opu_doc";
            cop.hn_doc = "hn_doc";
            cop.prefix_hn_doc = "prefix_hn_doc";
            cop.vn_doc = "vn_doc";
            cop.prefix_vn_doc = "prefix_vn_doc";
            cop.queue_doc = "queue_doc";
            cop.current_date = "current_date1";
            cop.form_a_doc = "form_a_doc";
            cop.prefix_form_a_doc = "prefix_form_a";
            cop.fet_doc = "fet_doc";
            cop.prefix_fet_doc = "prefix_fet_doc";
            cop.year = "";
            cop.month = "";
            cop.day = "";
            cop.day_curr = "day_curr";

            cop.table = "b_company";
            cop.pkField = "comp_id";
        }
        private void chkNull(Company p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.qu_line1 = p.qu_line1 == null ? "" : p.qu_line1;
            p.qu_line2 = p.qu_line2 == null ? "" : p.qu_line2;
            p.qu_line3 = p.qu_line3 == null ? "" : p.qu_line3;
            p.qu_line4 = p.qu_line4 == null ? "" : p.qu_line4;
            p.qu_line5 = p.qu_line5 == null ? "" : p.qu_line5;
            p.qu_line6 = p.qu_line6 == null ? "" : p.qu_line6;
            p.inv_line1 = p.inv_line1 == null ? "" : p.inv_line1;
            p.inv_line2 = p.inv_line2 == null ? "" : p.inv_line2;
            p.inv_line4 = p.inv_line4 == null ? "" : p.inv_line4;
            p.inv_line5 = p.inv_line5 == null ? "" : p.inv_line5;
            p.inv_line6 = p.inv_line6 == null ? "" : p.inv_line6;
            p.qu_line3 = p.inv_line3 == null ? "" : p.inv_line3;
            p.po_line1 = p.po_line1 == null ? "" : p.po_line1;
            p.po_due_period = p.po_due_period == null ? "" : p.po_due_period;
            p.addr1 = p.addr1 == null ? "" : p.addr1;
            p.addr2 = p.addr2 == null ? "" : p.addr2;
            p.amphur_id = p.amphur_id == null ? "" : p.amphur_id;
            p.district_id = p.district_id == null ? "" : p.district_id;
            p.month_curr = p.month_curr == null ? "" : p.month_curr;
            p.prefix_opu_doc = p.prefix_opu_doc == null ? "" : p.prefix_opu_doc;
            p.prefix_billing_doc = p.prefix_billing_doc == null ? "" : p.prefix_billing_doc;
            p.prefix_receipt_doc = p.prefix_receipt_doc == null ? "" : p.prefix_receipt_doc;
            p.prefix_billing_cover_doc = p.prefix_billing_cover_doc == null ? "" : p.prefix_billing_cover_doc;
            p.prefix_req_doc = p.prefix_req_doc == null ? "" : p.prefix_req_doc;
            p.opu_doc = p.opu_doc == null ? "0" : p.opu_doc;
            p.hn_doc = p.hn_doc == null ? "0" : p.hn_doc;
            p.prefix_hn_doc = p.prefix_hn_doc == null ? "" : p.prefix_hn_doc;
            p.vn_doc = p.vn_doc == null ? "0" : p.vn_doc;
            p.prefix_vn_doc = p.prefix_vn_doc == null ? "" : p.prefix_vn_doc;
            p.queue_doc = p.queue_doc == null ? "0" : p.queue_doc;
            p.current_date = p.current_date == null ? "" : p.current_date;
            p.prefix_form_a_doc = p.prefix_form_a_doc == null ? "" : p.prefix_form_a_doc;

            p.amount_reserve = Decimal.TryParse(p.amount_reserve, out chk1) ? chk1.ToString() : "0";
            p.billing_doc = int.TryParse(p.billing_doc, out chk) ? chk.ToString() : "0";
            p.receipt_doc = int.TryParse(p.receipt_doc, out chk) ? chk.ToString() : "0";
            p.billing_cover_doc = int.TryParse(p.billing_cover_doc, out chk) ? chk.ToString() : "0";
            p.cash_draw_doc = int.TryParse(p.cash_draw_doc, out chk) ? chk.ToString() : "0";
            p.req_doc = int.TryParse(p.req_doc, out chk) ? chk.ToString() : "0";
            p.form_a_doc = int.TryParse(p.form_a_doc, out chk) ? chk.ToString() : "0";
        }
        public String insert(Company p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";


            chkNull(p);
            sql = "Insert Into " + cop.table + "(" + cop.comp_code + "," + cop.comp_name_t + "," + cop.comp_name_e + "," +
                cop.comp_address_e + "," + cop.comp_address_t + ", " + cop.addr1 + ", " +
                cop.addr2 + "," + cop.amphur_id + ", " + cop.district_id + ", " +
                cop.province_id + "," + cop.zipcode + ", " + cop.tele + ", " +
                cop.fax + "," + cop.email + ", " + cop.website + ", " +
                cop.logo + "," + cop.tax_id + ", " + cop.vat + ", " +
                cop.spec1 + "," + cop.date_create + ", " + cop.date_modi + ", " +
                cop.date_cancel + "," + cop.user_create + ", " + cop.user_modi + ", " +
                cop.user_cancel + "," + cop.remark + ", " + 
                cop.qu_line1 + "," + cop.qu_line2 + ", " + cop.qu_line3 + ", " +
                cop.qu_line4 + "," + cop.qu_line5 + ", " + cop.qu_line6 + ", " +
                cop.inv_line1 + "," + cop.inv_line2 + ", " + cop.inv_line3 + ", " +
                cop.inv_line4 + "," + cop.inv_line5 + ", " + cop.inv_line6 + ", " +
                cop.po_line1 + "," + cop.po_due_period + ", " + cop.active + ", " +
                cop.taddr1 + "," + cop.taddr2 + ", " + cop.taddr3 + ", " +
                cop.taddr4 + "," + cop.eaddr1 + ", " + cop.eaddr2 + ", " +
                cop.eaddr3 + "," + cop.eaddr4 + ","  + cop.amount_reserve + " " +
                ") " +
                "Values ('" + p.comp_code + "','" + p.comp_name_t.Replace("'","''") + "','" + p.comp_name_e.Replace("'", "''") + "'," +
                "'" + p.comp_address_e.Replace("'", "''") + "','" + p.comp_address_t.Replace("'", "''") + "','" + p.addr1.Replace("'", "''") + "'," +
                "'" + p.addr2.Replace("'", "''") + "','" + p.amphur_id + "','" + p.district_id + "'," +
                "'" + p.province_id + "','" + p.zipcode + "','" + p.tele + "'," +
                "'" + p.fax + "','" + p.email + "','" + p.website + "'," +
                "'" + p.logo + "','" + p.tax_id + "','" + p.vat + "'," +
                "'" + p.spec1 + "',now(),'" + p.date_modi + "'," +
                "'" + p.date_cancel + "','" + userId + "','" + p.user_modi + "'," +
                "'" + p.user_cancel + "','" + p.remark.Replace("'", "''") + "'," +
                "'" + p.qu_line1 + "','" + p.qu_line2 + "','" + p.qu_line3 + "'," +
                "'" + p.qu_line4 + "','" + p.qu_line5 + "','" + p.qu_line6 + "'," +
                "'" + p.inv_line1 + "','" + p.inv_line2 + "','" + p.inv_line3 + "'," +
                "'" + p.inv_line4 + "','" + p.inv_line5 + "','" + p.inv_line6 + "'," +
                "'" + p.po_line1 + "','" + p.po_due_period + "','" + p.active + "', " +
                "'" + p.taddr1 + "','" + p.taddr2 + "','" + p.taddr3 + "', " +
                "'" + p.taddr4 + "','" + p.eaddr1 + "','" + p.eaddr2 + "', " +
                "'" + p.eaddr3 + "','" + p.eaddr4 + "','" + p.amount_reserve + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " "+ex.InnerException;
            }
            

            return re;
        }
        public String update(Company p, String userId)
        {
            String re = "", sql = "";

            chkNull(p);

            sql = "Update " + cop.table + " Set " +
                " " + cop.comp_code + "='"+p.comp_code + "' " +
                "," + cop.comp_name_t+ "='"+p.comp_name_t.Replace("'", "''") + "' " +
                "," + cop.comp_name_e+ "='"+p.comp_name_e.Replace("'", "''") + "' " +
                "," + cop.comp_address_e+ "='"+p.comp_address_e.Replace("'", "''") + "' " +
                "," + cop.comp_address_t+ "='"+p.comp_address_t.Replace("'", "''") + "' " +
                "," + cop.addr1+ "='"+p.addr1.Replace("'", "''") + "' " +
                "," + cop.addr2+ "='"+p.addr2.Replace("'", "''") + "' " +
                "," + cop.amphur_id+ "='"+p.amphur_id+ "' " +
                "," + cop.district_id+ "='"+p.district_id+ "' " +
                "," + cop.province_id+ "='"+p.province_id+ "' " +
                "," + cop.zipcode+ "='"+p.zipcode+ "' " +
                "," + cop.tele+ "='"+p.tele+ "' " +
                "," + cop.fax+ "='"+p.fax+ "' " +
                "," + cop.email+ "='"+p.email+ "' " +
                "," + cop.website+ "='"+p.website+ "' " +
                "," + cop.logo+ "='"+p.logo+ "' " +
                "," + cop.tax_id+ "='"+p.tax_id+ "' " +
                "," + cop.vat+ "='"+p.vat+ "' " +
                "," + cop.spec1+ "='"+p.spec1+ "' " +
                //"," + cop.date_create+ "='"+p.date_create+ "' " +
                "," + cop.date_modi+ "= now() " +
                //"," + cop.date_cancel+ "='"+p.date_cancel+ "' " +
                //"," + cop.user_create+ "='"+p.user_create+ "' " +
                "," + cop.user_modi+ "='"+ userId + "' " +
                //"," + cop.user_cancel+ "='"+p.user_cancel+ "' " +
                "," + cop.qu_line1+ "='"+p.qu_line1+ "' " +
                "," + cop.qu_line2+ "='"+p.qu_line2+ "' " +
                "," + cop.qu_line3+ "='"+p.qu_line3+ "' " +
                "," + cop.qu_line4+ "='"+p.qu_line4+ "' " +
                "," + cop.qu_line5+ "='"+p.qu_line5+ "' " +
                "," + cop.qu_line6+ "='"+p.qu_line6+ "' " +
                "," + cop.inv_line1+ "='"+p.inv_line1+ "' " +
                "," + cop.inv_line2+ "='"+p.inv_line2+ "' " +
                "," + cop.inv_line3+ "='"+p.inv_line3+ "' " +
                "," + cop.inv_line4+ "='"+p.inv_line4+ "' " +
                "," + cop.inv_line5+ "='"+p.inv_line5+ "' " +
                "," + cop.inv_line6+ "='"+p.inv_line6+ "' " +
                "," + cop.po_line1+ "='"+p.po_line1+ "' " +
                "," + cop.po_due_period+ "='"+p.po_due_period+ "' " +
                //"," + cop.active+ "='"+p.active+ "' " +
                "," + cop.remark+ "='"+p.remark.Replace("'", "''") + "' " +
                "," + cop.taddr1 + "='" + p.taddr1.Replace("'", "''") + "' " +
                "," + cop.taddr2 + "='" + p.taddr2.Replace("'", "''") + "' " +
                "," + cop.taddr3 + "='" + p.taddr3.Replace("'", "''") + "' " +
                "," + cop.taddr4 + "='" + p.taddr4.Replace("'", "''") + "' " +
                "," + cop.eaddr1 + "='" + p.eaddr1.Replace("'", "''") + "' " +
                "," + cop.eaddr2 + "='" + p.eaddr2.Replace("'", "''") + "' " +
                "," + cop.eaddr3 + "='" + p.eaddr3.Replace("'", "''") + "' " +
                "," + cop.eaddr4 + "='" + p.eaddr4.Replace("'", "''") + "' " +
                "Where " + cop.pkField + "='" + p.comp_id + "'"
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
        public String insertCompany(Company p, String userId)
        {
            String re = "";

            if (p.comp_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + cop.table + " cop " +
                " " +
                "Where cop." + cop.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cop.* " +
                "From " + cop.table + " cop " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cop." + cop.comp_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);            
            return dt;
        }
        public Company selectByPk1(String copId)
        {
            Company cop1 = new Company();
            DataTable dt = new DataTable();
            String sql = "select cop.*, month(now()) as month, day(now()) as day, year(now()) as year " +
                "From " + cop.table + " cop " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cop." + cop.comp_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCompany(dt);
            return cop1;
        }
        public Company selectByCode1(String copId)
        {
            Company cop1 = new Company();
            DataTable dt = new DataTable();
            String sql = "select cop.*, date_format(now(),'%m') as month, date_format(now(),'%d') as day, year(now()) as year " +
                "From " + cop.table + " cop " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cop." + cop.comp_code + " ='" + copId + "' and cop." + cop.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCompany(dt);
            return cop1;
        }
        public String genCashDrawDoc()
        {
            String doc = "", year="", sql="";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    ","+cop.cash_draw_doc+"=1 " +
                    "Where "+cop.pkField+"='"+cop1.comp_id+"'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if(int.TryParse(cop1.cash_draw_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +                    
                    "" + cop.cash_draw_doc + "="+chk +
                    " Where " + cop.pkField + "='"+ cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = "CD"+year.Substring(year.Length-2,2) + doc;
            return doc;
        }
        public String genBillingDoc(ref String year1, ref String month, ref String day)
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            //year = DateTime.Now.ToString("yyyy");
            year1 = cop1.year;
            month = cop1.month;
            day = cop1.day;
            if (!cop1.year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + cop1.year + "' " +
                    //"," + cop.billing_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.month.Equals(cop1.month_curr))
            {
                cop1.month = "00" + cop1.month;
                cop1.month = cop1.month.Substring(cop1.month.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.month_curr + "='" + cop1.month + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                cop1.billing_doc = "00000";
            }

            int chk = 0;
            if (int.TryParse(cop1.billing_doc, out chk))
            {
                chk++;
                doc = "00000" + chk;
                doc = doc.Substring(doc.Length - 5, 5);
                year = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.billing_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            try
            {
                int.TryParse(cop1.year, out chk);
                chk = chk + 543;
                cop1.year = chk.ToString();
                cop1.year = cop1.year.Substring(cop1.year.Length - 2, 2);
            }
            catch (Exception ex)
            {

            }
            doc = cop1.prefix_billing_doc + cop1.year + cop1.month + doc;
            return doc;
        }
        public String genReceiptDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.receipt_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if (int.TryParse(cop1.receipt_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +
                    "" + cop.receipt_doc + "=" + chk +
                    " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = "RE" + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String genBillingCoverDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.billing_cover_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if (int.TryParse(cop1.billing_cover_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +
                    "" + cop.billing_cover_doc + "=" + chk +
                    " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = "BC" + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String genReqDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.req_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if (int.TryParse(cop1.req_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +
                    "" + cop.req_doc + "=" + chk +
                    " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = cop1.prefix_req_doc + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String genOPUDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.opu_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if (int.TryParse(cop1.opu_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +
                    "" + cop.opu_doc + "=" + chk +
                    " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = "OPU" + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String genHNDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.hn_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            
            int chk = 0;
            if (int.TryParse(cop1.hn_doc, out chk))
            {
                chk++;
                doc = "00000" + chk;
                doc = doc.Substring(doc.Length - 5, 5);
                year = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.hn_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            year = String.Concat(DateTime.Now.Year +543);
            doc = cop1.prefix_hn_doc + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String genBillingExtDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            //year = DateTime.Now.ToString("yyyy");
            if (!cop1.year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + cop1.year + "' " +
                    //"," + cop.vn_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.month.Equals(cop1.month_curr))
            {
                cop1.month = "00" + cop1.month;
                cop1.month = cop1.month.Substring(cop1.month.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.month_curr + "='" + cop1.month + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                cop1.billing_doc = "00000";
            }
            
            int chk = 0;
            if (int.TryParse(cop1.billing_cover_doc, out chk))
            {
                chk++;
                doc = "00000" + chk;
                doc = doc.Substring(doc.Length - 5, 5);
                //year = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.billing_cover_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            try
            {
                int.TryParse(cop1.year, out chk);
                chk = chk + 543;
                cop1.year = chk.ToString();
                cop1.year = cop1.year.Substring(cop1.year.Length - 2, 2);
            }
            catch(Exception ex)
            {

            }
            
            //year = String.Concat(DateTime.Now.Year + 543);
            doc = cop1.prefix_billing_cover_doc + cop1.year + cop1.month + doc;
            return doc;
        }
        public String genVNDocWW()
        {
            DataTable dt = new DataTable();
            String doc = "", sql="", max="";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            if (!cop1.year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + cop1.year + "' " +
                    //"," + cop.vn_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.month.Equals(cop1.month_curr))
            {
                cop1.month = "00" + cop1.month;
                cop1.month = cop1.month.Substring(cop1.month.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.month_curr + "='" + cop1.month + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.day.Equals(cop1.day_curr))
            {
                cop1.day = "00" + cop1.day;
                cop1.day = cop1.day.Substring(cop1.day.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.day_curr + "='" + cop1.day + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                cop1.vn_doc = "000";
                doc = cop1.prefix_vn_doc + cop1.year + cop1.month + cop1.day + doc;
            }
            else
            {
                sql = "Select Max(VN) as vn From Visit ";
                dt = conn.selectData(conn.conn, sql);
                max = dt.Rows[0]["vn"].ToString();
                long chk = 0;
                if (long.TryParse(max, out chk))
                {
                    chk++;
                }
                doc = chk.ToString();
            }
            
            return doc;
        }
        public String genVNDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            //year = DateTime.Now.ToString("yyyy");
            if (!cop1.year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + cop1.year + "' " +
                    //"," + cop.vn_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.month.Equals(cop1.month_curr))
            {
                cop1.month = "00" + cop1.month;
                cop1.month = cop1.month.Substring(cop1.month.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.month_curr + "='" + cop1.month + "' " +
                    
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }
            if (!cop1.day.Equals(cop1.day_curr))
            {
                cop1.day = "00" + cop1.day;
                cop1.day = cop1.day.Substring(cop1.day.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.day_curr + "='" + cop1.day + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                cop1.vn_doc = "000";
            }

            int chk = 0;
            if (int.TryParse(cop1.vn_doc, out chk))
            {
                chk++;
                doc = "000" + chk;
                doc = doc.Substring(doc.Length - 3, 3);
                year = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.vn_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            //year = String.Concat(DateTime.Now.Year + 543);
            doc = cop1.prefix_vn_doc + cop1.year + cop1.month + cop1.day + doc;
            return doc;
        }
        public String genQueueDoc()
        {
            String doc = "", currDate = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            if (!cop1.day.Equals(cop1.day_curr))
            {
                cop1.day = "00" + cop1.day;
                cop1.day = cop1.day.Substring(cop1.day.Length - 2, 2);
                sql = "Update " + cop.table + " Set " +
                    " " + cop.day_curr + "='" + cop1.day + "' " +

                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                cop1.queue_doc = "000";
            }

            int chk = 0;
            if (int.TryParse(cop1.queue_doc, out chk))
            {
                chk++;
                doc = "000" + chk;
                doc = doc.Substring(doc.Length - 3, 3);
                currDate = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.queue_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            
            return doc;
        }
        public String genFormADoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.form_a_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                //doc = "00001";
            }

            int chk = 0;
            if (int.TryParse(cop1.form_a_doc, out chk))
            {
                chk++;
                doc = "00000" + chk;
                doc = doc.Substring(doc.Length - 5, 5);
                year = cop1.year_curr;

                sql = "Update " + cop.table + " Set " +
                "" + cop.form_a_doc + "=" + chk +
                " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
            }
            year = String.Concat(DateTime.Now.Year + 543);
            doc = cop1.prefix_vn_doc + doc;
            return doc;
        }
        public String genFEFDoc()
        {
            String doc = "", year = "", sql = "";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            year = DateTime.Now.ToString("yyyy");
            if (!year.Equals(cop1.year_curr))
            {
                sql = "Update " + cop.table + " Set " +
                    " " + cop.year_curr + "='" + year + "' " +
                    "," + cop.fet_doc + "=1 " +
                    "Where " + cop.pkField + "='" + cop1.comp_id + "'";
                conn.ExecuteNonQuery(conn.conn, sql);
                doc = "00001";
            }
            else
            {
                int chk = 0;
                if (int.TryParse(cop1.fet_doc, out chk))
                {
                    chk++;
                    doc = "00000" + chk;
                    doc = doc.Substring(doc.Length - 5, 5);
                    year = cop1.year_curr;

                    sql = "Update " + cop.table + " Set " +
                    "" + cop.fet_doc + "=" + chk +
                    " Where " + cop.pkField + "='" + cop1.comp_id + "'";
                    conn.ExecuteNonQuery(conn.conn, sql);
                }
            }
            doc = cop1.prefix_fet_doc + year.Substring(year.Length - 2, 2) + doc;
            return doc;
        }
        public String updateAmountReserve(String amt)
        {
            String sql = "",re="";
            Company cop1 = new Company();
            cop1 = selectByCode1("001");
            sql = "Update " + cop.table + " Set " +
                " " + cop.amount_reserve + "="+cop.amount_reserve + "+" + amt +
            " Where " + cop.pkField + "='" + cop1.comp_id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return re;
        }
        private Company setCompany(DataTable dt)
        {
            Company cop1 = new Company();
            if (dt.Rows.Count > 0)
            {
                cop1.comp_id = dt.Rows[0][cop.comp_id].ToString();
                cop1.comp_code = dt.Rows[0][cop.comp_code].ToString();
                cop1.comp_name_t = dt.Rows[0][cop.comp_name_t].ToString();
                cop1.comp_name_e = dt.Rows[0][cop.comp_name_e].ToString();
                cop1.comp_address_e = dt.Rows[0][cop.comp_address_e].ToString();
                cop1.comp_address_t = dt.Rows[0][cop.comp_address_t].ToString();
                cop1.addr1 = dt.Rows[0][cop.addr1].ToString();
                cop1.addr2 = dt.Rows[0][cop.addr2].ToString();
                cop1.amphur_id = dt.Rows[0][cop.amphur_id].ToString();
                cop1.district_id = dt.Rows[0][cop.district_id].ToString();
                cop1.province_id = dt.Rows[0][cop.province_id].ToString();
                cop1.zipcode = dt.Rows[0][cop.zipcode].ToString();
                cop1.tele = dt.Rows[0][cop.tele].ToString();
                cop1.fax = dt.Rows[0][cop.fax].ToString();
                cop1.email = dt.Rows[0][cop.email].ToString();
                cop1.website = dt.Rows[0][cop.website].ToString();
                cop1.logo = dt.Rows[0][cop.logo].ToString();
                cop1.tax_id = dt.Rows[0][cop.tax_id].ToString();
                cop1.vat = dt.Rows[0][cop.vat].ToString();
                cop1.spec1 = dt.Rows[0][cop.spec1].ToString();
                cop1.date_create = dt.Rows[0][cop.date_create].ToString();
                cop1.date_modi = dt.Rows[0][cop.date_modi].ToString();
                cop1.date_cancel = dt.Rows[0][cop.date_cancel].ToString();
                cop1.user_create = dt.Rows[0][cop.user_create].ToString();
                cop1.user_modi = dt.Rows[0][cop.user_modi].ToString();
                cop1.user_cancel = dt.Rows[0][cop.user_cancel].ToString();
                cop1.qu_line1 = dt.Rows[0][cop.qu_line1].ToString();
                cop1.qu_line2 = dt.Rows[0][cop.qu_line2].ToString();
                cop1.qu_line3 = dt.Rows[0][cop.qu_line3].ToString();
                cop1.qu_line4 = dt.Rows[0][cop.qu_line4].ToString();
                cop1.qu_line5 = dt.Rows[0][cop.qu_line5].ToString();
                cop1.qu_line6 = dt.Rows[0][cop.qu_line6].ToString();
                cop1.inv_line1 = dt.Rows[0][cop.inv_line1].ToString();
                cop1.inv_line2 = dt.Rows[0][cop.inv_line2].ToString();
                cop1.inv_line3 = dt.Rows[0][cop.inv_line3].ToString();
                cop1.inv_line4 = dt.Rows[0][cop.inv_line4].ToString();
                cop1.inv_line5 = dt.Rows[0][cop.inv_line5].ToString();
                cop1.inv_line6 = dt.Rows[0][cop.inv_line6].ToString();
                cop1.po_line1 = dt.Rows[0][cop.po_line1].ToString();
                cop1.po_due_period = dt.Rows[0][cop.po_due_period].ToString();
                cop1.active = dt.Rows[0][cop.active].ToString();
                cop1.remark = dt.Rows[0][cop.remark].ToString();
                cop1.taddr1 = dt.Rows[0][cop.taddr1].ToString();
                cop1.taddr2 = dt.Rows[0][cop.taddr2].ToString();
                cop1.taddr3 = dt.Rows[0][cop.taddr3].ToString();
                cop1.taddr4 = dt.Rows[0][cop.taddr4].ToString();
                cop1.eaddr1 = dt.Rows[0][cop.eaddr1].ToString();
                cop1.eaddr2 = dt.Rows[0][cop.eaddr2].ToString();
                cop1.eaddr3 = dt.Rows[0][cop.eaddr3].ToString();
                cop1.eaddr4 = dt.Rows[0][cop.eaddr4].ToString();
                cop1.year_curr = dt.Rows[0][cop.year_curr].ToString();
                cop1.cash_draw_doc = dt.Rows[0][cop.cash_draw_doc].ToString();
                cop1.amount_reserve = dt.Rows[0][cop.amount_reserve].ToString();
                cop1.billing_doc = dt.Rows[0][cop.billing_doc].ToString();
                cop1.receipt_doc = dt.Rows[0][cop.receipt_doc].ToString();
                cop1.billing_cover_doc = dt.Rows[0][cop.billing_cover_doc].ToString();
                cop1.req_doc = dt.Rows[0][cop.req_doc].ToString();
                cop1.month_curr = dt.Rows[0][cop.month_curr].ToString();
                cop1.prefix_opu_doc = dt.Rows[0][cop.prefix_opu_doc].ToString();
                cop1.prefix_billing_doc = dt.Rows[0][cop.prefix_billing_doc].ToString();
                cop1.prefix_receipt_doc = dt.Rows[0][cop.prefix_receipt_doc].ToString();
                cop1.prefix_billing_cover_doc = dt.Rows[0][cop.prefix_billing_cover_doc].ToString();
                cop1.prefix_req_doc = dt.Rows[0][cop.prefix_req_doc].ToString();
                cop1.opu_doc = dt.Rows[0][cop.opu_doc].ToString();
                cop1.hn_doc = dt.Rows[0][cop.hn_doc].ToString();
                cop1.prefix_hn_doc = dt.Rows[0][cop.prefix_hn_doc].ToString();
                cop1.vn_doc = dt.Rows[0][cop.vn_doc].ToString();
                cop1.prefix_vn_doc = dt.Rows[0][cop.prefix_vn_doc].ToString();
                cop1.queue_doc = dt.Rows[0][cop.queue_doc].ToString();
                cop1.current_date = dt.Rows[0][cop.current_date].ToString();
                cop1.form_a_doc = dt.Rows[0][cop.form_a_doc].ToString();
                cop1.prefix_form_a_doc = dt.Rows[0][cop.prefix_form_a_doc].ToString();
                cop1.fet_doc = dt.Rows[0][cop.fet_doc].ToString();
                cop1.prefix_fet_doc = dt.Rows[0][cop.prefix_fet_doc].ToString();
                cop1.year = dt.Rows[0]["year"].ToString();
                cop1.month = dt.Rows[0]["month"].ToString();
                cop1.day = dt.Rows[0]["day"].ToString();
                cop1.day_curr = dt.Rows[0][cop.day_curr].ToString();
            }
            else
            {
                cop1.comp_id = "";
                cop1.comp_code = "";
                cop1.comp_name_t = "";
                cop1.comp_name_e = "";
                cop1.comp_address_e = "";
                cop1.comp_address_t = "";
                cop1.addr1 = "";
                cop1.addr2 = "";
                cop1.amphur_id = "";
                cop1.district_id = "";
                cop1.province_id = "";
                cop1.zipcode = "";
                cop1.tele = "";
                cop1.fax = "";
                cop1.email = "";
                cop1.website = "";
                cop1.logo = "";
                cop1.tax_id = "";
                cop1.vat = "";
                cop1.spec1 = "";
                cop1.date_create = "";
                cop1.date_modi = "";
                cop1.date_cancel = "";
                cop1.user_create = "";
                cop1.user_modi = "";
                cop1.user_cancel = "";
                cop1.qu_line1 = "";
                cop1.qu_line2 = "";
                cop1.qu_line3 = "";
                cop1.qu_line4 = "";
                cop1.qu_line5 = "";
                cop1.qu_line6 = "";
                cop1.inv_line1 = "";
                cop1.inv_line2 = "";
                cop1.inv_line3 = "";
                cop1.inv_line4 = "";
                cop1.inv_line5 = "";
                cop1.inv_line6 = "";
                cop1.po_line1 = "";
                cop1.po_due_period = "";
                cop1.active = "";
                cop1.remark = "";
                cop1.taddr1 = "";
                cop1.taddr2 = "";
                cop1.taddr3 = "";
                cop1.taddr4 = "";
                cop1.eaddr1 = "";
                cop1.eaddr2 = "";
                cop1.eaddr3 = "";
                cop1.eaddr4 = "";
                cop1.year_curr = "";
                cop1.cash_draw_doc = "";
                cop1.amount_reserve = "";
                cop1.billing_doc = "";
                cop1.receipt_doc = "";
                cop1.billing_cover_doc = "";
                cop1.req_doc = "";
                cop1.month_curr = "";
                cop1.prefix_opu_doc = "";
                cop1.prefix_billing_doc = "";
                cop1.prefix_receipt_doc = "";
                cop1.prefix_billing_cover_doc = "";
                cop1.prefix_req_doc = "";
                cop1.opu_doc = "";
                cop1.hn_doc = "";
                cop1.prefix_hn_doc = "";
                cop1.vn_doc = "";
                cop1.prefix_vn_doc = "";
                cop1.queue_doc = "";
                cop1.current_date = "";
                cop1.form_a_doc = "";
                cop1.prefix_form_a_doc = "";
                cop1.fet_doc = "";
                cop1.prefix_fet_doc = "";
                cop1.year = "";
                cop1.month = "";
                cop1.day = "";
                cop1.day_curr = "";
            }

            return cop1;
        }
    }
}

