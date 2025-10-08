using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public SettingsController(
            ILogger<SettingsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Settings
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Settings/Profile
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        // POST: /Settings/Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Profile));
        }

        // GET: /Settings/Security
        public IActionResult Security()
        {
            return View();
        }

        // POST: /Settings/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Security", model);

            return RedirectToAction(nameof(Security));
        }

        // GET: /Settings/InvoiceTemplates
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InvoiceTemplates()
        {
            return View();
        }

        // POST: /Settings/SaveTemplate
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTemplate(InvoiceTemplateViewModel model)
        {
            if (!ModelState.IsValid)
                return View("InvoiceTemplates", model);

            return RedirectToAction(nameof(InvoiceTemplates));
        }

        // GET: /Settings/Notifications
        public async Task<IActionResult> Notifications()
        {
            return View();
        }

        // POST: /Settings/Notifications
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Notifications(NotificationSettingsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Notifications));
        }

        // GET: /Settings/FiscalConfiguration
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FiscalConfiguration()
        {
            // Configuración DGII/MH
            return View();
        }

        // POST: /Settings/FiscalConfiguration
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FiscalConfiguration(FiscalConfigViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(FiscalConfiguration));
        }
    }
}
