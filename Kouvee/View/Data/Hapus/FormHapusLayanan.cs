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
using MySql.Data.MySqlClient;

namespace Kouvee.View.Data.Hapus
{
    public partial class FormHapusLayanan : Form
    {
        Layanan layanan;
        public FormHapusLayanan()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new LayananControl();
                list.DeleteLayanan(txtCari.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new LayananControl();
            try
            {

                if (txtCari.Text != null && list.SearchLayanan(txtCari.Text) != null)
                {
                    layanan = list.SearchLayanan(txtCari.Text);
                    txtNamaLayanan.Text = layanan.Nama_Layanan;
                    txtHargaLayanan.Text = System.Convert.ToString(layanan.Harga_Layanan);

                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string sqlukuran = "SELECT * FROM ukuran WHERE ID_UKURAN = '" + layanan.ID_Ukuran + "';";
                    string sqljenishewan = "SELECT * FROM jenis_hewan WHERE ID_JENISHEWAN = '" + layanan.ID_JenisHewan + "';";

                    conn.Open();
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand(sqlukuran, conn);
                        MySqlDataReader result1 = cmd1.ExecuteReader();
                        if (result1 != null)
                        {
                            while (result1.Read())
                            {
                                comboBoxUkuran.Text = result1.GetString("Ukuran");
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

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusLayanan_Load(object sender, EventArgs e)
        {
            txtHargaLayanan.Enabled = false;
            txtNamaLayanan.Enabled = false;
            comboBoxUkuran.Enabled = false;
            comboBoxJenisHewan.Enabled = false;

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlukuran = "SELECT * FROM ukuran";
            string sqljenishewan = "SELECT * FROM jenis_hewan";

            #region ComboBoxUkuran
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlukuran, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxUkuran.Items.Add(result1.GetString("Ukuran"));
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
