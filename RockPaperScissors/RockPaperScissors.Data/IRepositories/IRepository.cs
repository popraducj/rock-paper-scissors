using RockPaperScissors.DatabaseEntities;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        IQueryable<T> Table { get; }
    }
}

