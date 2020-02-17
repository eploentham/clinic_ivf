using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldStockDrug:Persistent
    {
        public String DUID { get; set; }
        public String DUName { get; set; }
        public String EUsage { get; set; }
        public String TUsage { get; set; }
        public String UnitType { get; set; }
        public String Alert { get; set; }
        public String QTY { get; set; }
        public String PendingQTY { get; set; }
        public String Price { get; set; }
        public String drug_caution { get; set; }
        public String drug_description { get; set; }
        public String instruction_id { get; set; }
        public String frequency_id { get; set; }
        public String drug_caution_e { get; set; }
        public String drug_frequency_e { get; set; }
        public String item_sub_group_id { get; set; }
        public String on_hand { get; set; }
        public String order_point { get; set; }
        public String order_amount { get; set; }
        public String on_hand_sub_1 { get; set; }
        public String order_point_sub_1 { get; set; }
        public String order_amount_sub_1 { get; set; }
        public String on_hand_sub_2 { get; set; }
        public String order_point_sub_2 { get; set; }
        public String order_amount_sub_2 { get; set; }
        public String on_hand_sub_3 { get; set; }
        public String order_point_sub_3 { get; set; }
        public String order_amount_sub_3 { get; set; }
        public String item_code { get; set; }
    }
}
