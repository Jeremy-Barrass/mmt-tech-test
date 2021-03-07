using api.Enums;

namespace api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Category { get; set; }
        public int Sku { get; set; }
        public double Price { get; set;}
    }
}