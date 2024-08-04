using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfService;

        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateShelf(long id)
        {
            ViewBag.LibraryId = id;
            return View(new ShelfVM() { LibraryId = id});
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateShelf(ShelfVM shelfVM)
        {
            await _shelfService.CreateShelf(shelfVM);
            return RedirectToAction("Details", "Library", new{id = shelfVM.LibraryId});
        }
    }
}
