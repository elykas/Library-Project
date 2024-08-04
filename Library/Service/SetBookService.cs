using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class SetBookService : ISetBookService
    {

        private readonly ApplicationDbContext _context;


        public SetBookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SetBookModel> CreateSetBook(SetBookVM model, long id)
        {
            ShelfModel shelfModel = _context.Shelf.Find(id);    
            if (shelfModel == null) { return null;}

            SetBookModel setBookModel = new()
            {
                Name = model.Name,
                ShelfId = model.ShelfId,
            };
            if (!CanAddBook(shelfModel,setBookModel))
            {
                throw new Exception ("error"); 
            }
            await _context.SetBooks.AddAsync(setBookModel);
            _context.SaveChanges();
            return setBookModel ;
            }

            public float TotalShelf(ShelfModel shelf, SetBookModel set)
            {

                var totalShelfLength = shelf.SetBooks
                    .Aggregate((float)0, (start, nextSet) => start + TotalSet(set));

                return shelf.Width - totalShelfLength;

            }


        public float TotalSet(SetBookModel set)
        {
            var totalSetLength = set.Books
               .Aggregate((float)0, (start, nextbook) => start + nextbook.Width);
            return totalSetLength;
        }

        public float HeightSet(SetBookModel set)
        {
            if(set.Books == null)
            {
                throw new Exception ("error");
            }
            var height = set.Books.FirstOrDefault().Height;
            return height;
        }
        public bool CanAddBook(ShelfModel shelf, SetBookModel set)
        {
            var setTotal = TotalSet(set);
            var spare = TotalShelf(shelf, set);
            var heightSet = HeightSet(set);


            if(spare < setTotal && shelf.Height < heightSet) 
            {
                
                throw new Exception("Look for another shelf ");
            }
            if(heightSet < 0.10) {  }
            return true;
        }


       





    }
}
