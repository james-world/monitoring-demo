using Microsoft.AspNetCore.Mvc;

namespace Acme.Features.Orders
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ProductCatalog _catalog;

        public OrdersController(ProductCatalog catalog)
            => _catalog = catalog;

        [HttpPost]
        public IActionResult PlaceOrder(NewOrder order)
        {
            if (!_catalog.IsInCatalog(order.Product))
                return NotFound($"Product {order.Product} is not in the catalog.");

            if (!_catalog.TryPlaceOrder(order.Product, order.Amount))
                return Conflict($"Stock not available for product {order.Product}.");

            return Accepted((object)$"Order for {order.Amount} × {order.Product} accepted.");
        }
    }
}