using clinic_ivf.object1;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.objdb
{
    public class ConnectDB
    {
        public MySqlConnection connIm, connEx, conn;
        public MySqlConnection connNoClose;
        public OleDbConnection connA = new OleDbConnection();

        MySqlCommand comNoClose = new MySqlCommand();

        public long _rowsAffected = 0;
        private InitConfig initC;
        public Staff user;
        public String _IPAddress = "";
        //public SqlCommand comStore;

        public ConnectDB(InitConfig initc)
        {
            conn = new MySqlConnection();
            connIm = new MySqlConnection();
            connEx = new MySqlConnection();
            connNoClose = new MySqlConnection();

            conn.ConnectionString = "Server=" + initc.hostDB + ";Database=" + initc.nameDB + ";Uid=" + initc.userDB + ";Pwd=" + initc.passDB +
                ";port = " + initc.portDB + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connNoClose.ConnectionString = "Server=" + initc.hostDB + ";Database=" + initc.nameDB + ";Uid=" + initc.userDB + ";Pwd=" + initc.passDB +
                ";port = " + initc.portDB + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connIm.ConnectionString = "Server=" + initc.hostDBIm + ";Database=" + initc.nameDBIm + ";Uid=" + initc.userDBIm + ";Pwd=" + initc.passDBIm +
                ";port = " + initc.portDBIm + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            connEx.ConnectionString = "Server=" + initc.hostDBEx + ";Database=" + initc.nameDBEx + ";Uid=" + initc.userDBEx + ";Pwd=" + initc.passDBEx +
                ";port = " + initc.portDBEx + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none; convert zero datetime=True; ";
            user = new Staff();
        }
        public ConnectDB(String pathSSO)
        {
            String flag = CheckOfficeVersionAccess();
            connA = new OleDbConnection();
            //_mainConnection.ConnectionString = GetConfig("Main.ConnectionString");
            if (flag.Equals("32"))
            {
                connA.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathSSO + ";Persist Security Info=False";
            }
            else if (flag.Equals("64"))
            {
                connA.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathSSO + ";Persist Security Info=False";
            }

            //_mainConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\\source\reportBangna\\reportBangna\\DataBase\\reportBangna.mdb;Persist Security Info=False";
            //_isDisposed = false;
        }
        public DataTable selectData(MySqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comMainhis);
            try
            {
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("HResult " + ex.HResult + "\n" + "Message" + ex.Message + "\n" + sql, "Error");
                if (con.State == ConnectionState.Open)
                {
                    //con.Close();
                }
                throw new Exception(ex.Message, ex);
                
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public DataSet selectDataDS(MySqlConnection con, String sql)
        {
            DataSet toReturn = new DataSet();

            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comMainhis);
            try
            {
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("HResult " + ex.HResult + "\n" + "Message" + ex.Message + "\n" + sql, "Error");
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public DataTable selectDataA(OleDbConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            OleDbCommand comMainhis = new OleDbCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
            OleDbDataAdapter adapMainhis = new OleDbDataAdapter(comMainhis);
            try
            {
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public DataTable selectDataNoClose(String sql)
        {
            DataTable toReturn = new DataTable();

            comNoClose.CommandText = sql;
            comNoClose.CommandType = CommandType.Text;
            comNoClose.Connection = connNoClose;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comNoClose);
            try
            {
                //con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //con.Close();
                //comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public String ExecuteNonQuery(MySqlConnection con, String sql)
        {
            String toReturn = "";

            MySqlCommand com = new MySqlCommand();
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            try
            {
                con.Open();
                _rowsAffected = com.ExecuteNonQuery();
                //_rowsAffected = (int)com.ExecuteScalar();
                toReturn = sql.Substring(0, 1).ToLower() == "i" ? com.LastInsertedId.ToString() : _rowsAffected.ToString();
                if (sql.IndexOf("Insert Into Visit")>=0)        //old program
                {
                    toReturn = _rowsAffected.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                con.Close();
                com.Dispose();
            }

            return toReturn;
        }
        public String ExecuteNonQueryNoClose(String sql)
        {
            String toReturn = "";
            comNoClose.CommandText = sql;
            comNoClose.CommandType = CommandType.Text;
            comNoClose.Connection = connNoClose;
            try
            {
                //connMainHIS.Open();
                //_rowsAffected = comMainhisNoClose.ExecuteNonQuery();
                var aaa = comNoClose.ExecuteNonQuery();
                //toReturn = aaa.ToString();
                toReturn = sql.Substring(0, 1).ToLower() == "i" ? comNoClose.LastInsertedId.ToString() : _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }
            return toReturn;
        }
        public String OpenConnectionNoClose()
        {
            String toReturn = "";
            try
            {
                connNoClose.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }
            return toReturn;
        }
        public String OpenConnection()
        {
            String toReturn = "";
            try
            {
                conn.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnection()
        {
            conn.Close();
        }
        public void CloseConnectionNoClose()
        {
            connNoClose.Close();
        }
        public String OpenConnectionEx()
        {
            String toReturn = "";
            try
            {
                connEx.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnectionEx()
        {
            connEx.Close();
        }
        public String OpenConnectionIm()
        {
            String toReturn = "";
            try
            {
                connIm.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public String TestOpenConnectionA(String pathA, String flag)
        {
            String toReturn = "";
            try
            {
                toReturn = OpenConnectionA(pathA, flag);
                OleDbConnection con = new OleDbConnection(toReturn);
                con.Open();
                toReturn = "ok";
                con.Close();
            }
            catch (Exception ex)
            {
                toReturn = ex.Message;
                //throw new Exception("ExecuteNonQuery::Error occured.", ex);                
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public String OpenConnectionA(String pathA)
        {
            String toReturn = "";
            String flag = CheckOfficeVersionAccess();
            connA = new OleDbConnection();
            //_mainConnection.ConnectionString = GetConfig("Main.ConnectionString");
            if (flag.IndexOf("32") >= 0)
            {
                connA.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathA + ";Persist Security Info=False";
            }
            else if (flag.IndexOf("64") >= 0)
            {
                String[] aa = flag.Split('|');
                if (aa.Length > 0)
                {
                    connA.ConnectionString = "Provider=Microsoft.ACE.OLEDB." + aa[1] + "; Data Source=" + pathA + ";Persist Security Info=False";
                    connA.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathA + ";Persist Security Info=False";
                }
                else
                {
                    connA.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathA + ";Persist Security Info=False";
                }

            }
            try
            {
                //connA.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public String OpenConnectionA(String pathA, String flag)
        {
            String toReturn = "";

            connA = new OleDbConnection();
            //_mainConnection.ConnectionString = GetConfig("Main.ConnectionString");
            if (flag.IndexOf("32") >= 0)
            {
                toReturn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathA + ";Persist Security Info=False";
                connA.ConnectionString = toReturn;
            }
            else if (flag.IndexOf("64") >= 0)
            {
                String flag1 = CheckOfficeVersionAccess();
                String[] aa = flag1.Split('|');
                if (aa.Length > 0)
                {
                    toReturn = "Provider=Microsoft.ACE.OLEDB." + aa[1] + "; Data Source=" + pathA + ";Persist Security Info=False";
                    toReturn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathA + ";Persist Security Info=False";
                    connA.ConnectionString = toReturn;
                }
                else
                {
                    connA.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathA + ";Persist Security Info=False";
                }

            }
            try
            {
                //connA.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                toReturn = ex.Message;
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnectionIm()
        {
            connIm.Close();
        }
        public void CloseConnectionA()
        {
            connA.Close();
        }
        private static string CheckOfficeVersionAccess()
        {
            string ret = "";

            string keyName = "";
            string value = "", ver = "";
            List<string> versions = new List<string>();
            versions.Add("12.0");//Office 2007
            versions.Add("14.0");//Office 2010
            versions.Add("15.0");//Office 2013
            versions.Add("16.0");//Office 2016

            foreach (string version in versions)
            {
                keyName = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Office\" + version + @"\Outlook";
                value = (string)Registry.GetValue(keyName, "Bitness", "Does not exist");
                ver = version;
                if (value != "Does not exist" && value != null)
                    break;
            }

            if (value != "Does not exist" && value != null)
            {
                ret = value + "|" + ver;
            }

            return ret;
        }
        public String dateMiotoDB(String date)
        {
            String re = "";
            if (date.Length > 8)
            {
                re = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(date.Length - 2);
            }
            return re;
        }
    }
}
