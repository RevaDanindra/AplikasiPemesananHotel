using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace AplikasiPemesananHotel.Model.Context
{
    // Kelas DbContext bertanggung jawab untuk mengelola koneksi ke database SQLite.
    public class DbContext : IDisposable
    {
        // Private field untuk menyimpan objek koneksi SQLite.
        private SQLiteConnection _conn;

        // Properti Conn digunakan untuk mendapatkan koneksi database. Jika belum ada koneksi, maka akan membuat koneksi baru.
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        // Metode GetOpenConnection digunakan untuk mendapatkan koneksi baru yang terbuka.
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                // Nama database harus ditentukan. Harap isi nama database sesuai kebutuhan.
                string dbName = @"";

                // Membentuk string koneksi menggunakan nama database.
                string connectionString = string.Format("Data Source={0};FailIfMissing=True", dbName);

                // Membuat objek SQLiteConnection dan membukanya.
                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                // Menangani kesalahan jika terjadi kesalahan saat membuka koneksi.
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }

        // Metode Dispose untuk membersihkan dan menutup koneksi database saat objek tidak lagi dibutuhkan.
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    // Menutup koneksi hanya jika koneksi belum ditutup.
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    // Membebaskan sumber daya koneksi.
                    _conn.Dispose();
                }
            }
            // Mengabaikan pemanggilan finalizer untuk objek ini.
            GC.SuppressFinalize(this);
        }
    }
}