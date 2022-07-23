using AutoMapper;

namespace Marinawalks.api.Profiles
{
    public class RegionProfile:Profile
    {

        public RegionProfile()
        {
            //create here maps for models using createmap,that takes source and destination
            //here we want to convert a domain model to a dto
            CreateMap<Model.Domain.Region, Model.DTO.Region>();
            CreateMap<Model.Domain.Test, Model.DTO.Test>();

            //here automapper is smart enough to map the source domain and destination dto one to one

            //if name is different,then below is the way by which we tell automapper

            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.RegionId));

            //there is also reverse automapper

            //inorder to tell that we used automapper,we need to inject this profiles






        }
    }
}
