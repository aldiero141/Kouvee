using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Layanan
    {
        public Layanan(string ukuran, string jenisHewan, int iD_Pegawai, string nama_Layanan, int harga_Layanan)
        {
            Ukuran = ukuran;
            JenisHewan = jenisHewan;
            ID_Pegawai = iD_Pegawai;
            Nama_Layanan = nama_Layanan;
            Harga_Layanan = harga_Layanan;
        }

        public Layanan(int iD_Ukuran, int iD_Pegawai, int iD_JenisHewan, string nama_Layanan, int harga_Layanan)
        {
            ID_Ukuran = iD_Ukuran;
            ID_Pegawai = iD_Pegawai;
            ID_JenisHewan = iD_JenisHewan;
            Nama_Layanan = nama_Layanan;
            Harga_Layanan = harga_Layanan;
        }

        public Layanan(int iD_Layanan, int iD_Ukuran, int iD_Pegawai, int iD_JenisHewan, string nama_Layanan, int harga_Layanan, DateTime create_At_Layanan, DateTime update_At_Layanan, DateTime delete_At_Layanan)
        {
            ID_Layanan = iD_Layanan;
            ID_Ukuran = iD_Ukuran;
            ID_Pegawai = iD_Pegawai;
            ID_JenisHewan = iD_JenisHewan;
            Nama_Layanan = nama_Layanan;
            Harga_Layanan = harga_Layanan;
            Create_At_Layanan = create_At_Layanan;
            Update_At_Layanan = update_At_Layanan;
            Delete_At_Layanan = delete_At_Layanan;
        }

        public string Ukuran { get; set; }
        public string JenisHewan { get; set; }
        public int ID_Layanan { get; set; }
        public int ID_Ukuran { get; set; }
        public int ID_Pegawai { get; set; }
        public int ID_JenisHewan { get; set; }
        public string Nama_Layanan { get; set; }
        public int Harga_Layanan { get; set; }
        public DateTime Create_At_Layanan { get; set; }
        public DateTime Update_At_Layanan { get; set; }
        public DateTime Delete_At_Layanan { get; set; }
    }
}
