using System.Runtime.InteropServices;

namespace WebShopApp.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public string Country { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}