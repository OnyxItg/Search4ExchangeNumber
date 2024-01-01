using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using MahClass;
using System.Drawing;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - FormSettingsDB
    //  Date            - 08/08/2019
    //  Contact mah4moud@gmail.com
    public partial class FormDBSettings : Form
    {
        string ConnectionString = "", MasterConnectionString = "", serverName = "";
        int progress = 0;
        public FormDBSettings()
        {
            InitializeComponent();
            this.RightToLeft = Program.RTL ? RightToLeft.Yes : RightToLeft.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /*if (this.Tag.Equals(1)) {
                this.Dispose();
            }
            else {
                Application.Exit();
            }*/
            Close();
        }
        private void CreateDataSourceConnectionString()
        {
            serverName = (comboBoxServerName.Text.Equals("الكمبيوتر المحلي") ? "localhost" : comboBoxServerName.Text);
            if (cbxIntegratedSecurity.Checked)
            {
                MasterConnectionString = "Data Source=" + serverName + ";Initial Catalog=master;Integrated Security=true";
            }
            else
            {
                MasterConnectionString = "Data Source=" + serverName + ";Initial Catalog=master;User ID=" + txtUserID.Text + ";Password=" + txtPassword.Text;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool inSec = DBSettings.getIntegratedSecurity();
                if (inSec)
                {

                }
                else
                {

                }
                int result = 1;// Convert.ToInt16(sqc.ExecuteScalar());

                if (result > 0)
                {
                    CreateDataSourceConnectionString();
                    
                    DBSettings.update(serverName, txtUserID.Text, txtPassword.Text);
                    string ConnectionValue = DBSettings.getConnectionString();
                    string MasterConnectionValue = DBSettings.getMasterConnectionString();
                    string ClientsConnectionValue = DBSettings.getClientsConnectionString();
                    Program.DBName = DBSettings.getDBName();
                    string clientsDBName = DBSettings.getClientsDBName();
                    SQLHelper.InitHelper(Program.DBName, clientsDBName, ConnectionValue, MasterConnectionValue, ClientsConnectionValue);

                    CreateDataSourceConnectionString();
                    SqlConnection conn = new SqlConnection(MasterConnectionString);
                    try
                    {
                        conn.Open();
                        Program.isServerConnected = true;
                    }
                    catch { Program.isServerConnected = false; }
                    this.Dispose();
                }
                else
                    MessageBox.Show("عذرا : اسم المستخدم او كلمة المرور خاطئة");
            }
            catch (SqlException ex)
            {
                MyClass.Exception2LogFile(this.ToString(), string.Format("btnOK_Click({0}, {1})", sender.ToString(), e.ToString()), ex);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CreateDataSourceConnectionString();
            SqlConnection conn = new SqlConnection(MasterConnectionString);
            try
            {
                conn.Open();
                btnTest.BackColor = Color.GreenYellow;
                Program.isServerConnected = true;
                MessageBox.Show("تم الاتصال بمخدم قاعدة البيانات بنجاح", "تأكيد الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                btnTest.BackColor = Color.IndianRed;
                Program.isServerConnected = false;
                MyClass.Exception2LogFile(this.ToString(), string.Format("btnTest_Click({0}, {1})", sender.ToString(), e.ToString()), ex);
                MessageBox.Show("خطأ في  الاتصال بمخدم قاعدة البيانات", "خطأ في الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxLocalPC_CheckedChanged(object sender, EventArgs e)
        {
            btnTest.BackColor = SystemColors.Control;
            if (cbxLocalPC.Checked == true)
            {
                comboBoxServerName.Text = "الكمبيوتر المحلي";
                comboBoxServerName.Enabled = btnRefreshServers.Enabled = false;
            }
            else
            {
                comboBoxServerName.Text = "";
                comboBoxServerName.Enabled = btnRefreshServers.Enabled = true;
            }
        }

        private void cbxIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            btnTest.BackColor = SystemColors.Control;
            if (cbxIntegratedSecurity.Checked == true)
            {  
                txtPassword.Text = "";
                txtUserID.Text = "";
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserID.Enabled = true;
                txtPassword.Enabled = true;
                txtUserID.Text = "sa";
            }
        }
        private void getServers()
        {
            comboBoxServerName.Items.Clear();
            comboBoxServerName.Items.Add(Environment.MachineName);
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in servers.Rows)
                if (!string.IsNullOrWhiteSpace(row["InstanceName"].ToString()))
                    comboBoxServerName.Items.Add(row["ServerName"].ToString()+"\\"+ row["InstanceName"].ToString());
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Icon = Program.formMain.Icon;
            
            cbxIntegratedSecurity.Checked = DBSettings.getIntegratedSecurity();
            cbxLocalPC.Checked = DBSettings.getLocalPC();

            if (cbxIntegratedSecurity.Checked)
            {
                txtUserID.Clear();
                txtPassword.Clear();
            }
            else
            {
                txtPassword.Text = DBSettings.getPassword();
                txtUserID.Text = DBSettings.getUserName();
                if (txtUserID.Text == "")
                    txtUserID.Text = "sa";
            }
            //if (!cbxLocalPC.Checked)
                // getServers();
            comboBoxServerName.Text = DBSettings.getServerName();
        }
        private void btnRefreshServers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            getServers();
            this.Cursor = Cursors.Default;
        }
        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            btnTest.BackColor = SystemColors.Control;
        }
    }
}
