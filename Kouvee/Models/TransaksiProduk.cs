using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class TransaksiProduk
    {
        public TransaksiProduk(string iD_Transaksi_Produk, int iD_Pegawai, string nama_Pegawai, int iD_Hewan, string nama_Hewan, string nama_Pelanggan, int peg_ID_Pegawai, int status_Transaksi_Produk, DateTime tgl_Transaksi_Produk, int subtotal_Transaksi_Produk, int total_Transaksi_Produk, int diskon_Produk)
        {
            ID_Transaksi_Produk = iD_Transaksi_Produk;
            ID_Pegawai = iD_Pegawai;
            Nama_Pegawai = nama_Pegawai;
            ID_Hewan = iD_Hewan;
            Nama_Hewan = nama_Hewan;
            Nama_Pelanggan = nama_Pelanggan;
            Peg_ID_Pegawai = peg_ID_Pegawai;
            Status_Transaksi_Produk = status_Transaksi_Produk;
            Tgl_Transaksi_Produk = tgl_Transaksi_Produk;
            Subtotal_Transaksi_Produk = subtotal_Transaksi_Produk;
            Total_Transaksi_Produk = total_Transaksi_Produk;
            Diskon_Produk = diskon_Produk;
        }

        public string ID_Transaksi_Produk { get; set; }
        public int ID_Pegawai { get; set; }
        public string Nama_Pegawai { get; set; }
        public int ID_Hewan { get; set; }
        public string Nama_Hewan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public int Peg_ID_Pegawai { get; set; }
        public int Status_Transaksi_Produk { get; set; }
        public DateTime Tgl_Transaksi_Produk { get; set; }
        public int Subtotal_Transaksi_Produk { get; set; }
        public int Total_Transaksi_Produk { get; set; }
        public int Diskon_Produk { get; set; }
    }
}
