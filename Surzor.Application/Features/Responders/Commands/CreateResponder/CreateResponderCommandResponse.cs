using Surzor.Application.Responses;
using System;

namespace Surzor.Application.Features.Responders.Commands
{
    public class CreateResponderCommandResponse : BaseResponse
    {
        public Guid ResponderId { get; set; }
    }
}
