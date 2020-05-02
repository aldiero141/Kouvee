using Kouvee.Control;
using Kouvee.Exceptions;
using Kouvee.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Transaksi.Pembayaran
{
    public partial class FormPembayaranProduk : Form
    {
        TransaksiProduk transaksiProduk;
        int diskon;
        int subtotal;
        int totalHarga;
        int kembalian;
       
        public FormPembayaranProduk()
        {
            InitializeComponent();
            SetInitForm();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new TransaksiProdukControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiProduk(txtCari.Text) != null)
                {
                    transaksiProduk = list.SearchTransaksiProduk(txtCari.Text);
                    if (transaksiProduk.Status_Transaksi_Produk == 1)
                    {                        
                        txtNomorTransaksi.Text = transaksiProduk.ID_Transaksi_Produk;
                        txtNamaHewan.Text = transaksiProduk.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiProduk.Nama_Pelanggan;
                        txtStatusBayar.Text = "Lunas";
                        txtSubtotal.Text = Convert.ToString(transaksiProduk.Subtotal_Transaksi_Produk);
                        txtDiskon.Text = Convert.ToString(transaksiProduk.Diskon_Produk);
                        txtTotalHarga.Text = Convert.ToString(transaksiProduk.Total_Transaksi_Produk);
                        buttonCetak.Enabled = true;
                        MessageBox.Show("Transaksi Sudah Lunas!");
                    }
                    else
                    {
                        buttonHitungTotal.Enabled = true;
                        txtDiskon.Enabled = true;
                        subtotal = transaksiProduk.Subtotal_Transaksi_Produk;
                        txtNomorTransaksi.Text = transaksiProduk.ID_Transaksi_Produk;
                        txtNamaHewan.Text = transaksiProduk.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiProduk.Nama_Pelanggan;
                        txtSubtotal.Text = Convert.ToString(transaksiProduk.Subtotal_Transaksi_Produk);
                        txtStatusBayar.Text = "Belum Lunas";
                    }
                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan!");
                    txtCari.Text = string.Empty;
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonHitungTotal_Click(object sender, EventArgs e)
        {
            var ctrl = new TransaksiProdukControl();
            try
            {
                if (string.IsNullOrEmpty(txtDiskon.Text.Trim()))
                {
                    MessageBox.Show("Diskon Tidak Boleh Kosong!");
                    throw null;
                }
                ValidateNumberOnly(txtDiskon.Text);

                if (subtotal < Int32.Parse(txtDiskon.Text))
                {
                    MessageBox.Show("Diskon Melebihi Subtotal Harga!");
                    txtDiskon.Text = string.Empty;
                    throw null;
                }
                diskon = Int32.Parse(txtDiskon.Text);
                totalHarga = subtotal - Int32.Parse(txtDiskon.Text);
                txtTotalHarga.Text = Convert.ToString(totalHarga);
                MessageBox.Show("Diskon telah ditambahkan!");
                txtDiskon.Enabled = false;
                txtJumlahBayar.Enabled = true;
                buttonHitungTotal.Enabled = false;
                buttonBayar.Enabled = true;
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

        private void buttonBayar_Click(object sender, EventArgs e)
        {
            int status;
            var ctrl = new TransaksiProdukControl();
            try
            {
                if (string.IsNullOrEmpty(txtJumlahBayar.Text.Trim()))
                {
                    MessageBox.Show("Diskon Tidak Boleh Kosong!");
                    throw null;
                }
                ValidateNumberOnly(txtJumlahBayar.Text);

                if (totalHarga > Int32.Parse(txtJumlahBayar.Text))
                {
                    MessageBox.Show("Uang untuk Pembayaran Kurang!");
                    txtJumlahBayar.Text = string.Empty;
                    throw null;
                }
                status = 1;
                kembalian = Int32.Parse(txtJumlahBayar.Text) - totalHarga;
                txtKembalian.Text = Convert.ToString(kembalian);
                transaksiProduk = new TransaksiProduk(status,totalHarga,diskon);
                ctrl.UpdatePembayaranProduk(transaksiProduk, txtCari.Text);
                MessageBox.Show("Pembayaran Berhasil!");
                txtJumlahBayar.Enabled = false;
                buttonBayar.Enabled = false;
                buttonCetak.Enabled = true;
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

        private void buttonCetak_Click(object sender, EventArgs e)
        {

        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInitForm()
        {
            txtNomorTransaksi.Enabled = false;
            txtNamaHewan.Enabled = false;
            txtNamaPelanggan.Enabled = false;
            txtStatusBayar.Enabled = false;
            txtTotalHarga.Enabled = false;
            txtSubtotal.Enabled = false;
            txtDiskon.Enabled = false;
            txtJumlahBayar.Enabled = false;
            txtKembalian.Enabled = false;
            buttonCetak.Enabled = false;
            buttonBayar.Enabled = false;
            buttonHitungTotal.Enabled = false;
        }

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }


    }
}
