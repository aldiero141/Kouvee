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

        public void UpdateLayanan()
        {

        }

        public void DeleteLayanan()
        {

        }
    }
}
