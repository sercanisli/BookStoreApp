using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract record CategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Category Name is a required field.")]
        [MinLength(2, ErrorMessage = "Category Name must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Category must consist of at maximum 50 characters")]
        public String? CategoryName { get; init; }
    }
}
