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
using Kouvee.Control;
using Kouvee.Models;
using MySql.Data.MySqlClient;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahHewan : Form
    {
        Hewan hewan;
        public FormUbahHewan()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new HewanControl();
            try
            {
                if (txtCari.Text != null && list.SearchHewan(txtCari.Text) != null)
                {
                    buttonUbah.Enabled = true;

                    hewan = list.SearchHewan(txtCari.Text);
                    txtNamaHewan.Text = hewan.Nama_Hewan;
                    dateTimePickerHewan.Value = DateTime.Parse(hewan.Tgl_Lahir_Hewan);
                    
                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlpelanggan = "SELECT * FROM pelanggan WHERE ID_PELANGGAN = '" + hewan.ID_Pelanggan +"';";
                    string sqljenishewan = "SELECT * FROM jenis_hewan WHERE ID_JENISHEWAN = '" + hewan.ID_Jenis + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlpelanggan, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxNamaPelanggan.Text = result1.GetString("Nama_Pelanggan");
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

                    txtNamaHewan.Enabled = true;
                    dateTimePickerHewan.Enabled = true;
                    comboBoxNamaPelanggan.Enabled = true;
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
                if (string.IsNullOrEmpty(txtNamaHewan.Text.Trim()))
                {
                    MessageBox.Show("Nama Hewan Kosong");
                    throw null;
                }
                if (!Regex.Match(txtNamaHewan.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Hewan Tidak Boleh Mengandung Angka");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxNamaPelanggan.Text.Trim()))
                {
                    MessageBox.Show("Nama Pelanggan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxJenisHewan.Text.Trim()))
                {
                    MessageBox.Show("Jenis Hewan Kosong");
                    throw null;
                }
                

                var list = new HewanControl();
                hewan = new Hewan(comboBoxNamaPelanggan.Text, comboBoxJenisHewan.Text, FormLogin.id_pegawai, txtNamaHewan.Text, dateTimePickerHewan.Text);
                list.UpdateHewan(hewan, txtCari.Text);

                txtNamaHewan.Enabled = false;
                dateTimePickerHewan.Enabled = false;
                comboBoxNamaPelanggan.Enabled = false;
                comboBoxJenisHewan.Enabled = false;

                MessageBox.Show("Data Berhasil Diubah");
                buttonUbah.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormUbahHewan_Load(object sender, EventArgs e)
        {
            buttonUbah.Enabled = false;
            txtNamaHewan.Enabled = false;
            dateTimePickerHewan.Enabled = false;
            comboBoxNamaPelanggan.Enabled = false;
            comboBoxJenisHewan.Enabled = false;

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlpelanggan = "SELECT * FROM pelanggan";
            string sqljenishewan = "SELECT * FROM jenis_hewan";

            #region ComboBoxNamaPelanggan
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlpelanggan, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxNamaPelanggan.Items.Add(result1.GetString("Nama_Pelanggan"));
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
    }
}
