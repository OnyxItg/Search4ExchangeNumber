using System;
using System.Data;

namespace OnyxSmartIDReader
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - SQL Helper
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class TableTableBankMenu
    {
        SQLHelper sqlBlackList = new SQLHelper();
        DataTable dtBlackList = new DataTable();
        private string dbName = "", SchemaName = "", tableName = "BlackList";
        ///DataRow dataRow = null;
        private int _rowIndex = 0;                      
        private string sqlSELECT = "";
        public TableTableBankMenu()
        {
            
        }
        public void setConnectionString()
        {
            this.dbName = SQLHelper.dbName;
            SchemaName = SQLHelper.identitySchemaName;
            tableName = SQLHelper.BlackListTableName;
            sqlBlackList.SetConnectionString();
            sqlSELECT = string.Format("SELECT " +
                 /*00*/"  [ID] AS م " +
                 /*01*/", [IdentityNo] AS [الرقم الوطني] " +
                 /*02*/", [FullName] AS [الاسم الكامل]" +
                 /*03*/", [FatherName] AS الأب " +
                 /*04*/", [MotherName] AS الأم " +
                 /*05*/", CONVERT(VARCHAR, [BirthDate], 111) AS [تاريخ الولادة] " +
                       "  FROM [{0}].[{1}].[{2}] ", dbName, SchemaName, tableName);         
        }                                                                                      
        public DataTable openTable(string whereStatement)
        {
            dtBlackList = sqlBlackList.ExecuteSelect(sqlSELECT+whereStatement);
            return dtBlackList;
        }
        private string searchValue(string Field, string SearchValue)
        {

            if (SearchValue.Length <2)
            {
                return "";
            }
            else
            {
                if ((SearchValue[0] == 'ا' | SearchValue[0] == 'أ' | SearchValue[0] == 'إ' | SearchValue[0] == 'آ') & (SearchValue[1] == 'ل'))
                {
                    SearchValue = SearchValue.Substring(2);
                }

                int x = SearchValue.Length - 1;
                string Result = "";
                string field = "[" + Field + "]";
                
                    if (SearchValue[0] == 'ا' | SearchValue[0] == 'أ' | SearchValue[0] == 'إ' | SearchValue[0] == 'آ')
                {
                    if (SearchValue[1] == 'ل')
                    {
                        Result = "   (" + field + " LIKE '%ال" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + field + " LIKE '%أل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + field + " LIKE '%إل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + field + " LIKE '%آل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + field + " LIKE '%" + SearchValue.Substring(2, x - 1) + "%'" + ")";
                    }
                    else if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                    {
                        Result = "   (" + field + " LIKE " + "'%ا" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + field + " LIKE " + "'%أ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + field + " LIKE " + "'%إ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + field + " LIKE " + "'%آ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + field + " LIKE " + "'%ا" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + field + " LIKE " + "'%أ" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + field + " LIKE " + "'%إ" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + field + " LIKE " + "'%آ" + SearchValue.Substring(1, x - 1) + "ة%'" + ")";
                    }
                    else if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                    {
                        Result = "   (" + field + " LIKE " + "'%ا" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + field + " LIKE " + "'%أ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + field + " LIKE " + "'%إ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + field + " LIKE " + "'%آ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + field + " LIKE " + "'%ا" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + field + " LIKE " + "'%أ" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + field + " LIKE " + "'%إ" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + field + " LIKE " + "'%آ" + SearchValue.Substring(1, x - 1) + "ى%'" + ")";
                    }
                    else
                    {
                        Result = "   (" + /*field + " LIKE " + "'%" + SearchValue.Substring(1, x) + "%'" +
                                " or " +*/ field + " LIKE " + "'%أ" + SearchValue.Substring(1, x) + "%'" +
                                " or " + field + " LIKE " + "'%إ" + SearchValue.Substring(1, x) + "%'" +
                                " or " + field + " LIKE " + "'%آ" + SearchValue.Substring(1, x) + "%'" + ")";
                    }
                }//SearchValue[0] in ['ا', 'أ', 'إ', 'آ']
                else

                //

                if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                {
                    Result = "   (" + field + " LIKE " + "'%" + SearchValue.Substring(0, x) + "ه%'" +
                             " or " + field + " LIKE " + "'%" + SearchValue.Substring(0, x) + "ة%'" + ")";
                }
                else
                if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                {
                    Result = "   (" + field + " LIKE " + "'%" + SearchValue.Substring(0, x) + "ي%'" +
                             " or " + field + " LIKE " + "'%" + SearchValue.Substring(0, x) + "ى%'" + ")";
                }
                else
                {
                    Result = "   (" + field + " LIKE " + "'%" + SearchValue + "%'" + ")";
                }//***
                return Result;
            }
        }
        
        public DataTable search4Name(string FieldName, string value, bool partial, string filter)
        {
            string fieldName = FieldName;
            if (FieldName.Equals("الاسم الكامل"))
                fieldName = "FullName";
            else if (FieldName.Equals("الاسم"))
                fieldName = "FirstName";
            else if (FieldName.Equals("الرقم الوطني"))
                fieldName = "IdentityNo";

            string s = "";
            if (partial)
            {
                string[] words = value.Split(' ');
                s = searchValue(fieldName, words[0]);
                for (int i = 1; i < words.Length; i++)
                {
                    s = s + "OR" + searchValue(fieldName, words[i]);
                }
            }
            else
            {
                s = searchValue(fieldName, value);
            }
            if (s.Length > 0)
            {
                if (filter.Length > 0)
                    dtBlackList = sqlBlackList.ExecuteSelect(sqlSELECT + " WHERE " + s + " AND " + filter + " ORDER BY [تاريخ التعديل] DESC");
                else
                    dtBlackList = sqlBlackList.ExecuteSelect(sqlSELECT + " WHERE " + s + " ORDER BY [تاريخ التعديل] DESC");
            }
            return dtBlackList;
        }
        public DataTable search4IdentityNo(string IdentityNo)
        {
            return openTable(" WHERE [IdentityNo]='" + IdentityNo + "'");//dtBlackList;
        }
        public bool IsIdentityNoExist(string IdentityNo)
        {
            return sqlBlackList.IsValueExists("'"+IdentityNo+"'", "[IdentityNo]", "["+dbName+"].["+SchemaName+ "].[" + tableName + "]");
        }
        public DataTable sort(string columnName, bool ascending)
        {
            if (ascending)
                dtBlackList = sqlBlackList.ExecuteSelect(sqlSELECT+" ORDER BY ["+columnName+"] ASC");
            else
                dtBlackList = sqlBlackList.ExecuteSelect(sqlSELECT + " ORDER BY [" + columnName + "] DESC");
            return dtBlackList;
        }
        public bool Save2BlackList(string IdentityNo, string FirstName, string LastName, string FatherName,
                                   string MotherName, string BirthDate, string BirthPlace)
        {
            string ID = Guid.NewGuid().ToString();
            return sqlBlackList.ExecuteInsert_Update(string.Format(
                      "INSERT INTO [{0}].[{1}].[{2}] " +
                      "([ID], [IdentityNo], [FirstName], [LastName], [FatherName], [MotherName],[BirthDate], [BirthPlace]) " +
                      "VALUES('{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')", 
                      dbName, SchemaName, tableName, ID, IdentityNo, FirstName, LastName, FatherName, MotherName, BirthDate, BirthPlace));
        }
        public bool UpdateRecord(string ID, string IdentityNo, string FirstName, string LastName, string FatherName,
                                   string MotherName, string BirthDate, string BirthPlace)
        {
            /*return sqlBlackList.ExecuteInsert_Update(
                      "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                      "SET [Phone1]='" + Phone1 + "', [Phone2]='" + Phone2 + "', [Nationality]='" + Nationality + "', [Book]='" + Book +
                      "', [IssueDate]='" + IssueDate + "', [IssuePlace]='" + IssuePlace +
                      "' WHERE ID='" + ID + "'");*/
            return false;
        }

        public bool Delete()
        {
            return sqlBlackList.ExecuteNonQuery(string.Format("DELETE FROM [{0}].[{1}].[{2}]", dbName, SchemaName, tableName));
        }
        public void setRowIndex(int rowIndex)
        {
            _rowIndex = rowIndex;
        }
        public string getID()
        {
            if (dtBlackList.Rows.Count > 0)
                return dtBlackList.Rows[_rowIndex]["م"].ToString();
            else
                return "";
        }
        public string getIdentityNo()
        {
            return dtBlackList.Rows[_rowIndex]["الرقم الوطني"].ToString();
        }
        public string getFirstName()
        {
            return dtBlackList.Rows[_rowIndex]["الاسم"].ToString(); 
        }
        public string getLastName()
        {
            return dtBlackList.Rows[_rowIndex]["العائلة"].ToString();
        }
        public string getFatherName()
        {
            return dtBlackList.Rows[_rowIndex]["الأب"].ToString();
        }
        public string getFullName()
        {
            return dtBlackList.Rows[_rowIndex]["الاسم الكامل"].ToString();
        }
        public string getMotherName()
        {
            return dtBlackList.Rows[_rowIndex]["الأم"].ToString();
        }
        public DateTime getBirthDate()
        {
            return (DateTime)dtBlackList.Rows[_rowIndex]["تاريخ الولادة"];
        }
        public string getBirthDateString()
        {
            DateTime dt = (DateTime)dtBlackList.Rows[_rowIndex]["تاريخ الولادة"];
            string res = dt.ToString("yyyy-MM-dd");//.Year +"/"+dt.Month+"/"+dt.Day;
            return res;
        }
        public string getBirthPlace()
        {
            return dtBlackList.Rows[_rowIndex]["مكان الولادة"].ToString();
        }
        public int getRecCount()
        {
            return dtBlackList.Rows.Count;
        }
        public void goNext()
        {
            //dtBlackList.Rows.[++_rowIndex];
        }
    }
}
