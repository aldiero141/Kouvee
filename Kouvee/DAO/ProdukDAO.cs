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
using System.IO;
using System.Drawing;

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
            string sql = "INSERT INTO produk(ID_PEGAWAI, NAMA_PRODUK, STOCK, MIN_STOCK, SATUAN_PRODUK, HARGA_BELI, HARGA_JUAL, GAMBAR_BLOB) " +
              "VALUES('" + P.ID_Pegawai + "','" + P.Nama_Produk + "','" + P.Stock + "','" + P.Min_Stock + "','"
              + P.Satuan_Produk + "','" + P.Harga_BeliProduk + "','" + P.Harga_JualProduk + "','" + P.Gambar_Blob + "');";

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
                        Produk P = new Produk(
                            result.GetInt32("ID_Produk"),
                            result.GetString("Nama_Produk"),
                            result.GetInt32("Stock"),
                            result.GetInt32("Min_Stock"),
                            result.GetString("Satuan_Produk"),
                            result.GetInt32("Harga_Beli"),
                            result.GetInt32("Harga_Jual"),
                            (byte[])result["Gambar_Blob"],
                            result.GetInt32("ID_Pegawai"),
                            result.GetDateTime("Create_At_Produk"),
                            result.GetDateTime("Update_At_Produk"),
                            result.GetDateTime("Delete_At_Produk"));
                        ProdukList.Add(P);
                        Console.WriteLine((byte[])result["Gambar_Blob"]);

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

        public DataTable ShowProduk2()
        {
            string sql = "SELECT * FROM produk";
            DataTable table = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(table);
                da.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return table;
        }

        public void UpdateProduk(Produk P, String namaProduk)
        {
            string sql = "UPDATE produk SET NAMA_PRODUK = '" + P.Nama_Produk +"',ID_PEGAWAI ='" + P.ID_Pegawai
                + "',STOCK ='" + P.Stock +"',MIN_STOCK ='" + P.Min_Stock
                + "',SATUAN_PRODUK ='" + P.Satuan_Produk +"',HARGA_BELI ='" + P.Harga_BeliProduk
                + "',HARGA_JUAL ='" + P.Harga_JualProduk +"',GAMBAR_BLOB ='" + P.Gambar_Blob + "'"
                + " WHERE NAMA_PRODUK = '" + namaProduk + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Update...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update...");
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

        public Produk SearchProduk(String namaProduk)
        {
            string sql = "SELECT * FROM produk WHERE NAMA_PRODUK = '" + namaProduk + "';";
            Produk produk = null;
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
                            (byte[])result["Gambar_Blob"],
                            result.GetInt32("ID_Pegawai"),
                            result.GetDateTime("Create_At_Produk"),
                            result.GetDateTime("Update_At_Produk"),
                            result.GetDateTime("Delete_At_Produk"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return produk;
        }
    }
}
