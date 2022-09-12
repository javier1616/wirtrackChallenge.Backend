using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;
using Wirtrack.Domain.Queries;
namespace Wirtrack.AccessData.Queries
{
    public class CitiesQueries : ICitiesQueries
    {

        private readonly WirtrackContext _context;

        public CitiesQueries(WirtrackContext context)
        {
            _context = context;
        }

        public async Task<List<Cities>> GetAll()
        {

            var cities = await _context.Set<Cities>().ToListAsync();

            return cities;
        }

        public async Task<Cities> GetById(int cityId)
        {

            var city = await _context.Set<Cities>().Where(t => t.Id == cityId).FirstOrDefaultAsync();

            return city;

        }

    }
}