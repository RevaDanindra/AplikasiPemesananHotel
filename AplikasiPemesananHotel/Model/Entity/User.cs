using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiPemesananHotel.Model.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Nama { get; set; }
        public string TanggalLahir { get; set; }
        public string JenisKelamin { get; set; } 
        public string Alamat { get; set; }
        public string NoTelepon { get; set; }
        public string Email { get; set; }
    }
}
