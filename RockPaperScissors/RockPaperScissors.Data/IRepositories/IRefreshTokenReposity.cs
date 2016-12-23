using RockPaperScissors.DatabaseEntities;
using RockPaperScissors.DatabaseEntities.Entities;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.IRepositories
{
    public interface IRefreshTokenReposity<T> : IRepository<T> where T : RefreshToken
    {
        Task<bool> Add(T enyity);
        Task<bool> Remove(string id);
    }
}
