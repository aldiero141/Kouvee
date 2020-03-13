using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace Kouvee.Models
{
    class Pegawai
    {
        public int ID_Pegawai { get; set; }
        public string Nama_Pegawai { get; set; }
        public string Alamat_Pegawai { get; set; }
        public string Tgl_Lahir_Pegawai { get; set; }
        public string Phone_Pegawai { get; set; }
        public string Jabatan { get; set; }
        public string Password { get; set; }

    }
}
