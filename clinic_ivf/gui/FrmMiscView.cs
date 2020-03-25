using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmMiscView:Form
    {
        IvfControl ic;
        MainMenu menu;
        C1FlexGrid grfBillD;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        private C1.Win.C1Ribbon.C1StatusBar sb1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        C1ComboBox cboYear;

        Panel panel1, pnHead, pnBotton;
        Label lbCboYear, lbDept;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmMiscView(IvfControl ic, MainMenu m)
        {
            this.ic = ic;
            this.menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            initCompoment();
        }
        private void initCompoment()
        {
            int gapLine = 20, gapX = 20;
            Size size = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;

            theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.sb1 = new C1.Win.C1Ribbon.C1StatusBar();
            panel1 = new System.Windows.Forms.Panel();
            pnHead = new System.Windows.Forms.Panel();
            pnBotton = new System.Windows.Forms.Panel();

            panel1.SuspendLayout();
            pnHead.SuspendLayout();
            pnBotton.SuspendLayout();

            this.SuspendLayout();

            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 0;
            //panel1.BackColor = Color.Brown;
            this.sb1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.sb1.Location = new System.Drawing.Point(0, 620);
            this.sb1.Name = "sb1";
            this.sb1.Size = new System.Drawing.Size(956, 22);
            this.sb1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Blue;
            pnHead.Size = new System.Drawing.Size(scrW, 50);
            pnHead.BorderStyle = BorderStyle.Fixed3D;

            pnBotton.Dock = DockStyle.Fill;
            pnBotton.BorderStyle = BorderStyle.FixedSingle;

            setControlComponent();

            pnHead.Controls.Add(lbCboYear);
            pnHead.Controls.Add(cboYear);

            this.Controls.Add(panel1);
            this.Controls.Add(this.sb1);
            panel1.Controls.Add(pnBotton);
            panel1.Controls.Add(pnHead);

            panel1.ResumeLayout(false);
            pnHead.ResumeLayout(false);
            pnBotton.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void setControlComponent()
        {
            int gapLine = 10, gapX = 20;
            Size size = new Size();
            int scrW = Screen.PrimaryScreen.Bounds.Width;

            lbCboYear = new Label();
            lbCboYear.Text = "...";
            lbCboYear.Font = fEdit;
            lbCboYear.Location = new System.Drawing.Point(gapX, 5);
            lbCboYear.AutoSize = true;
            lbCboYear.Name = "lbCboYear";

            cboYear = new C1.Win.C1Input.C1ComboBox();
            cboYear.AllowSpinLoop = false;
            cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cboYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboYear.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            cboYear.Font = fEdit;
            cboYear.GapHeight = 0;
            cboYear.ImagePadding = new System.Windows.Forms.Padding(0);
            cboYear.ItemsDisplayMember = "";
            cboYear.ItemsValueMember = "";
            size = ic.MeasureString(lbCboYear);
            cboYear.Location = new System.Drawing.Point(lbCboYear.Location.X + size.Width + 5, lbCboYear.Location.Y);
            cboYear.Name = "cboAllergyDesc";
            cboYear.Size = new System.Drawing.Size(331, 20);
            cboYear.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            cboYear.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            cboYear.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            cboYear.TabIndex = 698;
            cboYear.Tag = null;
            theme1.SetTheme(this.cboYear, "(default)");
            cboYear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
        }
    }
}
