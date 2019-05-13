using Data.Entities;
using Data.Entities.TenantUser;
using Data.Infrastrutures.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantUser> TenantUser { get; set; }
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
