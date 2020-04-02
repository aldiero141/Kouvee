using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class JenisHewan
    {
        public JenisHewan(int iD_JenisHewan, string jenis_Hewan)
        {
            ID_JenisHewan = iD_JenisHewan;
            Jenis_Hewan = jenis_Hewan;
        }

        public int ID_JenisHewan { get; set; }
        public string Jenis_Hewan { get; set; }
    }
}
