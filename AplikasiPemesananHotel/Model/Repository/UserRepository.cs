using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using AplikasiPemesananHotel.Model.Entity;
using AplikasiPemesananHotel.Model.Context;

namespace AplikasiPemesananHotel.Model.Repository
{
    public class UserRepository
    {
        // deklarasi objek connection
        private SQLiteConnection _conn;

        // constructor
        public UserRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(User user)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into User (UserID, Nama, Tanggal_Lahir, Alamat, No_Telepon, Email, Jenis_Kelamin) values (@UserID, @Nama, @Tanggal_Lahir, @Alamat, @No_Telepon, @Email, @Jenis_Kelamin)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Nama", user.Nama);
                cmd.Parameters.AddWithValue("@Tanggal_Lahir", user.TanggalLahir);
                cmd.Parameters.AddWithValue("@Alamat", user.Alamat);
                cmd.Parameters.AddWithValue("@No_Telepon", user.NoTelepon);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Jenis_Kelamin", user.JenisKelamin);

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

        public int Update(User user)
        {
            int result = 0;
            string sql = @"update User set UserID = @UserID, Nama = @Nama, Tanggal_Lahir = @Tanggal_Lahir, Alamat = @Alamat, No_Telepon = @No_Telepon, Email = @Email, Jenis_Kelamin = @Jenis_Kelamin";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Nama", user.Nama);
                cmd.Parameters.AddWithValue("@Tanggal_Lahir", user.TanggalLahir);
                cmd.Parameters.AddWithValue("@Alamat", user.Alamat);
                cmd.Parameters.AddWithValue("@No_Telepon", user.NoTelepon);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Jenis_Kelamin", user.JenisKelamin);

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

        public int Delete(User user)
        {
            int result = 0;
            string sql = @"delete from mahasiswa where UserID = @UserID";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
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

        public List<User> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<User> list = new List<User>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select UserID, Nama, Tanggal_Lahir, Alamat, No_Telepon, Email, Jenis_Kelamin from User order by Nama";
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
                            User user = new User();
                            user.UserID = Convert.ToInt32(dtr["UserID"]);
                            user.Nama = dtr["Nama"].ToString();
                            user.TanggalLahir = dtr["Tanggal_Lahir"].ToString();
                            user.Alamat = dtr["Alamat"].ToString();
                            user.NoTelepon = dtr["No_Telepon"].ToString();
                            user.Email = dtr["Email"].ToString();
                            user.JenisKelamin = dtr["Jenis_Kelamin"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(user);
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

        public List<User> ReadByNama(string Nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<User> list = new List<User>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select UserID, Nama, Tanggal_Lahir, Alamat, No_Telepon, Email, Jenis_Kelamin from User where Nama like @Nama order by Nama";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@Nama", string.Format("%{0}%", Nama));
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            User user = new User();
                            user.UserID = Convert.ToInt32(dtr["UserID"]);
                            user.Nama = dtr["Nama"].ToString();
                            user.TanggalLahir = dtr["Tanggal_Lahir"].ToString();
                            user.Alamat = dtr["Alamat"].ToString();
                            user.NoTelepon = dtr["No_Telepon"].ToString();
                            user.Email = dtr["Email"].ToString();
                            user.JenisKelamin = dtr["Jenis_Kelamin"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(user);
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