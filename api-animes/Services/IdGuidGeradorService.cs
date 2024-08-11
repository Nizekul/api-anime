namespace api_animes.Services
{
    public class IdGuidGeradorService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
