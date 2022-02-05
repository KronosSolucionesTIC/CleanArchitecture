using CleanArchitecth.Application.Common.Exceptions;
using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;

namespace CleanArchitecth.Application.Students.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest
{
    public int Id { get; set; }

    public string? Title { get; set; }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
