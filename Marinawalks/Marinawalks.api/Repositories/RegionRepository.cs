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

        public  async Task<IEnumerable<Test>> GetAsync(Guid id)
        {
            //return await mariwalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //return await mariwalksDbContext.Regions.Where(x => x.Id == id).Select(x => new { x.Id, x.Area })
           var region = await mariwalksDbContext.Regions.Select(x => new Test() { Id =x.Id, Lat = x.Lat, Long = x.Long }).Where(x => x.Id == id).ToListAsync();
            return region;
        }

        public async Task<IEnumerable<TestJoin>> GetAsync2(Guid id)
        {
            //return await mariwalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //return await mariwalksDbContext.Regions.Where(x => x.Id == id).Select(x => new { x.Id, x.Area })
            var region = await mariwalksDbContext.Regions.Join(mariwalksDbContext.Walks, e => e.Id, d => d.RegionId, (reg, walk) => new TestJoin() {
                Id = reg.Id,
                Lat = reg.Lat,
                Long = reg.Long,
                Name = walk.Name



            }).Where(x => x.Id == id).ToListAsync();



            //Select(x => new Test() { Id = x.Id, Lat = x.Lat, Long = x.Long }).Where(x => x.Id == id).ToListAsync();
            return region;
        }
    }
}
