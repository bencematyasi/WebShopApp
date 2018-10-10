namespace WebShopApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }
        
        public int Size { get; set; }
        
        public string Image { get; set; }

    }
}