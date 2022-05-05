using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecth.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecth.Application.Products.Queries.GetProducts;

public class GetProductQuery : IRequest<ProductVm>
{
}

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Query para obtener el producto
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        Log.Debug($"Inicia Product/GetProductQuery");
        try
        {
            return new ProductVm
            {
                ListProducts = await _context.Products
                    .AsNoTracking()
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Name)
                    .ToListAsync(cancellationToken)
            };
        }
        catch (Exception ex)
        {
            Log.Debug($"Error Product/GetProductQuery: {ex.Message}-{ex.InnerException}");
            throw;
        }
        Log.Debug($"Termina Product/GetProductQuery");
    }
}