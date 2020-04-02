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
    public class CustomerControl
    {
        private CustomerDAO cDAO = new CustomerDAO();

        public void CreateCustomer(Customer customer)
        {
            cDAO.makeConnection();
            cDAO.CreateCustomer();
            cDAO.closeConnection();
        }

        public void UpdateCustomer(Customer customer)
        {
            cDAO.makeConnection();
            cDAO.UpdateCustomer();
            cDAO.closeConnection();
        }

        public void DeleteCustomer(string Nama_Pelanggan)
        {
            cDAO.makeConnection();
            cDAO.DeleteCustomer();
            cDAO.closeConnection();
        }

        public List<Customer> ShowCustomer() 
        {
            cDAO.makeConnection();
            List<Customer> CustomerData = cDAO.ShowCustomer();
            cDAO.closeConnection();
            return CustomerData;
        }
    }
}
