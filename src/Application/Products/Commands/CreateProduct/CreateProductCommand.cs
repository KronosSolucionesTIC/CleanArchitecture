using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;

namespace CleanArchitecth.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    /// <summary>
    /// Name del producto
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Descripcion del producto
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Imagen del producto
    /// </summary>
    public string? Image { get; set; }
    /// <summary>
    /// Codigo del producto
    /// </summary>
    public string? Code { get; set; }
    /// <summary>
    /// Precio del producto
    /// </summary>
    public int? Price { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Command para la creacion del producto
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product();
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Image = request.Image;
        entity.Code = request.Code;
        entity.Price = request.Price;
        _context.Products.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

