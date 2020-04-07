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
        private HewanDAO cDAO = new HewanDAO();

        public void CreateHewan(Hewan hewan)
        {
            cDAO.makeConnection();
            cDAO.CreateHewan(hewan);
            cDAO.closeConnection();
        }

        public void UpdateHewan(Hewan hewan)
        {
            cDAO.makeConnection();
            cDAO.UpdateHewan();
            cDAO.closeConnection();
        }

        public void DeleteHewan(string Nama_Hewan)
        {
            cDAO.makeConnection();
            cDAO.DeleteHewan();
            cDAO.closeConnection();
        }

        public List<Hewan> ShowHewan()
        {
            cDAO.makeConnection();
            List<Hewan> HewanData = cDAO.ShowHewan();
            cDAO.closeConnection();
            return HewanData;
        }
    }
}
