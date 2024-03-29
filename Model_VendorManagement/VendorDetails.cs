﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_VendorManagement
{
    public class VendorDetails
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? VendorName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get;set ;}
        [Required]
        public string? City { get;set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? TelePhone1 { get; set; }
        public string? TelePhone2 { get; set;}
        [Required]
        public string? VendorEmail { get; set;}
     
        public string? VendorWebsite { get;set; }
    }
}
