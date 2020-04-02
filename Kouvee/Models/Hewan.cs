using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Hewan
    {
        public Hewan(int iD_Hewan, int iD_Jenis, /*int iD_Ukuran,*/ int iD_Pelanggan, int iD_Pegawai, string nama_Hewan, string tgl_Lahir_Hewan)
        {
            ID_Hewan = iD_Hewan;
            ID_Jenis = iD_Jenis;
            //ID_Ukuran = iD_Ukuran;
            ID_Pelanggan = iD_Pelanggan;
            ID_Pegawai = iD_Pegawai;
            Nama_Hewan = nama_Hewan;
            Tgl_Lahir_Hewan = tgl_Lahir_Hewan;
        }

        public int ID_Hewan { get; set; }
        public int ID_Jenis { get; set; }
        //public int ID_Ukuran { get; set; }
        public int ID_Pelanggan { get; set; }
        public int ID_Pegawai { get; set; }
        public string Nama_Hewan { get; set; }
        public string Tgl_Lahir_Hewan { get; set; }
    }
}
