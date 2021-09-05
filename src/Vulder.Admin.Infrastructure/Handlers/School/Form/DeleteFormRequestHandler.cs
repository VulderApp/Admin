using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Handlers.School.Form
{
    public class DeleteFormRequestHandler : IRequestHandler<DeleteFormModel, bool>
    {
        private readonly ISchoolFormRepository _repository;

        public DeleteFormRequestHandler(ISchoolFormRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<bool> Handle(DeleteFormModel request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}