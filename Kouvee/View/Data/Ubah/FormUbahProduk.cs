using Kouvee.Control;
using Kouvee.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahProduk : Form
    {
        public FormUbahProduk()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    da.Dispose();

                    txtNamaProduk.Enabled = true;
                    txtStok.Enabled = true;
                    txtStokMinimal.Enabled = true;
                    txtSatuanProduk.Enabled = true;
                    txtHargaBeli.Enabled = true;
                    txtHargaJual.Enabled = true;
                    txtGambar.Enabled = true;
                    buttonUbah.Enabled = true;
                    btnBrowseGambar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaProduk.Text.Trim()))
            {
                MessageBox.Show("Nama Produk Tidak Boleh Kosong");
                throw null;
            }
            if (string.IsNullOrEmpty(txtStok.Text.Trim()))
            {
                MessageBox.Show("Stok Tidak Boleh Kosong");
                throw null;
            }
            if (string.IsNullOrEmpty(txtStokMinimal.Text.Trim()))
            {
                MessageBox.Show("Stok Minimal Tidak Boleh Kosong");
                throw null;
            }
            if (string.IsNullOrEmpty(txtSatuanProduk.Text.Trim()))
            {
                MessageBox.Show("Satuan Produk Tidak Boleh Kosong");
                throw null;
            }
            if (!Regex.Match(txtSatuanProduk.Text, @"^[a-zA-Z]+$").Success)
            {
                MessageBox.Show("Satuan Produk Tidak Boleh Mengandung Angka");
                throw null;
            }
            if (string.IsNullOrEmpty(txtHargaBeli.Text.Trim()))
            {
                MessageBox.Show("Harga Beli Tidak Boleh Kosong");
                throw null;
            }
            if (string.IsNullOrEmpty(txtHargaJual.Text.Trim()))
            {
                MessageBox.Show("Harga Jual Tidak Boleh Kosong");
                throw null;
            }
            if (pictureBoxProduk.Image == null)
            {
                MessageBox.Show("Gambar Tidak Boleh Kosong");
                throw null;
            }
            ValidateNumberOnly(txtStok.Text);
            ValidateNumberOnly(txtStokMinimal.Text);
            ValidateNumberOnly(txtHargaBeli.Text);
            ValidateNumberOnly(txtHargaJual.Text);

            MemoryStream ms = new MemoryStream();
            pictureBoxProduk.Image.Save(ms, pictureBoxProduk.Image.RawFormat);
            byte[] img = ms.ToArray();

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            String updateQuery = "UPDATE produk SET ID_PEGAWAI = @ID_PEGAWAI, NAMA_PRODUK = @NAMA_PRODUK, STOCK = @STOCK, MIN_STOCK = @MIN_STOCK, " +
                "SATUAN_PRODUK = @SATUAN_PRODUK, HARGA_BELI = @HARGA_BELI, HARGA_JUAL = @HARGA_JUAL, GAMBAR_BLOB = @GAMBAR_BLOB " +
                "WHERE NAMA_PRODUK = '" + txtCari.Text + "';";
            

            conn.Open();
            cmd = new MySqlCommand(updateQuery, conn);
            cmd.Parameters.Add("@ID_PEGAWAI", MySqlDbType.Int32).Value = FormLogin.id_pegawai;
            cmd.Parameters.Add("@NAMA_PRODUK", MySqlDbType.VarChar).Value = txtNamaProduk.Text;
            cmd.Parameters.Add("@STOCK", MySqlDbType.Int32).Value = Int32.Parse(txtStok.Text);
            cmd.Parameters.Add("@MIN_STOCK", MySqlDbType.Int32).Value = Int32.Parse(txtStokMinimal.Text);
            cmd.Parameters.Add("@SATUAN_PRODUK", MySqlDbType.VarChar).Value = txtSatuanProduk.Text;
            cmd.Parameters.Add("@HARGA_BELI", MySqlDbType.Int32).Value = Int32.Parse(txtHargaBeli.Text);
            cmd.Parameters.Add("@HARGA_JUAL", MySqlDbType.Int32).Value = Int32.Parse(txtHargaJual.Text);
            cmd.Parameters.Add("@GAMBAR_BLOB", MySqlDbType.MediumBlob).Value = img;
            cmd.ExecuteReader();
            MessageBox.Show("Data Berhasil Diubah");
           
            conn.Close();

            txtNamaProduk.Enabled = false;
            txtStok.Enabled = false;
            txtStokMinimal.Enabled = false;
            txtSatuanProduk.Enabled = false;
            txtHargaBeli.Enabled = false;
            txtHargaJual.Enabled = false;
            txtGambar.Enabled = false;
            buttonUbah.Enabled = false;
            btnBrowseGambar.Enabled = false;
        }

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
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

        private void FormUbahProduk_Load(object sender, EventArgs e)
        {
            txtNamaProduk.Enabled = false;
            txtStok.Enabled = false;
            txtStokMinimal.Enabled = false;
            txtSatuanProduk.Enabled = false;
            txtHargaBeli.Enabled = false;
            txtHargaJual.Enabled = false;
            txtGambar.Enabled = false;
            buttonUbah.Enabled = false;
            btnBrowseGambar.Enabled = false;
        }
    }
}
