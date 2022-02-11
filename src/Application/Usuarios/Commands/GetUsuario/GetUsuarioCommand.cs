using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;
using Serilog;

namespace CleanArchitecth.Application.Usuarios.Commands.GetUsuario;

public class GetUsuarioCommand : IRequest<int>
{
    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Pass del usuario
    /// </summary>
    public string? Pass { get; set; }
}

public class GetUsuarioCommandHandler : IRequestHandler<GetUsuarioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public GetUsuarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Command para obtener usuario
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(GetUsuarioCommand request, CancellationToken cancellationToken)
    {
        Log.Debug($"Inicia Usuarios/GetUsuarioCommand");
        try
        {
            var entity = new Usuario();
            entity.Name = request.Name;
            entity.Pass = request.Pass;
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        catch (Exception ex)
        {
            Log.Debug($"Error Usuarios/GetUsuarioCommand: {ex.Message}-{ex.InnerException}");
            throw;
        }
        Log.Debug($"Termina Usuarios/GetUsuarioCommand");
    }
}

