using MahClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - SQL Helper
    //  Date            - 22/07/2020
    //  Contact mah4moud@gmail.com
    public class SQLHelper
    {
        #region Class Variables
        protected string sqlSELECT = "";
        protected string tableName = "";
        public int rowIndex = 0;

        private SqlTransaction _sqltrn = null;
        private static SqlConnection _sqlcon = null;
        private static SqlConnection _sqlconClients = null;
        private SqlCommand _sqlcom = null;
        private Boolean _result = false;
        private Object _value = null;

        public DataTable _resultTable = null;
        //private  SqlDataReader _sqlDataReader = null;
        private String typevalue = String.Empty;
        private Dictionary<String, SqlDbType> _output = null;
        private Dictionary<String, String> _paranames = null;

        #endregion Class Variables

        #region  Values

        public static string ConnectionValue = "", ClientsConnectionValue = "", MasterConnectionValue = "", dbName = "IDReaderPro", clientsDBName = "IDReaderPro", SchemaName = "dbo";
        public static string identityTableName = "View_Identity", ProfileTableName = "Profile",
                             BranchTableName = "Branch", EmployeeTableName = "Employee", UsersTableName = "Users", EventsTableName = "Events",
                             PrivilegesTableName = "Privileges", UserPrivilegesTableName = "UserPrivileges", BlackListTableName = "BlackList",
                             PostalSlicesTableName = "PostalSlices", PostalWagesTableName = "PostalWages", ContactTableName = "Contact",
                             ManifestTableName = "Manifest", DeliveryTableName = "Branch", NoticeTableName = "Notice", 
                             BookTableName = "Book", DriverTableName = "Driver";

        public static string ManifestViewName = "View_Manifest", ManifistNoticeViewName = "View_ManifestNotice", NoticeViewName = "View_Notice",
                             DeliveryStatement_SUM_ViewName = "View_DeliveryStatement_SUM", BookViewName = "View_Book";
        #endregion Values
        //**********************************************************************************************
        public static void InitHelper(string dbName, string connectionValue, string masterConnectionValue)
        {
            SQLHelper.dbName = dbName;
            //dbName = "IDReaderPro";
            SchemaName = "dbo";
            ConnectionValue = connectionValue;
            MasterConnectionValue = masterConnectionValue!=""? masterConnectionValue : "Data Source=.;Initial Catalog=master;Integrated Security=true";
            _sqlcon = new SqlConnection(ConnectionValue);
        }
        public static void InitHelper(string dbName, string clientsDBName, string connectionValue, string masterConnectionValue, string clientsConnectionValue)
        {
            InitHelper(dbName, connectionValue, masterConnectionValue);
            SQLHelper.clientsDBName = clientsDBName;
            SQLHelper.ClientsConnectionValue = clientsConnectionValue;
            _sqlconClients = new SqlConnection(clientsConnectionValue);
        }
        public DataTable openTable()
        {
            return openTable("");
        }
        public DataTable openTable(string whereStatement)
        {
            _resultTable = ExecuteSelect(sqlSELECT + whereStatement);
            rowIndex = 0;
            return _resultTable;
        }
        public DataTable openTable(string whereStatement, string orderBy)
        {
            _resultTable = ExecuteSelect(sqlSELECT + whereStatement + orderBy);
            rowIndex = 0;
            return _resultTable;
        }
        public DataTable openTable(string[] fields)
        {
            return openTable(fields, "");
        }
        public DataTable openTable(string[] fields, string whereStatement)
        {
            if (fields.Length > 0)
            {
                sqlSELECT = "SELECT " + fields[0];
                for (int i = 1; i < fields.Length; i++)
                {
                    sqlSELECT += "," + fields[i];
                }
                sqlSELECT += " FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "] ";
                sqlSELECT += whereStatement;
                return openTable();
            }
            return null;
        }
        public DataTable search4ID(string ID)
        {
            sqlSELECT = "SELECT * FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "] ";
            _resultTable = openTable(" WHERE [ID]='" + ID + "'");
            return _resultTable;
        }
        public DataTable ExecuteSelect(String query)
        {
            try
            {
                openConnection();
                _sqlcom = new SqlCommand(query, _sqlcon);
                SqlDataAdapter adapt = new SqlDataAdapter(_sqlcom);
                DataTable _resultTable = new DataTable();
            //if (_resultTable.DataSet != null) 
                adapt.Fill(_resultTable);
                return _resultTable;
            }
            catch (Exception ex)
            {
                //-2146232060   //database not found
                //-2146232060
                MyClass.Exception2LogFile("SQLHelper", "ExecuteSelect("+query+")", ex);
            }
            return null;
        }
        public bool ExecuteNonQueryMaster(String query)
        {
            try
            {
                _result = false;
                _sqlcon = new SqlConnection(MasterConnectionValue);
                openConnection();
                //_sqlcom.Connection = _sqlcon;
                _sqlcom = new SqlCommand(query, _sqlcon);

                _sqlcom.CommandText = query;
                _sqlcom.ExecuteNonQuery();
                _result = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "ExecuteNonQueryMaster("+query+")", ex);
                /*if (ex.ToString().ToLower().IndexOf("database is in use") > 0)
                    MyClass.Message(Language.DB_Exists);
                else
                    MyClass.Message(Language.ErrorDataNotSaved, MessageBoxIcon.Error);*/
            }
            return _result;
        }
        public bool ExecuteNonQuery(String query)
        {
            try
            {
                _result = false;
                openConnection();
                //_sqlcom.Connection = _sqlcon;
                _sqlcom = new SqlCommand(query, _sqlcon);

                _sqlcom.CommandText = query;
                int ret = _sqlcom.ExecuteNonQuery();
                _result = (ret > 0);
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "ExecuteNonQuery("+query+")", ex);
                MyClass.Message("حدث خطأ أثناء الاتصال بقاعدة البيانات", MessageBoxIcon.Error);
                //{"Violation of PRIMARY KEY constraint 'PK_Markter'. Cannot insert duplicate key in object 'dbo.Markter'. The duplicate key value is (6).\r\nThe statement has been terminated."}
            }
            return _result;
        }
        public bool ExecuteStoredProcedureIU(string ProcedureName, SqlParameter[] parameters)
        {
            try
            {
                _result = false;
                openConnection();
                //_sqlcom.Connection = _sqlcon;
                _sqlcom = new SqlCommand(ProcedureName, _sqlcon);
                _sqlcom.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                foreach (SqlParameter param in parameters)
                {
                    _sqlcom.Parameters.Add(param);
                }
                _sqlcom.Connection = _sqlcon;//
                int ret = _sqlcom.ExecuteNonQuery();
                _sqlcon.Close();
                _result = (ret > 0);
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "ExecuteStoredProcedureIU("+ProcedureName+")", ex);
                MyClass.Message("حدث خطأ أثناء الاتصال بقاعدة البيانات", MessageBoxIcon.Error);
            }
            return _result;
        }
        public DataTable ExecuteStoredProcedureSelect(string ProcedureName, SqlParameter[] parameters)
        {
            try
            {
                _result = false;
                openConnection();
                //_sqlcom.Connection = _sqlcon;
                _sqlcom = new SqlCommand(ProcedureName, _sqlcon);
                _sqlcom.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (SqlParameter param in parameters)
                    {
                        _sqlcom.Parameters.Add(param);
                    }
                _sqlcom.Connection = _sqlcon;//
                SqlDataAdapter adapt = new SqlDataAdapter(_sqlcom);
                DataTable _resultTable = new DataTable();
                //if (_resultTable.DataSet != null)
                //_resultTable = ExecuteSelect("SELECT @output");
                adapt.Fill(_resultTable);
                _sqlcon.Close();
                return _resultTable;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "ExecuteStoredProcedureSelect("+ProcedureName+")", ex);
                MyClass.Message("حدث خطأ أثناء الاتصال بقاعدة البيانات" + Environment.NewLine + ex.ToString(), MessageBoxIcon.Error);
                return null;
            }
        }
        public bool ExecuteInsert_Update(String query)
        {
            return ExecuteNonQuery(query);
        }
        public bool ExecuteInsert_Update_Parameter(String tableName, string fieldName, string fileName, string where)
        {
            bool ret = false;
            try
            {
                string sqlText = "";
                if (!File.Exists(fileName))
                {
                    sqlText += "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                               "SET [" + fieldName + "] = NULL " + where;
                    ExecuteNonQuery(sqlText);
                }
                else
                {
                    sqlText += "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                               "SET [" + fieldName + "] = @file " + where;
                    _sqlcom = new SqlCommand(sqlText, _sqlcon);
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@file", SqlDbType.VarBinary);
                    byte[] file = File.ReadAllBytes(fileName);
                    param[0].Value = file;
                    openConnection();
                    _sqlcom.Parameters.AddRange(param);
                    _sqlcom.ExecuteNonQuery();
                    _sqlcon.Close();
                    //ExecuteNonQuery(sqlText);
                }
                ret = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", string.Format("ExecuteInsert_Update_Parameter({3},{0},{1},{2})", tableName, fieldName, fieldName, where), ex);
            }
            return ret;
        }
        public string searchValue(string Field, string SearchValue, bool partial)
        {
            string Result = "";
            string field = "[" + Field.Trim('[').Trim(']') + "]";
            string prefix = "%";
            if (partial)
                prefix = field + " LIKE " + prefix;
            if (SearchValue.Length < 1)
            {
                return "";
            }
            else if (SearchValue.Length == 1)
            {
                char c = SearchValue[0];
                switch (c)
                {
                    case 'ا':
                    case 'أ':
                    case 'إ':
                    case 'آ':
                        Result = "[اأإآ]%%";
                        break;
                    case 'ة':
                    case 'ه':
                        Result = "%%[ةه]";
                        break;
                    case 'ى':
                    case 'ي':
                        Result = "%%[ىي]";
                        break;
                    default:
                        Result = "" + c + "%";
                        break;
                }
            }
            else if (SearchValue.Length == 2)
            {
                char c = SearchValue[0];
                Result = prefix + SearchValue + "%";
                if ((c == 'ا' | c == 'أ' | c == 'إ' | c == 'آ') & (SearchValue[1] == 'ل'))
                {
                    Result = Result = "[اأإآ]%ل%";
                }
                c = SearchValue[1];
                if (c == 'ه' | c == 'ة')
                {
                    Result = "%%"+ SearchValue[0] + "[ةه]";
                }
                else if (c == 'ى' | c == 'ي')
                {
                    Result = "%%" + SearchValue[0] + "[ىي]%";
                }
            }
            else //if (SearchValue.Length > 2)
            {
                char c = SearchValue[0];
                if ((c == 'ا' | c == 'أ' | c == 'إ' | c == 'آ') & (SearchValue[1] == 'ل'))
                {
                    SearchValue = SearchValue.Substring(2);
                }

                int x = SearchValue.Length - 1;
                c = SearchValue[0];
                if (c == 'ا' || c == 'أ' || c == 'إ' || c == 'آ')
                {
                    /*if (SearchValue[1] == 'ل')
                    {
                        Result = " " + prefix + "ال" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "أل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "إل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "آل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "" + SearchValue.Substring(2, x - 1) + "%'" + "";
                    }
                    else */
                    if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                    {
                        Result = " " + prefix + "[اأإآ]" + SearchValue.Substring(1, x - 1) + "[ةه]%";
                    }
                    else if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                    {
                        Result = " " + prefix + "[اأإآ]" + SearchValue.Substring(1, x - 1) + "[يى]%";
                    }
                    else
                    {
                        Result = " " + prefix + "[اأإآ]" + SearchValue.Substring(1, x - 1) + "%";
                    }
                }//SearchValue[0] in ['ا', 'أ', 'إ', 'آ']
                else if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                {
                    Result = " " + prefix + "" + SearchValue.Substring(0, x) + "[ةه]%";
                }
                else
                if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                {
                    Result = " " + prefix + "" + SearchValue.Substring(0, x) + "[ىي]%" + "";
                }
                else
                {
                    Result = " %" + SearchValue + "%" + "";
                }//***
            }
            return Result;
        }
        public string search4Name(string fieldName, string value, bool partial, string filter, decimal StartRecNo)
        {
            if (value == "")
                return null;

            string s = "";
            if (partial)
            {
                string[] words = value.Split(' ');
                s = 'N' + searchValue(fieldName, words[0], partial);
                for (int i = 1; i < words.Length; i++)
                {
                    s = s + "OR N" + searchValue(fieldName, words[i], partial);
                }
            }
            else
            {
                s = "";
                string[] words = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] split = { "or" };
                string[] sv1 = searchValue(fieldName, words[0], partial).Split(split, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length == 1)
                {
                    s = fieldName + " LIKE N'" + sv1[0].TrimStart() + "'";
                    if (sv1.Length > 1)
                    {
                        for (int i = 1; i < sv1.Length; i++)
                        {
                            s += "" + sv1[i].TrimStart() + "";
                        }
                    }
                }
                else if (words.Length > 1)
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        string[] sv2 = searchValue(fieldName, words[i], partial).Split(split, StringSplitOptions.RemoveEmptyEntries);
                        s = "";
                        for (int j = 0; j < sv1.Length; j++)
                        {
                            for (int k = 0; k < sv2.Length; k++)
                            {
                                s = s + sv1[j] +//.Replace('(', ' ').Replace(')', ' ').Replace('\'', ' ').Trim() + "" +
                                        sv2[k] + "|";//.Replace('(', ' ').Replace(')', ' ').Replace('\'', ' ').Trim() + "|";
                            }

                        }
                        sv1 = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    }

                    sv1 = s.Split('|');
                    s = fieldName + " LIKE N'" + s.TrimEnd('|').TrimStart() + "'";
                    s = s.Replace("|", "' OR [FullName] LIKE N'");
                }

            }
            return s;
        }
        public string searchValue1(string Field, string SearchValue, bool partial)
        {
            string Result = "";
            string field = "[" + Field.Trim('[').Trim(']') + "]";
            string prefix = "'%";
            if (partial)
                prefix = field + " LIKE " + prefix;
            if (SearchValue.Length < 1)
            {
                return "";
            }
            else if (SearchValue.Length == 1)
            {
                char c = SearchValue[0];
                switch (c)
                {
                    case 'ا':
                    case 'أ':
                    case 'إ':
                    case 'آ':
                        Result = " " + prefix + "ا%'" +
                             " or " + prefix + "أ%'" +
                             " or " + prefix + "إ%'" +
                             " or " + prefix + "آ%' ";
                        break;
                    case 'ة':
                    case 'ه':
                        Result = " " + prefix + "ه%' or " + prefix + "ة%' ";
                        break;
                    case 'ى':
                    case 'ي':
                        Result = " " + prefix + "ي%' or " + prefix + "ى%' ";
                        break;
                    default:
                        Result = " " + prefix + c + "%'";
                        break;
                }
            }
            else if (SearchValue.Length == 2)
            {
                char c = SearchValue[0];
                Result = prefix + SearchValue + "%'";
                if ((c == 'ا' | c == 'أ' | c == 'إ' | c == 'آ') & (SearchValue[1] == 'ل'))
                {
                    Result = "    " + prefix + "ال%'" +
                                  " or " + prefix + "أل%'" +
                                  " or " + prefix + "إل%'" +
                                  " or " + prefix + "آل%'";
                }
                c = SearchValue[1];
                if (c == 'ه' | c == 'ة')
                {
                    Result = "    " + prefix + SearchValue[0] + "ه%'" +
                             " OR " + field + " LIKE N" + prefix + SearchValue[0] + "ة%'";
                }
                else if (c == 'ى' | c == 'ي')
                {
                    Result = "    " + prefix + SearchValue[0] + "ى%'" +
                             " OR " + field + " LIKE N" + prefix + SearchValue[0] + "ي%'";
                }
            }
            else //if (SearchValue.Length > 2)
            {
                char c = SearchValue[0];
                if ((c == 'ا' | c == 'أ' | c == 'إ' | c == 'آ') & (SearchValue[1] == 'ل'))
                {
                    SearchValue = SearchValue.Substring(2);
                }

                int x = SearchValue.Length - 1;
                c = SearchValue[0];
                if (c == 'ا' || c == 'أ' || c == 'إ' || c == 'آ')
                {
                    if (SearchValue[1] == 'ل')
                    {
                        Result = " " + prefix + "ال" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "أل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "إل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "آل" + SearchValue.Substring(2, x - 1) + "%'" +
                                 " or " + prefix + "" + SearchValue.Substring(2, x - 1) + "%'" + "";
                    }
                    else if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                    {
                        Result = " " + prefix + "ا" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + prefix + "أ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + prefix + "إ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + prefix + "آ" + SearchValue.Substring(1, x - 1) + "ه%'" +
                                 " or " + prefix + "ا" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + prefix + "أ" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + prefix + "إ" + SearchValue.Substring(1, x - 1) + "ة%'" +
                                 " or " + prefix + "آ" + SearchValue.Substring(1, x - 1) + "ة%'" + "";
                    }
                    else if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                    {
                        Result = " " + prefix + "ا" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + prefix + "أ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + prefix + "إ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + prefix + "آ" + SearchValue.Substring(1, x - 1) + "ي%'" +
                                 " or " + prefix + "ا" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + prefix + "أ" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + prefix + "إ" + SearchValue.Substring(1, x - 1) + "ى%'" +
                                 " or " + prefix + "آ" + SearchValue.Substring(1, x - 1) + "ى%'" + "";
                    }
                    else
                    {
                        Result = " " + /*prefix +"" + SearchValue.Substring(1, x) + "%'" +
                                " or " +*/ prefix + "أ" + SearchValue.Substring(1, x) + "%'" +
                                " or " + prefix + "إ" + SearchValue.Substring(1, x) + "%'" +
                                " or " + prefix + "ا" + SearchValue.Substring(1, x) + "%'" +
                                " or " + prefix + "آ" + SearchValue.Substring(1, x) + "%'" + "";
                    }
                }//SearchValue[0] in ['ا', 'أ', 'إ', 'آ']
                else

                //

                if (SearchValue[x] == 'ه' | SearchValue[x] == 'ة')
                {
                    Result = " " + prefix + "" + SearchValue.Substring(0, x) + "ه%'" +
                             " or " + prefix + "" + SearchValue.Substring(0, x) + "ة%'" + "";
                }
                else
                if (SearchValue[x] == 'ي' | SearchValue[x] == 'ى')
                {
                    Result = " " + prefix + "" + SearchValue.Substring(0, x) + "ي%'" +
                             " or " + prefix + "" + SearchValue.Substring(0, x) + "ى%'" + "";
                }
                else
                {
                    Result = " " + prefix + "" + SearchValue + "%'" + "";
                }//***
            }
            return Result;
        }
        public string searchID(string TableName, string ResultField, string ID)
        {
            if (ID == null || ID == "") return "";
            string sql = "SELECT " + ResultField + " FROM [" + dbName + "].[" + SQLHelper.SchemaName + "].[" + TableName + "] " +
                               "WHERE ID = '" + ID + "'";
            DataTable dt = ExecuteSelect(sql);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            else
                return "";
        }
        public bool attachDB(string mdf, string ldf, string dbName)
        {

            string sql = "USE[master] " +
                         "CREATE DATABASE[" + dbName + "] ON " +
                         "(FILENAME = N'" + mdf + "'), " +
                         "(FILENAME = N'" + ldf + "' ) " +
                         "FOR ATTACH";
            return ExecuteCreateDB(sql);
        }
        public void detachDB(string dbName)
        {
            string sql = "USE [master] EXEC master.dbo.sp_detach_db @dbname = N'" + dbName + "'";
            ExecuteCreateDB(sql);
        }
        public DateTime getServerDateTime()
        {
            DataTable dt = ExecuteSelect("SELECT GETDATE()");
            DateTime d = DateTime.Now;
            if (dt != null)
                d = MyClass.ParseDate(dt.Rows[0][0].ToString());
            return d;
        }
        public static string GetDBVersion(string DBName)
        {
            return GetDBVersion(DBName, MasterConnectionValue);
        }
        public static string GetDBVersion(string DBName, string connectionString)
        {
            string s = " ";
            string sql = "SELECT value FROM [" + DBName + "].[sys].extended_properties WHERE name = 'MahmoudAlkannassTransportPro_DB_Version'";
            try
            {
                //string ConnectionValue = ;
                SqlConnection sqlcon = new SqlConnection(connectionString);
                if (sqlcon.State == ConnectionState.Closed)
                    try
                    {
                        sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        ex.StackTrace.ToString();
                    }
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                SqlDataAdapter adapt = new SqlDataAdapter(sqlcom);
                DataTable _resultTable = new DataTable();
                //if (_resultTable.DataSet != null) 
                adapt.Fill(_resultTable);
                s = _resultTable.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                //-2146232060   //database not found
                //-2146232060
                ex.StackTrace.ToString();
            }
            return s;
        }
        public static string GetDatabases()
        {
            return GetDatabases(MasterConnectionValue);
        }
        public static string GetDatabasesFromProperty(string connectionString, string ExtendedProp)
        {
            string s = "";
            string sql = "if OBJECT_ID(N'tempdb..#TempDBs') IS NOT NULL DROP TABLE #TempDBs; " +
                         "CREATE TABLE #TempDBs(DatabaseName NVARCHAR(250), ExtendedProp NVARCHAR(MAX)); " +
                         "EXEC sp_MSforeachdb N'INSERT INTO #TempDBs (DatabaseName) SELECT ''?''' " +
                         "EXEC sp_MSforeachdb N'UPDATE #TempDBs SET ExtendedProp = DBs.[Valor] FROM (SELECT [DBName] = ''?'', " +
                         "[Extended] = CAST(name AS varchar), [Valor] = CAST(value AS varchar) " +
                         "FROM " +
                         "[?].sys.extended_properties WHERE class=0) " +
                         "DBs INNER JOIN #TempDBs ON #TempDBs.DatabaseName = [DBName]' " +
                         "SELECT DatabaseName FROM #TempDBs WHERE ExtendedProp ='" + ExtendedProp + "'";
            try
            {
                string ConnectionValue = connectionString;
                SqlConnection sqlcon = new SqlConnection(ConnectionValue);
                if (sqlcon.State == ConnectionState.Closed)
                    try
                    {
                        sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        MyClass.Exception2LogFile("SQLHelper", string.Format("GetDatabases({0},{1})", connectionString, ExtendedProp), ex);
                    }
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                SqlDataAdapter adapt = new SqlDataAdapter(sqlcom);
                DataTable _resultTable = new DataTable();
                //if (_resultTable.DataSet != null) 
                adapt.Fill(_resultTable);
                for (int i = 0; i < _resultTable.Rows.Count; i++)
                {
                    s += _resultTable.Rows[i][0] + "|";
                }
            }
            catch (Exception ex)
            {
                //-2146232060   //database not found
                //-2146232060
                MyClass.Exception2LogFile("SQLHelper", string.Format("GetDatabases({0})", connectionString), ex);
            }
            return s;
        }
        public static string GetDatabases(string connectionString)
        {
            return GetDatabasesFromProperty(connectionString, "MahmoudAlkannassTransportPro");
        }
        public static string GetNameDatabases(string connectionString)
        {
            return GetDatabasesFromProperty(connectionString, "MahmoudAlkannassIDReaderPro");
        }
        public int getRowCount()
        {
            return _resultTable == null ? -1 : _resultTable.Rows.Count;
        }
        public string getFieldValue(int rowIndex, string fieldName)
        {
            if (_resultTable != null && _resultTable.Rows.Count > rowIndex)
                try { 
                    return _resultTable.Rows[rowIndex][fieldName].ToString();
                }
                catch (Exception ex){ MyClass.Exception2LogFile("SQLHelper", "getFieldValue", ex); return ""; }
            else
                return "";
        }
        public string getFieldValue(int rowIndex, int fieldNo)
        {
            if (_resultTable != null && _resultTable.Rows.Count > rowIndex)
                return _resultTable.Rows[rowIndex][fieldNo].ToString();
            else
                return "";
        }
        public int getFieldValue_Int(int rowIndex, string fieldName)
        {
            try {
                return Convert.ToInt32(_resultTable.Rows[rowIndex][fieldName].ToString());
            }
            catch {
                return 0;
            }
        }
        public double getFieldValue_Double(int rowIndex, string fieldName)
        {
            try
            {
                return Convert.ToDouble(_resultTable.Rows[rowIndex][fieldName].ToString());
            }
            catch { return 0; }
        }
        public float getFieldValue_Float(int rowIndex, string fieldName)
        {
            try
            {
                return Convert.ToSingle(_resultTable.Rows[rowIndex][fieldName].ToString());
            }
            catch { return 0; }
        }
        public bool getFieldValue_Bool(int rowIndex, int fieldNo)
        {
            bool ret = false;
            if (_resultTable != null && _resultTable.Rows.Count > rowIndex)
            {
                string s = _resultTable.Rows[rowIndex][fieldNo].ToString();
                try
                {
                    ret = Convert.ToBoolean(s);
                }
                catch { }
            }
            return ret;
        }
        public bool getFieldValue_Bool(int rowIndex, string fieldName)
        {
            bool ret = false;
            if (_resultTable != null && _resultTable.Rows.Count > rowIndex)
            {   
                try
                {
                    string s = _resultTable.Rows[rowIndex][fieldName].ToString();
                    ret = Convert.ToBoolean(s);
                }
                catch { }
            }
            return ret;
        }
        public DateTime getFieldValue_DateTime(int rowIndex, int fieldNo)
        {
            string ret = getFieldValue(rowIndex, fieldNo);
            try
            {
                return Convert.ToDateTime(ret);
            }
            catch { }
            return new DateTime(1, 1, 1);
        }
        public DateTime getFieldValue_DateTime(int rowIndex, string fieldName)
        {
            string ret = getFieldValue(rowIndex, fieldName);
            try
            {
                return Convert.ToDateTime(ret);
            }
            catch { }
            return new DateTime(1, 1, 1);
        }
        public byte[] getFieldValue_bytes(int rowIndex, string fieldName)
        {
            byte[] ret = null;
            if (_resultTable.Rows.Count > 0)
                try
                {
                    ret = (byte[])_resultTable.Rows[rowIndex][fieldName];
                }
                catch { }
            return ret;
        }
        public bool ExecuteCreate(String query)
        {
            return ExecuteNonQuery(query);
        }
        public bool FillUsers()
        {
            bool ret = false;
            try
            {
                string sqlText = "INSERT INTO [" + dbName + "].[" + SchemaName + "].[" + UsersTableName + "] " +
                                 "([ID], [UserName], [Password]) " +
                                 "VALUES (1,'عادي',''),"+
                                        "(2,'مشرف', 'super'),"+
                                        "(3,'مدير', 'admin')";
                ExecuteNonQuery(sqlText);
                ret = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "FillUsers", ex);
                _sqlcon.Close();
                return false;
            }
            return ret;
        }
        public bool FillPrivileges()
        {
            bool ret = false;
            try
            {
                string sqlText = "INSERT INTO [" + dbName + "].[" + SchemaName + "].[" + PrivilegesTableName + "] " +
                                 "([ID], [Privilege]) " +
                                 "VALUES (1,'" + "طباعة" + "')," +
                                        "(2,'" + "بحث" + "')," +
                                        "(3,'" + "تصدير البيانات" + "'),"+
                                        "(4,'" + "تعديل الصلاحيات" + "'),"+
                                        "(5,'" + "تفعيل بطاقة" + "')," +
                                        "(6,'" + "إدخال يدوي" + "')";
                /*openConnection();
                _sqlcom = new SqlCommand(sqlText, _sqlcon);
                
                _sqlcom.ExecuteNonQuery();
                _sqlcon.Close();*/
                ExecuteNonQuery(sqlText);
                ret = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "FillPrivileges", ex);
                if (_sqlcon.State == ConnectionState.Open)
                    _sqlcon.Close();
                return false;
            }
            return ret;
        }
        public bool FillUserPrivileges(string data)
        {
            bool ret = false;
            try
            {
                string sqlText = "INSERT INTO [" + dbName + "].[" + SchemaName + "].[" + UserPrivilegesTableName + "] " +
                                 "([UserID], [PrivilegeID], [status]) " +
                                 "VALUES "+data;
                ExecuteNonQuery(sqlText);
                ret = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "FillUserPrivileges("+data+")", ex);
                if (_sqlcon.State == ConnectionState.Open)
                    _sqlcon.Close();
                return false;
            }
            return ret;
        }
        public bool UpdatePrivileges(string data)
        {
            bool ret = false;
            try
            {
                string sqlText = "DELETE FROM [" + dbName + "].[" + SchemaName + "].[" + UserPrivilegesTableName + "] " ;
                ExecuteNonQuery(sqlText);
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "UpdatePrivileges("+data+")", ex);
                return false;
            }
            FillUserPrivileges(data);
            return ret;
        }
        public static string getIdentityID(string IdentityNo)
        { 
            SqlConnection sqlcon = new SqlConnection(ClientsConnectionValue);
            int hr = openConnection(sqlcon);
            if (hr > 0)
            {
                string ret = "";
                SqlCommand sqlcom;
                sqlcom = new SqlCommand("SELECT ID FROM [" + dbName + "].[" + SchemaName + "].[" + identityTableName + "] WHERE IdentityNo = '" + IdentityNo + "'", sqlcon);
                ret = Convert.ToString(sqlcom.ExecuteScalar());
                return ret;
            }
            return "";
        }
        public int IsDBExists(string dbName)
        {
            SqlConnection sqlcon= new SqlConnection(MasterConnectionValue);
            int hr = openConnection(sqlcon);
            if (hr > 0)
            {
                SqlCommand sqlcom;
                sqlcom = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = N'" + dbName + "'", sqlcon);
                int _reuslt = Convert.ToInt16(sqlcom.ExecuteScalar());
                return _reuslt;
            }
            return hr;
        }
        private static int openConnection(SqlConnection sqlcon)
        {
            try
            {
                sqlcon.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "openConnection("+sqlcon.ConnectionString+")", ex);
                return ex.HResult;
            }
            
        }
        public bool ExecuteCreateDB(String query)
        {
            try
            {
                _result = false;
                //
                //_sqlcom.Connection = _sqlcon;
                _sqlcon = new SqlConnection(MasterConnectionValue);
                _sqlcom = new SqlCommand(query, _sqlcon);
                openConnection();
                //_sqlcom.CommandText = query;
                _sqlcom.ExecuteNonQuery();
                _result = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "ExecuteCreateDB("+query+")", ex);
            }
            return _result;
        }
        public bool BackupDatabase(string DBName, string backupFileName)
        {
            bool result = false;
            //if (File.Exists(backupFileName))
            try
            {
                string sqlText = "BACKUP DATABASE ["+ DBName+"] TO  DISK = N'"+ backupFileName+"' WITH NOFORMAT, NOINIT,  NAME = N'"+DBName+"-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                result = ExecuteNonQueryMaster(sqlText);
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", string.Format("BackupDatabase({0},{1})",DBName, backupFileName), ex);
            }
            return result;
        }
        public bool RestoreDatabase(string DBName, string restoreFileName)
        {
            _result = false;
            if (File.Exists(restoreFileName))
            {
                try
                {
                    string sqlText = "RESTORE DATABASE [" + DBName + "] FROM  DISK = N'" + restoreFileName + "' WITH  FILE = 1,  NOUNLOAD,   REPLACE,  STATS = 10";
                    _result = ExecuteNonQueryMaster(sqlText);
                }
                catch (Exception ex)
                {
                    MyClass.Exception2LogFile("SQLHelper", string.Format("RestoreDatabase({0},{1})", DBName,restoreFileName), ex);
                }
            }
            return _result;
        }
        public string GetDBNameFromRestore(string dbPath)
        {
            string query = "DECLARE @#MyTable TABLE " +
                           "([f1]  varchar(128), [f2]  varchar(128), [f3]  varchar(128), [f4]     varchar(128), [f5]  varchar(128), [f6]  varchar(128), " +
                           " [f7]  varchar(128), [f8]  varchar(128), [f9]  varchar(128), [DBName] varchar(128), [f11] varchar(128), [f12] varchar(128), " +
                           " [f13] varchar(128), [f14] varchar(128), [f15] varchar(128), [f16]    varchar(128), [f17] varchar(128), [f18] varchar(128), " +
                           " [f19] varchar(128), [f20] varchar(128), [f21] varchar(128), [f22]    varchar(128), [f23] varchar(128), [f24] varchar(128), " +
                           " [f25] varchar(128), [f26] varchar(128), [f27] varchar(128), [f28]    varchar(128), [f29] varchar(128), [f30] varchar(128), " +
                           " [f31] varchar(128), [f32] varchar(128), [f33] varchar(128), [f34]    varchar(128), [f35] varchar(128), [f36] varchar(128), " +
                           " [f37] varchar(128), [f38] varchar(128), [f39] varchar(128), [f40]    varchar(128), [f41] varchar(128), [f42] varchar(128), " +
                           " [f43] varchar(128), [f44] varchar(128), [f45] varchar(128), [f46]    varchar(128), [f47] varchar(128), [f48] varchar(128), " +
                           " [f49] varchar(128), [f50] varchar(128), [f51] varchar(128), [f52]    varchar(128)) " +
                           "INSERT INTO @#MyTable " +
                           "EXEC('RESTORE HEADERONLY FROM DISK=''" + dbPath + "''') " +
                           "SELECT [DBName] FROM @#MyTable ";
            DataTable dt = ExecuteSelect(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DBName"].ToString();
            }
            else
                return "SyrianIdentity";
        }
        public bool IsSchemaExists(string schemaName)
        {
            SqlConnection sqlcon=new SqlConnection(ConnectionValue);
            SqlCommand sqlcom;
            sqlcon.Open();
            sqlcom = new SqlCommand("SELECT COUNT(*) FROM sys.schemas WHERE name = N'"+schemaName+"'", sqlcon);
            int _reuslt = Convert.ToInt16(sqlcom.ExecuteScalar());
            return (_reuslt > 0);
        }
        public bool IsTableExists(string schemaName, string tableName)
        {
            SqlConnection sqlcon=new SqlConnection(ConnectionValue);
            SqlCommand sqlcom;
            int _reuslt = 0;
            try
            {
                //openConnection();
                sqlcon.Open();
                sqlcom = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[" + schemaName + "].[" + tableName + "]') AND type in (N'U')", sqlcon);
                _reuslt = Convert.ToInt16(sqlcom.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", string.Format("IsTableExists({0}, {1})",schemaName ,tableName), ex);
            }
            return (_reuslt > 0);
        }
        public bool IsValueExists(string value, string fieldName, string dbName)
        {
            return IsValueExists(value, fieldName, "", "", dbName);
        }
        public bool IsValueExists(string value1, string fieldName1, string value2, string fieldName2, string dbName)
        {
            SqlConnection sqlcon = new SqlConnection(ConnectionValue);
            SqlCommand sqlcom;
            
            string sql = "SELECT COUNT(*) FROM " + dbName + " WHERE " + fieldName1 + " = " + value1;
            if (fieldName2 != "")
            {
                sql += " AND " + fieldName2 + " = " + value2;
            }
            int result = 0;
            try
            {
                sqlcon.Open();
                sqlcom = new SqlCommand(sql, sqlcon);
                result = Convert.ToInt16(sqlcom.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", string.Format("IsValueExists({0},{1},{2},{3},{4})", value1, fieldName1, value2, fieldName2, dbName), ex);
            }
            return (result > 0);
        }
        public bool IsViewExists(string schemaName, string viewName)
        {
            SqlConnection sqlcon=new SqlConnection(ConnectionValue);
            SqlCommand sqlcom;
            if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
            string sql = "SELECT COUNT(*) FROM sys.views WHERE object_id = OBJECT_ID(N'[" + schemaName + "].[" + viewName + "]')";
            sqlcom = new SqlCommand(sql, sqlcon);
            int _reuslt = Convert.ToInt16(sqlcom.ExecuteScalar());
            return (_reuslt > 0);
        }
        public string getGUID(int colIndex, int rowIndex)
        {
            string res = "";
            SqlDataReader _sqlDataReader = _sqlcom.ExecuteReader();
            for (int i = 0; i < rowIndex + 1; i++)
                _sqlDataReader.Read();
            if (_sqlDataReader.HasRows)
            {
                res = _sqlDataReader.GetGuid(colIndex).ToString();
            }
            _sqlDataReader.Close();
            return res;
        }
        public  int getInt(int colIndex, int rowIndex)
        {
            int res = 0;
            SqlDataReader _sqlDataReader = _sqlcom.ExecuteReader();
            for (int i = 0; i < rowIndex + 1; i++)
                _sqlDataReader.Read();
            if (_sqlDataReader.HasRows)
            {
                res = _sqlDataReader.GetInt16(colIndex);
            }
            _sqlDataReader.Close();
            return res;
        }
        public  string getString(int colIndex, int rowIndex)
        {
            //if (!_sqlDataReader.IsClosed) _sqlDataReader.Close();
            string res = "";
            SqlDataReader _sqlDataReader = _sqlcom.ExecuteReader();
            for (int i=0;i<rowIndex+1;i++)
                _sqlDataReader.Read();
            if (_sqlDataReader.HasRows)
            {
                res = (string)_sqlDataReader.GetString(colIndex);
            }
            _sqlDataReader.Close();
            return res;
        }
        public DateTime getDate(int colIndex, int rowIndex)
        {
            //if (!_sqlDataReader.IsClosed) _sqlDataReader.Close();
            DateTime res = DateTime.Parse("1/1/1900");
            SqlDataReader _sqlDataReader = _sqlcom.ExecuteReader();
            for (int i = 0; i < rowIndex + 1; i++)
                _sqlDataReader.Read();
            if (_sqlDataReader.HasRows)
            {
                res = _sqlDataReader.GetDateTime(colIndex);
            }
            _sqlDataReader.Close();
            return res;
        }
        //**********************************************************************************************
        #region Private Methods
        private  void CreateParameters(List<SqlParameter> parameters)
        {
            if (parameters != null)
            {
                _output = null;
                _paranames = null;

                _output = new Dictionary<string, SqlDbType>();
                _paranames = new Dictionary<string, string>();

                if (_sqlcom.Parameters.Count != 0)
                    _sqlcom.Parameters.Clear();

                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.InputOutput)
                    {
                        _output.Add(parameter.SourceColumn, parameter.SqlDbType);
                        _paranames.Add(parameter.SourceColumn, parameter.ParameterName);
                    }

                    if (parameter.Direction == ParameterDirection.Output)
                    {
                        parameter.Value = DBNull.Value;
                        _output.Add(parameter.SourceColumn, parameter.SqlDbType);
                        _paranames.Add(parameter.SourceColumn, parameter.ParameterName);
                    }
                    _sqlcom.Parameters.Add(parameter);
                }

                if (_output.Count != 0)
                {
                    _resultTable = new DataTable("Result");
                    DataColumn col = null;

                    SqlDbType dbtype;
                    foreach (String key in _output.Keys)
                    {
                        dbtype = (SqlDbType)_output[key];
                        col = new DataColumn(key, Type.GetType(GetColumnType(dbtype)));
                        _resultTable.Columns.Add(col);
                    }
                }
            }
        }
        private  String GetColumnType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return "System.Int64";

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return "System.Byte[]";

                case SqlDbType.Bit:
                    return "System.Boolean";

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return "System.String";

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return "System.DateTime";

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return "System.Decimal";

                case SqlDbType.Float:
                    return "System.Double";

                case SqlDbType.Int:
                    return "System.Int32";

                case SqlDbType.Real:
                    return "System.Single";

                case SqlDbType.UniqueIdentifier:
                    return "System.Guid";

                case SqlDbType.SmallInt:
                    return "System.Int16";

                case SqlDbType.TinyInt:
                    return "System.Byte";

                case SqlDbType.Variant:
                case SqlDbType.Udt:
                    return "System.Object";

                case SqlDbType.Structured:
                    return "System.Data.DataTable";

                case SqlDbType.DateTimeOffset:
                    return "System.DateTimeOffset";

                default:
                    throw new ArgumentOutOfRangeException("Invalid SQL Data type");
            }
        }
        private void FillTable()
        {
            if (_resultTable != null)
            {
                DataRow row = _resultTable.NewRow();

                foreach (String item in _output.Keys)
                    row[item] = _sqlcom.Parameters[_paranames[item].ToString()].Value;

                _resultTable.Rows.Add(row);
            }
        }

        #endregion

        #region Execute SQLHelper
        public SQLHelper()
        {
            //_sqlcon = new SqlConnection(SQLHelper.ConnectionValue);
        }

        public bool openClientsConnection()
        {
            if (_sqlconClients.State == ConnectionState.Closed)
            {
                try
                {
                    _sqlconClients.Open();
                }
                catch (Exception ex)
                {
                    MyClass.Exception2LogFile("SQLHelper", "openClientsConnection()", ex);
                    return false;
                }
            }
            return (_sqlconClients.State == ConnectionState.Open);
        }
        public void closeClientsConnection()
        {
            if (_sqlconClients.State == ConnectionState.Open)
            {
                _sqlconClients.Close();
            }
        }
        public bool openConnection()
        {
            if (_sqlcon.State == ConnectionState.Closed)
            {
                try
                {
                    _sqlcon.Open();
                }
                catch (Exception ex)
                {
                    MyClass.Exception2LogFile("SQLHelper", "openConnection()", ex);
                    return false;
                }
            }
            return (_sqlcon.State == ConnectionState.Open);
        }
        public void closeConnection()
        {
            if (_sqlcon.State == ConnectionState.Open)
            {
                _sqlcon.Close();
            }
        }
        public  void CreateObjects(Boolean istransaction)
        {
            
            if (_sqlcon.State == ConnectionState.Closed)
            {
                _sqlcon.Open();
            }

            if (istransaction)
                _sqltrn = _sqlcon.BeginTransaction(IsolationLevel.Serializable);

            _sqlcom = new SqlCommand();
            _sqlcom.Connection = _sqlcon;
            _sqlcom.CommandType = CommandType.StoredProcedure;

            if (istransaction)
                _sqlcom.Transaction = _sqltrn;
        }
        public  void CommitTransction()
        {
            if (_sqltrn != null)
                _sqltrn.Commit();
        }
        public  void RollBackTransction()
        {
            if (_sqltrn != null)
                _sqltrn.Rollback();
        }
        public  void ClearObjects()
        {
            if (_sqlcom != null)
            {
                if (_sqlcom.Parameters.Count != 0)
                    _sqlcom.Parameters.Clear();

                _sqlcom.Cancel();
                _sqlcom.Dispose();

                _sqlcom = null;
            }

            if (_sqltrn != null)
            {
                _sqltrn.Dispose();
                _sqltrn = null;
            }

            if (_sqlcon != null)
            {
                if (_sqlcon.State == ConnectionState.Open)
                    _sqlcon.Close();

                _sqlcon.Dispose();
                _sqlcon = null;
            }

            if (_output != null)
                _output = null;

            if (_paranames != null)
                _paranames = null;
        }
        
        /*public  Boolean SQLHelper_ExecuteNonQuery(string Procedure_Name, List<SqlParameter> parameters)
        {
            try
            {
                _result = false;
                _sqlcom.CommandText = Procedure_Name;
                SQLHelper.CreateParameters(parameters);
                _sqlcom.ExecuteNonQuery();
                SQLHelper.FillTable();
                _result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _result;
        }*/

        public  Object SQLHelper_ExecuteScalar(string Procedure_Name)
        {
            try
            {
                _value = null;
                _sqlcom.CommandText = Procedure_Name;
                _value = _sqlcom.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "SQLHelper_ExecuteScalar("+Procedure_Name+")", ex);
                throw ex;
            }

            return _value;
        }
        public  DataTable SQLHelper_ExecuteReader(string Procedure_Name)
        {
            DataTable _data = null;
            try
            {
                _data = null;
                _sqlcom.CommandText = Procedure_Name;
                SqlDataAdapter _adapter = new SqlDataAdapter(_sqlcom);
                DataSet dataset = new DataSet("SQLHelper");
                _adapter.Fill(dataset);
                _data = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "SQLHelper_ExecuteReader("+Procedure_Name+")", ex);
                throw ex;
            }

            return _data;
        }

        public  DataTable SQLHelper_OutputValues()
        {
            return _resultTable;
        }
        #endregion
        public DataTable ExecuteSelectMaster(String query)
        {
            try
            {
                _sqlcon = new SqlConnection(MasterConnectionValue);
                openConnection();
                _sqlcom = new SqlCommand(query, _sqlcon);
                SqlDataAdapter adapt = new SqlDataAdapter(_sqlcom);
                DataTable _resultTable = new DataTable();
                //if (_resultTable.DataSet != null) 
                adapt.Fill(_resultTable);
                return _resultTable;
            }
            catch (Exception ex)
            {
                //-2146232060   //database not found
                //-2146232060
                MyClass.Exception2LogFile(this.ToString(), string.Format("ExecuteSelect({0})", query), ex);
                closeConnection();
            }
            return null;
        }
        public string GetDefaultSQL_DataPath()
        {
            DataTable dt = ExecuteSelectMaster("SELECT physical_name FROM sys.database_files; ");
            if (dt != null && dt.Rows.Count > 0)
            {
                string path = dt.Rows[0][0].ToString();
                path = path.Substring(0, path.ToLower().IndexOf("master.mdf"));
                return path;
            }
            return "C:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.MSSQLSERVER\\MSSQL\\DATA\\";
        }
        public string getIP()
        {
            DataTable dt = ExecuteSelect("select CONVERT(char(15), connectionproperty('client_net_address'))");
            if (dt != null)
            {
                string ret = dt.Rows[0][0].ToString();
                if (ret.Length > 1)
                    return ret;
                else
                    return "localhost";
            }
            return "";
        }
        public bool updateFile(string fileName, string tableName, string fieldName, string version)
        {
            bool ret = false;
            try
            {
                string sqlText = "";
                if (fileName == null)
                {
                    sqlText += "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                               "SET [" + fieldName + "]= NULL," +
                               "[Version] = '0'";
                    ExecuteNonQuery(sqlText);
                }
                else
                {
                    sqlText += "UPDATE [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                               "SET [" + fieldName + "]= @file," +
                               "[Version] = '" + version + "'";
                    byte[] image1 = MyClass.File2ByteArray(fileName);
                    updateBytesArray(image1, sqlText, "@file");
                }
                ret = true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile(this.ToString(), string.Format("updateFile({0}, {1}, {2})", fileName, fieldName), ex);
                closeConnection();
            }
            return ret;
        }
        public bool updateBytesArray(byte[] bytes, string sqlText, string parameterName)
        {
            try
            {
                _sqlcom = new SqlCommand(sqlText, _sqlcon);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(parameterName, SqlDbType.Image);
                param[0].Value = bytes;
                openConnection();
                _sqlcom.Parameters.AddRange(param);
                _sqlcom.ExecuteNonQuery();
                _sqlcon.Close();
                return true;
            }
            catch (Exception ex)
            {
                MyClass.Exception2LogFile("SQLHelper", "updateBytesArray", ex);
                return false;
            }
        }
        public bool RestoreDatabase(string DBName, string restoreFileName, string destination)
        {
            _result = false;
            string sqlText = "";
            string restoreDBName = GetDBNameFromRestore(restoreFileName);
            if (!destination.EndsWith("\\"))
                destination += "\\";
            if (File.Exists(restoreFileName))
            {
                try
                {
                    sqlText = string.Format("RESTORE DATABASE [{0}] FROM  DISK = N'{1}' WITH  FILE = 1, MOVE N'{2}' TO N'{3}{0}.mdf', MOVE N'{2}_log' TO N'{3}{0}.ldf', NOUNLOAD, REPLACE, STATS = 10",
                              DBName, restoreFileName, restoreDBName, destination);
                    _result = ExecuteNonQueryMaster(sqlText);
                }
                catch (Exception ex)
                {
                    MyClass.Exception2LogFile(this.ToString(), string.Format("RestoreDatabase({0}, {1} , {2})", DBName, restoreFileName, sqlText), ex);
                    closeConnection();
                    if (ex.ToString().ToLower().IndexOf("database is in use") > 0)
                        MessageBox.Show("قاعدة البيانات موجودة مسبقاً. الرجاء اختيار اسم آخر لقاعدة البيانات");
                    else
                        MessageBox.Show("حدث خطأ ولم يتم استعادة قاعدة البيانات", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return _result;
        }

        public void fillCombobox(ComboBox cmb, string tableName, string fieldName, string condition)
        {
            string s = "SELECT DISTINCT " + fieldName +
                       " FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                       " WHERE " + fieldName + " <> ''";
            if (condition.Length > 0)
                s += " AND " + condition;
            DataTable dt = new DataTable();
            dt = ExecuteSelect(s);
            //s = "";
            if (dt != null)
            {
                cmb.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.Items.Add(dt.Rows[i][0]);
                }/*
                Object[] o = new Object[dt.Rows.Count];
                dt.Rows.CopyTo(o, 0);
                cmb.Items.AddRange(o);*/
            }
            //cmb.Items.AddRange(s.Split('|'));
        }
    }
}