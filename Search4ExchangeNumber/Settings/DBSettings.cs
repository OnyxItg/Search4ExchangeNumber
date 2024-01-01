using System.Windows.Forms;
using System.Xml;
using String_Cipher;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - DBSettings
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    public class DBSettings:XML_Helper
    {
        private static string documentName = "DBSettings";
        private static string filePath = Application.StartupPath + "\\Settings\\";

        ///private string templateName = "", key = "", dateFormula = "", identityFormat = "";
        public DBSettings()
        {
            
        }
        public static string getServerName()
        {
            return getNodeValue(filePath, documentName, "ServerName", "localhost");
        }
        public static string getDBName()
        {
            return getNodeValue(filePath, documentName, "DBName");
        }
        public static string getClientsDBName()
        {
            return getNodeValue(filePath, documentName, "DBClientsName");
        }
        public static string getUserName()
        {
            return getNodeValue(filePath, documentName, "UserName", "");
        }
        public static string getBackupDir()
        {
            return getNodeValue(filePath, documentName, "BackupDir");
        }
        public static string getPassword()
        {
            string ret = getNodeValue(filePath, documentName, "Password");
            if (ret != null && ret.Length > 0)
                return StringCipher.Decrypt(ret);
            else
                return "ham19@2012";
        }
        public static bool getIntegratedSecurity()
        {
            string userName = getUserName();
            return (userName == "-1" || userName == "");
        }
        public static bool getLocalPC()
        {
            string serverName = getServerName();
            return (serverName.ToLower() == "localhost");
        }
        public static string getDBPath()
        {
            return getNodeValue(filePath, documentName, "DBPath");
        }
        public static string getConnectionString()
        {
            string userName = getUserName();
            if (userName == "-1" || userName == "")
            {
                return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", getServerName(), getDBName());
            }
            else
            {
                return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                                     getServerName(), getDBName(), userName, getPassword());
            }
        }
        public static string getClientsConnectionString()
        {
            string userName = getUserName();
            if (userName == "-1" || userName == "")
            {
                return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", getServerName(), getClientsDBName());
            }
            else
            {
                return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                                     getServerName(), getClientsDBName(), userName, getPassword());
            }
        }
        public static string getMasterConnectionString()
        {
            string userName = getUserName();
            if (userName == "-1" || userName == "")
            {
                return string.Format("Data Source={0};Initial Catalog=master;Integrated Security=true", getServerName());
            }
            else
            {
                return string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2}",
                                     getServerName(), userName, getPassword());
            }
        }
        private static void setNodeValue(string nodeName, string nodeValue)
        {
            setNodeValue(filePath, documentName, nodeName, nodeValue);
        }
        public static void update(string ServerName, string DBName, string UserName, string Password, string DBPath, string BackupDir)
        {
            if (ServerName != "") setNodeValue("ServerName", ServerName);
            if (DBName != "") setNodeValue("DBName", DBName);
            if (UserName != "") setNodeValue("UserName", UserName);
            if (Password != "") setNodeValue("Password", StringCipher.Encrypt(Password));
            if (DBPath != "") setNodeValue("DBPath()", DBPath);
            if (BackupDir != "") setNodeValue("BackupDir", BackupDir);
        }
        public static void update(string ServerName, string UserName, string Password)
        {
            if (ServerName != "") setNodeValue("ServerName", ServerName);
            if (UserName != "") setNodeValue("UserName", UserName);
            if (Password != "") setNodeValue("Password", StringCipher.Encrypt(Password));
        }
        public static void updateDBName(string DBName)
        {
            setNodeValue("DBName", DBName);
        }
        public static void updateDBClientsName(string DBClientsName)
        {
            setNodeValue("DBClientsName", DBClientsName);
        }
        public static void updateBackupDir(string BackupDir)
        {
            setNodeValue("BackupDir", BackupDir);
        }
    }
}
