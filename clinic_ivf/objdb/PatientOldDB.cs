using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class PatientOldDB
    {
        public PatientOld pttO;
        ConnectDB conn;
        FSexDB sexDB;
        FPrefixDB fpfDB;
        FMarriageStatusDB fmsDB;
        FNationDB fpnDB;
        FRelationDB frlDB;
        FRaceDB fracDB;
        FReligionDB frgDB;
        public PatientOldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pttO = new PatientOld();
            pttO.Address = "Address";
            pttO.Age = "Age";
            pttO.AgentID = "AgentID";
            pttO.Allergy = "Allergy";
            pttO.BuildingVillage = "BuildingVillage";
            pttO.CompanyName = "CompanyName";
            pttO.CompanyPhoneNo = "CompanyPhoneNo";
            pttO.ContractName = "ContractName";
            pttO.DateOfBirth = "DateOfBirth";
            pttO.District = "District";
            pttO.Email = "Email";
            pttO.EmergencyPersonAddress = "EmergencyPersonAddress";
            pttO.EmergencyPersonalContact = "EmergencyPersonalContact";
            pttO.EPAddress = "EPAddress";
            pttO.EPDistrict = "EPDistrict";
            pttO.EPEmail = "EPEmail";
            pttO.EPHomePhoneNo = "EPHomePhoneNo";
            pttO.EPMobilePhoneNo = "EPMobilePhoneNo";
            pttO.EPProvince = "EPProvince";
            pttO.EPRoad = "EPRoad";
            pttO.EPSubDistrict = "EPSubDistrict";
            pttO.EPZipcode = "EPZipcode";
            pttO.HomePhoneNo = "HomePhoneNo";
            pttO.IDNumber = "IDNumber";
            pttO.IDType = "IDType";
            pttO.InsuranceName = "InsuranceName";
            pttO.MaritalID = "MaritalID";
            pttO.MobilePhoneNo = "MobilePhoneNo";
            pttO.Moo = "Moo";
            pttO.Nationality = "Nationality";
            pttO.Occupation = "Occupation";
            pttO.OName = "OName";
            pttO.OSurname = "OSurname";
            pttO.PatientTypeID = "PatientTypeID";
            pttO.PaymentID = "PaymentID";
            pttO.PID = "PID";
            pttO.PIDS = "PIDS";
            pttO.PName = "PName";
            pttO.Province = "Province";
            pttO.PSurname = "PSurname";
            pttO.Race = "Race";
            pttO.RelationshipID = "RelationshipID";
            pttO.RelationshipOther = "RelationshipOther";
            pttO.Religion = "Religion";
            pttO.Road = "Road";
            pttO.SexID = "SexID";
            pttO.Soi = "Soi";
            pttO.SubDistrict = "SubDistrict";
            pttO.SurfixID = "SurfixID";
            pttO.ZipCode = "ZipCode";

            pttO.table = "Patient";
            pttO.pkField = "PID";

            sexDB = new FSexDB(conn);
            fpfDB = new FPrefixDB(conn);
            fmsDB = new FMarriageStatusDB(conn);
            fpnDB = new FNationDB(conn);
            frlDB = new FRelationDB(conn);
            fracDB = new FRaceDB(conn);
            frgDB = new FReligionDB(conn);
        }
        private void chkNull(PatientOld p)
        {
            int chk = 0;

            p.Address = p.Address == null ? "" : p.Address;
            p.Age = p.Age == null ? "" : p.Age;
            p.Allergy = p.Allergy == null ? "" : p.Allergy;
            p.BuildingVillage = p.BuildingVillage == null ? "" : p.BuildingVillage;
            p.CompanyName = p.CompanyName == null ? "" : p.CompanyName;

            p.CompanyPhoneNo = p.CompanyPhoneNo == null ? "" : p.CompanyPhoneNo;
            p.ContractName = p.ContractName == null ? "" : p.ContractName;
            p.DateOfBirth = p.DateOfBirth == null ? "" : p.DateOfBirth;
            p.District = p.District == null ? "" : p.District;
            p.Email = p.Email == null ? "" : p.Email;
            p.EmergencyPersonAddress = p.EmergencyPersonAddress == null ? "" : p.EmergencyPersonAddress;
            p.EmergencyPersonalContact = p.EmergencyPersonalContact == null ? "" : p.EmergencyPersonalContact;
            p.EPAddress = p.EPAddress == null ? "" : p.EPAddress;
            p.EPDistrict = p.EPDistrict == null ? "" : p.EPDistrict;
            p.EPEmail = p.EPEmail == null ? "" : p.EPEmail;
            p.EPHomePhoneNo = p.EPHomePhoneNo == null ? "" : p.EPHomePhoneNo;
            p.EPMobilePhoneNo = p.EPMobilePhoneNo == null ? "" : p.EPMobilePhoneNo;
            p.EPProvince = p.EPProvince == null ? "" : p.EPProvince;
            p.EPRoad = p.EPRoad == null ? "" : p.EPRoad;
            p.EPSubDistrict = p.EPSubDistrict == null ? "" : p.EPSubDistrict;
            p.EPZipcode = p.EPZipcode == null ? "" : p.EPZipcode;
            p.HomePhoneNo = p.HomePhoneNo == null ? "" : p.HomePhoneNo;
            p.IDNumber = p.IDNumber == null ? "" : p.IDNumber;
            p.IDType = p.IDType == null ? "" : p.IDType;
            p.InsuranceName = p.InsuranceName == null ? "" : p.InsuranceName;
            p.MobilePhoneNo = p.MobilePhoneNo == null ? "" : p.MobilePhoneNo;
            p.Moo = p.Moo == null ? "" : p.Moo;
            p.Nationality = p.Nationality == null ? "" : p.Nationality;
            p.Occupation = p.Occupation == null ? "" : p.Occupation;
            p.OName = p.OName == null ? "" : p.OName;
            p.OSurname = p.OSurname == null ? "" : p.OSurname;
            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.PName = p.PName == null ? "" : p.PName;
            p.Province = p.Province == null ? "" : p.Province;
            p.PSurname = p.PSurname == null ? "" : p.PSurname;
            p.Race = p.Race == null ? "" : p.Race;
            p.RelationshipOther = p.RelationshipOther == null ? "" : p.RelationshipOther;
            p.Religion = p.Religion == null ? "" : p.Religion;
            p.Road = p.Road == null ? "" : p.Road;
            p.Soi = p.Soi == null ? "" : p.Soi;
            p.SubDistrict = p.SubDistrict == null ? "" : p.SubDistrict;
            p.ZipCode = p.ZipCode == null ? "" : p.ZipCode;
            //p.remark = p.remark == null ? "" : p.remark;

            //p.PID = int.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.SurfixID = int.TryParse(p.SurfixID, out chk) ? chk.ToString() : "0";
            p.SexID = int.TryParse(p.SexID, out chk) ? chk.ToString() : "0";
            p.MaritalID = int.TryParse(p.MaritalID, out chk) ? chk.ToString() : "0";
            p.RelationshipID = int.TryParse(p.RelationshipID, out chk) ? chk.ToString() : "0";
            p.EmergencyPersonAddress = int.TryParse(p.EmergencyPersonAddress, out chk) ? chk.ToString() : "0";
            p.PaymentID = int.TryParse(p.PaymentID, out chk) ? chk.ToString() : "0";
            p.AgentID = int.TryParse(p.AgentID, out chk) ? chk.ToString() : "0";
            p.PatientTypeID = int.TryParse(p.PatientTypeID, out chk) ? chk.ToString() : "0";
            p.IDType = int.TryParse(p.IDType, out chk) ? chk.ToString() : "0";

            p.DateOfBirth = p.DateOfBirth.Equals("") ? null : p.DateOfBirth;
            //p.IDType = p.IDType.Equals("") ? null : p.IDType;
        }
        public String insert(PatientOld p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            try
            {
                sql = "Insert Into " + pttO.table + "(" + pttO.Address + "," + pttO.Age + "," + pttO.AgentID + "," +
                pttO.Allergy + "," + pttO.BuildingVillage + "," + pttO.CompanyName + "," +
                pttO.CompanyPhoneNo + "," + pttO.ContractName + "," + pttO.DateOfBirth + "," +
                pttO.District + "," + pttO.Email + "," + pttO.EmergencyPersonAddress + "," +
                pttO.EmergencyPersonalContact + "," + pttO.EPAddress + "," + pttO.EPDistrict + "," +
                
                pttO.EPEmail + "," + pttO.EPHomePhoneNo + "," + pttO.EPMobilePhoneNo + "," +
                pttO.EPProvince + "," + pttO.EPRoad + "," + pttO.EPSubDistrict + "," +
                pttO.EPZipcode + "," + pttO.HomePhoneNo + "," + pttO.IDNumber + "," +
                pttO.IDType + "," + pttO.InsuranceName + "," + pttO.MaritalID + "," +
                pttO.MobilePhoneNo + "," + pttO.Moo + "," + pttO.Nationality + "," +
                pttO.Occupation + "," + pttO.OName + "," + pttO.OSurname + "," +
                pttO.PatientTypeID + "," + pttO.PaymentID + "," + pttO.PIDS + "," +

                pttO.PName + "," + pttO.Province + "," + pttO.PSurname + "," +
                pttO.Race + "," + pttO.RelationshipID + "," + pttO.RelationshipOther + "," +
                pttO.Religion + "," + pttO.Road + "," + pttO.SexID + "," +
                pttO.Soi + "," + pttO.SubDistrict + "," + pttO.SurfixID + "," +
                pttO.ZipCode + "," + pttO.PID + " " +

                ") " +
                "Values ('" + p.Address + "','" + p.Age.Replace("'", "''") + "','" + p.AgentID.Replace("'", "''") + "'," +
                "'" + p.Allergy.Replace("'", "''") + "','" + p.BuildingVillage.Replace("'", "''") + "','" + p.CompanyName.Replace("'", "''") + "'," +
                "'" + p.CompanyPhoneNo + "','" + p.ContractName.Replace("'", "''") + "','" + p.DateOfBirth.Replace("'", "''") + "'," +
                "'" + p.District.Replace("'", "''") + "','" + p.Email + "','" + p.EmergencyPersonAddress + "'," +
                "'" + p.EmergencyPersonalContact + "','" + p.EPAddress.Replace("'", "''") + "','" + p.EPDistrict.Replace("'", "''") + "'," +
                
                "'" + p.EPEmail.Replace("'", "''") + "','" + p.EPHomePhoneNo + "','" + p.EPMobilePhoneNo + "'," +
                "'" + p.EPProvince + "','" + p.EPRoad + "','" + p.EPSubDistrict + "'," +
                "'" + p.EPZipcode + "','" + p.HomePhoneNo + "','" + p.IDNumber + "'," +
                "'" + p.IDType.Replace("'", "''") + "','" + p.InsuranceName.Replace("'", "''") + "','" + p.MaritalID.Replace("'", "''") + "'," +
                "'" + p.MobilePhoneNo + "','" + p.Moo + "','" + p.Nationality + "'," +
                "'" + p.Occupation.Replace("'", "''") + "','" + p.OName + "','" + p.OSurname + "'," +
                "'" + p.PatientTypeID.Replace("'", "''") + "','" + p.PaymentID.Replace("'", "''") + "','" + p.PIDS.Replace("'", "''") + "'," +

                "'" + p.PName.Replace("'", "''") + "','" + p.Province + "','" + p.PSurname + "'," +
                "'" + p.Race + "','" + p.RelationshipID + "','" + p.RelationshipOther + "'," +
                "'" + p.Religion + "','" + p.Road + "','" + p.SexID + "'," +
                "'" + p.Soi + "','" + p.SubDistrict + "','" + p.SurfixID.Replace("'", "''") + "'," +
                "'" + p.ZipCode + "'," + p.PID + " " +
                ")";

                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String update(PatientOld p, String userId)
        {
            String re = "";
            String sql = "";

            chkNull(p);
            sql = "Update " + pttO.table + " " +
                " Set " + pttO.Address + "='" + p.Address + "' " +
                "," + pttO.Age + "='" + p.Age + "' " +
                "," + pttO.AgentID + "='" + p.AgentID + "' " +
                "," + pttO.Allergy + "='" + p.Allergy + "' " +
                "," + pttO.BuildingVillage + "='" + p.BuildingVillage + "' " +
                "," + pttO.CompanyName + "='" + p.CompanyName + "' " +
                "," + pttO.CompanyPhoneNo + "='" + p.CompanyPhoneNo + "' " +
                "," + pttO.ContractName + "='" + p.ContractName + "' " +
                "," + pttO.DateOfBirth + "='" + p.DateOfBirth + "' " +
                "," + pttO.District + "='" + p.District + "' " +
                "," + pttO.Email + "='" + p.Email + "' " +
                "," + pttO.EmergencyPersonAddress + "='" + p.EmergencyPersonAddress + "' " +
                "," + pttO.EmergencyPersonalContact + "='" + p.EmergencyPersonalContact + "' " +
                "," + pttO.EPAddress + "='" + p.EPAddress + "' " +
                "," + pttO.EPDistrict + "='" + p.EPDistrict + "' " +
                "," + pttO.EPEmail + "='" + p.EPEmail + "' " +
                "," + pttO.EPHomePhoneNo + "='" + p.EPHomePhoneNo + "' " +
                "," + pttO.EPMobilePhoneNo + "='" + p.EPMobilePhoneNo + "' " +
                "," + pttO.EPProvince + "='" + p.EPProvince + "' " +
                "," + pttO.EPRoad + "='" + p.EPRoad + "' " +
                "," + pttO.EPSubDistrict + "='" + p.EPSubDistrict + "' " +
                "," + pttO.EPZipcode + "='" + p.EPZipcode + "' " +
                "," + pttO.HomePhoneNo + "='" + p.HomePhoneNo + "' " +
                "," + pttO.IDNumber + "='" + p.IDNumber + "' " +
                "," + pttO.IDType + "='" + p.IDType + "' " +
                "," + pttO.InsuranceName + "='" + p.InsuranceName + "' " +
                "," + pttO.MaritalID + "='" + p.MaritalID + "' " +
                "," + pttO.MobilePhoneNo + "='" + p.MobilePhoneNo + "' " +
                "," + pttO.Moo + "='" + p.Moo + "' " +
                "," + pttO.Nationality + "='" + p.Nationality + "' " +
                "," + pttO.Occupation + "='" + p.Occupation + "' " +
                "," + pttO.OName + "='" + p.OName + "' " +
                "," + pttO.OSurname + "='" + p.OSurname + "' " +
                "," + pttO.PatientTypeID + "='" + p.PatientTypeID + "' " +
                "," + pttO.PaymentID + "='" + p.PaymentID + "' " +
                //"," + pttO.PIDS + "='" + p.PIDS + "' " +
                "," + pttO.PName + "='" + p.PName + "' " +
                "," + pttO.Province + "='" + p.Province + "' " +
                "," + pttO.PSurname + "='" + p.PSurname + "' " +
                "," + pttO.Race + "='" + p.Race + "' " +
                "," + pttO.RelationshipID + "='" + p.RelationshipID + "' " +
                "," + pttO.RelationshipOther + "='" + p.RelationshipOther + "' " +
                "," + pttO.Religion + "='" + p.Religion + "' " +
                "," + pttO.Road + "='" + p.Road + "' " +
                "," + pttO.SexID + "='" + p.SexID + "' " +
                "," + pttO.Soi + "='" + p.Soi + "' " +
                "," + pttO.SubDistrict + "='" + p.SubDistrict + "' " +
                "," + pttO.SurfixID + "='" + p.SurfixID + "' " +
                "," + pttO.ZipCode + "='" + p.ZipCode + "' " +
                " Where " + pttO.pkField + " = '" + p.PID + "' "
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
        public String insertPatientOld(PatientOld p, String userId)
        {
            String re = "";

            if (p.PID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }
            return re;
        }
        public String insertPatientOld(Patient p, String userId)
        {
            String re = "";
            PatientOld pttO1 = setPatientToOLD(p);
            if (pttO1.PID.Equals(""))
            {
                pttO1.PID = selectByMaxPID();
                pttO1.PIDS = genHN(pttO1.PID);
                re = insert(pttO1, "");
                re = pttO1.PID;
            }
            else
            {
                re = update(pttO1, "");
            }
            return re;
        }
        public PatientOld setPatientToOLD(Patient ptt)
        {
            PatientOld pttO1 = new PatientOld();
            pttO1.Address = ptt.patient_house;
            //pttO1.PIDS = ptt.patient_hn;
            pttO1.Age = ptt.AgeStringShort().Replace("Y",".").Replace("M", ".").Replace("D", ".");
            pttO1.AgentID = ptt.agent;
            pttO1.Allergy = ptt.patient_drugallergy;
            pttO1.BuildingVillage = "";
            pttO1.CompanyName = "";
            pttO1.CompanyPhoneNo = "";
            pttO1.ContractName = ptt.contract;
            pttO1.DateOfBirth = ptt.patient_birthday;
            pttO1.District = "";
            pttO1.Email = ptt.email;
            pttO1.EmergencyPersonAddress = "";
            pttO1.EmergencyPersonalContact = ptt.patient_contact_firstname+" "+ptt.patient_contact_lastname;
            pttO1.EPAddress = "";
            pttO1.EPDistrict = "";
            pttO1.EPEmail = "";
            pttO1.EPHomePhoneNo = "";
            pttO1.EPMobilePhoneNo = "";
            pttO1.EPProvince = "";
            pttO1.EPRoad = "";
            pttO1.EPSubDistrict = "";
            pttO1.EPZipcode = "";
            pttO1.HomePhoneNo = ptt.mobile2;
            pttO1.IDNumber = ptt.passport;
            pttO1.IDType = "";
            pttO1.InsuranceName = ptt.insurance;
            String mat = "";
            mat = fmsDB.getList(ptt.f_patient_marriage_status_id);
            pttO1.MaritalID = mat.Equals("หย่า") ? "3" : mat.Equals("หม้าย") ? "4" : mat.Equals("โสด") ? "1" : mat.Equals("คู่") ? "2" : "";
            pttO1.MobilePhoneNo = ptt.mobile1;
            pttO1.Moo = ptt.patient_moo;
            pttO1.Nationality = fpnDB.getList(ptt.f_patient_nation_id);
            pttO1.Occupation = "";
            pttO1.OName = "";
            pttO1.OSurname = "";
            pttO1.PatientTypeID = ptt.patient_type;
            pttO1.PaymentID = ptt.b_contract_plans_id;
            
            pttO1.PID = ptt.t_patient_id_old;
            pttO1.PIDS = ptt.patient_hn;
            
            pttO1.PName = ptt.patient_firstname_e;
            pttO1.Province = "";
            pttO1.PSurname = ptt.patient_lastname_e;
            pttO1.Race = fracDB.getList(ptt.f_patient_race_id);
            pttO1.RelationshipID = "";
            pttO1.RelationshipOther = "";
            pttO1.Religion = frgDB.getList(ptt.f_patient_religion_id);
            pttO1.Road = ptt.patient_road;
            pttO1.SexID = sexDB.getList(ptt.f_sex_id).Equals("ชาย") ? "1" : "2";
            pttO1.Soi = "";
            String pre = "";
            pre = fpfDB.getList(ptt.f_patient_prefix_id);
            pttO1.SubDistrict = "";
            pttO1.SurfixID = pre.Equals("Mrs.") ? "1" : pre.Equals("Miss") ? "2" : pre.Equals("Mr.") ? "3" : pre.Equals("Girl") ? "4" : pre.Equals("Boy") ? "5" : "";
            pttO1.ZipCode = "";

            return pttO1;
        }
        public DataTable selectByDate1(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select ptt." + pttO.PID + ",ptt." + pttO.PIDS + ",CONCAT(ptt." + pttO.PName + ",' ',ptt." + pttO.PSurname + ") as name,ptt." + pttO.EmergencyPersonalContact + " " +
                "From " + pttO.table + " ptt " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Where ptt." + pttO.OName + " >='" + date + " 00:00:00' and ptt." + pttO.OName + " <='" + date + " 23:59:59' " +
                "Order By ptt." + pttO.OName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySearch(String search)
        {
            DataTable dt = new DataTable();
            String whereHN = "", whereName = "", wherepid = "", wherepassport = "", wherenameE = "";
            if (!search.Equals(""))
            {
                whereHN = " ptt." + pttO.PIDS + " like '%" + search.Trim().ToUpper() + "%'";
            }
            if (!search.Equals(""))
            {
                String[] txt = search.Split(' ');
                if (txt.Length == 2)
                {
                    whereName = " or ( lcase(ptt." + pttO.OName + ") like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt." + pttO.OSurname + ") like '%" + txt[1].Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + pttO.PName + ") like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt." + pttO.PSurname + ") like '%" + txt[1].Trim().ToLower() + "%')";
                    wherenameE += " or ( lcase(ptt." + pttO.PName + ") like '%" + txt[0].Trim().ToLower() +" "+txt[1].Trim().ToLower() + "%') ";
                }
                else if (txt.Length == 1)
                {
                    whereName = " or ( lcase(ptt." + pttO.OName + ") like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt." + pttO.OSurname + ") like '%" + txt[0].Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + pttO.PName + ") like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt." + pttO.PSurname + ") like '%" + txt[0].Trim().ToLower() + "%')";
                }
                else
                {
                    whereName = " or ( lcase(ptt." + pttO.OName + ") like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt." + pttO.OSurname + ") like '%" + search.Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + pttO.PName + ") like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt." + pttO.PSurname + ") like '%" + search.Trim().ToLower() + "%')";
                }
            }
            if (!search.Equals(""))
            {
                wherepid = " or ( ptt." + pttO.IDNumber + " like '%" + search.Trim() + "%' )";
            }
            //if (!search.Equals(""))
            //{
            //    wherepassport = " or ( ptt." + pttO.passport + " like '%" + search.Trim() + "%' )";
            //}
            String sql = "select ptt." + pttO.PID + ",ptt." + pttO.PIDS + ",CONCAT(IFNULL(fpp.SurfixName,''),' ', ptt." + pttO.PName + ",' ',ptt." + pttO.PSurname + ") as name,ptt." + pttO.EmergencyPersonalContact + " " +
                "From " + pttO.table + " ptt " +
                "Left join SurfixName fpp on fpp.SurfixID = ptt.SurfixID " +
                "Where " + whereHN + whereName + wherepid + wherenameE+" " +
                "Order By ptt." + pttO.PID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select pttO.* " +
                "From " + pttO.table + " pttO " +
                "Where pttO." + pttO.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PatientOld selectByPk1(String pttId)
        {
            PatientOld cop1 = new PatientOld();
            DataTable dt = new DataTable();
            String sql = "select pttO.* " +
                ",CONCAT(IFNULL(sfn.SurfixName,''),' ', pttO." + pttO.PName + ",' ',pttO." + pttO.PSurname + ") as namee  " +
                "From " + pttO.table + " pttO " +
                "Left Join SurfixName sfn on sfn.SurfixID = pttO.SurfixID " +
                "Where pttO." + pttO.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPatient(dt);
            return cop1;
        }
        public DataTable selectByOpdCard(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select pttO.*, agt.AgentName, paym.PaymentName,rsn.RelationshipName,sfn.SurfixName, sex.SexName, marn.MaritalName" +
                ",CONCAT(IFNULL(sfn.SurfixName,''),' ', pttO." + pttO.PName + ",' ',pttO." + pttO.PSurname + ") as namee  " +
                ",CONCAT(IFNULL(sfn.SurfixName,''),' ', pttO." + pttO.OName + ",' ',pttO." + pttO.OSurname + ") as namet  " +
                ",CONCAT(IFNULL(pttO.Address,''),' ', IFNULL(pttO." + pttO.BuildingVillage + ",' ') ,' ',IFNULL(pttO." + pttO.Moo + ",' ') ,' ',IFNULL(pttO." + pttO.Soi + ",' ') ,' ',IFNULL(pttO." + pttO.Road + ",' ' ) ,' ',IFNULL(pttO." + pttO.SubDistrict + ",' ')) as address1  " +
                ",CONCAT(IFNULL(pttO.EPAddress,''),' ', IFNULL(pttO." + pttO.EPRoad + ",' ') ,' ',IFNULL(pttO." + pttO.EPSubDistrict + ",' ') ,' ',IFNULL(pttO." + pttO.EPDistrict + ",' ') ,' ',IFNULL(pttO." + pttO.EPProvince + ",' ' ) ,' ',IFNULL(pttO." + pttO.EPZipcode + ",' ')) as ep_address1  " +
                "From " + pttO.table + " pttO " +
                "Left join Agent agt on agt.AgentID = pttO.AgentID " +
                "Left Join PaymentMethod paym on paym.PaymentID = pttO.PaymentID " +
                "Left Join RelationshipName rsn on rsn.RelationshipID = pttO.RelationshipID " +
                "Left Join SurfixName sfn on sfn.SurfixID = pttO.SurfixID " +
                "Left Join SexName sex on sex.SexID = pttO.SexID " +
                "Left Join MaritalName marn on marn.MaritalID = pttO.MaritalID " +
                "Where pttO." + pttO.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectByMaxPID()
        {
            PatientOld cop1 = new PatientOld();
            DataTable dt = new DataTable();
            int chk = 0;
            int year = DateTime.Now.Year*10000;
            String re = "";
            String sql = "select max(PID) as MAXPID from Patient ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["MAXPID"].ToString();
                chk = int.Parse(re);
            }
            if (year < chk) {
                chk = chk + 1;
            }
            else
            {
                chk = year + 1;
            }
            //IDS = "HN-".substr($PID, -5). "/".substr(date("Y", time()) + 543, -2);//
            return chk.ToString();
        }
        public String genHN(String pid)
        {
            String re = "", chk="", year="";
            int chk1 = 0;
            //PIDS = "HN-".substr($PID, -5). "/".substr(date("Y", time()) + 543, -2);
            if (pid.Length > 4)
            {
                chk = pid.Substring(pid.Length - 5);
                //year = pid.Substring(0, 4);
                if(int.TryParse(pid.Substring(0, 4), out chk1))
                {
                    chk1 += 543;
                    year = chk1.ToString().Substring(chk1.ToString().Length - 2);
                    re = "HN-" + chk + "/" + year;
                }
            }
            
            return re;
        }
        public PatientOld setPatient(DataTable dt)
        {
            PatientOld ptt1 = new PatientOld();
            if (dt.Rows.Count > 0)
            {
                ptt1.Address = dt.Rows[0][pttO.Address].ToString();
                ptt1.Age = dt.Rows[0][pttO.Age].ToString();
                ptt1.AgentID = dt.Rows[0][pttO.AgentID].ToString();
                ptt1.Allergy = dt.Rows[0][pttO.Allergy].ToString();
                ptt1.BuildingVillage = dt.Rows[0][pttO.BuildingVillage].ToString();
                ptt1.CompanyName = dt.Rows[0][pttO.CompanyName].ToString();
                ptt1.CompanyPhoneNo = dt.Rows[0][pttO.CompanyPhoneNo].ToString();
                ptt1.ContractName = dt.Rows[0][pttO.ContractName].ToString();
                ptt1.DateOfBirth = dt.Rows[0][pttO.DateOfBirth].ToString();
                ptt1.District = dt.Rows[0][pttO.District].ToString();
                ptt1.Email = dt.Rows[0][pttO.Email].ToString();
                ptt1.EmergencyPersonAddress = dt.Rows[0][pttO.EmergencyPersonAddress].ToString();
                ptt1.EmergencyPersonalContact = dt.Rows[0][pttO.EmergencyPersonalContact].ToString();
                ptt1.EPAddress = dt.Rows[0][pttO.EPAddress].ToString();
                ptt1.EPDistrict = dt.Rows[0][pttO.EPDistrict].ToString();
                ptt1.EPEmail = dt.Rows[0][pttO.EPEmail].ToString();
                ptt1.EPHomePhoneNo = dt.Rows[0][pttO.EPHomePhoneNo].ToString();
                ptt1.EPMobilePhoneNo = dt.Rows[0][pttO.EPMobilePhoneNo].ToString();
                ptt1.EPProvince = dt.Rows[0][pttO.EPProvince].ToString();
                ptt1.EPRoad = dt.Rows[0][pttO.EPRoad].ToString();
                ptt1.EPSubDistrict = dt.Rows[0][pttO.EPSubDistrict].ToString();
                ptt1.EPZipcode = dt.Rows[0][pttO.EPZipcode].ToString();
                ptt1.HomePhoneNo = dt.Rows[0][pttO.HomePhoneNo].ToString();
                ptt1.IDNumber = dt.Rows[0][pttO.IDNumber].ToString();
                ptt1.IDType = dt.Rows[0][pttO.IDType].ToString();
                ptt1.InsuranceName = dt.Rows[0][pttO.InsuranceName].ToString();
                ptt1.MaritalID = dt.Rows[0][pttO.MaritalID].ToString();
                ptt1.MobilePhoneNo = dt.Rows[0][pttO.MobilePhoneNo].ToString();
                ptt1.Moo = dt.Rows[0][pttO.Moo].ToString();
                ptt1.Nationality = dt.Rows[0][pttO.Nationality].ToString();
                ptt1.Occupation = dt.Rows[0][pttO.Occupation].ToString();
                ptt1.OName = dt.Rows[0][pttO.OName].ToString();
                ptt1.OSurname = dt.Rows[0][pttO.OSurname].ToString();
                ptt1.PatientTypeID = dt.Rows[0][pttO.PatientTypeID].ToString();
                ptt1.PaymentID = dt.Rows[0][pttO.PaymentID].ToString();
                ptt1.PID = dt.Rows[0][pttO.PID].ToString();
                ptt1.PIDS = dt.Rows[0][pttO.PIDS].ToString();
                ptt1.PName = dt.Rows[0][pttO.PName].ToString();
                ptt1.Province = dt.Rows[0][pttO.Province].ToString();
                ptt1.PSurname = dt.Rows[0][pttO.PSurname].ToString();
                ptt1.Race = dt.Rows[0][pttO.Race].ToString();
                ptt1.RelationshipID = dt.Rows[0][pttO.RelationshipID].ToString();
                ptt1.RelationshipOther = dt.Rows[0][pttO.RelationshipOther].ToString();
                ptt1.Religion = dt.Rows[0][pttO.Religion].ToString();
                ptt1.Road = dt.Rows[0][pttO.Road].ToString();
                ptt1.SexID = dt.Rows[0][pttO.SexID].ToString();
                ptt1.Soi = dt.Rows[0][pttO.Soi].ToString();
                ptt1.SubDistrict = dt.Rows[0][pttO.SubDistrict].ToString();
                ptt1.SurfixID = dt.Rows[0][pttO.SurfixID].ToString();
                ptt1.ZipCode = dt.Rows[0][pttO.ZipCode].ToString();
                ptt1.FullName = dt.Rows[0]["namee"].ToString();
            }
            else
            {
                setPatient1(ptt1);
            }
            return ptt1;
        }
        private PatientOld setPatient1(PatientOld stf1)
        {
            stf1.Address = "";
            stf1.Age = "";
            stf1.AgentID = "";
            stf1.Allergy = "";
            stf1.BuildingVillage = "";
            stf1.CompanyName = "";
            stf1.CompanyPhoneNo = "";
            stf1.ContractName = "";
            stf1.DateOfBirth = "";
            stf1.District = "";
            stf1.Email = "";
            stf1.EmergencyPersonAddress = "";
            stf1.EmergencyPersonalContact = "";
            stf1.EPAddress = "";
            stf1.EPDistrict = "";
            stf1.EPEmail = "";
            stf1.EPHomePhoneNo = "";
            stf1.EPMobilePhoneNo = "";
            stf1.EPProvince = "";
            stf1.EPRoad = "";
            stf1.EPSubDistrict = "";
            stf1.EPZipcode = "";
            stf1.HomePhoneNo = "";
            stf1.IDNumber = "";
            stf1.IDType = "";
            stf1.InsuranceName = "";
            stf1.MaritalID = "";
            stf1.MobilePhoneNo = "";
            stf1.Moo = "";
            stf1.Nationality = "";
            stf1.Occupation = "";
            stf1.OName = "";
            stf1.OSurname = "";
            stf1.PatientTypeID = "";
            stf1.PaymentID = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.PName = "";
            stf1.Province = "";
            stf1.PSurname = "";
            stf1.Race = "";
            stf1.RelationshipID = "";
            stf1.RelationshipOther = "";
            stf1.Religion = "";
            stf1.Road = "";
            stf1.SexID = "";
            stf1.Soi = "";
            stf1.SubDistrict = "";
            stf1.SurfixID = "";
            stf1.ZipCode = "";
            stf1.FullName = "";
            return stf1;
        }
    }
}
