using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.Models;
using Kouvee.DAO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Numerics;
using System.Windows.Documents;

namespace Kouvee.Control
{
    class AkunControl
    {
        private AkunDAO aDAO = new AkunDAO();
        public Akun SearchAkun(String namaPegawai, String password)
        {
            Akun akun = null;
            aDAO.makeConnection();
            akun = aDAO.SearchAkun(namaPegawai,password);
            aDAO.closeConnection();
            return akun;
        }
    }
}
