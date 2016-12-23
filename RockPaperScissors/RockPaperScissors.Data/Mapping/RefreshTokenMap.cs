using RockPaperScissors.DatabaseEntities.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RockPaperScissors.Data.Mapping
{
    public class RefreshTokenMap : EntityTypeConfiguration<RefreshToken>
    {
        public RefreshTokenMap()
        {
            HasKey(t => t.ID);

            Property(t => t.Subject).IsRequired().HasMaxLength(50);
            Property(t => t.ClientId).IsRequired().HasMaxLength(50);
            Property(t => t.ProtectedTicket).IsRequired();

            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();

            //table
            ToTable("RefreshTokens");
        }
    }
}
