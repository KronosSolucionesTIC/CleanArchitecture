using CleanArchitecth.Application.Clientes.Commands.CreateCliente;
using CleanArchitecth.Application.Clientes.Queries.GetClientes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;
/// <summary>
/// Controller para cliente
/// </summary>
public class ClienteController : ApiControllerBase
{
    /// <summary>
    /// Servicio API para obtener cliente
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<ClienteVm>> Get()
    {
        return await Mediator.Send(new GetClienteQuery());
    }

    /// <summary>
    /// Servicio API para crear cliente
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [EnableCors("DevCorsPolicy")]
    public async Task<ActionResult<int>> Create(CreateClienteCommand command)
    {
        return await Mediator.Send(command);
    }
}