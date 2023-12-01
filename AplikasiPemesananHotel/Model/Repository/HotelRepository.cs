using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AplikasiPemesananHotel.Model.Entity;
using AplikasiPemesananHotel.Model.Context;

namespace AplikasiPemesananHotel.Model.Repository
{
    public class HotelRepository
    {
        // deklarasi objek connection
        private SQLiteConnection _conn;

        // constructor
        public HotelRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create (Hotel hotel)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Hotel (HotelID, Kota, Nama_Hotel, Rating, UserID) values (@HotelID, @Kota, @Nama_Hotel, @Rating, @UserID)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@HotelID", hotel.HotelID);
                cmd.Parameters.AddWithValue("@Kota", hotel.Kota);
                cmd.Parameters.AddWithValue("@Nama_Hotel", hotel.NamaHotel);
                cmd.Parameters.AddWithValue("@Rating", hotel.Rating);
                cmd.Parameters.AddWithValue("@UserID", hotel.UserID);

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

        public int Update (Hotel hotel) 
        {
            int result = 0;
            string sql = @"update Hotel set HotelID = @HotelID, Kota = @Kota, Nama_Hotel = @Nama_Hotel, Rating = @Rating, UserID = @UserID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@HotelID", hotel.HotelID);
                cmd.Parameters.AddWithValue("@Kota", hotel.Kota);
                cmd.Parameters.AddWithValue("@Nama_Hotel", hotel.NamaHotel);
                cmd.Parameters.AddWithValue("@Rating", hotel.Rating);
                cmd.Parameters.AddWithValue("@UserID", hotel.UserID);

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

        public int Delete (Hotel hotel) 
        {
            int result = 0;
            string sql = @"delete from Hotel where HotelID = @HotelID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@HotelID", hotel.HotelID);
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

        public List<Hotel> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Hotel> list = new List<Hotel>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select HotelID, Kota, Nama_Hotel, Rating, UserID from Hotel order by Nama_Hotel";
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
                            Hotel hotel = new Hotel();
                            hotel.HotelID = Convert.ToInt32(dtr["HotelID"]);
                            hotel.Kota = dtr["Kota"].ToString();
                            hotel.NamaHotel = dtr["Nama_Hotel"].ToString();
                            hotel.Rating = Convert.ToInt32(dtr["Rating"]);
                            hotel.UserID = Convert.ToInt32(dtr["UserID"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(hotel);
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

        public List<Hotel> ReadByNamaHotel(string NamaHotel)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Hotel> list = new List<Hotel>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select HotelID, Kota, Nama_Hotel, Rating, UserID from Hotel where Nama_Hotel like @Nama_Hotel order by Nama_Hotel";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@Nama_Hotel", string.Format("%{0}%", NamaHotel));
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Hotel hotel = new Hotel();
                            hotel.HotelID = Convert.ToInt32(dtr["HotelID"]);
                            hotel.Kota = dtr["Kota"].ToString();
                            hotel.NamaHotel = dtr["Nama_Hotel"].ToString();
                            hotel.Rating = Convert.ToInt32(dtr["Rating"]);
                            hotel.UserID = Convert.ToInt32(dtr["UserID"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(hotel);
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
