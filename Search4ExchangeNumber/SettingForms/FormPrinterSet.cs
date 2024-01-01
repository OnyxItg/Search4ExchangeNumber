using System;
using System.Windows.Forms;
using MahClass;
//  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
//  Class           - FormPrinterSet
//  Date            - 01/11/2020
//  Contact mah4moud@gmail.com
namespace Search4ExchangeNumber
{
    public partial class FormPrinterSet : Form
    {
        public FormPrinterSet()
        {
            InitializeComponent();
            this.RightToLeft = Program.RTL ? RightToLeft.Yes : RightToLeft.No;

        }
        private void FormPrinterSet_Load(object sender, EventArgs e)
        {
            this.Icon = Program.formMain.Icon;
            ///this.TopMost = GeneralSettings.getAlwaysOnTop();
            
            comboBox1.Items.AddRange(MyClass.getInstalledPrinters());
            ///comboBox1.Text = PrintSettings.getPrinterName();
            comboBox1.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
