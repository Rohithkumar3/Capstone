﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject1.Models
{
    [Table("EmpInfo")]
    public class EmpInfo
    {
        [Key]
        public int EmpInfoId { get; set; }

        public string? EmailId { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int PassCode { get; set; }
    }
}
