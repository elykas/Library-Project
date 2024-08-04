using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetAllLibraries();

        Task<LibraryModel> CreateLibrary(LibraryVM libraryVM);

        Task<LibraryModel?> Details(long id);
        Task Deletelibrary(long id);

        Task<LibraryVM?> GetById(long id);
        Task<LibraryModel?> EditLibrary(LibraryVM libraryVM);
    }
}
