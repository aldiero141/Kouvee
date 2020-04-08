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
            var ctrl = new CustomerControl();
            dataGridViewTampil.DataSource = ctrl.ShowCustomer();
        }

        private void buttonTampilHewan_Click(object sender, EventArgs e)
        {
            var ctrl = new HewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowHewan();

            for (int i = 0; i<dataGridViewTampil.Columns.Count; i++) 
            {
                string str = dataGridViewTampil.Columns[i].HeaderText;
                if (str == "Nama_Pelanggan" || str == "JenisHewan")
                {
                    dataGridViewTampil.Columns[i].Visible = false;
                }
            }
        }

        private void buttonTampilJenisHewan_Click(object sender, EventArgs e)
        {
            var ctrl = new JenisHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowJenisHewan();
        }

        private void buttonTampilLayanan_Click(object sender, EventArgs e)
        {
            var ctrl = new LayananControl();
            dataGridViewTampil.DataSource = ctrl.ShowLayanan();
            for (int i = 0; i < dataGridViewTampil.Columns.Count; i++)
            {
                string str = dataGridViewTampil.Columns[i].HeaderText;
                if (str == "Ukuran" || str == "JenisHewan")
                {
                    dataGridViewTampil.Columns[i].Visible = false;
                }
            }
        }

        private void buttonTampilPegawai_Click(object sender, EventArgs e)
        {
            var ctrl = new PegawaiControl();
            dataGridViewTampil.DataSource = ctrl.ShowPegawai();
        }

        private void buttonTampilProduk_Click(object sender, EventArgs e)
        {
            var ctrl = new ProdukControl();
            dataGridViewTampil.DataSource = ctrl.ShowProduk();
        }

        private void buttonTampilSupplier_Click(object sender, EventArgs e)
        {
            var ctrl = new SupplierControl();
            dataGridViewTampil.DataSource = ctrl.ShowSupplier();
        }

        private void buttonTampilUkuranHewan_Click(object sender, EventArgs e)
        {
            var ctrl = new UkuranHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowUkuranHewan();
        }

        private void buttonTampilKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
