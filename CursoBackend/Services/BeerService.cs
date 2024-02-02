using AutoMapper;
using CursoBackend.DTOs;
using CursoBackend.Models;
using CursoBackend.Repository;
using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRespository;
        private IMapper _mapper;
        public List<string> Errors { get; }

        public BeerService(IRepository<Beer> beerRespository,
            IMapper mapper)
        {
            _beerRespository = beerRespository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRespository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b));
        }   

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRespository.Add(beer);
            await _beerRespository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer);
                
                _beerRespository.Update(beer);
                await _beerRespository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRespository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);

                _beerRespository.Delete(beer);
                await _beerRespository.Save();

                return beerDto;
            }

            return null;
        }

        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if (_beerRespository.Search(b => b.Name == beerInsertDto.Name).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }

        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRespository.Search(b => b.Name == beerUpdateDto.Name
            && beerUpdateDto.Id != b.BeerId).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }
    }
}
