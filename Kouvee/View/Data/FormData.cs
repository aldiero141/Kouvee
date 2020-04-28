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
using Kouvee.View.Data.Tampil;
using Kouvee.View.Data.Tambah;
using MySql.Data;
using MySql.Data.MySqlClient;
using Kouvee.View.Data.Ubah;
using Kouvee.View.Data.Hapus;
using Kouvee.View.Transaksi;

namespace Kouvee
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        #region Submenu Customizer
        private void CustomizeDesign()
        {
            panelTambahSubmenu.Visible = false;
            panelUbahSubmenu.Visible = false;
            panelHapusSubmenu.Visible = false;
        }

        private void hideSubmenu() 
        {
            if(panelTambahSubmenu.Visible == true)
            {
                panelTambahSubmenu.Visible = false;
            }
            if (panelUbahSubmenu.Visible == true)
            {
                panelUbahSubmenu.Visible = false;
            }
            if (panelHapusSubmenu.Visible == true)
            {
                panelHapusSubmenu.Visible = false;
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

        #region Menu Tambah
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            showSubmenu(panelTambahSubmenu);
        }

        private void buttonTambahCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahCustomer());
            hideSubmenu();
        }

        private void buttonTambahHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahHewan());
            hideSubmenu();
        }

        private void buttonTambahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahJenisHewan());
            hideSubmenu();
        }

        private void buttonTambahLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahLayanan());
            hideSubmenu();
        }

        private void buttonTambahPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahPegawai());
            hideSubmenu();
        }

        private void buttonTambahProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahProduk());
            hideSubmenu();
        }
        

        private void buttonTambahSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahSupplier());
            hideSubmenu();
        }

        private void buttonTambahUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahUkuranHewan());
            hideSubmenu();
        }
        #endregion

        #region Menu Tampil
        private void buttonTampil_Click(object sender, EventArgs e)
        {
            //showSubmenu(panelTampilSubmenu);
            openChildForm(new FormTampil());
            hideSubmenu();
        }


        #endregion

        #region Menu Ubah
        private void buttonUbah_Click(object sender, EventArgs e)
        {
            showSubmenu(panelUbahSubmenu);
        }

        private void buttonUbahCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahCustomer());
            hideSubmenu();
        }

        private void buttonUbahHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahHewan());
            hideSubmenu();
        }

        private void buttonUbahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahJenisHewan());
            hideSubmenu();
        }

        private void buttonUbahLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahLayanan());
            hideSubmenu();
        }

        private void buttonUbahPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahPegawai());
            hideSubmenu();
        }

        private void buttonUbahProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahProduk());
            hideSubmenu();
        }

        private void buttonUbahSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahSupplier());
            hideSubmenu();
        }

        private void buttonUbahUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahUkuranHewan());
            hideSubmenu();
        }
        #endregion

        #region Menu Hapus
        private void buttonHapus_Click(object sender, EventArgs e)
        {
            showSubmenu(panelHapusSubmenu);
        }

        private void buttonHapusCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusCustomer());
            hideSubmenu();
        }

        private void buttonHapusHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusHewan());
            hideSubmenu();
        }

        private void buttonHapusJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusJenisHewan());
            hideSubmenu();
        }

        private void buttonHapusLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusLayanan());
            hideSubmenu();
        }

        private void buttonHapusPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusPegawai());
            hideSubmenu();
        }

        private void buttonHapusProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusProduk());
            hideSubmenu();
        }

        private void buttonHapusSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusSupplier());
            hideSubmenu();
        }

        private void buttonHapusUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusUkuranHewan());
            hideSubmenu();
        }
        #endregion

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
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
    }
}
