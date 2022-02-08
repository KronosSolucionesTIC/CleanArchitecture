using CleanArchitecth.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;

[Authorize]
public class ProductController : ApiControllerBase
{
    /// <summary>
    /// Servicio API para obtener producto
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ProductVm>> Get()
    {
        return await Mediator.Send(new GetProductQuery());
    }
}