using CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchWithCQRSandMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blogs = await Mediator.Send(new GetBlogByIdQuery(){BlogId=id});

            if (blogs == null)
            {
                return NotFound();
            }
            return Ok(blogs);
        }
        [HttpPost]
        public async Task <IActionResult> Create( CreateBlogCommand command)
        {
            var createBlog= await Mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createBlog.Id }, createBlog);
        }
        [HttpPut("{Id}")]
        public async Task <IActionResult> Update( int id ,UpdateBlogCommand command)
        {
            if (id == command.Id) { return BadRequest(); }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task <IActionResult> Delete ( int id)
        {
            var result = await Mediator.Send(new DeleteBlogCommand { Id = id});

            return NoContent();

        }
    }
}
