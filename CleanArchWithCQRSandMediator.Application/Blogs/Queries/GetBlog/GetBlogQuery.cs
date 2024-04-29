using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQuery : IRequest<List<BlogVM>>
    {
    }

    //OR

    /*public record GetBlogQuery : IRequest<List<BlogVM>>;*/
}
