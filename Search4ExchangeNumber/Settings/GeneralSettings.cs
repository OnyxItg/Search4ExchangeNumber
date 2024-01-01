using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - SQL Helper
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class GeneralSettings:XML_Helper
    {
        private static string filePath = Application.StartupPath + "\\Settings\\";
        private static string documentName = "GeneralSettings";

        ///private string templateName = "", key = "", dateFormula = "", identityFormat = "";
        public GeneralSettings()
        {
            
        }
        public static string getMobilePattern()
        {
            return getNodeValue(filePath, documentName, "MobilePattern", "^(09)\\d{8}");
        }
        public static string getCurrentBranch()
        {
            return getNodeValue(filePath, documentName, "CurrentBranch");
        }
        public static string getCurrentBranchName()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentBranch");
            if (ret.Length > 0)
                return ret.Split('|')[1];
            else
                return "";
        }
        public static string getCurrentBranchID()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentBranch");
            if (ret.Length > 0)
                return ret.Split('|')[0];
            else
                return "";
        }
        public static string getCurrentBranchNo()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentBranch");
            //if (ret.Length > 3)
                //return ret.Split('|')[2];
            //else
                return "";
        }
        public static string getCurrentDelivery()
        {
            return getNodeValue(filePath, documentName, "CurrentDelivery");
        }
        public static string getCurrentDeliveryName()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentDelivery");
            if (ret.Length > 0)
                return ret.Split('|')[1];
            else
                return "";
        }
        public static string getCurrentDeliveryID()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentDelivery");
            if (ret.Length > 0)
                return ret.Split('|')[0];
            else
                return null;
        }
        public static string getCurrentDeliveryNo()
        {
            string ret = getNodeValue(filePath, documentName, "CurrentDelivery");
            //if (ret.Length > 0)
                //return ret.Split('|')[2];
            //else
                return null;
        }
        public static int getRound()
        {
            return getNodeValue_Int(filePath, documentName, "Round", 100);
        }
        public static bool getAlwaysOnTop()
        {
            return getNodeValue_Bool(filePath, documentName, "AlwaysOnTop", false);
        }
        public static string getCurrentUser()
        {
            return getNodeValue(filePath, documentName, "CurrentUser");
        }
        public static int getNoticesPerBook()
        {
            return getNodeValue_Int(filePath, documentName, "NoticesPerBook", 25);
        }
        public static void updateNoticesPerBook(int NoticesPerBook)
        {
            if (NoticesPerBook > 0)
                setNodeValue(filePath, documentName, "NoticesPerBook", ""+ NoticesPerBook);
        }
        public static void updateCurrentUser(string CurrentUser)
        {
            if (CurrentUser != "")
                setNodeValue(filePath, documentName, "CurrentUser", CurrentUser);
        }
        public static void updateRound(int Round)
        {
            if (Round > 0)
                setNodeValue(filePath, documentName, "CurrentUser", "" + Round);
        }
        public static void update(string CurrentBranch, string CurrentDelivery)
        {
            if (CurrentBranch != "")
                setNodeValue(filePath, documentName, "CurrentBranch", CurrentBranch);
            if (CurrentDelivery != "")
                setNodeValue(filePath, documentName, "CurrentDelivery", CurrentDelivery);
        }
        public static void update(string CurrentBranch, string CurrentDelivery, string AlwaysOnTop, string CurrentUser, int Round)
        {            
            if (CurrentBranch != "")
                setNodeValue(filePath, documentName, "CurrentBranch", CurrentBranch);
            if (CurrentDelivery != "")
                setNodeValue(filePath, documentName, "CurrentDelivery", CurrentDelivery);
            if (AlwaysOnTop != "")
                setNodeValue(filePath, documentName, "AlwaysOnTop", AlwaysOnTop);
            updateCurrentUser(CurrentUser);
            updateRound(Round);
        }
        public static bool delete()
        {
            document.Load(filePath + documentName + ".xml");
            while(document[documentName].ChildNodes.Count > 0) 
            {
                try
                {
                    XmlNode node = document[documentName].FirstChild;
                    document[documentName].RemoveChild(node);
                }
                catch { }
            }
            document.Save(filePath + documentName + ".xml");
            return true;
        }
        public static bool save(string CurrentBranch, string CurrentDelivery, string AlwaysOnTop, string CurrentUser, string Round)
        { 
            document.Load(filePath + documentName + ".xml");

            XmlNode nodeCurrentBranch = addNode("CurrentBranch", CurrentBranch);
            XmlNode nodeCurrentDelivery = addNode("CurrentDelivery", CurrentDelivery);
            XmlNode nodeAlwaysOnTop = addNode("AlwaysOnTop", AlwaysOnTop);
            XmlNode nodeCurrentUser = addNode("CurrentUser", CurrentUser);
            XmlNode nodeRound = addNode("Round", Round);

            document[documentName].AppendChild(nodeCurrentBranch);
            document[documentName].AppendChild(nodeCurrentDelivery);
            document[documentName].AppendChild(nodeAlwaysOnTop);
            document[documentName].AppendChild(nodeCurrentUser);
            document[documentName].AppendChild(nodeRound);

            document.Save(filePath + documentName + ".xml");
            return true;
        }
    }
}
