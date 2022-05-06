namespace CleanArchitecth.Domain.Entities;

/// <summary>
/// Clase para la entidad producto
/// </summary>
public class Usuario
{
    /// <summary>
    /// Id del usuario
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Usuario
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Password
    /// </summary>
    public string? Pass { get; set; }
    /// <summary>
    /// Rol
    /// </summary>
    public int Role { get; set; }
}
