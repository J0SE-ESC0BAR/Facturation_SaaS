using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(
            ILogger<DashboardController> logger,
            UserManager<ApplicationUser> userManager,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // TODO: Llamar a WebApp.API para obtener estadísticas
            // var client = _httpClientFactory.CreateClient("API");
            // var stats = await client.GetFromJsonAsync<DashboardStatsViewModel>($"api/dashboard/{user.Id}");

            var model = new DashboardStatsViewModel
            {
                TotalRevenue = 25450,
                MonthlyRevenue = 25450,
                TotalInvoices = 150,
                MonthlyInvoices = 15,
                TotalClients = 42,
                ActiveClients = 42,
                PendingInvoices = 7,
                OverdueInvoices = 2,
                PendingAmount = 8500,
                OverdueAmount = 1200,
                RecentInvoices = new List<RecentInvoiceViewModel>
                {
                    new() { Id = 1, InvoiceNumber = "FAC-001", ClientName = "Empresa ABC S.A.", Date = DateTime.Now.AddDays(-1), Status = "Pagada", Amount = 1250 },
                    new() { Id = 2, InvoiceNumber = "FAC-002", ClientName = "Comercial XYZ Ltda.", Date = DateTime.Now.AddDays(-2), Status = "Pendiente", Amount = 2800 },
                    new() { Id = 3, InvoiceNumber = "FAC-003", ClientName = "Servicios DEF S.A.S.", Date = DateTime.Now.AddDays(-3), Status = "Pagada", Amount = 750 }
                }
            };
            
            return View(model);
        }
    }
}
