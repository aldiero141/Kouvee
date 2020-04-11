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

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusJenisHewan : Form
    {
        JenisHewan jenisHewan;
        public FormHapusJenisHewan()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new JenisHewanControl();
            try
            {
                if (txtCari.Text != null && list.SearchJenisHewan(txtCari.Text) != null)
                {
                    buttonHapus.Enabled = true;

                    jenisHewan = list.SearchJenisHewan(txtCari.Text);
                    txtJenisHewan.Text = jenisHewan.Jenis_Hewan;
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

        private void FormHapusJenisHewan_Load(object sender, EventArgs e)
        {
            buttonHapus.Enabled = false;
            txtJenisHewan.Enabled = false;
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

                var list = new JenisHewanControl();
                list.DeleteJenisHewan(txtCari.Text);
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
    }
}
