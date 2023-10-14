namespace Books_Shop.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DateOfCreate { get; set; }

        public decimal Price { get; set; }
    }
}
