using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People(){Id = 1, Name = "Marco", Birthdate = new DateTime(1999, 09, 30)},
            new People(){Id = 2, Name = "David", Birthdate = new DateTime(1999, 07, 11)},
            new People(){Id = 3, Name = "Lolo", Birthdate = new DateTime(1999, 05, 30)},
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
