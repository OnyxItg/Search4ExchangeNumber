using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MahClass;
using System.Drawing;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - FormDBConnect
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    public partial class FormDBConnect : Form
    {
        string ConnectionString = "", MasterConnectionString = "", serverName = "";
        public FormDBConnect()
        {
            InitializeComponent();
            this.RightToLeft = Program.RTL ? RightToLeft.Yes : RightToLeft.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CreateDataSourceConnectionString()
        {
            serverName = (comboBoxServerName.Text.Equals("الكمبيوتر المحلي") ? "localhost" : comboBoxServerName.Text);
            if (cbxIntegratedSecurity.Checked)
            {
                ConnectionString = "Data Source=" + serverName + ";Initial Catalog=" + comboBoxDBName.Text + ";Integrated Security=true";
                MasterConnectionString = "Data Source=" + serverName + ";Initial Catalog=master;Integrated Security=true";
            }
            else
            {
                ConnectionString = "Data Source=" + serverName + ";Initial Catalog=" + comboBoxDBName.Text + ";User ID=" + txtUserID.Text + ";Password=" + txtPassword.Text;
                MasterConnectionString = "Data Source=" + serverName + ";Initial Catalog=master;User ID=" + txtUserID.Text + ";Password=" + txtPassword.Text;
            }
            //return ConnectionString;
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
                    string user = (txtUserID.Text == "" ? "-1" : txtUserID.Text);
                    string password = (txtPassword.Text == "" ? "-1" : txtPassword.Text);
                    CreateDataSourceConnectionString();
                    if (Tag.ToString() == "db")
                        DBSettings.update(serverName, comboBoxDBName.Text, user, password, "", "");
                    else
                        DBSettings.updateDBClientsName(comboBoxDBName.Text);
                    
                    DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                    MessageBox.Show("كلمة مرور خاطئة");
                //sqn.Close();

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
                MyClass.Message("تم الاتصال بنجاح", "تأكيد الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                btnTest.BackColor = Color.IndianRed;
                MyClass.Exception2LogFile(this.ToString(), string.Format("btnTest_Click({0}, {1})", sender.ToString(), e.ToString()), ex);
                MyClass.Message("خطأ في الاتصال بالخادم", "خطا في الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxLocalPC_CheckedChanged(object sender, EventArgs e)
        {
            btnTest.BackColor = SystemColors.Control;
            if (cbxLocalPC.Checked == true)
            {
                comboBoxServerName.Text = "الكمبيوتر المحلي";
                comboBoxServerName.Enabled = btnRefreshServers.Enabled = false;
                //getDatabases();
            }
            else
            {
                comboBoxServerName.Text = "";
                comboBoxServerName.Enabled = btnRefreshServers.Enabled = true;
                //getServers();
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
        {/*
            string[] s = SqlLocator.GetServers();
            if (s != null && s.Length > 0)
            foreach (var item in s)
            {
                comboBoxServerName.Items.Add(item);
            }*/
        }

        private void comboBoxServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getDatabases();
        }

        private void comboBoxServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getDatabases();
        }

        private void FormDBConnect_SizeChanged(object sender, EventArgs e)
        {
            //gbxSqlServer5.Width = gbxSqlServer3.Width;
        }

        private void btnRefreshServers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            getServers();
            this.Cursor = Cursors.Default;
        }

        private void btnRefreshDBs_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Tag.ToString() == "db")
                getDatabases();
            else
                getNamesDatabases();
            this.Cursor = Cursors.Default;
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            btnTest.BackColor = SystemColors.Control;
        }

        private void getDatabases()
        {
            comboBoxDBName.Items.Clear();
            //comboBoxDBName.Items.Add("IDReaderPro");
            CreateDataSourceConnectionString();
            string[] databases = SQLHelper.GetDatabases(MasterConnectionString).Split('|');
            for (int i = 0; i < databases.Length; i++)
            {
                if (databases[i].Length > 0)
                    comboBoxDBName.Items.Add(databases[i]);
            }
            if (comboBoxDBName.Items.Count > 0)
                comboBoxDBName.SelectedIndex = 0;
        }
        private void getNamesDatabases()
        {
            comboBoxDBName.Items.Clear();
            //comboBoxDBName.Items.Add("IDReaderPro");
            CreateDataSourceConnectionString();
            string[] databases = SQLHelper.GetNameDatabases(MasterConnectionString).Split('|');
            for (int i = 0; i < databases.Length; i++)
            {
                if (databases[i].Length > 0)
                    comboBoxDBName.Items.Add(databases[i]);
            }
            if (comboBoxDBName.Items.Count > 0)
                comboBoxDBName.SelectedIndex = 0;
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Icon = Program.formMain.Icon;
            ///this.TopMost = GeneralSettings.getAlwaysOnTop();

            comboBoxServerName.Text = DBSettings.getServerName();

            cbxIntegratedSecurity.Checked = DBSettings.getIntegratedSecurity() || !Program.isDBConnected;

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
            }
            if (Tag.ToString() == "db")
            {
                //**getDatabases();
                comboBoxDBName.Text = DBSettings.getDBName();
                /*else
                    getDatabases();*/
            }
            else if (Tag.ToString() == "dbNames")
            {
                comboBoxDBName.Text = DBSettings.getClientsDBName();
            }
        }
    }
}
