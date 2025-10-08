using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    [Authorize(Roles = "Admin,Facturador")]
    public class InvoicesController : Controller
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public InvoicesController(
            ILogger<InvoicesController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Invoices
        public async Task<IActionResult> Index(string? status, DateTime? dateFrom, DateTime? dateTo)
        {
            // Listar facturas con filtros
            return View();
        }

        // GET: /Invoices/Create
        public async Task<IActionResult> Create()
        {
            // Cargar clientes y productos desde API
            return View();
        }

        // POST: /Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Crear factura via API
            return RedirectToAction(nameof(Preview), new { id = model.Id });
        }

        // GET: /Invoices/Preview/5
        public async Task<IActionResult> Preview(int id)
        {
            // Previsualizar factura antes de enviar
            return View();
        }

        // POST: /Invoices/Submit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int id)
        {
            // Enviar factura a DGII/MH via API
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: /Invoices/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: /Invoices/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Solo si factura está en borrador
            return View();
        }

        // POST: /Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: /Invoices/Cancel/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, string reason)
        {
            // Cancelar factura via API
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: /Invoices/CreateCreditNote/5
        [Authorize(Roles = "Admin,Contador")]
        public async Task<IActionResult> CreateCreditNote(int invoiceId)
        {
            // Crear nota de crédito
            return View();
        }

        // POST: /Invoices/CreateCreditNote
        [HttpPost]
        [Authorize(Roles = "Admin,Contador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCreditNote(CreditNoteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Details), new { id = model.OriginalInvoiceId });
        }

        // GET: /Invoices/CreateDebitNote/5
        [Authorize(Roles = "Admin,Contador")]
        public async Task<IActionResult> CreateDebitNote(int invoiceId)
        {
            return View();
        }

        // POST: /Invoices/CreateDebitNote
        [HttpPost]
        [Authorize(Roles = "Admin,Contador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDebitNote(DebitNoteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction(nameof(Details), new { id = model.OriginalInvoiceId });
        }

        // GET: /Invoices/DownloadPDF/5
        public async Task<IActionResult> DownloadPDF(int id)
        {
            // Descargar PDF desde API
            return File(new byte[0], "application/pdf", $"factura-{id}.pdf");
        }

        // GET: /Invoices/DownloadJSON/5
        public async Task<IActionResult> DownloadJSON(int id)
        {
            // Descargar JSON desde API
            return File(new byte[0], "application/json", $"factura-{id}.json");
        }

        // POST: /Invoices/SendEmail/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(int id, string email)
        {
            // Enviar factura por email via API
            TempData["SuccessMessage"] = "Factura enviada correctamente";
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: /Invoices/History/5
        public async Task<IActionResult> History(int id)
        {
            // Ver historial de cambios de la factura
            return View();
        }
    }
}
