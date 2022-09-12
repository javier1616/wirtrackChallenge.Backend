using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtrack.Domain.Entities;

namespace Wirtrack.Domain.Queries
{
    public interface ICitiesQueries
    {
        public Task<List<Cities>> GetAll();
        public Task<Cities> GetById(int id);

    }
}
