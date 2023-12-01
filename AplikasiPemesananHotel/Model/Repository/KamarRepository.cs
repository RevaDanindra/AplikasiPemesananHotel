using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplikasiPemesananHotel.Model.Entity;
using AplikasiPemesananHotel.Model.Context;
using System.Data.SQLite;

namespace AplikasiPemesananHotel.Model.Repository
{
    public class KamarRepository
    {
        // deklarasi objek connection
        private SQLiteConnection _conn;

        // constructor
        public KamarRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Kamar kamar)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Kamar (KamarID, Tipe_Kamar, Tipe_Tempat_Tidur, Kapasitas, HotelID, HargaHari) values (@KamarID, @Tipe_Kamar, @Tipe_Tempat_Tidur, @Kapasitas, @HotelID, @HargaHari)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@KamarID", kamar.KamarID);
                cmd.Parameters.AddWithValue("@Tipe_Kamar", kamar.TipeKamar);
                cmd.Parameters.AddWithValue("@Tipe_Tempat_Tidur", kamar.TipeTempatTidur);
                cmd.Parameters.AddWithValue("@Kapasitas", kamar.Kapasitas);
                cmd.Parameters.AddWithValue("@HotelID", kamar.HotelID);
                cmd.Parameters.AddWithValue("@HargaHari", kamar.HargaHari);


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

        public int Update(Kamar kamar)
        {
            int result = 0;
            string sql = @"update Kamar set KamarID = @KamarID, Tipe_Kamar = @Tipe_Kamar, Tipe_Tempat_Tidur = @Tipe_Tempat_Tidur, Kapasitas = @Kapasitas, HotelID = @HotelID, HargaHari = @HargaHari";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@KamarID", kamar.KamarID);
                cmd.Parameters.AddWithValue("@Tipe_Kamar", kamar.TipeKamar);
                cmd.Parameters.AddWithValue("@Tipe_Tempat_Tidur", kamar.TipeTempatTidur);
                cmd.Parameters.AddWithValue("@Kapasitas", kamar.Kapasitas);
                cmd.Parameters.AddWithValue("@HotelID", kamar.HotelID);
                cmd.Parameters.AddWithValue("@HargaHari", kamar.HargaHari);

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

        public int Delete(Kamar kamar)
        {
            int result = 0;
            string sql = @"delete from Kamar where KamarID = @KamarID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@KamarID", kamar.KamarID);
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

        public List<Kamar> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Kamar> list = new List<Kamar>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select KamarID, Tipe_Kamar, Tipe_Tempat_Tidur, Kapasitas, HotelID from Kamar order by Tipe_Kamar";
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
                            Kamar kamar = new Kamar();
                            kamar.KamarID = Convert.ToInt32(dtr["KamarID"]);
                            kamar.TipeKamar = dtr["Tipe_Kamar"].ToString();
                            kamar.TipeTempatTidur = dtr["Tipe_Tempat_Tidur"].ToString();
                            kamar.Kapasitas = Convert.ToInt32(dtr["Kapasitas"]);
                            kamar.HotelID = Convert.ToInt32(dtr["HotelID"]);
                            kamar.HargaHari = Convert.ToInt32(dtr["HargaHari"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(kamar);
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

        public List<Kamar> ReadByTipeKamar(string TipeKamar)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Kamar> list = new List<Kamar>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select KamarID, Tipe_Kamar, Tipe_Tempat_Tidur, Kapasitas, HotelID from Kamar where Tipe_Kamar like @Tipe_Kamar order by Tipe_Kamar";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@Tipe_Kamar", string.Format("%{0}%", TipeKamar));
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Kamar kamar = new Kamar();
                            kamar.KamarID = Convert.ToInt32(dtr["KamarID"]);
                            kamar.TipeKamar = dtr["Tipe_Kamar"].ToString();
                            kamar.TipeTempatTidur = dtr["Tipe_Tempat_Tidur"].ToString();
                            kamar.Kapasitas = Convert.ToInt32(dtr["Kapasitas"]);
                            kamar.HotelID = Convert.ToInt32(dtr["HotelID"]);
                            kamar.HargaHari = Convert.ToInt32(dtr["HargaHari"]);
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(kamar);
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
