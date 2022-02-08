using CleanArchitecth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecth.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    /// <summary>
    /// DbSet para entidad producto
    /// </summary>
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
