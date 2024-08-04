using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class SetBookVM
    {
        public long Id { get; set; }
        public  string Name { get; set; }
        public long ShelfId { get; set; }
    }
}
