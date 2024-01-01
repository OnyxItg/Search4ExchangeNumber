using MahClass;
using String_Cipher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search4ExchangeNumber
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - FormLogin
    //  Date            - 22/07/2020
    //  Contact mah4moud@gmail.com
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.RightToLeft = Program.RTL ? RightToLeft.Yes : RightToLeft.No;
            loadLanguage();
        }
        private void loadLanguage()
        {

        }

        public void BtnOk_Click(object sender, EventArgs e)
        {
            ///*Close();
            ///*return;
            comboUser.Text = "admin";
            if (txtpassword.Text.Length == 0)
            {
                MyClass.Message("أدخل كلمة المرور من فضلك");
                txtpassword.Focus();
                //DialogResult = DialogResult.Cancel;
                return;
            }

            if (comboUser.Text == "admin")
            {
                string password = "0.";

                if (password == txtpassword.Text)
                {
                    DialogResult = DialogResult.OK;
                    Program.ok = true;
                    this.Close();
                }
                else
                {
                    Program.ok = false; 
                    MyClass.Message("كلمة المرور غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Select();
                    /// DialogResult = DialogResult.Cancel;
                }
            }
            ///this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Program.ok = false;
            //Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            ///this.TopMost = GeneralSettings.getAlwaysOnTop();
            string ConnectionValue = DBSettings.getConnectionString();
            string MasterConnectionValue = DBSettings.getMasterConnectionString();
            string clientsConnectionValue = DBSettings.getConnectionString();
            Program.DBName = DBSettings.getDBName();
            string clientsDBName = DBSettings.getClientsDBName();

            if (Program.DBName != "" && ConnectionValue != "")
            {
                SQLHelper.InitHelper(Program.DBName, clientsDBName, ConnectionValue, MasterConnectionValue, clientsConnectionValue);
                
                comboUser.Select();
            }
            else
            {
                SQLHelper.MasterConnectionValue = MasterConnectionValue;
            }
            Program.isDBConnected = (comboUser.DataSource != null);
            if (System.Diagnostics.Debugger.IsAttached)
            {
                if (comboUser.Text == "admin")
                    txtpassword.Text = "0.";
                else
                    txtpassword.Text = "123";
                BtnOk.Select();
                ///BtnOk_Click(null, null);
            }
            else
            {
                if (!Program.isDBConnected)
                {
                    comboUser.Text = "admin";
                }
                txtpassword.Text = "";
                comboUser.Select();
            }
            txtpassword.Select();
        }

        private void comboUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtpassword.Select();
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnOk.Select();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                Program.ok = false;
        }
    }
}
