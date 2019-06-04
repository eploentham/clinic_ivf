delete FROM ivf_101.Appointment;
delete FROM ivf_101.ApproveDiscount;
delete FROM ivf_101.BillHeader;
delete FROM ivf_101.BillDetail;
delete FROM ivf_101.BillHeader_old;
delete FROM ivf_101.DebtorHeader;
delete FROM ivf_101.DebtorDetail;
delete FROM ivf_101.FilePatient;
delete from ivf_101.JobDoctor;
delete from ivf_101.JobFETEmDev;
delete FROM ivf_101.JobLab;
delete FROM ivf_101.JobLabDetail;
delete FROM ivf_101.JobPx;
delete FROM ivf_101.JobPxDetail;
delete FROM ivf_101.JobSpecial;
delete FROM ivf_101.JobSpecialDetail;
delete FROM ivf_101.PackageDeposit;
delete FROM ivf_101.PackageDepositDetail;

delete FROM ivf_101.PackageSold;
delete FROM ivf_101.Patient;
delete FROM ivf_101.Visit;
delete FROM ivf_101.PR;
delete FROM ivf_101.ReceivePO;

delete From ivf_101.t_visit;
delete From ivf_101.t_patient;
delete From ivf_101.lab_t_form_a;
delete From ivf_101.lab_t_fet;
delete From ivf_101.lab_t_opu;
delete From ivf_101.lab_t_opu_embryo_dev;
delete From ivf_101.lab_t_request;

delete From ivf_101.t_doc_scan;
delete From ivf_101.t_patient_appointment;
delete From ivf_101.t_patient_appointment_text;
delete From ivf_101.t_patient_image;

delete From ivf_101.lab_t_sperm;
delete From ivf_101.lab_t_request;
delete From ivf_101.lab_t_opu_embryo_dev;
delete From ivf_101.lab_t_opu;
delete From ivf_101.lab_t_form_a;
delete From ivf_101.lab_t_fet;
delete From ivf_101.nurse_t_egg_sti;
delete From ivf_101.nurse_t_egg_sti_day;

update ivf_101.b_company 
set receipt_cover_doc = 0
,fet_doc=0
,form_a_doc=0
,queue_doc=0
,vn_doc=0
,hn_doc=0
,opu_doc=0
,req_doc=0
,receipt_doc=0
,billing_doc=0;




delete FROM ivf_101_donor.Appointment;
delete FROM ivf_101_donor.ApproveDiscount;
delete FROM ivf_101_donor.BillHeader;
delete FROM ivf_101_donor.BillDetail;
delete FROM ivf_101_donor.BillHeader_old;
delete FROM ivf_101_donor.DebtorHeader;
delete FROM ivf_101_donor.DebtorDetail;
delete FROM ivf_101_donor.FilePatient;
delete from ivf_101_donor.JobDoctor;
delete from ivf_101_donor.JobFETEmDev;
delete FROM ivf_101_donor.JobLab;
delete FROM ivf_101_donor.JobLabDetail;
delete FROM ivf_101_donor.JobPx;
delete FROM ivf_101_donor.JobPxDetail;
delete FROM ivf_101_donor.JobSpecial;
delete FROM ivf_101_donor.JobSpecialDetail;
delete FROM ivf_101_donor.PackageDeposit;
delete FROM ivf_101_donor.PackageDepositDetail;

delete FROM ivf_101_donor.PackageSold;
delete FROM ivf_101_donor.Patient;
delete FROM ivf_101_donor.Visit;
delete FROM ivf_101_donor.PR;
delete FROM ivf_101_donor.ReceivePO;

delete From ivf_101_donor.t_visit;
delete From ivf_101_donor.t_patient;
delete From ivf_101_donor.lab_t_form_a;
delete From ivf_101_donor.lab_t_fet;
delete From ivf_101_donor.lab_t_opu;
delete From ivf_101_donor.lab_t_opu_embryo_dev;
delete From ivf_101_donor.lab_t_request;

delete From ivf_101_donor.t_doc_scan;
delete From ivf_101_donor.t_patient_appointment;
delete From ivf_101_donor.t_patient_appointment_text;
delete From ivf_101_donor.t_patient_image;

delete From ivf_101_donor.lab_t_sperm;
delete From ivf_101_donor.lab_t_request;
delete From ivf_101_donor.lab_t_opu_embryo_dev;
delete From ivf_101_donor.lab_t_opu;
delete From ivf_101_donor.lab_t_form_a;
delete From ivf_101_donor.lab_t_fet;
delete From ivf_101_donor.nurse_t_egg_sti;
delete From ivf_101_donor.nurse_t_egg_sti_day;

update ivf_101_donor.b_company 
set receipt_cover_doc = 0
,fet_doc=0
,form_a_doc=0
,queue_doc=0
,vn_doc=0
,hn_doc=0
,opu_doc=0
,req_doc=0
,receipt_doc=0
,billing_doc=0;

