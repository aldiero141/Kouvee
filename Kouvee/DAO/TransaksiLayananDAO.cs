using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.Models;

namespace Kouvee.DAO
{
    class TransaksiLayananDAO
    {
        public static string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
        MySqlConnection conn = new MySqlConnection(connStr);

        public void makeConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect...");
                Console.WriteLine(ex.ToString());
            }
        }

        public void closeConnection()
        {
            try
            {
                conn.Close();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to close...");
                Console.WriteLine(ex.ToString());
            }
        }

        public List<TransaksiLayanan> ShowTransaksiLayanan()
        {
            string sql = "SELECT T.ID_TRANSAKSI_LAYANAN, T.ID_PEGAWAI, C.NAMA_PEGAWAI AS NAMA_CS, T.PEG_ID_PEGAWAI, K.NAMA_PEGAWAI AS NAMA_KASIR, " +
                "T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN ,T.TGL_TRANSAKSI_LAYANAN, T.PROGRES_LAYANAN, T.STATUS_LAYANAN, " +
                "T.TOTAL_TRANSAKSI_LAYANAN, T.SUBTOTAL_TRANSAKSI_LAYANAN, T.DISKON_LAYANAN " +
                "FROM transaksi_layanan T " +
                "JOIN hewan H ON (H.ID_HEWAN = T.ID_HEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (H.ID_HEWAN = G.ID_PELANGGAN); ";
         
            List < TransaksiLayanan> TransaksiLayananList = new List<TransaksiLayanan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        TransaksiLayanan TL = new TransaksiLayanan(
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetInt32("ID_PEGAWAI"),
                            result.GetString("NAMA_CS"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetString("NAMA_KASIR"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetDateTime("TGL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("PROGRES_LAYANAN"),
                            result.GetInt32("STATUS_LAYANAN"),
                            result.GetInt32("TOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("DISKON_LAYANAN"));
                        TransaksiLayananList.Add(TL);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return TransaksiLayananList;
        }

        public TransaksiLayanan SearchTransaksiLayanan(String idTransaksi)
        {
            string sql = "SELECT T.ID_TRANSAKSI_LAYANAN, T.ID_PEGAWAI, C.NAMA_PEGAWAI AS NAMA_CS, T.PEG_ID_PEGAWAI, K.NAMA_PEGAWAI AS NAMA_KASIR, " +
                "T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN ,T.TGL_TRANSAKSI_LAYANAN, T.PROGRES_LAYANAN, T.STATUS_LAYANAN, " +
                "T.TOTAL_TRANSAKSI_LAYANAN, T.SUBTOTAL_TRANSAKSI_LAYANAN, T.DISKON_LAYANAN " +
                "FROM transaksi_layanan T " +
                "JOIN hewan H ON (H.ID_HEWAN = T.ID_HEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (H.ID_HEWAN = G.ID_PELANGGAN)" +
                "WHERE T.ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            TransaksiLayanan transaksiLayanan = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        transaksiLayanan = new TransaksiLayanan(
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetInt32("ID_PEGAWAI"),
                            result.GetString("NAMA_CS"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetString("NAMA_KASIR"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetDateTime("TGL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("PROGRES_LAYANAN"),
                            result.GetInt32("STATUS_LAYANAN"),
                            result.GetInt32("TOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("DISKON_LAYANAN"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return transaksiLayanan;
        }

        public void UpdateTransaksiLayanan(TransaksiLayanan TL, String idTransaksi)
        {
            string sql = "UPDATE transaksi_layanan SET ID_HEWAN = (SELECT ID_HEWAN FROM hewan WHERE NAMA_HEWAN = '" + TL.Nama_Hewan + "')"
                     + ", ID_PEGAWAI = (SELECT ID_PEGAWAI FROM pegawai WHERE NAMA_PEGAWAI = '" + TL.Nama_CS + "')"
                     + ", PEG_ID_PEGAWAI = (SELECT ID_PEGAWAI FROM pegawai WHERE NAMA_PEGAWAI = '" + TL.Nama_Kasir + "')"
                     + ", PROGRES_LAYANAN = '" + TL.Progres_Layanan + "' ,STATUS_LAYANAN = '" + TL.Status_Layanan + "' ,DISKON_LAYANAN = '" + TL.Diskon_Layanan + "'"
                     + ", TOTAL_TRANSAKSI_LAYANAN = '" + TL.Total_Transaksi_Layanan + "'"
                     + " WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Updated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateSubtotalLayanan(int subtotal, String idTransaksi)
        {
            string sql = "UPDATE transaksi_layanan SET SUBTOTAL_TRANSAKSI_LAYANAN = '" + subtotal + "'"
                     + " WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Updated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateSubtotalLayanan(TransaksiLayanan TL, String idTransaksi)
        {
            string sql = "UPDATE transaksi_layanan SET SUBTOTAL_TRANSAKSI_LAYANAN = '" + TL.Subtotal_Transaksi_Layanan + "'"
                     + " WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Updated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdatePembayaranLayanan(TransaksiLayanan TL, String idTransaksi)
        {
            string sql = "UPDATE transaksi_layanan SET STATUS_LAYANAN = '" + TL.Status_Layanan + "'"
                     + ", TOTAL_TRANSAKSI_LAYANAN = '" + TL.Total_Transaksi_Layanan + "'"
                     + ", DISKON_LAYANAN = '" + TL.Diskon_Layanan + "'"
                     + " ,PEG_ID_PEGAWAI ='" + TL.Peg_ID_Pegawai + "'"
                     + " WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Updated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteTransaksiLayanan(String idTransaksi)
        {
            string sql = "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM transaksi_layanan WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "'; SET FOREIGN_KEY_CHECKS = 1;";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Deleted...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete...");
                Console.WriteLine(ex.ToString());
            }
        }

        public TransaksiLayanan ShowNotaLayanan(String idTransaksi)
        {
            string sql = "SELECT T.ID_TRANSAKSI_LAYANAN, C.NAMA_PEGAWAI AS NAMA_CS, K.NAMA_PEGAWAI AS NAMA_KASIR, " +
                "H.NAMA_HEWAN, G.NAMA_PELANGGAN ,T.TGL_TRANSAKSI_LAYANAN ,T.TOTAL_TRANSAKSI_LAYANAN, " +
                "T.SUBTOTAL_TRANSAKSI_LAYANAN, T.DISKON_LAYANAN, G.PHONE_PELANGGAN, J.JENISHEWAN " +
                "FROM transaksi_layanan T " +
                "JOIN hewan H ON (H.ID_HEWAN = T.ID_HEWAN) " +
                "JOIN jenis_hewan J ON (H.ID_JENISHEWAN = J.ID_JENISHEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (H.ID_HEWAN = G.ID_PELANGGAN) " + 
                "WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            TransaksiLayanan transaksiLayanan = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        transaksiLayanan = new TransaksiLayanan(
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetString("NAMA_CS"),
                            result.GetString("NAMA_KASIR"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetDateTime("TGL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("TOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_LAYANAN"),
                            result.GetInt32("DISKON_LAYANAN"),
                            result.GetString("PHONE_PELANGGAN"),
                            result.GetString("JENISHEWAN"));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return transaksiLayanan;
        }
        public void UpdateTotalHargaLayanan(int harga, String idTransaksi)
        {
            string sql = "UPDATE transaksi_layanan SET TOTAL_TRANSAKSI_LAYANAN = '" + harga + "'"
                     + " WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Updated...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
