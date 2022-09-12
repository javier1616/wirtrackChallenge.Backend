using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Queries
{
    public interface ITripsQueries
    {
        public Task<List<Trips>> GetAll();
        public Task<List<TripsJoinedDTO>> GetAllJoin();
        public Task<Trips> GetById(int id);   

    }
}
