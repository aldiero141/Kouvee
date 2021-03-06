﻿using System;
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
using Kouvee.Exceptions;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahLayanan : Form
    {
        Layanan layanan;
        public FormTambahLayanan()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(comboBoxUkuran.Text.Trim()))
                {
                    MessageBox.Show("Ukuran Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxJenisHewan.Text.Trim()))
                {
                    MessageBox.Show("Jenis Hewan Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNamaLayanan.Text.Trim()))
                {
                    MessageBox.Show("Nama Layanan Tidak Boleh Kosong");
                    throw null;
                }
                if (!Regex.Match(txtNamaLayanan.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Layanan Tidak Boleh Mengandung Angka");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtHargaLayanan.Text.Trim()))
                {
                    MessageBox.Show("Harga Layanan Tidak Boleh Kosong");
                    throw null;
                }

                var list = new LayananControl();
                ValidateNumberOnly(txtHargaLayanan.Text);
                layanan = new Layanan(comboBoxUkuran.Text, comboBoxJenisHewan.Text, FormLogin.id_pegawai, txtNamaLayanan.Text, Int32.Parse(txtHargaLayanan.Text));
                list.CreateLayanan(layanan);
                MessageBox.Show("Data Berhasil Ditambah");
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
        private void FormTambahLayanan_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlukuran = "SELECT * FROM ukuran";
            string sqljenishewan = "SELECT * FROM jenis_hewan";

            #region ComboBoxNamaPelanggan
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
                        comboBoxJenisHewan.Items.Add(result2.GetString("JenisHewan"));
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
