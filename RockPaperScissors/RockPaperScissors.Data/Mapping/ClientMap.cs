using RockPaperScissors.DatabaseEntities.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RockPaperScissors.Data.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            HasKey(t => t.ID);

            Property(t => t.Secret).IsRequired();
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Property(t => t.ApplicationType).IsRequired();
            Property(t => t.Active).IsRequired();
            Property(t => t.RefreshTokenLifeTime).IsRequired();
            Property(t => t.AllowedOrigin).IsRequired();

            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();

            //table
            ToTable("Clients");
        }
    }
}
