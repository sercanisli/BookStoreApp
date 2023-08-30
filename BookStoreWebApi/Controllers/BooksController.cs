using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.EntityFrameworkCore;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _context.Books.Where(b => b.Id == id).SingleOrDefault();
            try
            {
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        public IActionResult CreareOneBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest(); //400
                }
                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                var entity = _context.Books.Where(b => b.Id == id).SingleOrDefault();
                if (entity == null)
                {
                    return NotFound();
                }
                //id check
                if (id != book.Id)
                {
                    return BadRequest();
                }
                entity.Title = book.Title;
                entity.Price = book.Price;
                _context.SaveChanges();
                return StatusCode(200, book);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.Books.Where(b => b.Id == id).SingleOrDefault();
                if (entity == null)
                {
                    return NotFound(new
                    {
                        message = $"Book with id:{id} could not found",
                        statusCode = 404
                    });
                }
                _context.Books.Remove(entity);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPatch(" {id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                var entitiy = _context.Books.Where(b => b.Id == id).SingleOrDefault();
                if (entitiy == null)
                {
                    return NotFound();
                }
                bookPatch.ApplyTo(entitiy);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
