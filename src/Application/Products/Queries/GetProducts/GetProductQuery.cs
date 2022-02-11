using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecth.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        return new ProductVm
        {
            ListProducts = await _context.Products
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken)
        };
    }
}

