using CleanArchitecth.Application.Usuarios.Commands.GetUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecth.WebUI.Controllers;
/// <summary>
/// Controller para usuario
/// </summary>
public class UsuarioController : ApiControllerBase
{
    ///// <summary>
    ///// Servicio API para obtener login
    ///// </summary>
    ///// <param name="command"></param>
    ///// <returns></returns>
    //[HttpPost]
    //[EnableCors("DevCorsPolicy")]
    //public async Task<ActionResult<int>> Login(GetUsuarioCommand command)
    //{
    //    return await Mediator.Send(command);
    //}
}