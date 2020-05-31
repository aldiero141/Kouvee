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
            string sql = "SELECT T.ID_TRANSAKSI_PRODUK, T.ID_PEGAWAI, C.NAMA_PEGAWAI AS NAMA_CS, T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN, T.PEG_ID_PEGAWAI, K.NAMA_PEGAWAI AS NAMA_KASIR,  " +
                "T.STATUS_TRANSAKSI_PRODUK, T.TGL_TRANSAKSI, T.SUBTOTAL_TRANSAKSI_PRODUK, T.TOTAL_TRANSAKSI_PRODUK, T.DISKON_PRODUK " +
                "FROM transaksi_produk T " +
                "JOIN hewan H ON (T.ID_HEWAN = H.ID_HEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
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
                            result.GetString("NAMA_CS"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetString("NAMA_KASIR"),
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
            string sql = "SELECT T.ID_TRANSAKSI_PRODUK, T.ID_PEGAWAI, C.NAMA_PEGAWAI AS NAMA_CS, T.ID_HEWAN, H.NAMA_HEWAN, G.NAMA_PELANGGAN, T.PEG_ID_PEGAWAI, K.NAMA_PEGAWAI AS NAMA_KASIR, " +
                "T.STATUS_TRANSAKSI_PRODUK, T.TGL_TRANSAKSI, T.SUBTOTAL_TRANSAKSI_PRODUK, T.TOTAL_TRANSAKSI_PRODUK, T.DISKON_PRODUK " +
                "FROM transaksi_produk T " +
                "JOIN hewan H ON (T.ID_HEWAN = H.ID_HEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
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
                            result.GetString("NAMA_CS"),
                            result.GetInt32("ID_HEWAN"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetInt32("PEG_ID_PEGAWAI"),
                            result.GetString("NAMA_KASIR"),
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

        public void UpdateTransaksiProduk(TransaksiProduk TP, String idTransaksi)
        {
            string sql = "UPDATE transaksi_produk SET ID_HEWAN = (SELECT ID_HEWAN FROM hewan WHERE NAMA_HEWAN = '" + TP.Nama_Hewan + "')"
                     + " ,ID_PEGAWAI = (SELECT ID_PEGAWAI FROM pegawai WHERE NAMA_PEGAWAI = '" + TP.Nama_CS + "')"
                     + " ,PEG_ID_PEGAWAI = (SELECT ID_PEGAWAI FROM pegawai WHERE NAMA_PEGAWAI = '" + TP.Nama_Kasir + "')"
                     + " ,STATUS_TRANSAKSI_PRODUK =" + TP.Status_Transaksi_Produk + ",DISKON_PRODUK ='" + TP.Diskon_Produk + "'"
                     + " ,TOTAL_TRANSAKSI_PRODUK ='" + TP.Total_Transaksi_Produk + "'"
                     + " WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

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

        public void UpdateSubtotalProduk(TransaksiProduk TP, String idTransaksi)
        {
            string sql = "UPDATE transaksi_produk SET SUBTOTAL_TRANSAKSI_PRODUK = '" +  TP.Subtotal_Transaksi_Produk + "'"
                     + " WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

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

        public void UpdatePembayaranProduk(TransaksiProduk TP, String idTransaksi)
        {
            string sql = "UPDATE transaksi_produk SET STATUS_TRANSAKSI_PRODUK ='" + TP.Status_Transaksi_Produk + "'"
                     + " ,TOTAL_TRANSAKSI_PRODUK ='" + TP.Total_Transaksi_Produk + "'"
                     + " ,DISKON_PRODUK ='" + TP.Diskon_Produk + "'"
                     + " ,PEG_ID_PEGAWAI ='" + TP.Peg_ID_Pegawai + "'"
                     + " WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

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

        public void DeleteTransaksiProduk(String idTransaksi)
        {
            string sql = "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM transaksi_produk WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "'; SET FOREIGN_KEY_CHECKS = 1;";
           
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

        public TransaksiProduk ShowNotaProduk(String idTransaksi)
        {
            string sql = "SELECT T.ID_TRANSAKSI_PRODUK, C.NAMA_PEGAWAI AS NAMA_CS, H.NAMA_HEWAN, G.NAMA_PELANGGAN, K.NAMA_PEGAWAI AS NAMA_KASIR, " +
                "T.TGL_TRANSAKSI, T.SUBTOTAL_TRANSAKSI_PRODUK, T.TOTAL_TRANSAKSI_PRODUK, T.DISKON_PRODUK, G.PHONE_PELANGGAN, J.JENISHEWAN " +
                "FROM transaksi_produk T " +
                "JOIN hewan H ON (T.ID_HEWAN = H.ID_HEWAN) " +
                "JOIN jenis_hewan J ON (H.ID_JENISHEWAN = J.ID_JENISHEWAN) " +
                "JOIN pegawai C ON (T.ID_PEGAWAI = C.ID_PEGAWAI) " +
                "JOIN pegawai K ON (T.PEG_ID_PEGAWAI = K.ID_PEGAWAI) " +
                "JOIN pelanggan G ON (G.ID_PELANGGAN = H.ID_PELANGGAN) " + 
                "WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

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
                            result.GetString("NAMA_CS"),
                            result.GetString("NAMA_KASIR"),
                            result.GetString("NAMA_HEWAN"),
                            result.GetString("NAMA_PELANGGAN"),
                            result.GetDateTime("TGL_TRANSAKSI"),
                            result.GetInt32("SUBTOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("TOTAL_TRANSAKSI_PRODUK"),
                            result.GetInt32("DISKON_PRODUK"),
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
            return transaksiProduk;
        }

        public void UpdateTotalHargaProduk(int harga, String idTransaksi)
        {
            string sql = "UPDATE transaksi_produk SET TOTAL_TRANSAKSI_PRODUK = '" + harga + "'"
                     + " WHERE ID_TRANSAKSI_PRODUK = '" + idTransaksi + "';";

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
