using Data.Entities;
using Data.Entities.TenantUser;
using Data.Infrastrutures.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Contexts
{
    public sealed class TenantDbContext : IdentityDbContext<TenantUser>
    {

        private readonly Tenant _currentTenant;

        public TenantDbContext(Tenant currentTenant)
        {
            _currentTenant = currentTenant;

            Database.EnsureCreated();
        }

        public TenantDbContext(DbContextOptions<TenantDbContext> options)
           : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.TenantConfiguration();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_currentTenant != null)
            {
                optionsBuilder.UseSqlServer(_currentTenant.GetConnectionString());
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
