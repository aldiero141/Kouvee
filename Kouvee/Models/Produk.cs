using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class Produk
    {
        public int ID_Produk { get; set; }
        public string Nama_Produk { get; set; }
        public int Stock { get; set; }
        public int Min_Stock { get; set; }
        public float Harga_BeliProduk { get; set; }
        public float Harga_JualProduk { get; set; }
        public string Gambar_Produk { get; set; }
        public int ID_Pegawai { get; set; }

    }
}
