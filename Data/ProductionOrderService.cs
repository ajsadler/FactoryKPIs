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
            return await _context.ProductionOrders.ToListAsync();
        }
    }
}