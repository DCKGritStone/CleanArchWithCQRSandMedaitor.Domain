using AutoMapper;
using CleanArchWithCQRSandMedaitor.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQueryHandler: IRequestHandler < GetBlogQuery , List<BlogVM>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository ,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<List<BlogVM>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            /*var blogList = blogs.Select(x => new BlogVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Author = x.Author
            }).ToList();*/
            var blogList = _mapper.Map<List<BlogVM>>(blogs);

            return blogList;
        }
    }
}
