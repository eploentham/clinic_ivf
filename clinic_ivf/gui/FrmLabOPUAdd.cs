﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabOPUAdd : Form
    {
        IvfControl ic;
        String reqId = "", opuId="";
        LabRequest lbReq;
        LabOpu opu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colDay2ID = 1, colDay2Num = 2, colDay2Desc = 3, colDay2Desc1=4, colDay2Desc2=5, colDay2Edit=6;
        int colDay3ID = 1, colDay3Num = 2, colDay3Desc = 3, colDay3Desc1 = 4, colDay3Desc2 = 5, colDay3Edit = 6;
        int colDay5ID = 1, colDay5Num = 2, colDay5Desc = 3, colDay5Desc1 = 4, colDay5Desc2 = 5, colDay5Edit = 6;
        int colDay6ID = 1, colDay6Num = 2, colDay6Desc = 3, colDay6Desc1 = 4, colDay6Desc2 = 5, colDay6Edit = 6;

        int colDay2ImgId = 1, colDay2ImgPic = 3, colDay2ImgNun = 2, colDay2ImgDesc0 = 4, colDay2PathPic=5;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1FlexGrid grfDay2Img;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Color color;
        public FrmLabOPUAdd(IvfControl ic, String reqid, String opuid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            opuId = opuid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            opu = new LabOpu();
            lbReq = new LabRequest();

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.OPUProcedure);
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryoForEtEmbryologist, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistReport, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistDay2, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistDay3, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistDay5, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistDay6, "");
            ic.setCboDay(CboEmbryoDay0, "");
            ic.setCboDay(CboEmbryoDay1, "");

            setControl();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            
            btnSave.Click += BtnSave_Click;
            btnSaveMatura.Click += BtnSaveMatura_Click;
            btnSaveFertili.Click += BtnSaveFertili_Click;
            btnSaveSperm.Click += BtnSaveSperm_Click;
            btnSaveEmbryoEt.Click += BtnSaveEmbryoEt_Click;
            btnSaveEmbryoFreezDay0.Click += BtnSaveEmbryoFreezDay0_Click;
            btnSaveEmbryoFreezDay1.Click += BtnSaveEmbryoFreezDay1_Click;
            btnSaveDay2.Click += BtnSaveDay2_Click;
            btnSaveDay3.Click += BtnSaveDay3_Click;
            btnSaveDay5.Click += BtnSaveDay5_Click;
            btnSaveDay6.Click += BtnSaveDay6_Click;
            btnPrint.Click += BtnPrint_Click;
            tC1.DoubleClick += TC1_DoubleClick;
            tabDay2.DoubleClick += TabDay2_DoubleClick;
            btnSaveImg2.Click += BtnSaveImg2_Click;
            btnDay2ImgRef.Click += BtnDay2ImgRef_Click;

            setFocusColor();
            initGrfDay2();
            initGrfDay3();
            initGrfDay5();
            initGrfDay6();
            setGrfDay2();
            setGrfDay3();
            setGrfDay5();
            setGrfDay6();
            initGrfDay2Img();
            setGrfDay2Img();
        }

        private void BtnDay2ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
        }

        private void BtnSaveImg2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = "";
                    int i = 0;
                    foreach (Row row in grfDay2Img.Rows)
                    {
                        String id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                        String path = row[colDay2PathPic] != null ? row[colDay2PathPic].ToString() : "";
                        String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                        String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                        i++;
                        if (i == 1) continue;
                        if (id.Equals(""))
                        {
                            if (no.Length > 0)
                            {
                                String filename = "";
                                String[] ext = path.Split('.');
                                if (ext.Length > 1)
                                {
                                    re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, filename, desc, ic.cStf.staff_id);
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        filename = txtOpuCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                        ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);
                                        grfDay2Img.Rows[i - 1].StyleNew.BackColor = color;
                                    }
                                }
                            }
                        }
                        //i++;
                    }
                }
            }
        }

        private void TabDay2_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //frm.ShowDialog(this);

                // Read the files

                //Row row1 = grfImg.Rows.Add();
                //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                int i = 1;
                grfDay2Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                grfDay2Img.Cols[colDay2ImgPic].AllowMerging = true;
                //cc.Image
                Column col = grfDay2Img.Cols[colDay2ImgPic];
                col.DataType = typeof(Image);
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        grfDay2Img.Cols[colDay2ImgPic].ImageAndText = true;
                        Row row1 = grfDay2Img.Rows.Add();
                        int row = grfDay2Img.Rows.Count;

                        int hei = grfDay2Img.Rows.DefaultSize;
                        //grfImg.Rows[row-1].Height = hei*6;
                        //CellRange rg1 = grfDay2Img.GetCellRange(row - 1, colDay2ImgPic);

                        //PictureBox pb = new PictureBox();
                        grfDay2Img[row - 1, colDay2ImgId] = "";
                        grfDay2Img[row - 1, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";

                        grfDay2Img[row - 1, colDay2ImgPic] = resizedImage;

                        i++;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
                grfDay2Img.AutoSizeCols();
                grfDay2Img.AutoSizeRows();
            }
        }

        private void TC1_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic,txtID.Text);
            frm.ShowDialog(this);
        }

        private void BtnSaveDay6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    //setOPUEmbryoFreezDay1();
                    //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    String re = "";
                    int i = 1;
                    foreach (Row row in grfDay6.Rows)
                    {
                        if (row[colDay6Edit] == null) continue;
                        if (row[colDay6Edit].ToString().Equals("1"))
                        {
                            if (row[colDay6Desc] == null) continue;

                            LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                            opuEmDev.opu_embryo_dev_id = row[colDay6ID] != null ? row[colDay6ID].ToString() : "";
                            opuEmDev.opu_fet_id = txtID.Text;
                            opuEmDev.day = "6";
                            opuEmDev.opu_embryo_dev_no = row[colDay6Num] != null ? row[colDay6Num].ToString() : i.ToString();
                            opuEmDev.desc0 = row[colDay6Desc].ToString();
                            opuEmDev.active = "1";
                            opuEmDev.remark = "";
                            opuEmDev.path_pic = "";
                            opuEmDev.date_create = "";
                            opuEmDev.date_modi = "";
                            opuEmDev.date_cancel = "";
                            opuEmDev.user_create = "";
                            opuEmDev.user_modi = "";
                            opuEmDev.user_cancel = "";
                            opuEmDev.desc1 = row[colDay6Desc1] != null ? row[colDay6Desc1].ToString() : "";
                            opuEmDev.desc2 = row[colDay6Desc2] != null ? row[colDay6Desc2].ToString() : "";
                            opuEmDev.desc3 = "";
                            ComboBoxItem item = new ComboBoxItem();
                            if (cboEmbryologistDay6.SelectedItem != null)
                            {
                                item = (ComboBoxItem)cboEmbryologistDay6.SelectedItem;
                                opuEmDev.staff_id = item.Value;
                            }
                            else
                            {
                                opuEmDev.staff_id = "0";
                            }
                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                chkSave = true;
                                row[colDay6Edit] = "0";
                                //MessageBox.Show("Error", "");
                            }
                        }
                        i++;
                    }
                    long chk1 = 0;
                    if (chkSave)
                    {
                        setGrfDay6();
                        btnSaveDay5.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSaveDay5.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveDay5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 5 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    //setOPUEmbryoFreezDay1();
                    //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    String re = "";
                    int i = 1;
                    foreach (Row row in grfDay5.Rows)
                    {
                        if (row[colDay5Edit] == null) continue;
                        if (row[colDay5Edit].ToString().Equals("1"))
                        {
                            if (row[colDay5Desc] == null) continue;

                            LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                            opuEmDev.opu_embryo_dev_id = row[colDay5ID] != null ? row[colDay5ID].ToString() : "";
                            opuEmDev.opu_fet_id = txtID.Text;
                            opuEmDev.day = "5";
                            opuEmDev.opu_embryo_dev_no = row[colDay5Num] != null ? row[colDay5Num].ToString() : i.ToString();
                            opuEmDev.desc0 = row[colDay5Desc].ToString();
                            opuEmDev.active = "1";
                            opuEmDev.remark = "";
                            opuEmDev.path_pic = "";
                            opuEmDev.date_create = "";
                            opuEmDev.date_modi = "";
                            opuEmDev.date_cancel = "";
                            opuEmDev.user_create = "";
                            opuEmDev.user_modi = "";
                            opuEmDev.user_cancel = "";
                            opuEmDev.desc1 = row[colDay5Desc1] != null ? row[colDay5Desc1].ToString() : "";
                            opuEmDev.desc2 = row[colDay5Desc2] != null ? row[colDay5Desc2].ToString() : "";
                            opuEmDev.desc3 = "";
                            ComboBoxItem item = new ComboBoxItem();
                            if (cboEmbryologistDay5.SelectedItem != null)
                            {
                                item = (ComboBoxItem)cboEmbryologistDay5.SelectedItem;
                                opuEmDev.staff_id = item.Value;
                            }
                            else
                            {
                                opuEmDev.staff_id = "0";
                            }
                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                chkSave = true;
                                row[colDay5Edit] = "0";
                                //MessageBox.Show("Error", "");
                            }
                        }
                        i++;
                    }
                    long chk1 = 0;
                    if (chkSave)
                    {
                        setGrfDay5();
                        btnSaveDay5.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSaveDay5.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveDay3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 3 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    //setOPUEmbryoFreezDay1();
                    //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    String re = "";
                    int i = 1;
                    foreach (Row row in grfDay3.Rows)
                    {
                        if (row[colDay3Edit] == null) continue;
                        if (row[colDay3Edit].ToString().Equals("1"))
                        {
                            if (row[colDay3Desc] == null) continue;

                            LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                            opuEmDev.opu_embryo_dev_id = row[colDay3ID] != null ? row[colDay3ID].ToString() : "";
                            opuEmDev.opu_fet_id = txtID.Text;
                            opuEmDev.day = "3";
                            opuEmDev.opu_embryo_dev_no = row[colDay3Num] != null ? row[colDay3Num].ToString() : i.ToString();
                            opuEmDev.desc0 = row[colDay3Desc].ToString();
                            opuEmDev.active = "1";
                            opuEmDev.remark = "";
                            opuEmDev.path_pic = "";
                            opuEmDev.date_create = "";
                            opuEmDev.date_modi = "";
                            opuEmDev.date_cancel = "";
                            opuEmDev.user_create = "";
                            opuEmDev.user_modi = "";
                            opuEmDev.user_cancel = "";
                            opuEmDev.desc1 = row[colDay3Desc1] != null ? row[colDay3Desc1].ToString() : "";
                            opuEmDev.desc2 = row[colDay3Desc2] != null ? row[colDay3Desc2].ToString() : "";
                            opuEmDev.desc3 = "";
                            ComboBoxItem item = new ComboBoxItem();
                            if (cboEmbryologistDay3.SelectedItem != null)
                            {
                                item = (ComboBoxItem)cboEmbryologistDay3.SelectedItem;
                                opuEmDev.staff_id = item.Value;
                            }
                            else
                            {
                                opuEmDev.staff_id = "0";
                            }
                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                row[colDay3Edit] = "0";
                                //MessageBox.Show("Error", "");
                                chkSave = true;
                            }
                            else
                            {
                                chkSave = false;
                            }
                        }
                        i++;
                    }
                    long chk1 = 0;
                    if (chkSave)
                    {
                        setGrfDay3();
                        btnSaveDay3.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSaveDay3.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveDay2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 2 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    //setOPUEmbryoFreezDay1();
                    //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    String re = "";
                    int i = 1;
                    foreach (Row row in grfDay2.Rows)
                    {
                        if (row[colDay2Edit] == null) continue;
                        if (row[colDay2Edit].ToString().Equals("1"))
                        {
                            if (row[colDay2Desc] == null) continue;

                            LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                            opuEmDev.opu_embryo_dev_id = row[colDay2ID] != null ? row[colDay2ID].ToString():"";
                            opuEmDev.opu_fet_id = txtID.Text;
                            opuEmDev.day = "2";
                            opuEmDev.opu_embryo_dev_no = row[colDay2Num] != null ? row[colDay2Num].ToString(): i.ToString();
                            opuEmDev.desc0 = row[colDay2Desc].ToString();
                            opuEmDev.active = "1";
                            opuEmDev.remark = "";
                            opuEmDev.path_pic = "";
                            opuEmDev.date_create = "";
                            opuEmDev.date_modi = "";
                            opuEmDev.date_cancel = "";
                            opuEmDev.user_create = "";
                            opuEmDev.user_modi = "";
                            opuEmDev.user_cancel = "";
                            opuEmDev.desc1 = row[colDay2Desc1]!=null ? row[colDay2Desc1].ToString() : "";
                            opuEmDev.desc2 = row[colDay2Desc2] != null ? row[colDay2Desc2].ToString() : "";
                            opuEmDev.desc3 = "";
                            ComboBoxItem item = new ComboBoxItem();
                            if (cboEmbryologistDay2.SelectedItem != null)
                            {
                                item = (ComboBoxItem)cboEmbryologistDay2.SelectedItem;
                                opuEmDev.staff_id = item.Value;
                            }
                            else
                            {
                                opuEmDev.staff_id = "0";
                            }
                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                row[colDay2Edit] = "0";
                                chkSave = true;
                                //MessageBox.Show("Error", "");
                            }
                            else
                            {
                                chkSave = false;
                            }
                        }
                        i++;
                    }

                    long chk1 = 0;
                    if (chkSave)
                    {
                        setGrfDay2();
                        btnSaveDay2.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSaveDay2.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveEmbryoFreezDay1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryoFreezDay1();
                    String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveEmbryoFreezDay0_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryoFreezDay0();
                    String re = ic.ivfDB.opuDB.updateEmbryoFreezDay0(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveEmbryoEt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryeEt();
                    String re = ic.ivfDB.opuDB.updateEmbryoEt(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveSperm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Sperm Preparation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUSperm();
                    String re = ic.ivfDB.opuDB.updateSperm(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveFertili_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Fertilization ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUFertilization();
                    String re = ic.ivfDB.opuDB.updateFertili(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveMatura_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Maturation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUMatura();
                    String re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void setFocusColor()
        {
            this.txtHnFeMale.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHnFeMale.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtPosiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtPosiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setControl()
        {
            try
            {
                if (!reqId.Equals(""))
                {
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(reqId);

                    txtHnFeMale.Value = lbReq.hn_female;
                    txtHnMale.Value = lbReq.hn_male;
                    txtNameFeMale.Value = lbReq.name_female;
                    txtNameMale.Value = lbReq.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                }
                else
                {
                    opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);

                    txtID.Value = opu.opu_id;
                    txtHnFeMale.Value = opu.hn_female;
                    txtHnMale.Value = opu.hn_male;
                    txtNameFeMale.Value = opu.name_female;
                    txtNameMale.Value = opu.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                    txtDobFeMale.Value = opu.dob_female;
                    txtDobMale.Value = opu.dob_male;
                    ic.setC1Combo(cboDoctor, opu.doctor_id);
                    txtOpuDate.Value = opu.opu_date;
                    ic.setC1Combo(cboOpuProce, opu.proce_id);
                    txtOpuCode.Value = opu.opu_code;

                    txtMaturaNoofOpu.Value = opu.matura_no_of_opu;
                    txtMaturaDate.Value = opu.matura_date;
                    txtMaturaMii.Value = opu.matura_m_ii;
                    txtMaturaMi.Value = opu.matura_m_i;
                    txtMaturaGv.Value = opu.matura_gv;
                    txtMaturaPostMat.Value = opu.matura_post_mat;
                    txtMaturaAbnor.Value = opu.matura_abmormal;
                    txtMaturaDead.Value = opu.matura_dead;

                    txtFertiliDate.Value = opu.fertili_date;
                    txtFertili2Pn.Value = opu.fertili_2_pn;
                    txtFertili1Pn.Value = opu.fertili_1_pn;
                    txtFertili3Pn.Value = opu.fertili_3_pn;
                    txtFertili4Pn.Value = opu.fertili_4_pn;
                    txtFertiliNoPn.Value = opu.fertili_no_pn;
                    txtFertiliDead.Value = opu.fertili_dead;

                    txtSpermDate.Value = opu.sperm_date;
                    txtSpermVol.Value = opu.sperm_volume;
                    txtSpermCnt.Value = opu.sperm_count;
                    txtSpermTotalCnt.Value = opu.sperm_count_total;
                    txtSpermMoti.Value = opu.sperm_motile;
                    txtSpermMotiTotal.Value = opu.sperm_motile_total;
                    txtSpermMotility.Value = opu.sperm_motility;
                    chkSpermFresh.Value = opu.sperm_fresh_sperm.Equals("1") ? true : false;
                    chkSpermFrozen.Value = opu.sperm_frozen_sperm.Equals("1") ? true : false;
                    txtEmbryoForEtNO.Value = opu.embryo_for_et_no_of_et;
                    txtEmbryoForEtDay.Value = opu.embryo_for_et_day;
                    txtEmbryoForEtDate.Value = opu.embryo_for_et_date;
                    txtEmbryoForEtAsseted.Value = opu.embryo_for_et_assisted;
                    txtEmbryoForEtVolume.Value = opu.embryo_for_et_volume;
                    txtEmbryoForEtCatheter.Value = opu.embryo_for_et_catheter;
                    txtEmbryoForEtDoctor.Value = opu.embryo_for_et_doctor;
                    txtEmbryoForEtNumTran.Value = opu.embryo_for_et_number_of_transfer;
                    txtEmbryoForEtNumFreeze.Value = opu.embryo_for_et_number_of_freeze;
                    txtEmbryoForEtNumDiscard.Value = opu.embryo_for_et_number_of_discard;
                    //cboEmbryoForEtEmbryologist.Value = opu.embryo_for_et_embryologist_id;
                    //cboEmbryologistReport.Value = opu.embryologist_report_id;
                    //cboEmbryologistAppv.Value = opu.embryologist_approve_id;
                    ic.setC1Combo(cboEmbryologistAppv, opu.embryologist_approve_id);
                    ic.setC1Combo(cboEmbryologistReport, opu.embryologist_report_id);
                    ic.setC1Combo(cboEmbryoForEtEmbryologist, opu.embryo_for_et_embryologist_id);
                    ic.setC1Combo(CboEmbryoDay0, opu.embryo_freez_day_0);
                    ic.setC1Combo(CboEmbryoDay1, opu.embryo_freez_day_1);
                    txtEmbryoFreezDate0.Value = opu.embryo_freez_date_0;
                    txtEmbryoFreezDate1.Value = opu.embryo_freez_date_1;
                    txtEmbryoFreezStage0.Value = opu.embryo_freez_stage_0;
                    txtEmbryoFreezStage1.Value = opu.embryo_freez_stage_1;
                    txtEmbryoFreezNoOg0.Value = opu.embryo_freez_no_og_0;
                    txtEmbryoFreezNoOg1.Value = opu.embryo_freez_no_og_1;
                    txtEmbryoFreezNoStraw0.Value = opu.embryo_freez_no_of_straw_0;
                    txtEmbryoFreezNoStraw1.Value = opu.embryo_freez_no_of_straw_1;
                    txtEmbryoFreezPosi0.Value = opu.embryo_freez_position_0;
                    txtEmbryoFreezPosi1.Value = opu.embryo_freez_position_1;
                    txtEmbryoFreezMethod0.Value = opu.embryo_freez_mothod_0;
                    txtEmbryoFreezMethod1.Value = opu.embryo_freez_mothod_1;
                    txtEmbryoFreezMedia0.Value = opu.embryo_freez_freeze_media_0;
                    txtEmbryoFreezMedia1.Value = opu.embryo_freez_freeze_media_1;

                    txtRemark.Value = opu.remark;
                    //CboEmbryoDay.Text = opu.emb
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message, "");
            }
            
        }
        private void setOPU()
        {
            opu.opu_id = txtID.Text;
            opu.hn_female = txtHnFeMale.Text;
            opu.hn_male = txtHnMale.Text;
            opu.name_female = txtNameFeMale.Text;
            opu.name_male = txtNameMale.Text;
            //lbReq.req_code = txtLabReqCode.Text;
            opu.dob_female = txtDobFeMale.Text;
            opu.dob_male = txtDobMale.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (cboDoctor.SelectedItem != null)
            {
                item = (ComboBoxItem)cboDoctor.SelectedItem;
                opu.doctor_id = item.Value;
            }
            else
            {
                opu.doctor_id = "0";
            }
            opu.opu_date = txtOpuDate.Text;
            if (cboDoctor.SelectedItem != null)
            {
                item = (ComboBoxItem)cboOpuProce.SelectedItem;
                opu.proce_id = item.Value;
            }
            else
            {
                opu.proce_id = "0";
            }
            opu.opu_code = txtOpuCode.Text;
            opu.remark = txtRemark.Text;
        }
        private void setOPUMatura()
        {
            opu.opu_id = txtID.Text;
            opu.matura_no_of_opu = txtMaturaNoofOpu.Text;
            opu.matura_date = txtMaturaDate.Text;
            opu.matura_m_ii = txtMaturaMii.Text;
            opu.matura_m_i = txtMaturaMi.Text;
            opu.matura_gv = txtMaturaGv.Text;
            opu.matura_post_mat = txtMaturaPostMat.Text;
            opu.matura_abmormal = txtMaturaAbnor.Text;            
            opu.matura_dead = txtMaturaDead.Text;            
        }
        private void setOPUFertilization()
        {
            opu.opu_id = txtID.Text;
            opu.fertili_date = txtFertiliDate.Text;
            opu.fertili_2_pn = txtFertili2Pn.Text;
            opu.fertili_1_pn = txtFertili1Pn.Text;
            opu.fertili_3_pn = txtFertili3Pn.Text;
            opu.fertili_4_pn = txtFertili4Pn.Text;
            opu.fertili_no_pn = txtFertiliNoPn.Text;
            opu.fertili_dead = txtFertiliDead.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUSperm()
        {
            opu.opu_id = txtID.Text;
            opu.sperm_date = txtSpermDate.Text;
            opu.sperm_volume = txtSpermVol.Text;
            opu.sperm_count = txtSpermCnt.Text;
            opu.sperm_count_total = txtSpermTotalCnt.Text;
            opu.sperm_motile = txtSpermMoti.Text;
            opu.sperm_motile_total = txtSpermMotiTotal.Text;
            opu.sperm_motility = txtSpermMotility.Text;
            opu.sperm_fresh_sperm = chkSpermFresh.Checked ? "1" : "0";
            opu.sperm_frozen_sperm = chkSpermFrozen.Checked ? "1" : "0";
        }
        private void setOPUEmbryeEt()
        {
            opu.opu_id = txtID.Text;
            opu.embryo_for_et_no_of_et = txtEmbryoForEtNO.Text;
            opu.embryo_for_et_day = txtEmbryoForEtDay.Text;
            opu.embryo_for_et_date = txtEmbryoForEtDate.Text;
            opu.embryo_for_et_assisted = txtEmbryoForEtAsseted.Text;
            opu.embryo_for_et_volume = txtEmbryoForEtVolume.Text;
            opu.embryo_for_et_catheter = txtEmbryoForEtCatheter.Text;
            opu.embryo_for_et_doctor = txtEmbryoForEtDoctor.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (cboEmbryoForEtEmbryologist.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryoForEtEmbryologist.SelectedItem;
                opu.embryo_for_et_embryologist_id = item.Value;
            }
            else
            {
                opu.embryo_for_et_embryologist_id = "0";
            }
            if (cboEmbryologistReport.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryologistReport.SelectedItem;
                opu.embryologist_report_id = item.Value;
            }
            else
            {
                opu.embryologist_report_id = "0";
            }
            if (cboEmbryologistAppv.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryologistAppv.SelectedItem;
                opu.embryologist_approve_id = item.Value;
            }
            else
            {
                opu.embryologist_approve_id = "0";
            }

            opu.embryo_for_et_number_of_transfer = txtEmbryoForEtNumTran.Text;
            opu.embryo_for_et_number_of_freeze = txtEmbryoForEtNumFreeze.Text;
            opu.embryo_for_et_number_of_discard = txtEmbryoForEtNumDiscard.Text;
        }
        private void setOPUEmbryoFreezDay1()
        {
            opu.opu_id = txtID.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (CboEmbryoDay1.SelectedItem != null)
            {
                item = (ComboBoxItem)CboEmbryoDay1.SelectedItem;
                opu.embryo_freez_day_1 = item.Value;
            }
            else
            {
                opu.embryo_freez_day_1 = "0";
            }

            opu.embryo_freez_date_1 = txtEmbryoFreezDate1.Text;
            opu.embryo_freez_stage_1 = txtEmbryoFreezStage1.Text;
            opu.embryo_freez_no_og_1 = txtEmbryoFreezNoOg1.Text;
            opu.embryo_freez_no_of_straw_1 = txtEmbryoFreezNoStraw1.Text;
            opu.embryo_freez_position_1 = txtEmbryoFreezPosi1.Text;
            opu.embryo_freez_mothod_1 = txtEmbryoFreezMethod1.Text;
            opu.embryo_freez_freeze_media_1 = txtEmbryoFreezMedia1.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUEmbryoFreezDay0()
        {
            opu.opu_id = txtID.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (CboEmbryoDay0.SelectedItem != null)
            {
                item = (ComboBoxItem)CboEmbryoDay0.SelectedItem;
                opu.embryo_freez_day_0 = item.Value;
            }
            else
            {
                opu.embryo_freez_day_0 = "0";
            }

            opu.embryo_freez_date_0 = txtEmbryoFreezDate0.Text;
            opu.embryo_freez_stage_0 = txtEmbryoFreezStage0.Text;
            opu.embryo_freez_no_og_0 = txtEmbryoFreezNoOg0.Text;
            opu.embryo_freez_no_of_straw_0 = txtEmbryoFreezNoStraw0.Text;
            opu.embryo_freez_position_0 = txtEmbryoFreezPosi0.Text;
            opu.embryo_freez_mothod_0 = txtEmbryoFreezMethod0.Text;
            opu.embryo_freez_freeze_media_0 = txtEmbryoFreezMedia0.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPU();
                    String re = ic.ivfDB.opuDB.update(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
                
                //int chk = 0;
                //if (int.TryParse(re, out chk))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //setGrfPosi();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void setGrfDay2Img()
        {
            grfDay2Img.Clear();
            grfDay2Img.DataSource = null;
            grfDay2Img.Rows.Count = 1;
            grfDay2Img.Cols.Count = 6;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;
            //btn.Click += BtnEditor_Click;
            PictureBox img = new PictureBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfDay2Img.Cols[colDay2ImgId].Editor = txt;
            grfDay2Img.Cols[colDay2ImgNun].Editor = txt;
            grfDay2Img.Cols[colDay2ImgDesc0].Editor = txt;
            grfDay2Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay2Img.Cols[colDay2ImgPic].Editor = img;

            grfDay2Img.Cols[colDay2ImgId].Width = 250;
            grfDay2Img.Cols[colDay2ImgPic].Width = 100;
            grfDay2Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay2Img.Cols[colDay2ImgNun].Width = 100;
            grfDay2Img.Cols[colDay2PathPic].Width = 100;
            //grfDay2Img.Cols[colDay2ImgBtn].Width = 50;
            //grfDay2Img.Cols[colPathPic].Width = 100;

            grfDay2Img.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay2Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay2Img.Cols[colDay2ImgDesc0].Caption = "Desc1";
            grfDay2Img.Cols[colDay2PathPic].Caption = "pathpic";
            //grfDay2Img.Cols[colDesc3].Caption = "Desc3";
            //grfDay2Img.Cols[colDay2ImgBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            grfDay2Img.Cols[colDay2ImgPic].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfDay2Img.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay2Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay2Img.Cols[colDay2ImgPic].AllowMerging = true;
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay2Img.Rows.Add();
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                
                if (row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic] != null && !row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                {
                    //Thread threadA = new Thread(ExecuteA);
                    //threadA.Start("");
                    int ii = i;
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage=null, resizedImage;
                        String aaa = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
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
                            /* Create an FTP Request */
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            /* Log in to the FTP Server with the User Name and Password Provided */
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            /* When in doubt, use these options */
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = false;
                            ftpRequest.KeepAlive = true;
                            /* Specify the Type of FTP Request */
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            /* Establish Return Communication with the FTP Server */
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            /* Get the FTP Server's Response Stream */
                            ftpStream = ftpResponse.GetResponseStream();
                            /* Open a File Stream to Write the Downloaded File */
                            //FileStream localFileStream = new FileStream(localFile, FileMode.Create);

                            /* Buffer for the Downloaded Data */
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);

                            /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    //localFileStream.Write(byteBuffer, 0, bytesRead);
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            loadedImage = new Bitmap(stream);
                            /* Resource Cleanup */
                            //localFileStream.Close();
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        grfDay2Img.Cols[colDay2ImgPic].ImageAndText = true;
                        //grfDay2Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                        //grfDay2Img.Cols[colDay2ImgPic].AllowMerging = true;
                        //loadedImage = new Bitmap(ic.ftpC.download(aaa));
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfDay2Img.Cols[colDay2ImgPic];
                            col.DataType = typeof(Image);
                            row1[colDay2ImgPic] = resizedImage;
                            //grfDay2Img.Redraw = true;
                            
                        }
                        
                        //grfDay2Img.AutoSizeCols();
                        //grfDay2Img.AutoSizeRows();
                    }).Start();
                }

                //grfDay2Img[i, 0] = i;
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            
            //grfDay2Img.Cols[colDay2ImgId].Visible = false;
            grfDay2Img.Cols[colDay2PathPic].Visible = false;
            //grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
            theme1.SetTheme(grfDay2Img, "Office2016Colorful");
            grfDay2Img.Refresh();
        }
        
        private void initGrfDay2Img()
        {
            grfDay2Img = new C1FlexGrid();
            grfDay2Img.Font = fEdit;
            grfDay2Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay2Img.DoubleClick += GrfDay2Img_DoubleClick;
            //grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            grfDay2Img.ContextMenu = menuGw;
            pnGrf2Img.Controls.Add(grfDay2Img);

            theme1.SetTheme(grfDay2Img, "Office2010Blue");
        }
        private void ContextMenu_grfday2_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay2Img[grfDay2Img.Row, colDay2PathPic] != null ? grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString(): "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
                    String pathfile = ofd.FileName;
                    String desc = grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0] != null ? grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0].ToString() : "";
                    String no = grfDay2Img[grfDay2Img.Row, colDay2ImgNun] != null ? grfDay2Img[grfDay2Img.Row, colDay2ImgNun].ToString() : "";
                    if (no.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtOpuCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, "images/"+ txtOpuCode.Text +"/"+ filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                                    grfDay2Img.Rows[grfDay2Img.Row].StyleNew.BackColor = color;
                                }
                            }
                        }
                    }
                }                
            }
        }
        private void ContextMenu_grfday2_save(object sender, System.EventArgs e)
        {
            String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
            String desc = grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay2Img[grfDay2Img.Row, colDay2ImgNun].ToString();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number "+ num+" description "+ desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                }
            }
        }
        private void ContextMenu_grfday2_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id,"","","", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtOpuCode.Text, pathfile);
                }
            }
        }
        private void GrfDay2Img_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2Img.Row < 0) return;
            if (grfDay2Img.Col == colDay2ImgPic)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfDay2Img.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfDay2Img[row, colDay2ID] != null ? grfDay2Img[row, colDay2ID].ToString() : "", "", grfDay2Img[row, colDay2PathPic].ToString(), FrmShowImage.statusModule.LabOPU);
                frm.ShowDialog(this);
            }
        }

        private void initGrfDay2()
        {
            grfDay2 = new C1FlexGrid();
            grfDay2.Font = fEdit;
            grfDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay2.AfterRowColChange += GrfDay2_AfterRowColChange;
            grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            grfDay2.CellChanged += GrfDay2_CellChanged;
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            //menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            //grfDay2.ContextMenu = menuGw;
            pn2Grf.Controls.Add(grfDay2);

            theme1.SetTheme(grfDay2, "Office2010Blue");
        }
        
        private void GrfDay2_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;
            grfDay2[grfDay2.Row, colDay2Edit] = "1";
            //grfDay2[grfDay2.Row, 0] = "1";
            //grfDay2.Rows[grfDay2.Row].
            grfDay2.Rows[grfDay2.Row].StyleNew.BackColor = color;
            if(grfDay2.Col== colDay2Desc)
            {
                if ((grfDay2.Row + 1) == grfDay2.Rows.Count)
                    grfDay2.Rows.Add();
            }
        }

        private void GrfDay2_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;
            
        }

        private void GrfDay2_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;
            //if (grfDay2.Row == grfDay2.Rows.Count)
            //    grfDay2.Rows.Add();
        }

        private void initGrfDay6()
        {
            grfDay6 = new C1FlexGrid();
            grfDay6.Font = fEdit;
            grfDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay6.ChangeEdit += GrfDay6_ChangeEdit;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay6.ContextMenu = menuGw;
            pn6Grf.Controls.Add(grfDay6);

            theme1.SetTheme(grfDay6, "Office2010Blue");
        }

        private void GrfDay6_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay6.Row == null) return;
            if (grfDay6.Row < 0) return;
            grfDay6[grfDay6.Row, colDay6Edit] = "1";
            grfDay6.Rows[grfDay6.Row].StyleNew.BackColor = color;
            if (grfDay6.Col == colDay6Desc)
            {
                if ((grfDay6.Row + 1) == grfDay6.Rows.Count)
                    grfDay6.Rows.Add();
            }
        }

        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay3.ChangeEdit += GrfDay3_ChangeEdit;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay3.ContextMenu = menuGw;
            pn3Grf.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, "Office2010Silver");
        }

        private void GrfDay3_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay3.Row == null) return;
            if (grfDay3.Row < 0) return;
            grfDay3[grfDay3.Row, colDay3Edit] = "1";
            grfDay3.Rows[grfDay3.Row].StyleNew.BackColor = color;
            if (grfDay3.Col == colDay3Desc)
            {
                if ((grfDay3.Row + 1) == grfDay3.Rows.Count)
                    grfDay3.Rows.Add();
            }
        }

        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay5.ChangeEdit += GrfDay5_ChangeEdit;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            pn5Grf.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Red");
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }

        private void GrfDay5_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay5.Row == null) return;
            if (grfDay5.Row < 0) return;
            grfDay5[grfDay5.Row, colDay5Edit] = "1";
            grfDay5.Rows[grfDay5.Row].StyleNew.BackColor = color;
            if (grfDay5.Col == colDay5Desc)
            {
                if ((grfDay5.Row + 1) == grfDay5.Rows.Count)
                    grfDay5.Rows.Add();
            }
        }

        private void setGrfDay2()
        {
            //grfDept.Rows.Count = 7;
            grfDay2.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay2.Rows.Count = 1;
            grfDay2.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfDay2.Cols[colDay2ID].Editor = txt;
            grfDay2.Cols[colDay2Num].Editor = txt;
            grfDay2.Cols[colDay2Desc].Editor = txt;
            grfDay2.Cols[colDay2Desc1].Editor = txt;
            grfDay2.Cols[colDay2Desc2].Editor = txt;

            grfDay2.Cols[colDay2Num].Width = 40;
            grfDay2.Cols[colDay2Desc].Width = 100;
            grfDay2.Cols[colDay2Desc1].Width = 50;
            grfDay2.Cols[colDay2Desc2].Width = 50;

            grfDay2.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay2.Cols[colDay2Num].Caption = "no";
            grfDay2.Cols[colDay2Desc].Caption = "desc";
            grfDay2.Cols[colDay2Desc1].Caption = "desc1";
            grfDay2.Cols[colDay2Desc2].Caption = "desc2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay2.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                row1[colDay2ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay2Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay2Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay2.Rows.Add();
            grfDay2.Cols[colDay2ID].Visible = false;
            grfDay2.Cols[colDay2Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay2, staffId);
        }
        private void setGrfDay3()
        {
            //grfDept.Rows.Count = 7;
            grfDay3.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            grfDay3.Rows.Count = 1;
            grfDay3.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay3.Cols[colDay3ID].Editor = txt;
            grfDay3.Cols[colDay3Num].Editor = txt;
            grfDay3.Cols[colDay3Desc].Editor = txt;
            grfDay3.Cols[colDay3Desc1].Editor = txt;
            grfDay3.Cols[colDay3Desc2].Editor = txt;

            grfDay3.Cols[colDay3Num].Width = 40;
            grfDay3.Cols[colDay3Desc].Width = 100;
            grfDay3.Cols[colDay3Desc1].Width = 50;
            grfDay3.Cols[colDay3Desc2].Width = 50;

            grfDay3.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay3.Cols[colDay3Num].Caption = "no";
            grfDay3.Cols[colDay3Desc].Caption = "desc";
            grfDay3.Cols[colDay3Desc1].Caption = "desc1";
            grfDay3.Cols[colDay3Desc2].Caption = "desc2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            int i = 0;
            String staffId = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay3.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                row1[colDay3ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay3Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay3Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay3Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay3Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay3.Rows.Add();
            grfDay3.Cols[colDay3ID].Visible = false;
            grfDay3.Cols[colDay3Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay3, staffId);
        }
        private void setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            grfDay5.Rows.Count = 1;
            grfDay5.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay5.Cols[colDay5ID].Editor = txt;
            grfDay5.Cols[colDay5Num].Editor = txt;
            grfDay5.Cols[colDay5Desc].Editor = txt;
            grfDay5.Cols[colDay5Desc1].Editor = txt;
            grfDay5.Cols[colDay5Desc2].Editor = txt;

            grfDay5.Cols[colDay5Num].Width = 40;
            grfDay5.Cols[colDay5Desc].Width = 100;
            grfDay5.Cols[colDay5Desc1].Width = 50;
            grfDay5.Cols[colDay5Desc2].Width = 50;

            grfDay5.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay5.Cols[colDay5Num].Caption = "no";
            grfDay5.Cols[colDay5Desc].Caption = "desc";
            grfDay5.Cols[colDay5Desc1].Caption = "desc1";
            grfDay5.Cols[colDay5Desc2].Caption = "desc2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 0;
            String staffId = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay5.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                row1[colDay5ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay5Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay5Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay5Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay5Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay5.Rows.Add();
            grfDay5.Cols[colDay5ID].Visible = false;
            grfDay5.Cols[colDay5Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay5, staffId);
        }
        private void setGrfDay6()
        {
            //grfDept.Rows.Count = 7;
            grfDay6.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay6.Rows.Count = 1;
            grfDay6.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay6.Cols[colDay6ID].Editor = txt;
            grfDay6.Cols[colDay6Num].Editor = txt;
            grfDay6.Cols[colDay6Desc].Editor = txt;
            grfDay6.Cols[colDay6Desc1].Editor = txt;
            grfDay6.Cols[colDay6Desc2].Editor = txt;

            grfDay6.Cols[colDay6Num].Width = 40;
            grfDay6.Cols[colDay6Desc].Width = 100;
            grfDay6.Cols[colDay6Desc1].Width = 50;
            grfDay6.Cols[colDay6Desc2].Width = 50;

            grfDay6.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay6.Cols[colDay6Num].Caption = "no";
            grfDay6.Cols[colDay6Desc].Caption = "desc";
            grfDay6.Cols[colDay6Desc1].Caption = "desc1";
            grfDay6.Cols[colDay6Desc2].Caption = "desc2";


            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 0;
            String staffId = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay6.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                row1[colDay6ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay6Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay6Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay6Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay6Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay6.Rows.Add();
            grfDay6.Cols[colDay2ID].Visible = false;
            grfDay6.Cols[colDay2Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay6, staffId);
        }
        private void FrmLabOPUAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
