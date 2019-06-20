﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Entity
{
    public class Bank
    {
        [Key]
        public string Id { get; set; }
        public string AdminId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
