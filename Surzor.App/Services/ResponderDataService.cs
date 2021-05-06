using AutoMapper;
using Blazored.LocalStorage;
using Surzor.App.Contracts;
using Surzor.App.Services.Base;
using Surzor.App.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.App.Services
{
    public class ResponderDataService : BaseDataService, IResponderDataService
    {
        private readonly IMapper _mapper;

        public ResponderDataService(IClient client, IMapper mapper, ILocalStorageService service) : base(client, service)
        {
            _mapper = mapper;
        }

        public async Task<ICollection<ResponderListViewModel>> GetAllResponders() =>
          _mapper.Map<ICollection<ResponderListViewModel>>((await _client.GetAllRespondersAsync(new CancellationToken())));
    }
}
