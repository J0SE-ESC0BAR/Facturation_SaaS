using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize(Roles = "Admin,Contador,Facturador")]
    public class PaymentsController : Controller
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentsController(
            ILogger<PaymentsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Payments
        public async Task<IActionResult> Index(DateTime? dateFrom, DateTime? dateTo)
        {
            return View();
        }

        // GET: /Payments/Register
        public async Task<IActionResult> Register(int? invoiceId)
        {
            return View();
        }

        // POST: /Payments/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Payments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // POST: /Payments/SendReminder/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendReminder(int invoiceId)
        {
            // Enviar recordatorio de pago
            TempData["SuccessMessage"] = "Recordatorio enviado";
            return RedirectToAction("Details", "Invoices", new { id = invoiceId });
        }

        // GET: /Payments/OnlinePayment/5
        public async Task<IActionResult> OnlinePayment(int invoiceId)
        {
            // Iniciar proceso de pago en línea
            return View();
        }

        // POST: /Payments/ProcessOnlinePayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessOnlinePayment(OnlinePaymentViewModel model)
        {
            // Procesar pago con pasarela
            return RedirectToAction("Details", "Invoices", new { id = model.InvoiceId });
        }
    }
}
