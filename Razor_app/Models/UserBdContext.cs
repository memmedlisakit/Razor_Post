using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_app.Models
{
    public class UserBdContext : DbContext
    {
        public UserBdContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
