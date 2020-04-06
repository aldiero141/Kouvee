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
    public partial class FormTambahUkuranHewan : Form
    {
        UkuranHewan ukuranHewan;
        public FormTambahUkuranHewan()
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
                var list = new UkuranHewanControl();
                ukuranHewan = new UkuranHewan(FormLogin.id_pegawai, txtUkuranHewan.Text);
                list.CreateUkuranHewan(ukuranHewan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
