using Aluraflix.Data;
using Aluraflix.Data.Dtos;
using Aluraflix.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aluraflix.Services
{
    public class VideoService : IVideoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public VideoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadVideoDto> AdicionaVideo(CreateVideoDto videoDto)
        {
            Video video = _mapper.Map<Video>(videoDto);
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadVideoDto>(video);
        }

        public async Task<ReadVideoDto> RecuperaVideoPorId(int id)
        {
            Video video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);
            if (video != null)
            {
                return _mapper.Map<ReadVideoDto>(video);
                
            }
            return null;
        }

        public async Task<Result> AtualizaVideo(int id, UpdateVideoDto videoDto)
        {
            Video video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);
            if(video == null)
            {
                return Result.Fail("Video não encontrado.");
            }
            _mapper.Map(videoDto, video);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<List<ReadVideoDto>> RecuperaVideoPorTitulo(string nomeDoVideo)
        {
            List<Video> videos = await _context.Videos.ToListAsync();
            if (videos == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoVideo))
            {
                IEnumerable<Video> query = from video in videos
                                           where video.Titulo.Contains(nomeDoVideo)
                                           select video;

                videos = query.ToList();
                Console.WriteLine(videos);
            }
            return _mapper.Map<List<ReadVideoDto>>(videos);
        }

        public async Task<Result> DeletaVideo(int id)
        {
            Video video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);
            if (video == null)
            {
                return Result.Fail("Video não encontrado.");
            }
            _context.Remove(video);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
