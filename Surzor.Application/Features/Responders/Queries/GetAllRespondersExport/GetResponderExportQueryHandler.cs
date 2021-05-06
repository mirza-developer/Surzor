using AutoMapper;
using MediatR;
using Surzor.Application.Contracts.Infrastructure;
using Surzor.Application.Contracts.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Application.Features.Responders.Queries
{
    public class GetResponderExportQueryHandler : IRequestHandler<GetResponderExportQuery, ResponderExportVm>
    {
        private readonly IResponderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetResponderExportQueryHandler(IResponderRepository repository, IMapper mapper, ICsvExporter csvExporter)
        {
            _repository = repository;
            _mapper = mapper;
            _csvExporter = csvExporter;
        }
        public async Task<ResponderExportVm> Handle(GetResponderExportQuery request, CancellationToken cancellationToken)
            =>
            new ResponderExportVm()
            {
                Data = _csvExporter.ExportProductsToCsv(
                    _mapper.Map<List<ResponderExportDto>>(await _repository.GetAllData(cancellationToken))),
                FileName = $"{Guid.NewGuid()}.csv",
                FileType = "text/csv"
            };
    }
}