using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Supplier
    {
        public Supplier(string nama_Supplier, string alamat_Supplier, string phone_Supplier, int iD_Pegawai)
        {
            Nama_Supplier = nama_Supplier;
            Alamat_Supplier = alamat_Supplier;
            Phone_Supplier = phone_Supplier;
            ID_Pegawai = iD_Pegawai;
        }

        public Supplier(int iD_Supplier, string nama_Supplier, string alamat_Supplier, string phone_Supplier, int iD_Pegawai, DateTime create_At_Supplier, DateTime update_At_Supplier, DateTime delete_At_Supplier)
        {
            ID_Supplier = iD_Supplier;
            Nama_Supplier = nama_Supplier;
            Alamat_Supplier = alamat_Supplier;
            Phone_Supplier = phone_Supplier;
            ID_Pegawai = iD_Pegawai;
            Create_At_Supplier = create_At_Supplier;
            Update_At_Supplier = update_At_Supplier;
            Delete_At_Supplier = delete_At_Supplier;
        }

        public int ID_Supplier { get; set; }
        public string Nama_Supplier { get; set; }
        public string Alamat_Supplier { get; set; }
        public string Phone_Supplier { get; set; }
        public int ID_Pegawai { get; set; }
        public DateTime Create_At_Supplier { get; set; }
        public DateTime Update_At_Supplier { get; set; }
        public DateTime Delete_At_Supplier { get; set; }
    }
}
