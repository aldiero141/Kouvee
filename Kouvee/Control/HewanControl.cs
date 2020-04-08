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
    class HewanControl
    {
        private HewanDAO hDAO = new HewanDAO();

        public void CreateHewan(Hewan hewan)
        {
            hDAO.makeConnection();
            hDAO.CreateHewan(hewan);
            hDAO.closeConnection();
        }

        public void UpdateHewan(Hewan hewan, String namaHewan)
        {
            hDAO.makeConnection();
            hDAO.UpdateHewan(hewan,namaHewan);
            hDAO.closeConnection();
        }

        public void DeleteHewan(string Nama_Hewan)
        {
            hDAO.makeConnection();
            hDAO.DeleteHewan(Nama_Hewan);
            hDAO.closeConnection();
        }

        public List<Hewan> ShowHewan()
        {
            hDAO.makeConnection();
            List<Hewan> HewanData = hDAO.ShowHewan();
            hDAO.closeConnection();
            return HewanData;
        }

        public Hewan SearchHewan(String nama)
        {
            Hewan hewan = null;
            hDAO.makeConnection();
            hewan = hDAO.SearchHewan(nama);
            hDAO.closeConnection();
            return hewan;
        }
    }
}
