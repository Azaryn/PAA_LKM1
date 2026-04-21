using Microsoft.AspNetCore.Mvc;
using LKM1.Model;
using LKM1.Models;

namespace LKM1.Controllers
{
    public class MuridController : Controller
    {
        private string _kon;
        public MuridController(IConfiguration configuration)
        {
            _kon = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/murid")]
        public IActionResult ListMurid()
        {
            MuridContext konteks = new MuridContext(this._kon);
            List<Murid> ListMurid = konteks.ListMurid();
            return Ok(ListMurid);
        }
        [HttpGet("api/murid/{id}")]
        public IActionResult GetMuridById(int id)
        {
            MuridContext konteks = new MuridContext(this._kon);
            var murid = konteks.GetMuridById(id);

            if (murid == null)
            {
                return NotFound(new { message = $"Data murid dengan ID {id} tidak ditemukan." });
            }
            return Ok(murid);
        }
        [HttpPost("api/murid")]
        public IActionResult PostMurid([FromBody] Murid m)
        {
            MuridContext konteks = new MuridContext(this._kon);
            bool berhasil = konteks.AddMurid(m);
            if (!berhasil)
            {
                return BadRequest(new { message = "Gagal menambahkan data murid. Periksa kembali inputan Anda." });
            }
            return Ok(new { message = "Data Murid Berhasil Ditambahkan!" });
        }
        [HttpDelete("api/murid/{id}")]
        public IActionResult DeleteMurid(int id)
        {
            MuridContext konteks = new MuridContext(this._kon);
            bool berhasil = konteks.DelMurid(id);
            if (!berhasil)
            {
                return NotFound(new { message = $"Gagal menghapus! Data murid dengan ID {id} tidak ditemukan." });
            }
            return Ok(new { message = "Data Murid Berhasil Dihapus!" });
        }
        [HttpPut("api/murid/{id}")]
        public IActionResult PutMurid(int id, [FromBody] Murid m)
        {
            MuridContext konteks = new MuridContext(this._kon);
            m.id_murid = id;
            bool berhasil = konteks.UpdMurid(m);

            if (!berhasil)
            {
                return NotFound(new { message = $"Gagal memperbarui! Data murid dengan ID {id} tidak ditemukan." });
            }
            return Ok(new { message = "Data Murid Berhasil Diperbarui!" });
        }
    }
}