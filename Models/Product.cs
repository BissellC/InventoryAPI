using System;

namespace InventoryAPI.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime TimeOrdered { get; set; }
  }
}