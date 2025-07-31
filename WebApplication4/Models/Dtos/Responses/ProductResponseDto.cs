namespace WebApplication4.Models.Dtos.Responses
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name  { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}