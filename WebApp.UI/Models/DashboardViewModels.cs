namespace WebApp.UI.Models
{
    public class DashboardStatsViewModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public int TotalInvoices { get; set; }
        public int MonthlyInvoices { get; set; }
        public int TotalClients { get; set; }
        public int ActiveClients { get; set; }
        public int PendingInvoices { get; set; }
        public int OverdueInvoices { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal OverdueAmount { get; set; }
        public List<RecentInvoiceViewModel> RecentInvoices { get; set; } = new();
        public List<MonthlyRevenueChartData> MonthlyRevenueChart { get; set; } = new();
        public List<TopClientViewModel> TopClients { get; set; } = new();
    }

    public class RecentInvoiceViewModel
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class MonthlyRevenueChartData
    {
        public string Month { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int InvoicesCount { get; set; }
    }

    public class TopClientViewModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
        public int InvoicesCount { get; set; }
    }
}