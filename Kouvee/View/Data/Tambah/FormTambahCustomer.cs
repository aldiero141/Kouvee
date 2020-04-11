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
using Kouvee.Control;
using Kouvee.Models;
using Kouvee.View;
using Kouvee.Exceptions;

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahCustomer : Form
    {
       
        Customer customer;
        public FormTambahCustomer()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new CustomerControl();

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

                customer = new Customer(txtNamaPelanggan.Text, txtAlamatPelanggan.Text, dateTimePickerPelanggan.Text, txtNomorTelponPelanggan.Text, FormLogin.id_pegawai);
                ValidateNumberOnly(txtNomorTelponPelanggan.Text);
                list.CreateCustomer(customer);

                MessageBox.Show("Data Berhasil Ditambah");
            }
            catch (NumberOnlyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
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
