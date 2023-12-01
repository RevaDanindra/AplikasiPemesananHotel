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
    public class HotelController
    {
        // deklarasi objek repository untuk menjalankan operasi CRUD
        private HotelRepository _repository;

        public int Create(Hotel hotel)
        {
            int result = 0;
            // cek HotelID yang diinputkan tidak boleh kosong
            if (hotel.HotelID == 0)
            {
                MessageBox.Show("HotelID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Kota yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(hotel.Kota))
            {
                MessageBox.Show("Kota harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Nama Hotel yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(hotel.NamaHotel))
            {
                MessageBox.Show("Nama Hotel harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek HotelID yang diinputkan tidak boleh kosong
            if (hotel.Rating == 0)
            {
                MessageBox.Show("Rating harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek UserID yang diinputkan tidak boleh kosong
            if (hotel.UserID == 0)
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new HotelRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(hotel);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Hotel berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Hotel gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(Hotel hotel)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new HotelRepository(context);
                result = _repository.Update(hotel);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Hotel berhasil diperbarui !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Hotel gagal diperbarui !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Delete(Hotel hotel)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new HotelRepository(context);
                result = _repository.Delete(hotel);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Hotel berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Hotel gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Hotel> ReadByNamaHotel(string NamaHotel)
        {
            // membuat objek collection
            List<Hotel> list = new List<Hotel>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new HotelRepository(context);
                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNamaHotel(NamaHotel);
            }
            return list;
        }

        public List<Hotel> ReadAll()
        {
            // membuat objek collection
            List<Hotel> list = new List<Hotel>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new HotelRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
