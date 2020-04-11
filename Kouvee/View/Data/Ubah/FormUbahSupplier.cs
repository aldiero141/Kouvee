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
using Kouvee.Exceptions;
using System.Text.RegularExpressions;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahSupplier : Form
    {
        Supplier supplier;

        public FormUbahSupplier()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new SupplierControl();
            try
            {
                if (txtCari.Text != null && list.SearchSupplier(txtCari.Text) != null)
                {
                    buttonUbah.Enabled = true;
                    supplier = list.SearchSupplier(txtCari.Text);

                    txtNamaSupplier.Text = supplier.Nama_Supplier;
                    txtAlamatSupplier.Text = supplier.Alamat_Supplier;
                    txtNomorTelponSupplier.Text = supplier.Phone_Supplier;
                    
                    txtNamaSupplier.Enabled = true;
                    txtAlamatSupplier.Enabled = true;
                    txtNomorTelponSupplier.Enabled = true;
                    
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

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNamaSupplier.Text.Trim()))
                {
                    MessageBox.Show("Nama Supplier Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtAlamatSupplier.Text.Trim()))
                {
                    MessageBox.Show("Alamat Supplier Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNomorTelponSupplier.Text.Trim()))
                {
                    MessageBox.Show("Nomor Telpon Pegawai Kosong");
                    throw null;
                }
                

                var list = new SupplierControl();
                supplier = new Supplier(txtNamaSupplier.Text, txtAlamatSupplier.Text, txtNomorTelponSupplier.Text, FormLogin.id_pegawai);
                ValidateNumberOnly(txtNomorTelponSupplier.Text);
                list.UpdateSupplier(supplier, txtCari.Text);

                txtNamaSupplier.Enabled = false;
                txtAlamatSupplier.Enabled = false;
                txtNomorTelponSupplier.Enabled = false;

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

        private void FormUbahSupplier_Load(object sender, EventArgs e)
        {
            buttonUbah.Enabled = false;
            txtNamaSupplier.Enabled = false;
            txtAlamatSupplier.Enabled = false;
            txtNomorTelponSupplier.Enabled = false;
        }
    }
}
