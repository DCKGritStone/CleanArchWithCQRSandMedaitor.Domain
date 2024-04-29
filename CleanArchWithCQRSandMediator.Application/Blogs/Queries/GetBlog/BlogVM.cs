using CleanArchWithCQRSandMedaitor.Domain.Entity;
using CleanArchWithCQRSandMediator.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog
{
    public class BlogVM : IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
