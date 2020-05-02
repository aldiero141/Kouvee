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
        }

        private void buttonTambahHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahHewan());
        }

        private void buttonTambahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahJenisHewan());
        }

        private void buttonTambahLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahLayanan());
        }

        private void buttonTambahPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahPegawai());
        }

        private void buttonTambahProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahProduk());
        }
        

        private void buttonTambahSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahSupplier());
        }

        private void buttonTambahUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahUkuranHewan());
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
        }

        private void buttonUbahHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahHewan());
        }

        private void buttonUbahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahJenisHewan());
        }

        private void buttonUbahLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahLayanan());
        }

        private void buttonUbahPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahPegawai());
        }

        private void buttonUbahProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahProduk());
        }

        private void buttonUbahSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahSupplier());
        }

        private void buttonUbahUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUbahUkuranHewan());
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
        }

        private void buttonHapusHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusHewan());
        }

        private void buttonHapusJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusJenisHewan());
        }

        private void buttonHapusLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusLayanan());
        }

        private void buttonHapusPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusPegawai());
        }

        private void buttonHapusProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusProduk());
        }

        private void buttonHapusSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusSupplier());
        }

        private void buttonHapusUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHapusUkuranHewan());
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
