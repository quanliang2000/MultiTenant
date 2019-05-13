using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastrutures.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder TenantConfiguration(this ModelBuilder builder)
        {

            return builder;
        }
    }
}
