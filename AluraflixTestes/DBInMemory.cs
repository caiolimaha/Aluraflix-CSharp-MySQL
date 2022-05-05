using Aluraflix.Data;
using Aluraflix.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraflixTestes
{
    public class DBInMemory
    {
        private AppDbContext _context;
        public DBInMemory()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase("DbFake")
           .Options;

            _context = new AppDbContext(options);

            InsertFakeData();

        }

        private void InsertFakeData()
        {
            if (_context.Database.EnsureCreated())
            {
                Categoria categoria = new Categoria();
                categoria.Titulo = "CategoriaTeste";
                categoria.Cor = "FFFF00";

                Video video = new Video();
                video.Titulo = "VideoTeste";
                video.Descricao = "DescriçãoVideoTeste";
                video.CategoriaId = 20;

                Video video2 = new Video();
                video.Titulo = "VideoTeste2";
                video.Descricao = "DescriçãoVideoTeste2";
                video.CategoriaId = 20;

                _context.Categorias.Add(categoria);
                _context.Videos.Add(video);
                _context.Videos.Add(video2);
                _context.SaveChanges();
            }
        }

        public AppDbContext GetContext() => _context;
    }
}
