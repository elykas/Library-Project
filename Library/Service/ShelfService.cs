using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class ShelfService : IShelfService

    {

        private readonly ApplicationDbContext _context;

        public ShelfService(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<ShelfModel> CreateShelf(ShelfVM shelfVM)
        {
            ShelfModel shelfModel = new()
            {
                Height = shelfVM.Height,
                Width = shelfVM.Width,
                LibraryId = shelfVM.LibraryId
            };
            await _context.Shelf.AddAsync(shelfModel);
            _context.SaveChanges();
            return shelfModel;
        }

        public async Task<ShelfVM?> FindByShelfId(long id)
        {
            ShelfModel? shelf = await _context.Shelf.FindAsync(id);
            if (shelf == null) { return null; }

            ShelfVM shelfVM = new()
            {

                Id = id,
                Width = shelf.Width,
                Height = shelf.Height,
                LibraryId = shelf.LibraryId
            };
            return shelfVM;
        }


    }
}
