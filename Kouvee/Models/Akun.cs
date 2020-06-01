using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class Akun
    {
        public Akun(string nama_Pegawai, string password, string jabatan, int iD_Pegawai)
        {
            Nama_Pegawai = nama_Pegawai;
            Password = password;
            Jabatan = jabatan;
            ID_Pegawai = iD_Pegawai;
        }

        public string Nama_Pegawai { get; set; }
        public string Password { get; set; }
        public string Jabatan { get; set; }
        public int ID_Pegawai { get; set; }
    }
}
