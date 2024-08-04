using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface ISetBookService
    {
        Task<SetBookModel> CreateSetBook(SetBookVM model, long id);
        float TotalShelf(ShelfModel shelf, SetBookModel set);
        float TotalSet(SetBookModel set);
        float HeightSet(SetBookModel set);
        bool CanAddBook(ShelfModel shelf, SetBookModel set);

    }
}
