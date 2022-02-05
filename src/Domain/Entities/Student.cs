namespace CleanArchitecth.Domain.Entities;

public class Student : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
