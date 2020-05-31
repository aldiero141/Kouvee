using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class DetilTransaksiProduk
    {
        public DetilTransaksiProduk(string nama_Produk, int sub_Total_Produk, int jumlah_Produk)
        {
            Nama_Produk = nama_Produk;
            Sub_Total_Produk = sub_Total_Produk;
            Jumlah_Produk = jumlah_Produk;
        }

        public DetilTransaksiProduk(string iD_Transaksi_Produk, int id_Produk, int sub_Total_Produk, int jumlah_Produk)
        {
            ID_Transaksi_Produk = iD_Transaksi_Produk;
            ID_Produk = id_Produk;
            Sub_Total_Produk = sub_Total_Produk;
            Jumlah_Produk = jumlah_Produk;
        }

        public DetilTransaksiProduk(int iD_Detil_Transaksi, string iD_Transaksi_Produk, int iD_Produk, string nama_Produk, int sub_Total_Produk, int jumlah_Produk, int harga_Produk)
        {
            ID_Detil_Transaksi = iD_Detil_Transaksi;
            ID_Transaksi_Produk = iD_Transaksi_Produk;
            ID_Produk = iD_Produk;
            Nama_Produk = nama_Produk;
            Sub_Total_Produk = sub_Total_Produk;
            Jumlah_Produk = jumlah_Produk;
            Harga_Produk = harga_Produk;
        }

        public int ID_Detil_Transaksi { get; set; }
        public string ID_Transaksi_Produk { get; set; }
        public int ID_Produk { get; set; }
        public string Nama_Produk { get; set; }
        public int Sub_Total_Produk { get; set; }
        public int Jumlah_Produk { get; set; }
        public int Harga_Produk { get; set; }
    }
}
