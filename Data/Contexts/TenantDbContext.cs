using Data.Entities;
using Data.Entities.Customer;
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

        public TenantDbContext(DbContextOptions<TenantDbContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ctrString = DbContextFactory.ConnectionStrings;
            if (ctrString != null)
            {
                string connStr = ctrString.ElementAt(0).Value;
                optionsBuilder.UseSqlServer(connStr);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
