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
    public class PegawaiDAO
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

        public void CreatePegawai(Pegawai P)
        {
            string sql = "INSERT INTO pegawai(NAMA_PEGAWAI, TGL_LAHIR_PEGAWAI, PHONE_PEGAWAI, ALAMAT_PEGAWAI, JABATAN, PASSWORD) " +
               "VALUES('" + P.Nama_Pegawai + "','" + P.Tgl_Lahir_Pegawai + "','" + P.Phone_Pegawai + "','" + P.Alamat_Pegawai + "','" + P.Jabatan + "','" + P.Password + "');";
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

        public List<Pegawai> ShowPegawai()
        {
            string sql = "SELECT * FROM pegawai";
            List<Pegawai> PegawaiList = new List<Pegawai>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        Pegawai P = new Pegawai(
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("Nama_Pegawai"),
                            result.GetString("Alamat_Pegawai"),
                            result.GetString("Tgl_Lahir_Pegawai"),
                            result.GetString("Phone_Pegawai"),
                            result.GetString("Jabatan"),
                            result.GetString("Password"),
                            result.GetDateTime("Create_At_Pegawai"),
                            result.GetDateTime("Update_At_Pegawai"),
                            result.GetDateTime("Delete_At_Pegawai"));
                        PegawaiList.Add(P);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return PegawaiList;
        }

        public void UpdatePegawai(Pegawai P, String namaPegawai)
        {
            string sql = "UPDATE pegawai SET NAMA_PEGAWAI = '" + P.Nama_Pegawai + "',TGL_LAHIR_PEGAWAI ='" + P.Tgl_Lahir_Pegawai + "',PHONE_PEGAWAI ='"
                     + P.Phone_Pegawai + "',ALAMAT_PEGAWAI ='" + P.Alamat_Pegawai + "',JABATAN ='" + P.Jabatan + "',PASSWORD ='" + P.Password + "'"
                     + " WHERE NAMA_PEGAWAI = '" + namaPegawai + "';";

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

        public void DeletePegawai(String namaPegawai)
        {
            string sql = "UPDATE pegawai SET DELETE_AT_PEGAWAI = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                     + " WHERE NAMA_PEGAWAI = '" + namaPegawai + "';";

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

        public Pegawai SearchPegawai(String namaPegawai)
        {
            string sql = "SELECT * FROM pegawai WHERE NAMA_PEGAWAI = '" + namaPegawai + "';";
            Pegawai pegawai = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        pegawai = new Pegawai(
                            result.GetInt32("ID_Pegawai"),
                            result.GetString("Nama_Pegawai"),
                            result.GetString("Alamat_Pegawai"),
                            result.GetString("Tgl_Lahir_Pegawai"),
                            result.GetString("Phone_Pegawai"),
                            result.GetString("Jabatan"),
                            result.GetString("Password"),
                            result.GetDateTime("Create_At_Pegawai"),
                            result.GetDateTime("Update_At_Pegawai"),
                            result.GetDateTime("Delete_At_Pegawai"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to search...");
                Console.WriteLine(ex.ToString());
            }
            return pegawai;
        }
    }
}
