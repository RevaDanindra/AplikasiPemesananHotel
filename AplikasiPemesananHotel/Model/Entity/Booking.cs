using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AplikasiPemesananHotel.Model.Entity
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int KamarID { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int Total { get; set; }
    }
}
