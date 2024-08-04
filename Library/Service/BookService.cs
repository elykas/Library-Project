using Library.Data;
using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public class BookService: IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<BookModel> AddBook(BookVM bookVM) 
        {
            BookModel book = new() 
            { 
                Name = bookVM.Name,
                Height = bookVM.Height,
                Width = bookVM.Width,
                SetBookId = bookVM.SetBookId,
                
            };
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
