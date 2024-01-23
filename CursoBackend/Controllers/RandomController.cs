using CursoBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient
            )
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, double>> Get()
        {
            var result = new Dictionary<string, double>();

            result.Add("Singleton 1", _randomServiceSingleton.Value);
            result.Add("Scoped 1", -_randomServiceScoped.Value);
            result.Add("Transient 1", _randomServiceTransient.Value);

            return result;
        }
    }
}
