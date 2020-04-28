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
            string sql = "SELECT T.ID_TRANSAKSI_LAYANAN, T.ID_PEGAWAI, P.NAMA_PEGAWAI, T.PEG_ID_PEGAWAI, " +
                "T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN ,T.TGL_TRANSAKSI_LAYANAN, T.PROGRES_LAYANAN, T.STATUS_LAYANAN, " +
                "T.TOTAL_TRANSAKSI_LAYANAN, T.SUBTOTAL_TRANSAKSI_LAYANAN, T.DISKON_LAYANAN " +
                "FROM transaksi_layanan T " +
                "JOIN hewan H ON (H.ID_HEWAN = T.ID_HEWAN) " +
                "JOIN pegawai P ON (T.ID_PEGAWAI = P.ID_PEGAWAI) " +
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
                            result.GetString("NAMA_PEGAWAI"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
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
            string sql = "SELECT T.ID_TRANSAKSI_LAYANAN, T.ID_PEGAWAI, P.NAMA_PEGAWAI, T.PEG_ID_PEGAWAI, " +
                "T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN ,T.TGL_TRANSAKSI_LAYANAN, T.PROGRES_LAYANAN, T.STATUS_LAYANAN, " +
                "T.TOTAL_TRANSAKSI_LAYANAN, T.SUBTOTAL_TRANSAKSI_LAYANAN, T.DISKON_LAYANAN " +
                "FROM transaksi_layanan T " +
                "JOIN hewan H ON (H.ID_HEWAN = T.ID_HEWAN) " +
                "JOIN pegawai P ON (T.ID_PEGAWAI = P.ID_PEGAWAI) " +
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
                            result.GetString("NAMA_PEGAWAI"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
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
    }
}
