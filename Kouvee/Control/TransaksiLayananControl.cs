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

        public void UpdateTransaksiLayanan(TransaksiLayanan transaksiLayanan, String idTransaksi)
        {
            tlDAO.makeConnection();
            tlDAO.UpdateTransaksiLayanan(transaksiLayanan, idTransaksi);
            tlDAO.closeConnection();
        }

        public void UpdateSubtotalLayanan(TransaksiLayanan transaksiLayanan, String idTransaksi)
        {
            tlDAO.makeConnection();
            tlDAO.UpdateSubtotalLayanan(transaksiLayanan, idTransaksi);
            tlDAO.closeConnection();
        }

        public void UpdatePembayaranLayanan(TransaksiLayanan transaksiLayanan, String idTransaksi)
        {
            tlDAO.makeConnection();
            tlDAO.UpdatePembayaranLayanan(transaksiLayanan, idTransaksi);
            tlDAO.closeConnection();
        }

        public void DeleteTransaksiLayanan(String idTransaksi)
        {
            tlDAO.makeConnection();
            tlDAO.DeleteTransaksiLayanan(idTransaksi);
            tlDAO.closeConnection();
        }

        public TransaksiLayanan ShowNotaLayanan(String idTransaksi)
        {
            TransaksiLayanan transaksiProduk = null;
            tlDAO.makeConnection();
            transaksiProduk = tlDAO.ShowNotaLayanan(idTransaksi);
            tlDAO.closeConnection();
            return transaksiProduk;
        }
    }
}
