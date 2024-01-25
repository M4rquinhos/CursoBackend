using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine($"Conexion a base de datos");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail termiando");

            Console.WriteLine("Todo termino");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Conexion a base de datos");
                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail termiando");
                return 2;
            });

            task1.Start();
            task2.Start();

            Console.WriteLine("Hago otra cosa");

            var resultado1 = await task1;
            var resultado2 = await task2;

            Console.WriteLine("Todo ha terminado");

            stopwatch.Stop();

            return Ok(resultado1 + " " + resultado2 + " " + stopwatch.Elapsed);
        }
    }
}
