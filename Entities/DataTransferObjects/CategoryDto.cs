namespace Entities.DataTransferObjects
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }
        public String? CategoryName { get; init; }
    }
}
