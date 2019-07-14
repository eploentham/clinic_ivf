using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class InitConfig
    {
        public String hostDB = "", userDB = "", passDB = "", nameDB = "", portDB = "";
        public String hostDBEx = "", userDBEx = "", passDBEx = "", nameDBEx = "", portDBEx = "";
        public String hostDBIm = "", userDBIm = "", passDBIm = "", nameDBIm = "", portDBIm = "";
        public String hostFTP = "", userFTP = "", passFTP = "", portFTP = "", pathImageScan = "", folderFTP="", usePassiveFTP="";

        public String grdViewFontSize = "", grdViewFontName = "", themeApplication = "", txtFocus = "", grfRowColor = "", grfRowGreen = "", grfRowRed = "", grfRowYellow = "";

        public String sticker_donor_width = "", sticker_donor_height = "", sticker_donor_start_x = "", sticker_donor_start_y = "", sticker_donor_barcode_height = "", sticker_donor_barcode_gap_x = "", sticker_donor_barcode_gap_y = "", sticker_donor_gap="";
        public String statusAppDonor = "", patientaddpanel1weight="", barcode_width_minus="", status_show_border="";
        public String themeDonor = "",themeDonor1 = "", printStickerLeft="", printStickerRight = "", printStickerTop = "", printerSticker="", printerBill="", printerAppointment="", printerA4="";
        public String timerlabreqaccept = "", timerImgScanNew="", creditCharge="", service_point_id="", statusCheckDonor="",pathSaveExcelAppointment="";

        public String email_form = "", email_auth_user = "", email_auth_pass = "", email_port = "", email_ssl = "", email_to_sperm_freezing="";
    }
}
