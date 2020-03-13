using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class Customer
    {
        public int ID_Pelanggan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public string Alamat_Pelanggan { get; set; }
        public string Tgl_Lahir_Pelanggan { get; set; }
        public string Phone_Pelanggan { get; set; }
        public int ID_Pegawai { get; set; }
    }
}
