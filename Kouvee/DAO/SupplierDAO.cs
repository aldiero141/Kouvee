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
    public class SupplierDAO
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
        public void CreateSupplier(Supplier S)
        {
            string sql = "INSERT INTO supplier(ID_PEGAWAI, NAMA_SUPPLIER, ALAMAT_SUPPLIER, PHONE_SUPPLIER) " +
               "VALUES('" + S.ID_Pegawai + "','" + S.Nama_Supplier + "','" + S.Alamat_Supplier + "','" + S.Phone_Supplier + "');";
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

        public List<Supplier> ShowSupplier()
        {
            string sql = "SELECT * FROM supplier";
            List<Supplier> SupplierList = new List<Supplier>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result != null)
                {
                    while (result.Read())
                    {
                        Supplier S = new Supplier(
                            result.GetInt32("ID_Supplier"),
                            result.GetString("Nama_Supplier"),
                            result.GetString("Alamat_Supplier"),
                            result.GetString("Phone_Supplier"),
                            result.GetInt32("ID_Pegawai"),
                            result.GetDateTime("Create_At_Supplier"),
                            result.GetDateTime("Update_At_Supplier"),
                            result.GetDateTime("Delete_At_Supplier"));
                        SupplierList.Add(S);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read...");
                Console.WriteLine(ex.ToString());
            }
            return SupplierList;
        }

        public void UpdateSupplier()
        {

        }

        public void DeleteSupplier()
        {

        }
    }
}
