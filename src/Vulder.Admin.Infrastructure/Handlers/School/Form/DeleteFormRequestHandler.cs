using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.School.Form
{
    public class DeleteFormRequestHandler : AsyncRequestHandler<JwtModel>
    {
        private readonly ISchoolFormRepository _repository;

        public DeleteFormRequestHandler(ISchoolFormRepository repository)
        {
            _repository = repository;
        }
        
        protected override async Task Handle(JwtModel request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(new Guid(request.Id));
        }
    }
}