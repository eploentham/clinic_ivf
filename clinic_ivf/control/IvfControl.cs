using clinic_ivf.objdb;
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
        public String theme="";
        public String FixJobCode = "IMP", FixEccCode = "CC";

        public VideoCaptureDevice video;

        public VisitOld sVsOld;
        public Age age;
        //public FtpClient ftpC;

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
            cop = new Company();

            GetConfig();
            conn = new ConnectDB(iniC);
            ftpC = new FtpClient(iniC.hostFTP, iniC.userFTP, iniC.passFTP);

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
        public void getInit()
        {
            ivfDB.sexDB.getlSex();
            cop = ivfDB.copDB.selectByCode1("001");
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
            
            iniC.txtFocus = iniF.getIni("app", "txtFocus");
            iniC.grfRowColor = iniF.getIni("app", "grfRowColor");
            iniC.statusAppDonor = iniF.getIni("app", "statusAppDonor");
            iniC.themeApplication = iniF.getIni("app", "themeApplication");
            iniC.themeDonor = iniF.getIni("app", "themeDonor");
            iniC.printerSticker = iniF.getIni("app", "printerSticker");
            iniC.timerlabreqaccept = iniF.getIni("app", "timerlabreqaccept");

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

            iniC.patientaddpanel1weight = iniF.getIni("app", "patientaddpanel1weight");

            iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;

            iniC.sticker_donor_width = iniC.sticker_donor_width.Equals("") ? "120" : iniC.sticker_donor_width;
            iniC.sticker_donor_height = iniC.sticker_donor_height.Equals("") ? "90" : iniC.sticker_donor_height;
            iniC.sticker_donor_start_y = iniC.sticker_donor_start_y.Equals("") ? "60" : iniC.sticker_donor_start_y;
            iniC.sticker_donor_barcode_height = iniC.sticker_donor_barcode_height.Equals("") ? "40" : iniC.sticker_donor_barcode_height;
            iniC.sticker_donor_barcode_gap_x = iniC.sticker_donor_barcode_gap_x.Equals("") ? "5" : iniC.sticker_donor_barcode_gap_x;
            iniC.sticker_donor_barcode_gap_y = iniC.sticker_donor_barcode_gap_y.Equals("") ? "30" : iniC.sticker_donor_barcode_gap_y;
            iniC.sticker_donor_gap = iniC.sticker_donor_gap.Equals("") ? "20" : iniC.sticker_donor_gap;
            iniC.sticker_donor_start_x = iniC.sticker_donor_start_x.Equals("") ? "52" : iniC.sticker_donor_start_x;
            iniC.patientaddpanel1weight = iniC.patientaddpanel1weight==null ? "300" : iniC.patientaddpanel1weight.Equals("") ? "300" : iniC.patientaddpanel1weight;
            iniC.printerSticker = iniC.printerSticker.Equals("") ? "default" : iniC.printerSticker;
            iniC.status_show_border = iniC.status_show_border.Equals("") ? "0" : iniC.status_show_border;
            iniC.barcode_width_minus = iniC.barcode_width_minus.Equals("") ? "0" : iniC.barcode_width_minus;
            iniC.timerlabreqaccept = iniC.timerlabreqaccept.Equals("") ? "120" : iniC.timerlabreqaccept;

            iniC.hostFTP = iniC.hostFTP ==null ? "" : iniC.hostFTP;
            iniC.userFTP = iniC.userFTP == null ? "" : iniC.userFTP;
            iniC.passFTP = iniC.passFTP == null ? "" : iniC.passFTP;
            iniC.portFTP = iniC.portFTP == null ? "" : iniC.portFTP;

            iniC.themeApplication = iniC.themeApplication == null ? "Office2007Blue" : iniC.themeApplication .Equals("") ? "Office2007Blue" : iniC.themeApplication;
            iniC.themeDonor = iniC.themeDonor == null ? "Office2007Blue" : iniC.themeDonor.Equals("") ? "Office2007Blue" : iniC.themeDonor;

            iniC.statusAppDonor = iniC.statusAppDonor == null ? "1" : iniC.statusAppDonor.Equals("") ? "1" : iniC.statusAppDonor;

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
        public String datetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if(DateTime.TryParse(dt.ToString(),out dt1))
                {
                    re = dt1.ToString("dd-MM-yyyy");
                }


            }
            return re;
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
        public void setC1Combo(C1ComboBox c, String data)
        {
            if (c.Items.Count == 0) return;
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Value.Equals(data))
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
        public C1ComboBox setCboPttType(C1ComboBox c)
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
            
            return c;
        }
        public C1ComboBox setCboPttGroup(C1ComboBox c)
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

            return c;
        }
        public void savePicPatienttoServer( String filename, Image pic)
        {
            if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            pic.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            ftpC.createDirectory("images/" + filename);
            ftpC.upload("images/" + filename + "/" +filename+"." + System.Drawing.Imaging.ImageFormat.Jpeg, @"temppic" + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
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
            ftpC.createDirectory("images/" + pttId);
            ftpC.upload("images/"+pttId + "/" + filenamenew + "." + ex, localpathandfilename);
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
    }
}
