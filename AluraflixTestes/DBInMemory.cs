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
                //TODO
            }
        }
    }
}
