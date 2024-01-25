using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapstoneProject1.Models;

namespace CapstoneProject1.Data
{
    public class CapstoneProject1Context : DbContext
    {
        public CapstoneProject1Context (DbContextOptions<CapstoneProject1Context> options)
            : base(options)
        {
        }

        public DbSet<CapstoneProject1.Models.AdminInfocs> AdminInfocs { get; set; } = default!;

        public DbSet<CapstoneProject1.Models.BlogInfo>? BlogInfo { get; set; }

        public DbSet<CapstoneProject1.Models.EmpInfo>? EmpInfo { get; set; }
    }
}
