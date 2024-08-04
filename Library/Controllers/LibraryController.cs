using Microsoft.AspNetCore.Mvc;
using Library.Service;
using Microsoft.AspNetCore.Identity;
using Library.ViewModel;


namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _libraryService.GetAllLibraries());
        }

        public IActionResult Create() 
        {
            return View(new LibraryVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibraryVM libraryVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            await _libraryService.CreateLibrary(libraryVM);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(long id) 
        {
            var library = await _libraryService.Details(id);
            if(library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _libraryService.Deletelibrary(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id) 
        {
            var libraryVM = await _libraryService.GetById(id);
           
            if (libraryVM == null) { return NotFound(); }
            
            return View(libraryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LibraryVM libraryVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var library = await _libraryService.EditLibrary(libraryVM);
           
            if (library == null) { return NotFound(); }
            
            return RedirectToAction("Index");
        }


        



    }
    }

