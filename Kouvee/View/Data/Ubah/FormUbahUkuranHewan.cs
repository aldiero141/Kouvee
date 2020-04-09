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
    public partial class FormUbahUkuranHewan : Form
    {
        UkuranHewan ukuranHewan;
        public FormUbahUkuranHewan()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new UkuranHewanControl();
            try
            {
                if (txtCari.Text != null && list.SearchUkuran(txtCari.Text) != null)
                {
                    ukuranHewan = list.SearchUkuran(txtCari.Text);
                    txtUkuranHewan.Text = ukuranHewan.Ukuran;
                    txtUkuranHewan.Enabled = true;
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
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(txtUkuranHewan.Text.Trim()))
                {
                    MessageBox.Show("Ukuran Hewan Kosong");
                    throw null;
                }
                
                var list = new UkuranHewanControl();
                ukuranHewan = new UkuranHewan(FormLogin.id_pegawai, txtUkuranHewan.Text);
                list.UpdateUkuranHewan(ukuranHewan, txtCari.Text);

                txtUkuranHewan.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormUbahUkuranHewan_Load(object sender, EventArgs e)
        {
            txtUkuranHewan.Enabled = false;
        }
    }
}
