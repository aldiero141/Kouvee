using Kouvee.Control;
using Kouvee.Exceptions;
using Kouvee.Models;
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

namespace Kouvee.View.Transaksi.Layanan
{
    public partial class FormEditDetailTransaksiLayanan : Form
    {
        DetilTransaksiLayanan detilTransaksiLayanan;
        TransaksiLayanan transaksiLayanan;
        int hargaLayanan;
        string ID_Transaksi;

        public FormEditDetailTransaksiLayanan()
        {
            InitializeComponent();
            SetInitButton();
        }

        private void FormEditDetailTransaksiLayanan_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlproduk = "SELECT * FROM layanan";

            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlproduk, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxLayanan.Items.Add(result1.GetString("Nama_Layanan"));
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
            var list = new DetilTransaksiLayananControl();
            try
            {
                if (txtCari.Text != null && list.SearchDetilTransaksiLayanan(txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    buttonUbah.Enabled = true;

                    detilTransaksiLayanan = list.SearchDetilTransaksiLayanan(txtCari.Text);
                    txtJumlah.Text = System.Convert.ToString(detilTransaksiLayanan.Jumlah_Detil_Layanan);
                    ID_Transaksi = detilTransaksiLayanan.ID_Transaksi_Layanan;

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlproduk = "SELECT * FROM layanan WHERE ID_LAYANAN = '" + detilTransaksiLayanan.ID_Layanan + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlproduk, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxLayanan.Text = result1.GetString("Nama_Layanan");
                                hargaLayanan = result1.GetInt32("Harga_Layanan");
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
                if (string.IsNullOrEmpty(comboBoxLayanan.Text.Trim()))
                {
                    MessageBox.Show("Nama Produk Kosong");
                    throw null;
                }

                var ctrl = new DetilTransaksiLayananControl();
                var ctrlTL = new TransaksiLayananControl();
                ValidateNumberOnly(txtJumlah.Text);

                Subtotal = Convert.ToInt32(txtJumlah.Text) * hargaLayanan;
                detilTransaksiLayanan = new DetilTransaksiLayanan(comboBoxLayanan.Text, Subtotal, Convert.ToInt32(txtJumlah.Text));
                transaksiLayanan = new TransaksiLayanan(Subtotal);
                ctrl.UpdateDetilTransaksiLayanan(detilTransaksiLayanan, txtCari.Text);
                ctrlTL.UpdateSubtotalLayanan(transaksiLayanan, ID_Transaksi);
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
            comboBoxLayanan.Enabled = false;
            txtJumlah.Enabled = false;
            buttonUbah.Enabled = false;
            txtCari.Enabled = true;
        }

        public void SetTextBoxEnable()
        {
            comboBoxLayanan.Enabled = true;
            txtJumlah.Enabled = true;
        }

        public void SetTextBoxDisable()
        {
            comboBoxLayanan.Enabled = false;
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
