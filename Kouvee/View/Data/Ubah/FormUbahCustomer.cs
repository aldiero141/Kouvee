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
using Kouvee.View;
using System.Text.RegularExpressions;
using Kouvee.Exceptions;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahCustomer : Form
    {
        Customer customer;
        
        public FormUbahCustomer()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNamaPelanggan.Text.Trim()))
                {
                    MessageBox.Show("Nama Pelanggan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtAlamatPelanggan.Text.Trim()))
                {
                    MessageBox.Show("Alamat Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNomorTelponPelanggan.Text.Trim()))
                {
                    MessageBox.Show("Nomor Telpon Kosong");
                    throw null;
                }
                
                var list = new CustomerControl();
                customer = new Customer(txtNamaPelanggan.Text, txtAlamatPelanggan.Text, dateTimePickerPelanggan.Text, txtNomorTelponPelanggan.Text, FormLogin.id_pegawai);
                list.UpdateCustomer(customer,txtCari.Text);
                ValidateNumberOnly(txtNomorTelponPelanggan.Text);

                txtNamaPelanggan.Enabled = false;
                txtAlamatPelanggan.Enabled = false;
                txtNomorTelponPelanggan.Enabled = false;
                dateTimePickerPelanggan.Enabled = false;

                MessageBox.Show("Data Berhasil Diubah");
                buttonUbah.Enabled = false;
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

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new CustomerControl(); 
            try
            {
                if (txtCari.Text != null && list.SearchCustomer(txtCari.Text) != null)
                {
                    buttonUbah.Enabled = true;
                    customer = list.SearchCustomer(txtCari.Text);

                    txtNamaPelanggan.Text = customer.Nama_Pelanggan;
                    txtAlamatPelanggan.Text = customer.Alamat_Pelanggan;
                    txtNomorTelponPelanggan.Text = customer.Phone_Pelanggan;
                    dateTimePickerPelanggan.Value = DateTime.Parse(customer.Tgl_Lahir_Pelanggan);

                    txtNamaPelanggan.Enabled = true;
                    txtAlamatPelanggan.Enabled = true;
                    txtNomorTelponPelanggan.Enabled = true;
                    dateTimePickerPelanggan.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan");
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        private void FormUbahCustomer_Load(object sender, EventArgs e)
        {
            txtNamaPelanggan.Enabled = false;
            txtAlamatPelanggan.Enabled = false; 
            txtNomorTelponPelanggan.Enabled = false;
            dateTimePickerPelanggan.Enabled = false;
            buttonUbah.Enabled = false;
        }
    }
}
