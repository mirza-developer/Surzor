using Surzor.Application.Contracts.Persistence.Repositories;
using Surzor.Domain.Entities;

namespace Surzor.Persistence.Repositories
{
    public class ResponderRepository : BaseRepository<Responder>, IResponderRepository
    {
        public ResponderRepository(SurzorDbContext context) : base(context)
        {
        }
    }
}
