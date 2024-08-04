using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface IShelfService
    {
        Task<ShelfModel> CreateShelf(ShelfVM shelfVM);
        Task<ShelfVM?> FindByShelfId(long id);


    }
}
