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

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahJenisHewan : Form
    {
        JenisHewan jenisHewan;
        public FormTambahJenisHewan()
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
                var list = new JenisHewanControl();
                jenisHewan = new JenisHewan(FormLogin.id_pegawai,txtJenisHewan.Text);
                list.CreateJenisHewan(jenisHewan);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
