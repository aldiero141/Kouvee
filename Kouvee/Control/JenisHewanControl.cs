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
    class JenisHewanControl
    {
        private JenisHewanDAO jhDAO = new JenisHewanDAO();

        public void CreateJenisHewan(JenisHewan jenisHewan)
        {
            jhDAO.makeConnection();
            jhDAO.CreateJenisHewan(jenisHewan);
            jhDAO.closeConnection();
        }

        public void UpdateJenisHewan(JenisHewan jenisHewan, String namaJenis)
        {
            jhDAO.makeConnection();
            jhDAO.UpdateJenisHewan(jenisHewan,namaJenis);
            jhDAO.closeConnection();
        }

        public void DeleteJenisHewan(String namaJenis)
        {
            jhDAO.makeConnection();
            jhDAO.DeleteJenisHewan(namaJenis);
            jhDAO.closeConnection();
        }

        public List<JenisHewan> ShowJenisHewan()
        {
            jhDAO.makeConnection();
            List<JenisHewan> JenisHewanData = jhDAO.ShowJenisHewan();
            jhDAO.closeConnection();
            return JenisHewanData;
        }

        public JenisHewan SearchJenisHewan(String nama)
        {
            JenisHewan jenisHewan = null;
            jhDAO.makeConnection();
            jenisHewan = jhDAO.SearchJenisHewan(nama);
            jhDAO.closeConnection();
            return jenisHewan;
        }

    }
}
