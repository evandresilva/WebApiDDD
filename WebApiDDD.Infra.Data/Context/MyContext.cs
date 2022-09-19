using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDDD.Domain.Entities;
using WebApiDDD.Infra.Data.Mapping;

namespace WebApiDDD.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(new UserMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
