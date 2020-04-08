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

                }
            }
            catch
            {

            }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new SupplierControl();
                supplier = new Supplier(txtNamaSupplier.Text, txtAlamatSupplier.Text, txtNomorTelponSupplier.Text, FormLogin.id_pegawai);
                list.UpdateSupplier(supplier, txtCari.Text);

                txtNamaSupplier.Enabled = false;
                txtAlamatSupplier.Enabled = false;
                txtNomorTelponSupplier.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormUbahSupplier_Load(object sender, EventArgs e)
        {
            txtNamaSupplier.Enabled = false;
            txtAlamatSupplier.Enabled = false;
            txtNomorTelponSupplier.Enabled = false;
        }
    }
}
