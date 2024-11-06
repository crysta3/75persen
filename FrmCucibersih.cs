using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;


namespace visprofinalproject
{
    public partial class FrmCucibersih : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmCucibersih()
        {
            alamat = "server=localhost; database=db_bubble; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void FrmCucibersih_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmCustom1 frmCustom1 = new FrmCustom1();
            frmCustom1.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Inputan.Text != ""&& txtUsername.Text != "")
                {
                    int harga = Int32.Parse(Inputan.Text)*5000;
                    Random rnd = new Random();
                    int id_transaksi = rnd.Next(1000, 10000);
                    query = string.Format("insert into tbl_cucibersih (id, nama, total, username, harga, status)  values ('{0}','{1}', '{2}', '{3}', '{4}', '{5}');",id_transaksi, "Cuci Bersih", Inputan.Text, txtUsername.Text, harga, "In Queue");


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        Nota frmNota = new Nota(id_transaksi);
                        frmNota.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //try
            //{
            //    if (Inputan.Text != "")
            //    {

            //        query = string.Format("update tbl_cucibersih set total = '{0}'", Inputan.Text)


            //        koneksi.Open();
            //        perintah = new MySqlCommand(query, koneksi);
            //        adapter = new MySqlDataAdapter(perintah);
            //        int res = perintah.ExecuteNonQuery();
            //        koneksi.Close();
            //        if (res == 1)
            //        {
            //            MessageBox.Show("Update Data Suksess ...");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Gagal Update Data . . . ");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Data Tidak lengkap !!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
