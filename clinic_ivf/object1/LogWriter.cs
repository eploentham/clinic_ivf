using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public LogWriter()
        {
            
        }
        private void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                checkLogFile();
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void checkLogFile()
        {
            if (File.Exists(m_exePath + "\\" + "log.txt"))
            {
                long len = new FileInfo(m_exePath + "\\" + "log.txt").Length;
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                if (len > 300000)
                {
                    File.Delete(m_exePath + "\\" + "log.txt");
                    using (StreamWriter sw = File.CreateText(m_exePath + "\\" + "log.txt"))
                    {
                        sw.WriteLine("Log " + System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(m_exePath + "\\" + "log.txt"))
                {
                    sw.WriteLine("Log " + System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                }
            }
        }
        public void WriteLog(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                checkLogFile();
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //txtWriter.Write("\r\nLog Entry : ");
                //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString() + "->" + logMessage);
                //txtWriter.WriteLine("  :");
                //txtWriter.Write("  :{0}", logMessage);
                //txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
