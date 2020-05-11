using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class DetilTransaksiLayanan
    {
        public DetilTransaksiLayanan(string nama_Layanan, int sub_Total_Layanan, int jumlah_Detil_Layanan)
        {
            Nama_Layanan = nama_Layanan;
            Sub_Total_Layanan = sub_Total_Layanan;
            Jumlah_Detil_Layanan = jumlah_Detil_Layanan;
        }

        public DetilTransaksiLayanan(string nama_Layanan, int sub_Total_Layanan, int jumlah_Detil_Layanan, int harga_Layanan)
        {
            Nama_Layanan = nama_Layanan;
            Sub_Total_Layanan = sub_Total_Layanan;
            Jumlah_Detil_Layanan = jumlah_Detil_Layanan;
            Harga_Layanan = harga_Layanan;
        }

        public DetilTransaksiLayanan(int iD_DetilTransaksi_Layanan, string iD_Transaksi_Layanan, int iD_Layanan, string nama_Layanan, int sub_Total_Layanan, int jumlah_Detil_Layanan, int harga_Layanan)
        {
            ID_DetilTransaksi_Layanan = iD_DetilTransaksi_Layanan;
            ID_Transaksi_Layanan = iD_Transaksi_Layanan;
            ID_Layanan = iD_Layanan;
            Nama_Layanan = nama_Layanan;
            Sub_Total_Layanan = sub_Total_Layanan;
            Jumlah_Detil_Layanan = jumlah_Detil_Layanan;
            Harga_Layanan = harga_Layanan;
        }

        public int ID_DetilTransaksi_Layanan { get; set; }
        public string ID_Transaksi_Layanan { get; set; }
        public int ID_Layanan { get; set; }
        public string Nama_Layanan { get; set; }
        public int Sub_Total_Layanan { get; set; }
        public int Jumlah_Detil_Layanan { get; set; }
        public int Harga_Layanan { get; set; }
    }
}
