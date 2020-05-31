using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kouvee.View.Transaksi;
using Kouvee.View.Transaksi.Produk;
using Kouvee.View.Transaksi.Layanan;
using Kouvee.View.Transaksi.Pembayaran;
using Kouvee.View.Laporan;

namespace Kouvee.View.Transaksi
{
    public partial class FormTransaksi : Form
    {
        public FormTransaksi()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        #region Submenu Customizer
        private void CustomizeDesign()
        {
            panelTransaksiProduk.Visible = false;
            panelTransaksiLayanan.Visible = false;
            panelPembayaran.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelTransaksiProduk.Visible == true)
            {
                panelTransaksiProduk.Visible = false;
            }
            if (panelTransaksiLayanan.Visible == true)
            {
                panelTransaksiLayanan.Visible = false;
            }
            if (panelPembayaran.Visible == true)
            {
                panelPembayaran.Visible = false;
            }
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion

        #region Menu_TransaksiProduk
        private void buttonTransaksiProduk_Click(object sender, EventArgs e)
        {
            showSubmenu(panelTransaksiProduk);
        }

        private void buttonUbahHapusTransaksiProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEditTransaksiProduk());
            
        }

        private void buttonTampilTransaksiProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTampilTransaksiProduk());
            
        }

        private void buttonCetakNotaProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTampilTransaksiProduk());
        }
        #endregion

        #region Menu_TransaksiLayanan
        private void buttonTransaksiLayanan_Click(object sender, EventArgs e)
        {
            showSubmenu(panelTransaksiLayanan);
        }

        private void buttonEditTransaksiLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEditTransaksiLayanan());
        }

        private void buttonUbahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTampilTransaksiLayanan());
        }

        private void buttonCetakNotaLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTampilTransaksiProduk());
        }
        #endregion

        #region Menu_Pembayaran
        private void buttonPembayaran_Click(object sender, EventArgs e)
        {
            showSubmenu(panelPembayaran);
        }

        private void buttonPembayaranProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPembayaranProduk());
        }

        private void buttonPembayaranLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPembayaranLayanan());
        }
        #endregion

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            var form = new FormTransaksi();
            var frm2 = new FormLogin();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Close(); };
            form.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var form = new FormLaporan();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Close(); };
            form.Show();
            this.Hide();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            var frm2 = new FormLogin();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Close(); };
            form.Show();
            this.Hide();
        }
    }
}
