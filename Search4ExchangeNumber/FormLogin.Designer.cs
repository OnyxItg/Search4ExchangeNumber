namespace Search4ExchangeNumber
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.PictureBoxLogin = new System.Windows.Forms.PictureBox();
            this.LabelHeader = new System.Windows.Forms.Label();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).BeginInit();
            this.GroupBoxMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxLogin
            // 
            this.PictureBoxLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogin.BackgroundImage")));
            this.PictureBoxLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBoxLogin.Location = new System.Drawing.Point(323, 8);
            this.PictureBoxLogin.Name = "PictureBoxLogin";
            this.PictureBoxLogin.Size = new System.Drawing.Size(48, 56);
            this.PictureBoxLogin.TabIndex = 6;
            this.PictureBoxLogin.TabStop = false;
            // 
            // LabelHeader
            // 
            this.LabelHeader.AutoEllipsis = true;
            this.LabelHeader.BackColor = System.Drawing.Color.Transparent;
            this.LabelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LabelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LabelHeader.Image = ((System.Drawing.Image)(resources.GetObject("LabelHeader.Image")));
            this.LabelHeader.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelHeader.Location = new System.Drawing.Point(0, 0);
            this.LabelHeader.Name = "LabelHeader";
            this.LabelHeader.Size = new System.Drawing.Size(383, 68);
            this.LabelHeader.TabIndex = 5;
            this.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelHeader.UseMnemonic = false;
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.GroupBoxMain.Controls.Add(this.tableLayoutPanel1);
            this.GroupBoxMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBoxMain.Location = new System.Drawing.Point(8, 67);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(368, 134);
            this.GroupBoxMain.TabIndex = 0;
            this.GroupBoxMain.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.comboUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtpassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelUserName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelPassword, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 112);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboUser
            // 
            this.comboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboUser.Enabled = false;
            this.comboUser.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(3, 15);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(272, 26);
            this.comboUser.TabIndex = 0;
            this.comboUser.Text = "admin";
            this.comboUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboUser_KeyPress);
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpassword.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtpassword.ForeColor = System.Drawing.Color.Red;
            this.txtpassword.Location = new System.Drawing.Point(3, 72);
            this.txtpassword.MaxLength = 30;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpassword.Size = new System.Drawing.Size(272, 24);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.Text = "admin";
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // LabelUserName
            // 
            this.LabelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelUserName.Location = new System.Drawing.Point(281, 0);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(78, 56);
            this.LabelUserName.TabIndex = 0;
            this.LabelUserName.Text = "اسم المستخدم";
            this.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelPassword
            // 
            this.LabelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelPassword.Location = new System.Drawing.Point(281, 56);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(78, 56);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "كلمة المرور";
            this.LabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.Image = global::Search4ExchangeNumber.Properties.Resources.close_window_35px;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnClose.Location = new System.Drawing.Point(32, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnClose.Size = new System.Drawing.Size(118, 37);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "إل&غاء الأمر";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOk.Image = global::Search4ExchangeNumber.Properties.Resources.checkmark_25px;
            this.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnOk.Location = new System.Drawing.Point(214, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnOk.Size = new System.Drawing.Size(118, 37);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "&موافق";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(8, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnClose, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnOk, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // FormLogin
            // 
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(383, 264);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureBoxLogin);
            this.Controls.Add(this.LabelHeader);
            this.Controls.Add(this.GroupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تسجيل الدخول";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).EndInit();
            this.GroupBoxMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBoxLogin;
        internal System.Windows.Forms.Label LabelHeader;
        internal System.Windows.Forms.GroupBox GroupBoxMain;
        internal System.Windows.Forms.Button BtnClose;
        internal System.Windows.Forms.Button BtnOk;
        internal System.Windows.Forms.TextBox txtpassword;
        internal System.Windows.Forms.Label LabelPassword;
        public System.Windows.Forms.ComboBox comboUser;
        internal System.Windows.Forms.Label LabelUserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}