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
using MySql.Data.MySqlClient;

namespace visprofinalproject
{
    public partial class FrmAdmin1 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmAdmin1()
        {
            alamat = "server=localhost; database=db_bubble; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            TableInformasiMHS.ColumnCount = 6; // 5 kolom: Nama, NIM, Poin, Pekerjaan, Status
            TableInformasiMHS.RowCount = 1; // Mulai dengan 1 baris (untuk header)
            TableInformasiMHS.AutoSize = true;
            TableInformasiMHS.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Mengatur Ukuran Kolom
            TableInformasiMHS.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            AddHeaderToTable(); // Buat Headnya
        }
        private void AddHeaderToTable()
        {
            TableInformasiMHS.Controls.Add(new Label() { Text = "ID_TRANSAKSI", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 0, 0);
            TableInformasiMHS.Controls.Add(new Label() { Text = "NAMA", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 1, 0);
            TableInformasiMHS.Controls.Add(new Label() { Text = "TOTAL", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 2, 0);
            TableInformasiMHS.Controls.Add(new Label() { Text = "JENIS", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 3, 0);
            TableInformasiMHS.Controls.Add(new Label() { Text = "STATUS", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 4, 0);
            TableInformasiMHS.Controls.Add(new Label() { Text = "HARGA", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 5, 0);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    query = string.Format("select * from tbl_cucibersih where id = '{0}'", txtId.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            CBStatus.Text = kolom["status"].ToString();

                        }
                        txtId.Enabled = false;
                       
                        
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        
                    }

                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CBStatus.Text != "")
                {

                    query = string.Format("update tbl_cucibersih set status = '{0}' where id = '{1}'", CBStatus.Text, txtId.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        button1_Click(null, null);
                      
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data . . . ");
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
        }

        private void FrmAdmin1_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();

                // Perbaikan: Gunakan MySqlCommand bukan SqlCommand
                MySqlCommand command = new MySqlCommand("select * from tbl_cucibersih",koneksi);

                // Execute command
                MySqlDataReader reader = command.ExecuteReader();

                int row = 1; // Baris pertama (0) sudah diisi header, mulai dari baris ke-1
                while (reader.Read())
                {
                    // Menambahkan data mahasiswa
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["id"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 0, row);
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["username"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 1, row);
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["total"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 2, row);
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["nama"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 3, row);
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["status"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 4, row);
                    TableInformasiMHS.Controls.Add(new Label() { Text = reader["harga"].ToString(), TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 5, row);
                    row++; // Pindah ke baris berikutnya
                    TableInformasiMHS.RowCount = row; // Tambah jumlah baris di TableLayoutPanel
                }

                reader.Close(); // Jangan lupa tutup reader setelah selesai
                koneksi.Close(); // Tutup koneksi
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
