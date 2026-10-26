using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _productService.CreateProduct(model);
            return RedirectToAction(nameof(ProductIndex));
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var model = await _productService.FindProductById(id);
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _productService.UpdateProduct(model);
            return RedirectToAction(nameof(ProductIndex));
        }

        public async Task<IActionResult> ProductDelete(long id)
        {
            var model = await _productService.FindProductById(id);
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var deleted = await _productService.DeleteProductById(model.Id);
            if (!deleted) return NotFound();

            return RedirectToAction(nameof(ProductIndex));
        }
    }
}
