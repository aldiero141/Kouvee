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
                var list = new PegawaiControl();
                pegawai = new Pegawai(txtNamaPegawai.Text, txtAlamatPegawai.Text, dateTimePickerPegawai.Text, txtNomorTelponPegawai.Text, comboBoxJabatan.Text, txtPassword.Text);
                list.CreatePegawai(pegawai);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
