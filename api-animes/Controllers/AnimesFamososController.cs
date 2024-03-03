using api_animes.Model;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace api_animes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimesFamososController : ControllerBase
    {
        private static readonly List<Anime> Animes = new List<Anime>
        {
            new Anime { Id = 1, Title = "Naruto", EpisodeCount = 820, Rating = 8.5 },
            new Anime { Id = 2, Title = "One Piece", EpisodeCount = 1000, Rating = 9.9 },
            new Anime { Id = 3, Title = "Attack on Titan", EpisodeCount = 65, Rating = 9.2 },
            new Anime { Id = 4, Title = "Boku no Hero", EpisodeCount = 100, Rating = 8.8 },
            new Anime { Id = 5, Title = "Demon Slayer", EpisodeCount = 46, Rating = 9.5 }
        };

        [HttpGet("GetListAnimes")]
        public IEnumerable<Anime> GetAnimes()
        {
            return Animes;
        }

    }
}