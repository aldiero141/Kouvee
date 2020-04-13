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
using System.Text.RegularExpressions;
using Kouvee.Exceptions;

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahPegawai : Form
    {
        Pegawai pegawai;
        public FormTambahPegawai()
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
                if (string.IsNullOrEmpty(txtNamaPegawai.Text.Trim()))
                {
                    MessageBox.Show("Nama Pegawai Tidak Boleh Kosong");
                    throw null;
                }
                if (!Regex.Match(txtNamaPegawai.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Pegawai Tidak Boleh Mengandung Angka");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtAlamatPegawai.Text.Trim()))
                {
                    MessageBox.Show("Alamat Pegawai Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNomorTelponPegawai.Text.Trim()))
                {
                    MessageBox.Show("Nomor Telpon Pegawai Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxJabatan.Text.Trim()))
                {
                    MessageBox.Show("Jabatan Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Password Tidak Boleh Kosong");
                    throw null;
                }

                var list = new PegawaiControl();
                pegawai = new Pegawai(txtNamaPegawai.Text, txtAlamatPegawai.Text, dateTimePickerPegawai.Text, txtNomorTelponPegawai.Text, comboBoxJabatan.Text, txtPassword.Text);
                ValidateNumberOnly(txtNomorTelponPegawai.Text);
                list.CreatePegawai(pegawai);
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

        private void FormTambahPegawai_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            table.Columns.Add("value");
            table.Rows.Add("Admin", "Admin");
            table.Rows.Add("CS", "CS");
            table.Rows.Add("Kasir", "Kasir");

            comboBoxJabatan.DataSource = table;
            comboBoxJabatan.DisplayMember = "name";
        }
    }
}
