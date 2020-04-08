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
    public class LayananDAO
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
        public void CreateLayanan(Layanan L)
        {
            string sql = "INSERT INTO layanan(ID_PEGAWAI, ID_JENISHEWAN, ID_UKURAN, NAMA_LAYANAN, HARGA_LAYANAN) "
                         + "VALUES('"
                         + L.ID_Pegawai
                         + "',(SELECT ID_JENISHEWAN FROM jenis_hewan WHERE JENISHEWAN = '"
                         + L.JenisHewan
                         + "'),(SELECT ID_UKURAN FROM ukuran WHERE UKURAN = '"
                         + L.Ukuran
                         + "'),'"
                         + L.Nama_Layanan
                         + "','"
                         + L.Harga_Layanan
                         + "');";
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

        public List<Layanan> ShowLayanan()
        {
            string sql = "SELECT * FROM layanan";
            List<Layanan> LayananList = new List<Layanan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        Layanan L = new Layanan(
                            result.GetInt32("ID_Layanan"),
                            result.GetInt32("ID_Ukuran"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetInt32("ID_JenisHewan"),
                            result.GetString("Nama_Layanan"),
                            result.GetInt32("Harga_Layanan"),
                            result.GetDateTime("Create_At_Layanan"),
                            result.GetDateTime("Update_At_Layanan"),
                            result.GetDateTime("Delete_At_Layanan"));
                        LayananList.Add(L);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return LayananList;
        }

        public void UpdateLayanan(Layanan L, String namaLayanan)
        {
            string sql = "UPDATE layanan SET Nama_Layanan = '" + L.Nama_Layanan + "',HARGA_LAYANAN ='" + L.Harga_Layanan
                     + "',ID_UKURAN = (SELECT ID_UKURAN FROM ukuran WHERE UKURAN = '" + L.Ukuran
                     + "') ,ID_JENISHEWAN = (SELECT ID_JENISHEWAN FROM jenis_hewan WHERE JENISHEWAN = '" + L.JenisHewan + "')"
                     + " WHERE Nama_Layanan = '" + namaLayanan + "';";

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

        public void DeleteLayanan(String namaLayanan)
        {
            string sql = "UPDATE layanan SET DELETE_AT_LAYANAN = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                     + " WHERE Nama_Layanan = '" + namaLayanan + "';";

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

        public Layanan SearchLayanan(String namaLayanan)
        {
            string sql = "SELECT * FROM layanan WHERE Nama_Layanan = '" + namaLayanan + "';";
            Layanan layanan = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        layanan = new Layanan(
                            result.GetInt32("ID_Layanan"),
                            result.GetInt32("ID_Ukuran"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetInt32("ID_JenisHewan"),
                            result.GetString("Nama_Layanan"),
                            result.GetInt32("Harga_Layanan"),
                            result.GetDateTime("Create_At_Layanan"),
                            result.GetDateTime("Update_At_Layanan"),
                            result.GetDateTime("Delete_At_Layanan"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return layanan;
        }
    }
}
