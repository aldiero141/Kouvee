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
    public class UkuranHewanDAO
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
        public void CreateUkuranHewan(UkuranHewan uH)
        {
            string sql = "INSERT INTO ukuran(ID_PEGAWAI, UKURAN) " +
               "VALUES('" + uH.ID_Pegawai + "','" + uH.Ukuran + "');";
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

        public List<UkuranHewan> ShowUkuranHewan()
        {
            string sql = "SELECT * FROM ukuran";
            List<UkuranHewan> UkuranHewanList = new List<UkuranHewan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        UkuranHewan UH = new UkuranHewan(
                            result.GetInt32("ID_Ukuran"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("Ukuran"),
                            result.GetDateTime("Create_At_Ukuran"),
                            result.GetDateTime("Update_At_Ukuran"),
                            result.GetDateTime("Delete_At_Ukuran"));
                        UkuranHewanList.Add(UH);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return UkuranHewanList;
        }

        public void UpdateUkuranHewan()
        {

        }

        public void DeleteUkuranHewan()
        {

        }
    }
}
