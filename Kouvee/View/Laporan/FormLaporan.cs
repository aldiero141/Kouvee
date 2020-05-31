using Kouvee.View.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Laporan
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();
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


        private void FormLaporan_Load(object sender, EventArgs e)
        {

        }

        private void btnData_Click(object sender, EventArgs e)
        {
                var form = new MainForm();
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

        private void btnCashier_Click(object sender, EventArgs e)
        {
            var form = new FormTransaksi();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Close(); };
            form.Show();
            this.Hide();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProdukTerlaris_Click(object sender, EventArgs e)
        {
            openChildForm(new FormProdukTerlaris());
        }

        private void btnLayananTerlaris_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLayananTerlaris());
        }

        private void btnPendapatanTahunan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPendapatanTahunan());
        }

        private void btnPendapatanBulanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPendapatanBulanan());
        }

        private void btnPengadaanProdukTahunan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPengadaanTahunan());
        }

        private void btnPengadaanProdukBulanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPengadaanBulanan());
        }
    }
}
