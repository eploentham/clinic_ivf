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
    public class PatientMedicalHistoryDB
    {
        public PatientMedicalHistory pmh;
        ConnectDB conn;
        public List<PatientMedicalHistory> lPmh;
        public enum Day1 { Day2, Day3, Day5, Day6 }

        public PatientMedicalHistoryDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pmh = new PatientMedicalHistory();
            pmh.patient_medical_history_id = "patient_medical_history_id";
            pmh.t_patient_id = "t_patient_id";
            pmh.patient_hn = "patient_hn";
            pmh.patient_name = "patient_name";
            pmh.couple_name = "couple_name";
            pmh.active = "active";
            pmh.remark = "remark";
            pmh.occupation = "occupation";
            pmh.date_create = "date_create";
            pmh.date_modi = "date_modi";
            pmh.date_cancel = "date_cancel";
            pmh.user_create = "user_create";
            pmh.user_modi = "user_modi";
            pmh.user_cancel = "user_cancel";
            pmh.contraception = "contraception";
            pmh.contraception_other = "contraception_other";
            pmh.drug_allergy = "drug_allergy";
            pmh.drug_allergy_other = "drug_allergy_other";
            pmh.past_illness_dialeteles = "past_illness_dialeteles";
            pmh.past_illness_asihma = "past_illness_asihma";
            pmh.past_illness_hypertention = "past_illness_hypertention";
            pmh.past_illness_liver_disease = "past_illness_liver_disease";
            pmh.past_illness_tuberculosis = "past_illness_tuberculosis";
            pmh.past_illness_siezure = "past_illness_siezure";
            pmh.past_illness_sti = "past_illness_sti";
            pmh.past_illness_thyroid_disorders = "past_illness_thyroid_disorders";
            pmh.past_illness_other = "past_illness_other";
            pmh.substance_abuse = "substance_abuse";
            pmh.substance_abuse_other = "substance_abuse_other";
            pmh.surgical_history = "surgical_history";
            pmh.surgical_history_other = "surgical_history_other";
            pmh.type_of_infertility = "type_of_infertility";
            pmh.type_of_infertility_other = "type_of_infertility_other";
            pmh.menstrution = "menstrution";
            pmh.menstrution_days = "menstrution_days";
            pmh.menstrution_interval = "menstrution_interval";
            pmh.menstrution_amount = "menstrution_amount";
            pmh.menstrution_lmp = "menstrution_lmp";
            pmh.previous_treatment = "previous_treatment";
            pmh.previous_treatment_other = "previous_treatment_other";
            pmh.pap_smear = "pap_smear";
            pmh.pap_smear_other = "pap_smear_other";
            pmh.male_name = "male_name";
            pmh.male_drug_allery = "male_drug_allery";
            pmh.male_drug_allery_other = "male_drug_allery_other";
            pmh.male_past_illness_dialeteles = "male_past_illness_dialeteles";
            pmh.male_past_illness_asihma = "male_past_illness_asihma";
            pmh.male_past_illness_hypertention = "male_past_illness_hypertention";
            pmh.male_past_illness_liver_disease = "male_past_illness_liver_disease";
            pmh.male_past_illness_tuberculosis = "male_past_illness_tuberculosis";
            pmh.male_past_illness_siezure = "male_past_illness_siezure";
            pmh.male_past_illness_sti = "male_past_illness_sti";
            pmh.male_past_illness_thyroid_disorders = "male_past_illness_thyroid_disorders";
            pmh.male_past_illness_other = "male_past_illness_other";
            pmh.male_substance_abuse = "male_substance_abuse";
            pmh.male_substance_abuse_other = "male_substance_abuse_other";
            pmh.male_smoking = "male_smoking";
            pmh.male_smoking_other = "male_smoking_other";
            pmh.male_drinking = "male_drinking";
            pmh.male_drinking_other = "male_drinking_other";
            pmh.male_drug = "male_drug";
            pmh.male_drug_other = "male_drug_other";
            pmh.male_surg = "male_surg";
            pmh.male_surg_other = "male_surg_other";
            pmh.male_infertility = "male_infertility";
            pmh.male_infertility_other = "male_infertility_other";
            pmh.past_illness_other_other = "past_illness_other_other";
            pmh.male_past_illness_other_other = "male_past_illness_other_other";

            pmh.table = "t_patient_medical_history";
            pmh.pkField = "patient_medical_history_id";

            lPmh = new List<PatientMedicalHistory>();
        }
        private void chkNull(PatientMedicalHistory p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            //p.past_illness_dialeteles = long.TryParse(p.past_illness_dialeteles, out chk) ? chk.ToString() : "0";

            p.patient_hn = p.patient_hn == null ? "0" : p.patient_hn;
            p.couple_name = p.couple_name == null ? "" : p.couple_name;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.occupation = p.occupation == null ? "" : p.occupation;
            p.contraception = p.contraception == null ? "" : p.contraception;
            p.contraception_other = p.contraception_other == null ? "" : p.contraception_other;
            p.drug_allergy = p.drug_allergy == null ? "" : p.drug_allergy;
            p.past_illness_asihma = p.past_illness_asihma == null ? "" : p.past_illness_asihma;
            p.past_illness_hypertention = p.past_illness_hypertention == null ? "" : p.past_illness_hypertention;
            p.patient_name = p.patient_name == null ? "" : p.patient_name;
            p.drug_allergy_other = p.drug_allergy_other == null ? "" : p.drug_allergy_other;
            p.past_illness_dialeteles = p.past_illness_dialeteles == null ? "" : p.past_illness_dialeteles;
            p.past_illness_liver_disease = p.past_illness_liver_disease == null ? "" : p.past_illness_liver_disease;
            p.past_illness_siezure = p.past_illness_siezure == null ? "0" : p.past_illness_siezure;
            p.past_illness_sti = p.past_illness_sti == null ? "" : p.past_illness_sti;
            p.past_illness_thyroid_disorders = p.past_illness_thyroid_disorders == null ? "" : p.past_illness_thyroid_disorders;
            p.past_illness_other = p.past_illness_other == null ? "0" : p.past_illness_other;
            p.substance_abuse = p.substance_abuse == null ? "0" : p.substance_abuse;
            p.substance_abuse_other = p.substance_abuse_other == null ? "" : p.substance_abuse_other;
            p.surgical_history = p.surgical_history == null ? "0" : p.surgical_history;
            p.surgical_history_other = p.surgical_history_other == null ? "0" : p.surgical_history_other;
            p.type_of_infertility = p.type_of_infertility == null ? "" : p.type_of_infertility;
            p.type_of_infertility_other = p.type_of_infertility_other == null ? "" : p.type_of_infertility_other;
            p.menstrution = p.menstrution == null ? "" : p.menstrution;
            p.menstrution_days = p.menstrution_days == null ? "" : p.menstrution_days;
            p.menstrution_interval = p.menstrution_interval == null ? "" : p.menstrution_interval;
            p.menstrution_amount = p.menstrution_amount == null ? "" : p.menstrution_amount;
            p.menstrution_lmp = p.menstrution_lmp == null ? "" : p.menstrution_lmp;
            p.previous_treatment = p.previous_treatment == null ? "" : p.previous_treatment;
            p.previous_treatment_other = p.previous_treatment_other == null ? "" : p.previous_treatment_other;
            p.pap_smear = p.pap_smear == null ? "" : p.pap_smear;
            p.pap_smear_other = p.pap_smear_other == null ? "" : p.pap_smear_other;
            p.male_name = p.male_name == null ? "" : p.male_name;
            p.male_drug_allery = p.male_drug_allery == null ? "" : p.male_drug_allery;
            p.male_drug_allery_other = p.male_drug_allery_other == null ? "" : p.male_drug_allery_other;
            p.male_past_illness_dialeteles = p.male_past_illness_dialeteles == null ? "" : p.male_past_illness_dialeteles;
            p.male_past_illness_asihma = p.male_past_illness_asihma == null ? "" : p.male_past_illness_asihma;
            p.male_past_illness_hypertention = p.male_past_illness_hypertention == null ? "" : p.male_past_illness_hypertention;
            p.male_past_illness_liver_disease = p.male_past_illness_liver_disease == null ? "" : p.male_past_illness_liver_disease;
            p.male_past_illness_tuberculosis = p.male_past_illness_tuberculosis == null ? "" : p.male_past_illness_tuberculosis;
            p.male_past_illness_siezure = p.male_past_illness_siezure == null ? "" : p.male_past_illness_siezure;
            p.male_past_illness_sti = p.male_past_illness_sti == null ? "" : p.male_past_illness_sti;
            p.male_past_illness_thyroid_disorders = p.male_past_illness_thyroid_disorders == null ? "" : p.male_past_illness_thyroid_disorders;
            p.male_past_illness_other = p.male_past_illness_other == null ? "" : p.male_past_illness_other;
            p.male_substance_abuse = p.male_substance_abuse == null ? "" : p.male_substance_abuse;
            p.male_substance_abuse_other = p.male_substance_abuse_other == null ? "" : p.male_substance_abuse_other;
            p.male_smoking = p.male_smoking == null ? "" : p.male_smoking;
            p.male_smoking_other = p.male_smoking_other == null ? "" : p.male_smoking_other;
            p.male_drinking = p.male_drinking == null ? "" : p.male_drinking;
            p.male_drinking_other = p.male_drinking_other == null ? "" : p.male_drinking_other;
            p.male_drug = p.male_drug == null ? "" : p.male_drug;
            p.male_drug_other = p.male_drug_other == null ? "" : p.male_drug_other;
            p.male_surg = p.male_surg == null ? "" : p.male_surg;
            p.male_surg_other = p.male_surg_other == null ? "" : p.male_surg_other;
            p.male_infertility = p.male_infertility == null ? "" : p.male_infertility;
            p.male_infertility_other = p.male_infertility_other == null ? "" : p.male_infertility_other;

            p.past_illness_tuberculosis = p.past_illness_tuberculosis == null ? "" : p.past_illness_tuberculosis;
            p.past_illness_other_other = p.past_illness_other_other == null ? "" : p.past_illness_other_other;
            p.male_past_illness_other_other = p.male_past_illness_other_other == null ? "" : p.male_past_illness_other_other;
        }
        public String insert(PatientMedicalHistory p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //opuEmDev.p = "p";
            sql = "Insert Into " + pmh.table + " Set " +
                " " + pmh.t_patient_id + "='" + p.t_patient_id + "'" +
                "," + pmh.patient_hn + "='" + p.patient_hn + "'" +
                "," + pmh.patient_name + "='" + p.patient_name + "'" +
                "," + pmh.couple_name + "='" + p.couple_name.Replace("'", "''") + "'" +
                "," + pmh.active + "='" + p.active + "'" +
                "," + pmh.remark + "='" + p.remark.Replace("'", "''") + "'" +
                "," + pmh.occupation + "='" + p.occupation + "'" +
                "," + pmh.date_create + "=now()" +
                "," + pmh.user_create + "='" + userId + "'" +
                "," + pmh.contraception + "='" + p.contraception.Replace("'", "''") + "'" +
                "," + pmh.contraception_other + "='" + p.contraception_other.Replace("'", "''") + "'" +
                "," + pmh.drug_allergy + "='" + p.drug_allergy.Replace("'", "''") + "'" +
                "," + pmh.drug_allergy_other + "='" + p.drug_allergy_other.Replace("'", "''") + "'" +
                "," + pmh.past_illness_dialeteles + "='" + p.past_illness_dialeteles.Replace("'", "''") + "'" +
                "," + pmh.past_illness_asihma + "='" + p.past_illness_asihma.Replace("'", "''") + "'" +
                //"," + pmh.t_patient_id + "='" + p.t_patient_id + "'" +
                "," + pmh.past_illness_hypertention + "='" + p.past_illness_hypertention + "'" +
                "," + pmh.past_illness_liver_disease + "='" + p.past_illness_liver_disease + "'" +
                "," + pmh.past_illness_tuberculosis + "='" + p.past_illness_tuberculosis + "'" +
                "," + pmh.past_illness_siezure + "='" + p.past_illness_siezure + "'" +
                "," + pmh.past_illness_sti + "='" + p.past_illness_sti + "'" +
                "," + pmh.past_illness_thyroid_disorders + "='" + p.past_illness_thyroid_disorders + "'" +
                "," + pmh.past_illness_other + "='" + p.past_illness_other + "'" +
                "," + pmh.substance_abuse + "='" + p.substance_abuse + "'" +
                "," + pmh.substance_abuse_other + "='" + p.substance_abuse_other + "'" +
                "," + pmh.surgical_history + "='" + p.surgical_history + "'" +
                "," + pmh.surgical_history_other + "='" + p.surgical_history_other + "'" +
                "," + pmh.type_of_infertility + "='" + p.type_of_infertility + "'" +
                "," + pmh.type_of_infertility_other + "='" + p.type_of_infertility_other + "'" +
                "," + pmh.menstrution + "='" + p.menstrution + "'" +
                "," + pmh.menstrution_days + "='" + p.menstrution_days + "'" +
                "," + pmh.menstrution_interval + "='" + p.menstrution_interval + "'" +
                "," + pmh.menstrution_amount + "='" + p.menstrution_amount + "'" +
                "," + pmh.menstrution_lmp + "='" + p.menstrution_lmp + "'" +
                "," + pmh.previous_treatment + "='" + p.previous_treatment + "'" +
                "," + pmh.previous_treatment_other + "='" + p.previous_treatment_other + "'" +
                "," + pmh.pap_smear + "='" + p.pap_smear + "'" +
                "," + pmh.pap_smear_other + "='" + p.pap_smear_other + "'" +
                "," + pmh.male_name + "='" + p.male_name + "'" +
                "," + pmh.male_drug_allery + "='" + p.male_drug_allery + "'" +
                "," + pmh.male_drug_allery_other + "='" + p.male_drug_allery_other + "'" +
                "," + pmh.male_past_illness_dialeteles + "='" + p.male_past_illness_dialeteles + "'" +
                "," + pmh.male_past_illness_asihma + "='" + p.male_past_illness_asihma + "'" +
                "," + pmh.male_past_illness_hypertention + "='" + p.male_past_illness_hypertention + "'" +
                "," + pmh.male_past_illness_liver_disease + "='" + p.male_past_illness_liver_disease + "'" +
                "," + pmh.male_past_illness_tuberculosis + "='" + p.male_past_illness_tuberculosis + "'" +
                "," + pmh.male_past_illness_siezure + "='" + p.male_past_illness_siezure + "'" +
                "," + pmh.male_past_illness_sti + "='" + p.male_past_illness_sti + "'" +
                "," + pmh.male_past_illness_thyroid_disorders + "='" + p.male_past_illness_thyroid_disorders + "'" +
                "," + pmh.male_past_illness_other + "='" + p.male_past_illness_other + "'" +
                "," + pmh.male_substance_abuse + "='" + p.male_substance_abuse + "'" +
                "," + pmh.male_substance_abuse_other + "='" + p.male_substance_abuse_other + "'" +
                "," + pmh.male_smoking + "='" + p.male_smoking + "'" +
                "," + pmh.male_smoking_other + "='" + p.male_smoking_other + "'" +
                "," + pmh.male_drinking + "='" + p.male_drinking + "'" +
                "," + pmh.male_drinking_other + "='" + p.male_drinking_other + "'" +
                "," + pmh.male_drug + "='" + p.male_drug + "'" +
                "," + pmh.male_drug_other + "='" + p.male_drug_other + "'" +
                "," + pmh.male_surg + "='" + p.male_surg + "'" +
                "," + pmh.male_surg_other + "='" + p.male_surg_other + "'" +
                "," + pmh.male_infertility + "='" + p.male_infertility + "'" +
                "," + pmh.male_infertility_other + "='" + p.male_infertility_other + "'" +
                "," + pmh.past_illness_other_other + "='" + p.past_illness_other_other + "'" +
                "," + pmh.male_past_illness_other_other + "='" + p.male_past_illness_other_other + "'" +
                " " +

                "";
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
        public String update(PatientMedicalHistory p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + pmh.table + " Set " +
                " " + pmh.patient_hn + " = '" + p.patient_hn + "'" +
                "," + pmh.patient_name + " = '" + p.patient_name.Replace("'", "''") + "'" +
                "," + pmh.couple_name + " = '" + p.couple_name.Replace("'", "''") + "'" +
                "," + pmh.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + pmh.contraception + " = '" + p.contraception.Replace("'", "''") + "'" +
                "," + pmh.contraception_other + " = '" + p.contraception_other.Replace("'", "''") + "'" +
                "," + pmh.drug_allergy + " = '" + p.drug_allergy.Replace("'", "''") + "'" +
                "," + pmh.drug_allergy_other + " = '" + p.drug_allergy_other.Replace("'", "''") + "'" +
                "," + pmh.past_illness_dialeteles + "='" + p.past_illness_dialeteles.Replace("'", "''") + "'" +
                "," + pmh.past_illness_asihma + "='" + p.past_illness_asihma.Replace("'", "''") + "'" +
                "," + pmh.t_patient_id + "='" + p.t_patient_id + "'" +
                "," + pmh.past_illness_hypertention + "='" + p.past_illness_hypertention + "'" +
                "," + pmh.past_illness_liver_disease + "='" + p.past_illness_liver_disease + "'" +
                "," + pmh.past_illness_tuberculosis + "='" + p.past_illness_tuberculosis + "'" +
                "," + pmh.past_illness_siezure + "='" + p.past_illness_siezure + "'" +
                "," + pmh.past_illness_sti + "='" + p.past_illness_sti + "'" +
                "," + pmh.past_illness_thyroid_disorders + "='" + p.past_illness_thyroid_disorders + "'" +
                "," + pmh.past_illness_other + "='" + p.past_illness_other + "'" +
                "," + pmh.substance_abuse + "='" + p.substance_abuse + "'" +
                "," + pmh.substance_abuse_other + "='" + p.substance_abuse_other + "'" +
                "," + pmh.surgical_history + "='" + p.surgical_history + "'" +
                "," + pmh.surgical_history_other + "='" + p.surgical_history_other + "'" +
                "," + pmh.type_of_infertility + "='" + p.type_of_infertility + "'" +
                "," + pmh.occupation + "='" + p.occupation + "'" +
                "," + pmh.type_of_infertility_other + "='" + p.type_of_infertility_other + "'" +
                "," + pmh.menstrution + "='" + p.menstrution + "'" +
                "," + pmh.menstrution_days + "='" + p.menstrution_days + "'" +
                "," + pmh.menstrution_interval + "='" + p.menstrution_interval + "'" +
                "," + pmh.menstrution_amount + "='" + p.menstrution_amount + "'" +
                "," + pmh.menstrution_lmp + "='" + p.menstrution_lmp + "'" +
                "," + pmh.previous_treatment + "='" + p.previous_treatment + "'" +
                "," + pmh.previous_treatment_other + "='" + p.previous_treatment_other + "'" +
                "," + pmh.pap_smear + "='" + p.pap_smear + "'" +
                "," + pmh.pap_smear_other + "='" + p.pap_smear_other + "'" +
                "," + pmh.male_name + "='" + p.male_name + "'" +
                "," + pmh.male_drug_allery + "='" + p.male_drug_allery + "'" +
                "," + pmh.male_drug_allery_other + "='" + p.male_drug_allery_other + "'" +
                "," + pmh.male_past_illness_dialeteles + "='" + p.male_past_illness_dialeteles + "'" +
                "," + pmh.male_past_illness_asihma + "='" + p.male_past_illness_asihma + "'" +
                "," + pmh.male_past_illness_hypertention + "='" + p.male_past_illness_hypertention + "'" +
                "," + pmh.male_past_illness_liver_disease + "='" + p.male_past_illness_liver_disease + "'" +
                "," + pmh.male_past_illness_tuberculosis + "='" + p.male_past_illness_tuberculosis + "'" +
                "," + pmh.male_past_illness_siezure + "='" + p.male_past_illness_siezure + "'" +
                "," + pmh.male_past_illness_sti + "='" + p.male_past_illness_sti + "'" +
                "," + pmh.male_past_illness_thyroid_disorders + "='" + p.male_past_illness_thyroid_disorders + "'" +
                "," + pmh.male_past_illness_other + "='" + p.male_past_illness_other + "'" +
                "," + pmh.male_substance_abuse + "='" + p.male_substance_abuse + "'" +
                "," + pmh.male_substance_abuse_other + "='" + p.male_substance_abuse_other + "'" +
                "," + pmh.male_smoking + "='" + p.male_smoking + "'" +
                "," + pmh.male_smoking_other + "='" + p.male_smoking_other + "'" +
                "," + pmh.male_drinking + "='" + p.male_drinking + "'" +
                "," + pmh.male_drinking_other + "='" + p.male_drinking_other + "'" +
                "," + pmh.male_drug + "='" + p.male_drug + "'" +
                "," + pmh.male_drug_other + "='" + p.male_drug_other + "'" +
                "," + pmh.male_surg + "='" + p.male_surg + "'" +
                "," + pmh.male_surg_other + "='" + p.male_surg_other + "'" +
                "," + pmh.male_infertility + "='" + p.male_infertility + "'" +
                "," + pmh.male_infertility_other + "='" + p.male_infertility_other + "'" +
                "," + pmh.past_illness_other_other + "='" + p.past_illness_other_other + "'" +
                "," + pmh.male_past_illness_other_other + "='" + p.male_past_illness_other_other + "'" +
                "Where " + pmh.pkField + "='" + p.patient_medical_history_id + "'"
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
        public String insertPatientMedicalHistory(PatientMedicalHistory p, String userId)
        {
            String re = "";

            if (p.patient_medical_history_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String VoidEggSti(String id, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + pmh.table + " Set " +
                " " + pmh.active + " = '3'" +
                "," + pmh.date_cancel + " = now()" +
                "," + pmh.user_cancel + " = '" + userid + "'" +
                "Where " + pmh.pkField + "='" + id + "'";
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
                
        public DataTable selectDistinctByAddLab()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct eggs." + pmh.type_of_infertility + " " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboAddLab(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByAddLab();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[pmh.type_of_infertility].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public PatientMedicalHistory selectByPk1(String pttId)
        {
            PatientMedicalHistory cop1 = new PatientMedicalHistory();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public PatientMedicalHistory selectByVsId(String pttId)
        {
            PatientMedicalHistory cop1 = new PatientMedicalHistory();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.past_illness_hypertention + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public PatientMedicalHistory selectByPttId(String pttId)
        {
            PatientMedicalHistory cop1 = new PatientMedicalHistory();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.t_patient_id + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public DataTable selectByPttId1(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + pmh.table + " eggs " +
                "Where eggs." + pmh.t_patient_id + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private PatientMedicalHistory setEggSti(DataTable dt)
        {
            PatientMedicalHistory pmh1 = new PatientMedicalHistory();
            if (dt.Rows.Count > 0)
            {
                pmh1.patient_medical_history_id = dt.Rows[0][pmh.patient_medical_history_id].ToString();
                pmh1.t_patient_id = dt.Rows[0][pmh.t_patient_id].ToString();
                pmh1.patient_hn = dt.Rows[0][pmh.patient_hn].ToString();
                pmh1.patient_name = dt.Rows[0][pmh.patient_name].ToString();
                pmh1.couple_name = dt.Rows[0][pmh.couple_name].ToString();
                pmh1.active = dt.Rows[0][pmh.active].ToString();
                pmh1.remark = dt.Rows[0][pmh.remark].ToString();
                pmh1.occupation = dt.Rows[0][pmh.occupation].ToString();
                pmh1.date_create = dt.Rows[0][pmh.date_create].ToString();
                pmh1.date_modi = dt.Rows[0][pmh.date_modi].ToString();
                pmh1.date_cancel = dt.Rows[0][pmh.date_cancel].ToString();
                pmh1.user_create = dt.Rows[0][pmh.user_create].ToString();
                pmh1.user_modi = dt.Rows[0][pmh.user_modi].ToString();
                pmh1.user_cancel = dt.Rows[0][pmh.user_cancel].ToString();
                pmh1.contraception = dt.Rows[0][pmh.contraception].ToString();
                pmh1.contraception_other = dt.Rows[0][pmh.contraception_other].ToString();
                pmh1.drug_allergy = dt.Rows[0][pmh.drug_allergy].ToString();
                pmh1.drug_allergy_other = dt.Rows[0][pmh.drug_allergy_other].ToString();
                pmh1.past_illness_dialeteles = dt.Rows[0][pmh.past_illness_dialeteles].ToString();
                pmh1.past_illness_asihma = dt.Rows[0][pmh.past_illness_asihma].ToString();
                pmh1.t_patient_id = dt.Rows[0][pmh.t_patient_id].ToString();
                pmh1.past_illness_hypertention = dt.Rows[0][pmh.past_illness_hypertention].ToString();
                pmh1.past_illness_liver_disease = dt.Rows[0][pmh.past_illness_liver_disease].ToString();
                pmh1.past_illness_tuberculosis = dt.Rows[0][pmh.past_illness_tuberculosis].ToString();
                pmh1.past_illness_siezure = dt.Rows[0][pmh.past_illness_siezure].ToString();
                pmh1.past_illness_sti = dt.Rows[0][pmh.past_illness_sti].ToString();
                pmh1.past_illness_thyroid_disorders = dt.Rows[0][pmh.past_illness_thyroid_disorders].ToString();
                pmh1.past_illness_other = dt.Rows[0][pmh.past_illness_other].ToString();
                pmh1.substance_abuse = dt.Rows[0][pmh.substance_abuse].ToString();
                pmh1.substance_abuse_other = dt.Rows[0][pmh.substance_abuse_other].ToString();
                pmh1.surgical_history = dt.Rows[0][pmh.surgical_history].ToString();
                pmh1.surgical_history_other = dt.Rows[0][pmh.surgical_history_other].ToString();
                pmh1.type_of_infertility = dt.Rows[0][pmh.type_of_infertility].ToString();
                pmh1.type_of_infertility_other = dt.Rows[0][pmh.type_of_infertility_other].ToString();
                pmh1.menstrution = dt.Rows[0][pmh.menstrution].ToString();
                pmh1.menstrution_days = dt.Rows[0][pmh.menstrution_days].ToString();
                pmh1.menstrution_interval = dt.Rows[0][pmh.menstrution_interval].ToString();
                pmh1.menstrution_amount = dt.Rows[0][pmh.menstrution_amount].ToString();
                pmh1.menstrution_lmp = dt.Rows[0][pmh.menstrution_lmp].ToString();
                pmh1.previous_treatment = dt.Rows[0][pmh.previous_treatment].ToString();
                pmh1.previous_treatment_other = dt.Rows[0][pmh.previous_treatment_other].ToString();
                pmh1.pap_smear = dt.Rows[0][pmh.pap_smear].ToString();
                pmh1.pap_smear_other = dt.Rows[0][pmh.pap_smear_other].ToString();
                pmh1.male_name = dt.Rows[0][pmh.male_name].ToString();
                pmh1.male_drug_allery = dt.Rows[0][pmh.male_drug_allery].ToString();
                pmh1.male_drug_allery_other = dt.Rows[0][pmh.male_drug_allery_other].ToString();
                pmh1.male_past_illness_dialeteles = dt.Rows[0][pmh.male_past_illness_dialeteles].ToString();
                pmh1.male_past_illness_asihma = dt.Rows[0][pmh.male_past_illness_asihma].ToString();
                pmh1.male_past_illness_hypertention = dt.Rows[0][pmh.male_past_illness_hypertention].ToString();
                pmh1.male_past_illness_liver_disease = dt.Rows[0][pmh.male_past_illness_liver_disease].ToString();
                pmh1.male_past_illness_tuberculosis = dt.Rows[0][pmh.male_past_illness_tuberculosis].ToString();
                pmh1.male_past_illness_siezure = dt.Rows[0][pmh.male_past_illness_siezure].ToString();
                pmh1.male_past_illness_sti = dt.Rows[0][pmh.male_past_illness_sti].ToString();
                pmh1.male_past_illness_thyroid_disorders = dt.Rows[0][pmh.male_past_illness_thyroid_disorders].ToString();
                pmh1.male_past_illness_other = dt.Rows[0][pmh.male_past_illness_other].ToString();
                pmh1.male_substance_abuse = dt.Rows[0][pmh.male_substance_abuse].ToString();
                pmh1.male_substance_abuse_other = dt.Rows[0][pmh.male_substance_abuse_other].ToString();
                pmh1.male_smoking = dt.Rows[0][pmh.male_smoking].ToString();
                pmh1.male_smoking_other = dt.Rows[0][pmh.male_smoking_other].ToString();
                pmh1.male_drinking = dt.Rows[0][pmh.male_drinking].ToString();
                pmh1.male_drinking_other = dt.Rows[0][pmh.male_drinking_other].ToString();
                pmh1.male_drug = dt.Rows[0][pmh.male_drug].ToString();
                pmh1.male_drug_other = dt.Rows[0][pmh.male_drug_other].ToString();
                pmh1.male_surg = dt.Rows[0][pmh.male_surg].ToString();
                pmh1.male_surg_other = dt.Rows[0][pmh.male_surg_other].ToString();
                pmh1.male_infertility = dt.Rows[0][pmh.male_infertility].ToString();
                pmh1.male_infertility_other = dt.Rows[0][pmh.male_infertility_other].ToString();
                pmh1.past_illness_other_other = dt.Rows[0][pmh.past_illness_other_other].ToString();
                pmh1.male_past_illness_other_other = dt.Rows[0][pmh.male_past_illness_other_other].ToString();
            }
            else
            {
                pmh1.patient_medical_history_id = "";
                pmh1.t_patient_id = "";
                pmh1.patient_hn = "";
                pmh1.patient_name = "";
                pmh1.couple_name = "";
                pmh1.active = "";
                pmh1.remark = "";
                pmh1.occupation = "";
                pmh1.date_create = "";
                pmh1.date_modi = "";
                pmh1.date_cancel = "";
                pmh1.user_create = "";
                pmh1.user_modi = "";
                pmh1.user_cancel = "";
                pmh1.contraception = "";
                pmh1.contraception_other = "";
                pmh1.drug_allergy = "";
                pmh1.drug_allergy_other = "";
                pmh1.past_illness_dialeteles = "";
                pmh1.past_illness_asihma = "";
                pmh1.t_patient_id = "";
                pmh1.past_illness_hypertention = "";
                pmh1.past_illness_liver_disease = "";
                pmh1.past_illness_tuberculosis = "";
                pmh1.past_illness_siezure = "";
                pmh1.past_illness_sti = "";
                pmh1.past_illness_thyroid_disorders = "";
                pmh1.past_illness_other = "";
                pmh1.substance_abuse = "";
                pmh1.substance_abuse_other = "";
                pmh1.surgical_history = "";
                pmh1.surgical_history_other = "";
                pmh1.type_of_infertility = "";
                pmh1.type_of_infertility_other = "";
                pmh1.menstrution = "";
                pmh1.menstrution_days = "";
                pmh1.menstrution_interval = "";
                pmh1.menstrution_amount = "";
                pmh1.menstrution_lmp = "";
                pmh1.previous_treatment = "";
                pmh1.previous_treatment_other = "";
                pmh1.pap_smear = "";
                pmh1.pap_smear_other = "";
                pmh1.male_name = "";
                pmh1.male_drug_allery = "";
                pmh1.male_drug_allery_other = "";
                pmh1.male_past_illness_dialeteles = "";
                pmh1.male_past_illness_asihma = "";
                pmh1.male_past_illness_hypertention = "";
                pmh1.male_past_illness_liver_disease = "";
                pmh1.male_past_illness_tuberculosis = "";
                pmh1.male_past_illness_siezure = "";
                pmh1.male_past_illness_sti = "";
                pmh1.male_past_illness_thyroid_disorders = "";
                pmh1.male_past_illness_other = "";
                pmh1.male_substance_abuse = "";
                pmh1.male_substance_abuse_other = "";
                pmh1.male_smoking = "";
                pmh1.male_smoking_other = "";
                pmh1.male_drinking = "";
                pmh1.male_drinking_other = "";
                pmh1.male_drug = "";
                pmh1.male_drug_other = "";
                pmh1.male_surg = "";
                pmh1.male_surg_other = "";
                pmh1.male_infertility = "";
                pmh1.male_infertility_other = "";
                pmh1.past_illness_other_other = "";
                pmh1.male_past_illness_other_other = "";
            }
            return pmh1;
        }
    }
}
