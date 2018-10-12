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

namespace clinic_ivf.control
{
    public class IvfControl
    {
        public InitConfig iniC;
        private IniFile iniF;
        public ConnectDB conn;
        public int grdViewFontSize = 0;
        public List<Department> lDept;

        public IvfDB ivfDB;
        

        public String userId = "";
        public String copID = "", jobID = "", cusID = "", addrID = "", contID = "", cusrID = "", custID = "", stfID = "", deptID = "", posiID = "", drawID = "";
        public String rContactName = "", rContacTel = "", rContID = "", userIderc = "";
                
        public Staff sStf, cStf;
        
        public LogFile lf;
        public Staff user;

        public Color cTxtFocus;
        
        public FtpClient ftpC;
        Regex regEmail;
        String soapTaxId = "";
        public String FixJobCode = "IMP", FixEccCode = "CC";

        public VisitOld sVsOld;

        public IvfControl()
        {
            initConfig();
            
        }
        private void initConfig()
        {
            String appName = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
            }
            iniF = new IniFile(appName);
            iniC = new InitConfig();
            user = new Staff();
            cStf = new Staff();
            sStf = new Staff();

            GetConfig();
            conn = new ConnectDB(iniC);

            ivfDB = new IvfDB(conn);

            sVsOld = new VisitOld();
        }
        public void GetConfig()
        {
            iniC.hostDB = iniF.getIni("connection","hostDB");           
            iniC.nameDB = iniF.getIni("connection", "nameDB");
            iniC.userDB = iniF.getIni("connection", "userDB");
            iniC.passDB = iniF.getIni("connection", "passDB");            
            iniC.portDB = iniF.getIni("connection", "portDB");

            iniC.hostFTP = iniF.getIni("ftp", "hostFTP");
            iniC.userFTP = iniF.getIni("ftp", "userFTP");
            iniC.passFTP = iniF.getIni("ftp", "passFTP");
            iniC.portFTP = iniF.getIni("connection", "portFTP");

            iniC.grdViewFontSize = iniF.getIni("app", "grdViewFontSize");
            iniC.grdViewFontName = iniF.getIni("app", "grdViewFontName");
            iniC.themeApplication = iniF.getIni("app", "themeApplication");
            iniC.txtFocus = iniF.getIni("app", "txtFocus");
            iniC.grfRowColor = iniF.getIni("app", "grfRowColor");

            iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;
            int.TryParse(iniC.grdViewFontSize, out grdViewFontSize);
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
                    dt1 = DateTime.Parse(dt.ToString());
                    re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                }
            }
            return re;
        }
    }
}
