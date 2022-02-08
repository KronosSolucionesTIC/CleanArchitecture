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

    public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {

        return new ProductVm
        {
            Lists = await _context.Products
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken)
        };
    }
}

