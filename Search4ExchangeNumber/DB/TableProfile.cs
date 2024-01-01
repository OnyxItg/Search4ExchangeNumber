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
    //  Class           - TableProfile
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class TableProfile
    {
        SQLHelper sqlProfile = new SQLHelper();
        DataTable dtProfile  = new DataTable();
        //DataRow dataRow = null;
        int rowCount = 0;
        private int _rowIndex = 0;
        private string dbName = "", SchemaName = "", tableName = "Profile";
        private string[] fieldsName = {
                                    };
        private string sqlSELECT = "";
        public TableProfile()
        {
            
        }
        public void setConnectionString()
        {
            this.dbName = SQLHelper.dbName;
            SchemaName = SQLHelper.identitySchemaName;
            tableName = SQLHelper.ProfileTableName;
            sqlProfile.SetConnectionString();
            sqlSELECT = "SELECT " +
                        "[ID]                     " + //0
                        ",[ProfileName]           " + //1
                        ",[EmptyFields]           " + //2
                        ",[ClearPrevValues]       " + //3
                        ",[ShortcutModifier]      " + //4 
                        ",[ShortcutKeys]          " + //5 
                        ",[SyrianNationalIDFormat]" + //6 
                        ",[DateFormat]            " + //7 
                        ",[ISDefault]             " + //8
                        "FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "] "; 
        }
        public DataTable openTable()
        {
            dtProfile = sqlProfile.ExecuteSelect(sqlSELECT);
            //dataRow = dtProfile.Rows[_rowIndex];
            return dtProfile;
        }
        public DataTable openTable(string whereStatement)
        {
            dtProfile = sqlProfile.ExecuteSelect(sqlSELECT+whereStatement);
            return dtProfile;
        }
        public int getRowCount()
        {
            rowCount = dtProfile.Rows.Count;
            return rowCount;
        }
        public DataTable search4Profile(string profileName)
        {
            dtProfile = openTable(" WHERE [ProfileName]=" + profileName + "");//sqlIdentity.ExecuteSelect(sqlSELECT+ " WHERE [IdentityID]='" + ID+"'");
            return dtProfile;
        }
        public bool IsIdentityIDExist(string identityID)
        {
            return sqlProfile.IsValueExists("'" + identityID + "'", "[IdentityID]", "[" + dbName + "].[" + SchemaName + "].[" + tableName + "]");
        }
        public bool AddProfile(string ProfileName, bool EmptyFields, bool ClearPrevVaues, string ShortcutModifier, string ShortcutKeys, 
                               string SyrianNationalIDFormula, string DateFormula)
        {
            Guid guid = Guid.NewGuid();
            string ID = guid.ToString();
            return sqlProfile.ExecuteInsert_Update(
                      "INSERT INTO [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                      "([ID]                     " +
                      ",[ProfileName]            " +
                      ",[EmptyFields]            " +
                      ",[ClearPrevValues]        " +
                      ",[ShortcutModifier]       " +
                      ",[ShortcutKeys]           " +
                      ",[SyrianNationalIDFormat] " +
                      ",[DateFormat]             " +
                      ",[IsDefault]             )" +
                      "VALUES('" + ID + "', '" + ProfileName + "', '" + Convert.ToByte(EmptyFields) + "', '" + Convert.ToByte(ClearPrevVaues) + "', '" +
                                   ShortcutModifier + "', '" + ShortcutKeys + "', '" +
                                   SyrianNationalIDFormula + "', '" + DateFormula + "', 0)");
        }
        public bool UpdateProfile(string OldProfileName, string NewProfileName, bool EmptyFields, bool ClearPrevVaues, 
                                  string ShortcutModifier, string ShortcutKeys,
                                  string SyrianNationalIDFormula, string DateFormula)
        {
            return sqlProfile.ExecuteInsert_Update(
                      "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] SET " +
                      "  [ProfileName]            = '" + NewProfileName +
                      "',[EmptyFields]            = " + Convert.ToByte(EmptyFields) +
                      ",[ClearPrevValues]        = " + Convert.ToByte(ClearPrevVaues) +
                      " ,[ShortcutModifier]       = '" + ShortcutModifier +
                      "',[ShortcutKeys]           = '" + ShortcutKeys +
                      "',[SyrianNationalIDFormat] = '" + SyrianNationalIDFormula +
                      "',[DateFormat]             = '" +  DateFormula + "'" +
                      " WHERE [ProfileName] = '"+ OldProfileName +"'");
        }
        public bool DeleteProfile(string ProfileName)
        {
            return sqlProfile.ExecuteInsert_Update(
                      "DELETE FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "]  " +
                      " WHERE [ProfileName] = '" + ProfileName + "'");
        }
        public bool FillProfiles()
        {
            bool ret = AddProfile("صورة هوية1", true, true, "", "D1", "", "M/d/yyyy");
            ret &= AddProfile("صورة هوية2", true, true, "", "D2", "", "M/d/yyyy");
            //ret &= AddProfile("", true, "", "", "", "");
            return ret;
        }
        public void setRowIndex(int rowIndex)
        {
            _rowIndex = rowIndex;
        }
        public string getID()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["ID"].ToString();
            else
                return "";
        }
        public string getProfileName()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["ProfileName"].ToString();
            else
                return "";
        }
        public string getEmptyFields()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["EmptyFields"].ToString();
            else
                return null;
        }
        public string getClearPrevVaues()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["ClearPrevValues"].ToString();
            else
                return null;
        }
        public string getShortcutModifier()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["ShortcutModifier"].ToString();
            else
                return null;
        }
        public string getShortcutKeys()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["ShortcutKeys"].ToString();
            else
                return null;
        }
        public string getSyrianNationalIDFormat()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["SyrianNationalIDFormat"].ToString();
            else
                return "";
        }
        public string getDateFormula()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["DateFormat"].ToString();
            else
                return "";
        }
        public string getIsDefault()
        {
            if (dtProfile.Rows.Count > 0)
                return dtProfile.Rows[_rowIndex]["IsDefault"].ToString();
            else
                return null;
        }
        public bool goNext()
        {
            if (_rowIndex < dtProfile.Rows.Count - 1)
                ++_rowIndex;
            return (_rowIndex < dtProfile.Rows.Count - 1);
        }
    }
}
