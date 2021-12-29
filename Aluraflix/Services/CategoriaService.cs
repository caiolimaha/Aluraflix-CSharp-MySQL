using Aluraflix.Data;
using Aluraflix.Data.Dtos.Categoria;
using Aluraflix.Models;
using AutoMapper;
using System;
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
    }
}
