using CursoBackend.DTOs;
using CursoBackend.Models;
using CursoBackend.Repository;
using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRespository;

        public BeerService(IRepository<Beer> beerRespository)
        {
            _beerRespository = beerRespository;
        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRespository.Get();

            return beers.Select(b => new BeerDto()
            {
                Id = b.BeerId,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandId = b.BrandId
            });
        }   

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId
                };
                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandId,
                Alcohol = beerInsertDto.Alcohol
            };

            await _beerRespository.Add(beer);
            await _beerRespository.Save();

            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                beer.Name = beerUpdateDto.Name;
                beer.Alcohol = beerUpdateDto.Alcohol;
                beer.BrandId = beerUpdateDto.BrandId;
                
                _beerRespository.Update(beer);
                await _beerRespository.Save();

                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId
                };

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId
                };

                _beerRespository.Delete(beer);
                await _beerRespository.Save();

                return beerDto;
            }

            return null;
        }

    }
}
