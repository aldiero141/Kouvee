﻿using Kouvee.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.DAO
{
    class DetilTransaksiProdukDAO
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

        public List<DetilTransaksiProduk> ShowDetilTransaksiProduk()
        {
            string sql = "SELECT D.ID_DETIL_TRANSAKSI, D.ID_TRANSAKSI_PRODUK, D.ID_PRODUK, P.NAMA_PRODUK , D.SUB_TOTAL_PRODUK, D.JUMLAH_PRODUK " +
                "FROM detil_transaksi_produk D " +
                "JOIN produk P ON (D.ID_PRODUK = P.ID_PRODUK)";

            List<DetilTransaksiProduk> DetilTransaksiProdukList = new List<DetilTransaksiProduk>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        DetilTransaksiProduk DTP = new DetilTransaksiProduk(
                            result.GetInt32("ID_DETIL_TRANSAKSI"),
                            result.GetString("ID_TRANSAKSI_PRODUK"),
                            result.GetInt32("ID_PRODUK"),
                            result.GetString("NAMA_PRODUK"),
                            result.GetInt32("SUB_TOTAL_PRODUK"),
                            result.GetInt32("JUMLAH_PRODUK"));
                        DetilTransaksiProdukList.Add(DTP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return DetilTransaksiProdukList;
        }
        public DetilTransaksiProduk SearchDetilTransaksiProduk(String idDetilTransaksi)
        {
            string sql = "SELECT D.ID_DETIL_TRANSAKSI, D.ID_TRANSAKSI_PRODUK, D.ID_PRODUK, P.NAMA_PRODUK , D.SUB_TOTAL_PRODUK, D.JUMLAH_PRODUK " +
                "FROM detil_transaksi_produk D " +
                "JOIN produk P ON (D.ID_PRODUK = P.ID_PRODUK)" +
                "WHERE D.ID_DETIL_TRANSAKSI = '" + idDetilTransaksi + "';";

            DetilTransaksiProduk detiltransaksiProduk = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        detiltransaksiProduk = new DetilTransaksiProduk(
                            result.GetInt32("ID_DETIL_TRANSAKSI"),
                            result.GetString("ID_TRANSAKSI_PRODUK"),
                            result.GetInt32("ID_PRODUK"),
                            result.GetString("NAMA_PRODUK"),
                            result.GetInt32("SUB_TOTAL_PRODUK"),
                            result.GetInt32("JUMLAH_PRODUK"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return detiltransaksiProduk;
        }
    }
}
