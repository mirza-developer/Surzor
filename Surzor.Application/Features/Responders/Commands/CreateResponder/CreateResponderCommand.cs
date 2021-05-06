using MediatR;

namespace Surzor.Application.Features.Responders.Commands
{
    public class CreateResponderCommand : IRequest<CreateResponderCommandResponse>
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
