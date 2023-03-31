using Books.Models;
using Books.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> ListAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            var book = await _bookRepository.Get(id);

            if (book != null) return book;

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);

            return CreatedAtAction(nameof(ListAllBooks), new { id = newBook.BookId }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBook(Guid id)
        {
            var book = await _bookRepository.Get(id);

            if (book != null) 
            {
                await _bookRepository.Delete(book.BookId);

                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookDetails(Guid id, [FromBody] Book book)
        {
            if (id == book.BookId)
            {
                await _bookRepository.Update(book);

                return NoContent();
            }

            return BadRequest();
        }
    }
}