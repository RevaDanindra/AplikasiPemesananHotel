using AplikasiPemesananHotel.Model.Repository;
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
    public class KamarController
    {
        // deklarasi objek repository untuk menjalankan operasi CRUD
        private KamarRepository _repository;

        public int Create(Kamar kamar)
        {
            int result = 0;
            // cek KamarID yang diinputkan tidak boleh kosong
            if (kamar.KamarID == 0)
            {
                MessageBox.Show("KamarID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Tipe Kamar yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kamar.TipeKamar))
            {
                MessageBox.Show("Tipe Kamar harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Tipe Tempat Tidur yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kamar.TipeTempatTidur))
            {
                MessageBox.Show("Tipe Tempat Tidur harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Kapasitas yang diinputkan tidak boleh kosong
            if (kamar.Kapasitas == 0)
            {
                MessageBox.Show("Kapasitas harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek Harga per Hari yang diinputkan tidak boleh kosong
            if (kamar.HargaHari == 0)
            {
                MessageBox.Show("Harga per Hari harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek HotelID yang diinputkan tidak boleh kosong
            if (kamar.HotelID == 0)
            {
                MessageBox.Show("HotelID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new KamarRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(kamar);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Kamar berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Kamar gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(Kamar kamar)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new KamarRepository(context);
                result = _repository.Update(kamar);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Kamar berhasil diperbarui !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Kamar gagal diperbarui !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Delete(Kamar kamar)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new KamarRepository(context);
                result = _repository.Delete(kamar);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Kamar berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Kamar gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<Kamar> ReadByTipeKamar(string TipeKamar)
        {
            // membuat objek collection
            List<Kamar> list = new List<Kamar>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new KamarRepository(context);
                // panggil method GetByTipeKamar yang ada di dalam class repository
                list = _repository.ReadByTipeKamar(TipeKamar);
            }
            return list;
        }

        public List<Kamar> ReadAll()
        {
            // membuat objek collection
            List<Kamar> list = new List<Kamar>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new KamarRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
