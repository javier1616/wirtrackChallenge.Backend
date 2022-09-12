
using System.Threading.Tasks;

namespace Wirtrack.Domain.Command
{
    public interface IGenericsRepository
    {
        Task<bool> Add<T>(T entity) where T : class;
        Task<bool> Update<T>(T entity) where T : class;
        Task<bool> Remove<T>(T entity) where T : class;
    }
}
