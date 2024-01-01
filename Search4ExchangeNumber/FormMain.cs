using MahClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Search4ExchangeNumber
{
    public partial class FormMain : Form
    {
        SQLHelper sQLHelper = new SQLHelper();
        private decimal StartRecNo = 1, rowsCount = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            jj();
            radioBtnAll.Checked = true;
            dateTimePickerTo.Value = DateTime.Now;
            dateTimePickerFrom.Value = DateTime.Now;//.AddMonths(-1);
        }
        private void jj()
        {
            string sql = //"SELECT '111DFCB7-0EA5-4331-ABDA-85E7BB6DC3EA' AS rowguid, 'SYRHAM99' AS BRS_BR_Code,-1 AS BRS_Code,'' AS BRS_Staff,'','',1,'',99 " +
                         //" UNION " +
                         " SELECT [rowguid] " +
                         " ,[BRS_Staff] " +
                         //" ,[BRS_BR_Code] " +
                         //" ,[BRS_Code] " +
                         //" ,[BRS_Title] " +
                         //" ,[BRS_Login] " +
                         //" ,[BRS_Active] " +
                         //" ,[BRS_BRCN_Code] " +
                         //" ,[BRS_MaxSessionAllowed] " +
                         " FROM [" + comboDatabase.Text + "].[dbo].[BranchStaff] " +
                         " where BRS_BR_Code = 'syrham99' AND BRS_Staff != 'Administrator' AND BRS_Active = 1" +
                         " ORDER BY [BRS_Code]";
            comboBox1.DataSource = sQLHelper.ExecuteSelect(sql);
            comboBox1.DisplayMember = "BRS_Staff";
            comboBox1.ValueMember = "rowguid";
            //if (comboBox1.Items.Count > 0)
                //comboBox1.SelectedValue = "9505CF7E-08E5-437D-95D6-A9FF36F6FA5A";
            comboBox1.Text = "خالد الحايك";
        }
        private void search()
        {
            string select = " SELECT \n";
            //"TOP 100 " +
            select += tabControl1.SelectedIndex == 0 ? " CASE WHEN [MTTS_TypeText] IS NULL THEN CONVERT(bit, 0) ELSE CONVERT(bit, 1) END AS [وضع الحوالة],\n" : " CONVERT(bit, 1) AS [وضع الحوالة],";
            //"MTO_No, " +
            select += " MTO_CargoReceiptNo as [رقم إشعار الشحن],\n";
            if (tabControl1.SelectedIndex == 0)
            {
                select += " MTO_Benefactor as [المرسل],\n" +
                          " dbo.MoneyTransferOrder.MTO_Beneficiary as [المرسل إليه],\n";
            }
            else
            {
                select += " dbo.MoneyTransferOrder.MTO_Beneficiary as [المرسل إليه],\n" +
                          " MTO_Benefactor as [المرسل],\n";
            }
            select +=       " MTO_No as [رقم الحوالة],\n" +
                            " CONVERT(INT, MTO_Amount) as [المبلغ],\n" +
                            " CONVERT(VARCHAR, MTO_IssueDateTime, 111) as [تاريخ الإصدار],\n" +
                            " CONVERT(VARCHAR, MTO_IssueDateTime, 108) as [وقت الإصدار],\n";
            select += tabControl1.SelectedIndex == 0 ? " [BR_ABranch] as [الوجهة],\n" : " [BR_ABranch] as [المصدر],\n";
            select +=       " [BRS_Staff] as [الصندوق]\n";
            string from =   " FROM dbo.MoneyTransferOrder\n" +
                            " INNER JOIN dbo.Branch  ON dbo.Branch.BR_Code = dbo.MoneyTransferOrder.MTO_BR_Code_D\n" +
                            " INNER JOIN dbo.[BranchStaff] on dbo.[BranchStaff].BRS_BR_Code = dbo.MoneyTransferOrder.MTO_BR_Code_S AND dbo.[BranchStaff].BRS_Code = dbo.MoneyTransferOrder.MTO_IssuedBy\n";
            from += tabControl1.SelectedIndex == 0 ? " LEFT JOIN [dbo].[MoneyTransferTransactionSource]      ON [dbo].[MoneyTransferTransactionSource].MTTS_MTO_No      = dbo.MoneyTransferOrder.MTO_No\n" :
                                                     " LEFT JOIN [dbo].[MoneyTransferTransactionDestination] ON [dbo].[MoneyTransferTransactionDestination].MTTD_MTO_No = dbo.MoneyTransferOrder.MTO_No\n";

            string w = "";
            if (tabControl1.SelectedIndex == 0 && comboBox1.SelectedIndex > 0)
                w = " WHERE [BRS_Staff] = '"+comboBox1.Text + "'";
            else
            if (tabControl1.SelectedIndex == 1 && comboDatabase.SelectedIndex > 0)
                w = " WHERE [MTTD_MTO_BR_Code_D] = '" + comboDatabase.Text + "'";
            string wh = "";

            if (radioBtnCashed.Checked) wh += " [MTTS_TypeText] IS NOT NULL |";
            else
            if (radioBtnNotCashed.Checked) wh += " [MTTS_TypeText] IS NULL |";
            if (txtSender.Text != "")
            {
                wh += sQLHelper.search4Name("MTO_Benefactor", txtSender.Text, false, "", -1)+" |";
            }
            if (txtRecipient.Text != "")
            {
                wh += sQLHelper.search4Name("MTO_Beneficiary", txtRecipient.Text, false, "", -1)+" |";
            }
            if (txtFindReturnd.Text != "")
            {
                wh += "(" +sQLHelper.search4Name("MTO_Benefactor", txtFindReturnd.Text, false, "", -1) + " OR " +
                      sQLHelper.search4Name("MTO_Beneficiary", txtFindReturnd.Text, false, "", -1) + ") |";
            }
            if (checkBox1.Checked)
            {
                wh += string.Format(" MTO_IssueDateTime BETWEEN '{0}' AND '{1}' |", dateTimePickerFrom.Value.ToString("yyyy-MM-dd"), dateTimePickerTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (txtNo.Text != "")
            {
                wh += string.Format(" MTO_CargoReceiptNo LIKE '%{0}%' |", txtNo.Text);//.TrimStart('0'));
            }
            if (txtAmount.Text != "")
            {
                wh += string.Format(" MTO_Amount = {0} |", txtAmount.Text);
            }
            if (txtExchangeNo.Text != "")
            {
                wh += string.Format(" MTO_No = {0} |", txtExchangeNo.Text);
            }
            string[] whr = wh.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string where = "";
            if (whr.Length > 0)
            {
                where = w == "" ? " WHERE " + whr[0] : w + " AND " + whr[0] + "\n";
                for (int i = 1; i < whr.Length; i++)
                {
                    where += " AND " + whr[i] + "\n";
                }
            }
            //string sql1 = "USE " + comboDatabase.Text + " SELECT * FROM (\n" + sql + where + ") t \nORDER BY t.[رقم الحوالة],t.[تاريخ الإصدار] DESC\n";
            string sql1 = "USE " + comboDatabase.Text + " SELECT DISTINCT * FROM (" + select + from + where + ") t \nORDER BY [رقم الحوالة], [تاريخ الإصدار] DESC";
            Clipboard.SetText(sql1);
            dataGridView1.DataSource = sQLHelper.ExecuteSelect(sql1);
            txtRowCount.Text = dataGridView1.RowCount + "";

            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].MinimumWidth = 100;
                dataGridView1.Columns[3].MinimumWidth = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[8].Width = 200;
            }
            //calc sum
            int cashed = 0, notCashed = 0, returned = 0;
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int c = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if (c == 1) ++cashed; else ++notCashed;
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains("مرتجع") || dataGridView1.Rows[i].Cells[3].Value.ToString().Contains("مرتجع"))
                        returned++;
                }
            }
            txtCashedCount.Text = cashed + "";
            txtNotCashedCount.Text = notCashed + "";
            txtNotReturndCount.Text = "" + (Convert.ToInt32(txtRowCount.Text) - returned);
            txtNotReturnedTotal.Text = "" + Convert.ToInt32(txtFee.Text) * Convert.ToInt32(txtNotReturndCount.Text);
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            MahClass.MyClass.dataGridView_CellPainting(sender, e, new Font("Times New Roman", 16), Properties.Resources.checkmark_25px, Properties.Resources.symbol_cancel);
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            //MahClass.MyClass.dgv_FillCol(0, 100, dataGridView1);
        }
        private void txtSender_Enter(object sender, EventArgs e)
        {
            MyClass.loadArabicLanguage();
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePickerTo.Value = DateTime.Now;
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(Convert.ToInt32((sender as Button).Tag));
            checkBox1.Checked = true;
        }

        private void txtSender_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || (e.Control && e.KeyData == Keys.F) || e.KeyData == Keys.F3)
                btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Cursor = Cursors.WaitCursor;
            search();
            StartRecNo = 1;
            btnSearch.Cursor = Cursors.Hand;
        }

        private void btnFindReturnd_Click(object sender, EventArgs e)
        {
            btnFindReturnd.Cursor = Cursors.WaitCursor;
            radioBtnCashed.Checked = true;
            txtFindReturnd.Text = "مرتجع";
            btnSearch_Click(null, null);
            btnFindReturnd.Cursor = Cursors.Hand;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            //btnFindReturnd.Visible = lblFindReturnd.Visible = txtFindReturnd.Visible = (tabControl1.SelectedIndex == 0);
            if (tabControl1.SelectedIndex == 0)
            {
                tableLayoutPanel1.SetColumn(label1, 1);
                tableLayoutPanel1.SetColumn(txtSender, 2);
                tableLayoutPanel1.SetColumn(label3, 3);
                tableLayoutPanel1.SetColumn(txtRecipient, 4);
                label1.Text = "المرسل من مكتبنا:";
            }
            else
            {
                tableLayoutPanel1.SetColumn(label1, 3);
                tableLayoutPanel1.SetColumn(txtSender, 4);
                tableLayoutPanel1.SetColumn(label3, 1);
                tableLayoutPanel1.SetColumn(txtRecipient, 2);
                label1.Text = "المرسل:";
            }
            tableLayoutPanel1.Parent = tabControl1.SelectedTab;
        }

        private void txtFee_TextChanged(object sender, EventArgs e)
        {
            if (txtFee.Focused)
            {
                if (txtFee.Text != "" && txtNotReturndCount.Text != "")
                    txtNotReturnedTotal.Text = "" + Convert.ToInt32(txtFee.Text) * Convert.ToInt32(txtNotReturndCount.Text);
                else
                    txtNotReturnedTotal.Text = "0";
            }
        }

        private void toolStripbtnLast_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Select();
                int rowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[rowIndex].Cells[0].Selected = true;
            }
        }
    }
}
