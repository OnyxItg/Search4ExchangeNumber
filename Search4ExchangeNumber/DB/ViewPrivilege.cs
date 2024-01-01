using System;
using System.Data;

namespace OnyxSmartIDReader
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - ViewPrivilege
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    class ViewPrivilege
    {
        SQLHelper sqlPrivilege = new SQLHelper();
        DataTable dtPrivilege = new DataTable();
        DataRow dataRow = null;
        int rowCount = 0;
        private int _rowIndex = 0;
        private string dbName = "", SchemaName = "", viewName = "View_Privileges";

        private string sqlSELECT = "";
        public ViewPrivilege()
        {
            
        }
        public void setConnectionString()
        {
            this.dbName = SQLHelper.dbName;
            SchemaName = SQLHelper.identitySchemaName;
            viewName = "View_Privileges";// SQLHelper.photosTableName;
            sqlPrivilege.SetConnectionString();
            sqlSELECT = "SELECT * "+
                        "FROM [" + dbName + "].[" + SchemaName + "].[" + viewName + "] ";
        }
        public DataTable openView()
        {
            dtPrivilege = sqlPrivilege.ExecuteSelect(sqlSELECT);
            dataRow = dtPrivilege.Rows[_rowIndex];
            return dtPrivilege;
        }
        public DataTable openView(string whereStatement)
        {
            dtPrivilege = sqlPrivilege.ExecuteSelect(sqlSELECT+" "+whereStatement);
            return dtPrivilege;
        }
        public int getRowCount()
        {
            rowCount = dtPrivilege.Rows.Count;
            return rowCount;
        }
        public int getUserPrivilege(string userName, string privilege)
        {
            if (dtPrivilege != null)
            for (int i = 0; i < dtPrivilege.Rows.Count; i++)
            {
                if (dtPrivilege.Rows[i]["UserName"].ToString().Equals(userName))
                {
                    if (dtPrivilege.Rows[i]["Privilege"].ToString().Equals(privilege))
                        return Convert.ToInt32(dtPrivilege.Rows[i]["Status"]);
                }
            }
            return 0;
        }
        public bool Update(string data)
        { 
            return sqlPrivilege.UpdatePrivileges(data);
        }
        public string getFieldByName(string fieldName)
        {
            if (dtPrivilege.Rows.Count > 0)
            {
                return dtPrivilege.Rows[_rowIndex][fieldName].ToString();
            }
            else
                return "";
        }
    }
}
