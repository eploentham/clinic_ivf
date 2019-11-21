using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class ASCII
    {
        String NUL = ((char)1).ToString();      //Null                          HEX 
        String STX = ((char)2).ToString();      //Start Text                    HEX 02
        String ETX = ((char)3).ToString();      //End Text                      HEX 03
        String EOT = ((char)4).ToString();      // End of Transmission          HEX 04
        String ENQ = ((char)5).ToString();      // Inquiry                      HEX 05
        String ACK = ((char)6).ToString();      // Acknowledge                  HEX 06
        String NAK = ((char)21).ToString();      // Not Acknowledged             HEX 15
        String ETB = ((char)23).ToString();     // End of Transmission Block    HEX 17
        String CR = ((char)13).ToString();      // Carriage Return              HEX 0D
        String LF = ((char)10).ToString();      // Line Feed                    HEX 0A
        String caret = ((char)94).ToString();      // Line Feed                 HEX 5E
        String vBar = ((char)124).ToString();      // Line Feed                 HEX 7C
    }
}
