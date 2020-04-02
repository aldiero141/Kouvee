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
            jhDAO.CreateJenisHewan();
            jhDAO.closeConnection();
        }

        public void UpdateJenisHewan(JenisHewan jenisHewan)
        {
            jhDAO.makeConnection();
            jhDAO.UpdateJenisHewan();
            jhDAO.closeConnection();
        }

        public void DeleteJenisHewan(string Jenis_Hewan)
        {
            jhDAO.makeConnection();
            jhDAO.DeleteJenisHewan();
            jhDAO.closeConnection();
        }

        public List<JenisHewan> ShowJenisHewan()
        {
            jhDAO.makeConnection();
            List<JenisHewan> JenisHewanData = jhDAO.ShowJenisHewan();
            jhDAO.closeConnection();
            return JenisHewanData;
        }
    }
}
