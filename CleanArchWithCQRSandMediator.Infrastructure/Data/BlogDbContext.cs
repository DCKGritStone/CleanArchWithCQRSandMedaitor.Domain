using CleanArchWithCQRSandMedaitor.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext( DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
