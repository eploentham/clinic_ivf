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
        public OldCreditCardAccountDB occa;
        public OldBillGroupDB obilgDB;
        public OldFilePatientDB ofpDB;

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
            occa = new OldCreditCardAccountDB(conn);
            obildDB = new OldBilldetailDB(conn);
            obilhDB = new OldBillheaderDB(conn);
            obilgDB = new OldBillGroupDB(conn);
            ofpDB = new OldFilePatientDB(conn);

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
                JobPxDetail oJpxd = new JobPxDetail();
                //OldStockDrug ostkD = new OldStockDrug();
                Decimal price1 = 0, qty1 = 0;
                Decimal.TryParse(price, out price1);
                Decimal.TryParse(qty, out qty1);
                //ostkD = oStkdDB.selectByPk1(duid);
                oJpxd.VN = vn;
                oJpxd.DUID = duid;
                oJpxd.QTY = qty;
                oJpxd.Extra = extra;
                oJpxd.Price = price;
                oJpxd.Status = "1";
                oJpxd.PID = pid;
                oJpxd.PIDS = pids;
                oJpxd.DUName = duname;
                oJpxd.Comment = "";
                oJpxd.TUsage = usaget;
                oJpxd.EUsage = usagee;
            oJpxd.row1 = row1;
                oJpxdDB.insert(oJpxd, "");
            //}

        }
        public void PxAdd(String duid, String qty, String pid, String pids, String vn, String extra, String row1)
        {
            JobPxDetail oJpxd = new JobPxDetail();
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
            oJpxd.Status = "1";
            oJpxd.PID = pid;
            oJpxd.PIDS = pids;
            oJpxd.DUName = ostkD.DUName;
            oJpxd.Comment = "";
            oJpxd.TUsage = ostkD.TUsage;
            oJpxd.EUsage = ostkD.EUsage;
            oJpxd.row1 = row1;
            oJpxdDB.insert(oJpxd, "");
        }
        public void LabAdd(String lid, String qty, String pid, String pids, String vn, String extra, String sp1v, String sp2v, String sp3v, String sp4v, String sp5v, String sp6v, String sp7v, String row1)
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
            jlabD.row1 = row1;

            oJlabdDB.insert(jlabD, "");
        }
        public void SpecialAdd(String sid, String qty, String pid, String pids, String vn, String extra, String w1uid, String w2uid, String w3uid, String w4uid, String row1)
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
            ojsdDB.insert(ojsd, "");
        }
        public void DeleteBill(String vn)
        {
            obilhDB.delete(vn);
            obildDB.delete(vn);
        }
        public void getBill(String vn)
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
            DeleteBill(vn);
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
            Decimal inclab = 0, extlab = 0, incpx = 0, extpx = 0, incspe = 0, extspe = 0, inc=0, ext=0;
            int chk = 0;
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
            obilhDB.insertBillHeader(obillh, "");
            //sql = "Select * from PackageSold Where PID='"+ ovs.PID+ "' and Status<>3'";
            dt = opkgsDB.selectByPID(vn);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    OldBilldetail obilld = new OldBilldetail();
                    obilld.ID = "";
                    obilld.VN = row["VN"].ToString(); ;
                    obilld.Name = "Package";
                    obilld.Extra = "0";
                    obilld.Price = "0";
                    obilld.Total = "0";
                    obilld.GroupType = "Package";
                    obilld.Comment = "";
                    obildDB.insertBillDetail(obilld, "");
                }
            }
            if (inc != 0)
            {
                dt = oJlabdDB.selectBillExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String grp3 = "", grp4 = "", grp = "";
                        grp3 = obilgDB.getList("3");
                        grp4 = obilgDB.getList("4");

                        grp = row["LGID"].ToString().Equals("1") ? grp3 : grp4;

                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["LName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = "0";
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = oJpxdDB.selectExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = obilgDB.getList("1");
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["DUName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = "0";
                        obilld.GroupType = grp1;
                        obilld.Comment = "";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = ojsdDB.selectExtra0ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = oSItmDB.getBillGroupID(row["SID"].ToString());
                        grp = obilgDB.getList(grp1);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["SName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = "0";
                        obilld.GroupType = grp;
                        obilld.Comment = "";
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
                        String grp3 = "", grp4 = "", grp = "";
                        grp3 = obilgDB.getList("3");
                        grp4 = obilgDB.getList("4");

                        grp = row["LGID"].ToString().Equals("1") ? grp3 : grp4;

                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["LName"].ToString();
                        obilld.Extra = "1";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = row["Price"].ToString();
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = oJpxdDB.selectExtra1ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = obilgDB.getList("1");
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["DUName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = row["Price"].ToString();
                        obilld.GroupType = grp1;
                        obilld.Comment = "";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
                dt = ojsdDB.selectExtra1ByVN(vn);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String grp1 = "", grp4 = "", grp = "";
                        grp1 = oSItmDB.getBillGroupID(row["SID"].ToString());
                        grp = obilgDB.getList(grp1);
                        OldBilldetail obilld = new OldBilldetail();
                        obilld.ID = "";
                        obilld.VN = row["VN"].ToString();
                        obilld.Name = row["SName"].ToString();
                        obilld.Extra = "0";
                        obilld.Price = row["Price"].ToString();
                        obilld.Total = row["Price"].ToString();
                        obilld.GroupType = grp;
                        obilld.Comment = "";
                        obildDB.insertBillDetail(obilld, "");
                    }
                }
            }
            sql = "update BillHeader Set Total=Extra_Pkg_Price Where VN='"+vn+"'";
            re = conn.ExecuteNonQuery(conn.conn, sql);
        }
        public DataTable printBill(String vn)
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
            String sql = "select VN, ExtBillNo, IntLock, Year(Date)+543 as F1, date_format(Date,'%m') as F2 from BillHeader Where VN='"+vn+"'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                extBill = dt.Rows[0]["ExtBillNo"].ToString();
                intLock = dt.Rows[0]["IntLock"].ToString();
                f1 = dt.Rows[0]["F1"].ToString();
                f2 = dt.Rows[0]["F2"].ToString();
                f1 = f1.Length >= 4 ? f1.Substring(2,2) : f1;
                f1 += f2 + "0000";
                if(extBill.Equals("") && intLock.Equals("0"))
                {
                    sql = "Select max(ExtBillNo) as ExtBillNo from BillHeader";
                    dt = conn.selectData(conn.conn, sql);
                    if (dt.Rows.Count > 0)
                    {
                        maxBill = dt.Rows[0]["ExtBillNo"].ToString();
                        long.TryParse(f1, out chk1);
                        long.TryParse(maxBill, out chk2);
                        billNo = (chk1 < chk2) ? (chk1 + 1).ToString() : (chk2 + 1).ToString();
                        sql = "Update BillHeader Set ExtBillNo='"+ billNo + "' where VN='"+vn+"'";
                        String re1 = conn.ExecuteNonQuery(conn.conn, sql);
                        if(!long.TryParse(re1, out chk1))
                        {
                            re = "update ExtBillNo error ";
                        }
                    }
                }
                else
                {
                    re = "extBill "+extBill+ " intLock "+ intLock;
                }
            }
            else
            {
                re = "No Bill in vn "+vn;
            }
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
            String pname = "", pids = "", wtotal = "", total = "", billno = "", billdoc="", billextno="", billextdoc="", payby="", cashid="", pay2="", creditid="";
            Decimal total1 = 0;
            sql = "select * from BillHeader Where VN='"+vn+"' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                pname = dt.Rows[0]["PName"].ToString();
                pids = dt.Rows[0]["PIDS"].ToString();
                intLock = dt.Rows[0]["IntLock"].ToString();
                wtotal = dt.Rows[0]["Total"].ToString();
                total = dt.Rows[0]["Total"].ToString();
                billno = dt.Rows[0]["BillNo"].ToString();
                Decimal.TryParse(total, out total1);
                total = total1.ToString("0.00");
                billdoc = "RE"+billno.Substring(0, 4)+"-"+ billno.Substring(4);

                billextno = dt.Rows[0]["ExtBillNo"].ToString();
                try
                {
                    billextdoc = "RE" + billextno.Substring(0, 4) + "-" + billextno.Substring(4);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(""+ex.Message, "ExtBillNo");
                }
                

                payby = "รับชำระเงินจาก/Receive Payment From  " + dt.Rows[0]["PaymentBy"].ToString();
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
            sql = "Select Name from BillGroup Where ID=0";
            dt = conn.selectData(conn.conn, sql);
            String name = "", total111="", comm="";
            Decimal total1111 = 0;
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    grpname = row["Name"].ToString();
                    sql = "Select * from BillDetail Where Total<>0 and VN='"+vn+"' and GroupType='"+ grpname + "'";
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
                            total111 = dr["Total"].ToString();
                            comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name+" "+ comm;
                            row11["col2"] = total1111.ToString("0.00");
                            row11["col3"] = "";
                            row11["col4"] = total1111.ToString("0.00");
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "";
                            row11["grp"] = "1";
                            row11["grp_name"] = grpname;
                            dtprn.Rows.Add(row11);
                            i++;
                        }
                    }
                }
            }

            sql = "Select Name from BillGroup Where ID<99 and ID>0";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                int i = 2001;
                foreach (DataRow row in dt.Rows)
                {
                    grpname = row["Name"].ToString();
                    sql = "Select sum(Total) as Total1 from BillDetail Where VN='" + vn + "' and GroupType='" + grpname + "'";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        total111 = dtb0.Rows[0]["Total1"].ToString();
                        //name = dt.Rows[0]["Name"].ToString();
                        //comm = dt.Rows[0]["Comment"].ToString();
                        Decimal.TryParse(total111, out total1111);
                        DataRow row11 = dtprn.NewRow();
                        row11["col1"] = grpname;
                        row11["col2"] = total1111.ToString("0.00");
                        row11["col3"] = "";
                        row11["col4"] = total1111.ToString("0.00");
                        row11["sort1"] = i.ToString();
                        row11["fond_bold"] = "1";
                        row11["grp"] = "2";
                        row11["grp_name"] = grpname;
                        dtprn.Rows.Add(row11);
                    }
                }
            }

            sql = "Select Name from BillGroup Where ID=99";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    grpname = row["Name"].ToString();
                    sql = "Select * from BillDetail Where Total<>0 and VN='" + vn + "' and GroupType='" + grpname + "'";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        DataRow row1 = dtprn.NewRow();
                        row1["col1"] = grpname;
                        row1["sort1"] = "";
                        row1["fond_bold"] = "1";
                        row1["grp"] = "3";
                        dtprn.Rows.Add(row1);
                        int i = 3001;
                        foreach (DataRow dr in dtb0.Rows)
                        {
                            name = dr["Name"].ToString();
                            total111 = dr["Total"].ToString();
                            comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name;
                            row11["col2"] = total1111.ToString("0.00");
                            row11["col3"] = "";
                            row11["col4"] = comm;
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "";
                            row11["grp"] = "3";
                            row11["grp_name"] = grpname;
                            dtprn.Rows.Add(row11);
                        }
                    }
                }
            }

            sql = "Select Name from BillGroup Where ID=102";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    grpname = row["Name"].ToString();
                    sql = "Select * from BillDetail Where Total<>0 and VN='" + vn + "' and GroupType='" + grpname + "'";
                    dtb0 = conn.selectData(conn.conn, sql);
                    if (dtb0.Rows.Count > 0)
                    {
                        DataRow row1 = dtprn.NewRow();
                        row1["col1"] = "Other Service";
                        row1["sort1"] = "";
                        row1["fond_bold"] = "1";
                        row1["grp"] = "4";
                        dtprn.Rows.Add(row1);
                        int i = 4001;
                        foreach (DataRow dr in dtb0.Rows)
                        {
                            name = dr["Name"].ToString();
                            total111 = dr["Total"].ToString();
                            //comm = dr["Comment"].ToString();
                            Decimal.TryParse(total111, out total1111);
                            DataRow row11 = dtprn.NewRow();
                            row11["col1"] = name + " " + comm;
                            row11["col2"] = total1111.ToString("0.00");
                            row11["col3"] = "";
                            row11["col4"] = total1111.ToString("0.00");
                            row11["sort1"] = i.ToString();
                            row11["fond_bold"] = "";
                            row11["grp"] = "4";
                            row11["grp_name"] = "Other Service";
                            dtprn.Rows.Add(row11);
                        }
                    }
                }
            }

            return dtprn;
        }
    }
}
