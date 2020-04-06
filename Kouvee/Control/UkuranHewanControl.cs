using System;
using System.Collections;
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
    public class UkuranHewanControl
    {
        private UkuranHewanDAO ukDAO = new UkuranHewanDAO();

        public void CreateUkuranHewan(UkuranHewan ukuranHewan)
        {
            ukDAO.makeConnection();
            ukDAO.CreateUkuranHewan(ukuranHewan);
            ukDAO.closeConnection();
        }

        public void UpdateUkuranHewan(UkuranHewan ukuranHewan)
        {
            ukDAO.makeConnection();
            ukDAO.UpdateUkuranHewan();
            ukDAO.closeConnection();
        }

        public void DeleteUkuranHewan(string ukuran)
        {
            ukDAO.makeConnection();
            ukDAO.DeleteUkuranHewan();
            ukDAO.closeConnection();
        }

        public List<UkuranHewan> ShowUkuranHewan()
        {
            ukDAO.makeConnection();
            List<UkuranHewan> UkuranHewanData = ukDAO.ShowUkuranHewan();
            ukDAO.closeConnection();
            return UkuranHewanData;
        }
    }
    
}
