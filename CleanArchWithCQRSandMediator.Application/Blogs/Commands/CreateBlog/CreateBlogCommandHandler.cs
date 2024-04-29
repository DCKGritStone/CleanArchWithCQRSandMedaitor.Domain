using AutoMapper;
using CleanArchWithCQRSandMedaitor.Domain.Entity;
using CleanArchWithCQRSandMedaitor.Domain.Repository;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };
            var result = await _blogRepository.CreateAsync(blogEntity);

            return _mapper.Map<BlogVM>(result);
        }
    }
}
