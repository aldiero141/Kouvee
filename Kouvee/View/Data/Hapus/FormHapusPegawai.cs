using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kouvee.Control;
using Kouvee.Models;

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusPegawai : Form
    {
        Pegawai pegawai;
        public FormHapusPegawai()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new PegawaiControl();
            try
            {
                if (txtCari.Text != null && list.SearchPegawai(txtCari.Text) != null)
                {
                    buttonHapus.Enabled = true;
                    pegawai = list.SearchPegawai(txtCari.Text);

                    txtNamaPegawai.Text = pegawai.Nama_Pegawai;
                    txtAlamatPegawai.Text = pegawai.Alamat_Pegawai;
                    txtNomorTelponPegawai.Text = pegawai.Phone_Pegawai;
                    txtPassword.Text = pegawai.Password;
                    dateTimePickerPegawai.Value = DateTime.Parse(pegawai.Tgl_Lahir_Pegawai);
                    comboBoxJabatan.Text = pegawai.Jabatan;
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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }

                var list = new PegawaiControl();
                list.DeletePegawai(txtCari.Text);
                MessageBox.Show("Data Berhasil Dihapus");
                buttonHapus.Enabled = false;
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

        private void FormHapusPegawai_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            table.Columns.Add("value");
            table.Rows.Add("Admin", "Admin");
            table.Rows.Add("CS", "CS");
            table.Rows.Add("Kasir", "Kasir");

            comboBoxJabatan.DataSource = table;
            comboBoxJabatan.DisplayMember = "name";

            buttonHapus.Enabled = false;
            txtNamaPegawai.Enabled = false;
            txtAlamatPegawai.Enabled = false;
            txtNomorTelponPegawai.Enabled = false;
            txtPassword.Enabled = false;
            dateTimePickerPegawai.Enabled = false;
            comboBoxJabatan.Enabled = false;
        }
    }
}
