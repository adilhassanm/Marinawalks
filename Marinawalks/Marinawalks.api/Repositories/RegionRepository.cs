using Marinawalks.api.Data;
using Marinawalks.api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marinawalks.api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly MariwalksDbContext mariwalksDbContext;

        public RegionRepository(MariwalksDbContext mariwalksDbContext)
        {
            this.mariwalksDbContext = mariwalksDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            //implementation
            //Talk to database and get info here
            //use private property got thru constructor inside method

            //make the below async,so use tolist activity async
            return await mariwalksDbContext.Regions.ToListAsync();

            //now inject interface and implementation into services
            //goto program.cs file and create one more builder

        }
    }
}
