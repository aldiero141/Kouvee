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
        public static string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;";
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
        public void CreateJenisHewan()
        {

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
                            result.GetString("JenisHewan"));
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

        public void UpdateJenisHewan()
        {

        }

        public void DeleteJenisHewan()
        {

        }
    }
}
