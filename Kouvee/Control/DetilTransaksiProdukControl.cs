using Kouvee.DAO;
using Kouvee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Control
{
    class DetilTransaksiProdukControl
    {
        private DetilTransaksiProdukDAO dtpDAO = new DetilTransaksiProdukDAO();

        public List<DetilTransaksiProduk> ShowDetilTransaksiProduk()
        {
            dtpDAO.makeConnection();
            List<DetilTransaksiProduk> DetilTransaksiProdukData = dtpDAO.ShowDetilTransaksiProduk();
            dtpDAO.closeConnection();
            return DetilTransaksiProdukData;
        }

        public DetilTransaksiProduk SearchDetilTransaksiProduk(String idTransaksi)
        {
            DetilTransaksiProduk detiltransaksiProduk = null;
            dtpDAO.makeConnection();
            detiltransaksiProduk = dtpDAO.SearchDetilTransaksiProduk(idTransaksi);
            dtpDAO.closeConnection();
            return detiltransaksiProduk;
        }

        public void UpdateDetilTransaksiProduk(DetilTransaksiProduk detilTransaksiProduk, String idTransaksi)
        {
            dtpDAO.makeConnection();
            dtpDAO.UpdateDetilTransaksiProduk(detilTransaksiProduk, idTransaksi);
            dtpDAO.closeConnection();
        }

        public void DeleteDetilTransaksiProduk(String idTransaksi)
        {
            dtpDAO.makeConnection();
            dtpDAO.DeleteDetilTransaksiProduk(idTransaksi);
            dtpDAO.closeConnection();
        }
    }
}
