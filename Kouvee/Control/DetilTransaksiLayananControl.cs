using Kouvee.DAO;
using Kouvee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Control
{
    class DetilTransaksiLayananControl
    {
        private DetilTransaksiLayananDAO dtpDAO = new DetilTransaksiLayananDAO();

        public List<DetilTransaksiLayanan> ShowDetilTransaksiLayanan()
        {
            dtpDAO.makeConnection();
            List<DetilTransaksiLayanan> DetilTransaksiLayananData = dtpDAO.ShowDetilTransaksiLayanan();
            dtpDAO.closeConnection();
            return DetilTransaksiLayananData;
        }

        public DetilTransaksiLayanan SearchDetilTransaksiLayanan(String idTransaksi)
        {
            DetilTransaksiLayanan detiltransaksiProduk = null;
            dtpDAO.makeConnection();
            detiltransaksiProduk = dtpDAO.SearchDetilTransaksiLayanan(idTransaksi);
            dtpDAO.closeConnection();
            return detiltransaksiProduk;
        }
        public void UpdateDetilTransaksiLayanan(DetilTransaksiLayanan detailTransaksiProduk, String idTransaksi)
        {
            dtpDAO.makeConnection();
            dtpDAO.UpdateDetilTransaksiLayanan(detailTransaksiProduk, idTransaksi);
            dtpDAO.closeConnection();
        }
    }
}
