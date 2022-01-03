using Aluraflix.Data.Dtos;
using Aluraflix.Models;
using AutoMapper;


namespace Aluraflix.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<Video, ReadVideoDto>();
            CreateMap<UpdateVideoDto, Video>();
        }
    }
}
