using MediatR;
using System.Collections.Generic;

namespace Surzor.Application.Features.Responders.Queries
{
    public class GetAllResponderListQuery : IRequest<List<AllResponderListVm>>
    {
    }
}
