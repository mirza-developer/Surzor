using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Surzor.Application.Contracts.Persistence.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Surzor.Domain.Entities;

namespace Surzor.Application.Features.Responders.Commands
{
    public class CreateResponderCommandHandler : IRequestHandler<CreateResponderCommand, CreateResponderCommandResponse>
    {
        private readonly IResponderRepository _repository;
        private readonly IMapper _mapper;

        public CreateResponderCommandHandler(IResponderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateResponderCommandResponse> Handle(CreateResponderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateResponderCommandValidator();
            var validateResult = await validator.ValidateAsync(request, cancellationToken);
            if (validateResult.Errors.Count > 0)
            //throw new ValidationException(validateResult.Errors);
            {
                var response = new CreateResponderCommandResponse()
                {
                    Message = "Data not in correct format",
                    Success = false,
                };
                foreach (ValidationFailure failure in validateResult.Errors)
                    response.Errors.Add(failure.ErrorMessage);
                return response;
            }
            var product = _mapper.Map<Responder>(request);
            product.Id = Guid.NewGuid();
            var result = await _repository.InsertInstance(product, cancellationToken);
            if (result)
                return new CreateResponderCommandResponse()
                {
                    Message = "اطلاعات با موفقیت ثبت شد",
                    ResponderId = product.Id,
                    Success = true,
                };
            return new CreateResponderCommandResponse()
            {
                Message = "در ثبت اطلاعات مشکلی بوجود آمده است",
                Success = false
            };
        }
    }
}
