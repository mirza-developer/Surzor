using System.Collections.Generic;
using Surzor.Application.Features.Responders.Queries;

namespace Surzor.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportProductsToCsv(List<ResponderExportDto> data);
    }
}
