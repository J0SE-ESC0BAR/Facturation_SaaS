using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models; // Asegúrate de tener la directiva using correcta para ProductViewModel

namespace WebApp.UI.Controllers
{
    [Authorize(Roles = "Admin,Facturador")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(
            ILogger<ProductsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Products
        public async Task<IActionResult> Index(string? category, string? search)
        {
            return View();
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // POST: /Products/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Import
        [Authorize(Roles = "Admin")]
        public IActionResult Import()
        {
            return View();
        }

        // POST: /Products/Import
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar un archivo");
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
