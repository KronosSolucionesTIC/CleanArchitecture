﻿namespace CleanArchitecth.Domain.Entities;

/// <summary>
/// Clase para la entidad producto
/// </summary>
public class Compra
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
}
