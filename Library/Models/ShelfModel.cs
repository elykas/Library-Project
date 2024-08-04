using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ShelfModel
    {
        public long Id { get; set; }

        [Required]
        public required float Height { get; set; }
        [Required]
        public required float Width { get; set; }
        public long LibraryId { get; set; }
        public LibraryModel Library { get; set; }
        public List<SetBookModel> SetBooks { get; set; } = [];
    }
}