using CleanArchitecth.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Nombre es requerido.")
            .MaximumLength(200).WithMessage("Nombre no puede exceder los 200 caracteres.")
            .MustAsync(BeUniqueTitle).WithMessage("El nombre de producto ya existe.");
    }

    public async Task<bool> BeUniqueTitle(string name, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AllAsync(l => l.Name != name, cancellationToken);
    }
}