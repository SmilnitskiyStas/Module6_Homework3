using Books_Shop.Entities;
using Books_Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productProvider;

        public HomeController(IProductService productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult AllProduct()
        {
            var products = _productProvider.GetAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct() => View();

        [HttpPost]
        public IActionResult CreateProduct(Product product, string price)
        {
            decimal convertPrice = Convert.ToDecimal(price.Replace(".", ","));

            product.Price = convertPrice;

            _productProvider.Create(product);

            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {

            var product = _productProvider.GetById(id);

            ViewBag.ProductId = product.Id;
            ViewBag.ProductTitle = product.Title;
            ViewBag.ProductAuthor = product.Author;
            ViewBag.ProductDateOfCreate = product.DateOfCreate;
            ViewBag.ProductPrice = product.Price;

            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, string price)
        {
            decimal convertPrice = Convert.ToDecimal(price.Replace(".", ","));

            product.Price = convertPrice;

            _productProvider.Update(product);

            return View();
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            _productProvider.DeleteById(id);

            ViewBag.Message = "Product is delete!";

            return View();
        }
    }
}
