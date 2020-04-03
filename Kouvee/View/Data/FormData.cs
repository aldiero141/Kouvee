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

namespace Kouvee
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        //private void btnSupplier_Click(object sender, EventArgs e)
        //{
        //    stat = "supplier";
        //    var list = new SupplierControl();
        //    dataGridRead.DataSource = list.ShowSupplier();
        //}

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
        #endregion

        #region Menu Tambah
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            showSubmenu(panelTambahSubmenu);
        }

        private void buttonTambahCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahCustomer());
            //
            // Code tambah
            //
            hideSubmenu();
        }

        private void buttonTambahHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahHewan());
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonTambahJenisHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahJenisHewan());
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonTambahLayanan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahLayanan());
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonTambahPegawai_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahPegawai());
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonTambahProduk_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahProduk());
            //
            // Code 
            //
            hideSubmenu();
        }
        

        private void buttonTambahSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahSupplier());
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonTambahUkuranHewan_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahUkuranHewan());
            //
            // Code 
            //
            hideSubmenu();
        }
        #endregion

        #region Menu Tampil
        private void buttonTampil_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTampil());
        }
        #endregion

        #region Menu Ubah
        private void buttonUbah_Click(object sender, EventArgs e)
        {
            showSubmenu(panelUbahSubmenu);
        }

        private void buttonUbahCustomer_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahJenisHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahLayanan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahPegawai_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahProduk_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahSupplier_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonUbahUkuranHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
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
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusJenisHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusLayanan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusPegawai_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusProduk_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusSupplier_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }

        private void buttonHapusUkuranHewan_Click(object sender, EventArgs e)
        {
            //
            // Code 
            //
            hideSubmenu();
        }
        #endregion

        #region Keluar
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        { 
            if(activeForm != null)
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
        
    }
}
