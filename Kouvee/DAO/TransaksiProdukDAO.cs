using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.Models;

namespace Kouvee.DAO
{
    class TransaksiProdukDAO
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

        public List<TransaksiProduk> ShowTransaksiProduk()
        {
            string sql = "SELECT T.ID_TRANSAKSI_PRODUK, T.ID_PEGAWAI, P.NAMA_PEGAWAI, T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN, T.PEG_ID_PEGAWAI, " +
                "T.STATUS_TRANSAKSI_PRODUK, T.TGL_TRANSAKSI, T.SUBTOTAL_TRANSAKSI_PRODUK, T.TOTAL_TRANSAKSI_PRODUK, T.DISKON_PRODUK " +
                "FROM transaksi_produk T " +
                "JOIN hewan H ON (T.ID_HEWAN = H.ID_HEWAN) " +
                "JOIN pegawai P ON (T.ID_PEGAWAI = P.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (G.ID_PELANGGAN = H.ID_PELANGGAN);";

            List<TransaksiProduk> TransaksiProdukList = new List<TransaksiProduk>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        TransaksiProduk TP = new TransaksiProduk(
                            result.GetString("ID_TRANSAKSI_PRODUK"),
                            result.GetInt32("ID_PEGAWAI"),
                            result.GetString("NAMA_PEGAWAI"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetInt32("STATUS_TRANSAKSI_PRODUK"),
                            result.GetDateTime("TGL_TRANSAKSI"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("TOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("DISKON_PRODUK"));
                        TransaksiProdukList.Add(TP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return TransaksiProdukList;
        }

        public TransaksiProduk SearchTransaksiProduk(String idTransaksi)
        {
            string sql = "SELECT T.ID_TRANSAKSI_PRODUK, T.ID_PEGAWAI, P.NAMA_PEGAWAI, T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN, T.PEG_ID_PEGAWAI, " +
                "T.STATUS_TRANSAKSI_PRODUK, T.TGL_TRANSAKSI, T.SUBTOTAL_TRANSAKSI_PRODUK, T.TOTAL_TRANSAKSI_PRODUK, T.DISKON_PRODUK " +
                "FROM transaksi_produk T " +
                "JOIN hewan H ON (T.ID_HEWAN = H.ID_HEWAN) " +
                "JOIN pegawai P ON (T.ID_PEGAWAI = P.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (G.ID_PELANGGAN = H.ID_PELANGGAN) " +
                "WHERE T.ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

            TransaksiProduk transaksiProduk = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        transaksiProduk = new TransaksiProduk(
                            result.GetString("ID_TRANSAKSI_PRODUK"),
                            result.GetInt32("ID_PEGAWAI"),
                            result.GetString("NAMA_PEGAWAI"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetInt32("STATUS_TRANSAKSI_PRODUK"),
                            result.GetDateTime("TGL_TRANSAKSI"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("TOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("DISKON_PRODUK"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return transaksiProduk;
        }
    }
}
