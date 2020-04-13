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
using System.Text.RegularExpressions;
using Kouvee.Exceptions;

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahSupplier : Form
    {
        Supplier supplier;
        public FormTambahSupplier()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNamaSupplier.Text.Trim()))
                {
                    MessageBox.Show("Nama Supplier Tidak Boleh Kosong");
                    throw null;
                }
                if (!Regex.Match(txtNamaSupplier.Text, @"^[a-zA-Z]+$").Success)
                {
                    MessageBox.Show("Nama Supplier Tidak Boleh Mengandung Angka");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtAlamatSupplier.Text.Trim()))
                {
                    MessageBox.Show("Alamat Supplier Tidak Boleh Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtNomorTelponSupplier.Text.Trim()))
                {
                    MessageBox.Show("Nomor Telpon Pegawai Tidak Boleh Kosong");
                    throw null;
                }
                
                var list = new SupplierControl();
                supplier = new Supplier(txtNamaSupplier.Text, txtAlamatSupplier.Text, txtNomorTelponSupplier.Text, FormLogin.id_pegawai);
                ValidateNumberOnly(txtNomorTelponSupplier.Text);
                list.CreateSupplier(supplier);
                MessageBox.Show("Data Berhasil Ditambah");
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
    }
}
