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
    public class PegawaiControl
    {
        private PegawaiDAO pDAO = new PegawaiDAO();

        public void CreatePegawai(Pegawai pegawai)
        {
            pDAO.makeConnection();
            pDAO.CreatePegawai(pegawai);
            pDAO.closeConnection();
        }

        public void UpdatePegawai(Pegawai pegawai, String namaPegawai)
        {
            pDAO.makeConnection();
            pDAO.UpdatePegawai(pegawai,namaPegawai);
            pDAO.closeConnection();
        }

        public void DeletePegawai(String namaPegawai)
        {
            pDAO.makeConnection();
            pDAO.DeletePegawai(namaPegawai);
            pDAO.closeConnection();
        }

        public List<Pegawai> ShowPegawai() 
        {
            pDAO.makeConnection();
            List<Pegawai> PegawaiData = pDAO.ShowPegawai();
            pDAO.closeConnection();
            return PegawaiData;
        }

        public Pegawai SearchPegawai(String nama)
        {
            Pegawai pegawai = null;
            pDAO.makeConnection();
            pegawai = pDAO.SearchPegawai(nama);
            pDAO.closeConnection();
            return pegawai;
        }
    }
}
