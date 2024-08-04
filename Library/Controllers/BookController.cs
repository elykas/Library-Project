using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IShelfService _shelfService;

        public BookController(IBookService bookService, IShelfService shelfService)
        {
            _bookService = bookService;
            _shelfService = shelfService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook(long id)
        {
            ViewBag.SetId = id;
            return View(new BookVM() { SetBookId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookVM bookVM)
        {
            //var res = _shelfService.FindByShelfId(BookVM.ShelfId);
            //if (res == null) { return null; }
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            await _bookService.AddBook(bookVM);
            return RedirectToAction("Details", "Library");
        }

    }
}
