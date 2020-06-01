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
        public void CreateDetilTransaksiLayanan(DetilTransaksiLayanan DTL)
        {
            dtlDAO.makeConnection();
            dtlDAO.CreateDetilTransaksiLayanan(DTL);
            dtlDAO.closeConnection();
        }

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

        public DetilTransaksiLayanan SearchDetilTransaksiLayananUsingID(String idDetilTransaksi, String idTransaksi)
        {
            DetilTransaksiLayanan detilTransaksiLayanan = null;
            dtlDAO.makeConnection();
            detilTransaksiLayanan = dtlDAO.SearchDetilTransaksiLayananUsingID(idDetilTransaksi,idTransaksi);
            dtlDAO.closeConnection();
            return detilTransaksiLayanan;
        }

        public void UpdateDetilTransaksiLayanan(DetilTransaksiLayanan detailTransaksiProduk, String idTransaksi)
        {
            dtlDAO.makeConnection();
            dtlDAO.UpdateDetilTransaksiLayanan(detailTransaksiProduk, idTransaksi);
            dtlDAO.closeConnection();
        }

        public void DeleteDetilTransaksiLayanan(String idDetil, String idTransaksi)
        {
            dtlDAO.makeConnection();
            dtlDAO.DeleteDetilTransaksiLayanan(idTransaksi, idDetil);
            dtlDAO.closeConnection();
        }

        public void DeleteDetilTransaksiLayananUsingIDTransaksi(String idTransaksi)
        {
            dtlDAO.makeConnection();
            dtlDAO.DeleteDetilTransaksiLayananUsingIDTransaksi(idTransaksi);
            dtlDAO.closeConnection();
        }

        public List<DetilTransaksiLayanan> ShowDetilNotaLayanan()
        {
            dtlDAO.makeConnection();
            List<DetilTransaksiLayanan> NotaDetilTransaksiLayananData = dtlDAO.ShowDetilNotaLayanan();
            dtlDAO.closeConnection();
            return NotaDetilTransaksiLayananData;
        }

        public List<DetilTransaksiLayanan> SearchDetilTransaksiLayananUsingIDLayanan(String idTransaksi)
        {
            dtlDAO.makeConnection();
            List<DetilTransaksiLayanan> DetilTransaksiLayananData = dtlDAO.SearchDetilTransaksiLayananUsingIDLayanan(idTransaksi);
            dtlDAO.closeConnection();
            return DetilTransaksiLayananData;
        }

    }
}
