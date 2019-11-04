using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.object1
{
    public class IniFile
    {
        FileIniDataParser parser;
        IniData data;
        public IniFile(String filename)
        {
            parser = new FileIniDataParser();
            parser.Parser.Configuration.CommentString = "#";
            //MessageBox.Show("00221 " + filename, "");
            if (File.Exists(filename))
            {
                //MessageBox.Show("002211 " + filename, "");
                data = parser.ReadFile(filename);
                //MessageBox.Show("00222 " + filename, "");
            }
            else
            {
                //MessageBox.Show("002223 " + filename, "");
            }
        }
        public String getIni(String section, String node)
        {
            string ret = data[section][node];
            return ret;
        }
        public void setIni(String section, String node, String value)
        {
            data[section][node] = value;
            parser.WriteFile(section, data);
        }
    }
}
