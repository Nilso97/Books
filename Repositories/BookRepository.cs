using Books.Infra.Data.Persistence;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            var newBook = _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            _context.Remove(book);

            await _context.SaveChangesAsync();
        }

        public async Task<Book> Get(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.Entry(book).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}