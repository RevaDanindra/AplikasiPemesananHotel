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
    public class UserController
    {
        // deklarasi objek repository untuk menjalankan operasi CRUD
        private UserRepository _repository;

        public int Create(User user)
        {
            int result = 0;
            // cek UserID yang diinputkan tidak boleh kosong
            if (user.UserID == 0)
            {
                MessageBox.Show("UserID harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek Nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.TanggalLahir))
            {
                MessageBox.Show("Tanggal Lahir harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek UserID yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.JenisKelamin))
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek UserID yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek UserID yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.NoTelepon))
            {
                MessageBox.Show("Nomor Telepon harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek UserID yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(user.Email))
            {
                MessageBox.Show("Email harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new UserRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(user);
            }
            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal disimpan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(User user)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                result = _repository.Update(user);
            }
            if (result > 0)
            {
                MessageBox.Show("Data User berhasil diperbarui !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data User gagal diperbarui !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Delete(User user)
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                result = _repository.Delete(user);
            }
            if (result > 0)
            {
                MessageBox.Show("Data User berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data User gagal dihapus !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public List<User> ReadByNama(string Nama)
        {
            // membuat objek collection
            List<User> list = new List<User>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new UserRepository(context);
                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(Nama);
            }
            return list;
        }

        public List<User> ReadAll()
        {
            // membuat objek collection
            List<User> list = new List<User>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new UserRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
