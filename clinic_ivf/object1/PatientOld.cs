using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PatientOld
    {
        public String Address { get; set; }
        public String Age { get; set; }
        public String AgentID { get; set; }
        public String Allergy { get; set; }
        public String BuildingVillage { get; set; }
        public String CompanyName { get; set; }
        public String CompanyPhoneNo { get; set; }
        public String ContractName { get; set; }
        public String DateOfBirth { get; set; }
        public String District { get; set; }
        public String Email { get; set; }
        public String EmergencyPersonAddress { get; set; }
        public String EmergencyPersonalContact { get; set; }
        public String EPAddress { get; set; }
        public String EPDistrict { get; set; }
        public String EPEmail { get; set; }
        public String EPHomePhoneNo { get; set; }
        public String EPMobilePhoneNo { get; set; }
        public String EPProvince { get; set; }
        public String EPRoad { get; set; }
        public String EPSubDistrict { get; set; }
        public String EPZipcode { get; set; }
        public String HomePhoneNo { get; set; }
        public String IDNumber { get; set; }
        public String IDType { get; set; }
        public String InsuranceName { get; set; }
        public String MaritalID { get; set; }
        public String MobilePhoneNo { get; set; }
        public String Moo { get; set; }
        public String Nationality { get; set; }
        public String Occupation { get; set; }
        public String OName { get; set; }
        public String OSurname { get; set; }
        public String PatientTypeID { get; set; }
        public String PaymentID { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String PName { get; set; }
        public String Province { get; set; }
        public String PSurname { get; set; }
        public String Race { get; set; }
        public String RelationshipID { get; set; }
        public String RelationshipOther { get; set; }
        public String Religion { get; set; }
        public String Road { get; set; }
        public String SexID { get; set; }
        public String Soi { get; set; }
        public String SubDistrict { get; set; }
        public String SurfixID { get; set; }
        public String ZipCode { get; set; }

        public String table { get; set; }
        public String pkField { get; set; }

        public Age age = new Age(DateTime.Now);
        public String AgeString()
        {
            String re = "";
            DateTime dtB;
            if (DateTime.TryParse(DateOfBirth, out dtB))
            {
                age = new Age(dtB);
                re = age.AgeString;
            }
            return re;
        }
        public String AgeStringShort()
        {
            String re = "";
            DateTime dtB;
            if (DateTime.TryParse(DateOfBirth, out dtB))
            {
                age = new Age(dtB);
                //re = age.AgeString.Replace("Years", "Y").Replace("Year", "Y").Replace("Months", "M").Replace("Month", "M").Replace("Days", "D").Replace("Day", "D");
                re = age.Years + "." + age.Months + "." + age.Days;
            }
            return re;
        }
    }
}
