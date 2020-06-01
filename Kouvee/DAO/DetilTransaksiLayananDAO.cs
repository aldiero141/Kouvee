using Kouvee.Models;
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

        public void CreateDetilTransaksiLayanan(DetilTransaksiLayanan DTL)
        {
            string sql = "SET FOREIGN_KEY_CHECKS = 0; " +
                "INSERT INTO detil_transaksi_layanan(ID_TRANSAKSI_LAYANAN, ID_LAYANAN, SUB_TOTAL_LAYANAN, JUMLAH_DETIL_LAYANAN)" +
                "VALUES ('" + DTL.ID_Transaksi_Layanan + "','" + DTL.ID_Layanan + "','"
                + DTL.Sub_Total_Layanan + "','" + DTL.Jumlah_Detil_Layanan + "'); " +
                "SET FOREIGN_KEY_CHECKS = 1;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Created...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create...");
                Console.WriteLine(ex.ToString());
            }
        }

        public List<DetilTransaksiLayanan> ShowDetilTransaksiLayanan()
        {
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN, P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN, L.HARGA_LAYANAN " +
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
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"),
                            result.GetInt32("HARGA_LAYANAN"));
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
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN , P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN, L.HARGA_LAYANAN " +
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
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"),
                            result.GetInt32("HARGA_LAYANAN"));
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

        public DetilTransaksiLayanan SearchDetilTransaksiLayananUsingID(String idDetilTransaksi, String idTransaksi)
        {
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN , P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN, L.HARGA_LAYANAN " +
                "FROM detil_transaksi_layanan P " +
                "JOIN layanan L ON (P.ID_LAYANAN = L.ID_LAYANAN) " +
                "WHERE P.ID_DETILTRANSAKSI_LAYANAN = '" + idDetilTransaksi + "' AND P.ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

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
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"),
                            result.GetInt32("HARGA_LAYANAN"));
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

        public List<DetilTransaksiLayanan> SearchDetilTransaksiLayananUsingIDLayanan(String idTransaksi)
        {
            string sql = "SELECT P.ID_DETILTRANSAKSI_LAYANAN , P.ID_TRANSAKSI_LAYANAN, P.ID_LAYANAN, L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN, L.HARGA_LAYANAN " +
                "FROM detil_transaksi_layanan P " +
                "JOIN layanan L ON (P.ID_LAYANAN = L.ID_LAYANAN) " +
                "WHERE P.ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "';";

            List<DetilTransaksiLayanan> DetilTransaksiLayananList = new List<DetilTransaksiLayanan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    { 
                        DetilTransaksiLayanan DTL = new DetilTransaksiLayanan(
                            result.GetInt32("ID_DETILTRANSAKSI_LAYANAN"),
                            result.GetString("ID_TRANSAKSI_LAYANAN"),
                            result.GetInt32("ID_LAYANAN"),
                            result.GetString("NAMA_LAYANAN"),
                            result.GetInt32("SUB_TOTAL_LAYANAN"),
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"),
                            result.GetInt32("HARGA_LAYANAN"));
                        DetilTransaksiLayananList.Add(DTL);
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

        public void UpdateDetilTransaksiLayanan(DetilTransaksiLayanan DTL, String idTransaksi)
        {
            string sql = "UPDATE detil_transaksi_layanan SET ID_LAYANAN = (SELECT ID_LAYANAN FROM layanan WHERE NAMA_LAYANAN = '" + DTL.Nama_Layanan + "')"
                     + ", JUMLAH_DETIL_LAYANAN = '" + DTL.Jumlah_Detil_Layanan + "' ,SUB_TOTAL_LAYANAN = '" + DTL.Sub_Total_Layanan + "'"
                     + " WHERE ID_DETILTRANSAKSI_LAYANAN = '" + idTransaksi + "';";

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

        public void DeleteDetilTransaksiLayanan(String idTransaksi, String idDetilTransaksi)
        {
            string sql = "SET FOREIGN_KEY_CHECKS = 0; " +
                "DELETE FROM detil_transaksi_layanan WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "' AND ID_DETILTRANSAKSI_LAYANAN = '"+ idDetilTransaksi + "'; " +
                "SET FOREIGN_KEY_CHECKS = 1;";

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

        public void DeleteDetilTransaksiLayananUsingIDTransaksi(String idTransaksi)
        {
            string sql = "SET FOREIGN_KEY_CHECKS = 0; " +
                "DELETE FROM detil_transaksi_layanan WHERE ID_TRANSAKSI_LAYANAN = '" + idTransaksi + "'; " +
                "SET FOREIGN_KEY_CHECKS = 1;";

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

        public List<DetilTransaksiLayanan> ShowDetilNotaLayanan()
        {
            string sql = "SELECT L.NAMA_LAYANAN, P.SUB_TOTAL_LAYANAN, P.JUMLAH_DETIL_LAYANAN, L.HARGA_LAYANAN " +
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
                            result.GetString("NAMA_LAYANAN"),
                            result.GetInt32("SUB_TOTAL_LAYANAN"),
                            result.GetInt32("JUMLAH_DETIL_LAYANAN"),
                            result.GetInt32("HARGA_LAYANAN"));
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
    }
}
