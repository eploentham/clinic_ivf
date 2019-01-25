using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class IvfDB
    {
        ConnectDB conn;

        public StaffDB stfDB;
        public DepartmentDB deptDB;
        public PositionDB posiDB;
        //public PrefixDB pfxDB;
        public LabProcedureDB proceDB;
        public VisitOldDB vsOldDB;
        public BItemDB itmDB;
        public LabRequestDB lbReqDB;
        public CompanyDB copDB;
        public PatientDB pttDB;
        public AgentOldDB agnOldDB;
        public PatientOldDB pttOldDB;
        public DoctorOldDB dtrOldDB;
        public JobPxDB jobpxDB;
        public JobPxDetailDB jobpxdDB;

        public FPrefixDB fpfDB;
        public FBloodGroupDB fbgDB;
        public FSexDB sexDB;
        public FMarriageStatusDB fmsDB;
        public FRaceDB frcDB;
        public FNationDB fpnDB;
        public FEducationTypeDB ffetDB;
        public FRelationDB frlDB;
        public FReligionDB frgDB;
        public FPatientRaceDB fprDB;
        public AppointmentOldDB pApmOldDB;
        public BContractPlansDB crlDB;
        public BServicePointDB bspDB;
        public PatientImageDB pttImgDB;
        public OldJobSpecialDB oJsDB;
        public LabOpuDB opuDB;
        public LabOpuEmbryoDevDB opuEmDevDB;
        public PatientAppointmentDB pApmDB;
        public VisitDB vsDB;
        public FDocTypeDB fdtDB;
        public PatientAppointmentTextDB pApmtDB;
        public LabFormADB lFormaDB;
        public LabFetDB fetDB;

        public IvfDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            Console.WriteLine("ivfDB start");
            stfDB = new StaffDB(conn);
            deptDB = new DepartmentDB(conn);
            posiDB = new PositionDB(conn);
            //pfxDB = new PrefixDB(conn);
            proceDB = new LabProcedureDB(conn);
            vsOldDB = new VisitOldDB(conn);
            itmDB = new BItemDB(conn);
            lbReqDB = new LabRequestDB(conn);
            copDB = new CompanyDB(conn);
            fpfDB = new FPrefixDB(conn);
            fbgDB = new FBloodGroupDB(conn);
            sexDB = new FSexDB(conn);
            fmsDB = new FMarriageStatusDB(conn);
            fpnDB = new FNationDB(conn);
            ffetDB = new FEducationTypeDB(conn);
            frlDB = new FRelationDB(conn);
            frgDB = new FReligionDB(conn);
            fprDB = new FPatientRaceDB(conn);
            frcDB = new FRaceDB(conn);
            pttDB = new PatientDB(conn);
            pttOldDB = new PatientOldDB(conn);
            agnOldDB = new AgentOldDB(conn);
            crlDB = new BContractPlansDB(conn);
            bspDB = new BServicePointDB(conn);
            dtrOldDB = new DoctorOldDB(conn);
            pApmOldDB = new AppointmentOldDB(conn);
            pttImgDB = new PatientImageDB(conn);
            jobpxDB = new JobPxDB(conn);
            jobpxdDB = new JobPxDetailDB(conn);
            oJsDB = new OldJobSpecialDB(conn);
            opuDB = new LabOpuDB(conn);
            opuEmDevDB = new LabOpuEmbryoDevDB(conn);
            pApmDB = new PatientAppointmentDB(conn);
            vsDB = new VisitDB(conn);
            fdtDB = new FDocTypeDB(conn);
            pApmtDB = new PatientAppointmentTextDB(conn);
            lFormaDB = new LabFormADB(conn);
            fetDB = new LabFetDB(conn);

            Console.WriteLine("ivfDB end");
        }
        public String genAppointmentRemarkPtt(DataRow row1)
        {
            String re = "";
            String hormo = "", tvs = "", opu = "", fet = "", beta = "", other = "", appn = "";
            hormo = row1[pApmOldDB.pApmO.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
            tvs = row1[pApmOldDB.pApmO.TVS].ToString().Equals("1") ? "TVS " : "";
            opu = row1[pApmOldDB.pApmO.OPU].ToString().Equals("1") ? row1[pApmOldDB.pApmO.OPUTime] != null ? "OPU [" + row1[pApmOldDB.pApmO.OPUTime].ToString() + "]" : "OPU " + row1[pApmOldDB.pApmO.OPUTime].ToString() : "";
            beta = row1[pApmOldDB.pApmO.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
            fet = row1[pApmOldDB.pApmO.ET_FET].ToString().Equals("1") ? row1[pApmOldDB.pApmO.ET_FET_Time] != null ? "ET/FET [" + row1[pApmOldDB.pApmO.ET_FET_Time].ToString() + "]" : "ET/FET" : "";
            other = row1[pApmOldDB.pApmO.Other].ToString().Equals("1") ? row1[pApmOldDB.pApmO.OtherRemark] != null ? "Other " + row1[pApmOldDB.pApmO.OtherRemark].ToString() : "Other " : "";
            appn = row1["aaa"].ToString() + " " + hormo + " " + tvs + " " + opu + " " + beta + " " + fet + " " + other;
            return appn;
        }
        public String genAppointmentRemarkPttDonor(DataRow row1)
        {
            String e2 = "", lh = "", prl = "", fsh = "", appn = "", opu = "", tvs="";
            tvs = row1[pApmDB.pApm.tvs].ToString().Equals("1") ? "TVS Day "+ row1[pApmDB.pApm.tvs_day].ToString()+" [Time "+ row1[pApmDB.pApm.tvs_time].ToString() : "]";
            tvs = row1[pApmDB.pApm.tvs_day].ToString();
            e2 = row1[pApmDB.pApm.e2].ToString().Equals("1") ? "E2 " : "";
            lh = row1[pApmDB.pApm.lh].ToString().Equals("1") ? "LH " : "";
            prl = row1[pApmDB.pApm.prl].ToString().Equals("1") ? "PRL " : "";
            fsh = row1[pApmDB.pApm.fsh].ToString().Equals("1") ? "FSH " : "";
            opu = row1[pApmDB.pApm.opu].ToString().Equals("1") ? "OPU [Time " + row1[pApmDB.pApm.opu_time].ToString()+"] " + row1[pApmDB.pApm.doctor_anes].ToString() : "";
            appn = row1[pApmDB.pApm.patient_appointment_time].ToString() + " " + e2 + " " + lh + " " + prl + " " + fsh;
            return appn;
        }
        public String datetoDB(String dt)
        {
            DateTime dt1 = new DateTime();
            String re = "";
            if (dt != null)
            {
                if (!dt.Equals(""))
                {
                    // Thread แบบนี้ ทำให้ โปรแกรม ที่ไปลงที Xtrim ไม่เอา date ผิด
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us")
                    {
                        DateTimeFormat =
                        {
                            DateSeparator = "-"
                        }
                    };
                    if (DateTime.TryParse(dt, out dt1))
                    {
                        re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH")
                        {
                            DateTimeFormat =
                            {
                                DateSeparator = "-"
                            }
                        };
                        if (DateTime.TryParse(dt, out dt1))
                        {
                            re = dt1.ToString("yyyy-MM-dd");
                        }
                    }
                    //dt1 = DateTime.Parse(dt.ToString());

                }
            }
            return re;
        }
        public String dateTimetoDB(String dt)
        {
            DateTime dt1 = new DateTime();
            String re = "", tim = "";
            if (dt != null)
            {
                if (!dt.Equals(""))
                {
                    // Thread แบบนี้ ทำให้ โปรแกรม ที่ไปลงที Xtrim ไม่เอา date ผิด
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us")
                    {
                        DateTimeFormat =
                        {
                            DateSeparator = "-"
                        }
                    };
                    if (DateTime.TryParse(dt, out dt1))
                    {
                        re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH")
                        {
                            DateTimeFormat =
                            {
                                DateSeparator = "-"
                            }
                        };
                        if (DateTime.TryParse(dt, out dt1))
                        {
                            re = dt1.ToString("yyyy-MM-dd");
                        }
                    }
                    //dt1 = DateTime.Parse(dt.ToString());

                }
                tim = dt1.ToString("HH:mm:ss");
            }
            return re + " " + tim;
        }
        public LabRequest setLabRequest(String pttName, String vn, String doctorId, String remark, String hn, String dobfemale, String reqid, String itmcode)
        {
            LabRequest lbReq = new LabRequest();
            lbReq.req_id = "";
            lbReq.req_code = copDB.genReqDoc();
            lbReq.req_date = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            lbReq.hn_male = "";
            lbReq.name_male = "";
            lbReq.hn_female = hn;
            lbReq.name_female = pttName;
            lbReq.status_req = "1";
            lbReq.accept_date = "";
            lbReq.start_date = "";
            lbReq.result_date = "";
            lbReq.visit_id = "";
            lbReq.vn = vn;
            lbReq.active = "1";
            lbReq.remark = remark;
            lbReq.date_create = "";
            lbReq.date_modi = "";
            lbReq.date_cancel = "";
            lbReq.user_create = "";
            lbReq.user_modi = "";
            lbReq.user_cancel = "";
            //lbReq.item_id = "112";      //OPU
            lbReq.lab_id = "";
            lbReq.dob_donor = "";
            lbReq.dob_female = datetoDB(dobfemale);
            lbReq.dob_male = "";
            lbReq.hn_donor = "";
            lbReq.name_donor = "";
            lbReq.doctor_id = doctorId;
            lbReq.request_id = reqid;
            lbReq.item_id = itmcode;
            lbReq.form_a_id = "";
            return lbReq;
        }
        public LabOpu setOPU(String reqid)
        {
            LabOpu opu = new LabOpu();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByVnOld(lbreq.vn);
            opu.opu_id = "";
            opu.opu_code = copDB.genOPUDoc();
            opu.embryo_freez_stage = "";
            opu.embryoid_freez_position = "";
            opu.hn_male = lformA.hn_male;
            opu.hn_female = lbreq.hn_female;
            opu.name_male = lformA.name_male;
            opu.name_female = lbreq.name_female;
            opu.remark = lbreq.remark;
            opu.dob_female = lformA.dob_female;
            opu.dob_male = lformA.dob_male;
            opu.doctor_id = lbreq.doctor_id;
            opu.proce_id = "";
            opu.opu_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.req_id = reqid;
            opu.hn_donor = lformA.hn_donor;
            opu.name_donor = lformA.name_donor;
            //opu.dob_female = lbreq.dob_female;
            return opu;
        }
    }
}
