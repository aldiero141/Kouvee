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
        DetilTransaksiProduk detilTransaksiProduk; 
        int hargaProduk;
        int hargaProdukInputan;
        int subtotal;
        int subtotalTransaksi;
        int statusTransaksi;
        int idProduk;
        int hargaSubtotal;
        int oldSubtotal;
        int tempDiskon;
        int totalHargaAkhir;

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
            string sqlproduk = "SELECT * FROM produk";
            
            #region ComboBoxProduk
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
            #endregion

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
            var list2 = new DetilTransaksiProdukControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiProduk(txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    buttonUbah.Enabled = true;
                    buttonBatal.Enabled = true;
                    btnTambahProduk.Enabled = true;

                    transaksiProduk = list.SearchTransaksiProduk(txtCari.Text);
                    txtDiskon.Text = System.Convert.ToString(transaksiProduk.Diskon_Produk);
                    subtotal = transaksiProduk.Subtotal_Transaksi_Produk;
                    statusTransaksi = transaksiProduk.Status_Transaksi_Produk;
                    subtotalTransaksi = transaksiProduk.Subtotal_Transaksi_Produk;
                    tempDiskon = transaksiProduk.Diskon_Produk;

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

                    List<TransaksiProduk> TransaksiProdukList = new List<TransaksiProduk>();
                    TransaksiProdukList.Add(list.SearchTransaksiProduk(txtCari.Text));
                    dataGridViewTransaksi.DataSource = TransaksiProdukList;
                    dataGridViewDetiil.DataSource = list2.SearchDetilTransaksiProdukUsingIDTransaksi(txtCari.Text);
                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan");
                    txtCari.Text = string.Empty;
                    txtCariDetil.Text = string.Empty;
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
                    //ctrlDTP.DeleteDetilTransaksiProduk(txtCari.Text);
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
            btnTambahProduk.Enabled = false;
            btnUbahProduk.Enabled = false;
            btnHapusProduk.Enabled = false;
            buttonUbah.Enabled = false;
            buttonBatal.Enabled = false;
            txtCari.Enabled = true;
            txtCariDetil.Enabled = false;
            txtJumlah.Enabled = false;
        }

        public void SetTextBoxEnable()
        {
            comboBoxCS.Enabled = true;
            comboBoxHewan.Enabled = true;
            comboBoxKasir.Enabled = true;
            comboBoxStatus.Enabled = true;
            txtDiskon.Enabled = true;
            txtJumlah.Enabled = true;
            txtCariDetil.Enabled = true;
        }

        public void SetTextBoxDisable()
        {
            comboBoxCS.Enabled = false;
            comboBoxHewan.Enabled = false;
            comboBoxKasir.Enabled = false;
            comboBoxStatus.Enabled = false;
            txtDiskon.Enabled = false;
        }

        private void btnCariDetil_Click(object sender, EventArgs e)
        {
            var list = new DetilTransaksiProdukControl();
            int id_produk;
            try
            {
                if (txtCari.Text != null && list.SearchDetilTransaksiProdukUsingID(txtCariDetil.Text,txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    btnTambahProduk.Enabled = true;
                    btnHapusProduk.Enabled = true;
                    btnUbahProduk.Enabled = true;

                    detilTransaksiProduk = list.SearchDetilTransaksiProdukUsingID(txtCariDetil.Text, txtCari.Text);
                    txtJumlah.Text = System.Convert.ToString(detilTransaksiProduk.Jumlah_Produk);
                    id_produk = detilTransaksiProduk.ID_Produk;
                    oldSubtotal = detilTransaksiProduk.Sub_Total_Produk;

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlproduk = "SELECT Harga_Jual, Nama_Produk FROM produk WHERE ID_PRODUK = '" + id_produk + "';";

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
                                Console.WriteLine(hargaProduk);
                                Console.WriteLine(comboBoxProduk.Text);
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
                    txtCariDetil.Text = string.Empty;
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnTambahProduk_Click(object sender, EventArgs e)
        {
            int SubtotalProduk;
            
            try
            {
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

                string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sqlhewan = "SELECT * FROM produk WHERE NAMA_PRODUK = '" + comboBoxProduk.Text + "';";

                conn.Open();
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                    MySqlDataReader result1 = cmd1.ExecuteReader();
                    if (result1 != null)
                    {
                        while (result1.Read())
                        {
                            hargaProdukInputan = result1.GetInt32("HARGA_JUAL");
                            idProduk = result1.GetInt32("ID_PRODUk");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to read...");
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();

                SubtotalProduk = (Convert.ToInt32(txtJumlah.Text) * hargaProdukInputan);
                subtotalTransaksi = subtotalTransaksi + SubtotalProduk;
                totalHargaAkhir = subtotalTransaksi - tempDiskon;
                detilTransaksiProduk = new DetilTransaksiProduk(txtCari.Text, idProduk, SubtotalProduk, Convert.ToInt32(txtJumlah.Text));
                transaksiProduk = new TransaksiProduk(subtotalTransaksi);
                ctrl.CreateDetilTransaksiProduk(detilTransaksiProduk);
                ctrlTP.UpdateSubtotalProduk(transaksiProduk, txtCari.Text);
                ctrlTP.UpdateTotalHargaProduk(totalHargaAkhir, txtCari.Text);
                MessageBox.Show("Transaksi Berhasil Ditambah!");

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

        private void btnUbahProduk_Click(object sender, EventArgs e)
        {
            int SubtotalProduk;

            try
            {
                if (string.IsNullOrEmpty(txtCariDetil.Text.Trim()))
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

                string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sqlhewan = "SELECT * FROM produk WHERE NAMA_PRODUK = '" + comboBoxProduk.Text + "';";

                conn.Open();
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                    MySqlDataReader result1 = cmd1.ExecuteReader();
                    if (result1 != null)
                    {
                        while (result1.Read())
                        {
                            hargaProdukInputan = result1.GetInt32("HARGA_JUAL");
                            idProduk = result1.GetInt32("ID_PRODUk");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to read...");
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();

                var ctrl = new DetilTransaksiProdukControl();
                var ctrlTP = new TransaksiProdukControl();
                ValidateNumberOnly(txtJumlah.Text);

                SubtotalProduk = (Convert.ToInt32(txtJumlah.Text) * hargaProdukInputan);
                subtotalTransaksi = subtotalTransaksi - oldSubtotal + SubtotalProduk;
                totalHargaAkhir = subtotalTransaksi - tempDiskon;
                detilTransaksiProduk = new DetilTransaksiProduk(comboBoxProduk.Text, SubtotalProduk, Convert.ToInt32(txtJumlah.Text));
                transaksiProduk = new TransaksiProduk(subtotalTransaksi);
                ctrl.UpdateDetilTransaksiProduk(detilTransaksiProduk, txtCariDetil.Text);
                ctrlTP.UpdateSubtotalProduk(transaksiProduk, txtCari.Text);
                ctrlTP.UpdateTotalHargaProduk(totalHargaAkhir, txtCari.Text);
                MessageBox.Show("Transaksi Berhasil Diubah!");
                
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

        private void btnHapusProduk_Click(object sender, EventArgs e)
        {
            try
            {
                var ctrlDTP = new DetilTransaksiProdukControl();
                var ctrlTP = new TransaksiProdukControl();
                if (txtCariDetil.Text != null && ctrlDTP.SearchDetilTransaksiProduk(txtCariDetil.Text) != null)
                {
                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlhewan = "SELECT * FROM detil_transaksi_produk WHERE ID_DETIL_TRANSAKSI = '" + txtCariDetil.Text + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                hargaSubtotal = result1.GetInt32("SUB_TOTAL_PRODUK");                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                    ctrlDTP.DeleteDetilTransaksiProduk(txtCariDetil.Text,txtCari.Text);
                    subtotalTransaksi = subtotalTransaksi - hargaSubtotal;
                    totalHargaAkhir = subtotalTransaksi - tempDiskon;
                    transaksiProduk = new TransaksiProduk(subtotalTransaksi);
                    ctrlTP.UpdateSubtotalProduk(transaksiProduk, txtCari.Text);
                    ctrlTP.UpdateTotalHargaProduk(totalHargaAkhir, txtCari.Text);
                    MessageBox.Show("Produk Berhasil Dihapus!");
                }
                else
                {
                    MessageBox.Show("Transaksi Produk Tidak ditemukan!");
                    throw null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
