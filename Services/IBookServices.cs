using BookMvc.Models.RequestModel;
using BookMvc.Models.ResponseModel;

namespace BookMvc.Services
{
    public interface IBookServices
    {
        Task<BookResponseModel> AddBookAsync(BookRequestModel model);
        Task<IList<BookResponseModel>> GetBookAsync();
        Task<BookResponseModel> UpdateBookAsync(BookRequestModel model, Guid BookId);
        Task DeleteBookAsync(Guid BookId);
        Task<BookResponseModel> GetBook(Guid bookId);
    }
}