using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1Ribbon;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * 62-07-19     0009    Doctor		tabProgressNote  มี error ตอน thread run ดึง ftp อ่าน ชื่อ file
     */
    public partial class FrmDoctorAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder, grfPackage, grfPackageD, grfRxSetD, grfNote, grfpApmAll, grfVs;
        C1FlexGrid grfEggsd, grfImg, grfPg;

        String pttId = "", webcamname = "", vsid = "", flagedit = "", pApmId = "";
        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;
        EggSti eggs;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Image imgCorr, imgTran;
        public C1DockingTabPage tab;

        int colImgID = 1, colImgHn = 2, colImgImg = 3, colImgDesc = 4, colImgDesc2 = 5, colImgDesc3 = 6, colImgPathPic = 7, colImgBtn = 8, colImgStatus = 9, colImgDoctor = 10;
        int colBlId = 1, colBlName = 2, colBlQty = 3, colBlPrice = 4, colBlInclude = 5, colBlRemark = 6;
        int colPkgdId = 1, colPkgId = 2, colPkgType = 3, colPkgItmName = 4, colPkgItmId = 5, colPkgQty = 6;
        int colRxdId = 1, colRxName = 2, colRxQty = 3, colRxPrice = 4, colRxInclude = 5, colRxRemark = 6, colRxUsE = 7, colRxUsT = 8, colRxId = 9, colRxItmId = 10;
        int colNoteId = 1, colNote = 2, colNoteStatusAll = 3;
        int colVsId = 1, colVsDate = 2, colVsTime = 3, colVsETime=4, colVsBsp = 5,colNotice=6, colVsBp=7, colVsBw=8, colVsPulse=9;
        int colApmId = 1, colApmAppointment = 4, colApmDate = 2, colApmTime = 3, colApmDoctor = 5, colApmSp = 6, colApmNotice = 7, colE2 = 8, colLh = 9, colEndo = 10, colPrl = 10, colFsh = 11, colRt = 12, colLt = 13;
        int colOrdid = 1, colOrdlpid = 2, colOrdName = 3, colOrdPrice = 4, colOrdQty = 5, colOrdstatus = 6, colOrdrow1 = 7, colOrditmid = 8, colOrdInclude = 9, colOrdAmt = 10, colOrdUsE = 11, colOrdUsT = 12;
        int rowOrder = 0, spHeight = 150;
        int colEggDay = 1, colEggDate = 2, colEggE2 = 3, colEggLH = 4, colEggFSH = 5, colEggProlactin = 6, colEggRt1 = 7, colEggRt2 = 8, colEggLt1 = 9, colEggLt2 = 10, colEggEndo = 11, colEggMedi = 12, colEggId = 13, colEggEdit = 14, colEggMedi2 = 15;
        int colPgId = 1, colPgFilename = 2;
        int colHisVsId = 1, colHisVsDate = 2, colHisVsVn = 3;

        decimal rat = 0;
        Color color;
        Boolean flagImg = false;

        string documentName;
        string documentPath;
        RichTextBoxStreamType documentFileType;
        private void grfPgAdd(String msg)       // +0009
        {       // +0009
            grfPg.Invoke(new EventHandler(delegate {       // +0009
                Row row = grfPg.Rows.Add();       // +0009
                row[colPgId] = msg;       // +0009
                row[colPgFilename] = msg.Replace(txtIdOld.Text, "").Replace("/", "");       // +0009
            }));       // +0009
        }       // +0009
        public FrmDoctorAdd(IvfControl ic, MainMenu m, String pttid, String vsid)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vsid = vsid;
            this.pttId = pttid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(tabOrder, "MacSilver");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            eggs = new EggSti();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            ic.setCboLangSticker(cboLangSticker);
            ic.ivfDB.dtrOldDB.setCboDoctor(cboEggStiDtr, "");
            ic.ivfDB.eggsDB.setCboAddLab(cboEggStiAmh);
            ic.ivfDB.eggsDB.setCboTypingOther(cboEggStiOther);
            ic.ivfDB.eggsDB.setCboBhcgTest(cboEggStiBhcg);

            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            panel1.Resize += Panel1_Resize;
            cboLangSticker.SelectedIndexChanged += CboLangSticker_SelectedIndexChanged;
            btnNoteAdd.Click += BtnNoteAdd_Click;
            btnGenEggSti.Click += BtnGenEggSti_Click;
            btnEggStiPrint.Click += BtnEggStiPrint_Click;
            btnEggStiSave.Click += BtnEggStiSave_Click;
            FontBoldButton.Click += FontBoldButton_Click;
            FontItalicButton.Click += FontItalicButton_Click;
            FontUnderlineButton.Click += FontUnderlineButton_Click;
            FontStrikeoutButton.Click += FontStrikeoutButton_Click;
            FontColorPicker.Click += FontColorPicker_Click;
            BackColorPicker.Click += BackColorPicker_Click;
            ParagraphAlignLeftButton.Click += ParagraphAlignLeftButton_Click;
            ParagraphAlignCenterButton.Click += ParagraphAlignCenterButton_Click;
            ParagraphAlignRightButton.Click += ParagraphAlignRightButton_Click;
            DecreaseIndentButton.Click += DecreaseIndentButton_Click;
            IncreaseIndentButton.Click += IncreaseIndentButton_Click;
            FontSizeComboBox.ChangeCommitted += FontSizeComboBox_ChangeCommitted;
            FontFaceComboBox.ChangeCommitted += FontFaceComboBox_ChangeCommitted;
            CutButton.Click += CutButton_Click;
            CopyButton.Click += CopyButton_Click;
            FormatPainterButton.Click += FormatPainterButton_Click;
            PasteSplitButton.Click += PasteSplitButton_Click;
            SaveDocumentButton.Click += SaveDocumentButton_Click;
            UndoButton.Click += UndoButton_Click;
            RedoButton.Click += RedoButton_Click;

            setControl(vsid);

            initGrfBloodLab();
            setGrfBloodLab();
            initGrfSpermLab();
            setGrfSperm();
            initGrfEmbryoLab();
            setGrfEmbryo();
            initGrfGeneticLab();
            initGrfSpecialLab();
            initGrfRx();
            initGrfRxSet();
            initGrfOrder();
            //initGrfPackage();
            //initGrfPackageD();
            initGrfRxSetD();
            setGrfGenetic();
            setGrfSpecial();
            setGrfRx();
            setGrfRxSet();

            initGrfVs();
            setGrfVs();
            initGrfNote();
            setGrfNote();
            initGrfAdm();
            setGrfpApmAll();
            initGrfEggSti();
            setControlEggSti();
            setGrfOrder(txtVn.Text);
            initProgressNote();
            initGrfImg();
            setGrfImg();
            initGrfPg();
            setGrfPg();
        }
        private void initGrfPg()
        {
            grfPg = new C1FlexGrid();
            grfPg.Font = fEdit;
            grfPg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPg.Location = new System.Drawing.Point(0, 0);

            grfPg.DoubleClick += GrfPg_DoubleClick;

            pnPgView.Controls.Add(grfPg);

            theme1.SetTheme(grfPg, "Office2016Colorful");

        }

        private void GrfPg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "";
            id = grfPg[grfPg.Row, colPgId] != null ? grfPg[grfPg.Row, colPgId].ToString() : "";
            id = id.Replace(ic.iniC.folderFTP, "").Replace("/", "").Replace("progressnote", "").Replace(".rtf", "").Replace("_", "").Replace(txtIdOld.Text, "");
            txtVnProgressNote.Value = id;
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteProgressNote));
            threadA.Start();
        }
        private void ExecuteProgressNote(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
                MemoryStream stream = new MemoryStream();
                String filePathName = "progressnote" + "_" + txtVnProgressNote.Text + ".rtf";
                if (File.Exists(filePathName))
                {
                    File.Delete(filePathName);
                    System.Threading.Thread.Sleep(200);
                }
                String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + filePathName;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                stream = ic.ftpC.download(aaa);
                //File file1 = new File();
                //FileStream fileStream = new FileStream(filePathName, FileMode.Create);
                //fileStream.CopyTo(stream);
                //using (FileStream fileStream1 = File.Create(filePathName))
                //using (StreamWriter writer = new StreamWriter(fileStream1))
                //{
                //    //writer.w("Example 1 written");
                //}
                if (stream.Length > 0)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    using (FileStream file = new FileStream(filePathName, FileMode.Create, FileAccess.Write))
                    {
                        //byte[] bytes = new byte[stream.Length];
                        //file.Write(bytes, 0, (int)stream.Length);
                        stream.CopyTo(file);
                        file.Flush();
                        //stream.Write(bytes, 0, (int)file.Length);
                    }
                    //richTextBox1.LoadFile(filePathName, fileType);
                    if (File.Exists(filePathName))
                    {
                        richTextBox1.Invoke((Action)delegate
                        {
                            richTextBox1.LoadFile(filePathName, fileType);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                String aaa = "";
            }
        }
        private void setGrfPg()
        {
            grfPg.Clear();
            grfPg.DataSource = null;
            grfPg.Rows.Count = 1;
            grfPg.Cols.Count = 3;

            grfPg.Cols[colPgId].Width = 250;
            grfPg.Cols[colPgFilename].Width = 300;

            grfPg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPg.Cols[colPgFilename].Caption = "Desc1";


            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;

            List<string> filestxt = new List<string>();
            Thread pump = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                FtpWebRequest ftpRequest = null;
                FtpWebResponse ftpResponse = null;
                Stream ftpStream = null;
                int bufferSize = 2048;
                MemoryStream stream = new MemoryStream();
                string host = null;
                string user = null;
                string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                try
                {
                    //String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + filePathName;
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + ic.iniC.folderFTP + "/" + txtIdOld.Text);
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    ftpRequest.UseBinary = true;
                    //ftpRequest.UsePassive = false;
                    ftpRequest.UsePassive = ic.ftpUsePassive;
                    ftpRequest.KeepAlive = true;
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    //ftpStream = ftpResponse.GetResponseStream();
                    
                    StreamReader streamReader = null;
                    try
                    {
                        streamReader = new StreamReader(ftpResponse.GetResponseStream());
                        string line = streamReader.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains(".rtf"))
                            {
                                //MessageBox.Show(line);
                                filestxt.Add(line);
                                line = streamReader.ReadLine();
                            }
                            else
                            {
                                line = streamReader.ReadLine();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("setGrfPg 1 " + ex.Message + "\n ", "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                    }
                    finally
                    {
                        streamReader.Close();
                    }
                    //ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    foreach (String aaa in filestxt)
                    {
                        //Row row = grfPg.Rows.Add();
                        grfPgAdd(aaa);       // +0009
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("setGrfPg 2 " + ex.Message + "\n ", "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                }
            });
            
            pump.Start();
            //pump.Join();
            //grfImg.AutoSizeCols();
            //grfImg.AutoSizeRows();
            
            grfPg.Cols[colPgId].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfPg.Cols[colPgFilename].AllowEditing = false;

            theme1.SetTheme(grfPg, "Office2016Colorful");

        }
        private void initGrfImg()
        {
            grfImg = new C1FlexGrid();
            grfImg.Font = fEdit;
            grfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImg.Location = new System.Drawing.Point(0, 0);

            grfImg.DoubleClick += GrfImg_DoubleClick;

            pnHistoryScan.Controls.Add(grfImg);

            theme1.SetTheme(grfImg, "Office2016Colorful");

        }
        private void setGrfImg()
        {
            grfImg.Clear();
            grfImg.DataSource = null;
            grfImg.Rows.Count = 2;
            grfImg.Cols.Count = 10;

            Button btn = new Button();
            btn.BackColor = Color.Gray;

            grfImg.Cols[colImgBtn].Editor = btn;
            //grfImg.Cols[colImg].Editor = img;

            grfImg.Cols[colImgHn].Width = 250;
            grfImg.Cols[colImgImg].Width = 100;
            grfImg.Cols[colImgDesc].Width = 100;
            grfImg.Cols[colImgDesc2].Width = 100;
            grfImg.Cols[colImgDesc3].Width = 100;
            grfImg.Cols[colImgBtn].Width = 50;
            grfImg.Cols[colImgPathPic].Width = 100;

            grfImg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfImg.Cols[colImgHn].Caption = "HN";
            grfImg.Cols[colImgDesc].Caption = "Desc1";
            grfImg.Cols[colImgDesc2].Caption = "Desc2";
            grfImg.Cols[colImgDesc3].Caption = "Desc3";
            grfImg.Cols[colImgBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfImg.Cols[colImg].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfImg.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pttImgDB.selectByPttIDDept(txtPttId.Text, "1090000001");
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfImg.Rows.Add();
                row1[colImgID] = row[ic.ivfDB.pttImgDB.pttI.patient_image_id].ToString();
                row1[colImgDesc] = row[ic.ivfDB.pttImgDB.pttI.desc1].ToString();
                row1[colImgPathPic] = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                row1[colImgStatus] = row[ic.ivfDB.pttImgDB.pttI.status_image].ToString();
                String statusdoc = "";
                statusdoc = row[ic.ivfDB.pttImgDB.pttI.status_document].ToString();
                grfImg[i, 0] = i;
                if (row[ic.ivfDB.pttImgDB.pttI.image_path] != null && !row[ic.ivfDB.pttImgDB.pttI.image_path].ToString().Equals(""))
                {
                    int ii = i;
                    Thread pump = new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            //ftpRequest.UsePassive = false;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                MessageBox.Show("setGrfImgPatient 1 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                            }
                            if (statusdoc.Equals("1"))
                            {
                                loadedImage = new Bitmap(stream);
                            }
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            MessageBox.Show("setGrfImgPatient 2 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                        }
                        //grfImg.Cols[colImg].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfImg.Cols[colImgImg];
                            col.DataType = typeof(Image);
                            row1[colImgImg] = resizedImage;
                            flagImg = true;
                            //grfImg.AutoSizeCols();
                            //grfImg.AutoSizeRows();
                        }
                    });
                    pump.Start();
                    //pump.Join();
                    //grfImg.AutoSizeCols();
                    //grfImg.AutoSizeRows();
                }
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfImg.Cols[colImgID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfImg.Cols[colImgImg].AllowEditing = false;
            //grfImg.AutoSizeCols();
            grfImg.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016Colorful");

        }
        private void GrfImg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImg.Row < 0) return;
            if (grfImg.Col == colImgImg)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfImg.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfImg[row, colImgID] != null ? grfImg[row, colImgID].ToString() : "", txtIdOld.Text, grfImg[row, colImgPathPic] != null ? grfImg[row, colImgPathPic].ToString() : "", FrmShowImage.statusModule.Patient);
                frm.ShowDialog(this);
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Redo();
            this.UpdateUndoRedoButtons();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Undo();
            this.UpdateUndoRedoButtons();
        }

        private void SaveDocumentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SaveDocument();
        }

        private void PasteSplitButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Paste();
        }

        private void FormatPainterButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Copy();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Cut();
        }

        private void FontFaceComboBox_ChangeCommitted(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Font font = this.richTextBox1.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Cannot change font family while selected text has more than one font.");
                return;
            }

            string fontFamilyName = this.FontFaceComboBox.Text;

            this.richTextBox1.SelectionFont = new Font(
                fontFamilyName,
                font.Size,
                font.Style,
                font.Unit);
        }

        private void FontSizeComboBox_ChangeCommitted(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Font font = this.richTextBox1.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Cannot change font size while selected text has more than one font.");
                return;
            }

            this.richTextBox1.SelectionFont = new Font(
                font.FontFamily,
                float.Parse(this.FontSizeComboBox.Text),
                font.Style,
                GraphicsUnit.Point);
        }

        private void IncreaseIndentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionIndent += 30;
        }

        private void DecreaseIndentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionIndent -= 30;
        }

        private void ParagraphAlignRightButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Right);
        }

        private void ParagraphAlignCenterButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Center);
        }

        private void ParagraphAlignLeftButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Left);
        }

        private void BackColorPicker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionBackColor = this.BackColorPicker.Color;
        }

        private void FontColorPicker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionColor = this.FontColorPicker.Color;
        }

        private void FontStrikeoutButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Strikeout);
        }

        private void FontUnderlineButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Underline);
        }

        private void FontItalicButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Italic);
        }

        private void FontBoldButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Bold);
        }
        void SetParagraphAlignment(HorizontalAlignment alignment)
        {
            this.richTextBox1.SelectionAlignment = alignment;

            // If the user clicks the same button twice, it will get unpressed.
            // We want 1 button to be pressed at all times, so we just set 
            // the buttons' states based on current text alignment.
            this.UpdateParagraphAlignmentButtons();
        }
        void ToggleSelectionFontStyle(FontStyle fontStyle)
        {
            if (this.richTextBox1.SelectionFont == null)
            {
                MessageBox.Show("Cannot change font style while selected text has more than one font.");
            }
            else
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont,
                    this.richTextBox1.SelectionFont.Style ^ fontStyle);
            }
        }
        private void initProgressNote()
        {
            this.InitializeClipboardGroup();
            this.InitializeFontGroup();
            this.InitializeParagraphGroup();
            this.InitializeViewZoomGroup();

            this.InitializeRibbonStyleMenu();
            this.InitializeFocusManagement();
            this.InitializeUndoRedo();
            this.InitializeModifiedIcon();
            this.InitializeQatPosition();

            this.InitializeRecentDocumentList();
        }
        private void InitializeClipboardGroup()
        {
            this.UpdateClipboardGroupBasedOnCurrentTextSelection();

            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateClipboardGroupBasedOnCurrentTextSelection();
            };

            this.PasteButton.Click += new EventHandler(PasteButton_Click);
            this.PasteAsTextButton.Click += new EventHandler(PasteAsTextButton_Click);
        }
        void PasteButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }
        void PasteAsTextButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = Clipboard.GetText();
        }
        private void UpdateClipboardGroupBasedOnCurrentTextSelection()
        {
            this.CutButton.Enabled = this.CopyButton.Enabled =
                !string.IsNullOrEmpty(this.richTextBox1.SelectedText);
        }
        private void InitializeFontGroup()
        {
            // Populate the Font Face combobox with font names.
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                this.FontFaceComboBox.Items.Add(new RibbonButton(fontFamily.Name));
            }

            // Populate the Font Size combobox with some typical font sizes.
            foreach (int size in new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 })
            {
                this.FontSizeComboBox.Items.Add(new RibbonButton(size.ToString()));
            }

            // Keep ribbon controls state updated based on current text selection.
            this.UpdateFontGroupBasedOnCurrentTextSelection();
            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateFontGroupBasedOnCurrentTextSelection();
            };
        }
        private void UpdateFontGroupBasedOnCurrentTextSelection()
        {
            Font font = this.richTextBox1.SelectionFont;
            bool none = font == null;
            FontBoldButton.Pressed = none ? false : font.Bold;
            FontItalicButton.Pressed = none ? false : font.Italic;
            FontUnderlineButton.Pressed = none ? false : font.Underline;
            FontStrikeoutButton.Pressed = none ? false : font.Strikeout;
            FontFaceComboBox.Text = none ? "" : font.FontFamily.Name;
            FontSizeComboBox.Text = none ? "" : font.Size.ToString();
        }
        private void InitializeParagraphGroup()
        {
            // Keep Ribbon controls state updated based on current text selection.
            this.UpdateParagraphGroupBasedOnCurrentTextSelection();
            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateParagraphGroupBasedOnCurrentTextSelection();
            };
        }
        private void UpdateParagraphGroupBasedOnCurrentTextSelection()
        {
            this.UpdateParagraphAlignmentButtons();
        }
        private void UpdateParagraphAlignmentButtons()
        {
            HorizontalAlignment a = this.richTextBox1.SelectionAlignment;
            this.ParagraphAlignLeftButton.Pressed = a == HorizontalAlignment.Left;
            this.ParagraphAlignCenterButton.Pressed = a == HorizontalAlignment.Center;
            this.ParagraphAlignRightButton.Pressed = a == HorizontalAlignment.Right;
        }
        private void InitializeViewZoomGroup()
        {
            foreach (int percent in new int[] { 10, 30, 50, 80, 100, 120, 150, 200, 250, 300, 400, 700, 1000 })
            {
                this.ViewZoomCombobox.Items.Add(new RibbonButton(percent + "%"));
            }

            this.UpdateViewZoomComboBox();

            // Update the combo box when user zooms with the mouse wheel.
            this.richTextBox1.MouseWheel += delegate
            {
                this.UpdateViewZoomComboBox();
            };
        }
        private void UpdateViewZoomComboBox()
        {
            this.ViewZoomCombobox.Text = (this.richTextBox1.ZoomFactor * 100).ToString() + "%";
        }
        private void InitializeRibbonStyleMenu()
        {
            ribbonStyleCombo.Items.Clear();
            string[] themes = C1ThemeController.GetThemes();
            var showThemes = themes.Where((tn) =>
            {
                var ltn = tn.ToLower();
                if (ltn.Contains("visualstyle")) // avoid old "visual style" themes
                    return false;
                else
                    return true;
            });
            ribbonStyleCombo.Items.Add("(No Theme)");
            foreach (string theme in showThemes)
                ribbonStyleCombo.Items.Add(theme);
            ribbonStyleCombo.SelectedIndex = 0;
        }
        private void InitializeFocusManagement()
        {
            // Set initial focus on the text area.
            this.Shown += delegate { this.richTextBox1.Focus(); };

            // When a Ribbon button is clicked, move the focus back to the rich text box.
            this.c1Ribbon1.RibbonEvent += new RibbonEventHandler(c1Ribbon1_RibbonEvent);
        }
        void c1Ribbon1_RibbonEvent(object sender, RibbonEventArgs e)
        {
            switch (e.EventType)
            {
                case RibbonEventType.ChangeCommitted:
                case RibbonEventType.ChangeCanceled:
                case RibbonEventType.Click:
                case RibbonEventType.DialogLauncherClick:
                case RibbonEventType.DropDownClosed:
                    if (this.c1Ribbon1.Focused)
                    {
                        this.richTextBox1.Focus();
                    }
                    break;
            }
        }

        private void InitializeUndoRedo()
        {
            this.UpdateUndoRedoButtons();
            this.richTextBox1.TextChanged += delegate { this.UpdateUndoRedoButtons(); };
        }
        void UpdateUndoRedoButtons()
        {
            this.UndoButton.Enabled = this.richTextBox1.CanUndo;
            this.RedoButton.Enabled = this.richTextBox1.CanRedo;
        }
        private void InitializeModifiedIcon()
        {
            this.UpdateModifiedIcon();
            this.richTextBox1.ModifiedChanged += delegate { this.UpdateModifiedIcon(); };
        }
        private void UpdateModifiedIcon()
        {
            //this.DocumentModifiedLabel.Enabled = this.richTextBox1.Modified;
            //this.DocumentModifiedLabel.ToolTip = this.richTextBox1.Modified
            //    ? "Document modified"
            //    : "Document not modified";
        }
        private void InitializeQatPosition()
        {
            Properties.Settings settings = Properties.Settings.Default;

            // Initialize QAT position from application settings.
            this.c1Ribbon1.Qat.BelowRibbon = settings.QatBelowRibbon;

            // Update application setting when QAT position changes.
            this.c1Ribbon1.Qat.PositionChanged += delegate
            {
                settings.QatBelowRibbon = this.c1Ribbon1.Qat.BelowRibbon;
            };
        }
        private RecentDocumentList recentDocuments;
        private void InitializeRecentDocumentList()
        {
            // Create a new collection if it was not serialized before.
            if (Properties.Settings.Default.RecentDocuments == null)
            {
                Properties.Settings.Default.RecentDocuments = new StringCollection();
            }

            this.recentDocuments = new RecentDocumentList(this.c1Ribbon1.ApplicationMenu.RightPaneItems, Settings.Default.RecentDocuments, this.LoadRecentDocument);

            //RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
            //String filePathName = "progressnote" + "_" + txtVn.Text + ".rtf";
            //richTextBox1.LoadFile(filePathName, fileType);
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteProgressNote1));
            threadA.Start();
        }
        private void ExecuteProgressNote1(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
                MemoryStream stream = new MemoryStream();
                String filePathName = "progressnote" + "_" + txtVn.Text + ".rtf";
                if (File.Exists(filePathName))
                {
                    File.Delete(filePathName);
                    System.Threading.Thread.Sleep(200);
                }
                String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + filePathName;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                stream = ic.ftpC.download(aaa);
                if(stream.Length<=0) return;
                //File file1 = new File();
                //FileStream fileStream = new FileStream(filePathName, FileMode.Create);
                //fileStream.CopyTo(stream);
                //using (FileStream fileStream1 = File.Create(filePathName))
                //using (StreamWriter writer = new StreamWriter(fileStream1))
                //{
                //    //writer.w("Example 1 written");
                //}
                stream.Seek(0, SeekOrigin.Begin);
                using (FileStream file = new FileStream(filePathName, FileMode.Create, FileAccess.Write))
                {
                    //byte[] bytes = new byte[stream.Length];
                    //file.Write(bytes, 0, (int)stream.Length);
                    stream.CopyTo(file);
                    file.Flush();
                    //stream.Write(bytes, 0, (int)file.Length);
                }
                //richTextBox1.LoadFile(filePathName, fileType);
                richTextBox1.Invoke((Action)delegate
                {
                    richTextBox1.LoadFile(filePathName, fileType);
                });
            }
            catch (Exception ex)
            {
                String aaa = "";
            }
        }
        private void LoadRecentDocument(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("File does not exist: " + filename);
                return;
            }

            if (!this.PromtToSaveDocument()) return;

            this.LoadDocument(filename);
        }
        private bool PromtToSaveDocument()
        {
            if (!this.richTextBox1.Modified) return true;

            DialogResult dr = MessageBox.Show(
                "Do you want to save '" + this.documentName + "'?",
                "WordPad Sample", MessageBoxButtons.YesNoCancel);

            switch (dr)
            {
                case DialogResult.Cancel:
                    return false;

                case DialogResult.No:
                    return true;

                case DialogResult.Yes:
                    return this.SaveDocument();
            }

            throw new ApplicationException();
        }
        private void LoadDocument(string filePathName)
        {
            RichTextBoxStreamType streamType = filePathName.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
            try
            {
                this.richTextBox1.LoadFile(filePathName, streamType);
                this.SetDocumentProperties(filePathName, streamType);
                this.recentDocuments.Update(filePathName);
                this.RaiseRichTextBoxSelectionChanged();
            }
            catch (IOException e)
            {
                // there is no such file
                MessageBox.Show(e.Message);
            }
        }
        private bool SaveDocument()
        {
            return this.SaveDocument(this.documentPath == null);
        }

        private bool SaveDocument(bool showDialog)
        {
            //if (showDialog)
            //{
            //    SaveFileDialog dlg = new SaveFileDialog();
            //    dlg.FileName = this.documentName;
            //    if (this.documentPath != null) dlg.InitialDirectory = this.documentPath;
            //    dlg.Filter = "Rich text file (*.rtf)|*.rtf|"
            //        + "Rich text file, no OLE objects (*.rtf)|*.rtf|"
            //        + "Plain text file, no OLE objects (*.txt)|*.txt|"
            //        + "Plain text file, OLE objects replaced with text (*.txt)|*.txt|"
            //        + "Unicode text file, no OLE objects (*.txt)|*.txt";

            //    DialogResult dr = dlg.ShowDialog();
            //    if (dr == DialogResult.Cancel) return false;
            //    if (dr != DialogResult.OK) throw new ApplicationException();

            //    RichTextBoxStreamType fileType;

            //    switch (dlg.FilterIndex)
            //    {
            //        case 1: fileType = RichTextBoxStreamType.RichText; break;
            //        case 2: fileType = RichTextBoxStreamType.RichNoOleObjs; break;
            //        case 3: fileType = RichTextBoxStreamType.PlainText; break;
            //        case 4: fileType = RichTextBoxStreamType.TextTextOleObjs; break;
            //        case 5: fileType = RichTextBoxStreamType.UnicodePlainText; break;
            //        default: throw new ApplicationException();
            //    }

            //    this.SetDocumentProperties(dlg.FileName, fileType);
            //}
            RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
            this.SetDocumentProperties("progressnote_" + txtVn.Text + ".rtf", fileType);
            this.SaveDocumentAs(this.documentFileType);

            return true;
        }

        private void SaveDocumentAs(RichTextBoxStreamType fileType)
        {
            //string filePathName = this.documentPath + '\\' + this.documentName;
            try
            {
                String filePathName = this.documentPath + '\\' + this.documentName;
                if (File.Exists(filePathName))
                {
                    File.Delete(filePathName);
                    System.Threading.Thread.Sleep(200);
                }
                this.richTextBox1.SaveFile(filePathName, fileType);
                this.recentDocuments.Update(filePathName);
                this.richTextBox1.Modified = false;
                //RichTextBoxStreamType fileType1 = RichTextBoxStreamType.RichText;
                //String ext = Path.GetExtension(filePathName);
                //String filename = filePathName.Replace(ext, "");
                //filename = filename+"_" + txtVn.Text + ext;
                ic.savePicOPUtoServer(txtIdOld.Text, documentName, filePathName);
            }
            catch (Exception ex)
            {

            }
        }
        private void CreateNewDocument()
        {
            this.richTextBox1.Clear();
            this.documentName = "Document";
            this.documentPath = null;
            this.documentFileType = RichTextBoxStreamType.RichText;

            this.RaiseRichTextBoxSelectionChanged();
        }
        private void SetDocumentProperties(string filePathName, RichTextBoxStreamType fileType)
        {
            FileInfo fileInfo = new FileInfo(filePathName);
            this.documentName = fileInfo.Name;
            this.documentPath = fileInfo.DirectoryName;
            this.documentFileType = fileType;
        }
        private void RaiseRichTextBoxSelectionChanged()
        {
            // Force a SelectionChanged event to update the state of Ribbon items 
            // that depend on current text selection.
            this.richTextBox1.SelectAll();
            this.richTextBox1.Select(0, 0);

            this.richTextBox1.Modified = false;
        }
        private void setControlEggSti()
        {
            eggs = ic.ivfDB.eggsDB.selectByPk1(txtEggStiId.Text);
            if (eggs.egg_sti_id.Equals(""))
            {
                eggs = ic.ivfDB.eggsDB.selectByVsId(vsid);
                if (eggs.egg_sti_id.Equals(""))
                {
                    eggs = ic.ivfDB.eggsDB.selectByPttId(txtPttId.Text);
                    {
                        txtEggStiId.Value = eggs.egg_sti_id;
                    }
                }
                else
                {
                    txtEggStiId.Value = eggs.egg_sti_id;
                }
            }
            else
            {
                ic.setC1Combo(cboEggStiDtr, eggs.doctor_id);
                txtEggStiVisitLMP.Value = eggs.lmp_date;
            }
            txtEggStiVisitLMP.Value = eggs.lmp_date;
            txtEggStiDay.Value = eggs.day_start;
            txtEggStiOPUDate.Value = eggs.opu_date;
            txtEggStiOPUTime.Value = eggs.opu_time;
            txtEggStiEmbryoTranferDate.Value = eggs.fet;

            chkAbnormal.Checked = eggs.status_abnormal.Equals("1") ? true : false;
            chkTyping.Checked = eggs.status_typing.Equals("1") ? true : false;
            chkEggStiOther.Checked = eggs.status_typing_other.Equals("1") ? true : false;
            chkEggStiInfection.Checked = eggs.status_infectious.Equals("1") ? true : false;
            chkAmh.Checked = eggs.status_add_lab.Equals("1") ? true : false;
            txtAbnormal1.Value = eggs.abnormal1;
            txtAbnormal2.Value = eggs.abnormal2;
            ic.setC1ComboByName(cboEggStiOther, eggs.typing_other);
            ic.setC1ComboByName(cboEggStiBhcg, eggs.bhcg_test);
            ic.setC1ComboByName(cboEggStiAmh, eggs.add_lab);
            txtEggStiG.Value = eggs.g;
            txtEggStiP.Value = eggs.p;
            txtEggStiA.Value = eggs.a;
            ic.setC1Combo(cboEggStiDtr, eggs.doctor_id);

            setGrfEggStiDay();
        }
        private void setEggSti()
        {
            eggs.egg_sti_id = txtEggStiId.Text;
            eggs.lmp_date = ic.datetoDB(txtEggStiVisitLMP.Text);
            eggs.nurse_t_egg_sticol = "";
            eggs.status_g = "";
            eggs.p = txtEggStiP.Text;
            eggs.active = "";
            eggs.remark = "";
            eggs.a = txtEggStiA.Text;
            eggs.date_create = "";
            eggs.date_modi = "";
            eggs.date_cancel = "";
            eggs.user_create = "";
            eggs.user_modi = "";
            eggs.user_cancel = "";
            eggs.g = txtEggStiG.Text;
            eggs.opu_date = ic.datetoDB(txtEggStiOPUDate.Text);
            eggs.opu_time = txtEggStiOPUTime.Text;
            eggs.et = "";
            eggs.fet = "";
            eggs.bhcg_test = cboEggStiBhcg.Text;
            eggs.t_patient_id = txtPttId.Text;
            eggs.t_visit_id = txtVsId.Text;
            eggs.egg_sti_date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("MM-dd");
            eggs.doctor_id = cboEggStiDtr.SelectedItem == null ? "" : ((ComboBoxItem)cboEggStiDtr.SelectedItem).Value;
            eggs.status_abnormal = chkAbnormal.Checked ? "1" : "0";
            eggs.abnormal1 = txtAbnormal1.Text;
            eggs.abnormal2 = txtAbnormal2.Text;
            eggs.status_typing = chkTyping.Checked ? "1" : "0";
            eggs.status_typing_other = chkEggStiOther.Checked ? "1" : "0";
            eggs.typing_other = cboEggStiOther.Text;
            eggs.status_infectious = chkEggStiInfection.Checked ? "1" : "0";
            eggs.status_add_lab = chkAmh.Checked ? "1" : "0";
            eggs.add_lab = cboEggStiAmh.Text;
            eggs.day_start = txtEggStiDay.Text;
        }
        private void BtnEggStiSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtEggStiId.Text.Equals(""))
            {
                MessageBox.Show("ID ไม่ถูกต้อง ", "");
                return;
            }
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setEggSti();
                String re = ic.ivfDB.eggsDB.insertEggSti(eggs, ic.cStf.staff_id);

                for (int i = 1; i <= 17; i++)
                {
                    if (grfEggsd.Rows[i][colEggEdit] == null) continue;
                    if (grfEggsd.Rows[i][colEggEdit].ToString().Equals("1"))
                    {
                        EggStiDay eggsd = new EggStiDay();
                        eggsd.egg_sti_day_id = grfEggsd.Rows[i][colEggId].ToString();
                        eggsd.egg_sti_id = txtEggStiId.Text;
                        eggsd.day1 = i.ToString();
                        eggsd.date = "";
                        eggsd.e2 = grfEggsd.Rows[i][colEggE2].ToString();
                        eggsd.lh = grfEggsd.Rows[i][colEggLH].ToString();
                        eggsd.active = "";
                        eggsd.remark = "";
                        eggsd.fsh = grfEggsd.Rows[i][colEggFSH].ToString();
                        eggsd.date_create = "";
                        eggsd.date_modi = "";
                        eggsd.date_cancel = "";
                        eggsd.user_create = "";
                        eggsd.user_modi = "";
                        eggsd.user_cancel = "";
                        eggsd.prolactin = grfEggsd.Rows[i][colEggProlactin].ToString();
                        eggsd.rt_ovary_1 = grfEggsd.Rows[i][colEggRt1].ToString();
                        eggsd.rt_ovary_2 = grfEggsd.Rows[i][colEggRt2].ToString();
                        eggsd.lt_ovary_1 = grfEggsd.Rows[i][colEggLt1].ToString();
                        eggsd.lt_ovary_2 = grfEggsd.Rows[i][colEggLt2].ToString();
                        eggsd.endo = grfEggsd.Rows[i][colEggEndo].ToString();
                        eggsd.medication = grfEggsd.Rows[i][colEggMedi].ToString();
                        eggsd.medication2 = grfEggsd.Rows[i][colEggMedi2].ToString();
                        ic.ivfDB.eggsdDB.insertEggStiDay(eggsd, ic.cStf.staff_id);
                    }
                }
            }
        }
        private void BtnEggStiPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.eggsdDB.selectByEggStiId(txtEggStiId.Text);
            dt.Columns.Add("status_abnormal", typeof(String));
            dt.Columns.Add("abnormal1", typeof(String));
            dt.Columns.Add("abnormal2", typeof(String));
            dt.Columns.Add("status_typing", typeof(String));
            dt.Columns.Add("status_typing_other", typeof(String));
            dt.Columns.Add("typing_other", typeof(String));
            dt.Columns.Add("status_infectious", typeof(String));
            dt.Columns.Add("status_add_lab", typeof(String));
            dt.Columns.Add("add_lab", typeof(String));
            dt.Columns.Add("bhcg", typeof(String));
            String date1 = "";
            foreach (DataRow row in dt.Rows)
            {
                date1 = ic.datetoShow(row["date"].ToString());
                row["date"] = date1.Replace("-", "/");
                row["status_abnormal"] = chkAbnormal.Checked ? "1" : "0";
                row["abnormal1"] = txtAbnormal1.Text;
                row["abnormal2"] = txtAbnormal2.Text;
                row["status_typing"] = chkTyping.Checked ? "1" : "0";
                row["status_typing_other"] = chkEggStiOther.Checked ? "1" : "0"; ;
                row["typing_other"] = cboEggStiOther.Text;
                row["status_infectious"] = chkEggStiInfection.Checked ? "1" : "0";
                row["status_add_lab"] = chkAmh.Checked ? "1" : "0";
                row["add_lab"] = cboEggStiAmh.Text;
                row["bhcg"] = cboEggStiBhcg.Text;
                //row["status_abnormal"] = "";
                //row["status_abnormal"] = "";
            }

            frm.setEggStiReport(dt, txtPttNameE.Text, "", txtEggStiVisitLMP.Text, txtEggStiG.Text, txtEggStiP.Text, txtEggStiA.Text, cboEggStiDtr.Text, txtEggStiOPUDate.Text, txtEggStiOPUTime.Text, txtEggStiEmbryoTranferDate.Text, txtEggStiEmbryoTranferTime.Text);
            frm.ShowDialog(this);
        }
        private void BtnGenEggSti_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String lmpdate = "";
            DateTime lmpdate1 = new DateTime();
            lmpdate = ic.datetoDB(txtEggStiVisitLMP.Text);
            if (!DateTime.TryParse(lmpdate, out lmpdate1))
            {
                MessageBox.Show("วันที่ LMP Date ไม่ถูกต้อง ", "");
                return;
            }
            if (MessageBox.Show("ต้องการ Day Egg Sti  \nวันที่ LMP Date " + txtEggStiVisitLMP.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setEggSti();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    long chk = 0, chk1 = 0;
                    String re = ic.ivfDB.eggsDB.insertEggSti(eggs, ic.cStf.staff_id);
                    if (long.TryParse(re, out chk))
                    {
                        if (chk != 1)
                            txtEggStiId.Value = re;
                        ic.ivfDB.eggsdDB.VoidEggSti(txtEggStiId.Text, ic.cStf.staff_id);
                        lmpdate = ic.datetoDB(txtEggStiVisitLMP.Text);
                        if (DateTime.TryParse(lmpdate, out lmpdate1))
                        {
                            //if (txtEggStiDay.Text.Equals("1"))
                            //{

                            //}
                            //else
                            //{
                            long.TryParse(txtEggStiDay.Text, out chk1);
                            lmpdate1 = lmpdate1.AddDays(chk1);
                            //}
                            for (int i = 1; i <= 17; i++)
                            {
                                if (i != 1)
                                {
                                    lmpdate1 = lmpdate1.AddDays(1);
                                }
                                EggStiDay eggsd = new EggStiDay();
                                eggsd.egg_sti_day_id = "";
                                eggsd.egg_sti_id = txtEggStiId.Text;
                                eggsd.day1 = chk1.ToString();
                                eggsd.date = ic.datetoDB(lmpdate1.Year.ToString() + "-" + lmpdate1.ToString("MM-dd"));
                                eggsd.e2 = "";
                                eggsd.lh = "";
                                eggsd.active = "";
                                eggsd.remark = "";
                                eggsd.fsh = "";
                                eggsd.date_create = "";
                                eggsd.date_modi = "";
                                eggsd.date_cancel = "";
                                eggsd.user_create = "";
                                eggsd.user_modi = "";
                                eggsd.user_cancel = "";
                                eggsd.prolactin = "";
                                eggsd.rt_ovary_1 = "";
                                eggsd.rt_ovary_2 = "";
                                eggsd.lt_ovary_1 = "";
                                eggsd.lt_ovary_2 = "";
                                eggsd.endo = "";
                                eggsd.medication = "";
                                eggsd.medication2 = "";
                                chk1++;
                                ic.ivfDB.eggsdDB.insertEggStiDay(eggsd, ic.cStf.staff_id);
                            }
                        }
                        setControlEggSti();
                    }
                }
            }
        }
        private void initGrfEggSti()
        {
            grfEggsd = new C1FlexGrid();
            grfEggsd.Font = fEdit;
            grfEggsd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEggsd.Location = new System.Drawing.Point(0, 0);
            grfEggsd.ChangeEdit += GrfEggsd_ChangeEdit;

            //FilterRow fr = new FilterRow(grfExpn);

            pnEggSti.Controls.Add(grfEggsd);

            theme1.SetTheme(grfEggsd, "Office2010Blue");
        }
        private void GrfEggsd_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEggsd.Row == null) return;
            if (grfEggsd.Row < 0) return;
            grfEggsd[grfEggsd.Row, colEggEdit] = "1";
            grfEggsd.Rows[grfEggsd.Row].StyleNew.BackColor = color;
        }
        private void setGrfEggStiDay()
        {
            //grfDept.Rows.Count = 7;
            grfEggsd.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.eggsdDB.selectByEggStiId(txtEggStiId.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfEggsd.Rows.Count = 1;
            grfEggsd.Cols.Count = 16;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday3 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            C1ComboBox cbomedi = new C1ComboBox();
            C1ComboBox cbomedi2 = new C1ComboBox();
            cboday3.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbomedi.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbomedi.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbomedi2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbomedi2.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboEggStiRtOvary1(cboday3, "");
            ic.ivfDB.fdtDB.setCboEggStiRtOvary2(cboday3desc1, "");
            ic.ivfDB.fdtDB.setCboEggStiMedication(cbomedi, "");
            ic.ivfDB.fdtDB.setCboEggStiMedication2(cbomedi2, "");
            grfEggsd.Cols[colEggLt1].Editor = cboday3;
            grfEggsd.Cols[colEggLt2].Editor = cboday3desc1;
            grfEggsd.Cols[colEggRt1].Editor = cboday3;
            grfEggsd.Cols[colEggRt2].Editor = cboday3desc1;
            grfEggsd.Cols[colEggMedi].Editor = cbomedi;
            grfEggsd.Cols[colEggMedi2].Editor = cbomedi2;
            grfEggsd.Cols[colEggDay].Width = 40;
            grfEggsd.Cols[colEggDate].Width = 100;
            grfEggsd.Cols[colEggE2].Width = 50;
            grfEggsd.Cols[colEggLH].Width = 50;
            grfEggsd.Cols[colEggFSH].Width = 50;
            grfEggsd.Cols[colEggProlactin].Width = 50;
            grfEggsd.Cols[colEggRt1].Width = 160;
            grfEggsd.Cols[colEggRt2].Width = 160;
            grfEggsd.Cols[colEggLt1].Width = 160;
            grfEggsd.Cols[colEggLt2].Width = 160;
            grfEggsd.Cols[colEggEndo].Width = 50;
            grfEggsd.Cols[colEggMedi].Width = 160;
            grfEggsd.Cols[colEggMedi2].Width = 160;

            grfEggsd.Cols[colEggE2].AllowSorting = false;
            grfEggsd.Cols[colEggLH].AllowSorting = false;
            grfEggsd.Cols[colEggFSH].AllowSorting = false;

            grfEggsd.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfEggsd.Cols[colEggDay].Caption = "day";
            grfEggsd.Cols[colEggDate].Caption = "date";
            grfEggsd.Cols[colEggE2].Caption = "E2";
            grfEggsd.Cols[colEggLH].Caption = "LH";
            grfEggsd.Cols[colEggFSH].Caption = "FSH";
            grfEggsd.Cols[colEggProlactin].Caption = "Prolactin";
            grfEggsd.Cols[colEggRt1].Caption = "Rt ovary";
            grfEggsd.Cols[colEggRt2].Caption = "Rt ovary";
            grfEggsd.Cols[colEggLt1].Caption = "Lt ovary";
            grfEggsd.Cols[colEggLt2].Caption = "Lt ovary";
            grfEggsd.Cols[colEggEndo].Caption = "Endo";
            grfEggsd.Cols[colEggMedi].Caption = "Medication";
            grfEggsd.Cols[colEggMedi2].Caption = "Medication2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday2 = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfEggsd.Rows.Add();
                //staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                //checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                row1[colEggId] = row[ic.ivfDB.eggsdDB.eggsd.egg_sti_day_id].ToString();
                row1[colEggDay] = row[ic.ivfDB.eggsdDB.eggsd.day1].ToString();
                row1[colEggDate] = ic.datetoShow(row[ic.ivfDB.eggsdDB.eggsd.date].ToString());
                row1[colEggE2] = row[ic.ivfDB.eggsdDB.eggsd.e2].ToString();
                row1[colEggLH] = row[ic.ivfDB.eggsdDB.eggsd.lh].ToString();
                row1[colEggFSH] = row[ic.ivfDB.eggsdDB.eggsd.fsh].ToString();
                row1[colEggProlactin] = row[ic.ivfDB.eggsdDB.eggsd.prolactin].ToString();
                row1[colEggRt1] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_1].ToString();
                row1[colEggRt2] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_2].ToString();
                row1[colEggLt1] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_1].ToString();
                row1[colEggLt2] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_2].ToString();
                row1[colEggEndo] = row[ic.ivfDB.eggsdDB.eggsd.endo].ToString();
                row1[colEggMedi] = row[ic.ivfDB.eggsdDB.eggsd.medication].ToString();
                row1[colEggMedi2] = row[ic.ivfDB.eggsdDB.eggsd.medication2].ToString();
                row1[colEggEdit] = "";
                row1[0] = i;
                i++;
            }
            grfEggsd.Rows.Add();
            grfEggsd.Cols[colEggId].Visible = false;
            grfEggsd.Cols[colEggEdit].Visible = false;
            grfEggsd.Cols[colEggDay].AllowEditing = false;
            grfEggsd.Cols[colEggDate].AllowEditing = false;
            grfEggsd.Cols[colEggDay].AllowSorting = false;
            grfEggsd.Cols[colEggDate].AllowSorting = false;
            grfEggsd.Cols[colEggE2].AllowSorting = false;
            grfEggsd.Cols[colEggLH].AllowSorting = false;
            grfEggsd.Cols[colEggFSH].AllowSorting = false;
            grfEggsd.Cols[colEggProlactin].AllowSorting = false;
            grfEggsd.Cols[colEggRt1].AllowSorting = false;
            grfEggsd.Cols[colEggRt2].AllowSorting = false;
            grfEggsd.Cols[colEggLt1].AllowSorting = false;
            grfEggsd.Cols[colEggLt2].AllowSorting = false;
            grfEggsd.Cols[colEggEndo].AllowSorting = false;
            grfEggsd.Cols[colEggMedi].AllowSorting = false;
            grfEggsd.Cols[colEggMedi2].AllowSorting = false;
            //grfEggsd.Cols[colProlactin].Visible = false;
            grfEggsd.AutoClipboard = true;
        }
        private void BtnNoteAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                Note1 note = new Note1();
                note.active = "1";
                note.date_cancel = "";
                note.date_create = "";
                note.date_modi = "";
                note.note_1 = txtNote.Text;
                note.note_2 = "";
                note.note_id = txtNoteId.Text;
                note.remark = "";
                note.t_patient_id = ptt.t_patient_id;
                note.user_cancel = "";
                note.user_create = "";
                note.user_modi = "";
                note.status_all = chkNoteAll.Checked ? "1" : "0";
                note.b_service_point_id = "2120000000";
                ic.ivfDB.noteDB.insertNote(note, ic.cStf.staff_id);
                setGrfNote();
                txtNote.Value = "";
            }
        }

        private void CboLangSticker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cboLangSticker.Text.Equals("English"))
            {
                grfRx.Cols[colRxUsT].Visible = false;
                grfRx.Cols[colRxUsE].Visible = true;

                grfRxSetD.Cols[colRxUsT].Visible = false;
                grfRxSetD.Cols[colRxUsE].Visible = true;
            }
            else
            {
                grfRx.Cols[colRxUsT].Visible = true;
                grfRx.Cols[colRxUsE].Visible = false;
                grfRxSetD.Cols[colRxUsT].Visible = true;
                grfRxSetD.Cols[colRxUsE].Visible = false;
            }
        }
        private void UpdateTotals()
        {
            // clear existing totals
            //grfOrder.Subtotal(AggregateEnum.Clear);
            //grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colOrdAmt, "Total");
        }
        private void initGrfRxSetD()
        {
            grfRxSetD = new C1FlexGrid();
            grfRxSetD.Font = fEdit;
            grfRxSetD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSetD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfRxSetD.AfterRowColChange += GrfRxSetD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSetD.ContextMenu = menuGw;
            pnRxSetD.Controls.Add(grfRxSetD);

            theme1.SetTheme(grfRxSetD, "Office2016DarkGray");

        }

        private void GrfRxSetD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfRxSetD(String id)
        {
            //grfDept.Rows.Count = 7;
            grfRxSetD.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGudDB.selectByGdId1(id);

            grfRxSetD.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRxSetD.DataSource = dt;
            grfRxSetD.Cols.Count = 11;
            CellStyle cs = grfRxSetD.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRxSetD.Cols[colRxName].Width = 300;
            grfRxSetD.Cols[colRxInclude].Width = 60;
            grfRxSetD.Cols[colRxPrice].Width = 80;
            grfRxSetD.Cols[colRxRemark].Width = 100;
            grfRxSetD.Cols[colRxUsE].Width = 200;
            grfRxSetD.Cols[colRxUsT].Width = 200;
            grfRxSetD.Cols[colRxQty].Width = 60;

            grfRxSetD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSetD.Cols[colRxName].Caption = "Name";
            grfRxSetD.Cols[colRxInclude].Caption = "Include";
            grfRxSetD.Cols[colRxPrice].Caption = "Price";
            grfRxSetD.Cols[colRxQty].Caption = "QTY";
            grfRxSetD.Cols[colRxRemark].Caption = "Remark";

            CellRange rg = grfRxSetD.GetCellRange(1, colRxInclude, grfRxSetD.Rows.Count - 1, colRxInclude);
            rg.Style = cs;
            rg.Style = grfRxSetD.Styles["bool"];
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;

                    Decimal.TryParse(row["Price"].ToString(), out aaa);
                    grfRxSetD[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRxSetD[i, colRxdId] = row[ic.ivfDB.oGudDB.oGuD.DUID].ToString();
                    grfRxSetD[i, colRxName] = row[ic.ivfDB.oGudDB.oGuD.DUName].ToString();
                    grfRxSetD[i, colRxQty] = row[ic.ivfDB.oGudDB.oGuD.QTY].ToString();
                    grfRxSetD[i, colRxUsE] = row["EUsage"].ToString();
                    grfRxSetD[i, colRxUsT] = row["TUsage"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRxSetD);
            grfRxSetD.Cols[colRxdId].Visible = false;
            grfRxSetD.Cols[colRxId].Visible = false;
            grfRxSetD.Cols[colRxItmId].Visible = false;
            grfRxSetD.Cols[colBlRemark].Visible = false;

            grfRxSetD.Cols[colRxName].AllowEditing = false;
            grfRxSetD.Cols[colRxQty].AllowEditing = false;
            //grfRxSetD.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

            if (dt.Rows.Count > 0)
                btnPkgOrder.Enabled = true;
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfOrder.AfterDataRefresh += GrfOrder_AfterDataRefresh;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            //grfOrder.mou
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_or_void));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "GreenHouse");

        }

        private void GrfOrder_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }

        private void ContextMenu_or_void(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            String id = "", status = "";
            rowOrder--;
            id = grfOrder[grfOrder.Row, colOrdid].ToString();
            status = grfOrder[grfOrder.Row, colOrdstatus].ToString();
            if (status.Equals("bloodlab") || status.Equals("Sperm Lab") || status.Equals("Embryo Lab") || status.Equals("Genetic Lab"))
            {
                ic.ivfDB.oJlabdDB.deleteByPk(id);
            }
            else if (status.Equals("specialitem"))
            {
                ic.ivfDB.ojsdDB.deleteByPk(id);
            }
            else if (status.Equals("px"))
            {
                ic.ivfDB.oJpxdDB.deleteByPk(id);
            }
            else if (status.Equals("package"))
            {
                ic.ivfDB.opkgsDB.deleteByPk(id);
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void initGrfRxSet()
        {
            grfRxSet = new C1FlexGrid();
            grfRxSet.Font = fEdit;
            grfRxSet.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSet.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfRxSet);

            grfRxSet.AfterRowColChange += GrfRxSet_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSet.ContextMenu = menuGw;
            pnRxSet.Controls.Add(grfRxSet);

            theme1.SetTheme(grfRxSet, "Office2016DarkGray");

        }
        private void setRxSet()
        {
            if (grfRxSetD.Rows.Count > 0)
            {
                if (grfRxSetD.Row <= 0) return;
                foreach (Row row in grfRxSetD.Rows)
                {
                    if (row[colRxdId] == null) continue;
                    String duid = "", include = "", qty = "", usaget = "", usagee = "", duname = "", price = "", usage = "";
                    duid = row[colRxdId].ToString();
                    usaget = row[colRxUsT].ToString();
                    usagee = row[colRxUsE].ToString();
                    duname = row[colRxName].ToString();
                    price = row[colRxPrice].ToString();
                    include = row[colRxInclude] != null ? row[colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
                    qty = row[colBlQty] != null ? row[colBlQty].ToString() : "1";
                    if (cboLangSticker.Text.Equals("English"))
                    {
                        usage = row[colRxUsE] != null ? row[colRxUsE].ToString() : "";
                    }
                    else
                    {
                        usage = row[colRxUsT] != null ? row[colRxUsT].ToString() : "";
                    }
                    usaget = usage;
                    if (include.Equals("1"))
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                    else
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                }

                setGrfOrder(txtVnOld.Text);
            }
        }
        private void ContextMenu_order_rx_set(object sender, System.EventArgs e)
        {
            setRxSet();
        }
        private void GrfRxSet_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRxSet.Row < 0) return;
            if (grfRxSet[grfRxSet.Row, colBlId] == null) return;
            //btnPkgOrder.Enabled = false;
            String id = grfRxSet[grfRxSet.Row, colBlId].ToString();
            setGrfRxSetD(id);

        }

        private void setGrfRxSet()
        {
            //grfDept.Rows.Count = 7;
            grfRxSet.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGrpDb.selectByGrpDrugH1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfRxSet.DataSource = dt;
            grfRxSet.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1CheckBox chk = new C1CheckBox();
            chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfRxSet.Cols[colBlName].Editor = txt;
            grfRxSet.Cols[colBlInclude].Editor = txt;
            grfRxSet.Cols[colBlPrice].Editor = txt;
            grfRxSet.Cols[colBlRemark].Editor = txt;

            grfRxSet.Cols[colBlName].Width = 320;
            grfRxSet.Cols[colBlInclude].Width = 120;
            grfRxSet.Cols[colBlPrice].Width = 80;
            grfRxSet.Cols[colBlRemark].Width = 100;

            grfRxSet.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSet.Cols[colBlName].Caption = "Name";
            grfRxSet.Cols[colBlInclude].Caption = "Include";
            grfRxSet.Cols[colBlPrice].Caption = "Price";
            grfRxSet.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfRxSet.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    //if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRxSet);
            grfRxSet.Cols[colBlId].Visible = false;
            grfRxSet.Cols[colBlInclude].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;

            grfRxSet.Cols[colBlName].AllowEditing = false;
            grfRxSet.Cols[colBlPrice].AllowEditing = false;
            grfRxSet.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfRx()
        {
            grfRx = new C1FlexGrid();
            grfRx.Font = fEdit;
            grfRx.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRx.Location = new System.Drawing.Point(0, 0);

            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);

            grfRx.DoubleClick += GrfRx_DoubleClick;
            //grfRx.AfterFilter += GrfRx_AfterFilter;

            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRx.ContextMenu = menuGw;
            pnRx.Controls.Add(grfRx);

            theme1.SetTheme(grfRx, "Office2010Black");

        }
        private void GrfRx_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRx.Col == colBlQty) return;
            setOrderRx();
        }
        private void setOrderRx()
        {
            if (grfRx.Row <= 0) return;
            if (grfRx[grfRx.Row, colBlId] == null) return;
            String chk = "", name = "", drugid = "", qty = "", include = "", usage = "";
            drugid = grfRx[grfRx.Row, colRxdId] != null ? grfRx[grfRx.Row, colRxdId].ToString() : "";
            qty = grfRx[grfRx.Row, colRxQty] != null ? grfRx[grfRx.Row, colRxQty].ToString() : "";
            include = grfRx[grfRx.Row, colRxInclude] != null ? grfRx[grfRx.Row, colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
            if (cboLangSticker.Text.Equals("English"))
            {
                usage = grfRx[grfRx.Row, colRxUsE] != null ? grfRx[grfRx.Row, colRxUsE].ToString() : "";
            }
            else
            {
                usage = grfRx[grfRx.Row, colRxUsT] != null ? grfRx[grfRx.Row, colRxUsT].ToString() : "";
            }
            //sep.Clear();
            if (include.Equals("1"))
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage);
            }
            else
            {
                ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage);
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            setOrderRx();
        }
        private void setGrfRx()
        {
            //grfDept.Rows.Count = 7;
            //grfRx.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectBySockDrug1();

            grfRx.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRx.DataSource = dt;
            grfRx.Cols.Count = 9;
            CellStyle cs = grfRx.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRx.Cols[colRxName].Width = 300;
            grfRx.Cols[colRxInclude].Width = 60;
            grfRx.Cols[colRxPrice].Width = 80;
            grfRx.Cols[colRxRemark].Width = 100;
            grfRx.Cols[colRxUsE].Width = 200;
            grfRx.Cols[colRxUsT].Width = 200;
            grfRx.Cols[colRxQty].Width = 60;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";



            CellRange rg = grfRx.GetCellRange(2, colBlInclude, grfRx.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfRx.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfRx.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfRx.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfRx.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfRx.Cols[colRxName].Caption = "Name";
            grfRx.Cols[colRxInclude].Caption = "Include";
            grfRx.Cols[colRxPrice].Caption = "Price";
            grfRx.Cols[colRxQty].Caption = "QTY";
            grfRx.Cols[colRxRemark].Caption = "Remark";
            grfRx.Cols[colRxUsE].Caption = "Usage English";
            grfRx.Cols[colRxUsT].Caption = "Usage Thai";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    grfRx[i, colBlId] = row["DUID"].ToString();
                    grfRx[i, colRxName] = row["DUName"].ToString();
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfRx[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRx[i, colRxQty] = "1";
                    grfRx[i, colBlRemark] = "";
                    grfRx[i, colRxUsE] = row["EUsage"].ToString();
                    grfRx[i, colRxUsT] = row["TUsage"].ToString();
                    //Row row1 = grfRx.Rows.Add();
                    //row1[colBlId] = row["DUID"].ToString();
                    //row1[colBlName] = row["DUName"].ToString();
                    //row1[colBlPrice] = row["Price"].ToString();
                    //row1[colBlRemark] = "";
                    //if (i == 1) continue;
                    //if (i == 2) continue;
                    grfRx[i, 0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
            grfRx.Cols[colBlId].Visible = false;
            grfRx.Cols[colBlRemark].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;
            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);
            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = true;
            //grfRx.AllowFiltering = true;

            FilterRow fr = new FilterRow(grfRx);
            grfRx.AllowFiltering = true;
            grfRx.AfterFilter += GrfRx_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfRx_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfRx.Cols.Fixed; col < grfRx.Cols.Count; ++col)
            {
                var filter = grfRx.Cols[col].ActiveFilter;
            }
        }
        private void initGrfSpecialLab()
        {
            grfSpecial = new C1FlexGrid();
            grfSpecial.Font = fEdit;
            grfSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpecial.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfSpecial);

            grfSpecial.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_se_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSpecial.ContextMenu = menuGw;
            pnSpecial.Controls.Add(grfSpecial);

            theme1.SetTheme(grfSpecial, "Office2010Barbie");
            grfSpecial.AfterFilter += GrfSpecial_AfterFilter;
            grfSpecial.DoubleClick += GrfSpecial_DoubleClick;
        }

        private void ContextMenu_order_se_set(object sender, System.EventArgs e)
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString());
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSpecial()
        {
            //grfDept.Rows.Count = 7;
            grfSpecial.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem2();

            grfSpecial.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfSpecial.DataSource = dt;
            grfSpecial.Cols.Count = 7;
            CellStyle cs = grfSpecial.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSpecial.Cols[colBlName].Width = 320;
            grfSpecial.Cols[colBlQty].Width = 60;
            grfSpecial.Cols[colBlInclude].Width = 80;
            grfSpecial.Cols[colBlPrice].Width = 80;
            grfSpecial.Cols[colBlRemark].Width = 200;

            grfSpecial.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            CellRange rg = grfSpecial.GetCellRange(2, colBlInclude, grfSpecial.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSpecial.Styles["bool"];

            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfSpecial.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfSpecial.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfSpecial.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfSpecial.Cols[colBlName].Caption = "Name";
            grfSpecial.Cols[colBlInclude].Caption = "Include";
            grfSpecial.Cols[colBlPrice].Caption = "Price";
            grfSpecial.Cols[colBlRemark].Caption = "Remark";
            grfSpecial.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oSItmDB.sitm.Price].ToString(), out aaa);
                    grfSpecial[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSpecial[i, colBlId] = row[ic.ivfDB.oSItmDB.sitm.SID].ToString();
                    grfSpecial[i, colBlName] = row[ic.ivfDB.oSItmDB.sitm.SName].ToString();
                    grfSpecial[i, colBlQty] = "1";
                    grfSpecial[i, colBlRemark] = row["bilgrpname"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            //grfSpecial.Rows.Count = dt.Rows.Count + 2;
            //grfSpecial.Cols.Count = dt.Columns.Count + 1+2;
            //for (int row = 0; row < dt.Rows.Count; ++row)
            //{
            //    for (int col = 0; col < dt.Columns.Count; ++col)
            //    {
            //        grfSpecial[row + 2, col + 1] = dt.Rows[row][col];
            //    }
            //}
            CellNoteManager mgr = new CellNoteManager(grfSpecial);
            grfSpecial.Cols[colBlId].Visible = false;
            //grfSpecial.Cols[colBlInclude].Visible = false;
            //grfSpecial.Cols[colBlPrice].Visible = false;

            grfSpecial.Cols[colBlName].AllowEditing = false;
            grfSpecial.Cols[colBlPrice].AllowEditing = false;
            grfSpecial.Cols[colBlRemark].AllowEditing = false;

            FilterRow fr = new FilterRow(grfSpecial);
            grfSpecial.AllowFiltering = true;

            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfSpecial_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfSpecial.Cols.Fixed; col < grfSpecial.Cols.Count; ++col)
            {
                var filter = grfSpecial.Cols[col].ActiveFilter;
            }
        }
        private void GrfSpecial_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSpecial.Col == colBlQty) return;
            setOrderSpecial();
        }
        private void setOrderSpecial()
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString());
            }
            else
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString());
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void initGrfGeneticLab()
        {
            grfGenetic = new C1FlexGrid();
            grfGenetic.Font = fEdit;
            grfGenetic.Dock = System.Windows.Forms.DockStyle.Fill;
            grfGenetic.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfGenetic);

            grfGenetic.DoubleClick += GrfGenetic_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_ge_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfGenetic.ContextMenu = menuGw;
            pnGenetic.Controls.Add(grfGenetic);

            theme1.SetTheme(grfGenetic, "RainerOrange");

        }

        private void GrfGenetic_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfGenetic.Col == colBlQty) return;
            setOrderGenetic();
        }
        private void setOrderGenetic()
        {
            if (grfGenetic.Row <= 0) return;
            if (grfGenetic[grfGenetic.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfGenetic[grfGenetic.Row, colBlId].ToString();
            include = grfGenetic[grfGenetic.Row, colBlInclude] != null ? grfGenetic[grfGenetic.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfGenetic[grfGenetic.Row, colBlQty] != null ? grfGenetic[grfGenetic.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_ge_set(object sender, System.EventArgs e)
        {
            setOrderGenetic();
        }
        private void setGrfGenetic()
        {
            //grfDept.Rows.Count = 7;
            grfGenetic.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByGeneticLab1();

            grfGenetic.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfGenetic.DataSource = dt;
            grfGenetic.Cols.Count = 7;
            CellStyle cs = grfGenetic.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfGenetic.Cols[colBlName].Width = 320;
            grfGenetic.Cols[colBlInclude].Width = 120;
            grfGenetic.Cols[colBlPrice].Width = 80;
            grfGenetic.Cols[colBlRemark].Width = 100;

            grfGenetic.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";



            CellRange rg = grfGenetic.GetCellRange(2, colBlInclude, grfGenetic.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfGenetic.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfGenetic.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfGenetic.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfGenetic.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfGenetic.Cols[colBlName].Caption = "Name";
            grfGenetic.Cols[colBlInclude].Caption = "Include";
            grfGenetic.Cols[colBlPrice].Caption = "Price";
            grfGenetic.Cols[colBlRemark].Caption = "Remark";
            grfGenetic.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfGenetic[i, colBlPrice] = aaa.ToString("#,##0");
                    grfGenetic[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfGenetic[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfGenetic[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfGenetic);
            grfGenetic.Cols[colBlId].Visible = false;
            //grfGenetic.Cols[colBlInclude].Visible = false;
            //grfGenetic.Cols[colBlPrice].Visible = false;

            grfGenetic.Cols[colBlName].AllowEditing = false;
            grfGenetic.Cols[colBlPrice].AllowEditing = false;
            grfGenetic.Cols[colBlRemark].AllowEditing = false;

            FilterRow fr = new FilterRow(grfGenetic);
            grfGenetic.AllowFiltering = true;
            grfGenetic.AfterFilter += GrfGenetic_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfGenetic_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfGenetic.Cols.Fixed; col < grfGenetic.Cols.Count; ++col)
            {
                var filter = grfGenetic.Cols[col].ActiveFilter;
            }
        }
        private void initGrfEmbryoLab()
        {
            grfEmbryo = new C1FlexGrid();
            grfEmbryo.Font = fEdit;
            grfEmbryo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEmbryo.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfEmbryo);

            grfEmbryo.DoubleClick += GrfEmbryo_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_em_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfEmbryo.ContextMenu = menuGw;
            pnEmbryo.Controls.Add(grfEmbryo);

            theme1.SetTheme(grfEmbryo, "ShinyBlue");

        }
        private void setOrderEmbryo()
        {
            if (grfEmbryo.Row <= 0) return;
            if (grfEmbryo[grfEmbryo.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfEmbryo[grfEmbryo.Row, colBlId].ToString();
            include = grfEmbryo[grfEmbryo.Row, colBlInclude] != null ? grfEmbryo[grfEmbryo.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfEmbryo[grfEmbryo.Row, colBlQty] != null ? grfEmbryo[grfEmbryo.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void GrfEmbryo_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEmbryo.Col == colBlQty) return;
            setOrderEmbryo();
        }

        private void ContextMenu_order_em_set(object sender, System.EventArgs e)
        {
            setOrderEmbryo();
        }
        private void setGrfEmbryo()
        {
            //grfDept.Rows.Count = 7;
            grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByEmbryoLab1();

            grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.DataSource = dt;
            grfEmbryo.Cols.Count = 7;
            CellStyle cs = grfEmbryo.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEmbryo.Cols[colBlName].Width = 320;
            grfEmbryo.Cols[colBlInclude].Width = 120;
            grfEmbryo.Cols[colBlPrice].Width = 80;
            grfEmbryo.Cols[colBlRemark].Width = 100;

            grfEmbryo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";



            CellRange rg = grfEmbryo.GetCellRange(2, colBlInclude, grfEmbryo.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfEmbryo.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfEmbryo.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfEmbryo.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfEmbryo.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfEmbryo.Cols[colBlName].Caption = "Name";
            grfEmbryo.Cols[colBlInclude].Caption = "Include";
            grfEmbryo.Cols[colBlPrice].Caption = "Price";
            grfEmbryo.Cols[colBlRemark].Caption = "Remark";
            grfEmbryo.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfEmbryo[i, colBlPrice] = aaa.ToString("#,##0");
                    grfEmbryo[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfEmbryo[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfEmbryo[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfEmbryo);
            grfEmbryo.Cols[colBlId].Visible = false;
            //grfEmbryo.Cols[colBlInclude].Visible = false;
            //grfEmbryo.Cols[colBlPrice].Visible = false;

            grfEmbryo.Cols[colBlName].AllowEditing = false;
            grfEmbryo.Cols[colBlPrice].AllowEditing = false;
            grfEmbryo.Cols[colBlRemark].AllowEditing = false;

            FilterRow fr = new FilterRow(grfEmbryo);
            grfEmbryo.AllowFiltering = true;
            grfEmbryo.AfterFilter += GrfEmbryo_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfEmbryo_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfEmbryo.Cols.Fixed; col < grfEmbryo.Cols.Count; ++col)
            {
                var filter = grfEmbryo.Cols[col].ActiveFilter;
            }
        }
        private void initGrfSpermLab()
        {
            grfSperm = new C1FlexGrid();
            grfSperm.Font = fEdit;
            grfSperm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSperm.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfSperm);

            grfSperm.AfterRowColChange += GrfMed_AfterRowColChange;
            grfSperm.DoubleClick += GrfSperm_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_sp_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSperm.ContextMenu = menuGw;
            pnSperm.Controls.Add(grfSperm);

            theme1.SetTheme(grfSperm, "Office2010Green");

        }

        private void GrfSperm_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSperm.Col == colBlQty) return;
            setOrderSperm();
        }

        private void setOrderSperm()
        {
            if (grfSperm.Row <= 0) return;
            if (grfSperm[grfSperm.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfSperm[grfSperm.Row, colBlId].ToString();
            include = grfSperm[grfSperm.Row, colBlInclude] != null ? grfSperm[grfSperm.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSperm[grfSperm.Row, colBlQty] != null ? grfSperm[grfSperm.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_sp_set(object sender, System.EventArgs e)
        {
            setOrderSperm();
        }
        private void setGrfSperm()
        {
            //grfDept.Rows.Count = 7;
            grfSperm.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectBySpermLab1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSperm.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfSperm.Cols.Count = 7;
            CellStyle cs = grfSperm.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSperm.Cols[colBlName].Width = 320;
            grfSperm.Cols[colBlInclude].Width = 120;
            grfSperm.Cols[colBlPrice].Width = 80;
            grfSperm.Cols[colBlRemark].Width = 100;

            grfSperm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSperm.Cols[colBlName].Caption = "Name";
            grfSperm.Cols[colBlInclude].Caption = "Include";
            grfSperm.Cols[colBlQty].Caption = "QTY";
            grfSperm.Cols[colBlPrice].Caption = "Price";
            grfSperm.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfSperm.GetCellRange(1, colBlInclude, grfSperm.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSperm.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfSperm[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSperm[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfSperm[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfSperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSperm);
            grfSperm.Cols[colBlId].Visible = false;
            //grfSperm.Cols[colBlInclude].Visible = false;
            //grfSperm.Cols[colBlPrice].Visible = false;

            grfSperm.Cols[colBlName].AllowEditing = false;
            grfSperm.Cols[colBlPrice].AllowEditing = false;
            grfSperm.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();

            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID(pttId);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            dtAll.Columns.Add("usage", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = row["TUsage"];
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }
            foreach (DataRow row in dtpkg.Rows)
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
                    DataRow row1 = dtAll.NewRow();
                    row1["id"] = row["PCKSID"];
                    row1["itmid"] = row["PCKID"];
                    row1["lgid"] = "";
                    row1["name"] = name;
                    row1["price"] = pay;
                    row1["qty"] = "1";
                    row1["status"] = "package";
                    row1["row1"] = row["row1"];
                    row1["extra"] = "0";
                    row1["usage"] = "";
                    dtAll.Rows.InsertAt(row1, i);
                    i++;
                }
            }
            dtAll.DefaultView.Sort = "row1";
            DataView view = dtAll.DefaultView;
            view.Sort = "row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 13;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;

            grfOrder.Cols[colOrdName].Width = 280;
            grfOrder.Cols[colOrdPrice].Width = 120;
            grfOrder.Cols[colOrdQty].Width = 80;
            grfOrder.Cols[colOrdUsT].Width = 100;

            grfOrder.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOrder.Cols[colOrdName].Caption = "Name";
            grfOrder.Cols[colOrdPrice].Caption = "Price";
            grfOrder.Cols[colOrdQty].Caption = "QTY";
            grfOrder.Cols[colOrdInclude].Caption = "Include Package";
            grfOrder.Cols[colOrdUsT].Caption = "Usage";
            grfOrder.Cols[colOrdAmt].Caption = "Amount";
            //grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfOrder.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0;
                    Row row1 = grfOrder.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    row1[colOrdUsT] = row["usage"].ToString();
                    //row1[colOrdQty] = row["qty"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";

                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["extra"].ToString().Equals("1"))
                    {
                        ext += (price * qty);
                    }
                    else
                    {
                        if (row["status"].ToString().Equals("package"))
                        {
                            inc += (price * qty);
                        }
                    }
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            rowOrder = grfOrder.Rows.Count;
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colOrdrow1].Visible = false;
            grfOrder.Cols[colOrdlpid].Visible = false;
            grfOrder.Cols[colOrdid].Visible = false;
            //grfOrder.Cols[colOrdstatus].Visible = false;
            grfOrder.Cols[colOrditmid].Visible = false;

            grfOrder.Cols[colOrdUsE].Visible = false;
            //grfOrder.Cols[colOrderPID].Visible = false;
            //grfOrder.Cols[colOrderPIDS].Visible = false;
            //grfOrder.Cols[colOrderSP1V].Visible = false;
            //grfOrder.Cols[colOrderSP2V].Visible = false;
            //grfOrder.Cols[colOrderSP3V].Visible = false;
            //grfOrder.Cols[colOrderSP4V].Visible = false;
            //grfOrder.Cols[colOrderSP5V].Visible = false;
            //grfOrder.Cols[colOrderSP6V].Visible = false;
            //grfOrder.Cols[colOrderSP7V].Visible = false;
            //grfOrder.Cols[colOrderSubItem].Visible = false;
            //grfOrder.Cols[colOrderFileName].Visible = false;
            //grfOrder.Cols[colOrderWorder1].Visible = false;
            //grfOrder.Cols[colOrderWorker2].Visible = false;
            //grfOrder.Cols[colOrderWorker3].Visible = false;
            //grfOrder.Cols[colOrderWorkder4].Visible = false;
            //grfOrder.Cols[colOrderWorker5].Visible = false;
            //grfOrder.Cols[colOrderLGID].Visible = false;
            //grfOrder.Cols[colOrderActive].Visible = false;
            //grfOrder.Cols[colOrderLID].Visible = false;
            grfOrder.Cols[colOrdUsT].AllowEditing = false;
            grfOrder.Cols[colOrdName].AllowEditing = false;
            grfOrder.Cols[colOrdPrice].AllowEditing = false;
            grfOrder.Cols[colOrdQty].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            //UpdateTotals();
            String total = "";
            Decimal total1 = 0;
            //total = grfOrder[grfOrder.Rows.Count - 1, colOrdAmt] != null ? grfOrder[grfOrder.Rows.Count - 1, colOrdAmt].ToString() : "";
            total1 = inc + ext;
            //Decimal.TryParse(total, out total1);
            txtTotal.Value = total1.ToString("#,###.00");
            txtInclude.Value = inc.ToString("#,###.00");
            txtExtra.Value = ext.ToString("#,###.00");
        }
        private void initGrfBloodLab()
        {
            grfBloodLab = new C1FlexGrid();
            grfBloodLab.Font = fEdit;
            grfBloodLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBloodLab.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfBloodLab);

            grfBloodLab.DoubleClick += GrfBloodLab_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            }

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBloodLab.ContextMenu = menuGw;
            pnBloodLab.Controls.Add(grfBloodLab);

            theme1.SetTheme(grfBloodLab, "Office2010Red");

        }
        private void ContextMenu_order_bl_set(object sender, System.EventArgs e)
        {
            setOrderBloodLab();
        }
        private void GrfBloodLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfBloodLab.Col == colBlQty) return;
            setOrderBloodLab();
        }
        private void setOrderBloodLab()
        {
            if (grfBloodLab.Row <= 0) return;
            if (grfBloodLab[grfBloodLab.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "";
            rowOrder++;
            labid = grfBloodLab[grfBloodLab.Row, colBlId].ToString();
            include = grfBloodLab[grfBloodLab.Row, colBlInclude] != null ? grfBloodLab[grfBloodLab.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfBloodLab[grfBloodLab.Row, colBlQty] != null ? grfBloodLab[grfBloodLab.Row, colBlQty].ToString() : "1";
            if (include.Equals("1"))
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            else
            {
                ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0");
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfBloodLab()
        {
            //grfDept.Rows.Count = 7;
            grfBloodLab.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByBloodLab1();
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grfBloodLab.Cols.Count = 7;

            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfBloodLab.Cols[colBlName].Width = 330;
            grfBloodLab.Cols[colBlInclude].Width = 120;
            grfBloodLab.Cols[colBlPrice].Width = 80;
            grfBloodLab.Cols[colBlRemark].Width = 100;

            grfBloodLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            CellRange rg = grfBloodLab.GetCellRange(2, colBlInclude, grfBloodLab.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfBloodLab.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfBloodLab.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfBloodLab.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfBloodLab.Cols[colBlName].Caption = "Name";
            grfBloodLab.Cols[colBlInclude].Caption = "Include";
            grfBloodLab.Cols[colBlPrice].Caption = "Price";
            grfBloodLab.Cols[colBlQty].Caption = "QTY";
            grfBloodLab.Cols[colBlRemark].Caption = "Remark";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfBloodLab[i, colBlPrice] = aaa.ToString("#,##0");
                    grfBloodLab[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfBloodLab[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfBloodLab[i, colBlQty] = "1";

                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfBloodLab);
            grfBloodLab.Cols[colBlId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grfBloodLab.Cols[colBlName].AllowEditing = false;
            grfBloodLab.Cols[colBlPrice].AllowEditing = false;
            grfBloodLab.Cols[colBlRemark].AllowEditing = false;

            FilterRow fr = new FilterRow(grfBloodLab);
            grfBloodLab.AllowFiltering = true;
            grfBloodLab.AfterFilter += GrfBloodLab_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfBloodLab_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfBloodLab.Cols.Fixed; col < grfBloodLab.Cols.Count; ++col)
            {
                var filter = grfBloodLab.Cols[col].ActiveFilter;
            }
        }

        private void GrfMed_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void Panel1_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            label35.Text = panel1.Height.ToString();
        }

        private void setControl(String vn)
        {
            vsOld = ic.ivfDB.ovsDB.selectByPk1(vn);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            vs = ic.ivfDB.vsDB.selectByVn(vn);
            ptt = ic.ivfDB.pttDB.selectByHn(vsOld.PIDS);
            //ptt.patient_birthday = pttOld.DateOfBirth;
            txtHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtPttNameE.Value = vsOld.PName;
            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtAllergy.Value = ptt.allergy_description;
            txtIdOld.Value = pttOld.PID;
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;
            txtVnOld.Value = vsOld.VN;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtVisitHeight.Value = vs.height;
            txtVisitBW.Value = vs.bw;
            txtVisitBP.Value = vs.bp;
            txtVisitPulse.Value = vs.pulse;
            chkChronic.Checked = ptt.status_congenial.Equals("1") ? true : false;
            stt.Show("<p><b>สวัสดี</b></p>คุณ " + ptt.congenital_diseases_description + "<br> กรุณา ป้อนรหัสผ่าน", chkChronic);
            //txtBg.Value = pttOld.b
            //txtAllergy.Value = 
        }
        private void initGrfVs()
        {
            grfVs = new C1FlexGrid();
            grfVs.Font = fEdit;
            grfVs.Dock = System.Windows.Forms.DockStyle.Fill;
            grfVs.Location = new System.Drawing.Point(0, 0);

            grfVs.DoubleClick += GrfVs_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnHistoryVs.Controls.Add(grfVs);

            theme1.SetTheme(grfVs, "Office2016Colorful");

        }

        private void GrfVs_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfVs()
        {
            grfVs.Clear();            
            DataTable dt = ic.ivfDB.vsDB.selectByPttId(ptt.t_patient_id);
            grfVs.Cols.Count = 10;
            grfVs.Rows.Count = dt.Rows.Count+1;

            grfVs.Cols[colVsDate].Width = 85;
            grfVs.Cols[colVsTime].Width = 70;
            grfVs.Cols[colVsBsp].Width = 120;
            grfVs.Cols[colNotice].Width = 120;
            grfVs.Cols[colVsETime].Width = 70;
            grfVs.Cols[colVsBp].Width = 70;
            grfVs.Cols[colVsBw].Width = 70;
            grfVs.Cols[colVsPulse].Width = 70;

            grfVs.ShowCursor = true;

            grfVs.Cols[colVsDate].Caption = "Date";
            grfVs.Cols[colVsTime].Caption = "Time";
            grfVs.Cols[colVsBsp].Caption = "จุดบริการ";
            grfVs.Cols[colNotice].Caption = "อาการ";
            grfVs.Cols[colVsETime].Caption = "ETime";
            grfVs.Cols[colVsBp].Caption = "BP";
            grfVs.Cols[colVsBw].Caption = "BW";
            grfVs.Cols[colVsPulse].Caption = "Pulse";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfVs[i, colVsId] = row[ic.ivfDB.vsDB.vs.t_visit_id].ToString();
                grfVs[i, colVsDate] = ic.datetoShow(row[ic.ivfDB.vsDB.vs.visit_begin_visit_time].ToString());
                grfVs[i, colVsTime] = ic.timetoShow(row[ic.ivfDB.vsDB.vs.visit_begin_visit_time].ToString());
                grfVs[i, colVsETime] = ic.timetoShow(row[ic.ivfDB.vsDB.vs.visit_financial_discharge_time].ToString());
                grfVs[i, colVsBsp] = row["service_point_description"].ToString();
                grfVs[i, colNotice] = row[ic.ivfDB.vsDB.vs.visit_notice].ToString();
                grfVs[i, colVsBp] = row[ic.ivfDB.vsDB.vs.bp].ToString();
                grfVs[i, colVsBw] = row[ic.ivfDB.vsDB.vs.bw].ToString();
                grfVs[i, colVsPulse] = row[ic.ivfDB.vsDB.vs.pulse].ToString();
                i++;
            }
            grfVs.Cols[colVsId].Visible = false;
            grfVs.Cols[colVsDate].AllowEditing = false;
            grfVs.Cols[colVsTime].AllowEditing = false;
            grfVs.Cols[colVsETime].AllowEditing = false;
            grfVs.Cols[colVsBsp].AllowEditing = false;
            grfVs.Cols[colNotice].AllowEditing = false;

            theme1.SetTheme(grfVs, "Office2016DarkGray");
        }
        private void initGrfAdm()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);

            grfpApmAll.DoubleClick += GrfpApmAll_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnAdm.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }

        private void GrfpApmAll_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfpApmAll()
        {
            //grfDept.Rows.Count = 7;
            grfpApmAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByPtt(ptt.t_patient_id);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmAll.Rows.Count = 1;
            grfpApmAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmAll.Cols[colApmNotice].Editor = txt;
            grfpApmAll.Cols[colApmAppointment].Editor = txt;
            grfpApmAll.Cols[colApmDoctor].Editor = txt;
            Column colE21 = grfpApmAll.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApmAll.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApmAll.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApmAll.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApmAll.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApmAll.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApmAll.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApmAll.Cols[colApmDate].Width = 100;
            grfpApmAll.Cols[colApmTime].Width = 80;
            grfpApmAll.Cols[colApmAppointment].Width = 120;
            grfpApmAll.Cols[colApmDoctor].Width = 100;
            grfpApmAll.Cols[colApmSp].Width = 80;
            grfpApmAll.Cols[colApmNotice].Width = 200;
            grfpApmAll.Cols[colE2].Width = 60;
            grfpApmAll.Cols[colLh].Width = 60;
            grfpApmAll.Cols[colEndo].Width = 60;
            grfpApmAll.Cols[colPrl].Width = 60;
            grfpApmAll.Cols[colFsh].Width = 60;
            grfpApmAll.Cols[colRt].Width = 60;
            grfpApmAll.Cols[colLt].Width = 60;

            grfpApmAll.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApmAll.Cols[colApmDate].Caption = "Date";
            grfpApmAll.Cols[colApmTime].Caption = "time";
            grfpApmAll.Cols[colApmAppointment].Caption = "นัด";
            grfpApmAll.Cols[colApmDoctor].Caption = "Doctor";
            grfpApmAll.Cols[colApmSp].Caption = "จุดบริการ";
            grfpApmAll.Cols[colApmNotice].Caption = "แจ้ง";
            grfpApmAll.Cols[colE2].Caption = "E2";
            grfpApmAll.Cols[colLh].Caption = "LH";
            grfpApmAll.Cols[colEndo].Caption = "Endo";
            grfpApmAll.Cols[colPrl].Caption = "PRL";
            grfpApmAll.Cols[colFsh].Caption = "FSH";
            grfpApmAll.Cols[colRt].Caption = "Rt";
            grfpApmAll.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit_papm));
            grfpApmAll.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmAll.Rows.Add();
                row1[0] = i;
                row1[colApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colApmAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colApmDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colApmSp] = row["service_point_description"].ToString();
                row1[colApmNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

                //row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString();
                //row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString();
                //row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo].ToString();
                //row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString();
                //row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString();
                //row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString();
                //row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString();

                row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.endo].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfpApmAll.Cols[colE2].AllowEditing = false;
            grfpApmAll.Cols[colLh].AllowEditing = false;
            grfpApmAll.Cols[colEndo].AllowEditing = false;
            grfpApmAll.Cols[colPrl].AllowEditing = false;
            grfpApmAll.Cols[colFsh].AllowEditing = false;
            grfpApmAll.Cols[colRt].AllowEditing = false;
            grfpApmAll.Cols[colLt].AllowEditing = false;
            //menuGw = new ContextMenu();
            //grfpApmAll.ContextMenu = menuGw;
            grfpApmAll.Cols[colApmId].Visible = false;
            theme1.SetTheme(grfpApmAll, ic.theme);

        }
        private void initGrfNote()
        {
            grfNote = new C1FlexGrid();
            grfNote.Font = fEdit;
            grfNote.Dock = System.Windows.Forms.DockStyle.Fill;
            grfNote.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfImg.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            grfNote.DoubleClick += GrfNote_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnNote.Controls.Add(grfNote);

            theme1.SetTheme(grfNote, "Office2016Colorful");

        }
        private void GrfNote_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfNote.Row < 0) return;
            String id = grfNote[grfNote.Row, colNoteId] != null ? grfNote[grfNote.Row, colNoteId].ToString() : "";
            String note = grfNote[grfNote.Row, colNote] != null ? grfNote[grfNote.Row, colNote].ToString() : "";
            txtNoteId.Value = id;
            txtNote.Value = note;
        }
        private void setGrfNote()
        {
            grfNote.Clear();
            grfNote.Rows.Count = 1;
            grfNote.Cols.Count = 4;
            DataTable dt = ic.ivfDB.noteDB.selectByPttId(ptt.t_patient_id);

            grfNote.Rows.Count = dt.Rows.Count + 1;

            grfNote.Cols[colNoteId].Width = 250;
            grfNote.Cols[colNote].Width = 600;

            grfNote.ShowCursor = true;

            grfNote.Cols[colNote].Caption = "Note";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfNote[i, colNoteId] = row[ic.ivfDB.noteDB.note.note_id].ToString();
                grfNote[i, colNote] = row[ic.ivfDB.noteDB.note.note_1].ToString();
                grfNote[i, colNoteStatusAll] = row[ic.ivfDB.noteDB.note.status_all].ToString();
                i++;
            }
            grfNote.Cols[colNoteId].Visible = false;
            grfNote.Cols[colNoteStatusAll].Visible = false;
            grfNote.Cols[colNote].AllowEditing = false;

            theme1.SetTheme(grfNote, "Office2016DarkGray");
        }
        private void FrmDoctorAdd_Load(object sender, EventArgs e)
        {
            //sC.HeaderHeight = 0;
            sCOrder.HeaderHeight = 0;
            sCmain.HeaderHeight = 0;
            sCHistory.HeaderHeight = 0;
            tC.SelectedTab = tabHistory;
            tCHistory.SelectedTab = tabHistoryDrug;
        }
    }
}
