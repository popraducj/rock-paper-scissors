using RockPaperScissors.Data.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using RockPaperScissors.DatabaseEntities.Entities;
using System.Data.Entity;


namespace RockPaperScissors.Data.Repositories
{
    public class RefreshTokenReposity<T> : Repository<T>, IRefreshTokenReposity<T> where T : RefreshToken
    {
        #region initialization
        private IDatabaseContext _context;

        public RefreshTokenReposity(IDatabaseContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        public async Task<bool> Add(T enyity)
        {
            var existingItem = Entities.Where(r => r.Subject.Equals(enyity.Subject) && r.ClientId.Equals(enyity.ClientId)).FirstOrDefault();
            if (existingItem != null)
            {
                await Delete(existingItem);
            }

            return await Insert(enyity);

        }
        public async Task<bool> Remove(string id)
        {
            var entity = Entities.Find(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

    }
}
