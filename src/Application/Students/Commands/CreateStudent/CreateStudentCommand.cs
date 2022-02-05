using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Domain.Entities;
using MediatR;

namespace CleanArchitecth.Application.Students.Commands.CreateStudent;

public class CreateStudentCommand : IRequest<int>
{
    public string? Title { get; set; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Student();
        entity.Title = request.Title;
        _context.Students.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
