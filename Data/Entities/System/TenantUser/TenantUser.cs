using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities.TenantUser
{
    public class TenantUser : IdentityUser
    {

        [Required]
        public string TenantId { get; set; }

        [Required]
        public int Status { get; set; } //1=> All Good, 2=> Blocked

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

    }
}
