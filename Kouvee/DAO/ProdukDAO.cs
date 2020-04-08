using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Numerics;
using System.Windows.Documents;

namespace Kouvee.DAO
{
    class ProdukDAO
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
        public void CreateProduk(Produk P)
        {
            string sql = "";

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

        public List<Produk> ShowProduk()
        {
            string sql = "SELECT * FROM produk";
            List<Produk> ProdukList = new List<Produk>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        Produk Pr = new Produk(
                            result.GetInt32("ID_Produk"),
                            result.GetString("Nama_Produk"),
                            result.GetInt32("Stock"),
                            result.GetInt32("Min_Stock"),
                            result.GetString("Satuan_Produk"),
                            result.GetInt32("Harga_Beli"),
                            result.GetInt32("Harga_Jual"),
                            result.GetString("Gambar"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetDateTime("Create_At_Produk"),
                            result.GetDateTime("Update_At_Produk"),
                            result.GetDateTime("Delete_At_Produk"));
                        ProdukList.Add(Pr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return ProdukList;
        }

        public void UpdateProduk(Produk P, String namaProduk)
        {
            string sql = "";

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

        public void DeleteProduk(String namaProduk)
        {
            string sql = "UPDATE produk SET DELETE_AT_PRODUK = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                     + " WHERE NAMA_PRODUK = '" + namaProduk + "';";

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
    }
}
