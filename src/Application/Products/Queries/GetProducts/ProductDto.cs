﻿using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;

namespace CleanArchitecth.Application.Products.Queries.GetProducts;

public class ProductDto: IMapFrom<Product>
{
    /// <summary>
    /// Id del producto
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Codigo del producto
    /// </summary>
    public string? Code { get; set; }
    /// <summary>
    /// Nombre del producto
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Descripción del producto
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Precio del producto
    /// </summary>
    public int? Price { get; set; }
    /// <summary>
    /// Imagen del producto
    /// </summary>
    public string? Image { get; set; }
}