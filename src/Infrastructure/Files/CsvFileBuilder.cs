using System.Globalization;
using CleanArchitecth.Application.Common.Interfaces;
using CleanArchitecth.Application.TodoLists.Queries.ExportTodos;
using CleanArchitecth.Infrastructure.Files.Maps;
using CsvHelper;

namespace CleanArchitecth.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
