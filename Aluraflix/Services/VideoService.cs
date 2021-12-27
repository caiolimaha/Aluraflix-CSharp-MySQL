using Aluraflix.Data;
using Aluraflix.Data.Dtos.Video;
using Aluraflix.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aluraflix.Services
{
    public class VideoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public VideoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadVideoDto> RecuperaVideos()
        {
            List<Video> videos = _context.Videos.ToList();
            if(videos == null) return null;
            return _mapper.Map<List<ReadVideoDto>>(videos);
        }
    }
}
