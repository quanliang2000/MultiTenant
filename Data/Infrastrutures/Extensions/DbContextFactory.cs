using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastrutures.Extensions
{
    public static class DbContextFactory
    {
        public static Dictionary<string, string> ConnectionStrings { get; set; }

        public static void SetConnectionString(Dictionary<string, string> connStrs)
        {
            ConnectionStrings = connStrs;
        }

        public static TenantDbContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
                optionsBuilder.UseSqlServer(connStr);

                return new TenantDbContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionId");
            }
        }
    }
}
