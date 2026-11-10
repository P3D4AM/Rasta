using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>اطلاعات تجاری — اولویت ۴ (در صورت نیاز MedPad).</summary>
[ApiController]
[Authorize]
public class CommercialController : ControllerBase
{
    private readonly IWarehouseRepository _warehouses;
    private readonly IProductRepository _products;
    private readonly IOrderRepository _orders;

    public CommercialController(IWarehouseRepository warehouses, IProductRepository products, IOrderRepository orders)
    {
        _warehouses = warehouses;
        _products = products;
        _orders = orders;
    }

    /// <summary>فهرست انبارها (به‌طور پیش‌فرض فقط فعال‌ها).</summary>
    [HttpGet("api/v1/warehouses")]
    public async Task<IActionResult> Warehouses([FromQuery] bool includeDeactivated = false, CancellationToken ct = default)
    {
        var result = await _warehouses.GetWarehousesAsync(includeDeactivated, ct);
        return Ok(ApiResponse<IReadOnlyList<WarehouseDto>>.Ok(result.Items));
    }

    /// <summary>فهرست محصولات.</summary>
    [HttpGet("api/v1/products")]
    public async Task<IActionResult> Products([FromQuery] ProductListQuery q, CancellationToken ct)
    {
        var result = await _products.GetProductsAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<ProductDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }

    /// <summary>فهرست سفارش‌های فروش.</summary>
    [HttpGet("api/v1/orders")]
    public async Task<IActionResult> Orders([FromQuery] OrderListQuery q, CancellationToken ct)
    {
        var result = await _orders.GetOrdersAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<OrderDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }

    /// <summary>فهرست پیش‌سفارش‌ها.</summary>
    [HttpGet("api/v1/preorders")]
    public async Task<IActionResult> PreOrders([FromQuery] PreOrderListQuery q, CancellationToken ct)
    {
        var result = await _orders.GetPreOrdersAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<PreOrderDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }
}
