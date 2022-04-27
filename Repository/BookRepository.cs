using BookMvc.Data;
using BookMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookMvc.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context=dbContext;
        }

        public async Task<Book> GetBook(Guid Id)
        {
           return await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id).ConfigureAwait(false);
        }
    
        
    }
}