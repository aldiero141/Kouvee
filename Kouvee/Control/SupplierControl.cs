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
    class SupplierControl
    {
        private SupplierDAO sDAO = new SupplierDAO();

        public void CreateSupplier(Supplier supplier)
        {
            sDAO.makeConnection();
            sDAO.CreateSupplier(supplier);
            sDAO.closeConnection();
        }

        public void UpdateSupplier(Supplier supplier, String namaSupplier)
        {
            sDAO.makeConnection();
            sDAO.UpdateSupplier(supplier,namaSupplier);
            sDAO.closeConnection();
        }

        public void DeleteSupplier(String namaSupplier)
        {
            sDAO.makeConnection();
            sDAO.DeleteSupplier(namaSupplier);
            sDAO.closeConnection();
        }

        public List<Supplier> ShowSupplier()
        {
            sDAO.makeConnection();
            List<Supplier> SupplierData = sDAO.ShowSupplier();
            sDAO.closeConnection();
            return SupplierData;
        }

        public Supplier SearchSupplier(String nama)
        {
            Supplier supplier = null;
            sDAO.makeConnection();
            supplier = sDAO.SearchSupplier(nama);
            sDAO.closeConnection();
            return supplier;
        }
    }
}
