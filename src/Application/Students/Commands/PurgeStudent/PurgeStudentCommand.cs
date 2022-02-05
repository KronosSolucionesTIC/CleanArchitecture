using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Application.Common.Security;
using MediatR;

namespace CleanArchitecth.Application.Students.Commands.PurgeStudent;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public class PurgeStudentCommand : IRequest
{
}

public class PurgeStudentCommandHandler : IRequestHandler<PurgeStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PurgeStudentCommand request, CancellationToken cancellationToken)
    {
        _context.Students.RemoveRange(_context.Students);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
