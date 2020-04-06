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
                var list = new SupplierControl();
                supplier = new Supplier(txtNamaSupplier.Text, txtAlamatSupplier.Text, txtNomorTelponSupplier.Text, FormLogin.id_pegawai);
                list.CreateSupplier(supplier);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
