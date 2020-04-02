using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kouvee.Models
{
    public class UkuranHewan
    {
        public UkuranHewan(int iD_Ukuran, string ukuran)
        {
            ID_Ukuran = iD_Ukuran;
            Ukuran = ukuran;
        }

        public int ID_Ukuran { get; set; }
        public string Ukuran { get; set; }
    }
}
