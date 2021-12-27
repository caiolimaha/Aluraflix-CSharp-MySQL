﻿using Aluraflix.Models;
using Microsoft.EntityFrameworkCore;

namespace Aluraflix.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }

    }


}
