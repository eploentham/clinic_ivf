using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.objdb
{
    /*
     * 63-01-11         0015        ลงโปรแกรมที่ ww แล้ว การเงิน คิดเงินผิด
     * */
    public class IvfDB
    {
        ConnectDB conn;

        public StaffDB stfDB;
        public DepartmentDB deptDB;
        public PositionDB posiDB;
        //public PrefixDB pfxDB;
        public LabProcedureDB proceDB;
        public OldVisitDB ovsDB;
        public BItemDB itmDB;
        public LabRequestDB lbReqDB;
        public CompanyDB copDB;
        public PatientDB pttDB;
        public OldAgentDB oAgnDB;
        public OldPatientDB pttOldDB;
        public DoctorOldDB dtrOldDB;
        
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
        
        public LabOpuDB opuDB;
        public LabOpuEmbryoDevDB opuEmDevDB;
        public PatientAppointmentDB pApmDB;
        public VisitDB vsDB;
        public FDocTypeDB fdtDB;
        public PatientAppointmentTextDB pApmtDB;
        public LabFormADB lFormaDB;
        public LabFetDB fetDB;
        public OldLabItemDB oLabiDB;
        public OldSpecialItemDB oSItmDB;
        public OldStockDrugDB oStkdDB;
        public OldGroupDrugHeaderDB oGrpDb;
        public OldPackageHeaderDB oPkgDB;
        public OldPackageDetailDB oPkgdDB;
        public OldGroupDrugDetailDB oGudDB;
        public OldJobLabDetailDB oJlabdDB;
        public OldJobSpecialDB oJsDB;
        public OldJobSpecialDetailDB ojsdDB;
        public OldJobPxDB oJpxDB;
        public OldJobPxDetailDB oJpxdDB;
        public OldJobLabDB oJlabDB;
        public OldPackageSoldDB opkgsDB;
        public OldPackageDepositDB oPkgdpDB;
        public OldPackageDepositDetailDB oPkgdpdDB;
        public OldPackageSellThruDB opkgstDB;
        public DocGroupScanDB dgsDB;
        public DocGroupSubScanDB dgssDB;
        public DocScanDB dscDB;
        public OldBilldetailDB obildDB;
        public OldBillheaderDB obilhDB;
        public OldCashAccountDB ocaDB;
        public OldCreditCardAccountDB ocrDB;
        public OldBillGroupDB obilgDB;
        public OldFilePatientDB ofpDB;
        public NoteDB noteDB;
        public OrOperationGroupDB ordgDB;
        public OrOperationDB ordDB;
        public OrAnesthesiaDB oranesDB;
        public OrRequestDB orreqDB;
        public OrTOperationDB oropDB;
        public OldLabItemGroupDB olabgDB;
        public EggStiDB eggsDB;
        public EggStiDayDB eggsdDB;
        public StockSubNameDB stknDB;
        public StockRecDB stkrDB;
        public StockRecDetailDB stkrdDB;
        public StockDrawDB stkdDB;
        public StockDrawDetailDB stkddDB;
        public StockReturnDB stkreDB;
        public StockReturnDetailDB stkredDB;
        public LabSpermDB lspermDB;
        public LabOrderGroupDB logDB;
        public PatientMedicalHistoryDB pmhDB;
        public ClosedayDB cldDB;
        public ClosedayDetailDB clddDB;
        public LisDB lisDB;
        public LabResultDB lbresDB;
        public LabMethodDB lbmDB;
        public LabUnitDB lbuDB;
        public LabDataTypeComboBoxDB lbDtDB;
        public LabInterpretComboBoxDB lbinDB;
        public LabFormDay1DB lformDay1DB;
        public LabPrescriptionDB lPrescDB;
        public StockCardDB stkcDB;
        public StockCardEndYearDB stkeDB;
        public CustomerDB custDB;
        public AddressDB addrDB;
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
            ovsDB = new OldVisitDB(conn);
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
            pttOldDB = new OldPatientDB(conn);
            oAgnDB = new OldAgentDB(conn);
            crlDB = new BContractPlansDB(conn);
            bspDB = new BServicePointDB(conn);
            dtrOldDB = new DoctorOldDB(conn);
            pApmOldDB = new AppointmentOldDB(conn);
            pttImgDB = new PatientImageDB(conn);
            oJpxDB = new OldJobPxDB(conn);
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
            oLabiDB = new OldLabItemDB(conn);
            oSItmDB = new OldSpecialItemDB(conn);
            oStkdDB = new OldStockDrugDB(conn);
            oGrpDb = new OldGroupDrugHeaderDB(conn);
            oPkgDB = new OldPackageHeaderDB(conn);
            oPkgdDB = new OldPackageDetailDB(conn);
            oGudDB = new OldGroupDrugDetailDB(conn);
            oJlabdDB = new OldJobLabDetailDB(conn);
            ojsdDB = new OldJobSpecialDetailDB(conn);
            oJpxdDB = new OldJobPxDetailDB(conn);
            oJlabDB = new OldJobLabDB(conn);
            opkgsDB = new OldPackageSoldDB(conn);
            oPkgdpDB = new OldPackageDepositDB(conn);
            oPkgdpdDB = new OldPackageDepositDetailDB(conn);
            opkgstDB = new OldPackageSellThruDB(conn);
            dgsDB = new DocGroupScanDB(conn);
            dgssDB = new DocGroupSubScanDB(conn);
            dscDB = new DocScanDB(conn);
            ocaDB = new OldCashAccountDB(conn);
            ocrDB = new OldCreditCardAccountDB(conn);
            obildDB = new OldBilldetailDB(conn);
            obilhDB = new OldBillheaderDB(conn);
            obilgDB = new OldBillGroupDB(conn);
            ofpDB = new OldFilePatientDB(conn);
            noteDB = new NoteDB(conn);
            ordgDB = new OrOperationGroupDB(conn);
            ordDB = new OrOperationDB(conn);
            oranesDB = new OrAnesthesiaDB(conn);
            orreqDB = new OrRequestDB(conn);
            oropDB = new OrTOperationDB(conn);
            olabgDB = new OldLabItemGroupDB(conn);
            eggsDB = new EggStiDB(conn);
            eggsdDB = new EggStiDayDB(conn);
            stknDB = new StockSubNameDB(conn);
            stkrDB = new StockRecDB(conn);
            stkrdDB = new StockRecDetailDB(conn);
            stkdDB = new StockDrawDB(conn);
            stkddDB = new StockDrawDetailDB(conn);
            stkreDB = new StockReturnDB(conn);
            stkredDB = new StockReturnDetailDB(conn);
            lspermDB = new LabSpermDB(conn);
            logDB = new LabOrderGroupDB(conn);
            pmhDB = new PatientMedicalHistoryDB(conn);
            cldDB = new ClosedayDB(conn);
            clddDB = new ClosedayDetailDB(conn);
            lisDB = new LisDB(conn);
            lbresDB = new LabResultDB(conn);
            lbmDB = new LabMethodDB(conn);
            lbuDB = new LabUnitDB(conn);
            lbDtDB = new LabDataTypeComboBoxDB(conn);
            lbinDB = new LabInterpretComboBoxDB(conn);
            lformDay1DB = new LabFormDay1DB(conn);
            lPrescDB = new LabPrescriptionDB(conn);
            stkcDB = new StockCardDB(conn);
            stkeDB = new StockCardEndYearDB(conn);
            custDB = new CustomerDB(conn);
            addrDB = new AddressDB(conn);

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
        public String genAppointmentRemarkPtt1(DataRow row1)
        {
            String re = "";
            String hormo = "", tvs = "", opu = "", et = "", beta = "", other = "", appn = "", fet="", sperm = "", spermFreezing="", spermopu="", pesa="", e2="", lh="", fsh="", prl="", agent="", spermSA="", pttname="";
            hormo = row1[pApmDB.pApm.hormone_test].ToString().Equals("1") ? "Hormone Test " : "";
            tvs = row1[pApmDB.pApm.tvs].ToString().Equals("1") ? "TVS Day " + row1[pApmDB.pApm.tvs_day].ToString() + " [Time " + row1[pApmDB.pApm.tvs_time].ToString() + "]" : "" ;
            opu = row1[pApmDB.pApm.opu].ToString().Equals("1") ? row1[pApmDB.pApm.opu_time] != null ? "OPU [" + row1[pApmDB.pApm.opu_time].ToString() + "]" : "OPU " + row1[pApmDB.pApm.opu_time].ToString() : "";
            beta = row1[pApmDB.pApm.beta_hgc].ToString().Equals("1") ? "Beta HCG " : "";
            et = row1[pApmDB.pApm.et].ToString().Equals("1") ? row1[pApmDB.pApm.et_time] != null ? "ET [" + row1[pApmDB.pApm.et_time].ToString() + "]" : "ET" : "";
            fet = row1[pApmDB.pApm.fet].ToString().Equals("1") ? row1[pApmDB.pApm.fet_time] != null ? "FET [" + row1[pApmDB.pApm.fet_time].ToString() + "]" : "FET" : "";
            other = row1[pApmDB.pApm.other].ToString().Equals("1") ? row1[pApmDB.pApm.other_remark] != null ? "Other " + row1[pApmDB.pApm.other_remark].ToString() : "Other " : "";
            sperm = row1[pApmDB.pApm.sperm_collect].ToString().Equals("1") ? "Sperm Collect " : "";

            spermFreezing = row1[pApmDB.pApm.sperm_freezing].ToString().Equals("1") ? "Sperm Freezing " : "";
            spermopu = row1[pApmDB.pApm.sperm_opu].ToString().Equals("1") ? "Sperm OPU " : "";
            pesa = row1[pApmDB.pApm.pesa].ToString().Equals("1") ? "PESA/TESA " : "";

            e2 = row1[pApmDB.pApm.e2].ToString().Equals("1") ? "E2 " : "";
            lh = row1[pApmDB.pApm.lh].ToString().Equals("1") ? "LH " : "";
            fsh = row1[pApmDB.pApm.fsh].ToString().Equals("1") ? "FSH " : "";
            prl = row1[pApmDB.pApm.prl].ToString().Equals("1") ? "PRL " : "";
            //if (flagdonor.Equals("1"))      // donor ไม่เอา นามสกุล
            //{
            //    String[] tmp = row1["PatientName"].ToString().Split(' ');
            //    if (tmp.Length >= 3)
            //    {
            //        pttname = tmp[0] + " " + tmp[1];
            //    }
            //}
            //else
            //{
                pttname = row1["PatientName"] != null ? row1["PatientName"].ToString() : "";
            //}
            
            agent = !row1["AgentName"].ToString().Equals("") ? "Agent "+ row1["AgentName"].ToString() : "";

            spermSA = row1[pApmDB.pApm.sperm_sa].ToString().Equals("1") ? "Sperm SA " : "";

            //appn = row1[pApmDB.pApm.patient_appointment_time].ToString() + " " + hormo + " " + tvs + " " + opu + " " + beta + " " 
            //    + et + " " + fet + " " + sperm + " " 
            //    + spermFreezing + " " + spermopu + " " + pesa + " " + sperm + " "
            //    + e2 + " " + lh + " " + fsh + " " + prl + " " + agent + " "
            //    + other;
            
            lh = trimText(lh + " ");
            tvs = tvs + " ";
            sperm = sperm + " ";
            spermFreezing = spermFreezing + " ";
            pesa = pesa + " ";
            spermopu = spermopu + " ";
            opu = trimText(opu + " ");
            et = trimText(et + " ");
            fet = trimText(fet + " ");
            hormo = trimText(hormo + " ");
            beta = trimText(beta + " ");
            fsh = trimText(fsh + " ");
            prl = trimText(prl + " ");
            pttname = pttname + " ";
            agent = agent + " ";
            other = other + " ";
            appn = row1[pApmDB.pApm.patient_appointment_time].ToString() + " "
                + trimText(e2) + trimText(lh) + trimText(tvs) + trimText(sperm) + trimText(spermFreezing) + trimText(pesa) + trimText(spermopu) + trimText(opu) + trimText(et) + trimText(fet) + trimText(hormo) + trimText(beta) + trimText(fsh) + trimText(prl) + pttname + agent + other;
            return appn;
        }
        private String trimText(String txt)
        {
            String re = "";
            if (txt.Trim().Equals(""))
            {
                re = "";
            }
            else
            {
                re = txt.Trim() + " ";
            }
            return re;
        }
        public String genAppointmentRemarkPttDonor(DataRow row1)
        {
            String e2 = "", lh = "", prl = "", fsh = "", appn = "", opu = "", tvs="", et = "", fet = "", sperm="", spermFreezing = "", spermopu = "", pesa = "";
            tvs = row1[pApmDB.pApm.tvs].ToString().Equals("1") ? "TVS Day "+ row1[pApmDB.pApm.tvs_day].ToString()+" [Time "+ row1[pApmDB.pApm.tvs_time].ToString()+ "]" : "";
            //tvs = row1[pApmDB.pApm.tvs_day].ToString();
            e2 = row1[pApmDB.pApm.e2].ToString().Equals("1") ? "E2 " : "";
            lh = row1[pApmDB.pApm.lh].ToString().Equals("1") ? "LH " : "";
            prl = row1[pApmDB.pApm.prl].ToString().Equals("1") ? "PRL " : "";
            fsh = row1[pApmDB.pApm.fsh].ToString().Equals("1") ? "FSH " : "";
            sperm = row1[pApmDB.pApm.sperm_collect].ToString().Equals("1") ? "Sperm Collect " : "";

            spermFreezing = row1[pApmDB.pApm.sperm_freezing].ToString().Equals("1") ? "Sperm Freezing " : "";
            spermopu = row1[pApmDB.pApm.sperm_opu].ToString().Equals("1") ? "Sperm OPU " : "";
            pesa = row1[pApmDB.pApm.pesa].ToString().Equals("1") ? "PESA/TESA " : "";

            //e2 = row1[pApmDB.pApm.e2].ToString().Equals("1") ? "E2 " : "";
            //lh = row1[pApmDB.pApm.lh].ToString().Equals("1") ? "LH " : "";
            //fsh = row1[pApmDB.pApm.fsh].ToString().Equals("1") ? "FSH " : "";
            //prl = row1[pApmDB.pApm.prl].ToString().Equals("1") ? "PRL " : "";

            opu = row1[pApmDB.pApm.opu].ToString().Equals("1") ? "OPU [Time " + row1[pApmDB.pApm.opu_time].ToString()+"] " + row1[pApmDB.pApm.doctor_anes].ToString() : "";
            appn = row1[pApmDB.pApm.patient_appointment_time].ToString() + " " + e2 + " " + opu + " " + lh + " " + prl + " " + fsh + " " + sperm + " "
                + spermFreezing + " " + spermopu + " " + pesa + " " + sperm + " "
                //+ e2 + " " + lh + " " + fsh + " " + prl + " "
                ;
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
        public OrTOperation setOR(String reqid)
        {
            OrTOperation orop = new OrTOperation();
            OrRequest orrep = new OrRequest();
            orrep = orreqDB.selectByPk1(reqid);
            orop.or_id = "";
            orop.or_code = "";
            orop.or_req_id = orrep.or_req_id;
            orop.patient_hn = orrep.patient_hn;
            orop.patient_name = orrep.patient_name;
            orop.remark = orrep.remark;
            orop.date_create = "";
            orop.date_modi = "";
            orop.date_cancel = "";
            orop.user_create = "";
            orop.user_modi = "";
            orop.user_cancel = "";
            orop.active = "";
            orop.doctor_anesthesia_id = orrep.doctor_anesthesia_id;
            orop.doctor_surgical_id = orrep.doctor_surgical_id;
            orop.or_date = orrep.or_date;
            orop.or_time = orrep.or_time;
            orop.status_or = "1";
            orop.b_service_point_id = orrep.b_service_point_id;
            //orop.or_id = "";
            orop.opera_id = orrep.opera_id;
            orop.t_patient_id = orrep.t_patient_id;
            orop.status_urgent = orrep.status_urgent;
            orop.anesthesia_id = orrep.anesthesia_id;
            orop.operation_name = orrep.operation_name;
            orop.operation_group_name = orrep.operation_group_name;
            orop.anesthesia_name = orrep.anesthesia_name;
            orop.surgeon = orrep.surgeon;

            return orop;
        }
        public LabRequest setLabRequest(String reqid, String pttName, String vn, String doctorId, String remark, String hn, String dobfemale, String reqoldid, String itmcode
            , String hnmale, String namemale, String hndonor, String namedonor, String dobdornor, String vsid)
        {
            LabRequest lbReq = new LabRequest();
            lbReq.req_id = reqid;
            lbReq.req_code = copDB.genReqDoc();
            lbReq.req_date = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            lbReq.hn_male = hnmale;
            lbReq.name_male = namemale;
            lbReq.hn_female = hn;
            lbReq.name_female = pttName;
            lbReq.status_req = "1";
            lbReq.accept_date = "";
            lbReq.start_date = "";
            lbReq.result_date = "";
            lbReq.visit_id = vsid;
            lbReq.vn = vn;
            lbReq.active = "1";
            lbReq.remark = remark;
            lbReq.date_create = "";
            lbReq.date_modi = "";
            lbReq.date_cancel = "";
            lbReq.user_create = "";
            lbReq.user_modi = "";
            lbReq.user_cancel = "";
            lbReq.dob_female = datetoDB(dobfemale);
            //lbReq.item_id = "112";      //OPU
            lbReq.lab_id = "";
            lbReq.dob_donor = datetoDB(dobdornor);
            lbReq.dob_female = "";
            lbReq.dob_male = "";
            lbReq.hn_donor = hndonor;
            lbReq.name_donor = namedonor;
            lbReq.doctor_id = doctorId;
            lbReq.request_id = reqoldid;
            lbReq.item_id = itmcode;
            lbReq.form_a_id = "";
            lbReq.req_time = System.DateTime.Now.ToString("hh:mm:ss");
            return lbReq;
        }
        public LabRequest setLabRequest(String pttName, String vn, String doctorId, String remark, String hn, String dobfemale, String reqoldid, String itmcode
            ,String hnmale, String namemale, String hndonor, String namedonor, String dobdornor, String vsid)
        {
            LabRequest lbReq = new LabRequest();
            lbReq.req_id = "";
            lbReq.req_code = copDB.genReqDoc();
            lbReq.req_date = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            lbReq.hn_male = hnmale;
            lbReq.name_male = namemale;
            lbReq.hn_female = hn;
            lbReq.name_female = pttName;
            lbReq.status_req = "1";
            lbReq.accept_date = "";
            lbReq.start_date = "";
            lbReq.result_date = "";
            lbReq.visit_id = vsid;
            lbReq.vn = vn;
            lbReq.active = "1";
            lbReq.remark = remark;
            lbReq.date_create = "";
            lbReq.date_modi = "";
            lbReq.date_cancel = "";
            lbReq.user_create = "";
            lbReq.user_modi = "";
            lbReq.user_cancel = "";
            lbReq.dob_female = datetoDB(dobfemale);
            //lbReq.item_id = "112";      //OPU
            lbReq.lab_id = "";
            lbReq.dob_donor = datetoDB(dobdornor);
            lbReq.dob_female = "";
            lbReq.dob_male = "";
            lbReq.hn_donor = hndonor;
            lbReq.name_donor = namedonor;
            lbReq.doctor_id = doctorId;
            lbReq.request_id = reqoldid;
            lbReq.item_id = itmcode;
            lbReq.form_a_id = "";
            lbReq.req_time = System.DateTime.Now.ToString("hh:mm:ss");
            return lbReq;
        }
        public LabOpu setOPU(String reqid)
        {
            LabOpu opu = new LabOpu();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByVnOld(lbreq.vn);
            setOPU(reqid, lformA.form_a_id);
            return opu;
        }
        public LabOpu setOPU(String reqid, String formaid)
        {
            LabOpu opu = new LabOpu();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByPk1(formaid);
            opu.opu_id = "";
            opu.opu_code = copDB.genOPUDoc();
            opu.embryo_freez_stage = "";
            opu.embryoid_freez_position = "";
            opu.hn_male = lformA.hn_male;
            opu.hn_female = lformA.hn_female;
            opu.name_male = lformA.name_male;
            opu.name_female = lformA.name_female;
            opu.remark = lformA.remark;
            opu.dob_female = lformA.dob_female;
            opu.dob_male = lformA.dob_male;
            opu.doctor_id = lformA.doctor_id;
            opu.proce_id = "";
            //opu.opu_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.opu_date = lformA.opu_date;
            opu.opu_time = lformA.opu_time;
            opu.req_id = reqid;
            opu.hn_donor = lformA.hn_donor;
            opu.name_donor = lformA.name_donor;
            opu.dob_donor = lformA.dob_donor;
            return opu;
        }
        public LabFet setFET(String reqid)
        {
            LabFet fet = new LabFet();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByVnOld(lbreq.vn);
            fet.fet_id = "";
            fet.fet_code = copDB.genFETDoc();
            //opu.embryo_freez_stage = "";
            //opu.embryoid_freez_position = "";
            fet.hn_male = lformA.hn_male;
            fet.hn_female = lformA.hn_female;       // ให้ยึดจาก Lab Form A ถ้าข้อมูลไม่ถูกต้อง ให้แก้ที่ Lab Form A
            fet.name_male = lformA.name_male;
            fet.name_female = lformA.name_female;       // ให้ยึดจาก Lab Form A ถ้าข้อมูลไม่ถูกต้อง ให้แก้ที่ Lab Form A
            fet.remark = lformA.fet_remark;       // ให้ยึดจาก Lab Form A ถ้าข้อมูลไม่ถูกต้อง ให้แก้ที่ Lab Form A
            fet.dob_female = lformA.dob_female;       // ให้ยึดจาก Lab Form A ถ้าข้อมูลไม่ถูกต้อง ให้แก้ที่ Lab Form A
            fet.dob_male = lformA.dob_male;
            fet.doctor_id = lbreq.doctor_id;
            fet.proce_id = "";
            fet.fet_date = lformA.embryo_tranfer_date;
            fet.req_id = reqid;
            fet.hn_donor = lformA.hn_donor;
            fet.name_donor = lformA.name_donor;
            fet.dob_female = lbreq.dob_female;
            return fet;
        }
        public LabSperm setSperm(String reqid, String labsperm)
        {
            LabSperm opu = new LabSperm();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByVnOld(lbreq.vn);
            opu.sperm_id = "";
            opu.sperm_code = "";
            //opu.embryo_freez_stage = "";
            //opu.embryoid_freez_position = "";
            opu.hn_male = lformA.hn_male;
            opu.hn_female = lbreq.hn_female;
            if (opu.hn_female.Equals(""))     //ซ่อม เพราะใน request ไม่มี hn แต่มี name
            {
                Patient ptt = new Patient();
                ptt = pttDB.selectByHn(lformA.hn_male);
                opu.hn_female = ptt.patient_hn_1;
            }
            
            opu.name_male = lformA.name_male;
            opu.name_female = lbreq.name_female;
            opu.remark = lbreq.remark;
            opu.dob_female = lformA.dob_female;
            opu.dob_male = lformA.dob_male;
            opu.doctor_id = lbreq.doctor_id;
            opu.status_lab_sperm = labsperm;
            opu.sperm_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.req_id = reqid;
            opu.sperm_analysis_date_start = lformA.sperm_analysis_date_start;
            opu.spern_freezing_date_start = lformA.sperm_freezing_date_start;
            opu.iui_date = lformA.iui_date;
            opu.pasa_tese_date = lformA.pasa_tese_date;
            opu.form_a_id = lformA.form_a_id;

            //opu.dob_female = lbreq.dob_female;
            return opu;
        }
        public void calIncludeExtraPricePxOldProgram(String vn)
        {
            String include = "", extra = "";
            include = oJpxdDB.selectSumIncludePriceCashierOldProgramByVN(vn);
            extra = oJpxdDB.selectSumExtraPriceCashierOldProgramByVN(vn);
            oJpxDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void calIncludeExtraPricePx(String vn)
        {
            String include = "", extra = "";
            include = oJpxdDB.selectSumIncludePriceByVN(vn);
            extra = oJpxdDB.selectSumExtraPriceByVN(vn);
            oJpxDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void calIncludeExtraPricelabOldProgram(String vn)
        {
            String include = "", extra = "";
            include = oJlabdDB.selectSumIncludePriceByVNOldProgram(vn);
            extra = oJlabdDB.selectSumExtraPriceByVNOldProgram(vn);
            oJlabDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void calIncludeExtraPricelab(String vn)
        {
            String include = "", extra = "";
            include = oJlabdDB.selectSumIncludePriceByVN(vn);
            extra = oJlabdDB.selectSumExtraPriceByVN(vn);
            oJlabDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void calIncludeExtraPriceSpecial(String vn)
        {
            String include = "", extra = "";
            include = ojsdDB.selectSumIncludePriceByVN(vn);
            extra = ojsdDB.selectSumExtraPriceByVN(vn);
            oJsDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void calIncludeExtraPriceSpecialOldProgram(String vn)
        {
            String include = "", extra = "";
            include = ojsdDB.selectSumIncludePriceByVNOldProgram(vn);
            extra = ojsdDB.selectSumExtraPriceByVNOldProgram(vn);
            oJsDB.updateIncludePriceFormDetail(include, extra, vn);
        }
        public void nurseFinish(String vn, String userid)
        {
            //    $this->px->cal_px($VN);
            //$this->lab->cal_lab($VN);
            //$this->special->cal_spc($VN);
            //$this->visit->send_to_account($VN);

  //          $this->db->query('update Visit set LVSID=VSID Where VN="'.$VN.'"');
		//$this->db->query('update Visit set VSID="160" Where VN="'.$VN.'"');

            calIncludeExtraPricePx(vn);
            calIncludeExtraPricelab(vn);
            calIncludeExtraPriceSpecial(vn);
            vsDB.updateCloseStatusNurseByVN(vn, userid);
            ovsDB.updateStatusNurseFinish(vn);
        }
        public void nurseFinishCashierOldProgram(String vn, String userid)
        {
            //    $this->px->cal_px($VN);
            //$this->lab->cal_lab($VN);
            //$this->special->cal_spc($VN);
            //$this->visit->send_to_account($VN);

            //          $this->db->query('update Visit set LVSID=VSID Where VN="'.$VN.'"');
            //$this->db->query('update Visit set VSID="160" Where VN="'.$VN.'"');

            calIncludeExtraPricePxOldProgram(vn);
            calIncludeExtraPricelabOldProgram(vn);
            calIncludeExtraPriceSpecialOldProgram(vn);
            vsDB.updateCloseStatusNurseByVN(vn, userid);
            ovsDB.updateStatusNurseFinish(vn);
        }
        public void setPx(String vn, String hn, String pid, String drugid)
        {
            oJpxDB.setJobPx(vn, hn, pid);

        }
        public void PackageClose(String pkgsid)
        {
            //    $this->package->set_packageStatus2($PCKSID);
                    //$this->db->query("UPDATE PackageSold Set Status='3' Where PCKSID='".$PCKSID."'");
        //            $uSq1 = "UPDATE PackageDeposit SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
        //$           uSq2 = "UPDATE PackageDepositDetail SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
            //$this->package->close_packageDPS($PCKSID);
            opkgsDB.updateStatus3(pkgsid);
            oPkgdpDB.updateStatusDPS(pkgsid);
            oPkgdpdDB.updateStatusDPS(pkgsid);

        }
        public String PackageAdd(OldPackageSold opkgs, String userid)
        {
            DataTable dt = new DataTable();
            String re = "";
            re = opkgsDB.insert(opkgs, "");
            dt = oPkgdDB.selectByPkgId(opkgs.PCKID);
            foreach(DataRow row in dt.Rows)
            {
                OldPackageDeposit oPkgdp = new OldPackageDeposit();
                oPkgdp.PCKDPSID = "";
                oPkgdp.PCKSID = re;
                oPkgdp.PID = opkgs.PID;
                oPkgdp.ItemType = row["ItemType"].ToString();
                oPkgdp.ItemID = row["ItemID"].ToString();
                oPkgdp.ItemName = row["ItemName"].ToString();
                oPkgdp.QTY = row["QTY"].ToString();
                oPkgdp.QTYused = "0";
                oPkgdp.isPCKclosed = "0";
                oPkgdpDB.insertPackageDeposit(oPkgdp, userid);
            }
            return re;
        }
        public void PxSetAdd(String duid, String pid, String pids, String vn, String extra, String row1, String qty, String usaget, String usagee, String duname, String price)
        {
            //$queGD = $this->package->get_groupDrugDetail($_POST['GDID']);
            //foreach ($queGD->result() as $row) {
            //$aData['DUID'] = $row->DUID;
            //$aData['QTY'] = $row->QTY;

            //$this->package->clear_JobPx_package($VN, $aData['DUID']);
            //$this->px->add_jobpxdetail($aData);
            //$this->package->update_jobPx_package($VN, $aData['DUID'], $aData['QTY'], $aData['Extra']);
            //}

            //DataTable dtDrugSet = new DataTable();
            //dtDrugSet = oGudDB.selectByGdId(gdid);
            //foreach(DataRow row in dtDrugSet.Rows)
            //{
                //String duid = "";
                //duid = row["DUID"].ToString();
                //qty = row["QTY"].ToString();
            OldJobPxDetail oJpxd = new OldJobPxDetail();
            //OldStockDrug ostkD = new OldStockDrug();
            Decimal price1 = 0, qty1 = 0;
            Decimal.TryParse(price, out price1);
            Decimal.TryParse(qty, out qty1);
            //ostkD = oStkdDB.selectByPk1(duid);
            oJpxd.VN = vn;
            oJpxd.DUID = duid;
            oJpxd.QTY = qty;
            oJpxd.Extra = extra;
            //oJpxd.Price = price;
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = duname;
            oJpxd.Comment = "";
            oJpxd.TUsage = usaget;
            oJpxd.EUsage = usagee;
            oJpxd.row1 = row1;
            oJpxd.pckdid = "";
            //oJpxd.price1 = price;
            decimal qty11 = 0, price11 = 0;
            Decimal.TryParse(qty, out qty11);
            Decimal.TryParse(price, out price11);
            oJpxd.price1 = price;
            oJpxd.Price = price;
            oJpxd.status_print = "0";
            oJpxd.status_up_stock = "0";
            oJpxdDB.insert(oJpxd, "");
            //}

        }
        public void PxSetAdd(String duid, String pid, String pids, String vn, String extra, String row1, String qty, String usaget, String usagee, String duname, String price, String flagOld)
        {
            OldJobPxDetail oJpxd = new OldJobPxDetail();
            //OldStockDrug ostkD = new OldStockDrug();
            Decimal price1 = 0, qty1 = 0;
            Decimal.TryParse(price, out price1);
            Decimal.TryParse(qty, out qty1);
            //ostkD = oStkdDB.selectByPk1(duid);
            oJpxd.VN = vn;
            oJpxd.DUID = duid;
            oJpxd.QTY = qty;
            oJpxd.Extra = extra;
            //oJpxd.Price = price;
            if (flagOld.Equals("old"))
            {
                decimal qty11 = 0, price11 = 0;
                Decimal.TryParse(qty, out qty11);
                Decimal.TryParse(oJpxd.Price, out price11);
                oJpxd.Price = (qty11 * price11).ToString();
                oJpxd.price1 = oJpxd.Price;
            }
            else
            {
                oJpxd.Price = oJpxd.Price;
            }
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = duname;
            oJpxd.Comment = "";
            oJpxd.TUsage = usaget;
            oJpxd.EUsage = usagee;
            oJpxd.row1 = row1;
            oJpxd.pckdid = "";
            oJpxd.status_print = "0";
            oJpxd.status_up_stock = "0";
            oJpxdDB.insert(oJpxd, "");
            //}
        }
        public void PxAdd(String duid, String qty, String pid, String pids, String vn, String extra, String row1, String usage, String pckdid)
        {
            OldJobPxDetail oJpxd = new OldJobPxDetail();
            OldStockDrug ostkD = new OldStockDrug();
            Decimal price1 = 0, qty1 = 0;
            ostkD = oStkdDB.selectByPk1(duid);
            
            Decimal.TryParse(ostkD.Price, out price1);
            Decimal.TryParse(qty, out qty1);
            
            oJpxd.VN = vn;
            oJpxd.DUID = duid;
            oJpxd.QTY = qty;
            oJpxd.Extra = extra;
            oJpxd.Price = ostkD.Price;
            oJpxd.price1 = ostkD.Price;
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = ostkD.DUName;
            oJpxd.Comment = "";
            oJpxd.TUsage = usage;
            oJpxd.EUsage = ostkD.EUsage;
            oJpxd.row1 = row1;
            oJpxd.pckdid = pckdid;
            oJpxd.status_print = "0";
            oJpxd.status_up_stock = "0";
            oJpxdDB.insert(oJpxd, "");
        }
        public void PxAdd(String duid, String qty, String pid, String pids, String vn, String extra, String row1, String usage, String flagOld, String pckdid)
        {       //      0015
            OldJobPxDetail oJpxd = new OldJobPxDetail();
            OldStockDrug ostkD = new OldStockDrug();
            Decimal price1 = 0, qty1 = 0;
            ostkD = oStkdDB.selectByPk1(duid);

            Decimal.TryParse(ostkD.Price, out price1);
            Decimal.TryParse(qty, out qty1);

            oJpxd.VN = vn;
            oJpxd.DUID = duid;
            oJpxd.QTY = qty.Replace(".00","");
            oJpxd.Extra = extra;
            if (flagOld.Equals("old"))
            {
                decimal qty11 = 0, price11 = 0;
                Decimal.TryParse(qty, out qty11);
                Decimal.TryParse(ostkD.Price, out price11);
                oJpxd.Price = (qty11 * price11).ToString();
                oJpxd.price1 = ostkD.Price;
            }
            else
            {
                oJpxd.Price = ostkD.Price;
                oJpxd.price1 = ostkD.Price;
            }
            
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = ostkD.DUName;
            oJpxd.Comment = "";
            oJpxd.TUsage = usage;
            oJpxd.EUsage = ostkD.EUsage;
            oJpxd.row1 = row1;
            oJpxd.pckdid = pckdid;
            oJpxd.status_print = "0";
            oJpxd.status_up_stock = "0";
            oJpxdDB.insert(oJpxd, "");
        }
        public void LabAdd(String lid, String qty, String pid, String pids, String vn, String extra, String sp1v, String sp2v, String sp3v, String sp4v, String sp5v, String sp6v, String sp7v, String row1, String lidordergrp, String status_amt, String status_order_group, String pckdid)
        {
            OldJobLabDetail jlabD = new OldJobLabDetail();
            OldLabItem olab = new OldLabItem();
            olab = oLabiDB.selectByPk1(lid);
            jlabD.ID = "";
            jlabD.VN = vn;
            jlabD.LID = lid;
            jlabD.Extra = extra;
            jlabD.Price = olab.Price;
            jlabD.Status = "1";
            jlabD.PID = pid;
            jlabD.PIDS = pids;
            jlabD.LName = olab.LName;
            jlabD.SP1V = sp1v;
            jlabD.SP2V = sp2v;
            jlabD.SP3V = sp3v;
            jlabD.SP4V = sp4v;
            jlabD.SP5V = sp5v;
            jlabD.SP6V = sp6v;
            jlabD.SP7V = sp7v;
            jlabD.SubItem = "";
            jlabD.FileName = "";
            jlabD.Worker1 = olab.WorkerGroup1;
            jlabD.Worker2 = olab.WorkerGroup2;
            jlabD.Worker3 = olab.WorkerGroup3;
            jlabD.Worker4 = olab.WorkerGroup4;
            jlabD.LGID = olab.LGID;
            jlabD.QTY = qty.Replace(".00","");
            jlabD.row1 = row1;
            jlabD.status_show_qty = olab.status_show_qty;
            jlabD.status_amt = status_amt;
            jlabD.status_order_group = status_order_group;
            jlabD.lab_order_id = lidordergrp;
            jlabD.price1 = olab.Price;
            jlabD.pckdid = pckdid;

            oJlabdDB.insert(jlabD, "");
        }
        public void LabAdd(String lid, String qty, String pid, String pids, String vn, String extra, String sp1v, String sp2v, String sp3v, String sp4v, String sp5v, String sp6v, String sp7v, String row1
            , String lidordergrp, String status_amt, String status_order_group, String flagOld, String pckdid)
        {
            OldJobLabDetail jlabD = new OldJobLabDetail();
            OldLabItem olab = new OldLabItem();
            olab = oLabiDB.selectByPk1(lid);
            jlabD.ID = "";
            jlabD.VN = vn;
            jlabD.LID = lid;
            jlabD.Extra = extra;
            if (flagOld.Equals("old"))
            {
                decimal qty11 = 0, price11 = 0;
                Decimal.TryParse(qty, out qty11);
                Decimal.TryParse(olab.Price, out price11);
                
                //if (olab.status_order_group.Equals("1"))
                //{
                //    jlabD.Price = "0";
                //    jlabD.price1 = "0";
                //}
                //else
                //{
                    jlabD.Price = (qty11 * price11).ToString();
                    jlabD.price1 = olab.Price;
                //}
            }
            else
            {
                jlabD.Price = olab.Price;
            }
            //jlabD.Price = olab.Price;
            jlabD.Status = "1";
            jlabD.PID = pid;
            jlabD.PIDS = pids;
            jlabD.LName = olab.LName;
            jlabD.SP1V = sp1v;
            jlabD.SP2V = sp2v;
            jlabD.SP3V = sp3v;
            jlabD.SP4V = sp4v;
            jlabD.SP5V = sp5v;
            jlabD.SP6V = sp6v;
            jlabD.SP7V = sp7v;
            jlabD.SubItem = "";
            jlabD.FileName = "";
            jlabD.Worker1 = olab.WorkerGroup1;
            jlabD.Worker2 = olab.WorkerGroup2;
            jlabD.Worker3 = olab.WorkerGroup3;
            jlabD.Worker4 = olab.WorkerGroup4;
            jlabD.LGID = olab.LGID;
            jlabD.QTY = qty.Replace(".00", "");
            jlabD.row1 = row1;
            jlabD.status_show_qty = olab.status_show_qty;
            jlabD.status_amt = status_amt;
            jlabD.status_order_group = status_order_group;
            jlabD.lab_order_id = lidordergrp;
            jlabD.pckdid = pckdid;
            oJlabdDB.insert(jlabD, "");
        }
        public void SpecialAdd(String sid, String qty, String pid, String pids, String vn, String extra, String w1uid, String w2uid, String w3uid, String w4uid, String row1, String pckdid)
        {
            OldJobSpecialDetail ojsd = new OldJobSpecialDetail();
            OldSpecialItem ojs = new OldSpecialItem();
            ojs = oSItmDB.selectByPk1(sid);
            ojsd.ID = "";
            ojsd.VN = vn;
            ojsd.SID = sid;
            ojsd.SName = ojs.SName;
            ojsd.Extra = extra;
            ojsd.Price = ojs.Price;
            ojsd.Status = "1";
            ojsd.PID = pid;
            ojsd.PIDS = pids;
            ojsd.W1UID = w1uid;
            ojsd.W2UID = w2uid;
            ojsd.W3UID = w3uid;
            ojsd.W4UID = w4uid;
            ojsd.FileName = "";
            ojsd.status_req_accept = "0";
            ojsd.req_id = "";
            ojsd.row1 = row1;
            ojsd.qty = qty;
            ojsd.bill_group_id = ojs.BillGroupID;
            ojsd.price1 = ojs.Price;
            ojsd.pckdid = pckdid;
            ojsdDB.insert(ojsd, "");
        }
        public void SpecialAdd(String sid, String qty, String pid, String pids, String vn, String extra, String w1uid, String w2uid, String w3uid, String w4uid, String row1, String flagOld, String pckdid)
        {
            OldJobSpecialDetail ojsd = new OldJobSpecialDetail();
            OldSpecialItem ojs = new OldSpecialItem();
            ojs = oSItmDB.selectByPk1(sid);
            ojsd.ID = "";
            ojsd.VN = vn;
            ojsd.SID = sid;
            ojsd.SName = ojs.SName;
            ojsd.Extra = extra;
            if (flagOld.Equals("old"))
            {
                decimal qty11 = 0, price11 = 0;
                Decimal.TryParse(qty, out qty11);
                Decimal.TryParse(ojs.Price, out price11);
                ojsd.Price = (qty11 * price11).ToString();
                ojsd.price1 = ojs.Price;
            }
            else
            {
                ojsd.Price = ojs.Price;
            }
            //ojsd.Price = ojs.Price;
            ojsd.Status = "1";
            ojsd.PID = pid;
            ojsd.PIDS = pids;
            ojsd.W1UID = w1uid;
            ojsd.W2UID = w2uid;
            ojsd.W3UID = w3uid;
            ojsd.W4UID = w4uid;
            ojsd.FileName = "";
            ojsd.status_req_accept = "0";
            ojsd.req_id = "";
            ojsd.row1 = row1;
            ojsd.qty = qty;
            ojsd.bill_group_id = ojs.BillGroupID;
            ojsd.pckdid = pckdid;
            ojsdDB.insert(ojsd, "");
        }
        public void calPx(String vn)
        {
        //    $query = $this->db->query('select sum(Price) as Inc from JobPxDetail Where VN="'. $VN. '" and Extra="0"');
        //    if ($query->num_rows() != 0) {
        //    $Include_Pkg_Price = $query->row()->Inc;
        //    } else {
        //    $Include_Pkg_Price = 0;
        //    };
        //$query = $this->db->query('select sum(Price) as Extra from JobPxDetail Where VN="'. $VN. '" and Extra="1"');
        //    if ($query->num_rows() != 0) {
        //    $Extra_Pkg_Price = $query->row()->Extra;
        //    } else {
        //    $Extra_Pkg_Price = 0;
        //    };
        //$Total_Price = $Include_Pkg_Price + $Extra_Pkg_Price;
        //$this->db->query('update JobPx Set Include_Pkg_Price="'. $Include_Pkg_Price. '", Extra_Pkg_Price="'. $Extra_Pkg_Price. '", Total_Price="'. $Total_Price. '", Status="2" Where VN="'. $VN. '"');
            String sql = "", re="", inc="", extra="";
            DataTable dt = new DataTable();
            sql = "Select sum(Price) as inc from JobPxDetail Where VN = '"+vn+" and Extra='0' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                inc = dt.Rows[0]["inc"].ToString();
            }
            sql = "Select sum(Price) as extra from JobPxDetail Where VN = '"+vn+"' and Extra = '1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                extra = dt.Rows[0]["extra"].ToString();
            }
        }
        public void genCloseDayBill(String cldid)
        {
            String sql = "",re="";
            sql = "Insert into t_closeday_bill Select * From BillHeader Where closeday_id='"+ cldid + "' ";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            sql = "Insert into t_closeday_bill_detail Select * From BillDetail Where closeday_id='"+ cldid + "' ";
            re = conn.ExecuteNonQuery(conn.conn, sql);
        }
        public void VoidLabReult(String resid, String userId)
        {
            long chk = 0;
            String re = lbresDB.voidLabResult(resid, userId);
            if(long.TryParse(re, out chk))
            {
                //    chk = 0;
                //    String re1 = lbresDB.updateStatusProcess(resid);
                //    if (long.TryParse(re1, out chk))
                //    {
                LabResult res = new LabResult();
                    res = lbresDB.selectByPk(resid);
                //String re2 = lbReqDB.UpdateStatusRequestRequestAgain(res.req_id);
                String re2 = lbReqDB.VoidRequest(res.req_id, userId);
                //}
            }
        }
        public void VoidBill(String vn, String userId)
        {
            obilhDB.voidBillByVN(vn, userId);
            obildDB.voidBillDetailByVN(vn, userId);
        }
        public void DeleteBill1(String vn)
        {
            obilhDB.delete(vn);
            obildDB.delete(vn);
        }
        public String getBill(String vn, String agentId, String userId)
        {
            /* Step 1.
             * $this->db->query('delete from DebtorHeader Where VN="'.$VN.'"');
             * $this->db->query('delete from DebtorDetail Where VN="'.$VN.'"');
             * $this->db->query('delete from BillHeader Where VN="'.$VN.'"');
             * $this->db->query('delete from BillDetail Where VN="'.$VN.'"');
            */
            DataTable dt = new DataTable();
            String re = "";
            String sql = "delete from DebtorHeader Where VN='"+vn+"'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            sql = "delete from DebtorDetail Where VN='" + vn + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            sql = "";
            VoidBill(vn, userId);
            /* Step 2.
             * Update PackageSold
             * $queryP = $this->db->query('Select * from PackageSold Where VN="'.$VN.'"');
             * if ($queryP->num_rows()>0){
             * $rowP=$queryP->row();
             * if ($rowP->P4BDetailID > 0){
             * $this->db->query('Update PackageSold set P4BDetailID=0 Where VN="'.$VN.'" and P4BDetailID!=9999');
             * } else {
             * if ($rowP->P3BDetailID > 0){
             *  $this->db->query('Update PackageSold set P3BDetailID=0 Where VN="'.$VN.'" and P3BDetailID!=9999');
             *  } else {
             *  if ($rowP->P2BDetailID > 0){
             *  $this->db->query('Update PackageSold set P2BDetailID=0 Where VN="'.$VN.'" and P2BDetailID!=9999');
             *  } else {
             *  $this->db->query('Update PackageSold set P1BDetailID=0 Where VN="'.$VN.'" and P1BDetailID!=9999');
             *  }   }   }   };
            */
            opkgsDB.updateP4321(vn);
            /* Step 3.
             * get visit
             * 
             */
            VisitOld ovs = new VisitOld();
            ovs = ovsDB.selectByPk1(vn);
            /* Step 4.
             * set Include_Pkg_Price, Extra_Pkg_Price
             * $query = $this->db->query('Select Include_Pkg_Price, Extra_Pkg_Price from JobLab Where VN="' . $VN . '"');
             * if ($query->num_rows() != 0) {
             * $row = $query->row();
             * $Include_Pkg_Price = $row->Include_Pkg_Price;
             * $Extra_Pkg_Price = $row->Extra_Pkg_Price;
             * };
             * $query = $this->db->query('Select Include_Pkg_Price, Extra_Pkg_Price from JobPx Where VN="' . $VN . '"');
             * if ($query->num_rows() != 0) {
             * $row = $query->row();
             * $Include_Pkg_Price = $row->Include_Pkg_Price + $Include_Pkg_Price;
             * $Extra_Pkg_Price = $row->Extra_Pkg_Price + $Extra_Pkg_Price;
             * };
             * $query = $this->db->query('Select Include_Pkg_Price, Extra_Pkg_Price from JobSpecial Where VN="' . $VN . '"');
             * if ($query->num_rows() != 0) {
             * $row = $query->row();
             * $Include_Pkg_Price = $row->Include_Pkg_Price + $Include_Pkg_Price;
             * $Extra_Pkg_Price = $row->Extra_Pkg_Price + $Extra_Pkg_Price;
             * };
             *
             */
            Decimal inclab = 0, extlab = 0, incpx = 0, extpx = 0, incspe = 0, extspe = 0, inc=0, ext=0,incpkg=0;
            long chk = 0;
            sql = "Select Include_Pkg_Price, Extra_Pkg_Price from JobLab Where VN='"+vn+"'";
            dt = conn.selectData(conn.conn,sql);
            if (dt.Rows.Count > 0)
            {
                Decimal.TryParse(dt.Rows[0]["Include_Pkg_Price"].ToString(), out inclab);
                Decimal.TryParse(dt.Rows[0]["Extra_Pkg_Price"].ToString(), out extlab);
            }
            sql = "Select Include_Pkg_Price, Extra_Pkg_Price from JobPx Where VN='" + vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                Decimal.TryParse(dt.Rows[0]["Include_Pkg_Price"].ToString(), out incpx);
                Decimal.TryParse(dt.Rows[0]["Extra_Pkg_Price"].ToString(), out extpx);
            }
            sql = "Select Include_Pkg_Price, Extra_Pkg_Price from JobSpecial Where VN='" + vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                Decimal.TryParse(dt.Rows[0]["Include_Pkg_Price"].ToString(), out incspe);
                Decimal.TryParse(dt.Rows[0]["Extra_Pkg_Price"].ToString(), out extspe);
            }
            //sql = "Select Include_Pkg_Price, Extra_Pkg_Price from PackageSold Where VN='" + vn + "'";
            //dt = conn.selectData(conn.conn, sql);
            //if (dt.Rows.Count > 0)
            //{
            //    Decimal.TryParse(dt.Rows[0]["Include_Pkg_Price"].ToString(), out incpkg);
            //    //Decimal.TryParse(dt.Rows[0]["Extra_Pkg_Price"].ToString(), out extspe);
            //}
            inc = inclab + incpx + incspe;
            ext = extlab + extpx + extspe;
            
            /* Step 5.
             * insert Bill Header
             * insert Bill Detail
             * $date = date("Y-m-d", time());
             * $time = date("H:i:s", time());
             * $status = "1";
             * $this->db->query('Insert into BillHeader Set  BillNo="'.$BillNo.'", VN="' . $VN . '", PName="' . $PName . '", OName="' . $OName . '", PID="' . $PID . '", PIDS="' . $PIDS . '"
             * , Include_Pkg_Price="' . $Include_Pkg_Price . '", Extra_Pkg_Price="' . $Extra_Pkg_Price . '", Date="' . $date . '", Time="' . $time . '", Status=1');
             * $query=$this->db->query('Select * from PackageSold Where PID="'.$PID.'" and Status<>3');
             * if ($query->num_rows()>0){
             * $this->db->query('insert into BillDetail Set VN="' . $VN . '", Name="Package", Extra="0", Price="0", Total="0", GroupType="Package"');
             * }
             * 
             */

            DateTime dt11 = DateTime.Now;
            String date = "", time="";
            date = dt11.Year + "-" + dt11.ToString("MM-dd");
            time = dt11.ToString("HH:mm:ss");
            OldBillheader obillh = new OldBillheader();
            obillh.VN = vn;
            obillh.BillNo = "";
            obillh.PName = ovs.PName;
            obillh.Date = date;
            obillh.Time = time;
            obillh.PID = ovs.PID;
            obillh.PIDS = ovs.PIDS;
            obillh.Include_Pkg_Price = inc.ToString();
            obillh.Extra_Pkg_Price = ext.ToString();
            obillh.Total = "";
            obillh.Discount = "";
            obillh.CreditCardType = "";
            obillh.CreditCardNumber = "";
            obillh.Status = "1";
            obillh.CreditAgent = "CrediAgent";
            obillh.OName = ovs.OName;
            obillh.BID = "";
            obillh.PaymentBy = "";
            obillh.CashID = "";
            obillh.CreditCardID = "";
            obillh.SepCash = "";
            obillh.SepCredit = "";
            obillh.ExtBillNo = "";
            obillh.IntLock = "";
            obillh.agent_id = agentId;
            obillh.include_lab = inclab.ToString();
            obillh.ext_lab = extlab.ToString();
            obillh.include_special = incspe.ToString();
            obillh.ext_special = extspe.ToString();
            obillh.include_package = incpkg.ToString();
            obillh.ext_package = extpx.ToString();
            obillh.total1 = (inc+ext).ToString();
            String billid = "";
            billid = obilhDB.insertBillHeader(obillh, userId);
            //sql = "Select * from PackageSold Where PID='"+ ovs.PID+ "' and Status<>3'";
            //dt = opkgsDB.selectByVN1(vn);
            //dt = opkgsDB.selectByPID(ovs.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ selectByPIDStatusPackageON
            //dt = opkgsDB.selectByPIDStatusPackageON(ovs.PID);
            dt = opkgsDB.selectByPIDStatusPackageCashierON(ovs.PID);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
                    Decimal price = 0, pay1 = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["payment1"].ToString(), out pay1);
                    Decimal.TryParse(row["payment2"].ToString(), out pay2);
                    Decimal.TryParse(row["payment3"].ToString(), out pay3);
                    Decimal.TryParse(row["payment4"].ToString(), out pay4);
                    times = row["payment_times"].ToString();
                    bill1 = row["P1BDetailID"].ToString();
                    bill2 = row["P2BDetailID"].ToString();
                    bill3 = row["P3BDetailID"].ToString();
                    bill4 = row["P4BDetailID"].ToString();
                    name = row["PackageName"].ToString();
                    if (price > 0)
                    {
                        //if (Decimal.TryParse(row["Payment1"].ToString(), out price))
                        //{
                        //    if (price > 0)
                        //        times = "1";
                        //}
                        //else if (Decimal.TryParse(row["Payment2"].ToString(), out price))
                        //{
                        //    if (price > 0)
                        //        times = "2";
                        //}
                        //else if (Decimal.TryParse(row["Payment3"].ToString(), out price))
                        //{
                        //    if (price > 0)
                        //        times = "3";
                        //}
                        //else if (Decimal.TryParse(row["Payment4"].ToString(), out price))
                        //{
                        //    if (price > 0)
                        //        times = "4";
                        //}
                        if ((pay1 > 0) && bill1.Equals("0"))
                        {
                            pay = pay1;
                            name += "1/" + times;
                        }
                        else if ((pay2 > 0) && bill2.Equals("0"))
                        {
                            pay = pay2;
                            name += "2/" + times;
                        }
                        else if ((pay3 > 0) && bill3.Equals("0"))
                        {
                            pay = pay3;
                            name += "3/" + times;
                        }
                        else if ((pay4 > 0) && bill4.Equals("0"))
                        {
                            pay = pay4;
                            name += "4/" + times;
                        }

                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = vn;
                        //obilld.Name = "Package ";
                        obilld.Extra = "0";
                        obilld.Name = "Package "+name;
                        obilld.Price = pay.ToString();
                        obilld.Total = pay.ToString();
                        obilld.Comment = "";
                        obilld.item_id = row["PCKID"].ToString();
                        obilld.pcksid = row["PCKSID"].ToString();
                        //if (times.Equals("1"))
                        //{
                        //    obilld.Name = "Package " + row["PackageName"].ToString() + " Payment 1/" + times;
                        //    obilld.Price = price.ToString();
                        //    obilld.Total = price.ToString();
                        //    obilld.Comment = "";
                        //}
                        //else if (times.Equals("2"))
                        //{
                        //    obilld.Name = "Package " + row["PackageName"].ToString() + " Payment 2" + times;
                        //    obilld.Price = price.ToString();
                        //    obilld.Total = price.ToString();
                        //    obilld.Comment = "";
                        //}
                        //else if (times.Equals("3"))
                        //{
                        //    obilld.Name = "Package " + row["PackageName"].ToString() + " Payment 3" + times;
                        //    obilld.Price = price.ToString();
                        //    obilld.Total = price.ToString();
                        //    obilld.Comment = "";
                        //}
                        //else if (times.Equals("4"))
                        //{
                        //    obilld.Name = "Package " + row["PackageName"].ToString() + " Payment 4" + times;
                        //    obilld.Price = price.ToString();
                        //    obilld.Total = price.ToString();
                        //    obilld.Comment = "";
                        //}
                        obilld.GroupType = "Package";
                        obilld.status = "package";
                        obilld.price1 = pay.ToString();
                        obilld.qty = "1";
                        obilld.bill_id = billid;
                        obilld.bill_group_id = "2650000000";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
            }
            if (inc != 0)
            {
                dt = oJlabdDB.selectBillExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0,qty=0;
                        String grp3 = "", grp4 = "", grp = "";
                        grp3 = obilgDB.getList("2650000003");
                        grp4 = obilgDB.getList("2650000004");

                        grp = row["LGID"].ToString().Equals("1") ? grp3 : grp4;
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        if (row["status_show_qty"].ToString().Equals("1"))
                        {
                            obilld.Name = row["LName"].ToString()+" ["+ row["QTY"].ToString()+"]";
                        }
                        else
                        {
                            obilld.Name = row["LName"].ToString();
                        }
                        
                        obilld.Extra = "0";
                        obilld.Price = (price*qty).ToString();
                        obilld.Total = "0";     // เพราะ include ตอนออกใบเสร็จจะได้คำนวณถูก
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obilld.item_id = row["LID"].ToString();
                        obilld.status = "lab";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        if (row["LGID"].ToString().Equals("1"))     //lab blood
                        {
                            obilld.bill_group_id = "2650000003";
                        }
                        else
                        {
                            obilld.bill_group_id = "2650000004";
                        }
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = oJpxdDB.selectExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0, qty = 0;
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = obilgDB.getList("2650000001");
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["DUName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = (price * qty).ToString();
                        obilld.Total = "0";     // เพราะ include ตอนออกใบเสร็จจะได้คำนวณถูก
                        obilld.GroupType = grp1;
                        obilld.Comment = "";
                        obilld.item_id = row["DUID"].ToString();
                        obilld.status = "drug";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        obilld.bill_group_id = "2650000001";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = ojsdDB.selectExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0, qty = 0;
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = oSItmDB.getBillGroupID(row["SID"].ToString());
                        grp = obilgDB.getList(grp1);
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["SName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = (price * qty).ToString();
                        obilld.Total = "0";     // เพราะ include ตอนออกใบเสร็จจะได้คำนวณถูก
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obilld.item_id = row["SID"].ToString();
                        obilld.status = "special";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        obilld.bill_group_id = row["bill_group_id"].ToString();
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
            }
            if (ext != 0)
            {
                dt = oJlabdDB.selectBillExtra1ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0, qty = 0;
                        String grp3 = "", grp4 = "", grp = "";
                        grp3 = obilgDB.getList("2650000003");
                        grp4 = obilgDB.getList("2650000004");

                        grp = row["LGID"].ToString().Equals("1") ? grp3 : grp4;
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        if (row["status_show_qty"].ToString().Equals("1"))
                        {
                            String name = "";
                            name = row["LName"].ToString().Substring(0, row["LName"].ToString().IndexOf("per")).Trim() + " "+ row["QTY"].ToString()+" " + row["LName"].ToString().Substring(row["LName"].ToString().IndexOf("per")).Trim();
                            //name = row["LName"].ToString();
                            obilld.Name = name;
                        }
                        else
                        {
                            obilld.Name = row["LName"].ToString();
                        }
                        //obilld.Name = row["LName"].ToString();
                        obilld.Extra = "1";
                        obilld.Price = (price * qty).ToString();
                        obilld.Total = (price * qty).ToString();
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obilld.item_id = row["LID"].ToString();
                        obilld.status = "lab";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        if (row["LGID"].ToString().Equals("1"))     //lab blood
                        {
                            obilld.bill_group_id = "2650000003";
                        }
                        else
                        {
                            obilld.bill_group_id = "2650000004";
                        }
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = oJpxdDB.selectExtra1ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0, qty = 0;
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = obilgDB.getList("2650000001");
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["DUName"].ToString();
                        obilld.Extra = "1";
                        obilld.Price = (price * qty).ToString();
                        obilld.Total = (price * qty).ToString();
                        obilld.GroupType = grp1;
                        obilld.Comment = "";
                        obilld.item_id = row["DUID"].ToString();
                        obilld.status = "drug";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        obilld.bill_group_id = "2650000001";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = ojsdDB.selectExtra1ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Decimal price = 0, qty = 0;
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = oSItmDB.getBillGroupID(row["SID"].ToString());
                        grp = obilgDB.getList(grp1);
                        Decimal.TryParse(row["Price"].ToString(), out price);
                        Decimal.TryParse(row["QTY"].ToString(), out qty);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["SName"].ToString();
                        obilld.Extra = "1";
                        obilld.Price = (price * qty).ToString();
                        obilld.Total = (price * qty).ToString();
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obilld.item_id = row["SID"].ToString();
                        obilld.status = "special";
                        obilld.pcksid = "0";
                        obilld.price1 = row["Price"].ToString();
                        obilld.qty = row["QTY"].ToString();
                        obilld.bill_id = billid;
                        obilld.bill_group_id = row["bill_group_id"].ToString();
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
            }
            //sql = "update BillHeader Set Total=Extra_Pkg_Price Where VN='"+vn+"'";
            String pkgall = "", extra="";
            Decimal pkgall1 = 0, extra1 = 0, total1=0;
            pkgall = obildDB.selectSumPriceByBilIdBillGroup(billid, "2650000000");
            extra = obildDB.selectSumPriceExtraByBilId(billid);
            Decimal.TryParse(pkgall, out pkgall1);
            Decimal.TryParse(extra, out extra1);
            total1 = pkgall1 + extra1;
            sql = "update BillHeader Set Total="+ total1 + " " +
                ",Include_Pkg_Price ='"+ pkgall +"' "+
                ",Extra_Pkg_Price ='" + extra +"' "+
                "Where bill_id ='" + billid + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
            return billid;
        }
        public DataTable printBill(String vn,ref Decimal amt1,ref String payby)
        {
            //$chk = "";
            //$sql = 'select VN, ExtBillNo, IntLock, Year(Date)+543 as F1, date_format(Date,"%m") as F2 from BillHeader Where VN="'. $_POST['VN']. '"';
            //$result = mysql_query($sql, $link);
            //$row = mysql_fetch_row($result);
            //$VN =$row[0];
            //$ExtBillNo =$row[1];
            //$IntLock =$row[2];
            //$F1 =$row[3];
            //$F1 = substr($F1, -2);
            //$F2 =$row[4];
            //$F1 =$F1.$F2."0000";
            //if ($ExtBillNo == null and $IntLock == 0){
            //  $sql2 = "Select max(ExtBillNo) from BillHeader";
            //  $result2 = mysql_query($sql2, $link);
            //  $row2 = mysql_fetch_row($result2);
            //  $MaxBill =$row2[0];
            //    if ($F1 >$MaxBill){
            //    $ExtBillNo =$F1 + 1;
            //    } else {
            //    $ExtBillNo =$MaxBill + 1;
            //    }
            //  $sql3 = 'Update BillHeader Set ExtBillNo="'.$ExtBillNo.'" where VN="'.$VN.'"';
            //    mysql_query($sql3, $link);
            //}
            DataTable dt = new DataTable();
            long chk1 = 0, chk2 = 0;
            String re = "", extBill="", intLock="", f1="",f2="", maxBill="", billNo="";
            String sql = "select VN, ExtBillNo, IntLock, Year(Date)+543 as F1, date_format(Date,'%m') as F2 from BillHeader Where VN='"+vn+"' and active = '1'";
            //dt = conn.selectData(conn.conn, sql);
            //if (dt.Rows.Count > 0)
            //{
            //    extBill = dt.Rows[0]["ExtBillNo"].ToString();
            //    intLock = dt.Rows[0]["IntLock"].ToString();
            //    f1 = dt.Rows[0]["F1"].ToString();
            //    f2 = dt.Rows[0]["F2"].ToString();
            //    f1 = f1.Length >= 4 ? f1.Substring(2,2) : f1;
            //    f1 += f2 + "0000";
            //    if(extBill.Equals("") && intLock.Equals("0"))
            //    {
            //        sql = "Select max(ExtBillNo) as ExtBillNo from BillHeader";
            //        dt = conn.selectData(conn.conn, sql);
            //        if (dt.Rows.Count > 0)
            //        {
            //            maxBill = dt.Rows[0]["ExtBillNo"].ToString();
            //            long.TryParse(f1, out chk1);
            //            long.TryParse(maxBill, out chk2);
            //            billNo = (chk1 < chk2) ? (chk1 + 1).ToString() : (chk2 + 1).ToString();
            //            sql = "Update BillHeader Set ExtBillNo='"+ billNo + "' where VN='"+vn+"'";
            //            String re1 = conn.ExecuteNonQuery(conn.conn, sql);
            //            if(!long.TryParse(re1, out chk1))
            //            {
            //                re = "update ExtBillNo error ";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        re = "extBill "+extBill+ " intLock "+ intLock;
            //    }
            //}
            //else
            //{
            //    re = "No Bill in vn "+vn;
            //}
            //            $sql = 'select * from BillHeader Where VN="'. $_POST['VN']. '"';
            //$result = mysql_query($sql, $link);
            //$pdf->SetFont('freeserif', '', 9, '', true);
            //            set_time_limit(0);
            //            while ($row = mysql_fetch_array($result)) {
            //    $PName = $row['PName'];
            //    $PIDS = $row['PIDS'];
            //    $IntLock =$row['IntLock'];
            //    $WTotal = convert_number_to_words(round($row['Total'])). ' baht';
            //    $Total = number_format($row['Total'], 2, '.', ',');
            //    $billno = "RE".floor($row['BillNo'] / 10000). "-";
            //                if ($row['BillNo'] % 10000 < 10) {
            //        $billno = $billno. "000". $row['BillNo'] % 10000;
            //                } else {
            //                    if ($row['BillNo'] % 10000 < 100) {
            //        $billno = $billno. "00". $row['BillNo'] % 10000;
            //                    } else {
            //                        if ($row['BillNo'] % 10000 < 1000) {
            //        $billno = $billno. "0". $row['BillNo'] % 10000;
            //                        } else {
            //        //1. bug running
            //        //$billno = $billno . $row['BillNo'] % 100;     -1
            //        $billno = $billno. $row['BillNo'] % 10000;   //     +1
            //                        };
            //                    };
            //                };
            //  $ExtBillNo =$row['ExtBillNo'];
            //                if ($ExtBillNo != 0){
            //    $extbillno = "IVF".floor($row['ExtBillNo'] / 10000). "-";
            //                    if ($row['ExtBillNo'] % 10000 < 10) {
            //        $extbillno = $extbillno. "000". $row['ExtBillNo'] % 10000;
            //                    } else {
            //                        if ($row['ExtBillNo'] % 10000 < 100) {
            //        $extbillno = $extbillno. "00". $row['ExtBillNo'] % 10000;
            //                        } else {
            //                            if ($row['ExtBillNo'] % 10000 < 1000) {
            //        $extbillno = $extbillno. "0". $row['ExtBillNo'] % 10000;
            //                            } else {
            //        //1. bug running
            //        //$extbillno = $billno . $row['ExtBillNo'] % 100;   -1
            //        //$extbillno = $billno . $row['ExtBillNo'] % 10000;     //   +1
            //        $extbillno = $extbillno. $row['ExtBillNo'] % 10000;     //   +2
            //                            };
            //                        };
            //                    };
            //                }
            //	$PaymentBy =$row['PaymentBy'];
            //                if ($PaymentBy == "NULL"){
            //		$PaymentBy = "";
            //                } else {
            //		$PaymentBy = '<tr><td>รับชำระเงินจาก/Receive Payment From </td><td>'.$PaymentBy.'</td><td width="30%" align="right">&nbsp;</td></tr>';
            //                };
            //	$CashID =$row['CashID'];
            //	$CreditCardID =$row['CreditCardID'];
            //                if ($CashID != 0 && $CreditCardID == 0){
            //		$Payment2 = "เงินสด/Cash";
            //                };
            //                if ($CreditCardID != 0 && $CashID == 0){
            //		$Payment2 = "เครดิตการ์ด/Credit Card";
            //                };
            //                if ($CreditCardID != 0 && $CashID != 0){
            //		$Payment2 = "เงินสดและเครดิตการ์ด/Cash and Credit Card";
            //                };            };
            String pname = "", pids = "", wtotal = "", total = "", billno = "", billdoc="", billextno="", billextdoc="", cashid="", pay2="", creditid="";
            Decimal total1 = 0;
            sql = "select * from BillHeader Where VN='"+vn+"' and active = '1'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
            //    pname = dt.Rows[0]["PName"].ToString();
            //    pids = dt.Rows[0]["PIDS"].ToString();
            //    intLock = dt.Rows[0]["IntLock"].ToString();
            //    wtotal = dt.Rows[0]["Total"].ToString();
            //    total = dt.Rows[0]["Total"].ToString();
            //    billno = dt.Rows[0]["BillNo"].ToString();
            //    Decimal.TryParse(total, out total1);
            //    total = total1.ToString("0.00");
            //    if(billno.Length > 4)
            //    {
            //        billdoc = "RE" + billno.Substring(0, 4) + "-" + billno.Substring(4);
            //    }
                

            //    billextno = dt.Rows[0]["ExtBillNo"].ToString();
            //    try
            //    {
            //        billextdoc = "RE" + billextno.Substring(0, 4) + "-" + billextno.Substring(4);
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(""+ex.Message, "ExtBillNo");
            //    }
                

            //    payby = "รับชำระเงินจาก/Receive Payment From  " + dt.Rows[0]["PaymentBy"].ToString();
                cashid = dt.Rows[0]["CashID"].ToString();
                creditid = dt.Rows[0]["CreditCardID"].ToString();
                if(!cashid.Equals("0") && creditid.Equals("0")){
                    pay2 = "เงินสด/Cash ";
                }
                else if (cashid.Equals("0") && !creditid.Equals("0"))
                {
                    pay2 = "เครดิตการ์ด/Credit Card ";
                }
                else if (!cashid.Equals("0") && !creditid.Equals("0"))
                {
                    pay2 = "เงินสดและเครดิตการ์ด/Cash and Credit Card ";
                }
                else
                {
                    pay2 = "unknow payment";
                }
                payby = pay2;
            }
            String grpname = "";
            DataTable dtprn = new DataTable();
            DataTable dtb0 = new DataTable();
            DataTable dtb_99 = new DataTable();
            DataTable dtb99 = new DataTable();
            DataTable dtb102 = new DataTable();
            dtprn.Columns.Add("col1", typeof(String));
            dtprn.Columns.Add("col2", typeof(String));
            dtprn.Columns.Add("col3", typeof(String));
            dtprn.Columns.Add("col4", typeof(String));
            dtprn.Columns.Add("sort1", typeof(String));
            dtprn.Columns.Add("fond_bold", typeof(String));
            dtprn.Columns.Add("grp", typeof(String));
            dtprn.Columns.Add("grp_name", typeof(String));
            dtprn.Columns.Add("original", typeof(String));
            sql = "Select ID,Name from BillGroup Where ID=2650000000";//package
            dt = conn.selectData(conn.conn, sql);
            String name = "", total111="", comm="";
            Decimal total1111 = 0, amt=0;
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    String id = "", namedesc = "";

                    id = row["ID"].ToString();
                    namedesc = row["Name"].ToString();
                    sql = "Select sum(Total) as Total1, Name from BillDetail Where Total<>0 and VN='" + vn+ "' and bill_group_id='" + id + "' and active = '1' Group By Name ";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        //DataRow row1 = dtprn.NewRow();
                        //row1["col1"] = grpname;
                        //row1["sort1"] = "";
                        //row1["fond_bold"] = "1";
                        //row1["sort1"] = "1000";
                        //row1["fond_bold"] = "";
                        //row1["grp"] = "1";
                        //row1["grp_name"] = grpname;
                        //dtprn.Rows.Add(row1);
                        int i = 1001;
                        foreach (DataRow dr in dtb0.Rows)
                        {
                            name = dr["Name"].ToString();
                            total111 = dr["Total1"].ToString();
                            //comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name+" "+ comm;
                            row11["col2"] = total1111.ToString("#,###.00");
                            row11["col3"] = "";
                            row11["col4"] = total1111.ToString("#,###.00");
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "";
                            row11["grp"] = "1";
                            row11["grp_name"] = namedesc;
                            amt += total1111;
                            dtprn.Rows.Add(row11);
                            i++;
                        }
                    }
                }
            }

            sql = "Select ID, Name from BillGroup Where ID<2650000099 and ID>2650000000";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                int i = 2001;
                foreach (DataRow row in dt.Rows)
                {
                    String id = "", namedesc = "";

                    id = row["ID"].ToString();
                    namedesc = row["Name"].ToString();
                    //sql = "Select sum(Total) as Total1, Name from BillDetail Where Total<>0 and VN='" + vn + "' and GroupType='" + grpname + "' Group By Name ";
                    sql = "Select sum(Total) as Total1 from BillDetail Where Total<>0 and VN='" + vn + "' and bill_group_id='" + id + "'  and active = '1' and Extra = '1' ";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        total111 = dtb0.Rows[0]["Total1"].ToString();
                        Decimal.TryParse(total111, out total1111);
                        if (total1111 <= 0) continue;
                        DataRow row11 = dtprn.NewRow();
                        row11["col1"] = namedesc;
                        row11["col2"] = total1111.ToString("#,###.00");
                        row11["col3"] = "";
                        row11["col4"] = total1111.ToString("#,###.00");
                        row11["sort1"] = i.ToString();
                        row11["fond_bold"] = "1";
                        row11["grp"] = "2";
                        row11["grp_name"] = namedesc;
                        amt += total1111;
                        dtprn.Rows.Add(row11);
                        //foreach (DataRow row1 in dtb0.Rows)
                        //{
                        //    total111 = row1["Total1"].ToString();
                        //    //name = dt.Rows[0]["Name"].ToString();
                        //    //comm = dt.Rows[0]["Comment"].ToString();
                        //    Decimal.TryParse(total111, out total1111);
                        //    if (total1111 <= 0) continue;
                        //    DataRow row11 = dtprn.NewRow();
                        //    row11["col1"] = row1["Name"].ToString();
                        //    row11["col2"] = total1111.ToString("#,###.00");
                        //    row11["col3"] = "";
                        //    row11["col4"] = total1111.ToString("#,###.00");
                        //    row11["sort1"] = i.ToString();
                        //    row11["fond_bold"] = "1";
                        //    row11["grp"] = "2";
                        //    row11["grp_name"] = grpname;
                        //    amt += total1111;
                        //    dtprn.Rows.Add(row11);
                        //}
                    }
                }
            }

            sql = "Select ID,Name from BillGroup Where ID=2650000099";//   2650000099
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    String id = "", namedesc="";

                    id = row["ID"].ToString();
                    namedesc = row["Name"].ToString();
                    sql = "Select sum(Total) as Total1, Name from BillDetail Where Total<>0 and VN='" + vn + "' and bill_group_id ='" + id + "' and active = '1'  Group By Name ";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        //DataRow row1 = dtprn.NewRow();
                        //row1["col1"] = grpname;
                        //row1["sort1"] = "";
                        //row1["fond_bold"] = "1";
                        //row1["grp"] = "3";
                        //dtprn.Rows.Add(row1);
                        int i = 3001;
                        foreach (DataRow dr in dtb0.Rows)
                        {
                            name = dr["Name"].ToString();
                            total111 = dr["Total1"] != null ? dr["Total1"].ToString() : "0";
                            //comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name;
                            row11["col2"] = total1111.ToString("#,###.00");
                            row11["col3"] = "";
                            row11["col4"] = total1111.ToString("#,###.00");
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "1";
                            row11["grp"] = "3";
                            row11["grp_name"] = namedesc;
                            amt += total1111;
                            dtprn.Rows.Add(row11);
                        }
                    }
                }
            }

            sql = "Select ID,Name from BillGroup Where ID=2650000102";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    String id = "", namedesc = "";

                    id = row["ID"].ToString();
                    namedesc = row["Name"].ToString();
                    sql = "Select sum(Total) as Total1, Name from BillDetail Where Total<>0 and VN='" + vn + "' and bill_group_id='" + id + "' and active = '1' Group By Name ";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        //DataRow row1 = dtprn.NewRow();
                        //row1["col1"] = "Other Service";
                        //row1["sort1"] = "";
                        //row1["fond_bold"] = "1";
                        //row1["grp"] = "4";
                        //dtprn.Rows.Add(row1);
                        int i = 4001;
                        foreach (DataRow dr in dtb0.Rows)
                        {
                            name = dr["Name"].ToString();
                            total111 = dr["Total1"].ToString();
                            //comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name + " " + comm;
                            row11["col2"] = total1111.ToString("#,###.00");
                            row11["col3"] = "";
                            row11["col4"] = total1111.ToString("#,###.00");
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "";
                            row11["grp"] = "4";
                            row11["grp_name"] = "Other Service";
                            amt += total1111;
                            dtprn.Rows.Add(row11);
                        }
                    }
                }
            }
            amt1 = amt;
            return dtprn;
        }
        public void accountsendtonurse(String vn, String userid)
        {
            DataTable dt = new DataTable();
            //          $this->db->query('delete from BillHeader Where VN="'.$VN.'"');
            //$this->db->query('delete from BillDetail Where VN="'.$VN.'"');
            //$this->db->query('update Visit set VSID="115" Where VN="'.$VN.'"');
            Decimal price = 0;
            String pid = "", pkgid = "";
            VisitOld vs = new VisitOld();
            vs = ovsDB.selectByPk1(vn);
            pid = vs.PID;
            OldPackageSold pkg = new OldPackageSold();
            pkg = opkgsDB.selectByVN2(vn);
            //pkgid = pkg.PCKID;
            VoidBill(vn, userid);
            //dt = obildDB.selectByPIDPkgID(pid, pkgid);
            if (!pkg.PCKSID.Equals("0"))
            {
                if (!pkg.P4BDetailID.Equals("0"))
                {
                    opkgsDB.updateStatus2Payment4(pkg.PCKSID);
                }
                else if (!pkg.P3BDetailID.Equals("0"))
                {
                    opkgsDB.updateStatus2Payment3(pkg.PCKSID);
                }
                else if (!pkg.P2BDetailID.Equals("0"))
                {
                    opkgsDB.updateStatus2Payment2(pkg.PCKSID);
                }
                else if (!pkg.P1BDetailID.Equals("0"))
                {
                    opkgsDB.updateStatus2Payment1(pkg.PCKSID);
                }
            }
            ovsDB.updateStatusCashierbackNurse(vn);
        }
        public String updatePackagePaymentComplete(String pid, String pkgsid)
        {
            DataTable dt = new DataTable();
            String re = "", sql = "", billid = "";
            OldPackageSold opkgs1 = new OldPackageSold();
            opkgs1 = opkgsDB.selectByPk1(pkgsid);
            String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
            Decimal price = 0, amt = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
            Decimal.TryParse(opkgs1.Price, out amt);
            dt = obildDB.selectByPIDPkgsID(pid, pkgsid);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Decimal.TryParse(row["Total"].ToString(), out price);
                    pay += price;
                }
            }
            if(amt <= pay)
            {
                opkgsDB.updateStatus3(opkgs1.PCKSID);
            }
            return re;
        }
        public DataTable setOPUReport(String opuid, String day1, String day2, Boolean EmbryoDev20)
        {
            DataTable dt = new DataTable();
            DataTable dtdev1 = new DataTable();
            DataTable dtdev2 = new DataTable();
            if (!EmbryoDev20 && day2.Equals(""))
            {
                MessageBox.Show("กรุณา เลือก Day 2", "");
                return null;
            }
            dt = opuDB.selectByPrintOPU(opuid);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No Data" + dt.Rows.Count, "");
                return null;
            }
            if (day1.Equals("2"))
            {
                dtdev1 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            }
            else if (day1.Equals("3"))
            {
                dtdev1 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            }
            else if (day1.Equals("5"))
            {
                dtdev1 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            }
            else if (day1.Equals("6"))
            {
                dtdev1 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            }
            if (!EmbryoDev20 && !day2.Equals(""))
            {
                if (day2.Equals("2"))
                {
                    dtdev2 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                }
                else if (day2.Equals("3"))
                {
                    dtdev2 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day3);
                }
                else if (day2.Equals("5"))
                {
                    dtdev2 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day5);
                }
                else if (day2.Equals("6"))
                {
                    dtdev2 = opuEmDevDB.selectByOpuFetId_Day(opuid, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                }
            }
            for (int i = 1; i <= 40; i++)
            {
                String col = "";
                col = "embryo_dev_0_" + i.ToString("00");
                dt.Columns.Add(col, typeof(String));
                col = "embryo_dev_1_" + i.ToString("00");
                dt.Columns.Add(col, typeof(String));
            }
            int j = 1;
            String col11 = "embryo_dev_1_name";
            dt.Columns.Add(col11, typeof(String));
            col11 = "embryo_dev_0_name";
            dt.Columns.Add(col11, typeof(String));
            dt.Columns.Add("embryo_dev_0_date", typeof(String));
            dt.Columns.Add("embryo_dev_1_date", typeof(String));
            dt.Columns.Add("embryo_dev_0_staff_name", typeof(String));
            dt.Columns.Add("embryo_dev_1_staff_name", typeof(String));
            dt.Columns.Add("embryo_dev_0_checked_name", typeof(String));
            dt.Columns.Add("embryo_dev_1_checked_name", typeof(String));
            dt.Columns.Add("embryo_freez_no_straw_0", typeof(String));
            dt.Columns.Add("embryo_freez_no_straw_1", typeof(String));
            dt.Columns.Add("embryo_for_et_embryologist_name", typeof(String));
            //dt.Columns.Add("remark_day2", typeof(String));
            //dt.Columns.Add("remark_day3", typeof(String));
            //dt.Columns.Add("remark_day5", typeof(String));
            //dt.Columns.Add("remark_day6", typeof(String));

            if (!day1.Equals("") && dt.Rows.Count > 0)
            {
                dt.Rows[0]["embryo_dev_0_name"] = "Embryo Development (Day " + day1 + ")";
            }
            if (!day2.Equals("") && dt.Rows.Count > 0)
            {
                dt.Rows[0]["embryo_dev_1_name"] = "Embryo Development (Day " + day2 + ")";
            }
            String stfid = "", checkedid = "", embryodevdate = "", etName = "";
            foreach (DataRow row in dtdev1.Rows)
            {
                if (j > 40) continue;
                if (row["desc0"].ToString().Equals("")) continue;
                String col = "embryo_dev_0_", vol = "";
                stfid = ""; checkedid = ""; embryodevdate = "";
                vol = "0" + row["opu_embryo_dev_no"].ToString();
                vol = vol.Substring(vol.Length - 2);
                col = col + vol;
                dt.Rows[0][col] = j + ". " + row["desc0"].ToString() + " " + row["desc1"].ToString() + " " + row["desc2"].ToString();
                stfid = row["staff_id"].ToString();
                checkedid = row["checked_id"].ToString();
                embryodevdate = row["embryo_dev_date"].ToString();
                j++;
            }
            //j = 1;
            //foreach (DataRow row in dtdev2.Rows)
            //{
            //    if (j > 40) continue;
            //    if (row["desc0"].ToString().Equals("")) continue;
            //    String col = "embryo_dev_1_", vol = "";
            //    stfid = ""; checkedid = ""; embryodevdate = "";
            //    vol = "0" + row["opu_embryo_dev_no"].ToString();
            //    vol = vol.Substring(vol.Length - 2);
            //    col = col + vol;

            //    dt.Rows[0][col] = j + ". " + row["desc0"].ToString() + " " + row["desc1"].ToString() + " " + row["desc2"].ToString();
            //    j++;
            //}
            String stf0 = "", chk0="";
            stf0 = stfDB.getStaffNameBylStf(stfid);
            chk0 = stfDB.getStaffNameBylStf(checkedid);
            String[] stf01 = stf0.Split(' ');
            String[] chk01 = chk0.Split(' ');
            if (stf0.Length > 0)
            {
                if (stf01[1].Length > 0)
                {
                    if (stf0.Length > 0 && chk0.Length > 0)
                    {
                        stf0 = (stf01.Length > 0) ? stf01[0] + " " + stf01[1].Substring(0, 1) + "." : stf0;
                        chk0 = (chk01.Length > 0) ? chk01[0] + " " + chk01[1].Substring(0, 1) + "." : chk0;
                    }
                }
                else
                {
                    MessageBox.Show("staff invalid", "");
                    stf0 = (stf01.Length > 0) ? stf01[0] + " " + stf01[1] + "." : stf0;
                    chk0 = (chk01.Length > 0) ? chk01[0] + " " + chk01[1] + "." : chk0;
                }
            }
            
            
            dt.Rows[0]["embryo_dev_0_staff_name"] = stf0;
            dt.Rows[0]["embryo_dev_0_checked_name"] = chk0;
            etName = dt.Rows[0]["embryo_for_et_embryologist_id"].ToString();
            dt.Columns.Remove("embryo_for_et_embryologist_id");
            dt.Columns.Add("embryo_for_et_embryologist_id", typeof(String));
            dt.Rows[0]["embryo_for_et_embryologist_id"] = stfDB.getStaffNameBylStf(etName);
            //dt.Rows[0]["embryo_dev_0_date"] = datetimetoShow(embryodevdate);
            dt.Rows[0]["embryo_dev_0_date"] = datetoShow(embryodevdate).Replace("-", "/");
            dt.Rows[0]["embryo_freez_no_straw_0"] = dt.Rows[0]["embryo_freez_no_of_straw_0"].ToString();
            dt.Rows[0]["embryo_freez_no_straw_1"] = dt.Rows[0]["embryo_freez_no_of_straw_1"].ToString();
            j = 1;
            stfid = "";
            checkedid = "";
            if (!EmbryoDev20 && dtdev2.Rows.Count > 0)
            {
                foreach (DataRow row in dtdev2.Rows)
                {
                    if (j > 40) continue;
                    if (row["desc0"].ToString().Equals("")) continue;
                    String col = "embryo_dev_1_", vol = "";
                    stfid = ""; checkedid = ""; embryodevdate = "";
                    vol = "0" + row["opu_embryo_dev_no"].ToString();
                    vol = vol.Substring(vol.Length - 2);
                    col = col + vol;
                    dt.Rows[0][col] = j + ". " + row["desc0"].ToString() + " " + row["desc1"].ToString() + " " + row["desc2"].ToString();
                    stfid = row["staff_id"].ToString();
                    checkedid = row["checked_id"].ToString();
                    embryodevdate = row["embryo_dev_date"].ToString();
                    j++;
                }
            }
            if (!day2.Equals(""))
            {
                String stf1 = "", chk1 = "";
                stf1 = stfDB.getStaffNameBylStf(stfid);
                chk1 = stfDB.getStaffNameBylStf(checkedid);
                String[] stf11 = stf1.Split(' ');
                String[] chk11 = chk1.Split(' ');
                if (stf1.Length > 0 && chk1.Length > 0)
                {
                    stf1 = (stf11.Length > 0) ? stf11[0] + " " + stf11[1].Substring(0, 1) + "." : stf1;
                    chk1 = (chk11.Length > 0) ? chk11[0] + " " + chk11[1].Substring(0, 1) + "." : chk1;
                }
                dt.Rows[0]["embryo_dev_1_staff_name"] = stf1;
                dt.Rows[0]["embryo_dev_1_checked_name"] = chk1;
            }

            dt.Rows[0]["embryo_for_et_doctor"] = dt.Rows[0]["embryo_for_et_doctor"].ToString().Equals("") ? "-" : dtrOldDB.getlDtrNameByID(dt.Rows[0]["embryo_for_et_doctor"].ToString());

            dt.Rows[0]["embryo_dev_1_date"] = datetoShow(embryodevdate).Replace("-", "/");
            String date1 = "";
            date1 = datetoShow(dt.Rows[0][opuDB.opu.dob_female].ToString());
            dt.Rows[0][opuDB.opu.dob_female] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.dob_male].ToString());
            dt.Rows[0][opuDB.opu.dob_male] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.matura_date].ToString());
            dt.Rows[0][opuDB.opu.matura_date] = date1.Replace("-", "/").Replace("2001", "99999");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.fertili_date].ToString());
            dt.Rows[0][opuDB.opu.fertili_date] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_for_et_date].ToString());
            dt.Rows[0][opuDB.opu.embryo_for_et_date] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_2].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_2] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_3].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_3] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_5].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_5] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_6].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_6] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_0].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_0] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.embryo_freez_date_1].ToString());
            dt.Rows[0][opuDB.opu.embryo_freez_date_1] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.opu_date].ToString());
            dt.Rows[0][opuDB.opu.opu_date] = date1.Replace("-", "/");
            date1 = datetoShow(dt.Rows[0][opuDB.opu.sperm_date].ToString());
            dt.Rows[0][opuDB.opu.sperm_date] = date1.Replace("-", "/");

            dt.Rows[0][opuDB.opu.matura_m_ii] = dt.Rows[0][opuDB.opu.matura_m_ii].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_m_ii].ToString();
            dt.Rows[0][opuDB.opu.matura_m_i] = dt.Rows[0][opuDB.opu.matura_m_i].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_m_i].ToString();
            dt.Rows[0][opuDB.opu.matura_gv] = dt.Rows[0][opuDB.opu.matura_gv].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_gv].ToString();
            dt.Rows[0][opuDB.opu.matura_post_mat] = dt.Rows[0][opuDB.opu.matura_post_mat].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_post_mat].ToString();
            dt.Rows[0][opuDB.opu.matura_abmormal] = dt.Rows[0][opuDB.opu.matura_abmormal].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_abmormal].ToString();
            dt.Rows[0][opuDB.opu.matura_dead] = dt.Rows[0][opuDB.opu.matura_dead].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.matura_dead].ToString();

            dt.Rows[0][opuDB.opu.fertili_2_pn] = dt.Rows[0][opuDB.opu.fertili_2_pn].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_2_pn].ToString();
            dt.Rows[0][opuDB.opu.fertili_1_pn] = dt.Rows[0][opuDB.opu.fertili_1_pn].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_1_pn].ToString();
            dt.Rows[0][opuDB.opu.fertili_3_pn] = dt.Rows[0][opuDB.opu.fertili_3_pn].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_3_pn].ToString();
            dt.Rows[0][opuDB.opu.fertili_4_pn] = dt.Rows[0][opuDB.opu.fertili_4_pn].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_4_pn].ToString();
            dt.Rows[0][opuDB.opu.fertili_no_pn] = dt.Rows[0][opuDB.opu.fertili_no_pn].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_no_pn].ToString();
            dt.Rows[0][opuDB.opu.fertili_dead] = dt.Rows[0][opuDB.opu.fertili_dead].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.fertili_dead].ToString();

            dt.Rows[0][opuDB.opu.embryo_for_et_no_of_et] = dt.Rows[0][opuDB.opu.embryo_for_et_no_of_et].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_no_of_et].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_day] = dt.Rows[0][opuDB.opu.embryo_for_et_day].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_day].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_date] = dt.Rows[0][opuDB.opu.embryo_for_et_date].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_date].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_assisted] = dt.Rows[0][opuDB.opu.embryo_for_et_assisted].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_assisted].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_volume] = dt.Rows[0][opuDB.opu.embryo_for_et_volume].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_volume].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_catheter] = dt.Rows[0][opuDB.opu.embryo_for_et_catheter].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_catheter].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard] = dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_number_of_freeze] = dt.Rows[0][opuDB.opu.embryo_for_et_number_of_freeze].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_number_of_freeze].ToString();
            dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard] = dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard].ToString().Equals("") ? "-" : dt.Rows[0][opuDB.opu.embryo_for_et_number_of_discard].ToString();

            String remarkday2 = "", remarkday3 = "", remarkday5 = "", remarkday6 = "";
            remarkday2 = dt.Rows[0][opuDB.opu.remark_day2] != null ? dt.Rows[0][opuDB.opu.remark_day2].ToString() : "";
            remarkday3 = dt.Rows[0][opuDB.opu.remark_day3] != null ? dt.Rows[0][opuDB.opu.remark_day3].ToString() : "";
            remarkday5 = dt.Rows[0][opuDB.opu.remark_day5] != null ? dt.Rows[0][opuDB.opu.remark_day5].ToString() : "";
            remarkday6 = dt.Rows[0][opuDB.opu.remark_day6] != null ? dt.Rows[0][opuDB.opu.remark_day6].ToString() : "";
            if (remarkday2.Equals("") && remarkday3.Equals("") && remarkday5.Equals(""))
            {
                remarkday2 = "Remark Day6: " +remarkday6;
            }
            else if (remarkday2.Equals("") && remarkday3.Equals("") && !remarkday5.Equals(""))
            {
                remarkday2 = "Remark Day5: " + remarkday5;
                remarkday3 = "Remark Day6: " + remarkday6;
            }
            else if (remarkday2.Equals("") && !remarkday3.Equals("") && !remarkday5.Equals(""))
            {
                remarkday2 = "Remark Day3: " + remarkday3;
                remarkday3 = "Remark Day5: " + remarkday5;
                remarkday5 = "Remark Day6: " + remarkday6;
            }
            else if (remarkday2.Equals("") && !remarkday3.Equals("") && remarkday5.Equals("") && !remarkday6.Equals(""))
            {
                remarkday2 = "Remark Day3: " + remarkday3;
                remarkday3 = "Remark Day6: " + remarkday6;
            }
            String stf2 = "", chk2 = "";
            stf2 = dt.Rows[0]["embryo_for_et_embryologist_name_rpt"].ToString();
            chk2 = dt.Rows[0]["embryo_for_et_embryologist_name_apv"].ToString();
            String[] stf22 = stf2.Split(' ');
            String[] chk22 = chk2.Split(' ');
            stf2 = (stf22.Length > 1) ? stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            chk2 = (chk22.Length > 1) ? chk22[1] + " " + chk22[2].Substring(0, 1) + "." : chk2;
            dt.Rows[0]["embryo_for_et_embryologist_name_rpt"] = stf2;
            dt.Rows[0]["embryo_for_et_embryologist_name_apv"] = chk2;
            return dt;
        }
        public String datetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            //MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    if (dt1.Year < 1900) return "";
                    re = dt1.ToString("dd-MM-yyyy");
                }
            }
            return re;
        }
        public String genItem(String itemid,String itemcode, String pttitemid, String pttitemname, String linkitemid, String flagtype, String userid)
        {
            if (itemcode == null) return "";
            String re = "", code = "", codeH = "", re1="",re2="";
            long chk = 0;
            int chk1 = 0;
            if (flagtype.Length <= 0)
            {
                return "";
            }
            if (flagtype.Equals("LAB"))
            {
                codeH = "LB";
            }
            else if (flagtype.Equals("Special"))
            {
                codeH = "SE";
            }
            else if (flagtype.Equals("Drug"))
            {
                codeH = "DU";
            }
            int.TryParse(itmDB.selectCount(), out chk1);
            chk1++;
            code = "0000" + chk1.ToString();
            if (code.Length > 4)
            {
                code = code.Substring(code.Length - 4);
            }
            code = codeH + code;
            BItem item = new BItem();
            item.item_id = "";
            item.item_code = code;
            item.item_common_name = pttitemname;
            item.item_name_e = pttitemname;
            item.item_name_t = pttitemname;
            if (flagtype.Equals("LAB"))
            {
                item.status_item = "1";
            }
            else if (flagtype.Equals("Special"))
            {
                item.status_item = "2";
            }
            else if (flagtype.Equals("Drug"))
            {
                item.status_item = "3";
            }
            item.item_master_id = pttitemid;
            item.item_link_id = linkitemid;
            if (itemcode.Length <= 0)
            {
                re = itmDB.insert(item, userid);
            }
            else
            {
                re = itmDB.updateCodeLinkMaster(itemid, code, pttitemid, linkitemid, userid);
            }
            if (long.TryParse(re, out chk))
            {
                if (flagtype.Equals("LAB"))
                {
                    re1 = oLabiDB.updateCode(pttitemid, code, userid);
                    re2 = oLabiDB.updateCodeEx(linkitemid, code, userid);
                }
                else if (flagtype.Equals("Special"))
                {
                    re1 = oSItmDB.updateCode(pttitemid, code, userid);
                    re2 = oSItmDB.updateCodeEx(linkitemid, code, userid);
                }
                else if (flagtype.Equals("Drug"))
                {
                    re1 = oStkdDB.updateCode(pttitemid, code, userid);
                    re2 = oStkdDB.updateCodeEx(linkitemid, code, userid);
                }
            }
            return re;
        }
    }
}
