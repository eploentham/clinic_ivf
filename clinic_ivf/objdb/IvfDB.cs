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
        public OldVisitDB vsOldDB;
        public BItemDB itmDB;
        public LabRequestDB lbReqDB;
        public CompanyDB copDB;
        public PatientDB pttDB;
        public AgentOldDB agnOldDB;
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
        public OldCreditCardAccountDB occa;
        public OldBillGroupDB obilgDB;

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
            vsOldDB = new OldVisitDB(conn);
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
            agnOldDB = new AgentOldDB(conn);
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
            occa = new OldCreditCardAccountDB(conn);
            obildDB = new OldBilldetailDB(conn);
            obilhDB = new OldBillheaderDB(conn);
            obilgDB = new OldBillGroupDB(conn);

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
        public LabRequest setLabRequest(String pttName, String vn, String doctorId, String remark, String hn, String dobfemale, String reqid, String itmcode
            ,String hnmale, String namemale, String hndonor, String namedonor)
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
            lbReq.dob_donor = datetoDB(dobfemale);
            lbReq.dob_female = "";
            lbReq.dob_male = "";
            lbReq.hn_donor = hndonor;
            lbReq.name_donor = namedonor;
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
            //opu.opu_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.opu_date = lformA.opu_date;
            opu.opu_time = lformA.opu_time;
            opu.req_id = reqid;
            opu.hn_donor = lformA.hn_donor;
            opu.name_donor = lformA.name_donor;
            opu.dob_donor = lbreq.dob_donor;
            return opu;
        }
        public LabFet setFET(String reqid)
        {
            LabFet opu = new LabFet();
            LabRequest lbreq = new LabRequest();
            LabFormA lformA = new LabFormA();
            lbreq = lbReqDB.selectByPk1(reqid);
            lformA = lFormaDB.selectByVnOld(lbreq.vn);
            opu.fet_id = "";
            opu.fet_code = copDB.genFEFDoc();
            //opu.embryo_freez_stage = "";
            //opu.embryoid_freez_position = "";
            opu.hn_male = lformA.hn_male;
            opu.hn_female = lbreq.hn_female;
            opu.name_male = lformA.name_male;
            opu.name_female = lbreq.name_female;
            opu.remark = lbreq.remark;
            opu.dob_female = lformA.dob_female;
            opu.dob_male = lformA.dob_male;
            opu.doctor_id = lbreq.doctor_id;
            opu.proce_id = "";
            opu.fet_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.req_id = reqid;
            opu.hn_donor = lformA.hn_donor;
            opu.name_donor = lformA.name_donor;
            //opu.dob_female = lbreq.dob_female;
            return opu;
        }
        public void calIncludeExtraPricePx(String vn)
        {
            String include = "", extra = "";
            include = oJpxdDB.selectSumIncludePriceByVN(vn);
            extra = oJpxdDB.selectSumExtraPriceByVN(vn);
            oJpxDB.updateIncludePriceFormDetail(include, extra, vn);
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
        public void PackageAdd(OldPackageSold opkgs)
        {
            opkgsDB.insert(opkgs, "");
        }
        public void PxSetAdd(String gdid, String pid, String pids, String vn, String extra)
        {
            //$queGD = $this->package->get_groupDrugDetail($_POST['GDID']);
            //foreach ($queGD->result() as $row) {
            //$aData['DUID'] = $row->DUID;
            //$aData['QTY'] = $row->QTY;

            //$this->package->clear_JobPx_package($VN, $aData['DUID']);
            //$this->px->add_jobpxdetail($aData);
            //$this->package->update_jobPx_package($VN, $aData['DUID'], $aData['QTY'], $aData['Extra']);
            //}

            DataTable dtDrugSet = new DataTable();
            dtDrugSet = oGudDB.selectByGdId(gdid);
            foreach(DataRow row in dtDrugSet.Rows)
            {
                String duid = "", qty = "";
                duid = row["DUID"].ToString();
                qty = row["QTY"].ToString();
                JobPxDetail oJpxd = new JobPxDetail();
                OldStockDrug ostkD = new OldStockDrug();
                Decimal price1 = 0, qty1 = 0;
                Decimal.TryParse(ostkD.Price, out price1);
                Decimal.TryParse(qty, out qty1);
                ostkD = oStkdDB.selectByPk1(duid);
                oJpxd.VN = vn;
                oJpxd.DUID = duid;
                oJpxd.QTY = qty;
                oJpxd.Extra = extra;
                oJpxd.Price = String.Concat(price1*qty1);
                oJpxd.Status = "1";
                oJpxd.PID = pid;
                oJpxd.PIDS = pids;
                oJpxd.DUName = ostkD.DUName;
                oJpxd.Comment = "";
                oJpxd.TUsage = ostkD.TUsage;
                oJpxd.EUsage = ostkD.EUsage;
                oJpxdDB.insert(oJpxd, "");
            }

        }
        public void PxAdd(String duid, String qty, String pid, String pids, String vn, String extra)
        {
            JobPxDetail oJpxd = new JobPxDetail();
            OldStockDrug ostkD = new OldStockDrug();
            Decimal price1 = 0, qty1 = 0;
            Decimal.TryParse(ostkD.Price, out price1);
            Decimal.TryParse(qty, out qty1);
            ostkD = oStkdDB.selectByPk1(duid);
            oJpxd.VN = vn;
            oJpxd.DUID = duid;
            oJpxd.QTY = qty;
            oJpxd.Extra = extra;
            oJpxd.Price = String.Concat(price1 * qty1);
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = ostkD.DUName;
            oJpxd.Comment = "";
            oJpxd.TUsage = ostkD.TUsage;
            oJpxd.EUsage = ostkD.EUsage;
            oJpxdDB.insert(oJpxd, "");
        }
        public void LabAdd(String lid, String qty, String pid, String pids, String vn, String extra, String sp1v, String sp2v, String sp3v, String sp4v, String sp5v, String sp6v, String sp7v)
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
            jlabD.QTY = qty;

            oJlabdDB.insert(jlabD, "");
        }
        public void SpecialAdd(String sid, String qty, String pid, String pids, String vn, String extra, String w1uid, String w2uid, String w3uid, String w4uid)
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

            ojsdDB.insert(ojsd, "");
        }
    }
}
