using MahClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search4ExchangeNumber
{
    static class Program
    {
        #region Privileges
        public static bool ShowSum4All = false;
        #endregion Privileges

        public static bool firstInstance;
        private static System.Threading.Mutex mutex = null;

        public static Dictionary<string, string> defaultIcons = new Dictionary<string, string> { };

        public static Color bordersColor = Color.FromArgb(210, 37, 100);
        public static Color color1 = Color.FromArgb(210, 37, 100); //red;//(255, 192, 192)
        public static Color color2 = Color.FromArgb(50, 100, 220); //blue;//(192, 220, 220)
        public static Color colorCrossed = Color.FromArgb(100, 220, 255);
        public static Color colorPosted = Color.FromArgb(100, 200, 240);
        public static Color colorConnected = Color.FromArgb(0, 122, 204);
        public static Color colorNotConnected = Color.Red;

        public static Font labelFont = new Font("Times new roman", 16);
        public static Font textboxFont = new Font("Times new roman", 16);
        public static Font datagridFont = new Font("Times new roman", 16);
        public static Size ts = TextRenderer.MeasureText("qQ", Program.datagridFont);

        public static bool RTL = true;
        public static bool isArabic = true;
        public static double WriteSpeed = 0.3;

        public static FormMain formMain;// = new FormMainMDI();
        public static bool ok = true;

        public static bool isDBConnected = false;
        public static bool isDBCustomersConnected = false;
        public static string DBName = "No Database Assigned";
        public static string DBVersion = "1.0";
        public static string user = "عادي";

        public static int NoticeNoLength = 6;

        public static string ID = "",
                             BranchID = GeneralSettings.getCurrentBranchID(),
                             DeliveryID = GeneralSettings.getCurrentDeliveryID(),
                             SourceID = (DeliveryID == null ? GeneralSettings.getCurrentBranchID().ToUpper() :
                                         GeneralSettings.getCurrentDeliveryID().ToUpper()),
                             DestinationID = "", 
                             LoginEmployeeName = "", 
                             LoginEmployeeID = "",
                             LoginEmployment = "";
        internal static bool isServerConnected;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyClass.InitMyClass(RTL, formMain, labelFont, "&نعم", "&لا", "&موافق", "إل&غاء الأمر", "", "", "");

            string[] IDs = new string[23] { "783e473d-a061-ec11-a42a-f8165468411e", "793e473d-a061-ec11-a42a-f8165468411e", "7a3e473d-a061-ec11-a42a-f8165468411e", "7b3e473d-a061-ec11-a42a-f8165468411e", "7c3e473d-a061-ec11-a42a-f8165468411e", "7d3e473d-a061-ec11-a42a-f8165468411e", "7e3e473d-a061-ec11-a42a-f8165468411e", "7f3e473d-a061-ec11-a42a-f8165468411e", "803e473d-a061-ec11-a42a-f8165468411e", "813e473d-a061-ec11-a42a-f8165468411e", "823e473d-a061-ec11-a42a-f8165468411e", "833e473d-a061-ec11-a42a-f8165468411e", "843e473d-a061-ec11-a42a-f8165468411e", "853e473d-a061-ec11-a42a-f8165468411e", "863e473d-a061-ec11-a42a-f8165468411e", "873e473d-a061-ec11-a42a-f8165468411e", "883e473d-a061-ec11-a42a-f8165468411e", "893e473d-a061-ec11-a42a-f8165468411e", "8a3e473d-a061-ec11-a42a-f8165468411e", "8b3e473d-a061-ec11-a42a-f8165468411e", "8c3e473d-a061-ec11-a42a-f8165468411e", "8d3e473d-a061-ec11-a42a-f8165468411e", "8e3e473d-a061-ec11-a42a-f8165468411e" };
            string[] icons = new string[23] { "Envelope", "TankLarg", "TankMedium", "TankSmall", "Bag", "HandBag", "PlasticBox", "ShwalLarg", "ShwalMedium", "ShwalSmall", "CorkBox", "GalonLarg", "GalonMedium", "GalonSmall", "CartoonLarg", "CartoonMedium", "CartoonSmall", "SackLarg", "SackMedium", "Sacksmall", "Laptop", "Mobile1", "Case" };
            for (int i = 0; i < 23; i++)
            {
                defaultIcons.Add(IDs[i], icons[i]);
            }

            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            if (ok)
            {
                formMain = new FormMain();
                Application.Run(formMain);
            }
        }
    }
}
