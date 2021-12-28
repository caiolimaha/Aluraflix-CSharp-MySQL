using Aluraflix.Data;
using Aluraflix.Data.Dtos.Video;
using Aluraflix.Models;
using AutoMapper;
using FluentResults;
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

        public ReadVideoDto AdicionaVideo(CreateVideoDto videoDto)
        {
            Video video = _mapper.Map<Video>(videoDto);
            _context.Videos.Add(video);
            _context.SaveChanges();
            return _mapper.Map<ReadVideoDto>(video);
        }

        public ReadVideoDto RecuperaVideoPorId(int id)
        {
            Video video = _context.Videos.FirstOrDefault(v => v.Id == id);
            if (video != null)
            {
                return _mapper.Map<ReadVideoDto>(video);
                
            }
            return null;

        }

        public Result AtualizaVideo(int id, UpdateVideoDto videoDto)
        {
            Video video = _context.Videos.FirstOrDefault(v => v.Id == id);
            if(video == null)
            {
                return Result.Fail("Video não encontrado.");
            }
            _mapper.Map(videoDto, video);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
