using CsvHelper;
using Surzor.Application.Contracts.Infrastructure;
using System.Collections.Generic;
using System.IO;
using Surzor.Application.Features.Responders.Queries;

namespace Surzor.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportProductsToCsv(List<ResponderExportDto> data)
        {
            using MemoryStream memoryStream = new();
            using (StreamWriter streamWriter = new(memoryStream))
            {
                using CsvWriter csvWriter = new(streamWriter);
                csvWriter.WriteRecords(data);
            }
            return memoryStream.ToArray();
        }
    }
}
