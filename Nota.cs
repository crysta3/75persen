using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visprofinalproject
{
    public partial class Nota : Form
    {
        int parameterId;
        public Nota(int parameter)
        {
            InitializeComponent();
            parameterId = parameter;
        }

        private void Nota_Load(object sender, EventArgs e)
        {
            CrystalReport11.SetParameterValue("idTransaksi", parameterId);
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer12_Load(object sender, EventArgs e)
        {

        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }
    }
}
