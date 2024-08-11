using api_animes.Model;
using api_animes.Repository;
using Microsoft.AspNetCore.Mvc;
using api_animes.Services;
using System.Xml.Linq;

namespace api_animes.Services
{
    public class MangaService
    {
        private MangaRepository _mangaRepository;

        public MangaService(MangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public IEnumerable<MangaModel> GetMangas()
        {
           return _mangaRepository.GetMangas();
        }

        public void Add(MangaModel manga)
        {
            _mangaRepository.Add(manga);
        }

        public MangaModel AtualizarPorID(MangaModel manga, Guid id)
        {
            return _mangaRepository.AtualizarPorID(manga, id);
        }

        public void DeletePorID(Guid id)
        {
            _mangaRepository.DeletarPorID(id);
        }

    }
}
