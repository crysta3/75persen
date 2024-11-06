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
    public partial class FrmCustom1 : Form
    {
        public FrmCustom1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCucibersih frmCucibersih = new FrmCucibersih();
            frmCucibersih.Show();
            this.Hide();


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FrmCustom1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmCucilipat frmCucilipat = new FrmCucilipat();
            frmCucilipat.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCucisetrika frmCucisetrika = new FrmCucisetrika();
            frmCucisetrika.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmCuciselimut frmCuciselimut = new FrmCuciselimut();
            frmCuciselimut.Show();
            this.Hide();
        }
    }
}
