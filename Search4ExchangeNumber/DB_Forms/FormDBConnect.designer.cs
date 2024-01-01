namespace Search4ExchangeNumber
{
    partial class FormDBConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDBConnect));
            this.gbxSqlServer5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.gbxDBName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefreshDBs = new System.Windows.Forms.Button();
            this.comboBoxDBName = new System.Windows.Forms.ComboBox();
            this.gbxUserInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbxIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.lblSqlServerUserID = new System.Windows.Forms.Label();
            this.lblSqlServerPassword = new System.Windows.Forms.Label();
            this.gbxServerName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefreshServers = new System.Windows.Forms.Button();
            this.cbxLocalPC = new System.Windows.Forms.CheckBox();
            this.comboBoxServerName = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbxSqlServer5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.gbxDBName.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbxUserInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxServerName.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSqlServer5
            // 
            this.gbxSqlServer5.Controls.Add(this.tableLayoutPanel4);
            this.gbxSqlServer5.Location = new System.Drawing.Point(6, 289);
            this.gbxSqlServer5.Name = "gbxSqlServer5";
            this.gbxSqlServer5.Size = new System.Drawing.Size(336, 62);
            this.gbxSqlServer5.TabIndex = 21;
            this.gbxSqlServer5.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(330, 43);
            this.tableLayoutPanel4.TabIndex = 28;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(24, 3);
            this.btnCancel.MinimumSize = new System.Drawing.Size(118, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 38);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "     إل&غاء الأمر";
            this.toolTip1.SetToolTip(this.btnCancel, "إلغاء الأمر");
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnOK.AutoSize = true;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(189, 3);
            this.btnOK.MinimumSize = new System.Drawing.Size(118, 38);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 38);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "    &موافق";
            this.toolTip1.SetToolTip(this.btnOK, "موافق");
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.btnTest, 2);
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnTest.Location = new System.Drawing.Point(3, 86);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(324, 27);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "ا&ختبار الاتصال";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // gbxDBName
            // 
            this.gbxDBName.AutoSize = true;
            this.gbxDBName.Controls.Add(this.tableLayoutPanel3);
            this.gbxDBName.Location = new System.Drawing.Point(6, 230);
            this.gbxDBName.Name = "gbxDBName";
            this.gbxDBName.Size = new System.Drawing.Size(336, 57);
            this.gbxDBName.TabIndex = 24;
            this.gbxDBName.TabStop = false;
            this.gbxDBName.Text = "اختر قاعدة بيانات من القائمة المنسدلة ليتم الاتصال بها";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btnRefreshDBs, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxDBName, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(330, 38);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // btnRefreshDBs
            // 
            this.btnRefreshDBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDBs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshDBs.BackgroundImage")));
            this.btnRefreshDBs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshDBs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDBs.Location = new System.Drawing.Point(3, 5);
            this.btnRefreshDBs.Name = "btnRefreshDBs";
            this.btnRefreshDBs.Size = new System.Drawing.Size(33, 28);
            this.btnRefreshDBs.TabIndex = 10;
            this.btnRefreshDBs.Click += new System.EventHandler(this.btnRefreshDBs_Click);
            // 
            // comboBoxDBName
            // 
            this.comboBoxDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDBName.FormattingEnabled = true;
            this.comboBoxDBName.Location = new System.Drawing.Point(42, 8);
            this.comboBoxDBName.Name = "comboBoxDBName";
            this.comboBoxDBName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxDBName.Size = new System.Drawing.Size(285, 21);
            this.comboBoxDBName.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboBoxDBName, "أسماء قواعد البيانات المتوفرة للاتصال الحالي");
            // 
            // gbxUserInfo
            // 
            this.gbxUserInfo.Controls.Add(this.tableLayoutPanel2);
            this.gbxUserInfo.Location = new System.Drawing.Point(6, 85);
            this.gbxUserInfo.Name = "gbxUserInfo";
            this.gbxUserInfo.Size = new System.Drawing.Size(336, 143);
            this.gbxUserInfo.TabIndex = 23;
            this.gbxUserInfo.TabStop = false;
            this.gbxUserInfo.Text = "بيانات المستخدم";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtUserID, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnTest, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbxIntegratedSecurity, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSqlServerUserID, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSqlServerPassword, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 124);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Location = new System.Drawing.Point(3, 26);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserID.Size = new System.Drawing.Size(219, 20);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "sa";
            this.toolTip1.SetToolTip(this.txtUserID, "اسم مستخدم سيكوال سيرفر");
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(3, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPassword, "كلمة مرور مستخدم سيكوال سيرفر");
            this.txtPassword.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // cbxIntegratedSecurity
            // 
            this.cbxIntegratedSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxIntegratedSecurity.AutoSize = true;
            this.cbxIntegratedSecurity.Location = new System.Drawing.Point(3, 3);
            this.cbxIntegratedSecurity.Name = "cbxIntegratedSecurity";
            this.cbxIntegratedSecurity.Size = new System.Drawing.Size(219, 17);
            this.cbxIntegratedSecurity.TabIndex = 4;
            this.cbxIntegratedSecurity.Text = "&دخول باستخدام مصادقة نظام";
            this.cbxIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbxIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbxIntegratedSecurity_CheckedChanged);
            // 
            // lblSqlServerUserID
            // 
            this.lblSqlServerUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSqlServerUserID.Location = new System.Drawing.Point(228, 24);
            this.lblSqlServerUserID.Name = "lblSqlServerUserID";
            this.lblSqlServerUserID.Size = new System.Drawing.Size(99, 23);
            this.lblSqlServerUserID.TabIndex = 0;
            this.lblSqlServerUserID.Text = "اسم المستخدم:";
            this.lblSqlServerUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSqlServerPassword
            // 
            this.lblSqlServerPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSqlServerPassword.Location = new System.Drawing.Point(228, 50);
            this.lblSqlServerPassword.Name = "lblSqlServerPassword";
            this.lblSqlServerPassword.Size = new System.Drawing.Size(99, 23);
            this.lblSqlServerPassword.TabIndex = 1;
            this.lblSqlServerPassword.Text = "كـلـمــة الـمــرور:";
            this.lblSqlServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxServerName
            // 
            this.gbxServerName.Controls.Add(this.tableLayoutPanel1);
            this.gbxServerName.Location = new System.Drawing.Point(6, 5);
            this.gbxServerName.Name = "gbxServerName";
            this.gbxServerName.Size = new System.Drawing.Size(336, 84);
            this.gbxServerName.TabIndex = 22;
            this.gbxServerName.TabStop = false;
            this.gbxServerName.Text = "اسم المخدم";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshServers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxLocalPC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxServerName, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 65);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // btnRefreshServers
            // 
            this.btnRefreshServers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshServers.BackgroundImage")));
            this.btnRefreshServers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshServers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshServers.Location = new System.Drawing.Point(3, 26);
            this.btnRefreshServers.Name = "btnRefreshServers";
            this.btnRefreshServers.Size = new System.Drawing.Size(33, 29);
            this.btnRefreshServers.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnRefreshServers, "تحديث أسماء مخدمات سيكوال سيرفر المتوفرة");
            this.btnRefreshServers.Click += new System.EventHandler(this.btnRefreshServers_Click);
            // 
            // cbxLocalPC
            // 
            this.cbxLocalPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLocalPC.AutoSize = true;
            this.cbxLocalPC.Location = new System.Drawing.Point(42, 3);
            this.cbxLocalPC.Name = "cbxLocalPC";
            this.cbxLocalPC.Size = new System.Drawing.Size(285, 17);
            this.cbxLocalPC.TabIndex = 5;
            this.cbxLocalPC.Text = "ا&ستخدام الكمبيوتر المحلي";
            this.cbxLocalPC.UseVisualStyleBackColor = true;
            this.cbxLocalPC.CheckedChanged += new System.EventHandler(this.cbxLocalPC_CheckedChanged);
            // 
            // comboBoxServerName
            // 
            this.comboBoxServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxServerName.FormattingEnabled = true;
            this.comboBoxServerName.Location = new System.Drawing.Point(42, 33);
            this.comboBoxServerName.Name = "comboBoxServerName";
            this.comboBoxServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxServerName.Size = new System.Drawing.Size(285, 21);
            this.comboBoxServerName.TabIndex = 8;
            this.toolTip1.SetToolTip(this.comboBoxServerName, "أسماء سيرفرات سيكوال سيرفر المتوفرة");
            this.comboBoxServerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxServerName_SelectedIndexChanged);
            this.comboBoxServerName.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.comboBoxServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxServerName_KeyDown);
            // 
            // FormDBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 356);
            this.Controls.Add(this.gbxDBName);
            this.Controls.Add(this.gbxUserInfo);
            this.Controls.Add(this.gbxServerName);
            this.Controls.Add(this.gbxSqlServer5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDBConnect";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الاتصال بقاعدة بيانات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.SizeChanged += new System.EventHandler(this.FormDBConnect_SizeChanged);
            this.gbxSqlServer5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.gbxDBName.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbxUserInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbxServerName.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbxSqlServer5;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.GroupBox gbxDBName;
        internal System.Windows.Forms.GroupBox gbxUserInfo;
        private System.Windows.Forms.CheckBox cbxIntegratedSecurity;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Label lblSqlServerPassword;
        internal System.Windows.Forms.Label lblSqlServerUserID;
        internal System.Windows.Forms.GroupBox gbxServerName;
        private System.Windows.Forms.CheckBox cbxLocalPC;
        internal System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox comboBoxDBName;
        private System.Windows.Forms.ComboBox comboBoxServerName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        internal System.Windows.Forms.Button btnRefreshServers;
        internal System.Windows.Forms.Button btnRefreshDBs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}