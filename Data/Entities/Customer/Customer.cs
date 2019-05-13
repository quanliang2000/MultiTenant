using Data.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities.Customer
{
    public class Customer : EntityBase
    {

        [Required]
        public string Message { get; set; }
    }
}
