using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Transaksi.Layanan
{
    public partial class FormEditTransaksiLayanan : Form
    {
        public FormEditTransaksiLayanan()
        {
            InitializeComponent();
        }

        private void FormEditTransaksiLayanan_Load(object sender, EventArgs e)
        {
            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sqlhewan = "SELECT * FROM hewan";
            string sqllayanan = "SELECT * FROM layanan";

            #region ComboBoxHewan
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqlhewan, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxHewan.Items.Add(result1.GetString("Nama_Hewan"));
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

            #region ComboBoxLayanan
            conn.Open();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sqllayanan, conn);
                MySqlDataReader result1 = cmd1.ExecuteReader();
                if (result1 != null)
                {
                    while (result1.Read())
                    {
                        comboBoxLayanan.Items.Add(result1.GetString("Nama_Layanan"));
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
