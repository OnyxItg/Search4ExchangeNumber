namespace Search4ExchangeNumber
{
    partial class FormDBSettings
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
            this.gbxSqlServer5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbxUserInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSqlServerPassword = new System.Windows.Forms.Label();
            this.lblSqlServerUserID = new System.Windows.Forms.Label();
            this.gbxServerName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxLocalPC = new System.Windows.Forms.CheckBox();
            this.btnRefreshServers = new System.Windows.Forms.Button();
            this.comboBoxServerName = new System.Windows.Forms.ComboBox();
            this.gbxSqlServer5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxUserInfo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.gbxServerName.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSqlServer5
            // 
            this.gbxSqlServer5.Controls.Add(this.tableLayoutPanel2);
            this.gbxSqlServer5.Location = new System.Drawing.Point(6, 218);
            this.gbxSqlServer5.Name = "gbxSqlServer5";
            this.gbxSqlServer5.Size = new System.Drawing.Size(336, 62);
            this.gbxSqlServer5.TabIndex = 21;
            this.gbxSqlServer5.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Search4ExchangeNumber.Properties.Resources.close_window_35px;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(24, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "     إل&غاء الأمر";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::Search4ExchangeNumber.Properties.Resources.checkmark_25px;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(189, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 37);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "     &موافق";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbxUserInfo
            // 
            this.gbxUserInfo.Controls.Add(this.tableLayoutPanel4);
            this.gbxUserInfo.Location = new System.Drawing.Point(6, 84);
            this.gbxUserInfo.Name = "gbxUserInfo";
            this.gbxUserInfo.Size = new System.Drawing.Size(336, 131);
            this.gbxUserInfo.TabIndex = 23;
            this.gbxUserInfo.TabStop = false;
            this.gbxUserInfo.Text = "بيانات المستخدم";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cbxIntegratedSecurity, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnTest, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtUserID, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblSqlServerPassword, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblSqlServerUserID, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(330, 112);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // cbxIntegratedSecurity
            // 
            this.cbxIntegratedSecurity.AutoSize = true;
            this.cbxIntegratedSecurity.Location = new System.Drawing.Point(64, 3);
            this.cbxIntegratedSecurity.Name = "cbxIntegratedSecurity";
            this.cbxIntegratedSecurity.Size = new System.Drawing.Size(158, 17);
            this.cbxIntegratedSecurity.TabIndex = 4;
            this.cbxIntegratedSecurity.Text = "&دخول باستخدام مصادقة نظام";
            this.cbxIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbxIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbxIntegratedSecurity_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.btnTest, 2);
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnTest.Location = new System.Drawing.Point(3, 75);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(324, 34);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "ا&ختبار الاتصال";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Location = new System.Drawing.Point(3, 27);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserID.Size = new System.Drawing.Size(219, 20);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "sa";
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(3, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // lblSqlServerPassword
            // 
            this.lblSqlServerPassword.Location = new System.Drawing.Point(228, 48);
            this.lblSqlServerPassword.Name = "lblSqlServerPassword";
            this.lblSqlServerPassword.Size = new System.Drawing.Size(99, 23);
            this.lblSqlServerPassword.TabIndex = 1;
            this.lblSqlServerPassword.Text = "كـلـمــة الـمــرور:";
            this.lblSqlServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSqlServerUserID
            // 
            this.lblSqlServerUserID.Location = new System.Drawing.Point(228, 24);
            this.lblSqlServerUserID.Name = "lblSqlServerUserID";
            this.lblSqlServerUserID.Size = new System.Drawing.Size(99, 23);
            this.lblSqlServerUserID.TabIndex = 0;
            this.lblSqlServerUserID.Text = "اسم المستخدم:";
            this.lblSqlServerUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxServerName
            // 
            this.gbxServerName.Controls.Add(this.tableLayoutPanel6);
            this.gbxServerName.Location = new System.Drawing.Point(6, 4);
            this.gbxServerName.Name = "gbxServerName";
            this.gbxServerName.Size = new System.Drawing.Size(336, 78);
            this.gbxServerName.TabIndex = 22;
            this.gbxServerName.TabStop = false;
            this.gbxServerName.Text = "اسم المخدم";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.cbxLocalPC, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRefreshServers, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxServerName, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(330, 59);
            this.tableLayoutPanel6.TabIndex = 26;
            // 
            // cbxLocalPC
            // 
            this.cbxLocalPC.AutoSize = true;
            this.cbxLocalPC.Location = new System.Drawing.Point(179, 3);
            this.cbxLocalPC.Name = "cbxLocalPC";
            this.cbxLocalPC.Size = new System.Drawing.Size(148, 17);
            this.cbxLocalPC.TabIndex = 5;
            this.cbxLocalPC.Text = "ا&ستخدام الكمبيوتر المحلي";
            this.cbxLocalPC.UseVisualStyleBackColor = true;
            this.cbxLocalPC.CheckedChanged += new System.EventHandler(this.cbxLocalPC_CheckedChanged);
            // 
            // btnRefreshServers
            // 
            this.btnRefreshServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshServers.BackgroundImage = global::Search4ExchangeNumber.Properties.Resources.sync_20px;
            this.btnRefreshServers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshServers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshServers.Location = new System.Drawing.Point(3, 26);
            this.btnRefreshServers.Name = "btnRefreshServers";
            this.btnRefreshServers.Size = new System.Drawing.Size(33, 30);
            this.btnRefreshServers.TabIndex = 10;
            this.btnRefreshServers.Click += new System.EventHandler(this.btnRefreshServers_Click);
            // 
            // comboBoxServerName
            // 
            this.comboBoxServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxServerName.FormattingEnabled = true;
            this.comboBoxServerName.Location = new System.Drawing.Point(42, 30);
            this.comboBoxServerName.Name = "comboBoxServerName";
            this.comboBoxServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxServerName.Size = new System.Drawing.Size(285, 21);
            this.comboBoxServerName.TabIndex = 8;
            this.comboBoxServerName.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // FormDBSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 285);
            this.Controls.Add(this.gbxUserInfo);
            this.Controls.Add(this.gbxServerName);
            this.Controls.Add(this.gbxSqlServer5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDBSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إنشاء قاعدة بيانات جديدة";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.gbxSqlServer5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbxUserInfo.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.gbxServerName.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbxSqlServer5;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.GroupBox gbxUserInfo;
        private System.Windows.Forms.CheckBox cbxIntegratedSecurity;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Label lblSqlServerPassword;
        internal System.Windows.Forms.Label lblSqlServerUserID;
        internal System.Windows.Forms.GroupBox gbxServerName;
        private System.Windows.Forms.CheckBox cbxLocalPC;
        internal System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox comboBoxServerName;
        internal System.Windows.Forms.Button btnRefreshServers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
    }
}