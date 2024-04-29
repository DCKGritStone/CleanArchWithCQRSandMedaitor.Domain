using AutoMapper;
using CleanArchWithCQRSandMedaitor.Domain.Entity;
using CleanArchWithCQRSandMedaitor.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlogEntity= new Blog 
            { Id = request.Id,
            Name=request.Name,
            Description=request.Description,
            Author=request.Author
            };

            return await _blogRepository.UpdateAsync(request.Id, updateBlogEntity);
        }
    }
}
