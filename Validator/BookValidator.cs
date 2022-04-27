using BookMvc.Models.RequestModel;
using FluentValidation;

namespace BookMvc.Validator
{
    public class BookValidator : AbstractValidator<BookRequestModel>
    {
        public BookValidator()
        {
            RuleFor(x => x.AuthorName).NotNull().NotEmpty().WithMessage("Required author name");
            RuleFor(x => x.BookPrice).NotNull().GreaterThan(10).WithMessage("Required book price");
            RuleFor(x => x.BookTitle).NotNull().NotEmpty().WithMessage("Required book title");
        }
    
        
    }
}