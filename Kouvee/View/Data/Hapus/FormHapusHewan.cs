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

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusHewan : Form
    {
        Hewan hewan;
        public FormHapusHewan()
        {
            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new HewanControl();
            try
            {
                if (txtCari.Text != null && list.SearchHewan(txtCari.Text) != null)
                {
                    hewan = list.SearchHewan(txtCari.Text);
                    txtNamaHewan.Text = hewan.Nama_Hewan;
                    dateTimePickerHewan.Value = DateTime.Parse(hewan.Tgl_Lahir_Hewan);

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlpelanggan = "SELECT * FROM pelanggan WHERE ID_PELANGGAN = '" + hewan.ID_Pelanggan + "';";
                    string sqljenishewan = "SELECT * FROM jenis_hewan WHERE ID_JENISHEWAN = '" + hewan.ID_Jenis + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlpelanggan, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxNamaPelanggan.Text = result1.GetString("Nama_Pelanggan");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd2 = new MySqlCommand(sqljenishewan, conn);
                        MySqlDataReader result2 = cmd2.ExecuteReader();
                        if (result2 != null)
                        {
                            while (result2.Read())
                            {
                                comboBoxJenisHewan.Text = result2.GetString("Jenishewan");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read...");
                        Console.WriteLine(ex.ToString());
                    }
                    conn.Close();
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new HewanControl();
                list.DeleteHewan(txtCari.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ;
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusHewan_Load(object sender, EventArgs e)
        {
            txtNamaHewan.Enabled = false;
            dateTimePickerHewan.Enabled = false;
            comboBoxNamaPelanggan.Enabled = false;
            comboBoxJenisHewan.Enabled = false;

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
