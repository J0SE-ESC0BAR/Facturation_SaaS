using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize(Roles = "Admin,Facturador")]
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientsController(
            ILogger<ClientsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Clients
        public async Task<IActionResult> Index(string? search)
        {
            return View();
        }

        // GET: /Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Crear cliente via API
            return RedirectToAction(nameof(Index));
        }

        // GET: /Clients/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: /Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Clients/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // POST: /Clients/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: /Clients/Import
        [Authorize(Roles = "Admin")]
        public IActionResult Import()
        {
            return View();
        }

        // POST: /Clients/Import
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

            // Procesar CSV via API
            return RedirectToAction(nameof(Index));
        }

        // GET: /Clients/ValidateTaxId
        [HttpGet]
        public async Task<JsonResult> ValidateTaxId(string taxId)
        {
            // Validar RNC/Cédula via API
            return Json(new { isValid = true, name = "Nombre del cliente" });
        }

        // GET: /Clients/AccountStatement/5
        public async Task<IActionResult> AccountStatement(int id)
        {
            // Estado de cuenta del cliente
            return View();
        }
    }
}
