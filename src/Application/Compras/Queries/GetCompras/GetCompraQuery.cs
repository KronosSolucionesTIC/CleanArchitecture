﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecth.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Compras.Queries.GetCompras;

public class GetCompraQuery : IRequest<ComprasVm>
{
}

public class GetCompraQueryHandler : IRequestHandler<GetCompraQuery, ComprasVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompraQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Query para obtener la compra
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ComprasVm> Handle(GetCompraQuery request, CancellationToken cancellationToken)
    {
        return new ComprasVm
        {
            //ListCompras = await _context.Compras
            //    .AsNoTracking()
            //    .ProjectTo<ComprasDto>(_mapper.ConfigurationProvider)
            //    .OrderBy(x => x.PrecioTotal)
            //    .ToListAsync(cancellationToken)

            ListCompras = _context.Compras
                  .AsNoTracking()
                  .ProjectTo<ComprasDto>(_mapper.ConfigurationProvider)
                  .GroupBy(x => x.IdProduct)
                  .Select(x => new ComprasDto { IdProduct = x.Key, PrecioTotal = x.Sum(y => y.Cantidad) }).ToList()
        };
            
    }
}
