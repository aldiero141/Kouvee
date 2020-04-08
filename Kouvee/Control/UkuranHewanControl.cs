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

        public void UpdateUkuranHewan(UkuranHewan ukuranHewan, String ukuran)
        {
            ukDAO.makeConnection();
            ukDAO.UpdateUkuranHewan(ukuranHewan,ukuran);
            ukDAO.closeConnection();
        }

        public void DeleteUkuranHewan(String ukuran)
        {
            ukDAO.makeConnection();
            ukDAO.DeleteUkuranHewan(ukuran);
            ukDAO.closeConnection();
        }

        public List<UkuranHewan> ShowUkuranHewan()
        {
            ukDAO.makeConnection();
            List<UkuranHewan> UkuranHewanData = ukDAO.ShowUkuranHewan();
            ukDAO.closeConnection();
            return UkuranHewanData;
        }

        public UkuranHewan SearchUkuran(String nama)
        {
            UkuranHewan ukuranHewan = null;
            ukDAO.makeConnection();
            ukuranHewan = ukDAO.SearchUkuran(nama);
            ukDAO.closeConnection();
            return ukuranHewan;
        }
    }
    
}
