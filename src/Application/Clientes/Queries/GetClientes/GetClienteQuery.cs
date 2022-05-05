using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecth.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecth.Application.Clientes.Queries.GetClientes;

public class GetClienteQuery : IRequest<ClienteVm>
{
}

public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, ClienteVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClienteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Query para obtener el cliente
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ClienteVm> Handle(GetClienteQuery request, CancellationToken cancellationToken)
    {
        Log.Debug($"Inicia Cliente/GetClienteQuery");
        try
        {
            return new ClienteVm
            {
                ListClientes = await _context.Clientes
                    .AsNoTracking()
                    .ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Nombres)
                    .ToListAsync(cancellationToken)
            };
        }
        catch (Exception ex)
        {
            Log.Debug($"Error Cliente/GetClienteQuery: {ex.Message}-{ex.InnerException}");
            throw;
        }
        Log.Debug($"Termina Cliente/GetClienteQuery");
    }
}