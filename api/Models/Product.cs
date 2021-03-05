namespace api.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set;}
        public int Sku { get; private set; }
        public double Price { get; private set;}
    }
}