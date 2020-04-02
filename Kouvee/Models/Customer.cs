using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Customer
    {
        public Customer(int iD_Pelanggan, string nama_Pelanggan, string alamat_Pelanggan, string tgl_Lahir_Pelanggan, string phone_Pelanggan, int iD_Pegawai)
        {
            ID_Pelanggan = iD_Pelanggan;
            Nama_Pelanggan = nama_Pelanggan;
            Alamat_Pelanggan = alamat_Pelanggan;
            Tgl_Lahir_Pelanggan = tgl_Lahir_Pelanggan;
            Phone_Pelanggan = phone_Pelanggan;
            ID_Pegawai = iD_Pegawai;
        }

        public int ID_Pelanggan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public string Alamat_Pelanggan { get; set; }
        public string Tgl_Lahir_Pelanggan { get; set; }
        public string Phone_Pelanggan { get; set; }
        public int ID_Pegawai { get; set; }
    }
}
