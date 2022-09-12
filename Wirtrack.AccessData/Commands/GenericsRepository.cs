
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wirtrack.Domain.Command;

namespace Wirtrack.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly WirtrackContext _context;
        public GenericsRepository(WirtrackContext wirtrackContext)
        {
            _context = wirtrackContext;
        }

        public async Task<bool> Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
