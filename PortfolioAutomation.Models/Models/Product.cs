namespace PortfolioAutomation.Models.Models;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public Product(string name, string description, decimal price, string imageUrl, string id = null)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Id = id;
    }
}
