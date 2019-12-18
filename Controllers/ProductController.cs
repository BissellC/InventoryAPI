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



  }
}