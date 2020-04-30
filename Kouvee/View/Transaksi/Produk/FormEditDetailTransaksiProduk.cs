using Kouvee.Control;
using Kouvee.Models;
using Kouvee.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Transaksi.Produk
{
    public partial class FormEditDetailTransaksiProduk : Form
    {
        DetilTransaksiProduk detilTransaksiProduk;
        TransaksiProduk transaksiProduk;
        int hargaProduk;
        string ID_Transaksi;

        public FormEditDetailTransaksiProduk()
        {
            InitializeComponent();
            SetInitButton();
        }

        private void FormEditDetailTransaksiProduk_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlproduk = "SELECT * FROM produk";

            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlproduk, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxProduk.Items.Add(result1.GetString("Nama_Produk"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new DetilTransaksiProdukControl();
            try
            {
                if (txtCari.Text != null && list.SearchDetilTransaksiProduk(txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    buttonUbah.Enabled = true;

                    detilTransaksiProduk = list.SearchDetilTransaksiProduk(txtCari.Text);
                    txtJumlah.Text = System.Convert.ToString(detilTransaksiProduk.Jumlah_Produk);
                    ID_Transaksi = detilTransaksiProduk.ID_Transaksi_Produk;

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlproduk = "SELECT * FROM produk WHERE ID_PRODUK = '" + detilTransaksiProduk.ID_Produk + "';";
                    
                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlproduk, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxProduk.Text = result1.GetString("Nama_Produk");
                                hargaProduk = result1.GetInt32("Harga_Jual");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan");
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            SetTextBoxDisable();
            buttonUbah.Enabled = false;
            int Subtotal;

            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtJumlah.Text.Trim()))
                {
                    MessageBox.Show("Jumlah Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxProduk.Text.Trim()))
                {
                    MessageBox.Show("Nama Produk Kosong");
                    throw null;
                }

                var ctrl = new DetilTransaksiProdukControl();
                var ctrlTP = new TransaksiProdukControl();

                ValidateNumberOnly(txtJumlah.Text);

                Subtotal = Convert.ToInt32(txtJumlah.Text) * hargaProduk;
                detilTransaksiProduk = new DetilTransaksiProduk(comboBoxProduk.Text, Subtotal, Convert.ToInt32(txtJumlah.Text));
                transaksiProduk = new TransaksiProduk(Subtotal);
                ctrl.UpdateTransaksiProduk(detilTransaksiProduk, txtCari.Text);
                ctrlTP.UpdateSubtotalProduk(transaksiProduk,ID_Transaksi);
                MessageBox.Show("Data Berhasil Diubah");

            }
            catch (NumberOnlyException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInitButton()
        {
            comboBoxProduk.Enabled = false;
            txtJumlah.Enabled = false;
            buttonUbah.Enabled = false;
            txtCari.Enabled = true;
        }

        public void SetTextBoxEnable()
        {
            comboBoxProduk.Enabled = true;
            txtJumlah.Enabled = true;
        }

        public void SetTextBoxDisable()
        {
            comboBoxProduk.Enabled = false;
            txtJumlah.Enabled = false;
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
