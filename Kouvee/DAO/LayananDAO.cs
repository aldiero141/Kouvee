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
        public void CreateLayanan()
        {

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
                            result.GetString("Nama_Layanan"));
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
