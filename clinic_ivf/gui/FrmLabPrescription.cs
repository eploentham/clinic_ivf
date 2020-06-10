using C1.Win.C1Input;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmLabPrescription:Form
    {
        IvfControl ic;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        LabPrescription labPresc;

        C1ThemeController theme1;
        Panel panel1;
        C1ComboBox cboPkg, cboStfId, cboChkId;
        C1TextBox txtName, txtEmbryoFreezing, txtEmbryoStraws, txtEmbryoStrawsExtra, txtID, txtNGSEmbryo, txtNGSExtra, txtPGSEmbryo, txtPGSExtra, txtSpermSelection, txtSpermPrecaution, txtEmbryoRemaining;
        Label lbName, lbEmbryoFreezing, lbEmbryoStraws, lbEmbryoEmbryo, lbDate, lbPkg, lbStfId, lbChkId, lbNGSEmbryo, lbNGSExtra, lbPGSEmbryo, lbPGSExtra, lbEmbryoRemaining;
        C1Button btnSave, btnModality;
        C1DateEdit txtDate;
        C1CheckBox chkEmbryoFreezing, chkNGS, chkPGS, chkDay6, chkAssistedHatching, chkHA, chkSpermSelection, chkSpermPrecaution, chkEmbryoGlue, chkEmbryoRemaining, chkDiscardAll;
        Image imgStart;

        String hn = "", id="", opufetid="";

        public FrmLabPrescription(IvfControl ic, String id, String opufetid, String hn)
        {
            this.ic = ic;
            this.id = id;
            this.opufetid = opufetid;
            this.hn = hn;
            InitComponent();
            initConfig();
        }
        private void InitComponent()
        {
            int gapLine = 30, gapX = 20, gapY=20;
            Size size = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            imgStart = Resources.accept_database24;

            theme1 = new C1ThemeController();
            theme1.Theme = ic.theme;
            panel1 = new Panel();

            panel1.SuspendLayout();

            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Name = "panel1";

            txtID = new C1TextBox();
            txtID.Font = fEdit;
            //txtID.Location = new System.Drawing.Point(cboPkg.Location.X, lbName.Location.Y);
            txtID.Size = new Size(120, 20);
            txtID.Name = "txtID";
            txtID.Hide();

            lbDate = new Label();
            lbDate.Text = "Date : ";
            lbDate.Font = fEdit;
            lbDate.Location = new System.Drawing.Point(gapX, gapY);
            lbDate.AutoSize = true;
            lbDate.Name = "lbDate";
            txtDate = new C1.Win.C1Input.C1DateEdit();
            txtDate.Font = fEdit;
            txtDate.AllowSpinLoop = false;
            txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDate.Calendar.ArrowColor = System.Drawing.Color.Black;
            txtDate.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            txtDate.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            txtDate.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            txtDate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            txtDate.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            txtDate.Calendar.SelectionForeColor = System.Drawing.Color.White;
            txtDate.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            txtDate.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            txtDate.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            txtDate.Calendar.TodayBorderColor = System.Drawing.Color.White;
            txtDate.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            txtDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            txtDate.Culture = 1054;
            txtDate.CurrentTimeZone = false;
            txtDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            txtDate.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            txtDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            txtDate.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            txtDate.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            txtDate.EmptyAsNull = true;
            txtDate.GMTOffset = System.TimeSpan.Parse("00:00:00");
            txtDate.ImagePadding = new System.Windows.Forms.Padding(0);
            size = ic.MeasureString(lbDate);
            txtDate.Location = new System.Drawing.Point(lbDate.Location.X+ size.Width+10, lbDate.Location.Y);
            txtDate.Name = "txtDate";
            txtDate.Size = new System.Drawing.Size(133, 18);
            txtDate.TabIndex = 510;
            txtDate.Tag = null;
            theme1.SetTheme(this.txtDate, "(default)");
            txtDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            lbPkg = new Label();
            lbPkg.Font = fEdit;
            lbPkg.Name = "lbPkg";
            lbPkg.Text = "Package : ";
            lbPkg.Font = fEdit;
            lbPkg.Location = new System.Drawing.Point(gapX, gapY);
            lbPkg.AutoSize = true;
            cboPkg = new C1ComboBox();
            cboPkg.Font = fEdit;
            cboPkg.Name = "cboPkg";
            size = ic.MeasureString(lbPkg);
            cboPkg.Location = new System.Drawing.Point(lbPkg.Location.X + lbPkg.Width + 20, lbPkg.Location.Y);
            cboPkg.AllowSpinLoop = false;
            cboPkg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboPkg.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            cboPkg.Font = fEdit;
            cboPkg.GapHeight = 0;
            cboPkg.ImagePadding = new System.Windows.Forms.Padding(0);
            cboPkg.ItemsDisplayMember = "";
            cboPkg.ItemsValueMember = "";
            //cboPkg.Location = new System.Drawing.Point(106, 12);
            cboPkg.Size = new System.Drawing.Size(480, 20);
            cboPkg.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            cboPkg.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            cboPkg.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            cboPkg.TabIndex = 538;
            cboPkg.Tag = null;
            theme1.SetTheme(cboPkg, "(default)");
            cboPkg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            lbName = new Label();
            lbName.Font = fEdit;
            lbName.Text = "Name : ";
            lbName.Location = new System.Drawing.Point(gapX, gapY);
            lbName.AutoSize = true;
            lbName.Name = "lbName";
            txtName = new C1TextBox();
            txtName.Font = fEdit;
            txtName.Name = "txtName";
            size = ic.MeasureString(lbName);
            txtName.Location = new System.Drawing.Point(cboPkg.Location.X, lbName.Location.Y);
            txtName.Size = new Size(120, 20);

            gapY += gapLine;
            chkEmbryoFreezing = new C1.Win.C1Input.C1CheckBox();
            chkEmbryoFreezing.Font = fEdit;
            chkEmbryoFreezing.Text = "Embryo freezing ";
            chkEmbryoFreezing.Name = "chkEmbryoFreezing";
            chkEmbryoFreezing.BackColor = System.Drawing.Color.Transparent;
            chkEmbryoFreezing.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkEmbryoFreezing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkEmbryoFreezing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkEmbryoFreezing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkEmbryoFreezing.Location = new System.Drawing.Point(gapX, gapY);
            chkEmbryoFreezing.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkEmbryoFreezing.Size = new System.Drawing.Size(180, 24);
            chkEmbryoFreezing.TabIndex = 553;
            theme1.SetTheme(this.chkEmbryoFreezing, "(default)");
            chkEmbryoFreezing.UseVisualStyleBackColor = true;
            chkEmbryoFreezing.Value = null;
            chkEmbryoFreezing.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkEmbryoFreezing.AutoSize = true;
            txtEmbryoFreezing = new C1TextBox();
            txtEmbryoFreezing.Font = fEdit;
            size = ic.MeasureString(chkEmbryoFreezing);
            txtEmbryoFreezing.Location = new System.Drawing.Point(chkEmbryoFreezing.Location.X + size.Width + 25, chkEmbryoFreezing.Location.Y);
            txtEmbryoFreezing.Size = new Size(40, 20);
            txtEmbryoFreezing.Name = "txtEmbryoFreezing";
            lbEmbryoFreezing = new Label();
            lbEmbryoFreezing.Font = fEdit;
            lbEmbryoFreezing.Text = "embryos ";
            lbEmbryoFreezing.Name = "lbEmbryoFreezing";
            lbEmbryoFreezing.Location = new System.Drawing.Point(txtEmbryoFreezing.Location.X + txtEmbryoFreezing.Width + 5, chkEmbryoFreezing.Location.Y);
            lbEmbryoFreezing.AutoSize = true;
            txtEmbryoStraws = new C1TextBox();
            txtEmbryoStraws.Font = fEdit;
            size = ic.MeasureString(lbEmbryoFreezing);
            txtEmbryoStraws.Location = new System.Drawing.Point(lbEmbryoFreezing.Location.X + size.Width + 15, chkEmbryoFreezing.Location.Y);
            txtEmbryoStraws.Size = new Size(40, 20);
            txtEmbryoStraws.Name = "txtEmbryoStraws";
            lbEmbryoStraws = new Label();
            lbEmbryoStraws.Font = fEdit;
            lbEmbryoStraws.Text = "straws (Extra ";
            lbEmbryoStraws.Name = "lbEmbryoStraws";
            lbEmbryoStraws.Location = new System.Drawing.Point(txtEmbryoStraws.Location.X + txtEmbryoStraws.Width + 5, chkEmbryoFreezing.Location.Y);
            lbEmbryoStraws.AutoSize = true;
            txtEmbryoStrawsExtra = new C1TextBox();
            txtEmbryoStrawsExtra.Font = fEdit;
            size = ic.MeasureString(lbEmbryoStraws);
            txtEmbryoStrawsExtra.Location = new System.Drawing.Point(lbEmbryoStraws.Location.X + size.Width + 5, chkEmbryoFreezing.Location.Y);
            txtEmbryoStrawsExtra.Size = new Size(40, 20);
            lbEmbryoEmbryo = new Label();
            lbEmbryoEmbryo.Font = fEdit;
            lbEmbryoEmbryo.Text = "embryos) ";
            lbEmbryoEmbryo.Name = "lbEmbryoEmbryo";
            lbEmbryoEmbryo.Location = new System.Drawing.Point(txtEmbryoStrawsExtra.Location.X + txtEmbryoStrawsExtra.Width + 5, chkEmbryoFreezing.Location.Y);
            lbEmbryoEmbryo.AutoSize = true;

            gapY += gapLine;
            chkNGS = new C1.Win.C1Input.C1CheckBox();
            chkNGS.Font = fEdit;
            chkNGS.Text = "NGS ";
            chkNGS.Name = "chkNGS";
            chkNGS.BackColor = System.Drawing.Color.Transparent;
            chkNGS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkNGS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkNGS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkNGS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkNGS.Location = new System.Drawing.Point(gapX, gapY);
            chkNGS.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkNGS.Size = new System.Drawing.Size(180, 24);
            chkNGS.TabIndex = 553;
            theme1.SetTheme(this.chkNGS, "(default)");
            chkNGS.UseVisualStyleBackColor = true;
            chkNGS.Value = null;
            chkNGS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            
            txtNGSEmbryo = new C1TextBox();
            txtNGSEmbryo.Font = fEdit;
            size = ic.MeasureString(chkNGS);
            txtNGSEmbryo.Location = new System.Drawing.Point(chkNGS.Location.X + chkNGS.Width, chkNGS.Location.Y);
            txtNGSEmbryo.Size = new Size(60, 20);
            txtNGSEmbryo.Name = "txtNGSEmbryo";
            lbNGSEmbryo = new Label();
            lbNGSEmbryo.Font = fEdit;
            lbNGSEmbryo.Text = "embryo  (Extra ";
            lbNGSEmbryo.Name = "lbNGSEmbryo";
            lbNGSEmbryo.Location = new System.Drawing.Point(txtNGSEmbryo.Location.X + txtNGSEmbryo.Width, chkNGS.Location.Y);
            lbNGSEmbryo.AutoSize = true;
            txtNGSExtra = new C1TextBox();
            txtNGSExtra.Font = fEdit;
            size = ic.MeasureString(lbNGSEmbryo);
            txtNGSExtra.Location = new System.Drawing.Point(lbNGSEmbryo.Location.X + lbNGSEmbryo.Width, chkNGS.Location.Y);
            txtNGSExtra.Size = new Size(60, 20);
            txtNGSExtra.Name = "txtNGSExtra";
            lbNGSExtra = new Label();
            lbNGSExtra.Text = "embryos) ";
            lbNGSExtra.Font = fEdit;
            lbNGSExtra.Location = new System.Drawing.Point(txtNGSExtra.Location.X + txtNGSExtra.Width, chkNGS.Location.Y);
            lbNGSExtra.AutoSize = true;
            lbNGSExtra.Name = "lbNGSExtra";

            gapY += gapLine;
            chkPGS = new C1.Win.C1Input.C1CheckBox();
            chkPGS.BackColor = System.Drawing.Color.Transparent;
            chkPGS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkPGS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkPGS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkPGS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkPGS.Location = new System.Drawing.Point(gapX, gapY);
            chkPGS.Name = "chkPGS";
            chkPGS.Text = "PGS ";
            size = ic.MeasureString(chkPGS);
            chkPGS.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkPGS.Size = new System.Drawing.Size(size.Width+30, 24);
            chkPGS.TabIndex = 553;
            theme1.SetTheme(this.chkPGS, "(default)");
            chkPGS.UseVisualStyleBackColor = true;
            chkPGS.Value = null;
            chkPGS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkPGS.Font = fEdit;
            txtPGSEmbryo = new C1TextBox();
            txtPGSEmbryo.Font = fEdit;
            txtPGSEmbryo.Location = new System.Drawing.Point(chkPGS.Location.X + size.Width+35, chkPGS.Location.Y);
            txtPGSEmbryo.Size = new Size(60, 20);
            txtPGSEmbryo.Name = "txtPGSEmbryo";
            lbPGSEmbryo = new Label();
            lbPGSEmbryo.Font = fEdit;
            lbPGSEmbryo.Name = "lbPGSEmbryo";
            lbPGSEmbryo.Text = "embryo  (Extra ";
            lbPGSEmbryo.Location = new System.Drawing.Point(txtPGSEmbryo.Location.X + txtPGSEmbryo.Width, chkPGS.Location.Y);
            lbPGSEmbryo.AutoSize = true;
            
            txtPGSExtra = new C1TextBox();
            txtPGSExtra.Font = fEdit;
            size = ic.MeasureString(lbPGSEmbryo);
            txtPGSExtra.Location = new System.Drawing.Point(lbPGSEmbryo.Location.X + size.Width, chkPGS.Location.Y);
            txtPGSExtra.Size = new Size(60, 20);
            txtPGSExtra.Name = "txtPGSExtra";
            lbPGSExtra = new Label();
            lbPGSExtra.Font = fEdit;
            lbPGSExtra.Text = "embryos) ";
            lbPGSExtra.Name = "lbPGSExtra";
            lbPGSExtra.Location = new System.Drawing.Point(txtPGSExtra.Location.X + txtPGSExtra.Width, chkPGS.Location.Y);
            lbPGSExtra.AutoSize = true;

            gapY += gapLine;
            chkDay6 = new C1.Win.C1Input.C1CheckBox();
            chkDay6.Font = fEdit;
            chkDay6.Name = "chkPGS";
            chkDay6.Text = "Day 6 ";
            chkDay6.BackColor = System.Drawing.Color.Transparent;
            chkDay6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkDay6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkDay6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkDay6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkDay6.Location = new System.Drawing.Point(gapX, gapY);
            chkDay6.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkDay6.Size = new System.Drawing.Size(180, 24);
            chkDay6.TabIndex = 553;
            theme1.SetTheme(this.chkDay6, "(default)");
            chkDay6.UseVisualStyleBackColor = true;
            chkDay6.Value = null;
            chkDay6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            chkAssistedHatching = new C1.Win.C1Input.C1CheckBox();
            chkAssistedHatching.BackColor = System.Drawing.Color.Transparent;
            chkAssistedHatching.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkAssistedHatching.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkAssistedHatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkAssistedHatching.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkAssistedHatching.Location = new System.Drawing.Point(gapX, gapY);
            chkAssistedHatching.Name = "chkAssistedHatching";
            chkAssistedHatching.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkAssistedHatching.Size = new System.Drawing.Size(180, 24);
            chkAssistedHatching.TabIndex = 553;
            chkAssistedHatching.Text = "Assisted Hatching ";
            theme1.SetTheme(this.chkAssistedHatching, "(default)");
            chkAssistedHatching.UseVisualStyleBackColor = true;
            chkAssistedHatching.Value = null;
            chkAssistedHatching.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkAssistedHatching.Font = fEdit;

            gapY += gapLine;
            chkHA = new C1.Win.C1Input.C1CheckBox();
            chkHA.BackColor = System.Drawing.Color.Transparent;
            chkHA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkHA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkHA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkHA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkHA.Location = new System.Drawing.Point(gapX, gapY);
            chkHA.Name = "chkHA";
            chkHA.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkHA.Size = new System.Drawing.Size(180, 24);
            chkHA.TabIndex = 553;
            chkHA.Text = "HA Assist selection ";
            theme1.SetTheme(this.chkHA, "(default)");
            chkHA.UseVisualStyleBackColor = true;
            chkHA.Value = null;
            chkHA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkHA.Font = fEdit;

            gapY += gapLine;
            chkSpermSelection = new C1.Win.C1Input.C1CheckBox();
            chkSpermSelection.BackColor = System.Drawing.Color.Transparent;
            chkSpermSelection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkSpermSelection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkSpermSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkSpermSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkSpermSelection.Location = new System.Drawing.Point(gapX, gapY);
            chkSpermSelection.Name = "chkSpermSelection";
            chkSpermSelection.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkSpermSelection.Size = new System.Drawing.Size(180, 24);
            chkSpermSelection.TabIndex = 553;
            chkSpermSelection.Text = "Sperm Selection ";
            theme1.SetTheme(this.chkSpermSelection, "(default)");
            chkSpermSelection.UseVisualStyleBackColor = true;
            chkSpermSelection.Value = null;
            chkSpermSelection.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkSpermSelection.Font = fEdit;
            txtSpermSelection = new C1TextBox();
            txtSpermSelection.Font = fEdit;
            size = ic.MeasureString(chkSpermSelection);
            txtSpermSelection.Location = new System.Drawing.Point(chkSpermSelection.Location.X + chkSpermSelection.Width, chkSpermSelection.Location.Y);
            txtSpermSelection.Size = new Size(60, 20);
            txtSpermSelection.Name = "txtSpermSelection";

            gapY += gapLine;
            chkSpermPrecaution = new C1.Win.C1Input.C1CheckBox();
            chkSpermPrecaution.BackColor = System.Drawing.Color.Transparent;
            chkSpermPrecaution.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkSpermPrecaution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkSpermPrecaution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkSpermPrecaution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkSpermPrecaution.Location = new System.Drawing.Point(gapX, gapY);
            chkSpermPrecaution.Name = "chkSpermPrecaution";
            chkSpermPrecaution.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkSpermPrecaution.Size = new System.Drawing.Size(180, 24);
            chkSpermPrecaution.TabIndex = 553;
            chkSpermPrecaution.Text = "Sperm Precaution ";
            theme1.SetTheme(this.chkSpermPrecaution, "(default)");
            chkSpermPrecaution.UseVisualStyleBackColor = true;
            chkSpermPrecaution.Value = null;
            chkSpermPrecaution.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkSpermPrecaution.Font = fEdit;
            txtSpermPrecaution = new C1TextBox();
            txtSpermPrecaution.Font = fEdit;
            size = ic.MeasureString(chkSpermPrecaution);
            txtSpermPrecaution.Location = new System.Drawing.Point(chkSpermPrecaution.Location.X + chkSpermPrecaution.Width, chkSpermPrecaution.Location.Y);
            txtSpermPrecaution.Size = new Size(60, 20);
            txtSpermPrecaution.Name = "txtSpermPrecaution";

            gapY += gapLine;
            chkEmbryoGlue = new C1.Win.C1Input.C1CheckBox();
            chkEmbryoGlue.BackColor = System.Drawing.Color.Transparent;
            chkEmbryoGlue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkEmbryoGlue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkEmbryoGlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkEmbryoGlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkEmbryoGlue.Location = new System.Drawing.Point(gapX, gapY);
            chkEmbryoGlue.Name = "chkEmbryoGlue";
            chkEmbryoGlue.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkEmbryoGlue.Size = new System.Drawing.Size(180, 24);
            chkEmbryoGlue.TabIndex = 553;
            chkEmbryoGlue.Text = "Embryo Glue ";
            theme1.SetTheme(this.chkEmbryoGlue, "(default)");
            chkEmbryoGlue.UseVisualStyleBackColor = true;
            chkEmbryoGlue.Value = null;
            chkEmbryoGlue.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkEmbryoGlue.Font = fEdit;

            gapY += gapLine;
            chkEmbryoRemaining = new C1.Win.C1Input.C1CheckBox();
            chkEmbryoRemaining.BackColor = System.Drawing.Color.Transparent;
            chkEmbryoRemaining.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkEmbryoRemaining.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkEmbryoRemaining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkEmbryoRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkEmbryoRemaining.Location = new System.Drawing.Point(gapX, gapY);
            chkEmbryoRemaining.Name = "chkEmbryoRemaining";
            chkEmbryoRemaining.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkEmbryoRemaining.Size = new System.Drawing.Size(180, 24);
            chkEmbryoRemaining.TabIndex = 553;
            chkEmbryoRemaining.Text = "Embryo Remaining ";
            theme1.SetTheme(this.chkEmbryoRemaining, "(default)");
            chkEmbryoRemaining.UseVisualStyleBackColor = true;
            chkEmbryoRemaining.Value = null;
            chkEmbryoRemaining.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            chkEmbryoRemaining.Font = fEdit;
            txtEmbryoRemaining = new C1TextBox();
            txtEmbryoRemaining.Font = fEdit;
            size = ic.MeasureString(chkSpermPrecaution);
            txtEmbryoRemaining.Location = new System.Drawing.Point(chkEmbryoRemaining.Location.X + chkEmbryoRemaining.Width, chkEmbryoRemaining.Location.Y);
            txtEmbryoRemaining.Size = new Size(60, 20);
            txtEmbryoRemaining.Name = "txtEmbryoRemaining";
            lbEmbryoRemaining = new Label();
            lbEmbryoRemaining.Text = "embryos ";
            lbEmbryoRemaining.Font = fEdit;
            lbEmbryoRemaining.Location = new System.Drawing.Point(txtPGSExtra.Location.X + txtPGSExtra.Width, chkPGS.Location.Y);
            lbEmbryoRemaining.AutoSize = true;
            lbEmbryoRemaining.Name = "lbEmbryoRemaining";

            gapY += gapLine;
            chkDiscardAll = new C1.Win.C1Input.C1CheckBox();
            chkDiscardAll.Font = fEdit;
            chkDiscardAll.Name = "chkDiscardAll";
            chkDiscardAll.Text = "Discard All Embryos ";
            chkDiscardAll.BackColor = System.Drawing.Color.Transparent;
            chkDiscardAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            chkDiscardAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkDiscardAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkDiscardAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chkDiscardAll.Location = new System.Drawing.Point(gapX, gapY);
            chkDiscardAll.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            chkDiscardAll.Size = new System.Drawing.Size(180, 24);
            chkDiscardAll.TabIndex = 553;
            theme1.SetTheme(this.chkDiscardAll, "(default)");
            chkDiscardAll.UseVisualStyleBackColor = true;
            chkDiscardAll.Value = null;
            chkDiscardAll.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            lbStfId = new Label();
            lbStfId.Font = fEdit;
            lbStfId.Name = "lbStfId";
            lbStfId.Text = "Staff : ";
            lbStfId.Location = new System.Drawing.Point(gapX, gapY);
            lbStfId.AutoSize = true;
            cboStfId = new C1ComboBox();
            cboStfId.Font = fEdit;
            size = ic.MeasureString(lbStfId);
            cboStfId.Location = new System.Drawing.Point(cboPkg.Location.X, lbStfId.Location.Y);
            cboStfId.AllowSpinLoop = false;
            cboStfId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboStfId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            cboStfId.Font = fEdit;
            cboStfId.GapHeight = 0;
            cboStfId.ImagePadding = new System.Windows.Forms.Padding(0);
            cboStfId.ItemsDisplayMember = "";
            cboStfId.ItemsValueMember = "";            
            cboStfId.Name = "cboStfId";
            cboStfId.Size = new System.Drawing.Size(180, 20);
            cboStfId.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            cboStfId.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            cboStfId.Style.Font = fEdit;
            cboStfId.TabIndex = 538;
            cboStfId.Tag = null;
            theme1.SetTheme(cboStfId, "(default)");
            cboStfId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            lbChkId = new Label();
            lbChkId.Font = fEdit;
            lbChkId.Text = "Check By : ";
            lbChkId.Name = "lbChkId";
            lbChkId.Location = new System.Drawing.Point(gapX, gapY);
            lbChkId.AutoSize = true;
            cboChkId = new C1ComboBox();
            cboChkId.Font = fEdit;
            cboChkId.Name = "cboChkId";
            size = ic.MeasureString(lbChkId);
            cboChkId.Location = new System.Drawing.Point(cboPkg.Location.X, lbChkId.Location.Y);
            cboChkId.AllowSpinLoop = false;
            cboChkId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboChkId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            cboChkId.Font = fEdit;
            cboChkId.GapHeight = 0;
            cboChkId.ImagePadding = new System.Windows.Forms.Padding(0);
            cboChkId.ItemsDisplayMember = "";
            cboChkId.ItemsValueMember = "";
            cboChkId.Size = new System.Drawing.Size(180, 20);
            cboChkId.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            cboChkId.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            cboChkId.Style.Font = fEdit;
            cboChkId.TabIndex = 538;
            cboChkId.Tag = null;
            theme1.SetTheme(cboChkId, "(default)");
            cboChkId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            gapY += gapLine;
            btnSave = new C1Button();
            btnSave.Font = fEdit;
            btnSave.Name = "btnLisStart";
            btnSave.Text = "Save";
            //size = bc.MeasureString(btnHnSearch);
            btnSave.Location = new System.Drawing.Point(gapX, gapY);
            btnSave.Size = new Size(70, 60);
            btnSave.Font = fEdit;
            btnSave.Image = imgStart;
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;

            //panel1.Controls.Add(chkNGS);
            panel1.Controls.Add(lbDate);
            panel1.Controls.Add(txtDate);
            panel1.Controls.Add(lbPkg);
            panel1.Controls.Add(cboPkg);
            panel1.Controls.Add(lbName);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(chkEmbryoFreezing);
            panel1.Controls.Add(txtEmbryoFreezing);
            panel1.Controls.Add(lbEmbryoFreezing);
            panel1.Controls.Add(txtEmbryoStraws);
            panel1.Controls.Add(lbEmbryoStraws);
            panel1.Controls.Add(txtEmbryoStrawsExtra);
            panel1.Controls.Add(lbEmbryoEmbryo);
            panel1.Controls.Add(chkNGS);
            panel1.Controls.Add(chkPGS);

            //panel1.Controls.Add(lbPGSEmbryo);
            panel1.Controls.Add(txtPGSEmbryo);
            panel1.Controls.Add(lbPGSEmbryo);
            panel1.Controls.Add(txtPGSExtra);
            panel1.Controls.Add(lbPGSExtra);
            panel1.Controls.Add(txtSpermSelection);
            panel1.Controls.Add(txtSpermPrecaution);
            panel1.Controls.Add(txtEmbryoRemaining);
            panel1.Controls.Add(lbEmbryoRemaining);

            panel1.Controls.Add(chkDay6);
            panel1.Controls.Add(chkHA);
            panel1.Controls.Add(chkSpermSelection);
            panel1.Controls.Add(chkSpermPrecaution);
            panel1.Controls.Add(chkEmbryoGlue);
            panel1.Controls.Add(chkEmbryoRemaining);
            panel1.Controls.Add(chkDiscardAll);
            panel1.Controls.Add(lbStfId);
            panel1.Controls.Add(cboStfId);
            panel1.Controls.Add(lbChkId);
            panel1.Controls.Add(cboChkId);
            panel1.Controls.Add(btnSave);
            this.Controls.Add(panel1);
            setTheme();

            panel1.ResumeLayout(false);

            panel1.PerformLayout();
            this.PerformLayout();
        }
        private void setTheme()
        {
            foreach(Control c in this.Controls)
            {
                theme1.SetTheme(c, theme1.Theme);
            }
        }
        private void initConfig()
        {
            labPresc = new LabPrescription();

            this.Load += FrmLabPrescription_Load;
            btnSave.Click += BtnSave_Click;

            ic.ivfDB.oPkgDB.setCboPackage(cboPkg, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboStfId, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboChkId, "");
            setControl();
        }
        private void setControl()
        {
            Boolean chkNew = false;
            labPresc = ic.ivfDB.lPrescDB.selectByPk(id);
            if (labPresc.presc_id.Equals(""))
            {
                labPresc = ic.ivfDB.lPrescDB.selectByOpuFetID(opufetid);
                if (labPresc.presc_id.Equals(""))
                {
                    labPresc = ic.ivfDB.lPrescDB.selectByHN(hn);
                    if (labPresc.presc_id.Equals(""))
                    {
                        chkNew = true;
                    }
                }
            }
            txtID.Value = labPresc.presc_id;
            if (!chkNew)
            {
                opufetid = labPresc.opu_fet_id;
                hn = labPresc.visit_hn;
            }
            txtDate.Value = labPresc.presc_date;
            //cboPkg.SelectedItem labPresc.pkg_id = cboPkg.SelectedItem == null ? "" : ((ComboBoxItem)cboPkg.SelectedItem).Value;
            ic.setC1Combo(cboPkg, labPresc.pkg_id);
            chkEmbryoFreezing.Checked = labPresc.status_embryo_freezing.Equals("1") ? true : false;
            txtEmbryoFreezing.Value = labPresc.embryo_freezing;
            txtEmbryoStraws.Value = labPresc.embryo_straws;
            txtEmbryoStrawsExtra.Value = labPresc.embryo_straws_extra;
            chkNGS.Checked = labPresc.status_ngs.Equals("1") ? true :false;
            txtNGSEmbryo.Value = labPresc.embryo_ngs;
            txtNGSExtra.Value = labPresc.embryo_ngs_extra;
            chkPGS.Checked = labPresc.status_pgs.Equals("1") ? true : false;
            txtPGSEmbryo.Value = labPresc.embryo_pgs;
            txtPGSExtra.Value = labPresc.embryo_pgs_extra;
            chkDay6.Checked = labPresc.status_day6.Equals("1") ? true : false;
            chkAssistedHatching.Checked = labPresc.status_assisted_hatching.Equals("1") ? true : false;
            chkHA.Checked = labPresc.status_ha.Equals("1") ? true : false;
            chkSpermSelection.Checked = labPresc.status_sperm_selection.Equals("1") ? true : false;
            txtSpermSelection.Value = labPresc.sperm_selection;
            chkSpermPrecaution.Checked = labPresc.status_sperm_precaution.Equals("1") ? true : false;
            txtSpermPrecaution.Value = labPresc.sperm_precaution;
            chkEmbryoGlue.Checked = labPresc.status_embryo_glue.Equals("1") ? true : false;
            chkEmbryoRemaining.Checked = labPresc.status_embryo_remaining.Equals("1") ? true : false;
            txtEmbryoRemaining.Value = labPresc.embryo_remaining;
            chkDiscardAll.Checked = labPresc.status_discard_all.Equals("1") ? true : false;
            ic.setC1Combo(cboStfId, labPresc.staff_id);
            ic.setC1Combo(cboChkId, labPresc.checkby_id);
        }
        private void setLabPrescription()
        {

            labPresc.presc_id = txtID.Text;
            labPresc.opu_fet_id = opufetid;
            labPresc.presc_date = ic.datetoDB(txtDate.Text);
            labPresc.visit_hn = hn;
            labPresc.pkg_id = cboPkg.SelectedItem == null ? "" : ((ComboBoxItem)cboPkg.SelectedItem).Value;
            labPresc.status_embryo_freezing = chkEmbryoFreezing.Checked ? "1" : "0";
            labPresc.embryo_freezing = txtEmbryoFreezing.Text.Trim();
            labPresc.embryo_straws = txtEmbryoStraws.Text.Trim();
            labPresc.embryo_straws_extra = txtEmbryoStrawsExtra.Text.Trim();
            labPresc.status_ngs = chkNGS.Checked ? "1" : "0";
            labPresc.embryo_ngs = txtNGSEmbryo.Text.Trim();
            labPresc.embryo_ngs_extra = txtNGSExtra.Text.Trim();
            labPresc.status_pgs = chkPGS.Checked ? "1" : "0";
            labPresc.embryo_pgs = txtPGSEmbryo.Text.Trim();
            labPresc.embryo_pgs_extra = txtPGSExtra.Text.Trim();
            labPresc.status_day6 = chkDay6.Checked ? "1" : "0";
            labPresc.status_assisted_hatching = chkAssistedHatching.Checked ? "1" : "0";
            labPresc.status_ha = chkHA.Checked ? "1" : "0";
            labPresc.status_sperm_selection = chkSpermSelection.Checked ? "1" : "0";
            labPresc.sperm_selection = txtSpermSelection.Text.Trim();
            labPresc.status_sperm_precaution = chkSpermPrecaution.Checked ? "1" : "0";
            labPresc.sperm_precaution = txtSpermPrecaution.Text.Trim();
            labPresc.status_embryo_glue = chkEmbryoGlue.Checked ? "1" : "0";
            labPresc.status_embryo_remaining = chkEmbryoRemaining.Checked ? "1" : "0";
            labPresc.embryo_remaining = txtEmbryoRemaining.Text.Trim();
            labPresc.status_discard_all = chkDiscardAll.Checked ? "1" : "0";
            labPresc.staff_id = cboStfId.SelectedItem == null ? "" : ((ComboBoxItem)cboStfId.SelectedItem).Value;
            labPresc.checkby_id = cboChkId.SelectedItem == null ? "" : ((ComboBoxItem)cboChkId.SelectedItem).Value;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setLabPrescription();
                ic.ivfDB.lPrescDB.insertPrescription(labPresc, ic.cStf.staff_id);
            }
                
        }

        private void FrmLabPrescription_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
    }
}
