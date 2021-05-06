using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Surzor.Application.Contracts.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Application.Features.Responders.Queries
{
    public class GetAllResponderListQueryHandler : IRequestHandler<GetAllResponderListQuery, List<AllResponderListVm>>
    {
        private readonly IResponderRepository _repository;
        private readonly IMapper _mapper;

        public GetAllResponderListQueryHandler(IResponderRepository repository, IMapper mapper, ILogger<GetAllResponderListQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AllResponderListVm>> Handle(GetAllResponderListQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<List<AllResponderListVm>>(await _repository.GetAllData(cancellationToken));
    }
}
