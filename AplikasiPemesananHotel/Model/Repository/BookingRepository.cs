using AplikasiPemesananHotel.Model.Context;
using AplikasiPemesananHotel.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiPemesananHotel.Model.Repository
{
    public class BookingRepository
    {
        // deklarasi objek connection
        private SQLiteConnection _conn;

        // constructor
        public BookingRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Booking booking)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Booking (BookingID, CheckIn, CheckOut, Total, UserID, KamarID) values (@BookingID, @CheckIn, @CheckOut, @Total, @UserID, @KamarID)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@CheckIn", booking.CheckIn);
                cmd.Parameters.AddWithValue("@CheckOut", booking.CheckOut);
                cmd.Parameters.AddWithValue("@Total", booking.Total);
                cmd.Parameters.AddWithValue("@UserID", booking.UserID);
                cmd.Parameters.AddWithValue("@KamarID", booking.KamarID);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Booking booking)
        {
            int result = 0;
            string sql = @"update Booking set BookingID = @BookingID, CheckIn = @CheckIn, CheckOut = @CheckOut, Total = @Total, UserID = @UserID, KamarID = @KamarID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@CheckIn", booking.CheckIn);
                cmd.Parameters.AddWithValue("@CheckOut", booking.CheckOut);
                cmd.Parameters.AddWithValue("@Total", booking.Total);
                cmd.Parameters.AddWithValue("@UserID", booking.UserID);
                cmd.Parameters.AddWithValue("@KamarID", booking.KamarID);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Booking booking)
        {
            int result = 0;
            string sql = @"delete from Booking where BookingID = @BookingID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Booking> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Booking> list = new List<Booking>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select BookingID, CheckIn, CheckOut, Total, UserID, KamarID from Booking order by UserID";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT) 
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set 
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(dtr["BookingID"]);
                            booking.CheckIn = dtr["CheckIn"].ToString();
                            booking.CheckOut = dtr["CheckOut"].ToString();
                            booking.Total = Convert.ToInt32(dtr["Total"]);
                            booking.UserID = Convert.ToInt32(dtr["UserID"]);
                            booking.KamarID = Convert.ToInt32(dtr["KamarID"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(booking);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        public List<Booking> ReadByBookingID(string BookingID)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Booking> list = new List<Booking>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select BookingID, CheckIn, CheckOut, Total, UserID, KamarID from Booking where BookingID like @BookingID order by BookingID";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@BookingID", string.Format("%{0}%", BookingID));
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(dtr["BookingID"]);
                            booking.CheckIn = dtr["CheckIn"].ToString();
                            booking.CheckOut = dtr["CheckOut"].ToString();
                            booking.Total = Convert.ToInt32(dtr["Total"]);
                            booking.UserID = Convert.ToInt32(dtr["UserID"]);
                            booking.KamarID = Convert.ToInt32(dtr["KamarID"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(booking);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }
            return list;
        }
    }
}
