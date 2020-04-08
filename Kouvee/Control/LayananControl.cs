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
            lDAO.CreateLayanan(layanan);
            lDAO.closeConnection();
        }

        public void UpdateLayanan(Layanan layanan, String namaLayanan)
        {
            lDAO.makeConnection();
            lDAO.UpdateLayanan(layanan,namaLayanan);
            lDAO.closeConnection();
        }

        public void DeleteLayanan(String namaLayanan)
        {
            lDAO.makeConnection();
            lDAO.DeleteLayanan(namaLayanan);
            lDAO.closeConnection();
        }

        public List<Layanan> ShowLayanan()
        {
            lDAO.makeConnection();
            List<Layanan> LayananData = lDAO.ShowLayanan();
            lDAO.closeConnection();
            return LayananData;
        }
        public Layanan SearchLayanan(String nama)
        {
            Layanan layanan = null;
            lDAO.makeConnection();
            layanan = lDAO.SearchLayanan(nama);
            lDAO.closeConnection();
            return layanan;
        }
    }
}
