using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;

namespace CleanArchitecth.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
