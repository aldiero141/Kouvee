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

        public void CreateDetilTransaksiProduk(DetilTransaksiProduk DTP)
        {
            dtpDAO.makeConnection();
            dtpDAO.CreateDetilTransaksiProduk(DTP);
            dtpDAO.closeConnection();
        }

        public List<DetilTransaksiProduk> ShowDetilTransaksiProduk()
        {
            dtpDAO.makeConnection();
            List<DetilTransaksiProduk> DetilTransaksiProdukData = dtpDAO.ShowDetilTransaksiProduk();
            dtpDAO.closeConnection();
            return DetilTransaksiProdukData;
        }

        public DetilTransaksiProduk SearchDetilTransaksiProduk(String idDetilTransaksi)
        {
            DetilTransaksiProduk detiltransaksiProduk = null;
            dtpDAO.makeConnection();
            detiltransaksiProduk = dtpDAO.SearchDetilTransaksiProduk(idDetilTransaksi);
            dtpDAO.closeConnection();
            return detiltransaksiProduk;
        }

        public DetilTransaksiProduk SearchDetilTransaksiProdukUsingID(String idDetilTransaksi, String idTransaksi)
        {
            DetilTransaksiProduk detiltransaksiProduk = null;
            dtpDAO.makeConnection();
            detiltransaksiProduk = dtpDAO.SearchDetilTransaksiProdukUsingID(idDetilTransaksi, idTransaksi);
            dtpDAO.closeConnection();
            return detiltransaksiProduk;
        }

        //public DetilTransaksiProduk SearchDetilTransaksiProdukUsingIDTransaksi(String idTransaksi)
        //{
        //    DetilTransaksiProduk detiltransaksiProduk = null;
        //    dtpDAO.makeConnection();
        //    detiltransaksiProduk = dtpDAO.SearchDetilTransaksiProdukUsingIDTransaksi(idTransaksi);
        //    dtpDAO.closeConnection();
        //    return detiltransaksiProduk;
        //}

        public void UpdateDetilTransaksiProduk(DetilTransaksiProduk detilTransaksiProduk, String idTransaksi)
        {
            dtpDAO.makeConnection();
            dtpDAO.UpdateDetilTransaksiProduk(detilTransaksiProduk, idTransaksi);
            dtpDAO.closeConnection();
        }

        public void DeleteDetilTransaksiProduk(String idDetilTransaksi, String idTransaksi)
        {
            dtpDAO.makeConnection();
            dtpDAO.DeleteDetilTransaksiProduk(idDetilTransaksi,idTransaksi);
            dtpDAO.closeConnection();
        }

        public List<DetilTransaksiProduk> ShowDetilNotaProduk()
        {
            dtpDAO.makeConnection();
            List<DetilTransaksiProduk> NotaDetilTransaksiProdukData = dtpDAO.ShowDetilNotaProduk();
            dtpDAO.closeConnection();
            return NotaDetilTransaksiProdukData;
        }

        public List<DetilTransaksiProduk> SearchDetilTransaksiProdukUsingIDTransaksi(String idTransaksi)
        {
            dtpDAO.makeConnection();
            List<DetilTransaksiProduk> DetilTransaksiProdukData = dtpDAO.SearchDetilTransaksiProdukUsingIDTransaksi(idTransaksi);
            dtpDAO.closeConnection();
            return DetilTransaksiProdukData;
        }
    }
}
