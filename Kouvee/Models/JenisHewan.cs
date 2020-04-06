using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouvee.Models
{
    public class JenisHewan
    {
        public JenisHewan(int iD_Pegawai, string jenis_Hewan)
        {
            ID_Pegawai = iD_Pegawai;
            Jenis_Hewan = jenis_Hewan;
        }

        public JenisHewan(int iD_JenisHewan, int iD_Pegawai, string jenis_Hewan, DateTime create_At_JHewan, DateTime update_At_JHewan, DateTime delete_At_JHewan)
        {
            ID_JenisHewan = iD_JenisHewan;
            ID_Pegawai = iD_Pegawai;
            Jenis_Hewan = jenis_Hewan;
            Create_At_JHewan = create_At_JHewan;
            Update_At_JHewan = update_At_JHewan;
            Delete_At_JHewan = delete_At_JHewan;
        }

        public int ID_JenisHewan { get; set; }
        public int ID_Pegawai { get; set; }
        public string Jenis_Hewan { get; set; }
        public DateTime Create_At_JHewan { get; set; }
        public DateTime Update_At_JHewan { get; set; }
        public DateTime Delete_At_JHewan { get; set; }
    }
}
