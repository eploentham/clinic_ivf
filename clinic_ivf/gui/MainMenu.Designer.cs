﻿namespace clinic_ivf.gui
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVisitNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAppn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNurse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReqLab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNurseDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExamiRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReqLabFormA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLabAccept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLabOpu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLabFet = new System.Windows.Forms.ToolStripMenuItem();
            this.ปอนSemenAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ปอนSpermFreexingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTestForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPharmacy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrugPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCashier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCashierDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicalRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicalRecordInit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocGroupScan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocGroupSubScan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicalRecordDocScan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicalRecordView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPosi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.lABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpuProce = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFetProce = new System.Windows.Forms.ToolStripMenuItem();
            this.convertPatientDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCC1 = new C1.Win.C1Command.C1CommandDock();
            this.tC1 = new C1.Win.C1Command.C1DockingTab();
            this.PageS = new C1.Win.C1Command.C1DockingTabPage();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCC1)).BeginInit();
            this.tCC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tC1)).BeginInit();
            this.tC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(161)))), ((int)(((byte)(106)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit,
            this.menuRecept,
            this.menuNurse,
            this.menuLab,
            this.menuPharmacy,
            this.menuCashier,
            this.menuMedicalRecord,
            this.menuInit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.theme1.SetTheme(this.menuStrip1, "BeigeOne");
            // 
            // menuExit
            // 
            this.menuExit.Image = global::clinic_ivf.Properties.Resources.login24;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(53, 20);
            this.menuExit.Text = "Exit";
            // 
            // menuRecept
            // 
            this.menuRecept.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPatient,
            this.menuVisitNew,
            this.menuAppn});
            this.menuRecept.Name = "menuRecept";
            this.menuRecept.Size = new System.Drawing.Size(72, 20);
            this.menuRecept.Text = "Reception";
            // 
            // menuPatient
            // 
            this.menuPatient.Name = "menuPatient";
            this.menuPatient.Size = new System.Drawing.Size(145, 22);
            this.menuPatient.Text = "ประวัติคนไข้";
            // 
            // menuVisitNew
            // 
            this.menuVisitNew.Name = "menuVisitNew";
            this.menuVisitNew.Size = new System.Drawing.Size(145, 22);
            this.menuVisitNew.Text = "ออก Visit";
            // 
            // menuAppn
            // 
            this.menuAppn.Name = "menuAppn";
            this.menuAppn.Size = new System.Drawing.Size(145, 22);
            this.menuAppn.Text = "Appointment";
            // 
            // menuNurse
            // 
            this.menuNurse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReqLab,
            this.menuNurseDefault,
            this.menuExamiRoom,
            this.menuReqLabFormA});
            this.menuNurse.Name = "menuNurse";
            this.menuNurse.Size = new System.Drawing.Size(50, 20);
            this.menuNurse.Text = "Nurse";
            // 
            // menuReqLab
            // 
            this.menuReqLab.Name = "menuReqLab";
            this.menuReqLab.Size = new System.Drawing.Size(182, 22);
            this.menuReqLab.Text = "Request Lab";
            // 
            // menuNurseDefault
            // 
            this.menuNurseDefault.Name = "menuNurseDefault";
            this.menuNurseDefault.Size = new System.Drawing.Size(182, 22);
            this.menuNurseDefault.Text = "Nurse Screen";
            // 
            // menuExamiRoom
            // 
            this.menuExamiRoom.Name = "menuExamiRoom";
            this.menuExamiRoom.Size = new System.Drawing.Size(182, 22);
            this.menuExamiRoom.Text = "Examination Room";
            // 
            // menuReqLabFormA
            // 
            this.menuReqLabFormA.Name = "menuReqLabFormA";
            this.menuReqLabFormA.Size = new System.Drawing.Size(182, 22);
            this.menuReqLabFormA.Text = "Request LAB Form A";
            // 
            // menuLab
            // 
            this.menuLab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLabAccept,
            this.menuLabOpu,
            this.menuLabFet,
            this.ปอนSemenAnalysisToolStripMenuItem,
            this.ปอนSpermFreexingToolStripMenuItem,
            this.menuTestForm});
            this.menuLab.Name = "menuLab";
            this.menuLab.Size = new System.Drawing.Size(40, 20);
            this.menuLab.Text = "LAB";
            // 
            // menuLabAccept
            // 
            this.menuLabAccept.Name = "menuLabAccept";
            this.menuLabAccept.Size = new System.Drawing.Size(179, 22);
            this.menuLabAccept.Text = "Accept Lab";
            // 
            // menuLabOpu
            // 
            this.menuLabOpu.Name = "menuLabOpu";
            this.menuLabOpu.Size = new System.Drawing.Size(179, 22);
            this.menuLabOpu.Text = "ป้อน OPU/FET";
            // 
            // menuLabFet
            // 
            this.menuLabFet.Name = "menuLabFet";
            this.menuLabFet.Size = new System.Drawing.Size(179, 22);
            this.menuLabFet.Text = "ป้อน FET";
            // 
            // ปอนSemenAnalysisToolStripMenuItem
            // 
            this.ปอนSemenAnalysisToolStripMenuItem.Name = "ปอนSemenAnalysisToolStripMenuItem";
            this.ปอนSemenAnalysisToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ปอนSemenAnalysisToolStripMenuItem.Text = "ป้อน Semen Analysis";
            // 
            // ปอนSpermFreexingToolStripMenuItem
            // 
            this.ปอนSpermFreexingToolStripMenuItem.Name = "ปอนSpermFreexingToolStripMenuItem";
            this.ปอนSpermFreexingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ปอนSpermFreexingToolStripMenuItem.Text = "ป้อนSperm Freezing";
            // 
            // menuTestForm
            // 
            this.menuTestForm.Name = "menuTestForm";
            this.menuTestForm.Size = new System.Drawing.Size(179, 22);
            this.menuTestForm.Text = "Test Form";
            // 
            // menuPharmacy
            // 
            this.menuPharmacy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDrugPatient});
            this.menuPharmacy.Name = "menuPharmacy";
            this.menuPharmacy.Size = new System.Drawing.Size(72, 20);
            this.menuPharmacy.Text = "Pharmacy";
            // 
            // menuDrugPatient
            // 
            this.menuDrugPatient.Name = "menuDrugPatient";
            this.menuDrugPatient.Size = new System.Drawing.Size(207, 22);
            this.menuDrugPatient.Text = "ข้อมูลการจ่ายยา  ตามPatient";
            // 
            // menuCashier
            // 
            this.menuCashier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCashierDefault});
            this.menuCashier.Name = "menuCashier";
            this.menuCashier.Size = new System.Drawing.Size(58, 20);
            this.menuCashier.Text = "Cashier";
            // 
            // menuCashierDefault
            // 
            this.menuCashierDefault.Name = "menuCashierDefault";
            this.menuCashierDefault.Size = new System.Drawing.Size(151, 22);
            this.menuCashierDefault.Text = "Cashier Screen";
            // 
            // menuMedicalRecord
            // 
            this.menuMedicalRecord.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMedicalRecordInit,
            this.menuMedicalRecordDocScan,
            this.menuMedicalRecordView});
            this.menuMedicalRecord.Name = "menuMedicalRecord";
            this.menuMedicalRecord.Size = new System.Drawing.Size(66, 20);
            this.menuMedicalRecord.Text = "เวชระเบียน";
            // 
            // menuMedicalRecordInit
            // 
            this.menuMedicalRecordInit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDocGroupScan,
            this.menuDocGroupSubScan});
            this.menuMedicalRecordInit.Name = "menuMedicalRecordInit";
            this.menuMedicalRecordInit.Size = new System.Drawing.Size(238, 22);
            this.menuMedicalRecordInit.Text = "กำหนดค่า";
            // 
            // menuDocGroupScan
            // 
            this.menuDocGroupScan.Name = "menuDocGroupScan";
            this.menuDocGroupScan.Size = new System.Drawing.Size(146, 22);
            this.menuDocGroupScan.Text = "กลุ่มเอกสารหลัก";
            // 
            // menuDocGroupSubScan
            // 
            this.menuDocGroupSubScan.Name = "menuDocGroupSubScan";
            this.menuDocGroupSubScan.Size = new System.Drawing.Size(146, 22);
            this.menuDocGroupSubScan.Text = "กลุ่มเอกสารย่อย";
            // 
            // menuMedicalRecordDocScan
            // 
            this.menuMedicalRecordDocScan.Name = "menuMedicalRecordDocScan";
            this.menuMedicalRecordDocScan.Size = new System.Drawing.Size(238, 22);
            this.menuMedicalRecordDocScan.Text = "Scan เอกสาร เวชระเบียน (scanใหม่)";
            // 
            // menuMedicalRecordView
            // 
            this.menuMedicalRecordView.Name = "menuMedicalRecordView";
            this.menuMedicalRecordView.Size = new System.Drawing.Size(238, 22);
            this.menuMedicalRecordView.Text = "Scan ดูเวชระเบียน";
            // 
            // menuInit
            // 
            this.menuInit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStaff,
            this.menuDept,
            this.menuPosi,
            this.menuPackage,
            this.lABToolStripMenuItem,
            this.convertPatientDonorToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.menuAgent});
            this.menuInit.Name = "menuInit";
            this.menuInit.Size = new System.Drawing.Size(106, 20);
            this.menuInit.Text = "กำหนดค่าโปรแกรม";
            // 
            // menuStaff
            // 
            this.menuStaff.Name = "menuStaff";
            this.menuStaff.Size = new System.Drawing.Size(192, 22);
            this.menuStaff.Text = "รายชื่อพนักงาน";
            // 
            // menuDept
            // 
            this.menuDept.Name = "menuDept";
            this.menuDept.Size = new System.Drawing.Size(192, 22);
            this.menuDept.Text = "แผนก";
            // 
            // menuPosi
            // 
            this.menuPosi.Name = "menuPosi";
            this.menuPosi.Size = new System.Drawing.Size(192, 22);
            this.menuPosi.Text = "ตำแหน่ง";
            // 
            // menuAgent
            // 
            this.menuAgent.Name = "menuAgent";
            this.menuAgent.Size = new System.Drawing.Size(192, 22);
            this.menuAgent.Text = "Agent";
            // 
            // menuPackage
            // 
            this.menuPackage.Name = "menuPackage";
            this.menuPackage.Size = new System.Drawing.Size(192, 22);
            this.menuPackage.Text = "Package";
            // 
            // lABToolStripMenuItem
            // 
            this.lABToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpuProce,
            this.menuFetProce});
            this.lABToolStripMenuItem.Name = "lABToolStripMenuItem";
            this.lABToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.lABToolStripMenuItem.Text = "LAB";
            // 
            // menuOpuProce
            // 
            this.menuOpuProce.Name = "menuOpuProce";
            this.menuOpuProce.Size = new System.Drawing.Size(155, 22);
            this.menuOpuProce.Text = "OPU Procedure";
            // 
            // menuFetProce
            // 
            this.menuFetProce.Name = "menuFetProce";
            this.menuFetProce.Size = new System.Drawing.Size(155, 22);
            this.menuFetProce.Text = "FET Procedure";
            // 
            // convertPatientDonorToolStripMenuItem
            // 
            this.convertPatientDonorToolStripMenuItem.Name = "convertPatientDonorToolStripMenuItem";
            this.convertPatientDonorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.convertPatientDonorToolStripMenuItem.Text = "Convert Patient Donor";
            // 
            // tCC1
            // 
            this.tCC1.Controls.Add(this.tC1);
            this.tCC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCC1.Id = 1;
            this.tCC1.Location = new System.Drawing.Point(0, 24);
            this.tCC1.Name = "tCC1";
            this.tCC1.Size = new System.Drawing.Size(1017, 629);
            // 
            // tC1
            // 
            this.tC1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.tC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC1.CanAutoHide = true;
            this.tC1.CanCloseTabs = true;
            this.tC1.CanMoveTabs = true;
            this.tC1.Controls.Add(this.PageS);
            this.tC1.HotTrack = true;
            this.tC1.Location = new System.Drawing.Point(0, 0);
            this.tC1.Name = "tC1";
            this.tC1.ShowCaption = true;
            this.tC1.Size = new System.Drawing.Size(1017, 629);
            this.tC1.TabIndex = 0;
            this.tC1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC1.TabsShowFocusCues = false;
            this.tC1.TabsSpacing = 2;
            this.tC1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC1, "Office2007Black");
            // 
            // PageS
            // 
            this.PageS.CaptionVisible = true;
            this.PageS.Location = new System.Drawing.Point(1, 1);
            this.PageS.Name = "PageS";
            this.PageS.Size = new System.Drawing.Size(1015, 604);
            this.PageS.TabIndex = 0;
            this.PageS.Text = "Start Page";
            // 
            // theme1
            // 
            this.theme1.Theme = "BeigeOne";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDrug});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // menuDrug
            // 
            this.menuDrug.Name = "menuDrug";
            this.menuDrug.Size = new System.Drawing.Size(180, 22);
            this.menuDrug.Text = "Drug";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 653);
            this.Controls.Add(this.tCC1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCC1)).EndInit();
            this.tCC1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tC1)).EndInit();
            this.tC1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private C1.Win.C1Command.C1CommandDock tCC1;
        private C1.Win.C1Command.C1DockingTab tC1;
        private C1.Win.C1Command.C1DockingTabPage PageS;
        private System.Windows.Forms.ToolStripMenuItem menuLab;
        private System.Windows.Forms.ToolStripMenuItem menuLabOpu;
        private System.Windows.Forms.ToolStripMenuItem menuLabFet;
        private System.Windows.Forms.ToolStripMenuItem ปอนSemenAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ปอนSpermFreexingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuInit;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.ToolStripMenuItem menuStaff;
        private System.Windows.Forms.ToolStripMenuItem menuDept;
        private System.Windows.Forms.ToolStripMenuItem menuPosi;
        private System.Windows.Forms.ToolStripMenuItem lABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpuProce;
        private System.Windows.Forms.ToolStripMenuItem menuFetProce;
        private System.Windows.Forms.ToolStripMenuItem menuTestForm;
        private System.Windows.Forms.ToolStripMenuItem menuNurse;
        private System.Windows.Forms.ToolStripMenuItem menuReqLab;
        private System.Windows.Forms.ToolStripMenuItem menuLabAccept;
        private System.Windows.Forms.ToolStripMenuItem menuRecept;
        private System.Windows.Forms.ToolStripMenuItem menuPatient;
        private System.Windows.Forms.ToolStripMenuItem menuVisitNew;
        private System.Windows.Forms.ToolStripMenuItem convertPatientDonorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAppn;
        private System.Windows.Forms.ToolStripMenuItem menuNurseDefault;
        private System.Windows.Forms.ToolStripMenuItem menuExamiRoom;
        private System.Windows.Forms.ToolStripMenuItem menuPharmacy;
        private System.Windows.Forms.ToolStripMenuItem menuDrugPatient;
        private System.Windows.Forms.ToolStripMenuItem menuReqLabFormA;
        private System.Windows.Forms.ToolStripMenuItem menuCashier;
        private System.Windows.Forms.ToolStripMenuItem menuCashierDefault;
        private System.Windows.Forms.ToolStripMenuItem menuMedicalRecord;
        private System.Windows.Forms.ToolStripMenuItem menuMedicalRecordInit;
        private System.Windows.Forms.ToolStripMenuItem menuMedicalRecordDocScan;
        private System.Windows.Forms.ToolStripMenuItem menuDocGroupScan;
        private System.Windows.Forms.ToolStripMenuItem menuDocGroupSubScan;
        private System.Windows.Forms.ToolStripMenuItem menuMedicalRecordView;
        private System.Windows.Forms.ToolStripMenuItem menuAgent;
        private System.Windows.Forms.ToolStripMenuItem menuPackage;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDrug;
    }
}