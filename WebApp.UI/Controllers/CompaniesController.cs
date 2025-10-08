using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CompaniesController(
            ILogger<CompaniesController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Companies
        public async Task<IActionResult> Index()
        {
            // Obtener empresas del usuario desde API
            return View();
        }

        // GET: /Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Llamar a API para crear empresa
            return RedirectToAction(nameof(Index));
        }

        // GET: /Companies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Obtener empresa desde API
            return View();
        }

        // POST: /Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Actualizar empresa via API
            return RedirectToAction(nameof(Index));
        }

        // GET: /Companies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // POST: /Companies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Eliminar empresa via API
            return RedirectToAction(nameof(Index));
        }

        // GET: /Companies/ManageUsers/5
        public async Task<IActionResult> ManageUsers(int id)
        {
            // Gestionar usuarios de la empresa
            return View();
        }

        // POST: /Companies/AssignUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignUser(int companyId, string userId, string role)
        {
            // Asignar usuario a empresa via API
            return RedirectToAction(nameof(ManageUsers), new { id = companyId });
        }

        // POST: /Companies/RemoveUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUser(int companyId, string userId)
        {
            // Remover usuario de empresa via API
            return RedirectToAction(nameof(ManageUsers), new { id = companyId });
        }

        // GET: /Companies/SelectActive
        public async Task<IActionResult> SelectActive()
        {
            // Seleccionar empresa activa para trabajar
            return View();
        }

        // POST: /Companies/SetActive
        [HttpPost]
        public async Task<IActionResult> SetActive(int companyId)
        {
            // Guardar en sesión la empresa activa
            HttpContext.Session.SetInt32("ActiveCompanyId", companyId);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
