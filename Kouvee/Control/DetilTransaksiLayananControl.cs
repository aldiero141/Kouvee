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
        private DetilTransaksiLayananDAO dtlDAO = new DetilTransaksiLayananDAO();

        public List<DetilTransaksiLayanan> ShowDetilTransaksiLayanan()
        {
            dtlDAO.makeConnection();
            List<DetilTransaksiLayanan> DetilTransaksiLayananData = dtlDAO.ShowDetilTransaksiLayanan();
            dtlDAO.closeConnection();
            return DetilTransaksiLayananData;
        }

        public DetilTransaksiLayanan SearchDetilTransaksiLayanan(String idTransaksi)
        {
            DetilTransaksiLayanan detilTransaksiLayanan = null;
            dtlDAO.makeConnection();
            detilTransaksiLayanan = dtlDAO.SearchDetilTransaksiLayanan(idTransaksi);
            dtlDAO.closeConnection();
            return detilTransaksiLayanan;
        }
        public void UpdateDetilTransaksiLayanan(DetilTransaksiLayanan detailTransaksiProduk, String idTransaksi)
        {
            dtlDAO.makeConnection();
            dtlDAO.UpdateDetilTransaksiLayanan(detailTransaksiProduk, idTransaksi);
            dtlDAO.closeConnection();
        }

        public void DeleteDetilTransaksiLayanan(String idTransaksi)
        {
            dtlDAO.makeConnection();
            dtlDAO.DeleteDetilTransaksiLayanan(idTransaksi);
            dtlDAO.closeConnection();
        }
        public List<DetilTransaksiLayanan> ShowDetilNotaLayanan()
        {
            dtlDAO.makeConnection();
            List<DetilTransaksiLayanan> NotaDetilTransaksiLayananData = dtlDAO.ShowDetilNotaLayanan();
            dtlDAO.closeConnection();
            return NotaDetilTransaksiLayananData;
        }
    }
}
