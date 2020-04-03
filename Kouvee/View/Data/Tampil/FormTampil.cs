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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kouvee.View.Data.Tampil
{
    public partial class FormTampil : Form
    {
        public FormTampil()
        {
            InitializeComponent();
        }

        private void buttonTampilCustomer_Click(object sender, EventArgs e)
        {
            var list = new CustomerControl();
            dataGridViewTampil.DataSource = list.ShowCustomer();
        }

        private void buttonTampilHewan_Click(object sender, EventArgs e)
        {
            var list = new HewanControl();
            dataGridViewTampil.DataSource = list.ShowHewan();
        }

        private void buttonTampilJenisHewan_Click(object sender, EventArgs e)
        {
            var list = new JenisHewanControl();
            dataGridViewTampil.DataSource = list.ShowJenisHewan();
        }

        private void buttonTampilLayanan_Click(object sender, EventArgs e)
        {
            var list = new LayananControl();
            dataGridViewTampil.DataSource = list.ShowLayanan();
        }

        private void buttonTampilPegawai_Click(object sender, EventArgs e)
        {
            var list = new PegawaiControl();
            dataGridViewTampil.DataSource = list.ShowPegawai();
        }

        private void buttonTampilProduk_Click(object sender, EventArgs e)
        {
            var list = new ProdukControl();
            dataGridViewTampil.DataSource = list.ShowProduk();
        }

        private void buttonTampilSupplier_Click(object sender, EventArgs e)
        {
            var list = new SupplierControl();
            dataGridViewTampil.DataSource = list.ShowSupplier();
        }

        private void buttonTampilUkuranHewan_Click(object sender, EventArgs e)
        {
            var list = new UkuranHewanControl();
            dataGridViewTampil.DataSource = list.ShowUkuranHewan();
        }

        private void buttonTampilKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
