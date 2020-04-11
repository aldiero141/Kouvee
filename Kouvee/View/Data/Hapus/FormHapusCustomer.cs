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

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusCustomer : Form
    {
        Customer customer;
        public FormHapusCustomer()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            
            var list = new CustomerControl();
            try
            {
                if (txtCari.Text != null && list.SearchCustomer(txtCari.Text) != null)
                {
                    buttonHapus.Enabled = true;
                    customer = list.SearchCustomer(txtCari.Text);
                    txtNamaPelanggan.Text = customer.Nama_Pelanggan;
                    txtAlamatPelanggan.Text = customer.Alamat_Pelanggan;
                    txtNomorTelponPelanggan.Text = customer.Phone_Pelanggan;
                    dateTimePickerPelanggan.Value = DateTime.Parse(customer.Tgl_Lahir_Pelanggan);
                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan");
                    buttonHapus.Enabled = false;
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }

                var list = new CustomerControl();
                list.DeleteCustomer(txtCari.Text);
                MessageBox.Show("Data Berhasil Dihapus");
                buttonHapus.Enabled = false;
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
        private void FormHapusCustomer_Load(object sender, EventArgs e)
        {
            buttonHapus.Enabled = false;
            txtNamaPelanggan.Enabled = false;
            txtAlamatPelanggan.Enabled = false;
            txtNomorTelponPelanggan.Enabled = false;
            dateTimePickerPelanggan.Enabled = false;
        }
    }
}
