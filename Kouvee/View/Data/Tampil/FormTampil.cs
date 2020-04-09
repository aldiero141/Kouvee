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
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Kouvee.View.Data.Tampil
{
    public partial class FormTampil : Form
    {
        String stat = null;
        public FormTampil()
        {
            InitializeComponent();
        }

        private void buttonTampilCustomer_Click(object sender, EventArgs e)
        {
            stat = "customer";
            var ctrl = new CustomerControl();
            dataGridViewTampil.DataSource = ctrl.ShowCustomer();
        }

        private void buttonTampilHewan_Click(object sender, EventArgs e)
        {
            stat = "hewan";
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
            stat = "jenishewan";
            var ctrl = new JenisHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowJenisHewan();
        }

        private void buttonTampilLayanan_Click(object sender, EventArgs e)
        {
            stat = "layanan";
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
            stat = "pegawai";
            var ctrl = new PegawaiControl();
            dataGridViewTampil.DataSource = ctrl.ShowPegawai();
        }

        private void buttonTampilProduk_Click(object sender, EventArgs e)
        {
            stat = "produk";
            var ctrl = new ProdukControl();
            dataGridViewTampil.DataSource = ctrl.ShowProduk();
        }

        private void buttonTampilSupplier_Click(object sender, EventArgs e)
        {
            stat = "supplier";
            var ctrl = new SupplierControl();
            dataGridViewTampil.DataSource = ctrl.ShowSupplier();
        }

        private void buttonTampilUkuranHewan_Click(object sender, EventArgs e)
        {
            stat = "ukuranhewan";
            var ctrl = new UkuranHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowUkuranHewan();
        }

        private void buttonTampilKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if(stat  == "customer")
            {
                var ctrl = new CustomerControl();
                List<Customer> CustomerList = new List<Customer>();
                CustomerList.Add(ctrl.SearchCustomer(txtCari.Text)); 
                dataGridViewTampil.DataSource = CustomerList;
            }
            else if(stat == "hewan")
            {
                var ctrl = new HewanControl();
                List<Hewan> HewanList = new List<Hewan>();
                HewanList.Add(ctrl.SearchHewan(txtCari.Text));
                dataGridViewTampil.DataSource = HewanList;
            }
            else if (stat == "jenishewan")
            {
                var ctrl = new JenisHewanControl();
                List<JenisHewan> JenisHewanList = new List<JenisHewan>();
                JenisHewanList.Add(ctrl.SearchJenisHewan(txtCari.Text));
                dataGridViewTampil.DataSource = JenisHewanList;
            }
            else if (stat == "layanan")
            {
                var ctrl = new LayananControl();
                List<Layanan> LayananList = new List<Layanan>();
                LayananList.Add(ctrl.SearchLayanan(txtCari.Text));
                dataGridViewTampil.DataSource = LayananList;
            }
            else if (stat == "pegawai")
            {
                var ctrl = new PegawaiControl();
                List<Pegawai> PegawaiList = new List<Pegawai>();
                PegawaiList.Add(ctrl.SearchPegawai(txtCari.Text));
                dataGridViewTampil.DataSource = PegawaiList;
            }
            else if (stat == "produk")
            {
                //var ctrl = new ProdukControl();
                //List<Produk> ProdukList = new List<Produk>();
                //ProdukList.Add(ctrl.SearchProduk(txtCari.Text));
                //dataGridViewTampil.DataSource = ProdukList;
            }
            else if (stat == "supplier")
            {
                var ctrl = new SupplierControl();
                List<Supplier> SupplierList = new List<Supplier>();
                SupplierList.Add(ctrl.SearchSupplier(txtCari.Text));
                dataGridViewTampil.DataSource = SupplierList;
            }
            else if (stat == "ukuranhewan")
            {
                var ctrl = new UkuranHewanControl();
                List<UkuranHewan> UkuranHewanList = new List<UkuranHewan>();
                UkuranHewanList.Add(ctrl.SearchUkuran(txtCari.Text));
                dataGridViewTampil.DataSource = UkuranHewanList;
            }
        }
    }
}
