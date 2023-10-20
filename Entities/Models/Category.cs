namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
