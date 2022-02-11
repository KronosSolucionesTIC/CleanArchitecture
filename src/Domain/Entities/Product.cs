using System.ComponentModel.DataAnnotations;

namespace CleanArchitecth.Domain.Entities;

/// <summary>
/// Clase para la entidad producto
/// </summary>
public class Product
{
    
    /// <summary>
    /// Id del producto
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Codigo del producto
    /// </summary>
    [Required]
    public string? Code { get; set; }
    /// <summary>
    /// Nombre del producto
    /// </summary>
    [Required]
    public string? Name { get; set; }
    /// <summary>
    /// Descripción del producto
    /// </summary>
    [Required]
    public string? Description { get; set; }
    /// <summary>
    /// Precio del producto
    /// </summary>
    [Required]
    public int? Price { get; set; }
    /// <summary>
    /// Imagen del producto
    /// </summary>
    [Required]
    public string? Image { get; set; }
}
