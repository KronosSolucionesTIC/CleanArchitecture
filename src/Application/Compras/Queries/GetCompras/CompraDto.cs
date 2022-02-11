using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecth.Application.Compras.Queries.GetCompras;

public class ComprasDto : IMapFrom<Compra>
{
    /// <summary>
    /// Id de la compra
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Codigo del producto
    /// </summary>
    public int? IdProduct { get; set; }
    /// <summary>
    /// Cantidad de la compra
    /// </summary>
    public int? Cantidad { get; set; }
    /// <summary>
    /// Precio unitario
    /// </summary>
    public int? PrecioUnitario { get; set; }
    /// <summary>
    /// Precio total
    /// </summary>
    public int? PrecioTotal { get; set; }
    /// <summary>
    /// Nombre del producto
    /// </summary>
    public string? Name { get; set; }
}