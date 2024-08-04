using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface IBookService
    {
       Task<BookModel> AddBook(BookVM bookVM);
    }
}
