using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Hewan
    {
        public Hewan(int iD_Hewan, string nama_Hewan, string tgl_Lahir_Hewan, int iD_Jenis, int iD_Ukuran, int iD_Customer)
        {
            ID_Hewan = iD_Hewan;
            Nama_Hewan = nama_Hewan;
            Tgl_Lahir_Hewan = tgl_Lahir_Hewan;
            ID_Jenis = iD_Jenis;
            ID_Ukuran = iD_Ukuran;
            ID_Customer = iD_Customer;
        }

        public int ID_Hewan { get; set; }
        public string Nama_Hewan { get; set; }
        public string Tgl_Lahir_Hewan { get; set; }
        public int ID_Jenis { get; set; }
        public int ID_Ukuran { get; set; }
        public int ID_Customer { get; set; }
    }
}
