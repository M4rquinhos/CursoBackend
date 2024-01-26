using CursoBackend.DTOs;

namespace CursoBackend.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
