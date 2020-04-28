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

namespace Kouvee.View.Transaksi.Produk
{
    public partial class FormTampilTransaksiProduk : Form
    {
        string stat = null;
        public FormTampilTransaksiProduk()
        {
            InitializeComponent();
        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            stat = "transaksi";
            var ctrl = new TransaksiProdukControl();
            dataGridViewTampil.DataSource = ctrl.ShowTransaksiProduk();
            txtCari.Text = string.Empty;
            txtCari.Enabled = true;
            btnCari.Enabled = true;
        }

        private void buttonDetilTransaksi_Click(object sender, EventArgs e)
        {
            stat = "detiltransaksi";
            var ctrl = new DetilTransaksiProdukControl();
            dataGridViewTampil.DataSource = ctrl.ShowDetilTransaksiProduk();
            txtCari.Text = string.Empty;
            txtCari.Enabled = true;
            btnCari.Enabled = true;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                else
                {
                    if (stat == "transaksi")
                    {
                        var ctrl = new TransaksiProdukControl();
                        if (ctrl.SearchTransaksiProduk(txtCari.Text) == null)
                        {
                            MessageBox.Show("Pencarian Tidak Ditemukan");
                            txtCari.Text = string.Empty;
                            throw null;
                        }
                        else
                        {
                            List<TransaksiProduk> TransaksiProdukList = new List<TransaksiProduk>();
                            TransaksiProdukList.Add(ctrl.SearchTransaksiProduk(txtCari.Text));
                            dataGridViewTampil.DataSource = TransaksiProdukList;
                        }
                    }
                    else if (stat == "detiltransaksi")
                    {
                        var ctrl = new DetilTransaksiProdukControl();
                        if (ctrl.SearchDetilTransaksiProduk(txtCari.Text) == null)
                        {
                            MessageBox.Show("Pencarian Tidak Ditemukan");
                            txtCari.Text = string.Empty;
                            throw null;
                        }
                        else
                        {
                            List<DetilTransaksiProduk> DetilTransaksiProdukList = new List<DetilTransaksiProduk>();
                            DetilTransaksiProdukList.Add(ctrl.SearchDetilTransaksiProduk(txtCari.Text));
                            dataGridViewTampil.DataSource = DetilTransaksiProdukList;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormTampilTransaksiProduk_Load(object sender, EventArgs e)
        {
            txtCari.Enabled = false;
            btnCari.Enabled = false;
        }

        private void buttonTampilKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
