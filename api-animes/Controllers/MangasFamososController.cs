using api_animes.Model;
using api_animes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace api_animes.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MangasFamososController : ControllerBase
    {
        private readonly IdGuidGeradorService _idGuidGeradorService;
        private MangaService _mangaService;

        public MangasFamososController(IdGuidGeradorService idGuidGeradorService, MangaService mangaService)
        {
            _idGuidGeradorService = idGuidGeradorService;
            _mangaService = mangaService;
        }

        [HttpGet]
        public IEnumerable<MangaModel> GetMangas()
        {
            return _mangaService.GetMangas();
        }

        [HttpPost]
        public IActionResult AddManga([FromBody] MangaModel manga)
        {
            manga.Id = _idGuidGeradorService.Id;

            _mangaService.Add(manga);
            return CreatedAtAction(nameof(GetMangas), manga);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarManga(Guid id, [FromBody] MangaModel manga)
        {
            if (manga == null)
            {
                return BadRequest("Manga objeto é nulo");
            }

            var mangaAtt = _mangaService.AtualizarPorID(manga, id);

            if (mangaAtt == null)
            {
                return NotFound("Manga não encontrado");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManga(Guid id)
        {
            var mangaDelete = GetMangas().FirstOrDefault(m => m.Id == id);
            try
            {
                _mangaService.DeletePorID(id);
                return NoContent();
            }
            catch
            {
                return NotFound("Manga não encontrado!");
            }
        }
    }
}