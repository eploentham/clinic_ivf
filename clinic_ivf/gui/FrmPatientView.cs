using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmPatientView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colPttId = 1, colPttHn = 2, colPttName = 3, colPttRemark = 4;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Boolean flagReadCard = false;
        String _CardReaderTFK2700 = "";
        RDNID mRDNIDWRAPPER = new RDNID();
        string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        enum NID_FIELD
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
        public FrmPatientView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            chkToday.Checked = true;

            btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            btnSmartcard.Click += BtnSmartcard_Click;

            initGrfPtt();
            setGrfPtt("");
        }

        private void BtnSmartcard_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ReadCard();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                flagReadCard = false;
                setGrfPtt(txtSearch.Text);
            }
            else
            {
                if (txtSearch.Text.Length >= 2)
                {
                    flagReadCard = false;
                    setGrfPtt(txtSearch.Text);
                }
            }
        }

        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfPtt.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPtt.ContextMenu = menuGw;
            gB.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");
            
        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfPtt(String search)
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            grfPtt.DataSource = null;
            grfPtt.Rows.Count = 1;
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectByDate1(date);
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectByDate1(date);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    if (chkToday.Checked)
                    {
                        grfPtt.DataSource = ic.ivfDB.pttDB.selectBySearchDate(date);
                    }
                    
                }
                else
                {

                }
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectBySearch(search);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    grfPtt.DataSource = ic.ivfDB.pttDB.selectBySearch(search);
                }
                else
                {
                    grfPtt.DataSource = ic.ivfDB.pttOldDB.selectBySearch(search);
                }
            }
            
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colPttHn].Editor = txt;
            grfPtt.Cols[colPttName].Editor = txt;
            grfPtt.Cols[colPttRemark].Editor = txt;

            grfPtt.Cols[colPttName].Width = 250;
            grfPtt.Cols[colPttHn].Width = 120;
            grfPtt.Cols[colPttRemark].Width = 300;
            
            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colPttName].Caption = "Name";
            grfPtt.Cols[colPttRemark].Caption = "Remark";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            for (int i = 1; i <= grfPtt.Rows.Count - 1; i++)
            {
                grfPtt[i, 0] = i;
                if (i % 2 == 0)
                    grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfPtt.Cols[colPttId].Visible = false;
            theme1.SetTheme(grfPtt, ic.theme);
            
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfPtt[grfPtt.Row, colPttId] != null ? grfPtt[grfPtt.Row, colPttId].ToString() : "";
            chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colPttName] != null ? grfPtt[grfPtt.Row, colPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                //grfReq.Rows.Remove(grfReq.Row);
                openPatientAdd(id, name);
            //}
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openPatientAdd("", "");
        }
        private void openPatientAdd(String pttId, String name)
        {
            FrmPatientAdd frm;
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                frm = new FrmPatientAdd(ic, pttId, "", "");
            }
            else
            {
                frm = new FrmPatientAdd(ic,"", pttId,"");
            }
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน Patient " + name;
            }
            else
            {
                txt = "ป้อน Patient ใหม่ ";
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void FrmPatientView_Load(object sender, EventArgs e)
        {
            theme1.SetTheme(groupBox1, ic.theme);
            theme1.SetTheme(gB, ic.theme);
            theme1.SetTheme(grfPtt, ic.theme);
            foreach (Control c in groupBox1.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
            foreach (Control c in gB.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
            txtSearch.Focus();
        }
        protected int ReadCard()
        {
            try
            {
                byte[] Licinfo = new byte[1024];
                RDNID.getLicenseInfoRD(Licinfo);
                //m_lblDLXInfo.Text = ic.aByteToString(Licinfo);
                //String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                _CardReaderTFK2700 = ic.ListCardReader();
                String strTerminal = _CardReaderTFK2700;
                IntPtr obj = ic.selectReader(strTerminal);

                Int32 nInsertCard = 0;
                nInsertCard = RDNID.connectCardRD(obj);
                if (nInsertCard != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nInsertCard);
                    MessageBox.Show(m);

                    RDNID.disconnectCardRD(obj);
                    RDNID.deselectReaderRD(obj);
                    return nInsertCard;
                }

                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;
                String NIDNum = ic.aByteToString(id);

                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;

                String NIDData = ic.aByteToString(data);
                if (NIDData == "")
                {
                    MessageBox.Show("Read Text error");
                }
                else
                {
                    string[] fields = NIDData.Split('#');
                    gB.Text = "ค้นหา pid";
                    txtSearch.Value = NIDNum;
                    setGrfPtt(txtSearch.Text);
                    if (grfPtt.Rows.Count <= 1)
                    {
                        gB.Text = "ค้นหา namet";
                        txtSearch.Value = fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.SURNAME_T];
                        setGrfPtt(txtSearch.Text);
                        if (grfPtt.Rows.Count <= 1)
                        {
                            gB.Text = "ค้นหา namee";
                            txtSearch.Value = fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.SURNAME_E];
                            setGrfPtt(txtSearch.Text);
                        }
                    }
                    
                    ////m_txtID.Text = NIDNum;                             // or use m_txtID.Text = fields[(int)NID_FIELD.NID_Number];
                    //txtPid.Value = NIDNum;
                    //String fullname = fields[(int)NID_FIELD.TITLE_T] + " " +
                    //                    fields[(int)NID_FIELD.NAME_T] + " " +
                    //                    fields[(int)NID_FIELD.MIDNAME_T] + " " +
                    //                    fields[(int)NID_FIELD.SURNAME_T];
                    ////m_txtFullNameT.Text = fullname;
                    //txtPttName.Value = fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " ";
                    //txtPttLName.Value = fields[(int)NID_FIELD.SURNAME_T];
                    //txtPttNameE.Value = fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.MIDNAME_E] + " ";
                    //txtPttLNameE.Value = fields[(int)NID_FIELD.SURNAME_E];
                    ////fullname = fields[(int)NID_FIELD.TITLE_E] + " " +
                    ////                    fields[(int)NID_FIELD.NAME_E] + " " +
                    ////                    fields[(int)NID_FIELD.MIDNAME_E] + " " +
                    ////                    fields[(int)NID_FIELD.SURNAME_E];
                    ////m_txtFullNameE.Text = fullname;

                    ////m_txtBrithDate.Text = ic._yyyymmdd_(fields[(int)NID_FIELD.BIRTH_DATE]);
                    //String dob = fields[(int)NID_FIELD.BIRTH_DATE];
                    //if (dob.Length >= 8)
                    //{
                    //    dob = dob.Substring(0, 4) + "-" + dob.Substring(4, 2) + "-" + dob.Substring(dob.Length - 2);
                    //    txtDob.Value = dob;
                    //}
                    //txtAddrNo.Value = fields[(int)NID_FIELD.HOME_NO];
                    //txtMoo.Value = fields[(int)NID_FIELD.MOO];
                    //txtRoad.Value = fields[(int)NID_FIELD.TROK] + " " + fields[(int)NID_FIELD.SOI] + " " + fields[(int)NID_FIELD.ROAD] + " " + fields[(int)NID_FIELD.TUMBON] + " " + fields[(int)NID_FIELD.AMPHOE] + " " + fields[(int)NID_FIELD.PROVINCE];
                    ////m_txtAddress.Text = fields[(int)NID_FIELD.HOME_NO] + "   " +
                    ////                        fields[(int)NID_FIELD.MOO] + "   " +
                    ////                        fields[(int)NID_FIELD.TROK] + "   " +
                    ////                        fields[(int)NID_FIELD.SOI] + "   " +
                    ////                        fields[(int)NID_FIELD.ROAD] + "   " +
                    ////                        fields[(int)NID_FIELD.TUMBON] + "   " +
                    ////                        fields[(int)NID_FIELD.AMPHOE] + "   " +
                    ////                        fields[(int)NID_FIELD.PROVINCE] + "   "
                    //;
                    //if (fields[(int)NID_FIELD.GENDER] == "1")
                    //{
                    //    //m_txtGender.Text = "ชาย";
                    //    cboSex.SelectedIndex = 1;
                    //    cboPrefix.Text = "Mr.";
                    //}
                    //else
                    //{
                    //    //m_txtGender.Text = "หญิง";
                    //    cboSex.SelectedIndex = 2;
                    //    cboPrefix.Text = "Miss";
                    //}
                    ////m_txtIssueDate.Text = _yyyymmdd_(fields[(int)NID_FIELD.ISSUE_DATE]);
                    ////m_txtExpiryDate.Text = _yyyymmdd_(fields[(int)NID_FIELD.EXPIRY_DATE]);
                    ////if ("99999999" == m_txtExpiryDate.Text)
                    ////    m_txtExpiryDate.Text = "99999999 ตลอดชีพ";
                    ////m_txtIssueNum.Text = fields[(int)NID_FIELD.ISSUE_NUM];
                }

                //byte[] NIDPicture = new byte[1024 * 5];
                //int imgsize = NIDPicture.Length;
                //res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                //if (res != DefineConstants.NID_SUCCESS)
                //    return res;

                //byte[] byteImage = NIDPicture;
                //if (byteImage == null)
                //{
                //    MessageBox.Show("Read Photo error");
                //}
                //else
                //{
                //    //m_picPhoto
                //    Image img = Image.FromStream(new MemoryStream(byteImage));
                //    //Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                //    Bitmap MyImage = new Bitmap(img, picPtt.Width - 2, picPtt.Height - 2);
                //    //m_picPhoto.Image = (Image)MyImage;
                //    picPtt.Image = (Image)MyImage;
                //    setControlDonor("", txtPid.Text);
                //    if (txtID.Text.Equals(""))
                //    {
                //        img.Save(picIDCard, ImageFormat.Jpeg);
                //        flagReadCard = true;
                //    }
                //}
                flagReadCard = true;
                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReadCard " + ex.Message, "");
            }

            return 0;
        }
    }
}
