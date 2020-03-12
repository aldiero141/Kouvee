using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kouvee
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connstring = @"server=103.147.154.24;userid=kouveexy;password=wK-4Ya23U1-cVr;database=kouveexy_kouvee";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM table_name;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table_name");
                DataTable dt = ds.Tables["table_name"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }

                    Console.Write("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
