using RockPaperScissors.DatabaseEntities.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RockPaperScissors.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Key
            HasKey(t => t.ID);

            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.Password).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP).IsRequired();

            //table
            ToTable("Users");
        }
    }
}
