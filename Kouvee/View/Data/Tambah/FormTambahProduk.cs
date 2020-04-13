using Kouvee.Control;
using Kouvee.Exceptions;
using Kouvee.Models;
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

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahProduk : Form
    {
        public FormTambahProduk()
        {
            InitializeComponent();
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

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
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

                var list = new ProdukControl();
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
                String insertQuery = "INSERT INTO produk(ID_PEGAWAI, NAMA_PRODUK, STOCK, MIN_STOCK, SATUAN_PRODUK, HARGA_BELI, HARGA_JUAL, GAMBAR_BLOB) " +
                    "VALUES(@ID_PEGAWAI, @NAMA_PRODUK, @STOCK, @MIN_STOCK, @SATUAN_PRODUK , @HARGA_BELI ,@HARGA_JUAL ,@GAMBAR_BLOB)";

                conn.Open();
                cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.Add("@ID_PEGAWAI", MySqlDbType.Int32);
                cmd.Parameters.Add("@NAMA_PRODUK", MySqlDbType.VarChar);
                cmd.Parameters.Add("@STOCK", MySqlDbType.Int32);
                cmd.Parameters.Add("@MIN_STOCK", MySqlDbType.Int32);
                cmd.Parameters.Add("@SATUAN_PRODUK", MySqlDbType.VarChar);
                cmd.Parameters.Add("@HARGA_BELI", MySqlDbType.Int32);
                cmd.Parameters.Add("@HARGA_JUAL", MySqlDbType.Int32);
                cmd.Parameters.Add("@GAMBAR_BLOB", MySqlDbType.MediumBlob);
                cmd.Parameters["@ID_PEGAWAI"].Value = FormLogin.id_pegawai;
                cmd.Parameters["@NAMA_PRODUK"].Value = txtNamaProduk.Text;
                cmd.Parameters["@STOCK"].Value = Int32.Parse(txtStok.Text);
                cmd.Parameters["@MIN_STOCK"].Value = Int32.Parse(txtStokMinimal.Text);
                cmd.Parameters["@SATUAN_PRODUK"].Value = txtSatuanProduk.Text;
                cmd.Parameters["@HARGA_BELI"].Value = Int32.Parse(txtHargaBeli.Text);
                cmd.Parameters["@HARGA_JUAL"].Value = Int32.Parse(txtHargaJual.Text);
                cmd.Parameters["@GAMBAR_BLOB"].Value = img;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Berhasil Ditambah");
                }
                conn.Close();
            }
            catch (NumberOnlyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormTambahProduk_Load(object sender, EventArgs e)
        {
            txtGambar.Enabled = false;
        }

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }
    }
}
