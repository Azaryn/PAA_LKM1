using Npgsql;
using System.Data;

namespace LKM1.Helpers
{
    public class SqlDBHelper
    {
        private NpgsqlConnection koneksi;
        private string _kon;
        public SqlDBHelper(string kon)
        {
            _kon = kon;
            koneksi = new NpgsqlConnection();
            koneksi.ConnectionString = _kon;
        }
        public NpgsqlCommand getNpgsqlCommand(string query)
        {
            koneksi.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = koneksi;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public void closeConnection()
        {
            koneksi.Close();
        }
    }
}
