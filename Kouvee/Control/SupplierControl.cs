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

        public void CreateSupplier(Supplier customer)
        {
            sDAO.makeConnection();
            sDAO.CreateSupplier();
            sDAO.closeConnection();
        }

        public void UpdateSupplier(Supplier customer)
        {
            sDAO.makeConnection();
            sDAO.UpdateSupplier();
            sDAO.closeConnection();
        }

        public void DeleteSupplier(string Nama_Supplier)
        {
            sDAO.makeConnection();
            sDAO.DeleteSupplier();
            sDAO.closeConnection();
        }

        public List<Supplier> ShowSupplier()
        {
            sDAO.makeConnection();
            List<Supplier> SupplierData = sDAO.ShowSupplier();
            sDAO.closeConnection();
            return SupplierData;
        }
    }
}
