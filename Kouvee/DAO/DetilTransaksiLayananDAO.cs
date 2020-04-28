﻿using Kouvee.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.DAO
{
    class DetilTransaksiLayananDAO
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
        public List<DetilTransaksiLayanan> ShowDetilTransaksiLayanan()
        {
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN, P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN " +
                "FROM detil_transaksi_layanan P " +
                "JOIN layanan L ON (P.ID_LAYANAN = L.ID_LAYANAN);";

            List<DetilTransaksiLayanan> DetilTransaksiLayananList = new List<DetilTransaksiLayanan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        DetilTransaksiLayanan DTP = new DetilTransaksiLayanan(
                            result.GetInt32("ID_DETILTRANSAKSI_LAYANAN"),
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetInt32("ID_LAYANAN"),
                            result.GetString("NAMA_LAYANAN"),
                            result.GetInt32("SUB_TOTAL_LAYANAN"),
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"));
                        DetilTransaksiLayananList.Add(DTP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return DetilTransaksiLayananList;
        }

        public DetilTransaksiLayanan SearchDetilTransaksiLayanan(String idDetilTransaksi)
        {
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN, P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN " +
                "FROM detil_transaksi_layanan P " +
                "JOIN layanan L ON (P.ID_LAYANAN = L.ID_LAYANAN) " +
                "WHERE P.ID_DETILTRANSAKSI_LAYANAN = '" + idDetilTransaksi + "';";

            DetilTransaksiLayanan detiltransaksiLayanan = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        detiltransaksiLayanan = new DetilTransaksiLayanan(
                            result.GetInt32("ID_DETILTRANSAKSI_LAYANAN"),
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetInt32("ID_LAYANAN"),
                            result.GetString("NAMA_LAYANAN"),
                            result.GetInt32("SUB_TOTAL_LAYANAN"),
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return detiltransaksiLayanan;
        }
    }
}
