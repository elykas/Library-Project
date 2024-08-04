using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class BookVM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Height { get; set; }
        public float Width { get; set; }
        public long SetBookId { get; set; }
    }
}
