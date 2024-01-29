using CursoBackend.DTOs;
using CursoBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;

        public BeerController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerId,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandId = b.BrandId
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return Ok(beerDto);
        }
    }
}
