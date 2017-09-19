using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerDAL.Entities;

namespace VideoManagerDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                        .UseInMemoryDatabase("TheDB")
                        .Options;

        //
        public InMemoryContext() : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
    }
}
