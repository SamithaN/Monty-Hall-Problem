using Microsoft.EntityFrameworkCore;
using MontyHall_be.models;
using System.Collections.Generic;

namespace MontyHall_be.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
