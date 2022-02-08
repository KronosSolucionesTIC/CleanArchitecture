namespace CleanArchitecth.Application.Products.Queries.GetProducts;

public class ProductVm
{
    public IList<ProductDto> ListProducts { get; set; } = new List<ProductDto>();
}
