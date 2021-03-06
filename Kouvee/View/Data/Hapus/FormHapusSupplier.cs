﻿using System;
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


namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusSupplier : Form
    {
        Supplier supplier;
        public FormHapusSupplier()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new SupplierControl();
            try
            {
                if (txtCari.Text != null && list.SearchSupplier(txtCari.Text) != null)
                {
                    buttonHapus.Enabled = true;

                    supplier = list.SearchSupplier(txtCari.Text);

                    txtNamaSupplier.Text = supplier.Nama_Supplier;
                    txtAlamatSupplier.Text = supplier.Alamat_Supplier;
                    txtNomorTelponSupplier.Text = supplier.Phone_Supplier;
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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }

                var list = new SupplierControl();
                list.DeleteSupplier(txtCari.Text);
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

        private void FormHapusSupplier_Load(object sender, EventArgs e)
        {
            buttonHapus.Enabled = false;
            txtNamaSupplier.Enabled = false;
            txtAlamatSupplier.Enabled = false;
            txtNomorTelponSupplier.Enabled = false;
        }
    }
}
