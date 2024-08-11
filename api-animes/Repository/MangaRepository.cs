using api_animes.Model;
using api_animes.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_animes.Repository
{
    public class MangaRepository
    {
        private List<MangaModel> _mangas = new List<MangaModel>();

        public MangaRepository()
        {
            _mangas.Add(new MangaModel { Id = Guid.NewGuid(), Titulo = "Naruto", QtdCapitulos = 820, Avaliacao = 8.5 });
            _mangas.Add(new MangaModel { Id = Guid.NewGuid(), Titulo = "Attack on Titan", QtdCapitulos = 65, Avaliacao = 9.2 });
            _mangas.Add(new MangaModel { Id = Guid.NewGuid(), Titulo = "Boku no Hero", QtdCapitulos = 100, Avaliacao = 8.8 });
            _mangas.Add(new MangaModel { Id = Guid.NewGuid(), Titulo = "Demon Slayer", QtdCapitulos = 46, Avaliacao = 9.5 });
        }

        public IEnumerable<MangaModel> GetMangas()
        {
            return _mangas;
        }

        public void Add(MangaModel manga)
        {
            _mangas.Add(manga);
        }

        public MangaModel AtualizarPorID(MangaModel manga, Guid id)
        {
            var mangaAtt = _mangas.FirstOrDefault(m => m.Id == id);
            if (mangaAtt == null)
            {
                return mangaAtt;
            }

            mangaAtt.Titulo = manga.Titulo;
            mangaAtt.Avaliacao = manga.Avaliacao;
            mangaAtt.QtdCapitulos = manga.QtdCapitulos;

            return mangaAtt;
        }

        public void DeletarPorID(Guid id)
        {
            var mangaDelete = _mangas.FirstOrDefault(m => m.Id == id);

            if (mangaDelete == null)
            {
                new Exception("Manga não encontrado");
            }
            _mangas.Remove(mangaDelete);
        }

    }
}
