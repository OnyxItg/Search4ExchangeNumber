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

namespace TransportApplication
{
    //  Developer       - Mahmoud Alkannass +963960092185 - +963988651924
    //  Class           - SQL Helper
    //  Date            - 22/07/2019
    //  Contact mah4moud@gmail.com
    public partial class FormReportBond : Form
    {
   
        public FormReportBond()
        {
            InitializeComponent();
            this.RightToLeft = FormMain.rtl? RightToLeft.Yes : RightToLeft.No;
            loadLanguage();
        }
        private void loadLanguage()
        {
            Text = Language.getPrint();
        }
        public void SetCrystalReportViewr(Object cr)
        {
            crystalReportViewer1.ReportSource = cr; 
        }

        private void FormReportBond_FormClosing(object sender, FormClosingEventArgs e)
        {
            crystalReportViewer1.Dispose();
        }

        private void FormReportBond_Load(object sender, EventArgs e)
        {
            this.TopMost = ViewSettings.getAlwaysOnTop();
        }
    }
}
