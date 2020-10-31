using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinToolKit.Model;

namespace XamarinToolKit
{
    public class ToolkitContext : DbContext
    {
        private readonly string databasepath;

        public ToolkitContext(string databasepath)
        {
            this.databasepath = databasepath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"FileName={databasepath}");
        }

        public DbSet<ToolkitMaster> ToolkitMasters { get; set; }

        public DbSet<ToolkitDetail> ToolkitDetails { get; set; }
    }
}
