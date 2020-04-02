using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Supplier
    {
        public Supplier(int iD_Supplier, string nama_Supplier, string alamat_Supplier, string phone_Supplier, int iD_Pegawai)
        {
            ID_Supplier = iD_Supplier;
            Nama_Supplier = nama_Supplier;
            Alamat_Supplier = alamat_Supplier;
            Phone_Supplier = phone_Supplier;
            ID_Pegawai = iD_Pegawai;
        }

        public int ID_Supplier { get; set; }
        public string Nama_Supplier { get; set; }
        public string Alamat_Supplier { get; set; }
        public string Phone_Supplier { get; set; }
        public int ID_Pegawai { get; set; }
    }
}
