using Microsoft.AspNet.Identity.EntityFramework;
using RockPaperScissors.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>, IDatabaseContext
    {
        public DatabaseContext()
            : base("name=RockPaperScissorsConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typeRegister = Assembly.GetExecutingAssembly().GetTypes().
                Where(type => !String.IsNullOrEmpty(type.Namespace)).
                Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typeRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
