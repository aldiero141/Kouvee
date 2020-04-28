using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Hewan
    {
        public Hewan(string nama_Pelanggan, string jenisHewan, int iD_Pegawai, string nama_Hewan, string tgl_Lahir_Hewan)
        {
            Nama_Pelanggan = nama_Pelanggan;
            JenisHewan = jenisHewan;
            ID_Pegawai = iD_Pegawai;
            Nama_Hewan = nama_Hewan;
            Tgl_Lahir_Hewan = tgl_Lahir_Hewan;
        }

        public Hewan(int iD_Jenis, int iD_Pelanggan, int iD_Pegawai, string nama_Hewan, string tgl_Lahir_Hewan)
        {
            ID_Jenis = iD_Jenis;
            ID_Pelanggan = iD_Pelanggan;
            ID_Pegawai = iD_Pegawai;
            Nama_Hewan = nama_Hewan;
            Tgl_Lahir_Hewan = tgl_Lahir_Hewan;
        }

        public Hewan(int iD_Hewan, int iD_Jenis, int iD_Pelanggan, int iD_Pegawai, string nama_Hewan, string tgl_Lahir_Hewan, DateTime create_At_Hewan, DateTime update_At_Hewan, DateTime delete_At_Hewan)
        {
            ID_Hewan = iD_Hewan;
            ID_Jenis = iD_Jenis;
            ID_Pelanggan = iD_Pelanggan;
            ID_Pegawai = iD_Pegawai;
            Nama_Hewan = nama_Hewan;
            Tgl_Lahir_Hewan = tgl_Lahir_Hewan;
            Create_At_Hewan = create_At_Hewan;
            Update_At_Hewan = update_At_Hewan;
            Delete_At_Hewan = delete_At_Hewan;
        }

        public string Nama_Pelanggan { get; set; }
        public string JenisHewan { get; set; }
        public int ID_Hewan { get; set; }
        public int ID_Jenis { get; set; }
        public int ID_Pelanggan { get; set; }
        public int ID_Pegawai { get; set; }
        public string Nama_Hewan { get; set; }
        public string Tgl_Lahir_Hewan { get; set; }
        public DateTime Create_At_Hewan { get; set; }
        public DateTime Update_At_Hewan { get; set; }
        public DateTime Delete_At_Hewan { get; set; }
    }
}
