using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;

namespace CleanArchitecth.Application.Compras.Commands.CreateCompra;

public class CreateCompraCommand : IRequest<int>
{
    public int? Id { get; set; }

    public int? IdProduct { get; set; }

    public int? Cantidad { get; set; }

    public int? PrecioUnitario { get; set; }

    public int? PrecioTotal { get; set; }
}

public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCompraCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
    {
        var entity = new Compra();
        entity.IdProduct = request.IdProduct;
        entity.Cantidad = request.Cantidad;
        entity.PrecioUnitario = request.PrecioUnitario;
        entity.PrecioTotal = request.PrecioTotal;
        _context.Compras.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
