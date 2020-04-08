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
    class ProdukControl
    {
        private ProdukDAO prDAO = new ProdukDAO();

        public void CreateProduk(Produk produk)
        {
            prDAO.makeConnection();
            prDAO.CreateProduk(produk);
            prDAO.closeConnection();
        }

        public void UpdateProduk(Produk produk, String Nama_Produk)
        {
            prDAO.makeConnection();
            prDAO.UpdateProduk(produk, Nama_Produk);
            prDAO.closeConnection();
        }

        public void DeleteProduk(String Nama_Produk)
        {
            prDAO.makeConnection();
            prDAO.DeleteProduk(Nama_Produk);
            prDAO.closeConnection();
        }

        public List<Produk> ShowProduk()
        {
            prDAO.makeConnection();
            List<Produk> ProdukData = prDAO.ShowProduk();
            prDAO.closeConnection();
            return ProdukData;
        }
    }
}
