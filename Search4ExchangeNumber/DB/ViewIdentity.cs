using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnyxSmartIDReader
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - ViewIdentity
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class ViewIdentity
    {
        SQLHelper sqlIdentity = new SQLHelper();
        DataTable dtIdentity = new DataTable();
        DataRow dataRow = null;
        int rowCount = 0;
        private int _rowIndex = 0;
        private string dbName = "", SchemaName = "", viewName = "View_Identity";

        private string sqlSELECT = "";
        public ViewIdentity()
        {
            
        }
        public void setConnectionString()
        {
            this.dbName = SQLHelper.dbName;
            SchemaName = SQLHelper.identitySchemaName;
            viewName = "View_Identity";// SQLHelper.photosTableName;
            sqlIdentity.SetConnectionString();
            sqlSELECT = "SELECT DISTINCT * "+
                        "FROM [" + dbName + "].[" + SchemaName + "].[" + viewName + "] ";
        }
        public DataTable openTable()
        {
            dtIdentity = sqlIdentity.ExecuteSelect(sqlSELECT);
            dataRow = dtIdentity.Rows[_rowIndex];
            return dtIdentity;
        }
        public DataTable openTable(string whereStatement)
        {
            dtIdentity = sqlIdentity.ExecuteSelect(sqlSELECT+whereStatement);
            return dtIdentity;
        }
        public void setRowIndex(int rowIndex)
        {
            _rowIndex = rowIndex;
        }
        public int getRowIndex()
        {
            return _rowIndex;
        }
        public int getRowCount()
        {
            rowCount = dtIdentity.Rows.Count;
            return rowCount;
        }
        public DataTable search4IdentityNo(string identityNo)
        {
            dtIdentity = openTable(" WHERE [الرقم الوطني]='" + identityNo + "'");//sqlIdentity.ExecuteSelect(sqlSELECT+ " WHERE [IdentityID]='" + ID+"'");
            return dtIdentity;
        }
        public bool IsIdentityIDExist(string identityID)
        {
            return sqlIdentity.IsValueExists("'" + identityID + "'", "[الرقم الوطني]", "[" + dbName + "].[" + SchemaName + "].["+viewName+"]");
        }
        public bool SaveTemplate(string IdentityID, string Template)
        {
            return sqlIdentity.SaveTemplate(IdentityID, Template);
        }
        public bool UpdatePhoto1(string IdentityID, Image Photo1)
        {
            if (Photo1 == null)
                return false;
            return sqlIdentity.updatePhoto(Photo1, "Photo1", IdentityID);
        }
        public bool UpdatePhoto2(string IdentityID, Image Photo2)
        {
            if (Photo2 == null)
                return false;
            return sqlIdentity.updatePhoto(Photo2, "Photo2", IdentityID);
        }
        public bool UpdateFingerprint(string IdentityID, Image Fingerprint)
        {
            if (Fingerprint == null)
                return false;
            return sqlIdentity.updatePhoto(Fingerprint, "Fingerprint", IdentityID);
        }

        public bool UpdateTemplate(string IdentityID, string Template)
        {
            return sqlIdentity.UpdateTemplate(IdentityID, Template);
        }
        public string getFieldByName(string fieldName, string dateFormat)
        {
            //string fieldType = dtIdentity.Rows[_rowIndex][fieldName].GetType().Name.ToString().ToLower();
            if (dtIdentity.Rows.Count > 0)
            {
                if (fieldName.Equals("الاسم الثنائي")) { 
                    return dtIdentity.Rows[_rowIndex]["الاسم"].ToString() + " " + dtIdentity.Rows[_rowIndex]["العائلة"].ToString();
                }else
                if (dtIdentity.Rows[_rowIndex][fieldName].GetType().Name.ToString().ToLower().Equals("datetime"))
                {
                    DateTime dt = (DateTime)(dtIdentity.Rows[_rowIndex][fieldName]);
                    return dt.ToString(dateFormat);
                }
                else {
                    return dtIdentity.Rows[_rowIndex][fieldName].ToString();
                }
            }
            else
                return "";
        }
        public string getFieldByName(string fieldName)
        {
            if (dtIdentity.Rows.Count > 0)
            {
                return dtIdentity.Rows[_rowIndex][fieldName].ToString();
            }
            else
                return "";
        }
        public string getID()
        {
            return getFieldByName("ID");
        }
        public string getIdentityID()
        {
            return getFieldByName("IdentityID");
        }
        private byte[] getPhoto(string fieldName)
        {
            byte[] ret = null;
            if (dtIdentity.Rows.Count > 0)
                try
                {
                    ret = (byte[])dtIdentity.Rows[_rowIndex][fieldName];
                }
                catch { }
            return ret;
        }
        public byte[] getPhoto1()
        {
            return getPhoto("Photo1");
        }
        public byte[] getPhoto2()
        {
            return getPhoto("Photo2");
        }
        public byte[] getPhoto1Thumb()
        {
            return getPhoto("Photo1Thumb");
        }
        public byte[] getPhoto2Thumb()
        {
            return getPhoto("Photo2Thumb");
        }
        public byte[] getFingerprint()
        {
            return getPhoto("Fingerprint");
        }
        public string getFingerprintTemplate()
        {
            return getFieldByName("FingerprintTemplate");
        }
        public bool getBlackList()
        {
            return Convert.ToBoolean(getFieldByName("قائمة سوداء"));
        }
        public string getReason()
        {
            return getFieldByName("السبب");
        }
        public string getIdentityNo()
        {
            return getFieldByName("الرقم الوطني");
        }
        public string getFirstName()
        {
            return getFieldByName("الاسم");
        }
        public string getLastName()
        {
            return getFieldByName("العائلة");
        }
        public string getFatherName()
        {
            return getFieldByName("الأب");
        }
        public string getFullName()
        {
            return getFieldByName("الاسم الثلاثي");
        }
        public string getMotherName()
        {
            return getFieldByName("الأم");
        }
        public DateTime getBirthDate()
        {
            return (DateTime)dtIdentity.Rows[_rowIndex]["تاريخ الولادة"];
        }
        public string getBirthDateString()
        {
            DateTime dt = DateTime.Parse(dtIdentity.Rows[_rowIndex]["تاريخ الولادة"].ToString());
            string res = dt.Year + "/" + dt.Month + "/" + dt.Day;
            return res;
        }
        public string getBirthPlace()
        {
            return getFieldByName("مكان الولادة");
        }
        public string getPhone1()
        {
            return getFieldByName("هاتف1");
        }
        public string getPhone2()
        {
            return getFieldByName("هاتف2");
        }
        public string getNationality()
        {
            return getFieldByName("الجنسية");
        }
        public DateTime getIssueDate()
        {
            if (dtIdentity.Rows[_rowIndex]["تاريخ الإصدار"].ToString() == "")
                return DateTime.Parse("1/1/1900");
            else
                return DateTime.Parse(dtIdentity.Rows[_rowIndex]["تاريخ الإصدار"].ToString());//.ToString();
        }
        public string getIssuePlace()
        {
            return getFieldByName("مكان الإصدار");
        }
        public string getAddress()
        {
            return getFieldByName("العنوان");
        }
        public string getBook()
        {
            return getFieldByName("القيد");
        }
        public string getIsReviewed()
        {
            return getFieldByName("تم تدقيقه");
        }
        public string getManualyAdd()
        {
            return getFieldByName("إضافة يدوية");
        }
        public string getOthersID()
        {
            return getFieldByName("OthersID");
        }
        public string getDocumentName()
        {
            return getFieldByName("DocumentName");
        }
        public byte[] getDocumentPhoto()
        {
            return getPhoto("DocumentPhoto");
        }
        public DateTime getExpireDate()
        {
            if (dtIdentity.Rows[_rowIndex]["ExpireDate"].ToString() == "")
                return DateTime.Parse("1/1/1900");
            else
                return DateTime.Parse(dtIdentity.Rows[_rowIndex]["ExpireDate"].ToString());
        }
        public string getGender()
        {
            return getFieldByName("Gender");
        }
        public bool goNext()
        {
            if (_rowIndex < rowCount - 1)
            {
                ++_rowIndex;
            }
            return (_rowIndex < rowCount-1);
        }
        public bool goPrev()
        {
            if (_rowIndex > 0)
                --_rowIndex;
            return (_rowIndex > 0);
        }
        public void goFirst()
        {
            _rowIndex = 0;
        }
    }
}
