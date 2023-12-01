using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiPemesananHotel.Model.Entity
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string Kota { get; set; }
        public string NamaHotel { get; set; }
        public int Rating { get; set; }
        public int UserID { get; set; }
    }
}
