using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class Layanan
    {
        public Layanan(int iD_Layanan, string nama_Layanan)
        {
            ID_Layanan = iD_Layanan;
            Nama_Layanan = nama_Layanan;
        }

        public int ID_Layanan { get; set; }
        public string Nama_Layanan { get; set; }
    }
}
