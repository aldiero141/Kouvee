using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class TransaksiLayanan
    {

        public TransaksiLayanan(int subtotal_Transaksi_Layanan)
        {
            Subtotal_Transaksi_Layanan = subtotal_Transaksi_Layanan;
        }

        public TransaksiLayanan(int status_Layanan, int total_Transaksi_Layanan, int diskon_Layanan)
        {
            Status_Layanan = status_Layanan;
            Total_Transaksi_Layanan = total_Transaksi_Layanan;
            Diskon_Layanan = diskon_Layanan;
        }

        public TransaksiLayanan(string nama_CS, string nama_Kasir, string nama_Hewan, int progres_Layanan, int status_Layanan, int total_Transaksi_Layanan, int diskon_Layanan)
        {
            Nama_CS = nama_CS;
            Nama_Kasir = nama_Kasir;
            Nama_Hewan = nama_Hewan;
            Progres_Layanan = progres_Layanan;
            Status_Layanan = status_Layanan;
            Total_Transaksi_Layanan = total_Transaksi_Layanan;
            Diskon_Layanan = diskon_Layanan;
        }

        public TransaksiLayanan(string iD_Transaksi_Layanan, int iD_Pegawai, string nama_CS, int peg_ID_Pegawai, string nama_Kasir, int iD_Hewan, string nama_Hewan, string nama_Pelanggan, DateTime tgl_Transaksi_Layanan, int progres_Layanan, int status_Layanan, int total_Transaksi_Layanan, int subtotal_Transaksi_Layanan, int diskon_Layanan)
        {
            ID_Transaksi_Layanan = iD_Transaksi_Layanan;
            ID_Pegawai = iD_Pegawai;
            Nama_CS = nama_CS;
            Peg_ID_Pegawai = peg_ID_Pegawai;
            Nama_Kasir = nama_Kasir;
            ID_Hewan = iD_Hewan;
            Nama_Hewan = nama_Hewan;
            Nama_Pelanggan = nama_Pelanggan;
            Tgl_Transaksi_Layanan = tgl_Transaksi_Layanan;
            Progres_Layanan = progres_Layanan;
            Status_Layanan = status_Layanan;
            Total_Transaksi_Layanan = total_Transaksi_Layanan;
            Subtotal_Transaksi_Layanan = subtotal_Transaksi_Layanan;
            Diskon_Layanan = diskon_Layanan;
        }

        public string ID_Transaksi_Layanan{ get; set; }
        public int ID_Pegawai { get; set; }
        public string Nama_CS { get; set; }
        public int Peg_ID_Pegawai { get; set; }
        public string Nama_Kasir { get; set; }
        public int ID_Hewan { get; set; }
        public string Nama_Hewan { get; set; }
        public string Nama_Pelanggan { get; set; }
        public DateTime Tgl_Transaksi_Layanan { get; set; }
        public int Progres_Layanan { get; set; }
        public int Status_Layanan { get; set; }
        public int Total_Transaksi_Layanan { get; set; }
        public int Subtotal_Transaksi_Layanan { get; set; }
        public int Diskon_Layanan { get; set; }

    }
}
