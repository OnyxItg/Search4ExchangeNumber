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
    //  Class           - SQL Helper
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class TableVisits
    {
        SQLHelper sqlVisits = new SQLHelper();
        DataTable dtVisits = new DataTable();
        DataRow dataRow = null;
        int rowCount = 0;
        private int _rowIndex = 0;
        private string dbName = "", SchemaName = "", tableName = "Visits";
        private string sqlSELECT = "";
        public TableVisits()
        {
            
        }
        public void setConnectionString()
        {
            this.dbName = SQLHelper.dbName;
            SchemaName = SQLHelper.identitySchemaName;
            tableName = SQLHelper.VisitsTableName;
            sqlVisits.SetConnectionString();
            sqlSELECT = "SELECT [ID], [IdentityID], [UserName] AS [المستخدم]" +
                        ", [ComputerName] AS [الحاسب], [ComputerIP] AS [IP]" +
                        ", CONVERT(VARCHAR, [DateVisited], 111) AS [تاريخ الزيارة] " +
                        ", CONVERT(VARCHAR, [DateVisited], 24) AS [وقت الزيارة] " +
                        ", [Notes] " +
                        "FROM [" + dbName + "].[" + SchemaName + "].[" + tableName + "] ";
        }
        public DataTable openTable()
        {
            dtVisits = sqlVisits.ExecuteSelect(sqlSELECT);
            dataRow = dtVisits.Rows[_rowIndex];
            return dtVisits;
        }
        public DataTable openTable(string whereStatement)
        {
            dtVisits = sqlVisits.ExecuteSelect(sqlSELECT+whereStatement);
            return dtVisits;
        }
        public int getRowCount()
        {
            rowCount = dtVisits.Rows.Count;
            return rowCount;
        }
        public DataTable search4User(string userName)
        {
            dtVisits = openTable(" WHERE [UserName]=" + userName + "");//sqlIdentity.ExecuteSelect(sqlSELECT+ " WHERE [IdentityID]='" + ID+"'");
            return dtVisits;
        }
        public bool IsIdentityIDExist(string identityID)
        {
            return sqlVisits.IsValueExists("'" + identityID + "'", "[IdentityID]", "[" + dbName + "].[" + SchemaName + "].[" + tableName + "]");
        }
        public bool AddVisit(string IdentityID, string UserName, string ComputerName, string ComputerIP, string Notes)
        {
            string dateModifiedS = DateTime.MinValue.AddDays(1).ToString("MM-dd-yyyy HH:mm:ss");
            Guid guid = Guid.NewGuid();
            string ID = guid.ToString();
            return sqlVisits.ExecuteInsert_Update(
                      "INSERT INTO [" + dbName + "].[" + SchemaName + "].[" + tableName + "] " +
                      "([ID]           " +
                      ",[IdentityID]   " +
                      ",[UserName]     " +
                      ",[ComputerName] " +
                      ",[ComputerIP]   " +
                      ",[DateVisited] " +
                      ",[Notes]) " +
                      "VALUES('" + ID + "', '" + IdentityID +"', '" + UserName + "', '" + ComputerName + "', '" + ComputerIP + "', GETDATE(), '" + Notes + "')");
        }
        public void setRowIndex(int rowIndex)
        {
            _rowIndex = rowIndex;
        }
        public string getID()
        {
            if (dtVisits.Rows.Count > 0)
                return dtVisits.Rows[_rowIndex]["ID"].ToString();
            else
                return "";
        }
        public string getUserName()
        {
            if (dtVisits.Rows.Count > 0)
                return dtVisits.Rows[_rowIndex]["UserName"].ToString();
            else
                return "";
        }
        public string getComputerName()
        {
            if (dtVisits.Rows.Count > 0)
                return dtVisits.Rows[_rowIndex]["ComputerName"].ToString();
            else
                return null;
        }
        public string getDateModified()
        {
            if (dtVisits.Rows.Count > 0)
                return dtVisits.Rows[_rowIndex]["DateVisited"].ToString();
            else
                return null;
        }
        public string getNotes()
        {
            if (dtVisits.Rows.Count > 0)
                return dtVisits.Rows[_rowIndex]["Notes"].ToString();
            else
                return "";
        }
        public void goNext()
        {
            //dtIdentity.Rows.[++_rowIndex];
        }
    }
}
