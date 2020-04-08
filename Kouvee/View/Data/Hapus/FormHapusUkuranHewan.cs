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

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusUkuranHewan : Form
    {
        UkuranHewan ukuranHewan;
        public FormHapusUkuranHewan()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new UkuranHewanControl();
                list.DeleteUkuranHewan(txtCari.Text);

                txtUkuranHewan.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusUkuranHewan_Load(object sender, EventArgs e)
        {
            txtUkuranHewan.Enabled = false;
        }
    }
}
