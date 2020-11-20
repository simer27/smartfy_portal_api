using AutoMapper;
using smartfy.portal_api.domain.Entities;

namespace smartfy.portal_api.services.WebAPI.Mappings
{
    public class DtOToEntityProfile : Profile
    {
        public DtOToEntityProfile()
        {
            CreateMap<Partner, PartnerDto>().ReverseMap();
        }
    }
}