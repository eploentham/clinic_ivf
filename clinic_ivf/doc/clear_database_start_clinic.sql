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

update b_company 
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

