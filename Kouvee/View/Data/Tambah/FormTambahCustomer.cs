using System;
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
using Kouvee.View;

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
                customer = new Customer(txtNamaPelanggan.Text, txtNomorTelponPelanggan.Text, dateTimePickerPelanggan.Text, txtAlamatPelanggan.Text, FormLogin.id_pegawai);
                list.CreateCustomer(customer);
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
    }
}
