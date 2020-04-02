﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Produk
    {
        public Produk(int iD_Produk, string nama_Produk, int stock, int min_Stock, int harga_BeliProduk, int harga_JualProduk, string gambar_Produk, int iD_Pegawai)
        {
            ID_Produk = iD_Produk;
            Nama_Produk = nama_Produk;
            Stock = stock;
            Min_Stock = min_Stock;
            Harga_BeliProduk = harga_BeliProduk;
            Harga_JualProduk = harga_JualProduk;
            Gambar_Produk = gambar_Produk;
            ID_Pegawai = iD_Pegawai;
        }

        public int ID_Produk { get; set; }
        public string Nama_Produk { get; set; }
        public int Stock { get; set; }
        public int Min_Stock { get; set; }
        public int Harga_BeliProduk { get; set; }
        public int Harga_JualProduk { get; set; }
        public string Gambar_Produk { get; set; }
        public int ID_Pegawai { get; set; }
    }
}
