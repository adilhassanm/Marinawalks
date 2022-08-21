using AutoMapper;
using Marinawalks.api.Model.Domain;
using Marinawalks.api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Marinawalks.api.Controllers
{


    //Decorate the controller with [ApiController] and route(endpoint in url)   [Route("[controller]")]
    //-- this means controller name is Regions
    [ApiController]         //this decorator is a class for managing http  ,The [ApiController] attribute can be applied to a controller class to enable the following opinionated, API-specific behaviors:Automatic HTTP 400 responses etc
    [Route("[controller]")] //this is for managing endpoints
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //create constructor for dependency injection

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //return static list of regions after creating statc list

            //create a new list

            /*  var regions = new List<Region>()
              {
                  new Region
                  {Id = Guid.NewGuid(),
                  Code = "MRNR",
                  Name = "Marinawalkright",
                  Area = 227755,
                  Lat = -1.8822,
                  Long = 299.88,
                  Population = 500000

                  },

                  new Region
                  {Id = Guid.NewGuid(),
                  Code = "MRNL",
                  Name = "Marinawalklef",
                  Area = 227755,
                  Lat = -1.8822,
                  Long = 299.88,
                  Population = 500000

                  }


              };*/

            //above static data we can get the dynamic one from db using below statement

            var regions = await regionRepository.GetAllAsync();

            //Convert exposing domain methodology to DTO by below steps.

            //create dto list

            /*  HERE SINCE WE ARE USING AUTOMAPPER,WE WILL AVOID USING THIS

            var regionsDTO = new List<Model.DTO.Region>();

            //Using the domain data a DTO is created and exposed to outside world

            regions.ToList().ForEach(domainregion =>
            {
                var regionDTO = new Model.DTO.Region()
                {
                    Id = domainregion.Id,
                    Name = domainregion.Name,
                    Code = domainregion.Code,
                    Area = domainregion.Area,
                    Lat = domainregion.Lat,
                    Long = domainregion.Long,
                    Population = domainregion.Population,

                };
                regionsDTO.Add(regionDTO);
            });
            */
            var regionsDTO = mapper.Map<List<Model.DTO.Region>>(regions);//Here regions from domain model is mapped to DTO in one line of code
            return Ok(regionsDTO);
        }

/*
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<List<Model.DTO.Test>>(region);
            return Ok(regionDTO);
        }
*/
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionAsync2(Guid id)
        {
            var region = await regionRepository.GetAsync2(id);

            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<List<Model.DTO.TestJoin>>(region);
            return Ok(regionDTO);
        }
    }
}