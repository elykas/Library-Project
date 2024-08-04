using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookModel
    {
        public long Id { get; set; }
        
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public float Height { get; set; }
        [Required]
        public float Width { get; set; }

        public SetBookModel? SetBookModel { get; set; }

        public long SetBookId {  get; set; }


    }
}