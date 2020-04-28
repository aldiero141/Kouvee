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

namespace Kouvee.View.Transaksi.Layanan
{
    public partial class FormTampilTransaksiLayanan : Form
    {
        string stat = null;
        public FormTampilTransaksiLayanan()
        {
            InitializeComponent();
        }

        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            stat = "transaksi";
            var ctrl = new TransaksiLayananControl();
            dataGridViewTampil.DataSource = ctrl.ShowTransaksiLayanan();
            txtCari.Text = string.Empty;
            txtCari.Enabled = true;
            btnCari.Enabled = true;
        }

        private void buttonDetilTransaksi_Click(object sender, EventArgs e)
        {
            stat = "detiltransaksi";
            var ctrl = new DetilTransaksiLayananControl();
            dataGridViewTampil.DataSource = ctrl.ShowDetilTransaksiLayanan();
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
                    if(stat == "transaksi")
                    {
                        var ctrl = new TransaksiLayananControl();
                        if (ctrl.SearchTransaksiLayanan(txtCari.Text) == null)
                        {
                            MessageBox.Show("Pencarian Tidak Ditemukan");
                            txtCari.Text = string.Empty;
                            throw null;
                        }
                        else
                        {
                            List<TransaksiLayanan> TransaksiLayananList = new List<TransaksiLayanan>();
                            TransaksiLayananList.Add(ctrl.SearchTransaksiLayanan(txtCari.Text));
                            dataGridViewTampil.DataSource = TransaksiLayananList;
                        }
                    }
                    else if (stat == "detiltransaksi")
                    {
                        var ctrl = new DetilTransaksiLayananControl();
                        if (ctrl.SearchDetilTransaksiLayanan(txtCari.Text) == null)
                        {
                            MessageBox.Show("Pencarian Tidak Ditemukan");
                            txtCari.Text = string.Empty;
                            throw null;
                        }
                        else
                        {
                            List<DetilTransaksiLayanan> DetilTransaksiLayananList = new List<DetilTransaksiLayanan>();
                            DetilTransaksiLayananList.Add(ctrl.SearchDetilTransaksiLayanan(txtCari.Text));
                            dataGridViewTampil.DataSource = DetilTransaksiLayananList;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormTampilTransaksiLayanan_Load(object sender, EventArgs e)
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
