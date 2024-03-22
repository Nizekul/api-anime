using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using api_animes.Model;
using Microsoft.AspNetCore.Mvc.Testing;

namespace api_animes.Tests
{
    public class AnimesFamososControllerTests : IClassFixture<WebApplicationFactory<Controllers.AnimesFamososController>>
    {
        private readonly WebApplicationFactory<api_animes.Controllers.AnimesFamososController> _factory;

        public AnimesFamososControllerTests(WebApplicationFactory<Controllers.AnimesFamososController> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task AddAnime_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            var newAnime = new Anime { Title = "Test Anime", EpisodeCount = 12, Rating = 7.5 };

            // Convertendo o objeto Anime para JSON
            var jsonContent = JsonSerializer.Serialize(newAnime);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/AnimesFamosos/AddAnime", content);

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se o código de status da resposta é 2xx
            Assert.Equal(HttpStatusCode.Created, response.StatusCode); // Verifica se a resposta é 201 Created
        }
    }
}