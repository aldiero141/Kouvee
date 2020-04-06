using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Customer
    {
        public Customer(string nama_Pelanggan, string alamat_Pelanggan, string tgl_Lahir_Pelanggan, string phone_Pelanggan, int iD_Pegawai)
        {
            Nama_Pelanggan = nama_Pelanggan;
            Alamat_Pelanggan = alamat_Pelanggan;
            Tgl_Lahir_Pelanggan = tgl_Lahir_Pelanggan;
            Phone_Pelanggan = phone_Pelanggan;
            ID_Pegawai = iD_Pegawai;
        }

        public Customer(int iD_Pelanggan, string nama_Pelanggan, string alamat_Pelanggan, string tgl_Lahir_Pelanggan, string phone_Pelanggan, int iD_Pegawai, DateTime create_At_Pelanggan, DateTime update_At_Pelanggan, DateTime delete_At_Pelanggan)
        {
            ID_Pelanggan = iD_Pelanggan;
            Nama_Pelanggan = nama_Pelanggan;
            Alamat_Pelanggan = alamat_Pelanggan;
            Tgl_Lahir_Pelanggan = tgl_Lahir_Pelanggan;
            Phone_Pelanggan = phone_Pelanggan;
            ID_Pegawai = iD_Pegawai;
            Create_At_Pelanggan = create_At_Pelanggan;
            Update_At_Pelanggan = update_At_Pelanggan;
            Delete_At_Pelanggan = delete_At_Pelanggan;
        }

        public int ID_Pelanggan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public string Alamat_Pelanggan { get; set; }
        public string Tgl_Lahir_Pelanggan { get; set; }
        public string Phone_Pelanggan { get; set; }
        public int ID_Pegawai { get; set; }
        public DateTime Create_At_Pelanggan { get; set; }
        public DateTime Update_At_Pelanggan { get; set; }
        public DateTime Delete_At_Pelanggan { get; set; }

    }
}
