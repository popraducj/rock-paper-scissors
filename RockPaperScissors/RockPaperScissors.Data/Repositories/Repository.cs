using RockPaperScissors.DatabaseEntities;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using System.Linq;
using RockPaperScissors.Data.IRepositories;

namespace RockPaperScissors.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region initialization
        private IDatabaseContext _context;
        private IDbSet<T> _entities;

        public Repository(IDatabaseContext  context)
        {
            _context = context;
        }
        #endregion

        #region public methods

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                ValidateEntity(entity);
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ExceptionHandler(ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                ValidateEntity(entity);
                Entities.AddOrUpdate(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ExceptionHandler(ex);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                ValidateEntity(entity);
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ExceptionHandler(ex);
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }
        
        #endregion

        #region private methods

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        private Exception ExceptionHandler(DbEntityValidationException exception)
        {
            var msg = string.Empty;

            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += string.Format("Property: {0}, Error: {1}}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                }
            }

            return new Exception(msg, exception);
        }

        private void ValidateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is empty!!!");
            }
        }
      
        #endregion
    }
}
