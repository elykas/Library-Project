using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class SetBookModel
    {
        public long Id { get; set; }
        [Required, StringLength(100)]
        public required string Name { get; set; }
         public long ShelfId { get; set; }

        public ShelfModel? ShelfModel { get; set; }
        public List<BookModel> Books { get; set; } = [];

       
    }
}