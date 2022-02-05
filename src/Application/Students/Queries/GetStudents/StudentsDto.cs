using CleanArchitecth.Application.Common.Mappings;
using CleanArchitecth.Domain.Entities;

namespace CleanArchitecth.Application.Students.Queries.GetStudents;

public class StudentsDto : IMapFrom<Student>
{
    public StudentsDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
