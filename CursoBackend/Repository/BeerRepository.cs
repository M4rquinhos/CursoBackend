﻿using CursoBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;

        public BeerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> Get() 
            => await _context.Beers.ToListAsync();

        public async Task<Beer> GetById(int id) 
            => await _context.Beers.FindAsync(id);


        public async Task Add(Beer beer)
            => await _context.Beers.AddAsync(beer);

        public void Update(Beer beer)
        {
            _context.Beers.Attach(beer);
            _context.Beers.Entry(beer).State = EntityState.Modified;
        }

        public void Delete(Beer beer)
        {
            _context.Beers.Remove(beer);
        }

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Beer> Search(Func<Beer, bool> filter)
            => _context.Beers.Where(filter).ToList();
    }
}
