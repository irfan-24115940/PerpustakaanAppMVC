using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using PerpustakaanAppMVC.Model.Context;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Repository;

namespace PerpustakaanAppMVC.Controller
{
    public class MahasiswaController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private MahasiswaRepository _repository;

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Mahasiswa> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();

            /*
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }
            */
            var repo = new MahasiswaRestApiRepository();
            list = repo.ReadByName(nama);

            return list;
        }

        /// <summary>
        /// Method untuk menampilkan semua data mahasiswa
        /// </summary>
        /// <returns></returns>
        public List<Mahasiswa> ReadAll()
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();

            /*
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);

                // panggil method ReadAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            */
            var repo = new MahasiswaRestApiRepository();
            list = repo.ReadAll();

            return list;
        }

        public int Create(Mahasiswa mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                throw new ArgumentException("Nama harus diisi !!!");
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                throw new ArgumentException("Angkatan harus diisi !!!");
            }

            /*
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new MahasiswaRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(mhs);
            }
            */

            var repo = new MahasiswaRestApiRepository();
            result = repo.Create(mhs);

            if(result > 0)
            {
                // jika berhasil tambah data, tampilkan pesan sukses
                Console.WriteLine("Data mahasiswa berhasil disimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // jika gagal tambah data, tampilkan pesan gagal
                Console.WriteLine("Gagal menyimpan data mahasiswa !!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result;
        }

        public int Update(Mahasiswa mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                throw new ArgumentException("Nama harus diisi !!!");
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                throw new ArgumentException("Angkatan harus diisi !!!");
            }

            /*
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(mhs);
            }
            */
            var repo = new MahasiswaRestApiRepository();
            result = repo.Update(mhs);

            if (result > 0)
            {
                MessageBox.Show("Data Mahasiswa Berhasil Diupdate !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Data Mahasiswa Gagal Diupdate !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public int Delete(Mahasiswa mhs)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            /*
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(mhs);
            }
            */
            var repo = new MahasiswaRestApiRepository();
            result = repo.Delete(mhs);

            if (result > 0)
            {
                // jika berhasil tambah data, tampilkan pesan sukses
                Console.WriteLine("Data mahasiswa berhasil dihapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // jika gagal tambah data, tampilkan pesan gagal
                Console.WriteLine("Gagal menghapus data mahasiswa !!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }
    }
}
