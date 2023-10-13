using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("api/books")]
    public class BooksV2Controllers :ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksV2Controllers(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);
            var booksv2 = books.Select(b => new
            {
                Title = b.Title,
                Id = b.Id
            });
            return Ok(booksv2);
        }
    }
}
