using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kouvee.Models
{
    public class UkuranHewan
    {
        public UkuranHewan(int iD_Pegawai, string ukuran)
        {
            ID_Pegawai = iD_Pegawai;
            Ukuran = ukuran;
        }

        public UkuranHewan(int iD_Ukuran, int iD_Pegawai, string ukuran, DateTime create_At_Ukuran, DateTime update_At_Ukuran, DateTime delete_At_Ukuran)
        {
            ID_Ukuran = iD_Ukuran;
            ID_Pegawai = iD_Pegawai;
            Ukuran = ukuran;
            Create_At_Ukuran = create_At_Ukuran;
            Update_At_Ukuran = update_At_Ukuran;
            Delete_At_Ukuran = delete_At_Ukuran;
        }

        public int ID_Ukuran { get; set; }
        public int ID_Pegawai { get; set; }
        public string Ukuran { get; set; }
        public DateTime Create_At_Ukuran { get; set; }
        public DateTime Update_At_Ukuran { get; set; }
        public DateTime Delete_At_Ukuran { get; set; }
    }
}
