using AutoMapper;
using CleanArchWithCQRSandMedaitor.Domain.Repository;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById
{
    class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVM>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository , IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVM> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIdAsync(request.BlogId);
            return _mapper.Map<BlogVM>(blog);
        }
    }
}
