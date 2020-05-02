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

namespace Kouvee.View.Transaksi.Produk
{
    public partial class FormEditTransaksiProduk : Form
    {
        TransaksiProduk transaksiProduk;
        int subtotal;
        int statusTransaksi;

        public FormEditTransaksiProduk()
        {
            InitializeComponent();
            SetInitButton();
        }

        private void FormEditTransaksiProduk_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlhewan = "SELECT * FROM hewan";
            string sqlCS = "SELECT * FROM pegawai WHERE JABATAN = 'CS'";
            string sqlKasir = "SELECT * FROM pegawai WHERE JABATAN = 'Kasir'";


            #region ComboBoxHewan
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxHewan.Items.Add(result1.GetString("Nama_Hewan"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            #endregion

            #region ComboBoxCS
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlCS, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxCS.Items.Add(result1.GetString("Nama_Pegawai"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            #endregion

            #region ComboBoxKasir
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlKasir, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxKasir.Items.Add(result1.GetString("Nama_Pegawai"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            #endregion

            #region ComboBoxStatus
            DataTable tableStatus = new DataTable();
            tableStatus.Columns.Add("name");
            tableStatus.Columns.Add("value");
            tableStatus.Rows.Add("Lunas", "1");
            tableStatus.Rows.Add("Belum Lunas", "0");

            comboBoxStatus.DataSource = tableStatus;
            comboBoxStatus.DisplayMember = "name";
            #endregion
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new TransaksiProdukControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiProduk(txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    buttonUbah.Enabled = true;
                    buttonBatal.Enabled = true;

                    transaksiProduk = list.SearchTransaksiProduk(txtCari.Text);
                    txtDiskon.Text = System.Convert.ToString(transaksiProduk.Diskon_Produk);
                    subtotal = transaksiProduk.Subtotal_Transaksi_Produk;
                    statusTransaksi = transaksiProduk.Status_Transaksi_Produk;

                    if (transaksiProduk.Status_Transaksi_Produk == 1)comboBoxStatus.Text = "Lunas";
                    else comboBoxStatus.Text = "Belum Lunas";

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlhewan = "SELECT * FROM hewan WHERE ID_HEWAN = '" + transaksiProduk.ID_Hewan + "';";
                    string sqlCS = "SELECT * FROM pegawai WHERE ID_PEGAWAI = '" + transaksiProduk.ID_Pegawai + "';";
                    string sqlKasir = "SELECT * FROM pegawai WHERE ID_PEGAWAI = '" + transaksiProduk.Peg_ID_Pegawai + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxHewan.Text = result1.GetString("Nama_Hewan");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd2 = new MySqlCommand(sqlCS, conn);
                        MySqlDataReader result2 = cmd2.ExecuteReader();
                        if (result2 != null)
                        {
                            while (result2.Read())
                            {
                                comboBoxCS.Text = result2.GetString("Nama_Pegawai");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlKasir, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxKasir.Text = result1.GetString("Nama_Pegawai");
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
                    txtCari.Text = string.Empty;
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
            buttonBatal.Enabled = false;
            int status;
            int totalHarga;

            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtDiskon.Text.Trim()))
                {
                    MessageBox.Show("Diskon Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxStatus.Text.Trim()))
                {
                    MessageBox.Show("Status Pembayaran Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxCS.Text.Trim()))
                {
                    MessageBox.Show("Nama CS Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxHewan.Text.Trim()))
                {
                    MessageBox.Show("Nama Hewan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxKasir.Text.Trim()))
                {
                    MessageBox.Show("Nama Kasir Kosong");
                    throw null;
                }

                var ctrl = new TransaksiProdukControl();
                ValidateNumberOnly(txtDiskon.Text);

                if (comboBoxStatus.Text == "Lunas") status = 1;
                else status = 0;

                totalHarga = subtotal - Int32.Parse(txtDiskon.Text);
                transaksiProduk = new TransaksiProduk(comboBoxCS.Text, comboBoxHewan.Text, comboBoxKasir.Text, status, totalHarga, Int32.Parse(txtDiskon.Text));
                ctrl.UpdateTransaksiProduk(transaksiProduk, txtCari.Text);

                MessageBox.Show("Transaksi Berhasil Diubah!");
                txtCari.Text = string.Empty;
                txtDiskon.Text = string.Empty;
                comboBoxCS.Text = string.Empty;
                comboBoxHewan.Text = string.Empty;
                comboBoxKasir.Text = string.Empty;
                comboBoxStatus.Text = string.Empty;
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

        private void buttonBatal_Click(object sender, EventArgs e)
        {
            SetTextBoxDisable();
            buttonUbah.Enabled = false;
            buttonBatal.Enabled = false;

            try
            {
                var ctrlTP = new TransaksiProdukControl();
                var ctrlDTP = new DetilTransaksiProdukControl();

                if (statusTransaksi == 1)
                {
                    MessageBox.Show("Transaksi Sudah Lunas! Transaksi tidak bisa dibatalkan!");
                    txtCari.Text = string.Empty;
                    throw null;
                }
                else
                {
                    ctrlTP.DeleteTransaksiProduk(txtCari.Text);
                    ctrlDTP.DeleteDetilTransaksiProduk(txtCari.Text);
                    MessageBox.Show("Transaksi Berhasil Dibatalkan!");
                    txtCari.Text = string.Empty;
                    txtDiskon.Text = string.Empty;
                    comboBoxCS.Text = string.Empty;
                    comboBoxHewan.Text = string.Empty;
                    comboBoxKasir.Text = string.Empty;
                    comboBoxStatus.Text = string.Empty;
                }

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

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }

        public void SetInitButton()
        {
            comboBoxCS.Enabled = false;
            comboBoxHewan.Enabled = false;
            comboBoxKasir.Enabled = false;
            comboBoxStatus.Enabled = false;
            txtDiskon.Enabled = false;
            buttonUbah.Enabled = false;
            buttonBatal.Enabled = false;
            txtCari.Enabled = true;
        }

        public void SetTextBoxEnable()
        {
            comboBoxCS.Enabled = true;
            comboBoxHewan.Enabled = true;
            comboBoxKasir.Enabled = true;
            comboBoxStatus.Enabled = true;
            txtDiskon.Enabled = true;
        }

        public void SetTextBoxDisable()
        {
            comboBoxCS.Enabled = false;
            comboBoxHewan.Enabled = false;
            comboBoxKasir.Enabled = false;
            comboBoxStatus.Enabled = false;
            txtDiskon.Enabled = false;
        }

       
    }
}
