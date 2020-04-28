using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.DAO;
using Kouvee.Models;

namespace Kouvee.Control
{
    class TransaksiLayananControl
    {
        private TransaksiLayananDAO tlDAO = new TransaksiLayananDAO();

        public List<TransaksiLayanan> ShowTransaksiLayanan()
        {
            tlDAO.makeConnection();
            List<TransaksiLayanan> TransaksiLayananData = tlDAO.ShowTransaksiLayanan();
            tlDAO.closeConnection();
            return TransaksiLayananData;
        }

        public TransaksiLayanan SearchTransaksiLayanan(String idTransaksi)
        {
            TransaksiLayanan transaksiProduk = null;
            tlDAO.makeConnection();
            transaksiProduk = tlDAO.SearchTransaksiLayanan(idTransaksi);
            tlDAO.closeConnection();
            return transaksiProduk;
        }
    }
}
