using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;
using Wirtrack.Domain.Queries;
namespace Wirtrack.AccessData.Queries
{
    public class VehiclesQueries : IVehiclesQueries
    {

        private readonly WirtrackContext _context;

        public VehiclesQueries(WirtrackContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicles>> GetAll()
        {

            var vehicles = await _context.Set<Vehicles>().ToListAsync();

            return vehicles;
        }

        public async Task<Vehicles> GetById(int vehicleId)
        {

            var vehicle = await _context.Set<Vehicles>().Where(t => t.Id == vehicleId).FirstOrDefaultAsync();

            return vehicle;

        }

    }
}