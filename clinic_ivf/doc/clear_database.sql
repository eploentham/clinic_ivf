truncate  ivf_ww_new.Appointment;
truncate  ivf_ww_new.ApproveDiscount;
truncate  ivf_ww_new.BillHeader;
truncate  ivf_ww_new.BillDetail;
truncate  ivf_ww_new.DebtorHeader;
truncate  ivf_ww_new.DebtorDetail;
truncate  ivf_ww_new.FilePatient;
truncate ivf_ww_new.JobDoctor;
truncate ivf_ww_new.JobFETEmDev;
truncate  ivf_ww_new.JobLab;
truncate  ivf_ww_new.JobLabDetail;
truncate  ivf_ww_new.JobPx;
truncate  ivf_ww_new.JobPxDetail;
truncate  ivf_ww_new.JobSpecial;
truncate  ivf_ww_new.JobSpecialDetail;
truncate  ivf_ww_new.PackageDeposit;
truncate  ivf_ww_new.PackageDepositDetail;

truncate  ivf_ww_new.PackageSold;
truncate  ivf_ww_new.Patient;
truncate  ivf_ww_new.Visit;
truncate  ivf_ww_new.PR;
truncate  ivf_ww_new.ReceivePO;

truncate ivf_ww_new.t_visit;
truncate ivf_ww_new.t_patient;
truncate ivf_ww_new.lab_t_form_a;
truncate ivf_ww_new.lab_t_fet;
truncate ivf_ww_new.lab_t_opu;
truncate ivf_ww_new.lab_t_opu_embryo_dev;
truncate ivf_ww_new.lab_t_request;

truncate ivf_ww_new.t_doc_scan;
truncate ivf_ww_new.t_patient_appointment;
truncate ivf_ww_new.t_patient_appointment_text;
truncate ivf_ww_new.t_patient_image;


mysqldump -u root -h localhost -p ivf_ww_new > ivf_ww_new20190310.sql
tar -czvf /root/ivf_ww_new20190310.tar.gz ivf_ww_new20190310.sql