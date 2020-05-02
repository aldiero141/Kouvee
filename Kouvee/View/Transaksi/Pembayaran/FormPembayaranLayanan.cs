using Kouvee.Models;
using Kouvee.Exceptions;
using Kouvee.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Kouvee.View.Transaksi.Pembayaran
{
    public partial class FormPembayaranLayanan : Form
    {
        TransaksiLayanan transaksiLayanan;
        int diskon;
        int subtotal;
        int totalHarga;
        int kembalian;

        public FormPembayaranLayanan()
        {
            InitializeComponent();
            SetInitForm();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new TransaksiLayananControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiLayanan(txtCari.Text) != null)
                {
                    transaksiLayanan = list.SearchTransaksiLayanan(txtCari.Text);
                    if (transaksiLayanan.Status_Layanan == 1)
                    {
                        txtNomorTransaksi.Text = transaksiLayanan.ID_Transaksi_Layanan;
                        txtNamaHewan.Text = transaksiLayanan.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiLayanan.Nama_Pelanggan;
                        txtStatusBayar.Text = "Lunas";
                        txtSubtotal.Text = Convert.ToString(transaksiLayanan.Subtotal_Transaksi_Layanan);
                        txtDiskon.Text = Convert.ToString(transaksiLayanan.Diskon_Layanan);
                        txtTotalHarga.Text = Convert.ToString(transaksiLayanan.Total_Transaksi_Layanan);
                        if (transaksiLayanan.Progres_Layanan == 1) txtProgress.Text = "Selesai";
                        else txtProgress.Text = "Belum Selesai";
                        buttonCetak.Enabled = true;
                        MessageBox.Show("Transaksi Sudah Lunas!");
                    }
                    else
                    {
                        buttonHitungTotal.Enabled = true;
                        txtDiskon.Enabled = true;
                        subtotal = transaksiLayanan.Subtotal_Transaksi_Layanan;
                        txtNomorTransaksi.Text = transaksiLayanan.ID_Transaksi_Layanan;
                        txtNamaHewan.Text = transaksiLayanan.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiLayanan.Nama_Pelanggan;
                        txtSubtotal.Text = Convert.ToString(transaksiLayanan.Subtotal_Transaksi_Layanan);
                        if (transaksiLayanan.Progres_Layanan == 1) txtProgress.Text = "Selesai";
                        else txtProgress.Text = "Belum Selesai";
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
            var ctrl = new TransaksiLayananControl();
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
                transaksiLayanan = new TransaksiLayanan(status, totalHarga, diskon);
                ctrl.UpdatePembayaranLayanan(transaksiLayanan, txtCari.Text);
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
            txtProgress.Enabled = false;
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
