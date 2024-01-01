using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MahClass;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - BarcodeSettings
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    public class XML_Helper
    {
        public static XmlDocument document = new XmlDocument();        
        ///private string templateName = "", key = "", dateFormula = "", identityFormat = "";
        public XML_Helper()
        {
            
        }
        public static string saveXML2Table(XmlDocument document, string xmlManinNode, string[] xmlNodesNames, SqlDbType[] fieldTypes)
        {
            string data = "";
            try
            {
                XmlNodeList xmlData = document.GetElementsByTagName(xmlManinNode);
                for (int i = 0; i < xmlData.Count; ++i)
                {
                    data += "(";
                    for (int j = 0; j < xmlNodesNames.Length; j++)
                    {
                        string s = xmlData[i][xmlNodesNames[j]].InnerText;
                        if (s == "") s = "NULL";
                        if (fieldTypes[j] != SqlDbType.Int && fieldTypes[j] != SqlDbType.Bit && s != "NULL") data += "N'";
                        data += s;
                        if (fieldTypes[j] != SqlDbType.Int && fieldTypes[j] != SqlDbType.Bit && s != "NULL") data += "'";
                        data += ",";
                    }
                    data = data.Trim(',') + "),";
                }
            }
            catch
            { }
            return data.Trim(',');
        }
        public static string saveXML2Table_ByID(XmlDocument document, string xmlMainNode, string id, string[] xmlNodesNames, SqlDbType[] fieldTypes)
        {
            string data = "";
            try
            {
                XmlNodeList xmlData = document.GetElementsByTagName(xmlMainNode);
                //string b = document.DocumentElement.SelectSingleNode("descendant::dt:data[dt:mobile/dt:id='2']").InnerText;
                for (int i = 0; i < xmlData.Count; ++i)
                {
                    string v = xmlData[i].ChildNodes[0].InnerText;
                    if (v == id)
                    {
                        XmlNodeList xmlNodeList = xmlData[i].SelectNodes("orders");
                        for (int k = 0; k < xmlNodeList.Count; k++)
                        {
                            data += "(NEWID(), ";
                            for (int j = 0; j < xmlNodesNames.Length; j++)
                            {
                                string s = xmlNodeList[k][xmlNodesNames[j]].InnerText;
                                if (s == "") s = "NULL";
                                if (fieldTypes[j] != SqlDbType.Int && fieldTypes[j] != SqlDbType.Bit && s != "NULL") data += "'";
                                data += s;
                                if (fieldTypes[j] != SqlDbType.Int && fieldTypes[j] != SqlDbType.Bit && s != "NULL") data += "'";
                                data += ",";
                            }
                            data = data + id + "),";
                        }
                    }
                }
            }
            catch
            { }
            return data.Trim(',');
        }
        public static string getXML_Field(XmlDocument document, string xmlManinNode, string xmlNodeName)
        {
            string data = "";/// document.GetElementById(xmlNodeName).InnerText;
            try
            {
                XmlNodeList xmlData = document.GetElementsByTagName(xmlManinNode);
                for (int i = 0; i < xmlData.Count; ++i)
                {
                    string s = xmlData[i][xmlNodeName].InnerText;
                    data += s + "|";
                }
            }
            catch
            {
                return "";
            }
            return data.Trim('|');
        }
        public static string getNodeValue(XmlDocument document, string xmlManinNode, string nodeName)
        {
            try
            {
                XmlNode node = document["Root"][xmlManinNode][nodeName];
                if (node != null)
                {
                    return node.InnerText;
                }
            }
            catch (Exception ex) { MyClass.Exception2LogFile("XML_Helper", "getNodeValue", ex); }
            return "";
        }
        public static string getNodeValue(string filePath, string documentName, string nodeName, bool exitApplication)
        {
            string fileName = filePath + documentName + ".xml";
            if (File.Exists(fileName))
            {
                try
                {
                    document.Load(fileName);
                    XmlNode node = document[documentName][nodeName];
                    if (node != null)
                    {
                        return node.InnerText;
                    }
                }
                catch (Exception ex) { MyClass.Exception2LogFile("XML_Helper", "getNodeValue", ex); }
            }
            else if (exitApplication)
            {
                MessageBox.Show("هناك بعض الملفات المفقودة الرجاء إعادة تثبيت البرنامج.");
                Application.ExitThread();
                Application.Exit();
            }
            return "";
        }
        public static string getNodeValue(string filePath, string documentName, string nodeName, string defaultValue)
        {
            string ret = getNodeValue(filePath, documentName, nodeName, false);
            if (ret.Length > 0)
                return ret;
            else
                return defaultValue;
        }
        public static string getNodeValue(string filePath, string documentName, string nodeName)
        {
            string ret = getNodeValue(filePath, documentName, nodeName, true);
            if (ret.Length > 0)
                return ret;
            else
                return "";
        }
        public static int getNodeValue_Int(string filePath, string documentName, string nodeName, int defaultValue)
        {
            string ret = getNodeValue(filePath, documentName, nodeName, false);
            try
            {
                return Convert.ToInt32(ret);
            }
            catch { }
            return defaultValue;
        }
        public static bool getNodeValue_Bool(string filePath, string documentName, string nodeName, bool defaultValue)
        {
            string ret = getNodeValue(filePath, documentName, nodeName, false).ToLower();
            try
            {
                return Convert.ToBoolean(ret);
            }
            catch { return defaultValue; }
        }
        public static bool setNodeValue(string filePath, string documentName, string nodeName, string nodeValue)
        {
            string fileName = filePath + documentName + ".xml";
            if (File.Exists(fileName))
            {
                try
                {
                    document.Load(fileName);
                    XmlNode node = document[documentName][nodeName];
                    if (node != null)
                    {
                        node.InnerText = nodeValue;
                    }
                    else
                    {
                        document[documentName].AppendChild(addNode(nodeName, nodeValue));
                    }
                    document.Save(fileName);
                    return true;
                }
                catch (Exception ex) { MyClass.Exception2LogFile("", "", ex); }
            }
            else
            {
                MessageBox.Show("هناك بعض الملفات المفقودة الرجاء إعادة تثبيت البرنامج.");
                Application.ExitThread();
                Application.Exit();
            }
            return false;
        }
        public static bool setNodesValues(string filePath, string documentName, string[] nodesNames, string[] nodesValues)
        {
            string fileName = filePath + documentName + ".xml";
            if (File.Exists(fileName))
            {
                try
                {
                    document.Load(fileName);
                    for (int i = 0; i < nodesNames.Length; i++)
                    {
                        XmlNode node = document[documentName][nodesNames[i]];
                        if (node != null)
                        {
                            node.InnerText = nodesValues[i];
                        }
                    }
                    document.Save(fileName);
                    return true;
                }
                catch (Exception ex) { MyClass.Exception2LogFile("", "", ex); }
            }
            else
            {
                MessageBox.Show("هناك بعض الملفات المفقودة الرجاء إعادة تثبيت البرنامج.");
                Application.ExitThread();
                Application.Exit();
            }
            return false;
        }
        public static bool delete(string documentName)
        {
            string fileName = Application.StartupPath + "\\Settings\\" + documentName + ".xml";
            document.Load(fileName);
            while(document[documentName].ChildNodes.Count > 0) 
            {
                try
                {
                    XmlNode node = document[documentName].FirstChild;
                    document[documentName].RemoveChild(node);
                }
                catch (Exception ex){ MyClass.Exception2LogFile("XML_Helper", string.Format("delete()"), ex); }
            }
            document.Save(fileName);
            return true;
        }
        public static XmlNode addNode(string nodeName, string nodeInnerText)
        {
            XmlNode node = document.CreateElement(nodeName);
            XmlNode nodeText = document.CreateTextNode(nodeInnerText);
            node.AppendChild(nodeText);
            return node;
        }
    }
}
