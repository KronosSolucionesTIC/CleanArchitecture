using CleanArchitecth.Application.TodoLists.Queries.ExportTodos;

namespace CleanArchitecth.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
