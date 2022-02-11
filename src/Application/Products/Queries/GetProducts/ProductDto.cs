using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecth.Application.Products.Queries.GetProducts;
/// <summary>
/// Dto del producto
/// </summary>
public class ProductDto: IMapFrom<Product>
{
    /// <summary>
    /// Id del producto
    /// </summary>
    [Required]
    [StringLength(200, ErrorMessage = "El nombre no puede ser mayor a 200 caracteres.")]
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
    /// <summary>
    /// Cantidad
    /// </summary>
    [Required]
    public int Amount { get; set; } = 0;
}