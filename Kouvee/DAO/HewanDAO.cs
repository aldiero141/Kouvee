﻿using System;
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
    public class HewanDAO
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

        public void CreateHewan(Hewan H)
        {
            string sql = "INSERT INTO hewan(ID_PEGAWAI, ID_PELANGGAN, ID_JenisHewan, NAMA_HEWAN, TGL_LAHIR_HEWAN) "
                         + "VALUES('"
                         + H.ID_Pegawai
                         + "',(SELECT ID_PELANGGAN FROM pelanggan WHERE NAMA_PELANGGAN = '"
                         + H.Nama_Pelanggan
                         + "'),(SELECT ID_JENISHEWAN FROM jenis_hewan WHERE JENISHEWAN = '"
                         + H.JenisHewan
                         + "'),'"
                         + H.Nama_Hewan
                         + "','"
                         + H.Tgl_Lahir_Hewan
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

        public List<Hewan> ShowHewan()
        {
            string sql = "SELECT * FROM hewan";
            List<Hewan> HewanList = new List<Hewan>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        Hewan H = new Hewan(
                            result.GetInt32("ID_Hewan"),
                            result.GetInt32("ID_JenisHewan"),
                            //result.GetInt32("ID_Ukuran"),
                            result.GetInt32("ID_Pelanggan"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("Nama_Hewan"),
                            result.GetString("Tgl_Lahir_Hewan"),
                            result.GetDateTime("Create_At_Hewan"),
                            result.GetDateTime("Update_At_Hewan"),
                            result.GetDateTime("Delete_At_Hewan"));
                        HewanList.Add(H);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return HewanList;
        }

        public void UpdateHewan()
        {

        }

        public void DeleteHewan()
        {

        }
    }
}
