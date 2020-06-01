using Kouvee.Control;
using Kouvee.Models;
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


namespace Kouvee
{
    public partial class FormLogin : Form
    {
        public static int id_pegawai;
        public static string nama;
        public static string password;
        public static string jabatan;
        Akun akun;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var list = new AkunControl();
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("Username Tidak Boleh Kosong");
                    throw null;
                }
                else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Password Tidak Boleh Kosong");
                    throw null;
                }
                else if (list.SearchAkun(txtUsername.Text,txtPassword.Text) == null)
                {
                    MessageBox.Show("Akun Tidak Ditemukan");
                    throw null;
                }
                else
                {
                    akun = list.SearchAkun(txtUsername.Text, txtPassword.Text);
                    id_pegawai = akun.ID_Pegawai;
                    jabatan = akun.Jabatan;
                    nama = akun.Nama_Pegawai;
                    password = akun.Password;

                    if(jabatan == "Admin")
                    {
                        var frm = new MainForm();
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.FormClosing += delegate { this.Show(); };
                        frm.Show();
                        this.Hide();
                    }
                    else if (jabatan == "Kasir")
                    {
                        var frm = new FormTransaksi();
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.FormClosing += delegate { this.Show(); };
                        frm.Show();
                        this.Hide();
                    }
                    else if (jabatan == "CS")
                    {
                        var frm = new MainForm();
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.FormClosing += delegate { this.Show(); };
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
