using C1.Win.C1Input;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class FDocTypeDB
    {
        public FDocType fdt;
        ConnectDB conn;
        public List<FDocType> lFreezeMedia;
        public List<FDocType> lMethod;
        public List<FDocType> lStage, lStageDay3, lStageDau3Desc1, lStageDay5, lStageDau5Desc1, lFetStage;
        public List<FDocType> lEggstiRt1, lEggstiRt2, lEggstiLt1, lEggstiLt2, lEggstiMedi;
        //public List<FDocType> lFreezeMedia;

        public FDocTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fdt = new FDocType();
            lFreezeMedia = new List<FDocType>();
            lMethod = new List<FDocType>();
            lStage = new List<FDocType>();
            lFetStage = new List<FDocType>();
            lStageDay3 = new List<FDocType>();
            lStageDau3Desc1 = new List<FDocType>();
            lStageDay5 = new List<FDocType>();
            lStageDau5Desc1 = new List<FDocType>();
            lEggstiRt1 = new List<FDocType>();
            lEggstiRt2 = new List<FDocType>();
            lEggstiLt1 = new List<FDocType>();
            lEggstiLt2 = new List<FDocType>();
            lEggstiMedi = new List<FDocType>();
            fdt.doc_type_id = "doc_type_id";
            fdt.doc_type_code = "doc_type_code";
            fdt.doc_type_name = "doc_type_name";
            fdt.active = "active";
            fdt.status_combo = "status_combo";

            fdt.table = "f_doc_type";
            fdt.pkField = "doc_type_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectFETFreezeMedia()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='fet_freeze_media'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUFreezeMedia()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_freeze_media'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectSpermAnalysisNoofVail()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='sperm_analysis_no_of_vail'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectSpermAnalysisWbc()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='sperm_analysis_wbc'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectSpermAnalysisAppearanceNew()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='sperm_analysis_appeairance_new'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectSpermAnalysisAppearance()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='sperm_analysis_appeairance'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUMethod()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt."+fdt.status_combo+ "='opu_method'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStage()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectFETStage()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='fet_stage'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStageDay3()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage_day3'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStageDay3Desc1()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage_day3_desc1'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStageDay5()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage_day5'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStageDay5Desc1()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage_day5_desc1'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectEggStiRt1()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='egg_sti_rt_ovary1'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectEggStiRt2()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='egg_sti_rt_ovary2'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectEggStiMedication()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='egg_sti_medication'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectEggStiMedication2()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='egg_sti_medication2'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.* " +
                "From " + fdt.table + " fdt " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fdt." + fdt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlFETFreezeMedia()
        {
            //lDept = new List<Position>();
            lFreezeMedia.Clear();
            DataTable dt = new DataTable();
            dt = selectFETFreezeMedia();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lFreezeMedia.Add(itm1);
            }
        }
        public void getlFETFreezeStage()
        {
            //lDept = new List<Position>();
            lFreezeMedia.Clear();
            DataTable dt = new DataTable();
            dt = selectFETFreezeMedia();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lFreezeMedia.Add(itm1);
            }
        }
        public void getlOPUFreezeMedia()
        {
            //lDept = new List<Position>();
            lFreezeMedia.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUFreezeMedia();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lFreezeMedia.Add(itm1);
            }
        }
        public void getlOPUMethod()
        {
            //lDept = new List<Position>();
            lMethod.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUMethod();
            //FDocType itm1 = new FDocType();
            //itm1.doc_type_id = "";
            //itm1.doc_type_name = "";

            //lMethod.Add(itm1);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lMethod.Add(itm1);
            }
        }
        public void getlOPUStage()
        {
            //lDept = new List<Position>();
            lStage.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUStage();
            //FDocType itm = new FDocType();
            //itm.doc_type_id = "";
            //itm.doc_type_name = "";
            //lStage.Add(itm);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lStage.Add(itm1);
            }
        }
        public void getlOPUStageDay3()
        {
            //lDept = new List<Position>();
            lStageDay3.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUStageDay3();
            //FDocType itm = new FDocType();
            //itm.doc_type_id = "";
            //itm.doc_type_name = "";
            //lStageDay3.Add(itm);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lStageDay3.Add(itm1);
            }
        }
        public void getlOPUStageDay3Desc1()
        {
            //lDept = new List<Position>();
            lStageDau3Desc1.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUStageDay3Desc1();
            //FDocType itm = new FDocType();
            //itm.doc_type_id = "";
            //itm.doc_type_name = "";
            //lStageDau3Desc1.Add(itm);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lStageDau3Desc1.Add(itm1);
            }
        }
        public void getlOPUStageDay5()
        {
            //lDept = new List<Position>();
            lStageDay5.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUStageDay5();
            //FDocType itm = new FDocType();
            //itm.doc_type_id = "";
            //itm.doc_type_name = "";
            //lStageDay5.Add(itm);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lStageDay5.Add(itm1);
            }
        }
        public void getlOPUStageDay5Desc1()
        {
            //lDept = new List<Position>();
            lStageDau5Desc1.Clear();
            DataTable dt = new DataTable();
            dt = selectOPUStageDay5Desc1();            
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lStageDau5Desc1.Add(itm1);
            }
        }
        public void getlEggStiRt1()
        {
            //lDept = new List<Position>();
            lEggstiRt1.Clear();
            DataTable dt = new DataTable();
            dt = selectEggStiRt1();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lEggstiRt1.Add(itm1);
            }
        }
        public void getlEggStiRt2()
        {
            //lDept = new List<Position>();
            lEggstiRt2.Clear();
            DataTable dt = new DataTable();
            dt = selectEggStiRt2();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lEggstiRt2.Add(itm1);
            }
        }
        public void getlEggStiMedication()
        {
            //lDept = new List<Position>();
            lEggstiMedi.Clear();
            DataTable dt = new DataTable();
            dt = selectEggStiMedication();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lEggstiMedi.Add(itm1);
            }
        }
        public void getlEggStiMedication2()
        {
            //lDept = new List<Position>();
            lEggstiMedi.Clear();
            DataTable dt = new DataTable();
            dt = selectEggStiMedication2();
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lEggstiMedi.Add(itm1);
            }
        }
        public FDocType selectByPk1(String copId)
        {
            FDocType cop1 = new FDocType();
            DataTable dt = new DataTable();
            String sql = "select fdt.* " +
                "From " + fdt.table + " fpf " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fdt." + fdt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFDocType(dt);
            return cop1;
        }
        private FDocType setFDocType(DataTable dt)
        {
            FDocType dept1 = new FDocType();
            if (dt.Rows.Count > 0)
            {
                dept1.doc_type_id = dt.Rows[0][fdt.doc_type_id].ToString();
                dept1.doc_type_code = dt.Rows[0][fdt.doc_type_code].ToString();
                dept1.doc_type_name = dt.Rows[0][fdt.doc_type_name].ToString();
                dept1.active = dt.Rows[0][fdt.active].ToString();
                dept1.status_combo = dt.Rows[0][fdt.status_combo].ToString();
            }
            else
            {
                fdt.doc_type_id = "";
                fdt.doc_type_code = "";
                fdt.doc_type_name = "";
                fdt.active = "";
                fdt.status_combo = "";
            }
            return dept1;
        }
        public C1ComboBox setCboEggStiMedication2(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lEggstiMedi.Count <= 0) getlEggStiMedication2();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lEggstiMedi)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboEggStiMedication(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lEggstiMedi.Count <= 0) getlEggStiMedication();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lEggstiMedi)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboEggStiRtOvary2(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lEggstiRt2.Count <= 0) getlEggStiRt2();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lEggstiRt2)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboEggStiRtOvary1(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lEggstiRt1.Count <= 0) getlEggStiRt1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lEggstiRt1)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }

        public C1ComboBox setCboFETFreezeMedia(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lFreezeMedia.Count <= 0)
            {
                getlFETFreezeMedia();
            }
            //DataTable dt = selectFETFreezeMedia();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (FDocType row in lFreezeMedia)
            {
                item = new ComboBoxItem();
                item.Text = row.doc_type_name;
                item.Value = row.doc_type_id;

                c.Items.Add(item);
            }
            return c;
        }
        public void getlFETStage()
        {
            //lDept = new List<Position>();
            lFetStage.Clear();
            DataTable dt = new DataTable();
            dt = selectFETStage();
            //FDocType itm = new FDocType();
            //itm.doc_type_id = "";
            //itm.doc_type_name = "";
            //lStage.Add(itm);
            foreach (DataRow row in dt.Rows)
            {
                FDocType itm1 = new FDocType();
                itm1.doc_type_id = row[fdt.doc_type_id].ToString();
                itm1.doc_type_name = row[fdt.doc_type_name].ToString();

                lFetStage.Add(itm1);
            }
        }
        public C1ComboBox setCboFETStage(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lFetStage.Count <= 0) getlFETStage();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lFetStage)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboOPUFreezeMedia(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            if (lFreezeMedia.Count <= 0)
            {
                getlOPUFreezeMedia();
            }
            //DataTable dt = selectOPUFreezeMedia();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (FDocType row in lFreezeMedia)
            {
                item = new ComboBoxItem();
                item.Text = row.doc_type_name;
                item.Value = row.doc_type_id;

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSpermAnalysisNoofVail(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectSpermAnalysisNoofVail();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSpermAnalysisWbc(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectSpermAnalysisWbc();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSpermAnalysisAppearanceNew(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectSpermAnalysisAppearanceNew();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSpermAnalysisAppearance(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectSpermAnalysisAppearance();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboOPUMethod(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectOPUMethod();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboOPUStage(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lStage.Count <= 0) getlOPUStage();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lStage)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboOPUStageDay3(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lStageDay3.Count <= 0) getlOPUStageDay3();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lStageDay3)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboOPUStageDay3Desc1(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lStageDau3Desc1.Count <= 0) getlOPUStageDay3Desc1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lStageDau3Desc1)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboOPUStageDay5(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lStageDay5.Count <= 0) getlOPUStageDay5();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lStageDay5)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public C1ComboBox setCboOPUStageDay5Desc1(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectOPUStage();
            if (lStageDau5Desc1.Count <= 0) getlOPUStageDay5Desc1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            int i = 0;
            foreach (FDocType row in lStageDau5Desc1)
            {
                item = new ComboBoxItem();
                item.Value = row.doc_type_id;
                item.Text = row.doc_type_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
    }
}
