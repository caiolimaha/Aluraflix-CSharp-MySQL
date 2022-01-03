using Aluraflix.Data;
using Aluraflix.Data.Dtos;
using Aluraflix.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ReadCategoriaDto AdicionaCategoria(CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Add(categoria);
            _context.SaveChanges();
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }

        public ReadCategoriaDto RecuperaCategoriaPorId(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if(categoria != null)
            {
                return _mapper.Map<ReadCategoriaDto>(categoria);
            }
            return null;
        }

        public List<ReadCategoriaDto> RecuperaCategorias()
        {
            List<Categoria> categorias = _context.Categorias.ToList();
            if(categorias != null)
            {
                return _mapper.Map<List<ReadCategoriaDto>>(categorias);
            }
            return null;
        }

        public Result AtualizaCategoria(int id, CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return Result.Fail("Categoria não foi encontrada");
            }
            _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if(categoria == null)
            {
                return Result.Fail("Categoria não foi encontrada");
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
