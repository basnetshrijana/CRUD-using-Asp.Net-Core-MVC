namespace BookMvc.Models.ResponseModel
{
    public class BookResponseModel
    {
         public Guid BookId{get;set;}

        public string AuthorName{get;set;}=string.Empty;

        public string BookTitle{get;set;}=string.Empty;
        
        public decimal BookPrice{get;set;}
    }
}