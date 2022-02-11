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
    /// <summary>
    /// DbSet para entidad usuario
    /// </summary>
    DbSet<Usuario> Usuarios { get; }
    /// <summary>
    /// DbSet para entidad compras
    /// </summary>
    DbSet<Compra> Compras { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
