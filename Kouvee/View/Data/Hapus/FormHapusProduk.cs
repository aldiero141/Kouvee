using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusProduk : Form
    {
        public FormHapusProduk()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBoxProduk.Image.Save(ms, pictureBoxProduk.Image.RawFormat);
            byte[] img = ms.ToArray();

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            String updateQuery = "UPDATE produk SET DELETE_AT_PRODUK = @DELETE_AT_PRODUK WHERE NAMA_PRODUK = '" + txtCari.Text + "';";

            conn.Open();
            cmd = new MySqlCommand(updateQuery, conn);
            cmd.Parameters.Add("@DELETE_AT_PRODUK", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Berhasil Dihapus");
            }
            conn.Close();
            buttonHapus.Enabled = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string selectQuery = "SELECT * FROM produk WHERE NAMA_PRODUK = '" + txtCari.Text + "'";
                MySqlCommand command = new MySqlCommand(selectQuery, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                da.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan");
                    da.Dispose();
                    throw null;
                }
                else
                {
                    byte[] img = (byte[])table.Rows[0][9];
                    MemoryStream ms = new MemoryStream(img);
                    txtNamaProduk.DataBindings.Add("Text", table, "NAMA_PRODUK");
                    txtStok.DataBindings.Add("Text", table, "STOCK");
                    txtStokMinimal.DataBindings.Add("Text", table, "MIN_STOCK");
                    txtSatuanProduk.DataBindings.Add("Text", table, "SATUAN_PRODUK");
                    txtHargaBeli.DataBindings.Add("Text", table, "HARGA_BELI");
                    txtHargaJual.DataBindings.Add("Text", table, "HARGA_JUAL");
                    pictureBoxProduk.Image = Image.FromStream(ms);
                    buttonHapus.Enabled = true;
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                txtGambar.Text = opf.FileName;
                pictureBoxProduk.Image = Image.FromFile(opf.FileName);
            }
        }

        private void FormHapusProduk_Load(object sender, EventArgs e)
        {
            txtNamaProduk.Enabled = false;
            txtStok.Enabled = false;
            txtStokMinimal.Enabled = false;
            txtSatuanProduk.Enabled = false;
            txtHargaBeli.Enabled = false;
            txtHargaJual.Enabled = false;
            txtGambar.Enabled = false;
            buttonHapus.Enabled = false;
            btnBrowseGambar.Enabled = false;
        }
    }
}
