using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class LibraryService: ILibraryService
    {
        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LibraryModel> CreateLibrary(LibraryVM libraryVM)
        {
            LibraryModel library = new() { Genre = libraryVM.Genre };
            await _context.Library.AddAsync(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<List<LibraryModel>> GetAllLibraries()
        {
            return await _context.Library.ToListAsync();
        }


        public async Task<LibraryModel?> Details(long id)
        {
            return await _context.Library
                .Include(s => s.Shelfs)
                .ThenInclude(s => s.SetBooks)
                .ThenInclude(s => s.Books)
                .FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task Deletelibrary(long id)
        {
            LibraryModel? toDelete = await _context.Library.FindAsync(id);
            if (toDelete != null)
            {
                _context.Library.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<LibraryVM?> GetById(long id)
        {
            LibraryModel? library = await _context.Library.FindAsync(id);
            if (library == null) { return null; }

            LibraryVM libraryVM = new() { Id = id, Genre = library.Genre };
            return libraryVM;
        }



        public async Task<LibraryModel?> EditLibrary(LibraryVM libraryVM)
        {
            LibraryModel? model = await _context.Library.FindAsync(libraryVM.Id);
            if (model != null)
            {
                model.Genre = libraryVM.Genre;
                await _context.SaveChangesAsync();
                return model;
            }
            return null;
        }

        
    }
}
