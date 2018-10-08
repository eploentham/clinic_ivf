namespace clinic_ivf
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1SuperTooltip2 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            this.c1SuperErrorProvider1 = new C1.Win.C1SuperTooltip.C1SuperErrorProvider(this.components);
            this.c1CommandDock1 = new C1.Win.C1Command.C1CommandDock();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).BeginInit();
            this.c1CommandDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            // 
            // c1SuperTooltip2
            // 
            this.c1SuperTooltip2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip2.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            // 
            // c1SuperErrorProvider1
            // 
            this.c1SuperErrorProvider1.ContainerControl = this;
            this.c1SuperErrorProvider1.ToolTip = this.c1SuperTooltip1;
            // 
            // c1CommandDock1
            // 
            this.c1CommandDock1.Controls.Add(this.c1DockingTab1);
            this.c1CommandDock1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1CommandDock1.Id = 2;
            this.c1CommandDock1.Location = new System.Drawing.Point(0, 0);
            this.c1CommandDock1.Name = "c1CommandDock1";
            this.c1CommandDock1.Size = new System.Drawing.Size(388, 450);
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1DockingTab1.CanAutoHide = true;
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.CanMoveTabs = true;
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.ShowCaption = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(300, 450);
            this.c1DockingTab1.TabIndex = 0;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsSpacing = 5;
            // 
            // c1DockingTabPage1
            // 
            this.c1DockingTabPage1.CaptionVisible = true;
            this.c1DockingTabPage1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(297, 426);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Page1";
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.Location = new System.Drawing.Point(358, 42);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Size = new System.Drawing.Size(100, 18);
            this.c1TextBox1.TabIndex = 1;
            this.c1TextBox1.Tag = null;
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(358, 66);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(75, 23);
            this.c1Button1.TabIndex = 2;
            this.c1Button1.Text = "c1Button1";
            this.c1Button1.UseVisualStyleBackColor = true;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.BackColor = System.Drawing.Color.White;
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this.c1FlexGrid1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.c1FlexGrid1.Location = new System.Drawing.Point(394, 108);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.c1FlexGrid1.Size = new System.Drawing.Size(240, 150);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 4;
            this.c1ThemeController1.SetTheme(this.c1FlexGrid1, "(default)");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.c1TextBox1);
            this.Controls.Add(this.c1CommandDock1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandDock1)).EndInit();
            this.c1CommandDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip2;
        private C1.Win.C1SuperTooltip.C1SuperErrorProvider c1SuperErrorProvider1;
        private C1.Win.C1Command.C1CommandDock c1CommandDock1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private C1.Win.C1Input.C1Button c1Button1;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
    }
}

