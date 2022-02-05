using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Students.Queries.GetStudents;

public class GetStudentsQuery : IRequest<StudentsVm>
{
}

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, StudentsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StudentsVm> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return new StudentsVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = await _context.Students
                .AsNoTracking()
                .ProjectTo<StudentsDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
