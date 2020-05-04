using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class TransaksiProduk
    {


        public TransaksiProduk(int subtotal_Transaksi_Produk)
        {
            Subtotal_Transaksi_Produk = subtotal_Transaksi_Produk;
        }

        public TransaksiProduk(int status_Transaksi_Produk, int total_Transaksi_Produk, int diskon_Produk, int peg_ID_Pegawai)
        {
            Status_Transaksi_Produk = status_Transaksi_Produk;
            Total_Transaksi_Produk = total_Transaksi_Produk;
            Diskon_Produk = diskon_Produk;
            Peg_ID_Pegawai = peg_ID_Pegawai;
        }

        public TransaksiProduk(string nama_CS, string nama_Hewan, string nama_Kasir, int status_Transaksi_Produk, int total_Transaksi_Produk, int diskon_Produk)
        {
            Nama_CS = nama_CS;
            Nama_Hewan = nama_Hewan;
            Nama_Kasir = nama_Kasir;
            Status_Transaksi_Produk = status_Transaksi_Produk;
            Total_Transaksi_Produk = total_Transaksi_Produk;
            Diskon_Produk = diskon_Produk;
        }

        public TransaksiProduk(string iD_Transaksi_Produk, int iD_Pegawai, string nama_CS, int iD_Hewan, string nama_Hewan, string nama_Pelanggan, int peg_ID_Pegawai, string nama_Kasir, int status_Transaksi_Produk, DateTime tgl_Transaksi_Produk, int subtotal_Transaksi_Produk, int total_Transaksi_Produk, int diskon_Produk)
        {
            ID_Transaksi_Produk = iD_Transaksi_Produk;
            ID_Pegawai = iD_Pegawai;
            Nama_CS = nama_CS;
            ID_Hewan = iD_Hewan;
            Nama_Hewan = nama_Hewan;
            Nama_Pelanggan = nama_Pelanggan;
            Peg_ID_Pegawai = peg_ID_Pegawai;
            Nama_Kasir = nama_Kasir;
            Status_Transaksi_Produk = status_Transaksi_Produk;
            Tgl_Transaksi_Produk = tgl_Transaksi_Produk;
            Subtotal_Transaksi_Produk = subtotal_Transaksi_Produk;
            Total_Transaksi_Produk = total_Transaksi_Produk;
            Diskon_Produk = diskon_Produk;
        }

        public TransaksiProduk(string iD_Transaksi_Produk, string nama_CS, string nama_Hewan, string nama_Pelanggan, string nama_Kasir, DateTime tgl_Transaksi_Produk, int subtotal_Transaksi_Produk, int total_Transaksi_Produk, int diskon_Produk, string nomor_Telpon, string jenis_Hewan)
        {
            ID_Transaksi_Produk = iD_Transaksi_Produk;
            Nama_CS = nama_CS;
            Nama_Hewan = nama_Hewan;
            Nama_Pelanggan = nama_Pelanggan;
            Nama_Kasir = nama_Kasir;
            Tgl_Transaksi_Produk = tgl_Transaksi_Produk;
            Subtotal_Transaksi_Produk = subtotal_Transaksi_Produk;
            Total_Transaksi_Produk = total_Transaksi_Produk;
            Diskon_Produk = diskon_Produk;
            Nomor_Telpon = nomor_Telpon;
            Jenis_Hewan = jenis_Hewan;
        }

        public string ID_Transaksi_Produk { get; set; }
        public int ID_Pegawai { get; set; }
        public string Nama_CS { get; set; }
        public int ID_Hewan { get; set; }
        public string Nama_Hewan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public int Peg_ID_Pegawai { get; set; }
        public string Nama_Kasir { get; set; }
        public int Status_Transaksi_Produk { get; set; }
        public DateTime Tgl_Transaksi_Produk { get; set; }
        public int Subtotal_Transaksi_Produk { get; set; }
        public int Total_Transaksi_Produk { get; set; }
        public int Diskon_Produk { get; set; }
        public string Nomor_Telpon { get; set; }
        public string Jenis_Hewan { get; set; }
    }
}
