using Library.Service;
using Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class SetBookController : Controller
    {
        private readonly ISetBookService _setBookService;
        private readonly IShelfService _shelfService;

        public SetBookController(ISetBookService setBookService, IShelfService shelfService)
        {
            _setBookService = setBookService;
            _shelfService = shelfService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateSetBook(long id)
        {
            ViewBag.ShelfId = id;
            return View(new SetBookVM() { ShelfId = id });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSetBook(SetBookVM setBookVM,long id)
        {
            try
            {
                var res = _shelfService.FindByShelfId(setBookVM.ShelfId);
                if (res == null) { return null; }

                await _setBookService.CreateSetBook(setBookVM, id);
                return RedirectToAction("Details", "Library", new { id = res.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View();
            }


        }

    }
}
