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
    public class AddressDB
    {
        public Address addr;
        ConnectDB conn;

        public List<Address> lAddr;
        public DataTable dtAddr;

        public AddressDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            addr = new Address();
            addr.address_id = "address_id";
            addr.address_name = "address_name";
            addr.address_code = "address_code";
            addr.line_t1 = "line_t1";
            addr.line_t2 = "line_t2";
            addr.line_t3 = "line_t3";
            addr.line_t4 = "line_t4";
            addr.line_e1 = "line_e1";
            addr.line_e2 = "line_e2";
            addr.line_e3 = "line_e3";
            addr.line_e4 = "line_e4";
            addr.prov_id = "prov_id";
            addr.amphur_id = "amphur_id";
            addr.district_id = "district_id";
            addr.zipcode = "zipcode";
            addr.email = "email";
            addr.email2 = "email2";
            addr.tele = "tele";
            addr.mobile = "mobile";
            addr.fax = "fax";
            addr.remark = "remark";
            addr.address_type_id = "address_type_id";
            addr.table_id = "table_id";
            addr.date_create = "date_create";
            addr.date_modi = "date_modi";
            addr.date_cancel = "date_cancel";
            addr.user_create = "user_create";
            addr.user_modi = "user_modi";
            addr.user_cancel = "user_cancel";
            addr.active = "active";

            addr.contact_id = "contact_id";
            addr.contact_name1 = "contact_name1";
            addr.contact_name2 = "contact_name2";
            addr.contact_name_tel1 = "contact_name_tel1";
            addr.contact_name_tel2 = "contact_name_tel2";

            addr.web_site1 = "web_site1";
            addr.web_site2 = "web_site2";
            addr.google_map = "google_map";
            addr.status_defalut_customer = "status_default_customer";
            addr.remark2 = "remark2";
            addr.time_open_close = "time_open_close";
            addr.time_open_close_over_time = "time_open_close_over_time";
            addr.contact_id2 = "contact_id2";
            addr.web_site3 = "web_site3";
            addr.over_time = "over_time";
            addr.rate_over_time = "rate_over_time";
            addr.map_pic_path = "map_pic_path";
            addr.status_container_yard = "status_container_yard";
            addr.status_place_addr = "status_place_addr";
            addr.status_tax = "status_tax";

            addr.table = "b_address";
            addr.pkField = "address_id";
        }
        public void getlAddr()
        {
            //lDept = new List<Department>();

            lAddr.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            dtAddr = dt;
            foreach (DataRow row in dt.Rows)
            {
                Address addr1 = new Address();
                addr1.address_id = row[addr.address_id].ToString();
                addr1.address_code = row[addr.address_code].ToString();
                addr1.line_t1 = row[addr.line_t1].ToString();
                addr1.line_e1 = row[addr.line_e1].ToString();
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lAddr.Add(addr1);
            }
        }
        public void setCboCus(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            foreach (Address cus1 in lAddr)
            {
                item = new ComboBoxItem();
                item.Value = cus1.address_id;
                item.Text = cus1.line_t1;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    c.SelectedItem = item;
                }
            }
        }
        public String getCodeById(String code)
        {
            String id = "";
            foreach (Address cus1 in lAddr)
            {
                if (code.Trim().Equals(cus1.address_code.Trim()))
                {
                    id = cus1.address_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Address cus1 in lAddr)
            {
                if (code.Trim().Equals(cus1.address_code.Trim()))
                {
                    id = cus1.address_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Address cus1 in lAddr)
            {
                if (name.Trim().Equals(cus1.line_t1.Trim()))
                {
                    id = cus1.address_id;
                    break;
                }
            }
            return id;
        }
        public String getNameTById(String id)
        {
            String ret = "";
            foreach (Address cus1 in lAddr)
            {
                if (id.Trim().Equals(cus1.address_id.Trim()))
                {
                    ret = cus1.line_t1;
                    break;
                }
            }
            return ret;
        }
        private void chkNull(Address p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.line_e4 = p.line_e4 == null ? "" : p.line_e4;
            p.line_e3 = p.line_e3 == null ? "" : p.line_e3;
            p.line_e2 = p.line_e2 == null ? "" : p.line_e2;
            p.line_e1 = p.line_e1 == null ? "" : p.line_e1;
            p.line_t1 = p.line_t1 == null ? "" : p.line_t1;
            p.line_t2 = p.line_t2 == null ? "" : p.line_t2;
            p.line_t3 = p.line_t3 == null ? "" : p.line_t3;
            p.line_t4 = p.line_t4 == null ? "" : p.line_t4;
            p.address_name = p.address_name == null ? "" : p.address_name;

            p.contact_id = p.contact_id == null ? "" : p.contact_id;
            p.contact_name1 = p.contact_name1 == null ? "" : p.contact_name1;
            p.contact_name2 = p.contact_name2 == null ? "" : p.contact_name2;
            p.contact_name_tel1 = p.contact_name_tel1 == null ? "" : p.contact_name_tel1;
            p.contact_name_tel2 = p.contact_name_tel2 == null ? "" : p.contact_name_tel2;

            p.zipcode = p.zipcode == null ? "" : p.zipcode;
            p.email = p.email == null ? "" : p.email;
            p.email2 = p.email2 == null ? "" : p.email2;
            p.tele = p.tele == null ? "" : p.tele;
            p.mobile = p.mobile == null ? "" : p.mobile;
            p.fax = p.fax == null ? "" : p.fax;
            p.remark = p.remark == null ? "" : p.remark;
            p.address_type_id = p.address_type_id == null ? "" : p.address_type_id;
            p.google_map = p.google_map == null ? "" : p.google_map;
            p.web_site1 = p.web_site1 == null ? "" : p.web_site1;
            p.web_site2 = p.web_site2 == null ? "" : p.web_site2;
            p.status_defalut_customer = p.status_defalut_customer == null ? "" : p.status_defalut_customer;
            p.remark2 = p.remark2 == null ? "" : p.remark2;
            p.time_open_close = p.time_open_close == null ? "" : p.time_open_close;
            p.time_open_close_over_time = p.time_open_close_over_time == null ? "" : p.time_open_close_over_time;
            p.web_site3 = p.web_site3 == null ? "" : p.web_site3;
            p.over_time = p.over_time == null ? "" : p.over_time;
            p.rate_over_time = p.rate_over_time == null ? "" : p.rate_over_time;
            p.map_pic_path = p.map_pic_path == null ? "" : p.map_pic_path;
            p.status_place_addr = p.status_place_addr == null ? "0" : p.status_place_addr;
            p.status_container_yard = p.status_container_yard == null ? "0" : p.status_container_yard;
            p.status_tax = p.status_tax == null ? "0" : p.status_tax;

            p.amphur_id = int.TryParse(p.amphur_id, out chk) ? chk.ToString() : "0";
            p.district_id = int.TryParse(p.district_id, out chk) ? chk.ToString() : "0";
            p.prov_id = int.TryParse(p.prov_id, out chk) ? chk.ToString() : "0";
            p.table_id = int.TryParse(p.table_id, out chk) ? chk.ToString() : "0";
            p.amphur_id = int.TryParse(p.amphur_id, out chk) ? chk.ToString() : "0";
            p.contact_id2 = int.TryParse(p.contact_id2, out chk) ? chk.ToString() : "0";

        }
        public String insert(Address p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + addr.table + "(" + addr.address_code + "," + addr.line_t1 + "," + addr.line_t2 + "," +
                addr.line_t3 + "," + addr.line_t4 + "," + addr.line_e1 + "," +
                addr.line_e2 + "," + addr.line_e3 + "," + addr.line_e4 + "," +
                addr.prov_id + "," + addr.amphur_id + "," + addr.district_id + "," +
                addr.zipcode + "," + addr.email + "," + addr.email2 + "," +
                addr.tele + "," + addr.mobile + "," + addr.fax + "," +
                addr.remark + "," + addr.address_type_id + "," + addr.table_id + "," +
                addr.date_create + "," + addr.date_modi + ", " + addr.date_cancel + ", " +
                addr.user_create + "," + addr.user_modi + ", " + addr.user_cancel + ", " +
                addr.active + ", " + addr.address_name + ", " + addr.contact_id + ", " +
                addr.contact_name1 + ", " + addr.contact_name2 + ", " + addr.contact_name_tel1 + ", " +
                addr.contact_name_tel2 + "," + addr.web_site1 + "," + addr.web_site2 + "," +
                addr.google_map + "," + addr.status_defalut_customer + ", " + addr.remark2 + ", " +
                addr.time_open_close + "," + addr.time_open_close_over_time + ", " + addr.contact_id2 + ", " +
                addr.web_site3 + "," + addr.over_time + ", " + addr.rate_over_time + ", " +
                addr.map_pic_path + ", " + addr.status_container_yard + ", " + addr.status_place_addr + "," +
                addr.status_tax + ", " +
                ") " +
                "Values ('" + p.address_code + "','" + p.line_t1.Replace("'", "''") + "','" + p.line_t2.Replace("'", "''") + "'," +
                "'" + p.line_t3 + "','" + p.line_t4.Replace("'", "''") + "','" + p.line_e1.Replace("'", "''") + "'," +
                "'" + p.line_e2.Replace("'", "''") + "','" + p.line_e3.Replace("'", "''") + "','" + p.line_e4.Replace("'", "''") + "'," +
                "'" + p.prov_id + "','" + p.amphur_id + "','" + p.district_id + "'," +
                "'" + p.zipcode.Replace("'", "''") + "','" + p.email + "','" + p.email2 + "'," +
                "'" + p.tele + "','" + p.mobile + "','" + p.fax.Replace("'", "''") + "'," +
                "'" + p.remark.Replace("'", "''") + "','" + p.address_type_id.Replace("'", "''") + "','" + p.table_id + "', " +
                "'" + p.date_create + "','" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + p.user_create + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.address_name.Replace("'", "''") + "', '" + p.contact_id.Replace("'", "''") + "', " +
                "'" + p.contact_name1 + "','" + p.contact_name2.Replace("'", "''") + "', '" + p.contact_name_tel1.Replace("'", "''") + "', " +
                "'" + p.contact_name_tel2 + "','" + p.web_site1.Replace("'", "''") + "','" + p.web_site2.Replace("'", "''") + "'," +
                "'" + p.google_map + "','" + p.status_defalut_customer + "','" + p.remark2.Replace("'", "''") + "', " +
                "'" + p.time_open_close + "','" + p.time_open_close_over_time + "','" + p.contact_id2.Replace("'", "''") + "'," +
                "'" + p.web_site3 + "','" + p.over_time + "','" + p.rate_over_time.Replace("'", "''") + "'," +
                "'" + p.map_pic_path + "','" + p.status_container_yard + "','" + p.status_place_addr + "'," +
                "'" + p.status_tax + "' " +
                ")";
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
        public String update(Address p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + addr.table + " Set " +
                " " + addr.address_code + " = '" + p.address_code + "'" +
                "," + addr.line_t1 + " = '" + p.line_t1.Replace("'", "''") + "'" +
                "," + addr.line_t2 + " = '" + p.line_t2.Replace("'", "''") + "'" +
                "," + addr.line_t3 + " = '" + p.line_t3.Replace("'", "''") + "'" +
                "," + addr.line_t4 + " = '" + p.line_t4.Replace("'", "''") + "'" +
                "," + addr.line_e1 + " = '" + p.line_e1.Replace("'", "''") + "'" +
                "," + addr.line_e2 + " = '" + p.line_e2.Replace("'", "''") + "'" +
                "," + addr.line_e3 + " = '" + p.line_e3.Replace("'", "''") + "'" +
                "," + addr.line_e4 + " = '" + p.line_e4.Replace("'", "''") + "'" +
                "," + addr.prov_id + " = '" + p.prov_id + "'" +
                "," + addr.amphur_id + " = '" + p.amphur_id + "'" +
                "," + addr.district_id + " = '" + p.district_id + "'" +
                "," + addr.zipcode + " = '" + p.zipcode + "'" +
                "," + addr.email + " = '" + p.email + "'" +
                "," + addr.email2 + " = '" + p.email2 + "'" +
                "," + addr.tele + " = '" + p.tele.Replace("'", "''") + "'" +
                "," + addr.date_modi + " = now()" +
                "," + addr.mobile + " = '" + p.mobile + "'" +
                "," + addr.fax + " = '" + p.fax + "' " +
                "," + addr.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + addr.address_type_id + " = '" + p.address_type_id + "' " +
                "," + addr.table_id + " = '" + p.table_id + "' " +
                "," + addr.address_name + " = '" + p.address_name.Replace("'", "''") + "' " +
                "," + addr.contact_id + " = '" + p.contact_id + "' " +
                "," + addr.contact_name1 + " = '" + p.contact_name1.Replace("'", "''") + "' " +
                "," + addr.contact_name2 + " = '" + p.contact_name2.Replace("'", "''") + "' " +
                "," + addr.contact_name_tel1 + " = '" + p.contact_name_tel1.Replace("'", "''") + "' " +
                "," + addr.contact_name_tel2 + " = '" + p.contact_name_tel2.Replace("'", "''") + "' " +
                "," + addr.web_site1 + " = '" + p.web_site1.Replace("'", "''") + "' " +
                "," + addr.web_site2 + " = '" + p.web_site2.Replace("'", "''") + "' " +
                "," + addr.google_map + " = '" + p.google_map.Replace("'", "''") + "' " +
                "," + addr.status_defalut_customer + " = '" + p.status_defalut_customer.Replace("'", "''") + "' " +
                "," + addr.remark2 + " = '" + p.remark2.Replace("'", "''") + "' " +
                "," + addr.time_open_close + " = '" + p.time_open_close.Replace("'", "''") + "' " +
                "," + addr.time_open_close_over_time + " = '" + p.time_open_close_over_time.Replace("'", "''") + "' " +
                "," + addr.contact_id2 + " = '" + p.contact_id2 + "' " +
                "," + addr.web_site3 + " = '" + p.web_site3 + "' " +
                "," + addr.over_time + " = '" + p.over_time + "' " +
                "," + addr.rate_over_time + " = '" + p.rate_over_time + "' " +
                "," + addr.map_pic_path + " = '" + p.map_pic_path + "' " +
                "," + addr.status_place_addr + " = '" + p.status_place_addr + "' " +
                "," + addr.status_container_yard + " = '" + p.status_container_yard + "' " +
                "," + addr.status_tax + " = '" + p.status_tax + "' " +
                "Where " + addr.pkField + "='" + p.address_id + "'";

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
        public String insertAddress(Address p)
        {
            String re = "";

            if (p.address_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }

            return re;
        }
        public String updateContact1(String address_id, String contact_id, String contact_name, String contact_name_tel)
        {
            String re = "";
            String sql = "";
            sql = "Update " + addr.table + " Set " +
                " " + addr.contact_id + " = '" + contact_id + "' " +
                "," + addr.contact_name1 + " = '" + contact_name.Replace("'", "''") + "' " +
                "," + addr.contact_name_tel1 + " = '" + contact_name_tel.Replace("'", "''") + "' " +

                "Where " + addr.pkField + "='" + address_id + "'";
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
        public String updateContact2(String address_id, String contact_id, String contact_name, String contact_name_tel)
        {
            String re = "";
            String sql = "";
            sql = "Update " + addr.table + " Set " +
                " " + addr.contact_id2 + " = '" + contact_id + "' " +
                "," + addr.contact_name2 + " = '" + contact_name.Replace("'", "''") + "' " +
                "," + addr.contact_name_tel2 + " = '" + contact_name_tel.Replace("'", "''") + "' " +

                "Where " + addr.pkField + "='" + address_id + "'";
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
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + addr.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidAddress(String addrId, String userId)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + addr.table + " Set " +
                "" + addr.active + "='3' " +
                "," + addr.date_cancel + "=now() " +
                "," + addr.user_cancel + " ='" + userId + "' " +
                "Where " + addr.pkField + "='" + addrId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + addr.table + " cop " +
                " " +
                "Where cop." + addr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select addr.* " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where LOWER(addr." + addr.address_code + ") like '" + copId.ToLower() + "%' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select addr.* " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where addr." + addr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByTableId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select addr.* " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where addr." + addr.table_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByTableId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select addr.address_id, addr.address_name, addr.line_t1, addr.line_t2, addr.line_t3, addr.line_t4, addr.email, addr.email2, addr.tele, addr.mobile, addr.remark, addr.remark2 " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where addr." + addr.table_id + " ='" + copId + "' and addr." + addr.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Address selectStatusTaxByCusId1(String copId)
        {
            Address cop1 = new Address();
            DataTable dt = new DataTable();
            String sql = "select addr.address_id, addr.address_name, addr.line_t1, addr.line_t2, addr.line_t3, addr.line_t4, addr.email, addr.email2, addr.tele" +
                ", addr.mobile, addr.remark, addr.remark2 " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where addr." + addr.table_id + " ='" + copId + "' and addr." + addr.active + "='1' and " + addr.status_tax + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            //cop1 = setAddress(dt);
            if (dt.Rows.Count > 0)
            {
                cop1.address_id = dt.Rows[0][addr.address_id].ToString();

                cop1.line_t1 = dt.Rows[0][addr.line_t1].ToString();
                cop1.line_t2 = dt.Rows[0][addr.line_t2].ToString();
                cop1.line_t3 = dt.Rows[0][addr.line_t3].ToString();

                cop1.line_t4 = dt.Rows[0][addr.line_t4].ToString();
                cop1.line_e1 = dt.Rows[0][addr.address_name].ToString();

                cop1.email = dt.Rows[0][addr.email].ToString();

                cop1.email2 = dt.Rows[0][addr.email2].ToString();
                cop1.tele = dt.Rows[0][addr.tele].ToString();
                cop1.mobile = dt.Rows[0][addr.mobile].ToString();

                cop1.remark = dt.Rows[0][addr.remark].ToString();

            }
            return cop1;
        }
        public Address selectByPk1(String copId)
        {
            Address cop1 = new Address();
            DataTable dt = new DataTable();
            String sql = "select addr.* " +
                "From " + addr.table + " addr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where addr." + addr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAddress(dt);
            return cop1;
        }
        public Address setAddress(DataTable dt)
        {
            Address addr1 = new Address();
            addr1.status_defalut_customer = "0";
            if (dt.Rows.Count > 0)
            {
                //stf1.staff_id = dt.Rows[0][addr.staff_id].ToString();
                addr1.address_id = dt.Rows[0][addr.address_id].ToString();
                addr1.address_code = dt.Rows[0][addr.address_code].ToString();
                addr1.line_t1 = dt.Rows[0][addr.line_t1].ToString();
                addr1.line_t2 = dt.Rows[0][addr.line_t2].ToString();
                addr1.line_t3 = dt.Rows[0][addr.line_t3].ToString();

                addr1.line_t4 = dt.Rows[0][addr.line_t4].ToString();
                addr1.line_e1 = dt.Rows[0][addr.line_e1].ToString();
                addr1.line_e2 = dt.Rows[0][addr.line_e2].ToString();
                addr1.line_e3 = dt.Rows[0][addr.line_e3].ToString();
                addr1.line_e4 = dt.Rows[0][addr.line_e4].ToString();

                addr1.prov_id = dt.Rows[0][addr.prov_id].ToString();
                addr1.amphur_id = dt.Rows[0][addr.amphur_id].ToString();
                addr1.district_id = dt.Rows[0][addr.district_id].ToString();
                addr1.zipcode = dt.Rows[0][addr.zipcode].ToString();
                addr1.email = dt.Rows[0][addr.email].ToString();

                addr1.email2 = dt.Rows[0][addr.email2].ToString();
                addr1.tele = dt.Rows[0][addr.tele].ToString();
                addr1.mobile = dt.Rows[0][addr.mobile].ToString();
                addr1.fax = dt.Rows[0][addr.fax].ToString();
                addr1.remark = dt.Rows[0][addr.remark].ToString();

                addr1.address_type_id = dt.Rows[0][addr.address_type_id].ToString();
                addr1.table_id = dt.Rows[0][addr.table_id].ToString();

                addr1.date_create = dt.Rows[0][addr.date_create].ToString();
                addr1.date_modi = dt.Rows[0][addr.date_modi].ToString();
                addr1.date_cancel = dt.Rows[0][addr.date_cancel].ToString();
                addr1.user_create = dt.Rows[0][addr.user_create].ToString();
                addr1.user_modi = dt.Rows[0][addr.user_modi].ToString();

                addr1.user_cancel = dt.Rows[0][addr.user_cancel].ToString();
                addr1.address_name = dt.Rows[0][addr.address_name].ToString();

                addr1.active = dt.Rows[0][addr.active].ToString();

                addr1.contact_id = dt.Rows[0][addr.contact_id].ToString();
                addr1.contact_name1 = dt.Rows[0][addr.contact_name1].ToString();
                addr1.contact_name2 = dt.Rows[0][addr.contact_name2].ToString();
                addr1.contact_name_tel1 = dt.Rows[0][addr.contact_name_tel1].ToString();
                addr1.contact_name_tel2 = dt.Rows[0][addr.contact_name_tel2].ToString();

                addr1.web_site1 = dt.Rows[0][addr.web_site1].ToString();
                addr1.web_site2 = dt.Rows[0][addr.web_site2].ToString();
                addr1.google_map = dt.Rows[0][addr.google_map].ToString();
                addr1.status_defalut_customer = dt.Rows[0][addr.status_defalut_customer].ToString();
                addr1.remark2 = dt.Rows[0][addr.remark2].ToString();
                addr1.time_open_close = dt.Rows[0][addr.time_open_close].ToString();
                addr1.time_open_close_over_time = dt.Rows[0][addr.time_open_close_over_time].ToString();
                addr1.contact_id2 = dt.Rows[0][addr.contact_id2].ToString();

                addr1.web_site3 = dt.Rows[0][addr.web_site3].ToString();
                addr1.over_time = dt.Rows[0][addr.over_time].ToString();
                addr1.rate_over_time = dt.Rows[0][addr.rate_over_time].ToString();
                addr1.map_pic_path = dt.Rows[0][addr.map_pic_path].ToString();
                addr1.status_container_yard = dt.Rows[0][addr.status_container_yard].ToString();
                addr1.status_place_addr = dt.Rows[0][addr.status_place_addr].ToString();
                addr1.status_tax = dt.Rows[0][addr.status_tax].ToString();
            }

            return addr1;
        }
    }
}
