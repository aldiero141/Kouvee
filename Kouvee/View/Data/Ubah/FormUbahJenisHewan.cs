﻿using System;
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


namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahJenisHewan : Form
    {
        JenisHewan jenisHewan;
        public FormUbahJenisHewan()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new JenisHewanControl();
            try
            {
                if (txtCari.Text != null && list.SearchJenisHewan(txtCari.Text) != null)
                {
                    buttonUbah.Enabled = true;
                    jenisHewan = list.SearchJenisHewan(txtCari.Text);
                    txtJenisHewan.Text = jenisHewan.Jenis_Hewan;
                    txtJenisHewan.Enabled = true;
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
                if (!Regex.Match(txtJenisHewan.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Hewan Tidak Boleh Mengandung Angka");
                    throw null;
                }

                var list = new JenisHewanControl();
                jenisHewan = new JenisHewan(FormLogin.id_pegawai,txtJenisHewan.Text);
                list.UpdateJenisHewan(jenisHewan, txtCari.Text);
                txtJenisHewan.Enabled = false;

                MessageBox.Show("Data Berhasil Diubah");
                buttonUbah.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormUbahJenisHewan_Load(object sender, EventArgs e)
        {
            txtJenisHewan.Enabled = false;
            buttonUbah.Enabled = false;
        }
    }
}
