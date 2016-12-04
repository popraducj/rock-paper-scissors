
using RockPaperScissors.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.DAL
{
    public class DabaseContext : DbContext, IDatabaseContext
    {
        public DabaseContext()
            : base("name=RockPaperScissors")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Standard> Standards { get; set; }
        //public virtual DbSet<Student> Students { get; set; }
        //public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        //public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
