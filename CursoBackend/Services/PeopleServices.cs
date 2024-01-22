using CursoBackend.Controllers;

namespace CursoBackend.Services
{
    public class PeopleServices : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return false;
            }
            return true;
        }
    }
}
