using CleanArchitecth.Application.Compras.Commands.CreateCompra;
using CleanArchitecth.Application.Compras.Queries.GetCompras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;

public class CompraController : ApiControllerBase
{
    /// <summary>
    /// Servicio API para obtener producto
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<ComprasVm>> Get()
    {
        return await Mediator.Send(new GetCompraQuery());
    }

    /// <summary>
    /// Servicio API para crear compra
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<int>> Create(CreateCompraCommand command)
    {
        return await Mediator.Send(command);
    }
}