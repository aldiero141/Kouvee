using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.DAO;
using Kouvee.Models;

namespace Kouvee.Control
{
    class TransaksiProdukControl
    {
        private TransaksiProdukDAO tpDAO = new TransaksiProdukDAO();

        public List<TransaksiProduk> ShowTransaksiProduk()
        {
            tpDAO.makeConnection();
            List<TransaksiProduk> TransaksiProdukData = tpDAO.ShowTransaksiProduk();
            tpDAO.closeConnection();
            return TransaksiProdukData;
        }

        public TransaksiProduk SearchTransaksiProduk(String idTransaksi)
        {
            TransaksiProduk transaksiProduk = null;
            tpDAO.makeConnection();
            transaksiProduk = tpDAO.SearchTransaksiProduk(idTransaksi);
            tpDAO.closeConnection();
            return transaksiProduk;
        }

        public void UpdateTransaksiProduk(TransaksiProduk transaksiProduk, String idTransaksi)
        {
            tpDAO.makeConnection();
            tpDAO.UpdateTransaksiProduk(transaksiProduk, idTransaksi);
            tpDAO.closeConnection();
        }

        public void UpdateSubtotalProduk(TransaksiProduk transaksiProduk, String idTransaksi)
        {
            tpDAO.makeConnection();
            tpDAO.UpdateSubtotalProduk(transaksiProduk, idTransaksi);
            tpDAO.closeConnection();
        }
    }
}
