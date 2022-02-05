using CleanArchitecth.Application.Common.Exceptions;
using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Students.Commands.DeleteStudent;

public class DeleteStudentCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        _context.Students.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
