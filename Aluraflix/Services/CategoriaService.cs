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
    public class CategoriaService
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadCategoriaDto> AdicionaCategoria(CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }

        public async Task<ReadCategoriaDto> RecuperaCategoriaPorId(int id)
        {
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id);
            if(categoria != null)
            {
                return _mapper.Map<ReadCategoriaDto>(categoria);
            }
            return null;
        }

        public async Task<List<ReadCategoriaDto>> RecuperaCategorias()
        {
            List<Categoria> categorias = await _context.Categorias.ToListAsync();
            if(categorias != null)
            {
                return _mapper.Map<List<ReadCategoriaDto>>(categorias);
            }
            return null;
        }

        public async Task<Result> AtualizaCategoria(int id, CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return Result.Fail("Categoria não foi encontrada");
            }
            _mapper.Map(categoriaDto, categoria);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<Result> DeletaCategoria(int id)
        {
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id);
            if(categoria == null)
            {
                return Result.Fail("Categoria não foi encontrada");
            }
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<List<ReadVideoDto>> RecuperaVideoPorCategoria(int id)
        {
            List<Video> videos = await _context.Videos.ToListAsync();
            if (videos == null)
            {
                return null;
            }

            IEnumerable<Video> query = from video in videos 
                                       where video.CategoriaId == id 
                                       select video;

            videos = query.ToList();
            return _mapper.Map<List<ReadVideoDto>>(videos);
        }
    }
}
