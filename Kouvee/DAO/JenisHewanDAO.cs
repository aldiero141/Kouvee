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
    public class JenisHewanDAO
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
        public void CreateJenisHewan(JenisHewan jH)
        {
            string sql = "INSERT INTO jenis_hewan(ID_PEGAWAI,JENISHEWAN) " +
                "VALUES('" + jH.ID_Pegawai + "','" + jH.Jenis_Hewan +"');";
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

        public List<JenisHewan> ShowJenisHewan()
        {
            string sql = "SELECT * FROM jenis_hewan";
            List<JenisHewan> JenisHewanList = new List<JenisHewan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        JenisHewan JH = new JenisHewan(
                            result.GetInt32("ID_JenisHewan"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("JenisHewan"),
                            result.GetDateTime("Create_At_Jhewan"),
                            result.GetDateTime("Update_At_Jhewan"),
                            result.GetDateTime("Delete_At_Jhewan"));
                        JenisHewanList.Add(JH);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return JenisHewanList;
        }

        public void UpdateJenisHewan(JenisHewan jH, String namaJenis)
        {
            string sql = "UPDATE jenis_hewan SET JENISHEWAN = '" + jH.Jenis_Hewan + "'"
                     + " WHERE JENISHEWAN = '" + namaJenis + "';";

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

        public void DeleteJenisHewan(String namaJenis)
        {
            string sql = "UPDATE jenis_hewan SET DELETE_AT_JHEWAN = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                     + " WHERE JENISHEWAN = '" + namaJenis + "';";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteReader();
                Console.WriteLine("Data Delete...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete...");
                Console.WriteLine(ex.ToString());
            }
        }

        public JenisHewan SearchJenisHewan(String namaJenis)
        {
            string sql = "SELECT * FROM jenis_hewan WHERE JENISHEWAN = '" + namaJenis + "';";
            JenisHewan jenisHewan = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        jenisHewan = new JenisHewan(
                            result.GetInt32("ID_JenisHewan"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("JenisHewan"),
                            result.GetDateTime("Create_At_Jhewan"),
                            result.GetDateTime("Update_At_Jhewan"),
                            result.GetDateTime("Delete_At_Jhewan"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return jenisHewan;
        }
    }
}
