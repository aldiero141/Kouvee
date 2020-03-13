using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouvee.DAO;
using Kouvee.Models;

namespace Kouvee.Control
{
    public class PegawaiControl
    {
        public PegawaiDAO pegawaiDAO = new PegawaiDAO;

        public void InsertPegawai(Pegawai pegawai)
        {
            PegawaiDAO.InsertPegawai(pegawai);
        }

        public void UpdatePegawai(Pegawai pegawai)
        {
            PegawaiDAO.UpdatePegawai(pegawai);
        }

        public void DeletePegawai(string Nama_Pegawai)
        {
            PegawaiDAO.DeletePegawai(Nama_Pegawai);
        }
    }
}
