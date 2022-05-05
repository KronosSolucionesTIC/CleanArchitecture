using CleanArchitecth.Application.Common.Exceptions;
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
    public int Id { get; set; }
    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Pass del usuario
    /// </summary>
    public string? Pass { get; set; }

    /// <summary>
    /// Rol del usuario
    /// </summary>
    public int? Role { get; set; }
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
            var entity = await _context.Usuarios
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Name);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Role;
        }
        catch (Exception ex)
        {
            Log.Debug($"Error Usuarios/GetUsuarioCommand: {ex.Message}-{ex.InnerException}");
            throw;
        }
        Log.Debug($"Termina Usuarios/GetUsuarioCommand");
    }
}



