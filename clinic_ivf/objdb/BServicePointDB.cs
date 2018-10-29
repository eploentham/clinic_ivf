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
    public class BServicePointDB
    {
        public BServicePoint bsp;
        ConnectDB conn;
        public List<BServicePoint> lBsp;
        public BServicePointDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            bsp = new BServicePoint();
            lBsp = new List<BServicePoint>();
            bsp.b_service_point_id = "b_service_point_id";
            bsp.service_point_number = "service_point_number";
            bsp.service_point_description = "service_point_description";
            bsp.f_service_group_id = "f_service_group_id";
            bsp.f_service_subgroup_id = "f_service_subgroup_id";
            bsp.active = "active";
            bsp.service_point_check = "service_point_check";
            bsp.service_point_operation_room = "service_point_operation_room";
            bsp.service_point_color = "service_point_color";
            bsp.alert_send_opdcard = "alert_send_opdcard";
            bsp.is_ipd = "is_ipd";

            bsp.table = "b_service_point";
            bsp.pkField = "b_service_point_id";
        }
        private void chkNull(BServicePoint p)
        {
            int chk = 0;            

            p.service_point_number = p.service_point_number == null ? "" : p.service_point_number;
            p.service_point_description = p.service_point_description == null ? "" : p.service_point_check;
            p.service_point_operation_room = p.service_point_operation_room == null ? "" : p.service_point_operation_room;
            p.alert_send_opdcard = p.alert_send_opdcard == null ? "" : p.alert_send_opdcard;
            p.service_point_color = p.service_point_color == null ? "" : p.service_point_color;
            p.active = p.active == null ? "" : p.active;
            p.is_ipd = p.is_ipd == null ? "" : p.is_ipd;

            p.f_service_subgroup_id = int.TryParse(p.f_service_subgroup_id, out chk) ? chk.ToString() : "0";
            p.f_service_group_id = int.TryParse(p.f_service_group_id, out chk) ? chk.ToString() : "0";
            //p.service_point_color = int.TryParse(p.service_point_color, out chk) ? chk.ToString() : "0";
            //p.service_point_color = int.TryParse(p.service_point_color, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bsp.* " +
                "From " + bsp.table + " bsp " +
                "Where bsp." + bsp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select bsp.*  " +
                "From " + bsp.table + " bsp " +
                " " +
                "Where bsp." + bsp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lBsp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                BServicePoint itm1 = new BServicePoint();
                itm1.b_service_point_id = row[bsp.b_service_point_id].ToString();
                itm1.service_point_number = row[bsp.service_point_number].ToString();
                itm1.service_point_description = row[bsp.service_point_description].ToString();
                itm1.f_service_group_id = row[bsp.f_service_group_id].ToString();
                itm1.f_service_subgroup_id = row[bsp.f_service_subgroup_id].ToString();
                itm1.active = row[bsp.active].ToString();
                itm1.service_point_check = row[bsp.service_point_check].ToString();
                itm1.service_point_operation_room = row[bsp.service_point_operation_room].ToString();
                itm1.service_point_color = row[bsp.service_point_color].ToString();
                itm1.alert_send_opdcard = row[bsp.alert_send_opdcard].ToString();
                //itm1.active = row[bsp.active].ToString();
                itm1.is_ipd = row[bsp.is_ipd].ToString();
                
                //itm1.is_ipd = row[bsp.is_ipd].ToString();
                lBsp.Add(itm1);
            }
        }
        public void setCboBsp(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            int i = 0;
            if (lBsp.Count <= 0) getlBsp();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (BServicePoint cus1 in lBsp)
            {
                item = new ComboBoxItem();
                item.Value = cus1.b_service_point_id;
                item.Text = cus1.service_point_description;
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
    }
}
