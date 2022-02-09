using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;

namespace CleanArchitecth.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Code { get; set; }

    public int? Price { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

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

