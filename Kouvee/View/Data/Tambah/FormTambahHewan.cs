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
using MySql.Data.MySqlClient;

namespace Kouvee.View.Data.Tambah
{
    public partial class FormTambahHewan : Form
    {
        Hewan hewan;
        
        public FormTambahHewan()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtNamaHewan.Text.Trim()))
                {
                    MessageBox.Show("Nama Hewan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxNamaPelanggan.Text.Trim()))
                {
                    MessageBox.Show("Nama Pelanggan Kosong");
                    throw null;
                }
                if (string.IsNullOrEmpty(comboBoxJenisHewan.Text.Trim()))
                {
                    MessageBox.Show("Jenis Hewan Kosong");
                    throw null;
                }

                var list = new HewanControl();
                hewan = new Hewan(comboBoxNamaPelanggan.Text, comboBoxJenisHewan.Text, FormLogin.id_pegawai, txtNamaHewan.Text, dateTimePickerHewan.Text);
                list.CreateHewan(hewan);
                MessageBox.Show("Data Berhasil Ditambah");
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

        private void FormTambahHewan_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlpelanggan = "SELECT * FROM pelanggan";
            string sqljenishewan = "SELECT * FROM jenis_hewan";

            #region ComboBoxNamaPelanggan
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlpelanggan, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxNamaPelanggan.Items.Add(result1.GetString("Nama_Pelanggan"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            #endregion

            #region ComboBoxJenisHewan
            conn.Open();
            try
            {
                MySqlCommand cmd2 = new MySqlCommand(sqljenishewan, conn);
                MySqlDataReader result2 = cmd2.ExecuteReader();
                if (result2 != null)
                {
                    while (result2.Read())
                    {
                        comboBoxJenisHewan.Items.Add(result2.GetString("Jenishewan"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            #endregion
        }
    }
}
