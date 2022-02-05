namespace CleanArchitecth.Application.Students.Queries.GetStudents;

public class StudentsVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<StudentsDto> Lists { get; set; } = new List<StudentsDto>();
}
