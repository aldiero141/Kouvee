using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kouvee.Models
{
    public class Pegawai
    {
        public Pegawai(string nama_Pegawai, string alamat_Pegawai, string tgl_Lahir_Pegawai, string phone_Pegawai, string jabatan, string password)
        {
            Nama_Pegawai = nama_Pegawai;
            Alamat_Pegawai = alamat_Pegawai;
            Tgl_Lahir_Pegawai = tgl_Lahir_Pegawai;
            Phone_Pegawai = phone_Pegawai;
            Jabatan = jabatan;
            Password = password;
        }

        public Pegawai(int iD_Pegawai, string nama_Pegawai, string alamat_Pegawai, string tgl_Lahir_Pegawai, string phone_Pegawai, string jabatan, string password, DateTime create_At_Pegawai, DateTime update_At_Pegawai, DateTime delete_At_Pegawai)
        {
            ID_Pegawai = iD_Pegawai;
            Nama_Pegawai = nama_Pegawai;
            Alamat_Pegawai = alamat_Pegawai;
            Tgl_Lahir_Pegawai = tgl_Lahir_Pegawai;
            Phone_Pegawai = phone_Pegawai;
            Jabatan = jabatan;
            Password = password;
            Create_At_Pegawai = create_At_Pegawai;
            Update_At_Pegawai = update_At_Pegawai;
            Delete_At_Pegawai = delete_At_Pegawai;
        }

        public int ID_Pegawai { get; set; }
        public string Nama_Pegawai { get; set; }
        public string Alamat_Pegawai { get; set; }
        public string Tgl_Lahir_Pegawai { get; set; }
        public string Phone_Pegawai { get; set; }
        public string Jabatan { get; set; }
        public string Password { get; set; }
        public DateTime Create_At_Pegawai { get; set; }
        public DateTime Update_At_Pegawai { get; set; }
        public DateTime Delete_At_Pegawai { get; set; }



    }
}
