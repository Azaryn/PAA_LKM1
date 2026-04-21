# 📖 README – PAA LKM 1
## 🤖 Deskripsi Proyek
Project ini adalah Web API Manajemen Data Murid yang dibangun untuk memenuhi tugas LKM 1 mata kuliah Pemrograman Antarmuka Aplikasi. 
Domain yang dipilih adalah Sistem Informasi Akademik. API ini memungkinkan pengelolaan data murid yang terintegrasi dengan sistem status melalui relasi database, serta menerapkan standar keamanan Parameterized Query.

## 🚀 Teknologi yang digunakan
* Bahasa Pemrograman: C#
* Framework : ASP.NET Core Web API
* Database : PostgreSQL
* Library & Packages : Npgsql dan Swashbuckle.AspNetCore

## ⚙️ Langkah Instalasi & Cara menjalankan
1. Clone Repositori:
'''git clone https://github.com/Azaryn/PAA_LKM1.git'''
2. Buka project: open folder menggunakan Visual Studio 2022.
3. Restore NuGet Packages: Klik kanan pada solution explorer dan pilih Restore NuGet Packages untuk mengunduh library Npgsql secara otomatis
4. Konfigurasi Koneksi: Buka file appsettings.json dan sesuaikan ConnectionString dengan kredensial PostgreSQL lokal: 
'''
"ConnectionStrings": {
  "WebApiDatabase": "Host=127.0.0.1; Port=5432; Database=NamaDB; Username=postgres; Password=isipassword;"
}
'''
5. Jalankan Aplikasi: Tekan F5 atau klik start untuk menjalankan aplikasi. akan otomatis terbuka di browsert melalui Swagger UI

## 🗄️ Cara Import Database
1. Buka pgAdmin
2. buat database baru dengan nama yang sesuai di appsettings.json
3. Buka Query Tool pada database
4. Salin query pada database.sql dan jalankan seluruh query. script ini mencakup pembuatan status, murid, dan status_murid hingga penyertaan sample data.
5. Script query ini tidak mencakup pembuatan skema users.

## 🛣️ Daftar Endpoint Lengkap
Seluruh respon balik API menggunakan format JSON yang konsisten dengan HTTP Status Code yang tepat.
### Dokumentasi API Murid

| Method | URL | Keterangan |
| :---: | :--- | :--- |
| **GET** | `/api/murid` | Menampilkan seluruh daftar murid beserta status jabatannya (JOIN). |
| **GET** | `/api/murid/{id}` | Mengambil data murid spesifik berdasarkan ID. Menangani error 404 apabila inputan tidak parameter tidak sesuai. |
| **POST** | `/api/murid` | Menambahkan data murid baru secara aman (Parameterized Query). |
| **PUT** | `/api/murid/{id}` | Memperbarui data murid dan memperbarui kolom `updated_at`. Menangani error 404 apabila inputan tidak parameter tidak sesuai|
| **DELETE** | `/api/murid/{id}` | Menghapus data murid secara permanen dari database. Menangani error 404 apabila inputan tidak parameter tidak sesuai|

## Link Video Demonstrasi
👉 https://youtu.be/GZFv-pst_G4?si=RqviHzc1bMJFRC-c

Dibuat oleh Rafi Hadianto Aribowo - 242410102006
