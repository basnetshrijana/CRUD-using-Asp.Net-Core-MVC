namespace BookMvc.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
        
        IBookRepository BookRepository { get; }
    
    
    
         
    }
}