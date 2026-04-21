using System.Text.Json.Serialization;

namespace LKM1.Models
{
    public class Murid
    {
        public int id_murid { get; set; }
        public string nama { get; set; }
        public string kelas { get; set; }
        public int absen { get; set; }
        [JsonIgnore]
        public string namaStatus { get; set; }
        [JsonIgnore]
        public DateTime createAt { get; set; }
        [JsonIgnore]
        public DateTime updateAt { get; set; }
    }
}
