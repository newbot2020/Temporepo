using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using one2many.Models;

namespace one2many.Data
{
    public class one2manyContext : DbContext
    {
        public one2manyContext (DbContextOptions<one2manyContext> options)
            : base(options)
        {
        }

        public DbSet<one2many.Models.Student> Student { get; set; }

        public DbSet<one2many.Models.Result> Result { get; set; }

        public DbSet<one2many.Models.Classinfo> Classinfo { get; set; }

        public DbSet<one2many.Models.Studentaction> Studentaction { get; set; }

       
    }
}
