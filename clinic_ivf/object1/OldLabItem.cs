using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldLabItem:Persistent
    {
        public String LID { get; set; }
        public String LGID { get; set; }
        public String LName { get; set; }
        public String WorkTime { get; set; }
        public String Price { get; set; }
        public String SP1N { get; set; }
        public String SP1T { get; set; }
        public String SP2N { get; set; }
        public String SP2T { get; set; }
        public String SP3N { get; set; }
        public String SP3T { get; set; }
        public String SP4N { get; set; }
        public String SP4T { get; set; }
        public String SP5N { get; set; }
        public String SP5T { get; set; }
        public String SP6N { get; set; }
        public String SP6T { get; set; }
        public String SP7N { get; set; }
        public String SP7T { get; set; }
        public String SubItem { get; set; }
        public String WorkerGroup1 { get; set; }
        public String WorkerGroup2 { get; set; }
        public String WorkerGroup3 { get; set; }
        public String WorkerGroup4 { get; set; }
        public String QTY { get; set; }
        public String status_show_qty { get; set; }
        public String status_order_group { get; set; }
        public String method { get; set; }
        public String unit { get; set; }
        public String normal_vaule { get; set; }
        public String status_outlab { get; set; }
        public String num_barcode { get; set; }
        public String lab_unit_id { get; set; }
        public String method_id { get; set; }
        public String status_datatype_result { get; set; }
        public String datatype_decimal { get; set; }
        public String status_interpret { get; set; }
        public String remark { get; set; }
    }
}
