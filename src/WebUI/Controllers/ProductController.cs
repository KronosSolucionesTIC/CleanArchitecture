using CleanArchitecth.Application.Products.Commands.CreateProduct;
using CleanArchitecth.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;
/// <summary>
/// Controller para producto
/// </summary>
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

    /// <summary>
    /// Servicio API para crear producto
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }
}