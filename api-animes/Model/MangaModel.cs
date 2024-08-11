namespace api_animes.Model
{
    public class MangaModel
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public int QtdCapitulos { get; set; }
        public double Avaliacao { get; set; }
    }
}
