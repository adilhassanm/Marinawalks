using Marinawalks.api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marinawalks.api.Data
{
    public class MariwalksDbContext:DbContext
    {
        //create a constructor,use shorthand ctor tab
        //pass dbcontext options thru constructor to pass to baseclass
        public MariwalksDbContext(DbContextOptions<MariwalksDbContext> options):base(options)
        {

        }
        //This property is actually table creation in db

        //with help of below line as dbset,we can now use Marinawalksdbcontext to query or process data to regions table
        public DbSet<Region> Regions { get; set; }

        //the above lines means,if such table does not exist create a table and this is the connection and property with which you can talk to regions table
        //similar for others also
        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
