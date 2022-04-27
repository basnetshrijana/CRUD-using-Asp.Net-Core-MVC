using BookMvc.Entities;

namespace BookMvc.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBook(Guid Id);
    
         
    }
}