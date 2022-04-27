using BookMvc.Data;
using BookMvc.Entities;

namespace BookMvc.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
         private bool disposed=false;

         private readonly ApplicationDbContext _context;

         public IRepository<Book> _bookRepository;

         public IBookRepository BookRepository{get;}

       

        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository)
         {
             _context=context ?? throw new ArgumentNullException(nameof(context));
             BookRepository=bookRepository;
             
         }
         public void Dispose()
         {
             Dispose(true);
             GC.SuppressFinalize(this);

         }
         public int SaveChanges()
        {
            return _context.SaveChanges();

        }
        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed=true;
        }

        public async Task<int> SaveChangesAsync()
        {
          return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    
        
    }
}