﻿using CleanArchitecth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Student> Students { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
