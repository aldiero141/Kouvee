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
    public partial class FormEditTransaksiLayanan : Form
    {
        TransaksiLayanan transaksiLayanan;
        DetilTransaksiLayanan detilTransaksiLayanan;
        int subtotal;
        int statusTransaksi;
        int progressLayanan;
        int hargaLayananInput;
        int subtotalLayanan;
        int idLayanan;
        string ID_Transaksi;
        int hargaLayanan;
        int hargaSubtotal;
        int oldSubtotal;
        int tempDiskon;
        int totalHargaAkhir;
        int tempSubtotalLayanan;

        public FormEditTransaksiLayanan()
        {
            InitializeComponent();
            SetInitButton();
        }

        private void FormEditTransaksiLayanan_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlhewan = "SELECT * FROM hewan";
            string sqlCS = "SELECT * FROM pegawai WHERE JABATAN = 'CS'";
            string sqlKasir = "SELECT * FROM pegawai WHERE JABATAN = 'Kasir'";
            string sqlproduk = "SELECT * FROM layanan";

            #region ComboBoxLayanan
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

            #region ComboBoxProgress
            DataTable tableProgress = new DataTable();
            tableProgress.Columns.Add("name");
            tableProgress.Columns.Add("value");
            tableProgress.Rows.Add("Selesai", "1");
            tableProgress.Rows.Add("Belum Selesai", "0");

            comboBoxProgress.DataSource = tableProgress;
            comboBoxProgress.DisplayMember = "name";
            #endregion
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new TransaksiLayananControl();
            var list2 = new DetilTransaksiLayananControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiLayanan(txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    buttonUbah.Enabled = true;
                    buttonBatal.Enabled = true;
                    btnTambahLayanan.Enabled = true;
                    
                    transaksiLayanan = list.SearchTransaksiLayanan(txtCari.Text);
                    txtDiskon.Text = System.Convert.ToString(transaksiLayanan.Diskon_Layanan);
                    subtotal = transaksiLayanan.Subtotal_Transaksi_Layanan;
                    statusTransaksi = transaksiLayanan.Status_Layanan;
                    progressLayanan = transaksiLayanan.Progres_Layanan;
                    tempDiskon = transaksiLayanan.Diskon_Layanan;
                    subtotalLayanan = transaksiLayanan.Subtotal_Transaksi_Layanan;
                    tempSubtotalLayanan = subtotalLayanan;

                    if (transaksiLayanan.Status_Layanan == 1) comboBoxStatus.Text = "Lunas";
                    else comboBoxStatus.Text = "Belum Lunas";

                    if (transaksiLayanan.Progres_Layanan == 1) comboBoxProgress.Text = "Selesai";
                    else comboBoxProgress.Text = "Belum Selesai";

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlhewan = "SELECT * FROM hewan WHERE ID_HEWAN = '" + transaksiLayanan.ID_Hewan + "';";
                    string sqlCS = "SELECT * FROM pegawai WHERE ID_PEGAWAI = '" + transaksiLayanan.ID_Pegawai + "';";
                    string sqlKasir = "SELECT * FROM pegawai WHERE ID_PEGAWAI = '" + transaksiLayanan.Peg_ID_Pegawai + "';";

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

                    List<TransaksiLayanan> TransaksiLayananList = new List<TransaksiLayanan>();
                    TransaksiLayananList.Add(list.SearchTransaksiLayanan(txtCari.Text));
                    dataGridViewTransaksi.DataSource = TransaksiLayananList;
                    dataGridViewDetiil.DataSource = list2.SearchDetilTransaksiLayananUsingIDLayanan(txtCari.Text);
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
            int progress;
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
                if (string.IsNullOrEmpty(comboBoxProgress.Text.Trim()))
                {
                    MessageBox.Show("Progress Kosong");
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

                var ctrl = new TransaksiLayananControl();
                ValidateNumberOnly(txtDiskon.Text);

                if (comboBoxStatus.Text == "Lunas") status = 1;
                else status = 0;
                if (comboBoxProgress.Text == "Selesai") progress = 1;
                else progress = 0;

                totalHarga = subtotal - Int32.Parse(txtDiskon.Text);
                transaksiLayanan = new TransaksiLayanan(comboBoxCS.Text, comboBoxKasir.Text, comboBoxHewan.Text, progress, status, totalHarga, Int32.Parse(txtDiskon.Text));
                ctrl.UpdateTransaksiLayanan(transaksiLayanan, txtCari.Text);

                MessageBox.Show("Transaksi Berhasil Diubah");
                txtCari.Text = string.Empty;
                txtDiskon.Text = string.Empty;
                comboBoxCS.Text = string.Empty;
                comboBoxHewan.Text = string.Empty;
                comboBoxKasir.Text = string.Empty;
                comboBoxStatus.Text = string.Empty;
                comboBoxProgress.Text = string.Empty;
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
                var ctrlTL = new TransaksiLayananControl();
                var ctrlDTL = new DetilTransaksiLayananControl();

                if (statusTransaksi == 1)
                {
                    MessageBox.Show("Transaksi Sudah Lunas! Transaksi tidak bisa dibatalkan!");
                    txtCari.Text = string.Empty;
                    throw null;
                }
                if (progressLayanan == 1)
                {
                    MessageBox.Show("Progress Sudah Selesai! Transaksi tidak bisa dibatalkan!");
                    txtCari.Text = string.Empty;
                    throw null;
                }

                ctrlTL.DeleteTransaksiLayanan(txtCari.Text);
                ctrlDTL.DeleteDetilTransaksiLayananUsingIDTransaksi(txtCari.Text);
                MessageBox.Show("Transaksi Berhasil Dibatalkan");
                txtCari.Text = string.Empty;
                txtDiskon.Text = string.Empty;
                comboBoxCS.Text = string.Empty;
                comboBoxHewan.Text = string.Empty;
                comboBoxKasir.Text = string.Empty;
                comboBoxStatus.Text = string.Empty;
                comboBoxProgress.Text = string.Empty;
                
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
            comboBoxCS.Enabled = false;
            comboBoxHewan.Enabled = false;
            comboBoxKasir.Enabled = false;
            comboBoxStatus.Enabled = false;
            comboBoxProgress.Enabled = false;
            txtDiskon.Enabled = false;
            buttonUbah.Enabled = false;
            buttonBatal.Enabled = false;
            btnUbahLayanan.Enabled = false;
            btnTambahLayanan.Enabled = false;
            btnHapusLayanan.Enabled = false;
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
            comboBoxProgress.Enabled = true;
            txtDiskon.Enabled = true;
            txtCariDetil.Enabled = true;
            txtJumlah.Enabled = true;
        }

        public void SetTextBoxDisable()
        {
            comboBoxCS.Enabled = false;
            comboBoxHewan.Enabled = false;
            comboBoxKasir.Enabled = false;
            comboBoxStatus.Enabled = false;
            comboBoxProgress.Enabled = false;
            txtDiskon.Enabled = false;
        }
        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }

        private void btnTambahLayanan_Click(object sender, EventArgs e)
        {
            int SubtotalLayanan;

            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Kode Transaksi Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtJumlah.Text.Trim()))
                {
                    MessageBox.Show("Jumlah Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxLayanan.Text.Trim()))
                {
                    MessageBox.Show("Nama Layanan Kosong");
                    throw null;
                }

                var ctrl = new DetilTransaksiLayananControl();
                var ctrlTL = new TransaksiLayananControl();

                ValidateNumberOnly(txtJumlah.Text);

                string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sqlLayanan = "SELECT * FROM layanan WHERE NAMA_LAYANAN = '" + comboBoxLayanan.Text + "';";

                conn.Open();
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sqlLayanan, conn);
                    MySqlDataReader result1 = cmd1.ExecuteReader();
                    if (result1 != null)
                    {
                        while (result1.Read())
                        {
                            hargaLayananInput = result1.GetInt32("HARGA_LAYANAN");
                            idLayanan = result1.GetInt32("ID_LAYANAN");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to read...");
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();


                SubtotalLayanan = (Convert.ToInt32(txtJumlah.Text) * hargaLayananInput);
                subtotalLayanan = tempSubtotalLayanan + SubtotalLayanan;
                totalHargaAkhir = subtotalLayanan - tempDiskon;
                detilTransaksiLayanan = new DetilTransaksiLayanan(txtCari.Text, idLayanan, SubtotalLayanan, Convert.ToInt32(txtJumlah.Text));
                transaksiLayanan = new TransaksiLayanan(subtotalLayanan);
                ctrl.CreateDetilTransaksiLayanan(detilTransaksiLayanan);
                ctrlTL.UpdateSubtotalLayanan(transaksiLayanan, txtCari.Text);
                ctrlTL.UpdateTotalHargaLayanan(totalHargaAkhir, txtCari.Text);
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

        private void btnUbahLayanan_Click(object sender, EventArgs e)
        {
            int SubtotalLayanan;

            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Kode Transaksi Kosong");
                    throw null;
                }
                
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
                if (string.IsNullOrEmpty(comboBoxLayanan.Text.Trim()))
                {
                    MessageBox.Show("Nama Layanan Kosong");
                    throw null;
                }

                string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sqlLayanan = "SELECT * FROM layanan WHERE NAMA_LAYANAN = '" + comboBoxLayanan.Text + "';";

                conn.Open();
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sqlLayanan, conn);
                    MySqlDataReader result1 = cmd1.ExecuteReader();
                    if (result1 != null)
                    {
                        while (result1.Read())
                        {
                            hargaLayananInput = result1.GetInt32("HARGA_LAYANAN");
                            idLayanan = result1.GetInt32("ID_LAYANAN");
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Failed to read...");
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();

                var ctrl = new DetilTransaksiLayananControl();
                var ctrlTP = new TransaksiLayananControl();
                ValidateNumberOnly(txtJumlah.Text);

                SubtotalLayanan = (Convert.ToInt32(txtJumlah.Text) * hargaLayananInput);
                subtotalLayanan = tempSubtotalLayanan - oldSubtotal + SubtotalLayanan;
                totalHargaAkhir = subtotalLayanan - tempDiskon;
                detilTransaksiLayanan = new DetilTransaksiLayanan(comboBoxLayanan.Text, SubtotalLayanan, Convert.ToInt32(txtJumlah.Text));
                transaksiLayanan = new TransaksiLayanan(subtotalLayanan);
                ctrl.UpdateDetilTransaksiLayanan(detilTransaksiLayanan, txtCariDetil.Text);
                ctrlTP.UpdateSubtotalLayanan(transaksiLayanan, txtCari.Text);
                ctrlTP.UpdateTotalHargaLayanan(totalHargaAkhir, txtCari.Text);
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

        private void btnHapusLayanan_Click(object sender, EventArgs e)
        {
            var ctrlDTL = new DetilTransaksiLayananControl();
            var ctrlTL = new TransaksiLayananControl();
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Kode Transaksi Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtCariDetil.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (txtCariDetil.Text != null && ctrlDTL.SearchDetilTransaksiLayanan(txtCariDetil.Text) != null)
                {
                    hargaSubtotal = 0;
                    detilTransaksiLayanan = ctrlDTL.SearchDetilTransaksiLayanan(txtCariDetil.Text);
                    hargaSubtotal = detilTransaksiLayanan.Sub_Total_Layanan;

                    ctrlDTL.DeleteDetilTransaksiLayanan(txtCariDetil.Text, txtCari.Text);
                    subtotalLayanan = subtotalLayanan - hargaSubtotal;
                    totalHargaAkhir = subtotalLayanan - tempDiskon;
                    ctrlTL.UpdateSubtotalLayanan(subtotalLayanan, txtCari.Text);
                    ctrlTL.UpdateTotalHargaLayanan(totalHargaAkhir, txtCari.Text);
                    MessageBox.Show("Layanan Berhasil Dihapus!");
                }
                else
                {

                    MessageBox.Show("Transaksi Layanan Tidak ditemukan!");
                    throw null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnCariDetil_Click(object sender, EventArgs e)
        {
            var list = new DetilTransaksiLayananControl();
            int id_layanan;
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Kode Transaksi Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtCariDetil.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (txtCari.Text != null && list.SearchDetilTransaksiLayananUsingID(txtCariDetil.Text,txtCari.Text) != null)
                {
                    SetTextBoxEnable();
                    btnHapusLayanan.Enabled = true;
                    btnUbahLayanan.Enabled = true;

                    detilTransaksiLayanan = list.SearchDetilTransaksiLayananUsingID(txtCariDetil.Text,txtCari.Text);
                    txtJumlah.Text = System.Convert.ToString(detilTransaksiLayanan.Jumlah_Detil_Layanan);
                    id_layanan = detilTransaksiLayanan.ID_Layanan;
                    ID_Transaksi = detilTransaksiLayanan.ID_Transaksi_Layanan;
                    oldSubtotal = detilTransaksiLayanan.Sub_Total_Layanan;
                    

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlproduk = "SELECT Nama_Layanan, Harga_Layanan FROM layanan WHERE ID_LAYANAN = '" + id_layanan + "';";

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
    }
}
