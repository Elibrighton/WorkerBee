using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerBee.DAL
{
    public class WorkerBeeContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=workerbee.db");
    }
}
