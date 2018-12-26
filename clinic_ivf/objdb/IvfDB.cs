using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        public FEducationTypeDB fetDB;
        public FRelationDB frlDB;
        public FReligionDB frgDB;
        public FPatientRaceDB fprDB;
        public AppointmentOldDB appnOldDB;
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
            fetDB = new FEducationTypeDB(conn);
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
            appnOldDB = new AppointmentOldDB(conn);
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

            Console.WriteLine("ivfDB end");
        }
        public String genAppointmentRemarkPtt(DataRow row1)
        {
            String re = "";
            String hormo = "", tvs = "", opu = "", fet = "", beta = "", other = "", appn = "";
            hormo = row1[appnOldDB.appnOld.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
            tvs = row1[appnOldDB.appnOld.TVS].ToString().Equals("1") ? "TVS " : "";
            opu = row1[appnOldDB.appnOld.OPU].ToString().Equals("1") ? row1[appnOldDB.appnOld.OPUTime] != null ? "OPU [" + row1[appnOldDB.appnOld.OPUTime].ToString() + "]" : "OPU " + row1[appnOldDB.appnOld.OPUTime].ToString() : "";
            beta = row1[appnOldDB.appnOld.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
            fet = row1[appnOldDB.appnOld.ET_FET].ToString().Equals("1") ? row1[appnOldDB.appnOld.ET_FET_Time] != null ? "ET/FET [" + row1[appnOldDB.appnOld.ET_FET_Time].ToString() + "]" : "ET/FET" : "";
            other = row1[appnOldDB.appnOld.Other].ToString().Equals("1") ? row1[appnOldDB.appnOld.OtherRemark] != null ? "Other " + row1[appnOldDB.appnOld.OtherRemark].ToString() : "Other " : "";
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
    }
}
