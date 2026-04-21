using Npgsql;
using LKM1.Model;
using LKM1.Helpers;
using LKM1.Models;

namespace LKM1.Model
{
    public class MuridContext
    {
        private string _kon;
        private string _PesanError;
        public MuridContext(string kon)
        {
            _kon = kon;
        }
        public List<Murid> ListMurid()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT m.id_murid, m.nama, m.kelas, m.absen, s.nama_status, m.created_at, m.updated_at
                                            FROM users.murid m
                                            LEFT JOIN users.status_murid sm ON m.id_murid = sm.id_murid
                                            LEFT JOIN users.status s ON sm.id_status = s.id_status;");
            SqlDBHelper db = new SqlDBHelper(this._kon);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        kelas = reader["kelas"].ToString(),
                        absen = int.Parse(reader["absen"].ToString()),
                        namaStatus = reader["nama_status"].ToString(),
                        createAt = DateTime.Parse(reader["created_at"].ToString()),
                        updateAt = DateTime.Parse(reader["updated_at"].ToString())
                    });
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                _PesanError = ex.Message;
            }
            return list1;
        }
        public bool AddMurid(Murid murid)
        {
            bool isBerhasil = false;
            string query = @"INSERT INTO users.murid (nama, kelas, absen) VALUES (@nama, @kelas, @absen)";
            SqlDBHelper db = new SqlDBHelper(this._kon);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@nama", murid.nama);
                cmd.Parameters.AddWithValue("@kelas", murid.kelas);
                cmd.Parameters.AddWithValue("@absen", murid.absen);

                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0) isBerhasil = true;

                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                _PesanError = ex.Message;
            }
            return isBerhasil;
        }
        public bool DelMurid(int id)
        {
            bool isBerhasil = false;
            string query = @"DELETE FROM users.murid WHERE id_murid = @id";
            SqlDBHelper db = new SqlDBHelper(this._kon);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    isBerhasil = true;
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                _PesanError = ex.Message;
            }
            return isBerhasil;
        }
        public bool UpdMurid(Murid murid)
        {
            bool isBerhasil = false;
            string query = @"UPDATE users.murid SET nama = @nama, kelas = @kelas, absen = @absen, updated_at = CURRENT_TIMESTAMP WHERE id_murid = @id";
            SqlDBHelper db = new SqlDBHelper(this._kon);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@nama", murid.nama);
                cmd.Parameters.AddWithValue("@kelas", murid.kelas);
                cmd.Parameters.AddWithValue("@absen", murid.absen);
                cmd.Parameters.AddWithValue("@id", murid.id_murid);

                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0) isBerhasil = true;

                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                _PesanError = ex.Message;
            }
            return isBerhasil;
        }
        public Murid GetMuridById(int id)
        {
            Murid murid = null;
            string query = @"SELECT m.id_murid, m.nama, m.kelas, m.absen, s.nama_status, m.created_at, m.updated_at
                     FROM users.murid m
                     LEFT JOIN users.status_murid sm ON m.id_murid = sm.id_murid
                     LEFT JOIN users.status s ON sm.id_status = s.id_status
                     WHERE m.id_murid = @id";

            SqlDBHelper db = new SqlDBHelper(this._kon);
            try
            {
                NpgsqlCommand cmd = db.getNpgsqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    murid = new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        kelas = reader["kelas"].ToString(),
                        absen = int.Parse(reader["absen"].ToString()),
                        namaStatus = reader["nama_status"].ToString(),
                        createAt = DateTime.Parse(reader["created_at"].ToString()),
                        updateAt = DateTime.Parse(reader["updated_at"].ToString())
                    };
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return murid;
        }
    }
}
