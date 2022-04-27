using BookMvc.Entities;
using BookMvc.Models.RequestModel;
using BookMvc.Models.ResponseModel;
using BookMvc.Repository;

namespace BookMvc.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookServices(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public async Task<BookResponseModel> AddBookAsync(BookRequestModel model)
        {
            try
            {
                var book = new Book
                {
                    BookId = Guid.NewGuid(),
                    BookPrice = model.BookPrice,
                    BookTitle = model.BookTitle,
                    AuthorName = model.AuthorName
                };
               await _unitOfWork.BookRepository.InsertAsync(book).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                return new BookResponseModel
                {
                    BookId = book.BookId,
                    BookPrice = book.BookPrice,
                    BookTitle = book.BookTitle,
                    AuthorName = book.AuthorName
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                // TODO
            }
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            try
            {
                var data = await _unitOfWork.BookRepository.GetBook(bookId);
                if (data != null)
                {
                    _unitOfWork.BookRepository.Delete(data);
                    await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // TODO
            }
        }

        public async Task<BookResponseModel> GetBook(Guid bookId)
        {
            var book = await _unitOfWork.BookRepository.GetBook(bookId).ConfigureAwait(false);
            if (book == null)
            {
                throw new Exception("Book Not found");
            }

            return new BookResponseModel
            {
                BookId = book.BookId,
                AuthorName = book.AuthorName,
                BookPrice = book.BookPrice,
                BookTitle = book.BookTitle
            };
        }

        public async Task<IList<BookResponseModel>> GetBookAsync()
        {
            var books = await _unitOfWork.BookRepository.GetAllAsync().ConfigureAwait(false);
            var response = books
                .Select(
                    x =>
                        new BookResponseModel
                        {
                            BookId = x.BookId,
                            BookPrice = x.BookPrice,
                            BookTitle = x.BookTitle,
                            AuthorName = x.AuthorName
                        }
                )
                .ToList();
            return response;
        }

        public async Task<BookResponseModel> UpdateBookAsync(BookRequestModel model, Guid BookId)
        {
            try
            {
                var book = await _unitOfWork.BookRepository.GetBook(BookId).ConfigureAwait(false);

                if (book == null)
                {
                    throw new Exception("Book not found");
                }

                book.AuthorName = model.AuthorName;
                book.BookPrice = model.BookPrice;
                book.BookTitle = model.BookTitle;

                _unitOfWork.BookRepository.Update(book);
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                return new BookResponseModel
                {
                    BookId = book.BookId,
                    AuthorName = book.AuthorName,
                    BookPrice = book.BookPrice,
                    BookTitle = book.BookTitle
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
        
    }
}