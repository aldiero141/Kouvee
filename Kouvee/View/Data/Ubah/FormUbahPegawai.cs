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


namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahPegawai : Form
    {
        Pegawai pegawai;
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            table.Columns.Add("value");
            table.Rows.Add("Admin", "Admin");
            table.Rows.Add("CS", "CS");
            table.Rows.Add("Kasir", "Kasir");

            comboBoxJabatan.DataSource = table;
            comboBoxJabatan.DisplayMember = "name";

            txtNamaPegawai.Enabled = false;
            txtAlamatPegawai.Enabled = false;
            txtNomorTelponPegawai.Enabled = false;
            txtPassword.Enabled = false;
            dateTimePickerPegawai.Enabled = false;
            comboBoxJabatan.Enabled = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new PegawaiControl();
            try
            {
                if (txtCari.Text != null && list.SearchPegawai(txtCari.Text) != null)
                {
                    pegawai = list.SearchPegawai(txtCari.Text);

                    txtNamaPegawai.Text = pegawai.Nama_Pegawai;
                    txtAlamatPegawai.Text = pegawai.Alamat_Pegawai;
                    txtNomorTelponPegawai.Text = pegawai.Phone_Pegawai;
                    txtPassword.Text = pegawai.Password;
                    dateTimePickerPegawai.Value = DateTime.Parse(pegawai.Tgl_Lahir_Pegawai);
                    comboBoxJabatan.Text = pegawai.Jabatan;

                    txtNamaPegawai.Enabled = true;
                    txtAlamatPegawai.Enabled = true;
                    txtNomorTelponPegawai.Enabled = true;
                    txtPassword.Enabled = true;
                    dateTimePickerPegawai.Enabled = true;
                    comboBoxJabatan.Enabled = true;
                }
                else
                {
                    Console.WriteLine("test");
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
                var list = new PegawaiControl();
                pegawai = new Pegawai(txtNamaPegawai.Text, txtAlamatPegawai.Text, dateTimePickerPegawai.Text, txtNomorTelponPegawai.Text, comboBoxJabatan.Text, txtPassword.Text);
                list.UpdatePegawai(pegawai, txtCari.Text);

                txtNamaPegawai.Enabled = false;
                txtAlamatPegawai.Enabled = false;
                txtNomorTelponPegawai.Enabled = false;
                txtPassword.Enabled = false;
                dateTimePickerPegawai.Enabled = false;
                comboBoxJabatan.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
