namespace BookMvc.Entities
{
    public class Book
    {
         public Guid BookId{get;set;}
         public string BookTitle{get;set;}=string.Empty;
         public string AuthorName{get;set;}=string.Empty;
         public decimal BookPrice{get;set;}
    }
}