using CleanArchitecth.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;

public class ProductController : ApiControllerBase
{
    /// <summary>
    /// Servicio API para obtener producto
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<ProductVm>> Get()
    {
        return await Mediator.Send(new GetProductQuery());
    }
}