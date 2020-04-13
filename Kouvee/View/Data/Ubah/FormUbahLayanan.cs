using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kouvee.Models;
using Kouvee.Control;
using MySql.Data.MySqlClient;
using Kouvee.Exceptions;
using System.Text.RegularExpressions;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahLayanan : Form
    {
        Layanan layanan;
        public FormUbahLayanan()
        {
            InitializeComponent();
        }

        private void FormUbahLayanan_Load(object sender, EventArgs e)
        {
            buttonUbah.Enabled = false;
            txtHargaLayanan.Enabled = false;
            txtNamaLayanan.Enabled = false;
            comboBoxUkuran.Enabled = false;
            comboBoxJenisHewan.Enabled = false;

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlukuran = "SELECT * FROM ukuran";
            string sqljenishewan = "SELECT * FROM jenis_hewan";

            #region ComboBoxUkuran
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlukuran, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxUkuran.Items.Add(result1.GetString("Ukuran"));
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

            #region ComboBoxJenisHewan
            conn.Open();
            try
            {
                MySqlCommand cmd2 = new MySqlCommand(sqljenishewan, conn);
                MySqlDataReader result2 = cmd2.ExecuteReader();
                if (result2 != null)
                {
                    while (result2.Read())
                    {
                        comboBoxJenisHewan.Items.Add(result2.GetString("Jenishewan"));
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
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new LayananControl();
            try
            {
               
                if (txtCari.Text != null && list.SearchLayanan(txtCari.Text) != null)
                {
                    buttonUbah.Enabled = true;
                    layanan = list.SearchLayanan(txtCari.Text);
                    txtNamaLayanan.Text = layanan.Nama_Layanan;
                    txtHargaLayanan.Text = System.Convert.ToString(layanan.Harga_Layanan);

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlukuran = "SELECT * FROM ukuran WHERE ID_UKURAN = '" + layanan.ID_Ukuran + "';";
                    string sqljenishewan = "SELECT * FROM jenis_hewan WHERE ID_JENISHEWAN = '" + layanan.ID_JenisHewan + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlukuran, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxUkuran.Text = result1.GetString("Ukuran");
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
                        MySqlCommand cmd2 = new MySqlCommand(sqljenishewan, conn);
                        MySqlDataReader result2 = cmd2.ExecuteReader();
                        if (result2 != null)
                        {
                            while (result2.Read())
                            {
                                comboBoxJenisHewan.Text = result2.GetString("Jenishewan");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                    txtNamaLayanan.Enabled = true;
                    txtHargaLayanan.Enabled = true;
                    comboBoxUkuran.Enabled = true;
                    comboBoxJenisHewan.Enabled = true;
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
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxUkuran.Text.Trim()))
                {
                    MessageBox.Show("Ukuran Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxJenisHewan.Text.Trim()))
                {
                    MessageBox.Show("Jenis Hewan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNamaLayanan.Text.Trim()))
                {
                    MessageBox.Show("Nama Layanan Kosong");
                    throw null;
                }
                if (!Regex.Match(txtNamaLayanan.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Hewan Tidak Boleh Mengandung Angka");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtHargaLayanan.Text.Trim()))
                {
                    MessageBox.Show("Harga Layanan Kosong");
                    throw null;
                }
                
                var list = new LayananControl();
                ValidateNumberOnly(txtHargaLayanan.Text);
                layanan = new Layanan(comboBoxUkuran.Text, comboBoxJenisHewan.Text, FormLogin.id_pegawai, txtNamaLayanan.Text, Int32.Parse(txtHargaLayanan.Text));
                list.UpdateLayanan(layanan, txtCari.Text);

                txtNamaLayanan.Enabled = false;
                txtHargaLayanan.Enabled = false;
                comboBoxUkuran.Enabled = false;
                comboBoxJenisHewan.Enabled = false;

                MessageBox.Show("Data Berhasil Diubah");
                buttonUbah.Enabled = false;
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

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
