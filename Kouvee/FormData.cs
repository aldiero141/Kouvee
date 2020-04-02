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
using Kouvee.DAO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kouvee
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridRead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var list = new PegawaiControl();
            dataGridRead.DataSource = list.ShowPegawai();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var list = new CustomerControl();
            list.ShowCustomer();
            dataGridRead.DataSource = list.ShowCustomer();
        }


        private void btnHewan_Click(object sender, EventArgs e)
        {
            var list = new HewanControl();
            dataGridRead.DataSource = list.ShowHewan();
        }

        private void btnJenisHewan_Click(object sender, EventArgs e)
        {
            var list = new JenisHewanControl();
            dataGridRead.DataSource = list.ShowJenisHewan();
        }

        private void btnUkuranHewan_Click(object sender, EventArgs e)
        {
            var list = new UkuranHewanControl();
            dataGridRead.DataSource = list.ShowUkuranHewan();
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            var list = new ProdukControl();
            dataGridRead.DataSource = list.ShowProduk();
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            var list = new LayananControl();
            dataGridRead.DataSource = list.ShowLayanan();
        }
        private void btnPegawai_Click(object sender, EventArgs e)
        {
            var list = new PegawaiControl();
            dataGridRead.DataSource = list.ShowPegawai();
        }
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            var list = new SupplierControl();
            dataGridRead.DataSource = list.ShowSupplier();
        }
    }
}
