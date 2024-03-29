﻿using CleanArchitecth.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Usuarios.Commands.GetUsuario;

public class GetUsuarioCommandValidator : AbstractValidator<GetUsuarioCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Validator para obtener usuario
    /// </summary>
    /// <param name="context"></param>
    public GetUsuarioCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Nombre es requerido.");
    }
}