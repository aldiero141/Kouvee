using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    class Hewan
    {
        public int ID_Hewan { get; set; }
        public string Nama_Hewan { get; set; }
        public string Tgl_Lahir_Hewan { get; set; }
        public int ID_Jenis { get; set; }
        public int ID_Ukuran { get; set; }
        public int ID_Customer { get; set; }
    }
}
