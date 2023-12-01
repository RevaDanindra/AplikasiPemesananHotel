using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiPemesananHotel.Model.Entity
{
    public class Kamar
    {
        public int KamarID { get; set; }
        public string TipeKamar { get; set; }
        public string TipeTempatTidur { get; set; }
        public int Kapasitas { get; set; }
        public int HargaHari { get; set; }
        public int HotelID { get; set; }
    }
}
