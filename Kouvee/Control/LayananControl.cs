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
    class LayananControl
    {
        private LayananDAO lDAO = new LayananDAO();

        public void CreateLayanan(Layanan layanan)
        {
            lDAO.makeConnection();
            lDAO.CreateLayanan();
            lDAO.closeConnection();
        }

        public void UpdateLayanan(Layanan layanan)
        {
            lDAO.makeConnection();
            lDAO.UpdateLayanan();
            lDAO.closeConnection();
        }

        public void DeleteLayanan(string Nama_Layanan)
        {
            lDAO.makeConnection();
            lDAO.DeleteLayanan();
            lDAO.closeConnection();
        }

        public List<Layanan> ShowLayanan()
        {
            lDAO.makeConnection();
            List<Layanan> LayananData = lDAO.ShowLayanan();
            lDAO.closeConnection();
            return LayananData;
        }
    }
}
