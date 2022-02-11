using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;
using Serilog;

namespace CleanArchitecth.Application.Compras.Commands.CreateCompra;

public class CreateCompraCommand : IRequest<int>
{
    /// <summary>
    /// Id de la compra
    /// </summary>
    public int? Id { get; set; }
    /// <summary>
    /// Id del producto
    /// </summary>
    public int? IdProduct { get; set; }
    /// <summary>
    /// Cantidad
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

public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCompraCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Command para la creacion de la compra
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateCompraCommand request, CancellationToken cancellationToken)
    {
        Log.Debug($"Inicia Compras/CreateCompraCommand");
        try
        {
            var entity = new Compra();
            entity.IdProduct = request.IdProduct;
            entity.Cantidad = request.Cantidad;
            entity.PrecioUnitario = request.PrecioUnitario;
            entity.PrecioTotal = request.PrecioTotal;
            _context.Compras.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            Log.Debug($"Termina Compras/CreateCompraCommand");
            return entity.Id;
        }
        catch (Exception ex)
        {
            Log.Debug($"Error Compras/CreateCompraCommand: {ex.Message}-{ex.InnerException}");
            throw;
        }
    }
}
