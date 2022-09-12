using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Queries
{
    public interface IVehiclesQueries
    {
        public Task<List<Vehicles>> GetAll();
        public Task<Vehicles> GetById(int id);

    }
}
