using CleanArchitecth.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Students.Commands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Students
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
