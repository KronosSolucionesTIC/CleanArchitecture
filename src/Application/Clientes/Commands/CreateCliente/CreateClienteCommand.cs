using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using CleanArchitecth.Domain.Enums;
using MediatR;
using Serilog;

namespace CleanArchitecth.Application.Clientes.Commands.CreateCliente;

public class CreateClienteCommand : IRequest<int>
{
    /// <summary>
    /// Nombres del cliente
    /// </summary>
    public string Nombres { get; set; }
    /// <summary>
    /// Apellidos del cliente
    /// </summary>
    public string Apellidos { get; set; }
    /// <summary>
    /// Documento del cliente
    /// </summary>
    public int Documento { get; set; }
    /// <summary>
    /// Tipo de documento
    /// </summary>
    public TipoDocumento TipoDoc { get; set; }
}

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClienteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Command para la creacion del cliente
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        Log.Debug($"Inicia Cliente/CreateClienteCommand");
        try
        {
            var entity = new Cliente();
            entity.Nombres = request.Nombres;
            entity.Apellidos = request.Apellidos;
            entity.Documento = request.Documento;
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            Log.Debug($"Termina Cliente/CreateClienteCommand");
            return entity.Id;
        }
        catch (Exception ex)
        {
            Log.Error($"Error Cliente/CreateClienteCommand: {ex.Message}-{ex.InnerException}");
            throw;
        }
    }
}