using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class LibraryVM
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Genre { get; set; } = string.Empty;
    }
}
