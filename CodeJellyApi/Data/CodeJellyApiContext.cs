using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeJellyApi.Models;

namespace CodeJellyApi.Models
{
    public class CodeJellyApiContext : DbContext
    {
        public CodeJellyApiContext (DbContextOptions<CodeJellyApiContext> options)
            : base(options)
        {
        }

        public DbSet<CodeJellyApi.Models.Customer> Customer { get; set; }

        public DbSet<CodeJellyApi.Models.Policy> Policy { get; set; }
    }
}
