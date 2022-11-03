using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data.Models;

namespace WebServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Npc> NpcDb { get; set; }
        public DbSet<Script> ScriptDb { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Npc>()
                .HasIndex(n => n.NpcMajor).HasName("Index_Major");
        }
    }
}
