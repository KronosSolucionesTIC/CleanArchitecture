namespace CleanArchitecth.Application.Products.Queries.GetProducts;
/// <summary>
/// Vm del producto
/// </summary>
public class ProductVm
{
    public IList<ProductDto> ListProducts { get; set; } = new List<ProductDto>();
}
