using Microsoft.EntityFrameworkCore;

namespace FactoryKPIs.Data
{
    public class ProductionOrderService
    {
        private readonly ApplicationDbContext _context;

        public ProductionOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductionOrder>> GetProductionOrdersAsync()
        {
            var today = DateTime.UtcNow.Date; // Get today's date (UTC)

            return await _context.ProductionOrders
                .Where(po => po.UpdateTs >= today && po.UpdateTs < today.AddDays(1)) // Only fetch today's data
                .ToListAsync();
        }
    }
}