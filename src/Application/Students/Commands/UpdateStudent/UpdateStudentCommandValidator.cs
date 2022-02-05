using CleanArchitecth.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Students.Commands.UpdateStudent;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(UpdateStudentCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.Students
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
