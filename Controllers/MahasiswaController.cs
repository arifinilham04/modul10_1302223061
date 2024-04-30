using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_1302223061.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {
        private static List<MahasiswaModel> arrMahasiswa = new List<MahasiswaModel>
        {
            new MahasiswaModel { Nama = "M Arifin Ilham", Nim = "1302223061", Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023 },
            new MahasiswaModel { Nama = "Zabrina Virgie", Nim = "1302223055",Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023 },
            new MahasiswaModel { Nama = "Nasya Kirana Marendra", Nim = "1302223148",Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023 },
            new MahasiswaModel {  Nama = "Dara Sheiba M.C", Nim = "1302223075 ",Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023 },
            new MahasiswaModel {  Nama = "M Tsaqif Zayyan", Nim = "1302220141",Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023  },
            new MahasiswaModel {  Nama = "Rafie Aydin Ihsan", Nim = "1302220065",Course = new List<string>{"PBO","KPL","ALPRO"}, Year = 2023 }
        };

        [HttpGet]
        public IEnumerable<MahasiswaModel> Get()
        {
            return arrMahasiswa;
        }

        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            return arrMahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MahasiswaModel mahasiswa)
        {
            arrMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = arrMahasiswa.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            arrMahasiswa.RemoveAt(id);
            return NoContent();
        }
    }

    public class MahasiswaModel
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
        public List<string> Course { get; set; }
        public int Year {  get; set; } 
    }
}