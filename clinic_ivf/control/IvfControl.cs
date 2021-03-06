﻿using clinic_ivf.objdb;
using clinic_ivf.object1;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using C1.Win.C1Input;
using AForge.Video.DirectShow;
using System.IO;
using System.Reflection;
using C1.Win.C1Document;
using MySql.Data.Types;
using System.Net;
using System.Net.Sockets;
using C1.Win.C1FlexGrid;
using C1.C1Excel;
using System.Collections;
using System.Diagnostics;
using C1.Win.BarCode;
using System.IO.Ports;
using System.Data;
using clinic_ivf.gui;
using C1.Win.FlexViewer;
using C1.Win.C1Command;

namespace clinic_ivf.control
{
    public class IvfControl
    {
        public InitConfig iniC;
        private IniFile iniF;
        public ConnectDB conn;
        public int grdViewFontSize = 0;
        public List<Department> lDept;
        public Company cop;

        public IvfDB ivfDB;
        public String[] args;
        public String userId = "";
        public String copID = "", jobID = "", cusID = "", addrID = "", contID = "", cusrID = "", custID = "", stfID = "", deptID = "", posiID = "", drawID = "", email="", hnspareyear="/";
        public String rContactName = "", rContacTel = "", rContID = "", userIderc = "", NumSticker="", labrequestremark="", statusResult="", opu_report_day3 = "", opu_report_day1 = "", statusResultDay1 = "", opu_report_day5 = "", statusResultDay5 = "", opu_report_day6 = "", statusResultDay6 = "", statusResultDay0 = "", opu_report_day0="", statusResultDay2 = "", opu_report_day2="", deposit="", dwithdrawid="";
        
        public Staff sStf, cStf;
        
        //public LogFile lf;
        public Staff user;

        public Color cTxtFocus;
        
        public FtpClient ftpC;
        Regex regEmail;
        String soapTaxId = "";
        public String theme="";
        public String FixJobCode = "IMP", FixEccCode = "CC";
        public String StartupPath = "";

        public VideoCaptureDevice video;

        public VisitOld sVsOld;
        public Age age;
        public String _IPAddress = "";
        public Decimal CreditCharge = 0;
        public Boolean ftpUsePassive = false;
        Hashtable _styles;
        public LogWriter logw;
        public int spermFreezingDecimal = 0;
        //public FtpClient ftpC;
        public enum NID_FIELD
        {
            NID_Number,   //1234567890123#

            TITLE_T,    //Thai title#
            NAME_T,     //Thai name#
            MIDNAME_T,  //Thai mid name#
            SURNAME_T,  //Thai surname#

            TITLE_E,    //Eng title#
            NAME_E,     //Eng name#
            MIDNAME_E,  //Eng mid name#
            SURNAME_E,  //Eng surname#

            HOME_NO,    //12/34#
            MOO,        //10#
            TROK,       //ตรอกxxx#
            SOI,        //ซอยxxx#
            ROAD,       //ถนนxxx#
            TUMBON,     //ตำบลxxx#
            AMPHOE,     //อำเภอxxx#
            PROVINCE,   //จังหวัดxxx#

            GENDER,     //1#			//1=male,2=female

            BIRTH_DATE, //25200131#	    //YYYYMMDD 
            ISSUE_PLACE,//xxxxxxx#      //
            ISSUE_DATE, //25580131#     //YYYYMMDD 
            EXPIRY_DATE,//25680130      //YYYYMMDD 
            ISSUE_NUM,  //12345678901234 //14-Char
            END
        };
        public IvfControl(String[] args)
        {
            initConfig(args);
            
        }
        private void initConfig(String[] args)
        {
            this.args = args;
            String appName = "", appName1 = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            appName1 = appName;

            //MessageBox.Show("001 " + appName, "");
            //MessageBox.Show("001111 args.Length " + args.Length, "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
                //appName1 = appName;
                //MessageBox.Show("0012 " + appName, "");
            }
            //MessageBox.Show("002", "");
            StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (args == null)
            {
                //MessageBox.Show("0021 "+ appName, "");
                iniF = new IniFile(appName);
            }
            else
            {
                //MessageBox.Show("0022 " + StartupPath + "\\" + appName1 + ".ini", "");
                iniF = new IniFile(StartupPath + "\\" + appName1 + ".ini");
            }
            
            iniC = new InitConfig();
            user = new Staff();
            cStf = new Staff();
            sStf = new Staff();
            cop = new Company();
            logw = new LogWriter();
            //MessageBox.Show("003 " + appName+ "\nStartupPath"+ StartupPath, "");
            //MessageBox.Show("00411111112", "");
            GetConfig();
            //MessageBox.Show("004", "");
            conn = new ConnectDB(iniC);
            //MessageBox.Show("005", "");
            ftpC = new FtpClient(iniC.hostFTP, iniC.userFTP, iniC.passFTP,ftpUsePassive, iniC.pathChar);
            
            //ivfDB = new IvfDB(conn);

            sVsOld = new VisitOld();
            cTxtFocus = ColorTranslator.FromHtml(iniC.txtFocus);
            if (iniC.statusAppDonor.Equals("1"))
            {
                theme = iniC.themeDonor;
            }
            else
            {
                theme = iniC.themeApplication;
            }
        }
        public String GetCurrentExecutingDirectory()
        {
            string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
        public void getInit()
        {
            ivfDB.sexDB.getlSex();
            cop = ivfDB.copDB.selectByCode1("001");
            _IPAddress = GetLocalIPAddress();
            conn._IPAddress = _IPAddress;
        }
        public void GetConfig()
        {
            //MessageBox.Show("0031", "");
            try
            {
                iniC.hostDB = iniF.getIni("connection", "hostDB");
                //MessageBox.Show("0032 "+ iniC.hostDB, "");
                iniC.nameDB = iniF.getIni("connection", "nameDB");
                iniC.userDB = iniF.getIni("connection", "userDB");
                iniC.passDB = iniF.getIni("connection", "passDB");
                iniC.portDB = iniF.getIni("connection", "portDB");

                iniC.hostDBEx = iniF.getIni("connection", "hostDBEx");
                iniC.nameDBEx = iniF.getIni("connection", "nameDBEx");
                iniC.userDBEx = iniF.getIni("connection", "userDBEx");
                iniC.passDBEx = iniF.getIni("connection", "passDBEx");
                iniC.portDBEx = iniF.getIni("connection", "portDBEx");
                //MessageBox.Show("0033 " + iniC.hostDBEx, "");
                iniC.hostFTP = iniF.getIni("ftp", "hostFTP");
                iniC.userFTP = iniF.getIni("ftp", "userFTP");
                iniC.passFTP = iniF.getIni("ftp", "passFTP");
                iniC.portFTP = iniF.getIni("ftp", "portFTP");
                iniC.folderFTP = iniF.getIni("ftp", "folderFTP");
                iniC.usePassiveFTP = iniF.getIni("ftp", "usePassiveFTP");
                iniC.pathChar = iniF.getIni("ftp", "pathChar");

                iniC.grdViewFontSize = iniF.getIni("app", "grdViewFontSize");
                iniC.grdViewFontName = iniF.getIni("app", "grdViewFontName");
                //MessageBox.Show("0034 " + iniC.grdViewFontSize, "");
                iniC.txtFocus = iniF.getIni("app", "txtFocus");
                iniC.grfRowColor = iniF.getIni("app", "grfRowColor");
                iniC.statusAppDonor = iniF.getIni("app", "statusAppDonor");
                iniC.themeApplication = iniF.getIni("app", "themeApplication");
                iniC.themeApp = iniF.getIni("app", "themeApp");
                iniC.themeDonor = iniF.getIni("app", "themeDonor");
                iniC.themeDonor1 = iniF.getIni("app", "themeDonor1");
                iniC.printerSticker = iniF.getIni("app", "printerSticker");
                iniC.timerlabreqaccept = iniF.getIni("app", "timerlabreqaccept");
                //MessageBox.Show("0035 " + iniC.timerlabreqaccept, "");
                iniC.sticker_donor_width = iniF.getIni("sticker_donor", "width");
                iniC.sticker_donor_height = iniF.getIni("sticker_donor", "height");
                iniC.sticker_donor_start_y = iniF.getIni("sticker_donor", "start_y");
                iniC.sticker_donor_barcode_height = iniF.getIni("sticker_donor", "barcode_height");
                iniC.sticker_donor_barcode_gap_x = iniF.getIni("sticker_donor", "barcode_gap_x");
                iniC.sticker_donor_barcode_gap_y = iniF.getIni("sticker_donor", "barcode_gap_y");
                iniC.sticker_donor_gap = iniF.getIni("sticker_donor", "gap");
                iniC.sticker_donor_start_x = iniF.getIni("sticker_donor", "start_x");
                iniC.status_show_border = iniF.getIni("sticker_donor", "status_show_border");
                iniC.barcode_width_minus = iniF.getIni("sticker_donor", "barcode_width_minus");
                iniC.printStickerLeft = iniF.getIni("sticker_donor", "printStickerLeft");
                iniC.printStickerRight = iniF.getIni("sticker_donor", "printStickerRight");
                iniC.printStickerTop = iniF.getIni("sticker_donor", "printStickerTop");
                //MessageBox.Show("0036 " + iniC.printStickerTop, "");
                iniC.grfRowRed = iniF.getIni("app", "grfRowRed");
                iniC.grfRowGreen = iniF.getIni("app", "grfRowGreen");
                iniC.grfRowYellow = iniF.getIni("app", "grfRowYellow");
                iniC.timerImgScanNew = iniF.getIni("app", "timerImgScanNew");
                iniC.pathImageScan = iniF.getIni("app", "pathImageScan");
                iniC.patientaddpanel1weight = iniF.getIni("app", "patientaddpanel1weight");
                iniC.creditCharge = iniF.getIni("app", "creditCharge");
                iniC.service_point_id = iniF.getIni("app", "service_point_id");
                iniC.statusCheckDonor = iniF.getIni("app", "statusCheckDonor");
                iniC.printerBill = iniF.getIni("app", "printerBill");
                iniC.printerAppointment = iniF.getIni("app", "printerAppointment");
                iniC.pathSaveExcelAppointment = iniF.getIni("app", "pathSaveExcelAppointment");
                iniC.printerA4 = iniF.getIni("app", "printerA4");
                iniC.statusCashierOldProgram = iniF.getIni("app", "statusCashierOldProgram");
                iniC.spermFreezingDecimal = iniF.getIni("app", "spermFreezingDecimal");
                iniC.statusNurseOrderInclude = iniF.getIni("app", "statusNurseOrderInclude");
                //iniC.grdViewFontName = iniF.getIni("app", "grdViewFontName");
                iniC.pdfFontName = iniF.getIni("app", "pdfFontName");
                iniC.pdfViewFontSize = iniF.getIni("app", "pdfViewFontSize");
                iniC.pathDownloadFile = iniF.getIni("app", "pathDownloadFile");

                iniC.email_form = iniF.getIni("email", "email_form");
                iniC.email_auth_user = iniF.getIni("email", "email_auth_user");
                iniC.email_auth_pass = iniF.getIni("email", "email_auth_pass");
                iniC.email_port = iniF.getIni("email", "email_port");
                iniC.email_ssl = iniF.getIni("email", "email_ssl");
                iniC.email_to_sperm_freezing = iniF.getIni("email", "email_to_sperm_freezing");
                iniC.themeFET = iniF.getIni("app", "themeFET");
                iniC.lisBarcode = iniF.getIni("app", "lisBarcode");
                iniC.messageDebug = iniF.getIni("app", "messageDebug");
                iniC.email_to_lab_opu = iniF.getIni("email", "email_to_lab_opu");
                iniC.email_form_lab_opu = iniF.getIni("email", "email_form_lab_opu");
                iniC.email_auth_user_lab_opu = iniF.getIni("email", "email_auth_user_lab_opu");
                iniC.email_auth_pass_lab_opu = iniF.getIni("email", "email_auth_pass_lab_opu");
                iniC.email_to_lab_fet = iniF.getIni("email", "email_to_lab_fet");
                iniC.email_form_lab_fet = iniF.getIni("email", "email_form_lab_fet");
                iniC.email_auth_user_lab_fet = iniF.getIni("email", "email_auth_user_lab_fet");
                iniC.email_auth_pass_lab_fet = iniF.getIni("email", "email_auth_pass_lab_fet");
                iniC.email_to_labblood = iniF.getIni("email", "email_to_labblood");

                iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;
                iniC.pdfFontName = iniC.pdfFontName.Equals("") ? iniC.grdViewFontName : iniC.pdfFontName;
                iniC.pdfViewFontSize = iniC.pdfViewFontSize.Equals("") ? iniC.grdViewFontSize : iniC.pdfViewFontSize;
                //MessageBox.Show("0037 " + iniC.lisBarcode, "");
                iniC.sticker_donor_width = iniC.sticker_donor_width.Equals("") ? "120" : iniC.sticker_donor_width;
                iniC.sticker_donor_height = iniC.sticker_donor_height.Equals("") ? "90" : iniC.sticker_donor_height;
                iniC.sticker_donor_start_y = iniC.sticker_donor_start_y.Equals("") ? "60" : iniC.sticker_donor_start_y;
                iniC.sticker_donor_barcode_height = iniC.sticker_donor_barcode_height.Equals("") ? "40" : iniC.sticker_donor_barcode_height;
                iniC.sticker_donor_barcode_gap_x = iniC.sticker_donor_barcode_gap_x.Equals("") ? "5" : iniC.sticker_donor_barcode_gap_x;
                iniC.sticker_donor_barcode_gap_y = iniC.sticker_donor_barcode_gap_y.Equals("") ? "30" : iniC.sticker_donor_barcode_gap_y;
                iniC.sticker_donor_gap = iniC.sticker_donor_gap.Equals("") ? "20" : iniC.sticker_donor_gap;
                iniC.sticker_donor_start_x = iniC.sticker_donor_start_x.Equals("") ? "52" : iniC.sticker_donor_start_x;
                iniC.patientaddpanel1weight = iniC.patientaddpanel1weight == null ? "320" : iniC.patientaddpanel1weight.Equals("") ? "300" : iniC.patientaddpanel1weight;
                iniC.printerSticker = iniC.printerSticker.Equals("") ? "default" : iniC.printerSticker;
                iniC.status_show_border = iniC.status_show_border.Equals("") ? "0" : iniC.status_show_border;
                iniC.barcode_width_minus = iniC.barcode_width_minus.Equals("") ? "0" : iniC.barcode_width_minus;
                iniC.timerlabreqaccept = iniC.timerlabreqaccept.Equals("") ? "120" : iniC.timerlabreqaccept;

                iniC.hostFTP = iniC.hostFTP == null ? "" : iniC.hostFTP;
                iniC.userFTP = iniC.userFTP == null ? "" : iniC.userFTP;
                iniC.passFTP = iniC.passFTP == null ? "" : iniC.passFTP;
                iniC.portFTP = iniC.portFTP == null ? "" : iniC.portFTP;

                iniC.themeApplication = iniC.themeApplication == null ? "Office2007Blue" : iniC.themeApplication.Equals("") ? "Office2007Blue" : iniC.themeApplication;
                iniC.themeDonor = iniC.themeDonor == null ? "Office2007Blue" : iniC.themeDonor.Equals("") ? "Office2007Blue" : iniC.themeDonor;
                iniC.themeDonor1 = iniC.themeDonor1 == null ? "MacBlue" : iniC.themeDonor1.Equals("") ? "MacBlue" : iniC.themeDonor1;
                iniC.themeFET = iniC.themeFET == null ? "Office2016Black" : iniC.themeFET.Equals("") ? "Office2016Black" : iniC.themeFET;
                iniC.lisBarcode = iniC.themeFET == null ? "Code_128_B" : iniC.lisBarcode.Equals("") ? "" : iniC.lisBarcode;

                iniC.grfRowRed = iniC.grfRowRed == null ? "#FF0266" : iniC.grfRowRed.Equals("") ? "#FF0266" : iniC.grfRowRed;
                iniC.grfRowGreen = iniC.grfRowGreen == null ? "#7CB342" : iniC.grfRowGreen.Equals("") ? "#7CB342" : iniC.grfRowGreen;
                iniC.grfRowYellow = iniC.grfRowYellow == null ? "#FFDE03" : iniC.grfRowYellow.Equals("") ? "#FFDE03" : iniC.grfRowYellow;

                iniC.statusAppDonor = iniC.statusAppDonor == null ? "1" : iniC.statusAppDonor.Equals("") ? "1" : iniC.statusAppDonor;
                iniC.timerImgScanNew = iniC.timerImgScanNew == null ? "2" : iniC.timerImgScanNew.Equals("") ? "0" : iniC.timerImgScanNew;
                iniC.pathImageScan = iniC.pathImageScan == null ? "d:\\images" : iniC.pathImageScan.Equals("") ? "d:\\images" : iniC.pathImageScan;
                iniC.folderFTP = iniC.folderFTP == null ? "images_medical_record" : iniC.folderFTP.Equals("") ? "images_medical_record" : iniC.folderFTP;
                iniC.creditCharge = iniC.creditCharge == null ? "3" : iniC.creditCharge.Equals("") ? "3" : iniC.creditCharge;
                iniC.usePassiveFTP = iniC.usePassiveFTP == null ? "false" : iniC.usePassiveFTP.Equals("") ? "false" : iniC.usePassiveFTP;
                iniC.service_point_id = iniC.service_point_id == null ? "2120000002" : iniC.service_point_id.Equals("") ? "2120000002" : iniC.service_point_id;
                iniC.statusCheckDonor = iniC.statusCheckDonor == null ? "0" : iniC.statusCheckDonor.Equals("") ? "0" : iniC.statusCheckDonor;
                iniC.messageDebug = iniC.messageDebug == null ? "0" : iniC.messageDebug.Equals("") ? "0" : iniC.messageDebug;
                iniC.pathChar = iniC.pathChar == null ? "\\" : iniC.pathChar.Equals("") ? "\\" : iniC.pathChar;
                iniC.statusCashierOldProgram = iniC.statusCashierOldProgram == null ? "0" : iniC.statusCashierOldProgram.Equals("") ? "0" : iniC.statusCashierOldProgram;
                iniC.spermFreezingDecimal = iniC.spermFreezingDecimal == null ? "0" : iniC.spermFreezingDecimal.Equals("") ? "0" : iniC.spermFreezingDecimal;
                iniC.statusNurseOrderInclude = iniC.statusNurseOrderInclude == null ? "0" : iniC.statusNurseOrderInclude.Equals("") ? "0" : iniC.statusNurseOrderInclude;
                iniC.pathDownloadFile = iniC.pathDownloadFile == null ? "C:\\Manual" : iniC.pathDownloadFile.Equals("") ? "C:\\Manual" : iniC.pathDownloadFile;

                int.TryParse(iniC.grdViewFontSize, out grdViewFontSize);
                int.TryParse(iniC.spermFreezingDecimal, out spermFreezingDecimal);
                Decimal.TryParse(iniC.creditCharge, out CreditCharge);
                Boolean.TryParse(iniC.usePassiveFTP, out ftpUsePassive);
            }
            catch(Exception ex)
            {
                new LogWriter("e", ex.Message);
                MessageBox.Show("error "+ex.Message, "");
            }
            
            //MessageBox.Show("00401 " + iniC.hostDB, "");
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
                    if(DateTime.TryParse(dt, out dt1))
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
        public String dateTimetoDB1(Object dt)
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
                    if (DateTime.TryParse(dt.ToString(), out dt1))
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
                        if (DateTime.TryParse(dt.ToString(), out dt1))
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
        public String dateTimetoDB(String dt)
        {
            DateTime dt1 = new DateTime();
            String re = "", tim="";
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
            return re+" "+ tim;
        }
        public String timetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            //MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    re = dt1.ToString("HH:mm:ss");
                }
            }
            return re;
        }
        public String datetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            //MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if(DateTime.TryParse(dt.ToString(),out dt1))
                {
                    if (dt1.Year < 1900) return "";
                    re = dt1.ToString("dd-MM-yyyy");
                }
            }
            return re;
        }
        public String datetimetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    re = dt1.ToString("dd-MM-yyyy HH:mm:ss");
                }
            }
            return re;
        }
        public void setCboBarcodeType(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            C1BarCode barc = new C1BarCode();
            var codetype = Enum.GetValues(typeof(C1.BarCode.CodeType));
            //codetype.gett
            //foreach(C1.BarCode.CodeType name in codetype)
            //{
            //    String value1 = "";
            //    if (name == null) continue;
            //    //value1 = Enum.get(typeof(C1.BarCode.CodeType), name);
            //}

            foreach (C1.BarCode.CodeType value1 in  Enum.GetValues(typeof(C1.BarCode.CodeType)))
            {
                //if (value1 == null) continue;
                String name = "";
                //name = Enum.get(typeof(C1.BarCode.CodeType), value1);
                item = new ComboBoxItem();
                item.Value = name.ToString();
                item.Text = value1.ToString();
                c.Items.Add(item);
            }
        }
        public void setCboSpermAppearance(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "Normal";
            item.Text = "Normal";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "High";
            item.Text = "High";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "Low";
            item.Text = "Low";
            c.Items.Add(item);

        }
        public void setCboPkgGrp(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "LID";
            item.Text = "LAB";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "SID";
            item.Text = "Special Item";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "DUID";
            item.Text = "DRUG";
            c.Items.Add(item);

        }
        public void setCboLangSticker(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "English";
            item.Text = "English";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "Thai";
            item.Text = "Thai";
            c.Items.Add(item);
            c.SelectedItem = "English";
        }
        public void setCboLangSticker(C1ComboBox c,String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "English";
            item.Text = "English";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "Thai";
            item.Text = "Thai";
            c.Items.Add(item);
            c.SelectedItem = selected;
        }
        public void setCboDay(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            for(int i=1;i<=6;i++)
            {
                item = new ComboBoxItem();
                item.Value = i.ToString();
                item.Text = i.ToString();
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
            }
        }
        public void setCboDayFETEmbryoDev(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);

            item = new ComboBoxItem();
            item.Value = "2";
            item.Text = "2";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "3";
            item.Text = "3";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "4";
            item.Text = "4";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "5";
            item.Text = "5";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "6";
            item.Text = "6";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "5,6";
            item.Text = "5,6";
            c.Items.Add(item);

        }
        public void setCboDayEmbryoDev(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "2";
            item.Text = "2";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "3";
            item.Text = "3";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "5";
            item.Text = "5";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "6";
            item.Text = "6";
            c.Items.Add(item);

        }
        public String getC1ComboBySelectedIndex(C1ComboBox c)
        {
            if (c.Items.Count == 0) return "";
            int i = 0, row=0;
            row = c.SelectedIndex;
            ComboBoxItem item1 = new ComboBoxItem();
            foreach (ComboBoxItem item in c.Items)
            {
                if (i==row)
                {
                    item1 = item;
                    break;
                }
                i++;
            }
            return item1.Value;
        }
        public void setC1Combo(C1ComboBox c, String data)
        {
            if (c.Items.Count == 0) return;
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            c.SelectedIndex = 0;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Value.Equals(data))
                {
                    c.SelectedItem = item;
                    break;
                }
            }
        }
        public C1ComboBox setCboCldReport(C1ComboBox c)
        {
            //C1ComboBox c = new C1ComboBox();
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "BillDetail Excel";
            item.Text = "BillDetailExcel";
            c.Items.Add(item);

            return c;
        }
        public void setC1ComboByName(C1ComboBox c, String data)
        {
            if (c.Items.Count == 0) return;
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            c.SelectedIndex = 0;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    c.SelectedItem = item;
                    break;
                }
            }
        }
        public String getC1Combo(C1ComboBox c, String data)
        {
            String re = "";
            if (c.Items.Count == 0) return "";
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.Value;
                    break;
                }
            }
            return re;
        }
        public C1ComboBox setCboPttTypeDonor(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();

            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)

            item = new ComboBoxItem();
            item.Text = "Patient";
            item.Value = "1";
            c.Items.Add(item);

            item = new ComboBoxItem();
            item.Text = "Egg Donor";
            item.Value = "2";
            c.Items.Add(item);

            item = new ComboBoxItem();
            item.Text = "Surrogate";
            item.Value = "3";
            c.Items.Add(item);

            if (!selected.Equals(""))
            {
                c.SelectedText = selected;
            }

            return c;
        }
        public C1ComboBox setCboPttType(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            
            item = new ComboBoxItem();
            item.Text = "Patient";
            item.Value = "1";
            c.Items.Add(item);

            //item = new ComboBoxItem();
            //item.Text = "Egg Donor";
            //item.Value = "2";
            //c.Items.Add(item);

            //item = new ComboBoxItem();
            //item.Text = "Surrogate";
            //item.Value = "3";
            //c.Items.Add(item);

            if (!selected.Equals(""))
            {
                c.SelectedText = selected;
            }
            
            return c;
        }
        public C1ComboBox setCboPttGroup(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();

            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)

            item = new ComboBoxItem();
            item.Text = "A";
            item.Value = "a";
            c.Items.Add(item);

            item = new ComboBoxItem();
            item.Text = "B";
            item.Value = "b";            
            c.Items.Add(item);
            if (!selected.Equals(""))
            {
                c.SelectedText = selected;
            }
            return c;
        }
        public C1ComboBox setCboNurseReport(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            item = new ComboBoxItem();
            item.Text = "";
            item.Value = "";
            c.Items.Add(item);

            item = new ComboBoxItem();
            item.Text = "List คนไข้ประจำวัน";
            item.Value = "rptnur001";
            c.Items.Add(item);
            return c;
        }
        public C1ComboBox setCboApmTime(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            item = new ComboBoxItem();
            item.Text = "";
            item.Value = "";
            c.Items.Add(item);
            for (int i = 5; i <= 22; i++)
            {
                String val = "", txt = "";
                val = i.ToString("00")+":00";
                txt = val;
                item = new ComboBoxItem();
                item.Text = val;
                item.Value = txt;
                c.Items.Add(item);

                val = i.ToString("00") + ":15";
                txt = val;
                item = new ComboBoxItem();
                item.Text = val;
                item.Value = txt;
                c.Items.Add(item);

                val = i.ToString("00") + ":30";
                txt = val;
                item = new ComboBoxItem();
                item.Text = val;
                item.Value = txt;
                c.Items.Add(item);
            }

            return c;
        }
        public C1ComboBox setCboPrinter(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            item = new ComboBoxItem();
            item.Text = "";
            item.Value = "";
            c.Items.Add(item);
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                item = new ComboBoxItem();
                item.Text = printer;
                item.Value = printer;
                c.Items.Add(item);
            }
            return c;
        }
        public void savePicPatienttoServer( String filename, Image pic)
        {
            if (File.Exists(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                File.Delete(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            String datetick = "";
            datetick = DateTime.Now.Ticks.ToString();
            pic.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            pic.Save(@"temppic_"+ datetick+"." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            ftpC.createDirectory(iniC.folderFTP + "/" + filename);
            ftpC.upload(iniC.folderFTP + "/" + filename + "/" +filename+"." + System.Drawing.Imaging.ImageFormat.Jpeg, @"temppic" + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public void delPicOPUtoServer(String opuCode, String filename)
        {
            //if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            //{
            //    File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //pathFile.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            ftpC.createDirectory(iniC.folderFTP + "/");
            ftpC.createDirectory(iniC.folderFTP + "/" + opuCode);
            ftpC.delete(filename);
            
        }
        public void savePicOPUtoServer(String opuCode, String filename, String pathFile)
        {
            //if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            //{
            //    File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //pathFile.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            ftpC.createDirectory(iniC.folderFTP);
            ftpC.createDirectory(iniC.folderFTP + "/" + opuCode);
            ftpC.delete(iniC.folderFTP + "/" + opuCode + "/" + filename);
            //ftpC.upload( filename, pathFile);
            ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
        }
        public void savePicOPUtoServerDebug(String opuCode, String filename, String pathFile)
        {
            //if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            //{
            //    File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //pathFile.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            new LogWriter("d", "IvfControl savePicOPUtoServerDebug 00" );
            ftpC.createDirectory(iniC.folderFTP);
            new LogWriter("d", "IvfControl savePicOPUtoServerDebug 01");
            ftpC.createDirectory(iniC.folderFTP + "/" + opuCode);
            new LogWriter("d", "IvfControl savePicOPUtoServerDebug 02");
            ftpC.delete(iniC.folderFTP + "/" + opuCode + "/" + filename);
            new LogWriter("d", "IvfControl savePicOPUtoServerDebug 03");
            //ftpC.upload( filename, pathFile);
            ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
            new LogWriter("d", "IvfControl savePicOPUtoServerDebug 04");
        }
        public void saveFilePatienttoServer(String pttId,String filenamenew, String localpathandfilename)
        {
            //if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            //{
            //    File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //pic.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, localpathandfilename);
            String[] sur = localpathandfilename.Split('.');
            String ex = "";
            if (sur.Length == 2)
            {
                ex = sur[1];
            }
            //ftpC.createDirectory("images/" + pttId);
            ftpC.createDirectory("" );
            //ftpC.upload("images/"+pttId + "/" + filenamenew + "." + ex, localpathandfilename);
            ftpC.upload(iniC.folderFTP + "." + ex, localpathandfilename);
        }
        public void saveFilePatientHNtoServer(String hn,String filename, Image pic)
        {
            if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            pic.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            ftpC.createDirectory(hn);
            ftpC.upload(DateTime.Now.Year.ToString() + "/" + filename + "." + System.Drawing.Imaging.ImageFormat.Jpeg, @"temppic" + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public bool compareImage(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }
        public String ListCardReader()
        {
            string fileName = StartupPath + "\\RDNIDLib.DLX";
            if (System.IO.File.Exists(fileName) == false)
            {
                MessageBox.Show("RDNIDLib.DLX not found");
            }

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //this.Text = String.Format("R&D NID Card VC# {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            byte[] _lic = String2Byte(fileName);

            int nres = 0;
            nres = RDNID.openNIDLibRD(_lic);
            if (nres != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nres);
                MessageBox.Show(m);
            }

            byte[] Licinfo = new byte[1024];

            RDNID.getLicenseInfoRD(Licinfo);

            //m_lblDLXInfo.Text = aByteToString(Licinfo);

            byte[] Softinfo = new byte[1024];
            RDNID.getSoftwareInfoRD(Softinfo);
            //m_lblSoftwareInfo.Text = aByteToString(Softinfo);

            String re = "";
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return "";
            String s = aByteToString(szReaders);
            String[] readlist = s.Split(';');
            if (readlist != null)
            {
                re = readlist[0];
                //for (int i = 0; i < readlist.Length; i++)
                //    m_ListReaderCard.Items.Add(readlist[i]);
                //m_ListReaderCard.SelectedIndex = 0;
            }
            return re;
        }
        public string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        public IntPtr selectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = String2Byte(reader);
            IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
                mCard = (IntPtr)res;
            return mCard;
        }
        static byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }
        public String _yyyymmdd_(String d)
        {
            string s = "";
            string _yyyy = d.Substring(0, 4);
            string _mm = d.Substring(4, 2);
            string _dd = d.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
            string _tm = "-";
            if (_mm == "00")
            {
                _tm = "-";
            }
            else
            {
                _tm = mm[int.Parse(_mm)];
            }
            if (_yyyy == "0000")
                _yyyy = "-";

            if (_dd == "00")
                _dd = "-";

            s = _dd + " " + _tm + " " + _yyyy;
            return s;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //bmp.Dispose();
            return bmp;
        }
        public String getBillVN(String vn, String agentId, String userId)
        {
            //ต้อง void ตาม VN เพราะในหน้า frmcashierview ได้สร้างบิล ทำให้ ไม่รู้บิล จริงๆ เอา process มาจาก โปรแกรมเดิม
            ivfDB.VoidBillByVN(vn, userId);
            String billid = ivfDB.getBill(vn, agentId, userId);
            return billid;
        }
        public string NumberToText(long number)
        {
            StringBuilder wordNumber = new StringBuilder();

            string[] powers = new string[] { "Thousand ", "Million ", "Billion " };
            string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] ones = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                       "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            if (number == 0) { return "Zero"; }
            if (number < 0)
            {
                wordNumber.Append("Negative ");
                number = -number;
            }

            long[] groupedNumber = new long[] { 0, 0, 0, 0 };
            int groupIndex = 0;

            while (number > 0)
            {
                groupedNumber[groupIndex++] = number % 1000;
                number /= 1000;
            }

            for (int i = 3; i >= 0; i--)
            {
                long group = groupedNumber[i];

                if (group >= 100)
                {
                    wordNumber.Append(ones[group / 100 - 1] + " Hundred ");
                    group %= 100;

                    if (group == 0 && i > 0)
                        wordNumber.Append(powers[i - 1]);
                }

                if (group >= 20)
                {
                    if ((group % 10) != 0)
                        wordNumber.Append(tens[group / 10 - 2] + " " + ones[group % 10 - 1] + " ");
                    else
                        wordNumber.Append(tens[group / 10 - 2] + " ");
                }
                else if (group > 0)
                    wordNumber.Append(ones[group - 1] + " ");

                if (group != 0 && i > 0)
                    wordNumber.Append(powers[i - 1]);
            }

            return wordNumber.ToString().Trim();
        }
        public string NumberToCurrencyText(decimal number, MidpointRounding midpointRounding)
        {
            // Round the value just in case the decimal value is longer than two digits
            number = decimal.Round(number, 2, midpointRounding);

            string wordNumber = string.Empty;

            // Divide the number into the whole and fractional part strings
            string[] arrNumber = number.ToString().Split('.');

            // Get the whole number text
            long wholePart = long.Parse(arrNumber[0]);
            string strWholePart = NumberToText(wholePart);

            // For amounts of zero dollars show 'No Dollars...' instead of 'Zero Dollars...'
            wordNumber = (wholePart == 0 ? "No" : strWholePart) + (wholePart == 1 ? " Dollar and " : " Dollars and ");

            // If the array has more than one element then there is a fractional part otherwise there isn't
            // just add 'No Cents' to the end
            if (arrNumber.Length > 1)
            {
                // If the length of the fractional element is only 1, add a 0 so that the text returned isn't,
                // 'One', 'Two', etc but 'Ten', 'Twenty', etc.
                long fractionPart = long.Parse((arrNumber[1].Length == 1 ? arrNumber[1] + "0" : arrNumber[1]));
                string strFarctionPart = NumberToText(fractionPart);

                wordNumber += (fractionPart == 0 ? " No" : strFarctionPart) + (fractionPart == 1 ? " Cent" : " Cents");
            }
            else
                wordNumber += "No Cents";

            return wordNumber;
        }
        public string NumberToCurrencyTextThaiBaht(decimal number, MidpointRounding midpointRounding)
        {
            // Round the value just in case the decimal value is longer than two digits
            number = decimal.Round(number, 2, midpointRounding);

            string wordNumber = string.Empty;

            // Divide the number into the whole and fractional part strings
            string[] arrNumber = number.ToString().Split('.');

            // Get the whole number text
            long wholePart = long.Parse(arrNumber[0]);
            string strWholePart = NumberToText(wholePart);

            // For amounts of zero dollars show 'No Dollars...' instead of 'Zero Dollars...'
            //wordNumber = (wholePart == 0 ? "No" : strWholePart) + (wholePart == 1 ? " Dollar and " : " Dollars and ");
            wordNumber = (wholePart == 0 ? "No" : strWholePart) + (wholePart == 1 ? " Baht " : " Baht ");

            // If the array has more than one element then there is a fractional part otherwise there isn't
            // just add 'No Cents' to the end
            //if (arrNumber.Length > 1)
            //{
            //    // If the length of the fractional element is only 1, add a 0 so that the text returned isn't,
            //    // 'One', 'Two', etc but 'Ten', 'Twenty', etc.
            //    long fractionPart = long.Parse((arrNumber[1].Length == 1 ? arrNumber[1] + "0" : arrNumber[1]));
            //    string strFarctionPart = NumberToText(fractionPart);

            //    wordNumber += (fractionPart == 0 ? " No" : strFarctionPart) + (fractionPart == 1 ? " Cent" : " Cents");
            //}
            //else
            //    wordNumber += "No Cents";

            return wordNumber;
        }
        public String showVN(String vn)
        {
            String re = "";
            try
            {
                re = vn.Substring(vn.Length - 5, 5);
            }
            catch(Exception ex)
            {

            }

            return re;
        }
        public String showHN(String hn, String hnyear)
        {
            String re = "";
            try
            {
                re = hn+hnspareyear+hnyear;
            }
            catch (Exception ex)
            {

            }

            return re;
        }
        public void SaveSheet(C1FlexGrid flex, XLSheet sheet, C1XLBook _book, bool fixedCells)
        {
            // account for fixed cells
            //int frows = flex.Rows.Fixed;
            int frows = 0;// with header
            int fcols = flex.Cols.Fixed;
            if (fixedCells) frows = fcols = 0;

            // copy dimensions
            //int lastRow = flex.Rows.Count - frows - 1;
            int lastRow = flex.Rows.Count;// with header
            int lastCol = flex.Cols.Count - fcols - 1;
            if (lastRow < 0 || lastCol < 0) return;
            XLCell cell = sheet[lastRow, lastCol];

            // set default properties
            sheet.Book.DefaultFont = flex.Font;
            sheet.DefaultRowHeight = C1XLBook.PixelsToTwips(flex.Rows.DefaultSize);
            sheet.DefaultColumnWidth = C1XLBook.PixelsToTwips(flex.Cols.DefaultSize);

            // prepare to convert styles
            _styles = new Hashtable();

            // set row/column properties
            for (int r = frows; r < flex.Rows.Count; r++)
            {
                // size/visibility
                Row fr = flex.Rows[r];
                XLRow xr = sheet.Rows[r - frows];
                if (fr.Height >= 0)
                    xr.Height = C1XLBook.PixelsToTwips(fr.Height);
                xr.Visible = fr.Visible;

                // style
                //XLStyle xs = StyleFromFlex(_book,fr.Style, _styles);
                //if (xs != null)
                //    xr.Style = xs;
            }
            for (int c = fcols; c < flex.Cols.Count; c++)
            {
                // size/visibility
                Column fc = flex.Cols[c];
                XLColumn xc = sheet.Columns[c - fcols];
                if (fc.Width >= 0)
                    xc.Width = C1XLBook.PixelsToTwips(fc.Width);
                xc.Visible = fc.Visible;

                // style
                //XLStyle xs = StyleFromFlex(_book, fc.Style, _styles);
                //if (xs != null)
                //    xc.Style = xs;
            }

            // load cells
            for (int r = frows; r < flex.Rows.Count; r++)
            {
                for (int c = fcols; c < flex.Cols.Count; c++)
                {
                    // get cell
                    cell = sheet[r - frows, c - fcols];

                    // apply content
                    cell.Value = flex[r, c];

                    // apply style
                    //XLStyle xs = StyleFromFlex(_book,flex.GetCellStyle(r, c), _styles);
                    //if (xs != null)
                    //    cell.Style = xs;
                }
            }
        }
        public void SaveSheetDataTable(DataTable flex, XLSheet sheet, C1XLBook _book, bool fixedCells)
        {
            // account for fixed cells
            //int frows = flex.Rows.Fixed;
            int frows = 0;// with header
            //int fcols = flex.Cols.Fixed;
            //if (fixedCells) frows = fcols = 0;

            // copy dimensions
            //int lastRow = flex.Rows.Count - frows - 1;
            int lastRow = flex.Rows.Count;// with header
            int lastCol = flex.Columns.Count - 1;
            if (lastRow < 0 || lastCol < 0) return;
            XLCell cell = sheet[lastRow, lastCol];

            // set default properties
            sheet.Book.DefaultFont = new Font(iniC.grdViewFontName, grdViewFontSize, FontStyle.Regular);
            //sheet.DefaultRowHeight = C1XLBook.PixelsToTwips(flex.Rows.DefaultSize);
            //sheet.DefaultColumnWidth = C1XLBook.PixelsToTwips(flex.Cols.DefaultSize);

            // prepare to convert styles
            _styles = new Hashtable();

            // set row/column properties
            
            // load cells
            for (int r = frows; r < flex.Rows.Count; r++)
            {
                for (int c = 0; c < flex.Columns.Count; c++)
                {
                    // get cell
                    cell = sheet[r - frows, c];

                    // apply content
                    cell.Value = flex.Rows[r][c];

                    // apply style
                    //XLStyle xs = StyleFromFlex(_book,flex.GetCellStyle(r, c), _styles);
                    //if (xs != null)
                    //    cell.Style = xs;
                }
            }
        }
        private XLStyle StyleFromFlex(C1XLBook _book, CellStyle style,Hashtable _styles)
        {
            // sanity
            if (style == null)
                return null;

            // look it up on list
            if (_styles.Contains(style))
                return _styles[style] as XLStyle;

            // create new Excel style
            XLStyle xs = new XLStyle(_book);

            // set up new style
            xs.Font = style.Font;
            if (style.BackColor.ToArgb() != SystemColors.Window.ToArgb())
            {
                xs.BackColor = style.BackColor;
            }
            xs.WordWrap = style.WordWrap;
            xs.Format = XLStyle.FormatDotNetToXL(style.Format);
            switch (style.TextDirection)
            {
                case TextDirectionEnum.Up:
                    xs.Rotation = 90;
                    break;
                case TextDirectionEnum.Down:
                    xs.Rotation = 180;
                    break;
            }
            switch (style.TextAlign)
            {
                case TextAlignEnum.CenterBottom:
                    xs.AlignHorz = XLAlignHorzEnum.Center;
                    xs.AlignVert = XLAlignVertEnum.Bottom;
                    break;
                case TextAlignEnum.CenterCenter:
                    xs.AlignHorz = XLAlignHorzEnum.Center;
                    xs.AlignVert = XLAlignVertEnum.Center;
                    break;
                case TextAlignEnum.CenterTop:
                    xs.AlignHorz = XLAlignHorzEnum.Center;
                    xs.AlignVert = XLAlignVertEnum.Top;
                    break;
                case TextAlignEnum.GeneralBottom:
                    xs.AlignHorz = XLAlignHorzEnum.General;
                    xs.AlignVert = XLAlignVertEnum.Bottom;
                    break;
                case TextAlignEnum.GeneralCenter:
                    xs.AlignHorz = XLAlignHorzEnum.General;
                    xs.AlignVert = XLAlignVertEnum.Center;
                    break;
                case TextAlignEnum.GeneralTop:
                    xs.AlignHorz = XLAlignHorzEnum.General;
                    xs.AlignVert = XLAlignVertEnum.Top;
                    break;
                case TextAlignEnum.LeftBottom:
                    xs.AlignHorz = XLAlignHorzEnum.Left;
                    xs.AlignVert = XLAlignVertEnum.Bottom;
                    break;
                case TextAlignEnum.LeftCenter:
                    xs.AlignHorz = XLAlignHorzEnum.Left;
                    xs.AlignVert = XLAlignVertEnum.Center;
                    break;
                case TextAlignEnum.LeftTop:
                    xs.AlignHorz = XLAlignHorzEnum.Left;
                    xs.AlignVert = XLAlignVertEnum.Top;
                    break;
                case TextAlignEnum.RightBottom:
                    xs.AlignHorz = XLAlignHorzEnum.Right;
                    xs.AlignVert = XLAlignVertEnum.Bottom;
                    break;
                case TextAlignEnum.RightCenter:
                    xs.AlignHorz = XLAlignHorzEnum.Right;
                    xs.AlignVert = XLAlignVertEnum.Center;
                    break;
                case TextAlignEnum.RightTop:
                    xs.AlignHorz = XLAlignHorzEnum.Right;
                    xs.AlignVert = XLAlignVertEnum.Top;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            // save it
            _styles.Add(style, xs);

            // return it
            return xs;
        }
        public void setCboPORT(C1ComboBox cbo)
        {
            try
            {
                int index = 0;
                String[] ArrayComPortsNames = SerialPort.GetPortNames();
                if (ArrayComPortsNames.Length == 0)
                {
                    MessageBox.Show("No Comm Port", "");
                    return;
                }
                Array.Sort(ArrayComPortsNames);
                foreach (String port in ArrayComPortsNames)
                {
                    index += 1;
                    cbo.Items.Add(ArrayComPortsNames[index]);
                }
                //do
                //{

                //}
                //while (!((ArrayComPortsNames[index] == ComPortName)
                //              || (index == ArrayComPortsNames.GetUpperBound(0))));


                //want to get first out
                //if (index == ArrayComPortsNames.GetUpperBound(0))
                //{
                //    ComPortName = ArrayComPortsNames[0];
                //}
                //cbo.Text = ArrayComPortsNames[0];
                cbo.SelectedIndex = 0;
            }
            catch(Exception ex)
            {

            }
            
        }
        public void setCboBAUDRATE(C1ComboBox cbo)
        {
            cbo.Items.Add(300);
            cbo.Items.Add(600);
            cbo.Items.Add(1200);
            cbo.Items.Add(2400);
            cbo.Items.Add(9600);
            cbo.Items.Add(14400);
            cbo.Items.Add(19200);
            cbo.Items.Add(38400);
            cbo.Items.Add(57600);
            cbo.Items.Add(115200);
            cbo.Items.ToString();
            //get first item print in text
            if (cbo.SelectedIndex >= 4)     // from Recommend
            {
                cbo.SelectedIndex = 4;
            }
            else
            {
                cbo.SelectedIndex = 0;
            }
            //cbo.Text = cbo.Items[0].ToString();
        }
        public void setCboDATABIT(C1ComboBox cbo)
        {
            cbo.Items.Add(7);
            cbo.Items.Add(8);
            cbo.SelectedIndex = 0;
            //cbo.Text = cbo.Items[0].ToString();
        }
        public void setCboStopBIT(C1ComboBox cbo)
        {
            cbo.Items.Add("One");
            cbo.Items.Add("OnePointFive");
            cbo.Items.Add("Two");
            //cbo.SelectedIndex = 0;
            if (cbo.SelectedIndex >= 1)     // from Recommend
            {
                cbo.SelectedIndex = 0;
            }
            else
            {
                cbo.SelectedIndex = 0;
            }
            //get the first item print in the text
            //cbo.Text = cbo.Items[0].ToString();
        }
        public void setCboParity(C1ComboBox cbo)
        {
            cbo.Items.Add("None");
            cbo.Items.Add("Even");
            cbo.Items.Add("Mark");
            cbo.Items.Add("Odd");
            cbo.Items.Add("Space");
            cbo.SelectedIndex = 0;

            //cbo.Text = cbo.Items[0].ToString();
        }
        public void setCboHandShaking(C1ComboBox cbo)
        {
            cbo.Items.Add("None");
            cbo.Items.Add("XOnXOff");
            cbo.Items.Add("RequestToSend");
            cbo.Items.Add("RequestToSendXOnXOff");
            if (cbo.SelectedIndex >= 1)     // from Recommend
            {
                cbo.SelectedIndex = 1;
            }
            else
            {
                cbo.SelectedIndex = 0;
            }
            //cbo.SelectedIndex = 0;
            //cbo.Text = cbo.Items[0].ToString();
        }
        public void setCboBItemType(C1ComboBox cbo)
        {
            cbo.Items.Add("LAB");
            cbo.Items.Add("Special");
            cbo.Items.Add("Drug");
            cbo.SelectedIndex = 0;

            //cbo.Text = cbo.Items[0].ToString();
        }
        public C1ComboBox setCboYear(C1ComboBox c)
        {
            c.Items.Clear();
            c.Items.Add(System.DateTime.Now.Year );
            c.Items.Add(System.DateTime.Now.Year - 1);
            c.Items.Add(System.DateTime.Now.Year - 2);
            c.SelectedIndex = 0;
            return c;
        }
        public Size MeasureString(Control c, string text)
        {
            return TextRenderer.MeasureText(text, c.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.SingleLine | TextFormatFlags.NoClipping | TextFormatFlags.PreserveGraphicsClipping);
        }
        public Size MeasureString(Control c)
        {
            return TextRenderer.MeasureText(c.Text, c.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.SingleLine | TextFormatFlags.NoClipping | TextFormatFlags.PreserveGraphicsClipping);
        }
        public void setRptLabBloodInfectious(String vsid, Form frm1)
        {
            FrmReport frm = new FrmReport(this);
            DataTable dt = new DataTable();
            Visit vs = new Visit();
            Patient ptt = new Patient();
            LabResult lbRes = new LabResult();
            vs = ivfDB.vsDB.selectByPk1(vsid);
            ptt = ivfDB.pttDB.selectByPk1(vs.t_patient_id);
            dt = ivfDB.lbresDB.selectLabBloodByVsIdInfectious(vsid);

            lbRes = ivfDB.lbresDB.selectByVsId(vsid);

            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String date1 = "", collectdate = "", receivedate = "", reporter = "", approved = "", reportername = "", approvedname = "";
            Staff stf = new Staff();
            //reporter = ivfDB.stfDB.getIdByNameSurname(lbRes.staff_id_result);
            //approved = ivfDB.stfDB.getIdByNameSurname(lbRes.staff_id_approve);
            stf = ivfDB.stfDB.selectByPk1(lbRes.staff_id_result);
            reportername = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            stf = ivfDB.stfDB.selectByPk1(lbRes.staff_id_approve);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            String dob = "", sex="";
            dob = datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            sex = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ivfDB.lbresDB.lbRes.req_date_time].ToString();
                receivedate = row[ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                row["patient_hn"] = ptt.patient_hn;
                row["patient_name"] = ptt.Name;
                row["patient_dob"] = dob;
                row["patient_sex"] = sex;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = cop.comp_name_t;
                    row["line2"] = cop.addr1;
                    row["line3"] = cop.addr2;
                }
            }
            frm.setLabBloodReportInfectious(dt, ptt.patient_hn, ptt.Name, dob, sex, reportername, approvedname, datetoShow(lbRes.date_time_result), datetoShow(lbRes.date_time_approve), datetimetoShow(collectdate), datetimetoShow(receivedate));
            frm.ShowDialog(frm1);
        }
        public void setRptHormone(String vsid, Form frm1)
        {
            FrmReport frm = new FrmReport(this);
            DataTable dt = new DataTable();
            Visit vs = new Visit();
            Patient ptt = new Patient();
            LabResult lbRes = new LabResult();
            vs = ivfDB.vsDB.selectByPk1(vsid);
            ptt = ivfDB.pttDB.selectByPk1(vs.t_patient_id);
            dt = ivfDB.lbresDB.selectLabBloodByVsIdHormone(vsid);
            lbRes = ivfDB.lbresDB.selectByVsId(vsid);
            
            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String amh = "", collectdate = "", receivedate = "", reporter = "", approved = "", reportername = "", approvedname = "";
            Staff stf = new Staff();
            //lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            //reporter = ivfDB.stfDB.getIdByNameSurname(cboEmbryologistReport.Text);
            //approved = ivfDB.stfDB.getIdByNameSurname(cboEmbryologistAppv.Text);
            stf = ivfDB.stfDB.selectByPk1(lbRes.staff_id_result);
            reportername = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            stf = ivfDB.stfDB.selectByPk1(lbRes.staff_id_approve);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            String dob = "", sex = "";
            dob = datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            sex = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ivfDB.lbresDB.lbRes.date_time_collect].ToString();
                receivedate = row[ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                if (row["LID"].ToString().Equals("10"))
                {
                    amh = "1";
                }
                else
                {
                    //amh = "0";
                }
                row["patient_hn"] = ptt.patient_hn;
                row["patient_name"] = ptt.Name.ToUpper();
                row["patient_dob"] = dob;
                row["patient_sex"] = sex;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = cop.comp_name_t;
                    row["line2"] = cop.addr1;
                    row["line3"] = cop.addr2;
                }
            }
            String date1 = "";
            if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
            {
                frm.setLabBloodReportHormone(dt, ptt.patient_hn, ptt.Name.ToUpper(), dob, sex, reportername, approvedname, datetoShow(lbRes.date_time_result), datetoShow(lbRes.date_time_approve), "1", amh, datetimetoShow(collectdate), datetimetoShow(receivedate));
            }
            else
            {
                frm.setLabBloodReportHormone(dt, ptt.patient_hn, ptt.Name.ToUpper(), dob, sex, reportername, approvedname, datetoShow(lbRes.date_time_result), datetoShow(lbRes.date_time_approve), "", amh, datetimetoShow(collectdate), datetimetoShow(receivedate));
            }

            frm.ShowDialog(frm1);
        }
        public void showResultDay(String opuid, String day, Form this1, String filename1)
        {
            String filenameembryo = "", ext1 = "";
            Boolean chk = false;
            if (filename1.Length > 0)
            {
                ext1 = Path.GetExtension(filename1);
                filenameembryo = filename1.Replace(ext1, "") + "_embryo_day" + day+ext1;
                if (File.Exists(filename1))
                {
                    chk = true;
                }
            }
            LabOpu opu1 = new LabOpu();
            //opu1 = ic.ivfDB.opuDB.selectByPk1(txtID.Text.Trim());
            opu1 = ivfDB.opuDB.selectByPk1(opuid);
            Form frm = new Form();
            C1DockingTab tC1 = new C1DockingTab();
            C1DockingTabPage tabDay = new C1DockingTabPage();
            C1DockingTabPage tabEmbryo = new C1DockingTabPage();
            C1FlexViewer day1View = new C1FlexViewer();
            C1FlexViewer day1Embryo = new C1FlexViewer();

            tC1.SuspendLayout();
            tabDay.SuspendLayout();
            tabEmbryo.SuspendLayout();
            day1View.SuspendLayout();
            day1Embryo.SuspendLayout();

            tC1.Dock = System.Windows.Forms.DockStyle.Fill;
            tC1.HotTrack = true;
            tC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tC1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tC1.TabsShowFocusCues = true;
            tC1.Alignment = TabAlignment.Top;
            tC1.SelectedTabBold = true;
            tC1.Name = "tC1";
            tabDay.Name = "tabDay";
            tabDay.TabIndex = 0;
            tabDay.Text = "Report Day" + day;
            tabEmbryo.Name = "tabEmbryo";
            tabEmbryo.TabIndex = 0;
            tabEmbryo.Text = "Embryo Day" + day;
            tC1.Controls.Add(tabDay);
            tC1.Controls.Add(tabEmbryo);

            day1View = new C1FlexViewer();
            day1View.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day1View.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day1View.Dock = System.Windows.Forms.DockStyle.Fill;
            day1View.Location = new System.Drawing.Point(0, 0);
            day1View.Name = "day1View";
            day1View.Size = new System.Drawing.Size(1065, 790);
            day1View.TabIndex = 0;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            MemoryStream stream = null;
            C1PdfDocumentSource pdsEmbryo = new C1PdfDocumentSource();


            if (chk)
            {
                pds.LoadFromFile(filename1);
                if (File.Exists(filenameembryo))
                {
                    pdsEmbryo.LoadFromFile(filenameembryo);
                }
                    
            }
            else
            {
                FtpClient ftpc = new FtpClient(iniC.hostFTP, iniC.userFTP, iniC.passFTP, ftpUsePassive);
                //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
                if (day.Equals("1"))
                {
                    stream = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day1);
                }
                else if (day.Equals("2"))
                {
                    stream = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day2);
                }
                else if (day.Equals("3"))
                {
                    stream = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day3);
                }
                else if (day.Equals("5"))
                {
                    stream = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day5);
                }
                else if (day.Equals("6"))
                {
                    stream = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day6);
                }
                stream.Seek(0, SeekOrigin.Begin);
                pds.LoadFromStream(stream);

                MemoryStream streamEmbryo = null;
                //FtpClient ftpc = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
                //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
                if (day.Equals("1"))
                {
                    streamEmbryo = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + opu1.report_day1);
                }
                else if (day.Equals("2"))
                {
                    String ext = "", filename = "";
                    ext = Path.GetExtension(opu1.report_day2);
                    filename = Path.GetFileNameWithoutExtension(opu1.report_day2);
                    streamEmbryo = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + filename + "_embryo_day2" + ext);
                }
                else if (day.Equals("3"))
                {
                    String ext = "", filename = "";
                    ext = Path.GetExtension(opu1.report_day3);
                    filename = Path.GetFileNameWithoutExtension(opu1.report_day3);
                    streamEmbryo = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + filename + "_embryo_day3" + ext);
                }
                else if (day.Equals("5"))
                {
                    String ext = "", filename = "";
                    ext = Path.GetExtension(opu1.report_day5);
                    filename = Path.GetFileNameWithoutExtension(opu1.report_day5);
                    streamEmbryo = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + filename + "_embryo_day5" + ext);
                }
                else if (day.Equals("6"))
                {
                    String ext = "", filename = "";
                    ext = Path.GetExtension(opu1.report_day6);
                    filename = Path.GetFileNameWithoutExtension(opu1.report_day6);
                    streamEmbryo = ftpc.download(iniC.folderFTP + "//" + opu1.opu_code + "//" + filename + "_embryo_day6" + ext);
                }
                streamEmbryo.Seek(0, SeekOrigin.Begin);
                pdsEmbryo.LoadFromStream(streamEmbryo);
            }
            

            day1Embryo = new C1FlexViewer();
            day1Embryo.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day1Embryo.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day1Embryo.Dock = System.Windows.Forms.DockStyle.Fill;
            day1Embryo.Location = new System.Drawing.Point(0, 0);
            day1Embryo.Name = "day1Embryo";
            day1Embryo.Size = new System.Drawing.Size(1065, 790);
            day1Embryo.TabIndex = 0;
            
            

            //pds.LoadFromFile(filename1);

            tabDay.ResumeLayout(false);
            tabEmbryo.ResumeLayout(false);
            tC1.ResumeLayout(false);
            day1View.ResumeLayout(false);
            day1Embryo.ResumeLayout(false);

            tabDay.PerformLayout();
            tabEmbryo.PerformLayout();
            tC1.PerformLayout();
            day1View.PerformLayout();
            day1Embryo.PerformLayout();
            frm.PerformLayout();

            day1View.DocumentSource = pds;
            day1Embryo.DocumentSource = pdsEmbryo;
            tabDay.Controls.Add(day1View);
            tabEmbryo.Controls.Add(day1Embryo);
            frm.Controls.Add(tC1);
            frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog(this);
            frm.ShowDialog(this1);
        }
        public void setControlLabel(ref Label lb, Font fEdit, String text, String name, int x, int y)
        {
            lb.Text = text;
            lb.Font = fEdit;
            lb.Location = new System.Drawing.Point(x, y);
            lb.AutoSize = true;
            lb.Name = name;
        }
        public void setControlC1DateTimeEdit(ref C1DateEdit txt, String name, int x, int y)
        {
            txt.AllowSpinLoop = false;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            txt.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            txt.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            txt.CurrentTimeZone = false;
            txt.DisplayFormat.CustomFormat = "dd/MM/yyyy";
            txt.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            txt.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            txt.EditFormat.CustomFormat = "dd/MM/yyyy";
            txt.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            txt.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.GMTOffset = System.TimeSpan.Parse("00:00:00");
            txt.ImagePadding = new System.Windows.Forms.Padding(0);
            //txt.Culture = 1033;     // English US

            txt.Location = new System.Drawing.Point(x, y);
            txt.Name = name;
            txt.Size = new System.Drawing.Size(111, 20);
            txt.TabIndex = 12;
            txt.Tag = null;
            txt.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            txt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
        }
        public void setControlC1FlexViewer(ref C1FlexViewer fvPrnEmailSummary, String name)
        {
            fvPrnEmailSummary = new C1FlexViewer();
            fvPrnEmailSummary.AutoScrollMargin = new System.Drawing.Size(0, 0);
            fvPrnEmailSummary.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            fvPrnEmailSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            fvPrnEmailSummary.Location = new System.Drawing.Point(0, 0);
            fvPrnEmailSummary.Name = name;
            fvPrnEmailSummary.Size = new System.Drawing.Size(1065, 790);
            fvPrnEmailSummary.TabIndex = 0;
            fvPrnEmailSummary.Ribbon.Minimized = true;
        }
        public void setControlC1ComboBox(ref C1ComboBox cbo, String name, int width, int x, int y)
        {
            cbo.AllowSpinLoop = false;
            cbo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cbo.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            cbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            cbo.GapHeight = 0;
            cbo.ImagePadding = new System.Windows.Forms.Padding(0);
            cbo.ItemsDisplayMember = "";
            cbo.ItemsValueMember = "";
            cbo.Location = new System.Drawing.Point(x, y);
            cbo.Name = name;
            cbo.Size = new System.Drawing.Size(65, 20);
            cbo.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            cbo.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            cbo.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            cbo.TabIndex = 538;
            cbo.Tag = null;
            cbo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            cbo.Size = new Size(width, 30);
        }
        public void setControlC1Button(ref C1Button btn, Font fEdit, String text, String name, int x, int y)
        {
            btn = new C1Button();
            btn.Name = name;
            btn.Text = text;
            btn.Font = fEdit;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new Size(MeasureString(btn).Width + 50, 30);
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.Font = fEdit;
        }
        public void setControlCheckBox(ref CheckBox chk, Font fEdit, String text, String name, int x, int y)
        {
            chk.BackColor = System.Drawing.Color.Transparent;
            //chk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            //chk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //chk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chk.Location = new System.Drawing.Point(x, y);
            chk.Name = name;
            chk.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chk.Text = text;
            //chk.Value = text;
            Size size = MeasureString(chk);
            chk.Width = size.Width;
            chk.TabIndex = 0;
            //theme1.SetTheme(this.chkVoid, "(default)");
            chk.UseVisualStyleBackColor = true;
            //chk.Value = null;
            //chk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chk.Font = fEdit;
        }
        public void setControlRadioBox(ref RadioButton chk, Font fEdit, String text, String name, int x, int y)
        {
            chk.Checked = false;
            chk.Name = name;
            chk.Text = text;
            chk.Font = fEdit;
            Size size = MeasureString(chk);
            chk.Width = size.Width + 20;
            chk.Location = new Point(x, y);
        }
        public void setControlC1CheckBox(ref C1CheckBox chk, Font fEdit, String text, String name, int x, int y)
        {
            chk.BackColor = System.Drawing.Color.Transparent;
            chk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chk.Location = new System.Drawing.Point(x, y);
            chk.Name = name;
            chk.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chk.Text = text;
            chk.Value = text;
            chk.Font = fEdit;
            Size size = MeasureString(chk);
            chk.Width = size.Width + 30;
            chk.TabIndex = 0;
            //theme1.SetTheme(this.chkVoid, "(default)");
            chk.UseVisualStyleBackColor = true;
            chk.Value = null;
            chk.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

        }
        public void setControlC1TextBox(ref C1TextBox txt, Font fEdit, String name, int width, int x, int y)
        {
            //txt = new C1TextBox();
            txt.Font = fEdit;
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new Size(width, 30);
            txt.Name = name;
        }
    }
}
