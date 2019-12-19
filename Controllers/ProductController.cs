using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using System.Linq;

namespace InventoryAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : Controller
  {

    [HttpGet]
    public ActionResult GetAllProducts()
    {
      var db = new DatabaseContext();
      return Ok(db.Products.OrderBy(product => product.Id));
    }

    [HttpGet("{id}")]
    public ActionResult GetOneProduct(int id)
    {
      var db = new DatabaseContext();
      var product = db.Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(product);
      }
    }

    [HttpPost]
    public ActionResult AddProduct(Product product)
    {
      var db = new DatabaseContext();
      db.Products.Add(product);
      db.SaveChanges();
      return Ok(product);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(Product product)
    {
      var db = new DatabaseContext();
      var prevProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
      if (prevProduct == null)
      {
        return NotFound();
      }
      else
      {
        prevProduct.SKU = product.SKU;
        prevProduct.Name = product.Name;
        prevProduct.Description = product.Description;
        prevProduct.NumberInStock = product.NumberInStock;
        prevProduct.Price = product.Price;
        db.SaveChanges();
        return Ok(prevProduct);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
      var db = new DatabaseContext();
      var product = db.Products.FirstOrDefault(p => p.Id == id);
      if (product == null)
      {
        return NotFound();
      }
      else
      {
        db.Products.Remove(product);
        db.SaveChanges();
        return Ok("Product Deleted");
      }
    }

    [HttpGet("OutOfStock")]
    public ActionResult OutOfStock()
    {
      var db = new DatabaseContext();
      return Ok(db.Products.Where(p => p.NumberInStock == 0));
    }

    [HttpGet("SKU/{SKU}")]
    public ActionResult GetProductBySKU(string SKU)
    {
      var db = new DatabaseContext();
      var product = db.Products.FirstOrDefault(p => p.SKU == SKU);
      if (product == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(product);
      }

    }





  }
}