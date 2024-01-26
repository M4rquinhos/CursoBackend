using CursoBackend.DTOs;
using System.Text.Json;

namespace CursoBackend.Services
{
    public class PostService : IPostService
    {
        private HttpClient _httppclient;

        public PostService(HttpClient httpClient)
        {
            _httppclient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            var result = await _httppclient.GetAsync(_httppclient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);

            return post;
        }
    }
}
