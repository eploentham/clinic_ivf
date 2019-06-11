using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PatientMedicalHistory:Persistent
    {
        public String patient_medical_history_id { get; set; }
        public String t_patient_id { get; set; }
        public String patient_hn { get; set; }
        public String patient_name { get; set; }
        public String couple_name { get; set; }
        public String occupation { get; set; }
        public String contraception { get; set; }
        public String contraception_other { get; set; }
        public String drug_allergy { get; set; }
        public String drug_allergy_other { get; set; }
        public String past_illness_dialeteles { get; set; }
        public String past_illness_asihma { get; set; }
        public String past_illness_hypertention { get; set; }
        public String past_illness_liver_disease { get; set; }
        public String past_illness_tuberculosis { get; set; }
        public String past_illness_siezure { get; set; }
        public String past_illness_sti { get; set; }
        public String past_illness_thyroid_disorders { get; set; }
        public String past_illness_other { get; set; }
        public String substance_abuse { get; set; }
        public String substance_abuse_other { get; set; }
        public String surgical_history { get; set; }
        public String surgical_history_other { get; set; }
        public String type_of_infertility { get; set; }
        public String type_of_infertility_other { get; set; }
        public String menstrution { get; set; }
        public String menstrution_days { get; set; }
        public String menstrution_interval { get; set; }
        public String menstrution_amount { get; set; }
        public String menstrution_lmp { get; set; }
        public String previous_treatment { get; set; }
        public String previous_treatment_other { get; set; }
        public String pap_smear { get; set; }
        public String pap_smear_other { get; set; }
        public String male_name { get; set; }
        public String male_drug_allery { get; set; }
        public String male_drug_allery_other { get; set; }
        public String male_past_illness_dialeteles { get; set; }
        public String male_past_illness_asihma { get; set; }
        public String male_past_illness_hypertention { get; set; }
        public String male_past_illness_liver_disease { get; set; }
        public String male_past_illness_tuberculosis { get; set; }
        public String male_past_illness_siezure { get; set; }
        public String male_past_illness_sti { get; set; }
        public String male_past_illness_thyroid_disorders { get; set; }
        public String male_past_illness_other { get; set; }
        public String male_substance_abuse { get; set; }
        public String male_substance_abuse_other { get; set; }
        public String male_smoking { get; set; }
        public String male_smoking_other { get; set; }
        public String male_drinking { get; set; }
        public String male_drinking_other { get; set; }
        public String male_drug { get; set; }
        public String male_drug_other { get; set; }
        public String male_surg { get; set; }
        public String male_surg_other { get; set; }
        public String male_infertility { get; set; }
        public String male_infertility_other { get; set; }
        public String past_illness_other_other { get; set; }
        public String male_past_illness_other_other { get; set; }

    }
}
