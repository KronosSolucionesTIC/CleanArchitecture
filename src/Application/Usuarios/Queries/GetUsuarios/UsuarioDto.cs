using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecth.Application.Usuarios.Queries.GetUsuarios;
/// <summary>
/// Dto del usuario
/// </summary>
public class UsuarioDto : IMapFrom<Usuario>
{
    /// <summary>
    /// Id del usuario
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Password del usuario
    /// </summary>
    public string? Pass { get; set; }
    /// <summary>
    /// Rol del usuario
    /// </summary>
    public int? Role { get; set; }

}