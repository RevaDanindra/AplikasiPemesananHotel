using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikasiPemesananHotel.Model.Entity;
using AplikasiPemesananHotel.Model.Repository;
using AplikasiPemesananHotel.Model.Context;

namespace AplikasiPemesananHotel.Controller
{
    public class BookingController
    {
        // deklarasi objek repository untuk menjalankan operasi CRUD
        private BookingRepository _repository;

        public int Create(Booking booking)
        {
            int result = 0;
            // cek BookingID yang diinputkan tidak boleh kosong
            if (booking.BookingID == 0)
            {
                MessageBox.Show("BookingID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek UserID yang diinputkan tidak boleh kosong
            if (booking.UserID == 0)
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek KamarID yang diinputkan tidak boleh kosong
            if (booking.KamarID == 0)
            {
                MessageBox.Show("KamarID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek CheckIn yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(booking.CheckIn))
            {
                MessageBox.Show("CheckIn harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek CheckOut yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(booking.CheckOut))
            {
                MessageBox.Show("CheckOut harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek Total yang diinputkan tidak boleh kosong
            if (booking.Total == 0)
            {
                MessageBox.Show("Total harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new BookingRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(booking);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Booking berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Booking gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(Booking booking)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new BookingRepository(context);
                result = _repository.Update(booking);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Booking berhasil diperbarui !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Booking gagal diperbarui !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Delete(Booking booking)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new BookingRepository(context);
                result = _repository.Delete(booking);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Booking berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Booking gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Booking> ReadByBookingID(string BookingID)
        {
            // membuat objek collection
            List<Booking> list = new List<Booking>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BookingRepository(context);
                // panggil method GetByTipeKamar yang ada di dalam class repository
                list = _repository.ReadByBookingID(BookingID);
            }
            return list;
        }

        public List<Booking> ReadAll()
        {
            // membuat objek collection
            List<Booking> list = new List<Booking>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BookingRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
