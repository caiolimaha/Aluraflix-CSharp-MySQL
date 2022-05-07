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
                categoria.Id = 1;
                categoria.Titulo = "CategoriaTeste";
                categoria.Cor = "FFFF00";

                Categoria categoria2 = new Categoria();
                categoria2.Id = 2;
                categoria2.Titulo = "CategoriaTeste2";
                categoria2.Cor = "FFFFFF";

                _context.Categorias.Add(categoria);
                _context.Categorias.Add(categoria2);

                Video video = new Video();
                video.Id = 1;
                video.Titulo = "VideoTeste";
                video.Descricao = "DescriçãoVideoTeste";
                video.CategoriaId = 1;

                Video video2 = new Video();
                video2.Id = 2;
                video2.Titulo = "VideoTeste2";
                video2.Descricao = "DescriçãoVideoTeste2";
                video2.CategoriaId = 2;

               
                _context.Videos.Add(video);
                _context.Videos.Add(video2);

                _context.SaveChanges();
            }
        }

        public AppDbContext GetContext() => _context;
    }
}
