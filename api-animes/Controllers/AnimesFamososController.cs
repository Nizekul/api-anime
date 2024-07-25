using api_animes.Model;
using api_animes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace api_animes.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AnimesFamososController : ControllerBase
    {
        readonly List<AnimeModel> Animes = new List<AnimeModel>
        {
            new AnimeModel { Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>(), Title = "Naruto", EpisodeCount = 820, Rating = 8.5 },
            new AnimeModel { Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>(), Title = "One Piece", EpisodeCount = 1000, Rating = 9.9 },
            new AnimeModel { Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>(), Title = "Attack on Titan", EpisodeCount = 65, Rating = 9.2 },
            new AnimeModel { Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>(), Title = "Boku no Hero", EpisodeCount = 100, Rating = 8.8 },
            new AnimeModel { Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>(), Title = "Demon Slayer", EpisodeCount = 46, Rating = 9.5 }
        };

        [HttpGet]
        public IEnumerable<AnimeModel> GetAnimes()
        {
            return Animes;
        }

        [HttpPost]
        public IActionResult AddAnime([FromBody] AnimeModel anime)
        {
            if (anime == null)
            {
                return BadRequest("Anime objeto é nulo");
            }

            anime.Id = IdGeradorService.Instancia.PegarProxId<AnimeModel>();

            Animes.Add(anime);
            return CreatedAtAction(nameof(GetAnimes), new { id = anime.Id }, anime);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnime(int id)
        {
            var animeDelete = Animes.FirstOrDefault(a => a.Id == id);

            if (animeDelete == null)
            {
                return NotFound("Anime não encontrado");
            }

            Animes.Remove(animeDelete);

            return NoContent();
        }

    }
}