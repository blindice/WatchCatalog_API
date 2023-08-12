using AutoMapper;
using WatchCatalog_API.DTOs;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Profiles
{
    public class WatchProfile : Profile
    {
        public WatchProfile()
        {
            CreateMap<tbl_watch, WatchDTO>().ReverseMap();
            CreateMap<tbl_watch, WatchDetailsDTO>().ReverseMap();
            CreateMap<tbl_watch, CreateWatchDTO>().ReverseMap();
            CreateMap<tbl_watch, ToggleWatchDTO>().ReverseMap();
            CreateMap<tbl_watch, UpdateWatchDTO>();
            CreateMap<UpdateWatchDTO, tbl_watch>()
                .ForMember(dest => dest.Image, src => src.Ignore());
        }
    }
}
