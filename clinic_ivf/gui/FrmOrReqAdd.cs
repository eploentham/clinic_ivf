using C1.Win.C1FlexGrid;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmOrReqAdd : Form
    {
        IvfControl ic;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        OrRequest orreq;
        C1FlexGrid grfReq;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colCode = 2, colName = 3, colCnt = 4;

        public FrmOrReqAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            theme1 = new C1.Win.C1Themes.C1ThemeController();
            theme1.Theme = "Office2013Red";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            orreq = new OrRequest();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            txtReqDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd HH:mm:ss");
            
            //btnReq.Image = Resources.Ticket_24;
            btnSearch.Click += BtnSearch_Click;
            cboFetDay.SelectedIndexChanged += CboFetDay_SelectedIndexChanged;

            initGrfPosi();
            //ic.ivfDB.itmDB.setCboItem(cboLabReq, "");
            //ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");

            //btnSearch.Click += BtnSearch_Click;
            //btnReq.Click += BtnReq_Click;
        }

        private void CboFetDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "";
            id = cboFetDay.SelectedItem == null ? "" : ((ComboBoxItem)cboFetDay.SelectedItem).Value;
            //String deptId = "";
            //deptId = grfReq[e.NewRange.r1, colID] != null ? grfReq[e.NewRange.r1, colID].ToString() : "";
            setGrfPosi(id);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            Patient ptt = new Patient();
            ptt = ic.ivfDB.pttDB.selectByHn(ic.sVsOld.PIDS);
            txtHn.Value = ic.sVsOld.PIDS;
            txtPttNameE.Value = ic.sVsOld.PName;
            txtDob.Value = ic.sVsOld.dob +"["+ ptt.AgeStringShort()+"]";
        }
        private void initGrfPosi()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfReq.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel5.Controls.Add(this.grfReq);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfReq, theme);
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfReq[e.NewRange.r1, colID] != null ? grfReq[e.NewRange.r1, colID].ToString() : "";
            setGrfPosi(deptId);
            //setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void setGrfPosi(String id)
        {
            //grfDept.Rows.Count = 7;

            grfReq.DataSource = ic.ivfDB.ordDB.selectByGroup1(id);
            grfReq.Cols.Count = colCnt;

            grfReq.Cols[colID].Width = 80;

            grfReq.Cols[colCode].Width = 80;
            grfReq.Cols[colName].Width = 300;

            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colCode].Caption = "รหัส";
            grfReq.Cols[colName].Caption = "ชื่อ Diagnosis ";

            for (int i = 1; i < grfReq.Rows.Count; i++)
            {
                grfReq[i, 0] = i;
                if (i % 2 == 0)
                    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfReq.Cols[colID].Visible = false;
            //grfAgn.Cols[colE].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmOrReqAdd_Load(object sender, EventArgs e)
        {
            ic.ivfDB.ordgDB.setC1CboDiagGroup(cboFetDay);
        }
    }
}
